package com.windsor.node.plugin.windsor.csv;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.IOCase;
import org.apache.commons.io.filefilter.SuffixFileFilter;
import org.supercsv.io.CsvListReader;
import org.supercsv.io.ICsvListReader;
import org.supercsv.prefs.CsvPreference;

import javax.sql.DataSource;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.FileSystems;
import java.nio.file.Files;
import java.nio.file.Path;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

/**
 * Provides a plugin that will check a directory for CSV files and then import each file into a
 * database table of the same name.
 */
public class CsvToDatabaseImportService extends BaseWnosPlugin {

    public static final PluginServiceParameterDescriptor IMPORT_FILE_PATH =
            new PluginServiceParameterDescriptor("Location with CSV files to import",
                    "java.lang.String", Boolean.TRUE,
                    "The path to a directory on the filesystem where this plugin will find the CSV" +
                            " files to import. Each CSV file needs to have the same name as a database table" +
                            " in the target database server. The name of these files should be in the format" +
                            " \"SCHEMA.TABLE_NAME.CSV\".");

    public static final PluginServiceParameterDescriptor TRUNCATE_TARGET_TABLE =
            new PluginServiceParameterDescriptor(
                    "Flag indicating if the target database table should be truncated before importing",
                    "java.lang.String", Boolean.FALSE,
                    "If this parameter is set to \"True\", the target database table will be" +
                            " truncated before the CSV data is imported.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    protected DataSource dataSource;

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("CSV File Import Service");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR
                .setDescription("Imports CSV files from the filesystem into the target database server.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(CsvToDatabaseImportService.class.getCanonicalName());
    }

    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public CsvToDatabaseImportService() {

        setPublishForEN11(false);
        setPublishForEN20(false);

        getDataSources().put(ARG_DS_SOURCE, null);
        getSupportedPluginTypes().add(ServiceType.TASK);
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {

        List<PluginServiceParameterDescriptor> params = new ArrayList();
        params.add(IMPORT_FILE_PATH);
        params.add(TRUNCATE_TARGET_TABLE);
        return params;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getConfigurationArguments() == null) {
            throw new RuntimeException("ConfigurationArguments were empty.");
        }

        // make sure the run time args are set
        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the source data source is set
        if (!getDataSources().containsKey(ARG_DS_SOURCE))
        {
            throw new RuntimeException("Data source not set");
        }

        dataSource = getDataSources().get(ARG_DS_SOURCE);
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        // setup our result
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        // flag indicating that no further processing should be performed
        boolean haltProcessing = false;

        // get a handle on our parameters
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        String importFilePathName = null;
        Boolean truncateTargetTable = false;

        // parse out our parameters
        if(!haltProcessing) {

            if(namedParams.get(IMPORT_FILE_PATH.getName()) != null) {
                importFilePathName = namedParams.get(IMPORT_FILE_PATH.getName()).toString();
            } else {
                haltProcessing = true;
                logProgress(result, "No import file path was provided", true);
            }

            if(namedParams.get(TRUNCATE_TARGET_TABLE.getName()) != null) {
                if(namedParams.get(TRUNCATE_TARGET_TABLE.getName()).toString().toLowerCase().trim().equals("true")
                        || namedParams.get(TRUNCATE_TARGET_TABLE.getName()).toString().toLowerCase().trim().equals("yes"))
                truncateTargetTable = true;
            }
        }

        // recap our parameters
        if(!haltProcessing) {
            logProgress(result,"I will check the path \"" + importFilePathName + "\" for CSV files");
            if(truncateTargetTable) {
                logProgress(result, "Target tables in the database will be truncated before CSV data is imported");
            } else {
                logProgress(result, "Imported CSV data will be appended to the target tables in the database");
            }
        }

        // ensure the export path is readable, etc.
        Path importFilePath = null;
        if(!haltProcessing) {

             importFilePath = FileSystems.getDefault().getPath(importFilePathName);

            if(!Files.exists(importFilePath)) {

                logProgress(result, "The import file path \"" + importFilePath + "\" does not exist, exiting.",
                        true);
                haltProcessing = true;
            }

            if(!Files.isDirectory(importFilePath)) {

                logProgress(result, "The import file path \"" + importFilePath +
                        "\" does not point to a directory, exiting.", true);
                haltProcessing = true;
            }

            if(!Files.isReadable(importFilePath)) {

                logProgress(result, "The export file path \"" + importFilePath +
                        "\" is not readable, exiting.", true);
                haltProcessing = true;
            }
        }

        // check our database
        if(!haltProcessing) {
            if (dataSource == null) {
                logProgress(result, "No data source was provided, I need a location for the imported data", true);
                haltProcessing = true;
            } else {
                logProgress(result, "Using data source " + dataSource);
            }
        }

        if(!haltProcessing) {
            try {
                logProgress(result, "Using database server at " + dataSource.getConnection().getMetaData().getURL());
            } catch (SQLException exception) {
                logProgress(result, "Could not connect to the database server!", true);
            }
        }

        // loop through our CSV files
        if(!haltProcessing) {

            Collection<File> files = FileUtils.listFiles(importFilePath.toFile(),
                    new SuffixFileFilter(".csv", IOCase.INSENSITIVE), null);

            if(files != null) {

                for (File fileThis : files) {
                    boolean successful = importFile(fileThis, result);
                    if(!successful) {
                        logProgress(result, "The file \"" + fileThis.getAbsolutePath() + "\" was " +
                                " not processed successfully.", true);
                    }
                }
            }
        }


        // we completed successfully
        if(!haltProcessing) {

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            logProgress(result,"Successfully processed CSV file import");
        }

        result.setPaginatedContentIndicator(new PaginationIndicator(
                transaction.getRequest().getPaging().getStart(),
                transaction.getRequest().getPaging().getCount(), true));

        return result;
    }

    private boolean testFileReadable(File file) {
        return testFileReadable(file, null);
    }

    private boolean importFile(File file, ProcessContentResult result) {

        boolean successful = true;

        result.getAuditEntries().add(makeEntry("Importing data from file \"" + file.getAbsolutePath() + "\"..."));

        if(!testFileReadable(file, result)) {
            return false;
        }

        String fileName = file.getName();
        String schemaName = null;
        String tableName = null;

        String[] chunks = fileName.split(".");
        if(chunks.length != 3) {
            result.getAuditEntries().add(makeEntry("Could not parse out the file name \"" + fileName + "\" into " +
                    "schema and database name"));
            return false;

        }

        schemaName = chunks[0];
        tableName = chunks[1];
        result.getAuditEntries().add(makeEntry("Importing the data from \"" + fileName + "\" into the schema " +
                "\"" + schemaName + "\" and the table \"" + tableName + "\"..."));

        // get a reader on the file
        ICsvListReader listReader = null;
        try {
            listReader = new CsvListReader(new FileReader(file), CsvPreference.STANDARD_PREFERENCE);
        } catch (FileNotFoundException exception) {
            logProgress(result, "The file \"" + file.getAbsolutePath() + "\" should have been readable but " +
                    "I could not read from the file!", true);
            return false;
        }

        // parse out the headers
        String[] headers = null;
        try {
            headers = listReader.getHeader(true);
            boolean firstHeader = true;
            StringBuilder builder = new StringBuilder("Inserting into the following columns: ");
            for(String header : headers) {
                if(!firstHeader) {
                    builder.append(", ");
                }
                builder.append("\"" + header + "\"");
                firstHeader = false;
            }
        } catch (IOException exception) {
            logProgress(result, "Could not read the headers from the file!", true);
            return false;
        }

        return successful;
    }

    private boolean testFileReadable(File file, ProcessContentResult result) {

        boolean valid = true;

        if(valid && !file.exists()) {
            valid = false;
            if(result != null) {
                result.getAuditEntries().add(makeEntry("The file \"" + file.getAbsolutePath() + "\" should be " +
                        "imported but does not exist"));
            }
        }

        if(valid && !file.canRead()) {
            valid = false;
            if(result != null) {
                result.getAuditEntries().add(makeEntry("The file \"" + file.getAbsolutePath() + "\" should be " +
                        "imported but is not readable"));
            }
        }

        return valid;
    }

    private void logProgress(ProcessContentResult result, String message) {
        logProgress(result, message, false);
    }

    private void logProgress(ProcessContentResult result, String message, boolean error) {
        result.getAuditEntries().add(makeEntry(message));

        if(error) {
            error(message);
        } else {
            info(message);
        }
    }
}

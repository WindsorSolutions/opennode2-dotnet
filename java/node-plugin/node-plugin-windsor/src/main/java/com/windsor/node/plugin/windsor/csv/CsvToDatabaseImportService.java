package com.windsor.node.plugin.windsor.csv;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.BaseJdbcDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.IOCase;
import org.apache.commons.io.filefilter.SuffixFileFilter;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
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
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
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
            }
        }

        if(!haltProcessing) {
            try {
                Connection connection = dataSource.getConnection();
                connection.close();
                logProgress(result, "Verified that I can connect to the database");
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
                    boolean successful = importFile(fileThis, result, truncateTargetTable);
                    if(!successful) {
                        logProgress(result, "The file \"" + fileThis.getAbsolutePath() + "\" was " +
                                " not processed successfully.", true);
                        haltProcessing = true;
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

    private boolean importFile(File file, ProcessContentResult result, Boolean truncateTargetTable) {

        boolean successful = true;

        result.getAuditEntries().add(makeEntry("Importing data from file \"" + file.getAbsolutePath() + "\"..."));

        if(!testFileReadable(file, result)) {
            return false;
        }

        String fileName = file.getName();
        String schemaName = null;
        String tableName = null;

        String[] chunks = fileName.split("\\.");
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

            if(headers == null || headers.length < 1) {
                logProgress(result, "There were no headers in the file \"" + file.getAbsolutePath() + "\"!");
                return false;
            }

            boolean firstHeader = true;
            StringBuilder builder = new StringBuilder("Inserting into the following columns: ");
            for(String header : headers) {
                if(!firstHeader) {
                    builder.append(", ");
                }
                builder.append("\"" + header + "\"");
                firstHeader = false;
            }
            logProgress(result, builder.toString());
        } catch (IOException exception) {
            logProgress(result, "Could not read the headers from the file!", true);
            return false;
        }

        // get a database connection
        Connection connection = null;
        try {
            connection = dataSource.getConnection();
        } catch (SQLException exception) {
            logProgress(result, "Couldn't get a connection from the database: " + exception.getMessage(), true);
            return false;
        }

        // truncate the target table
        if(truncateTargetTable) {
            try {
                String query = "truncate table " + schemaName + "." + tableName;
                executeQuery(connection, query);
                logProgress(result, "Truncated " + schemaName + "." + tableName + " successfully");
            } catch (SQLException exception) {
                logProgress(result, "Couldn't truncate table " + schemaName + "." + tableName + ": "
                        + exception.getMessage(), true);
                successful = false;
            }
        }

        // insert rows into the table
        List<String> csvRow;
        try {

            while((csvRow = listReader.read()) != null && successful == true) {

                StringBuilder query = new StringBuilder("insert into " + schemaName + "." + tableName + " (");

                // columns
                boolean first = true;
                for(String column : headers) {
                    if(!first) {
                        query.append(", ");
                    }
                    query.append(column);
                    first = false;
                }
                query.append(") ");

                // values
                query.append("values (");
                first = true;
                for(String value : csvRow) {
                    if(!first) {
                        query.append(", ");
                    }
                    query.append("'" + value + "'");
                    first = false;
                }
                query.append(")");

                try {
                    executeQuery(connection, query.toString());
                } catch (SQLException exception) {
                    logProgress(result, "Couldn't execute insert \"" + query + "\": "
                            + exception.getMessage(), true);
                    successful = false;
                }
            }

            listReader.close();
        } catch (IOException exception) {
            logProgress(result, "Couldn't read the row of data from the file \"" + file.getAbsolutePath()
                    + "\": " + exception.getMessage(), true);
            successful = false;
        }

        closeConnection(connection);

        return successful;
    }

    private void closeConnection(Connection connection) {
        try {
            connection.close();
        } catch (SQLException exception) {
            error("Couldn't close the database connection");
        }
    }

    private ResultSet executeQuery(Connection connection, String query) throws SQLException {
        info("EXEC QUERY: " + query);
        Statement statement = connection.createStatement();
        return statement.executeQuery(query);
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

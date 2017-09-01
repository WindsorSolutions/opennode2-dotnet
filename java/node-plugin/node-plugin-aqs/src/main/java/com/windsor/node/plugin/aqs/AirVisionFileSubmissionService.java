package com.windsor.node.plugin.aqs;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.aqs.wsdl.AbstractAirVisionSubmissionService;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.IOCase;
import org.apache.commons.io.IOUtils;
import org.apache.commons.io.filefilter.SuffixFileFilter;
import org.apache.commons.io.filefilter.WildcardFileFilter;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.FileSystems;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

/**
 * Provides a plugin for retrieving an AirVision XML report file and submitting
 * that file to the network partner.
 */
public class AirVisionFileSubmissionService extends AbstractAirVisionSubmissionService {

    private AirVisionSubmissionHelper submissionHelper = new AirVisionSubmissionHelper();

    public static final PluginServiceParameterDescriptor EXPORT_FILE_PATH =
            new PluginServiceParameterDescriptor("AirVision exported file location",
                    "java.lang.String", Boolean.TRUE,
                    "The path to a directory on the filesystem where the AirVision AQS export file will be " +
                            "located. This plugin will be looking for a file with an extension of \".xml\", if there " +
                            "is more than one file in the provided directory, the most recent file will be used.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("AirVisionFileSubmissionService");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR
                .setDescription("Submits AirVision AQS files (read from the filesystem) to CDX");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(AirVisionProxyService.class.getCanonicalName());
    }

    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public AirVisionFileSubmissionService() {

        getSupportedPluginTypes().add(ServiceType.TASK);
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {

        List<PluginServiceParameterDescriptor> params = new ArrayList();
        params.add(EXPORT_FILE_PATH);
        return params;
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

        // accumulate a list of documents
        List<Document> documents = new ArrayList<>();
        result.setDocuments(documents);

        // setup a temporary output directory for our results
        File tempOutput = new File(System.getProperty("java.io.tmpdir"));

        // get a handle on the export path
        String exportFilePathName = null;
        Path exportFilePath = null;

        if(!haltProcessing) {
            if (namedParams.get(EXPORT_FILE_PATH.getName()) != null) {

                exportFilePathName = namedParams.get(EXPORT_FILE_PATH.getName()).toString();
            } else {

                error("No export file path was provided");
                result.getAuditEntries().add(makeEntry("No export file path was provided, exiting."));
                haltProcessing = true;
            }
        }

        // ensure the export path is readable
        if(!haltProcessing) {

            exportFilePath = FileSystems.getDefault().getPath(exportFilePathName);

            if(!Files.exists(exportFilePath)) {

                error("The export file path \"" + exportFilePathName + "\" does not exit, exiting.");
                result.getAuditEntries().add(makeEntry("The export file path \"" + exportFilePathName + "\" does not " +
                        "exist, exiting."));
                haltProcessing = true;
            }

            if(!Files.isDirectory(exportFilePath)) {

                error("The export file path \"" + exportFilePathName + "\" does not point to a directory, exiting.");
                result.getAuditEntries().add(makeEntry("The export file path \"" + exportFilePathName + "\" does not " +
                        "point to a directory, exiting."));
                haltProcessing = true;
            }

            if(!Files.isReadable(exportFilePath)) {

                error("The export file path \"" + exportFilePathName + "\" does is not readable, exiting.");
                result.getAuditEntries().add(makeEntry("The export file path \"" + exportFilePathName + "\" is not " +
                        "readable, exiting."));
                haltProcessing = true;
            }
        }

        // get the newest file in the directory
        File exportFile = null;
        if(!haltProcessing) {

            Collection<File> files = FileUtils.listFiles(exportFilePath.toFile(),
                    new SuffixFileFilter(".xml", IOCase.INSENSITIVE), null);

            if(files != null) {

                for(File fileThis : files) {

                    if(exportFile == null) {
                        exportFile = fileThis;
                    } else if(fileThis.lastModified() > exportFile.lastModified()) {
                        exportFile = fileThis;
                    }
                }
            }

            if(exportFile == null) {

                error("The export file path \"" + exportFilePathName + "\" does not contain any XML files, exiting.");
                result.getAuditEntries().add(makeEntry("The export file path \"" + exportFilePathName + "\" does not " +
                        "contain any XML files, exiting."));
                haltProcessing = true;
            }
        }

        // wrap the file for sending to the network partner
        List<String> lines = null;
        String docId = getIdGenerator().createId();
        if(!haltProcessing) {

            result.getAuditEntries().add(makeEntry("Found file to submit with name \"" + exportFile.getName() + "\" at " +
                    "path \"" + exportFile.getAbsolutePath() + "\" of size " + exportFile.length() + " (in bytes)"));

            try {
                // strip off the XML header
                lines = AirVisionSubmissionHelper.removeXmlHeader(exportFile);

                // add the header
                addHeader(lines, docId, transaction);
                result.getAuditEntries().add(makeEntry("Added exchange network header"));
            } catch(IOException exception) {
                error("Could not read the export file and remove the XML header ", exception);
                result.getAuditEntries().add(makeEntry("Could not read the export file and remove the XML header: " +
                        exception.getMessage()));
                haltProcessing = true;
            }
        }

        // add document to transaction
        if(!haltProcessing) {

            try {

                // write our lines data to a temp file
                String tempFilePath = AirVisionSubmissionHelper.makeTemporaryFilename(getSettingService(), docId);
                OutputStream output = new FileOutputStream(tempFilePath);
                IOUtils.writeLines(lines, null, output, "UTF-8");

                // zip the temp file and create a new document
                Document doc = AirVisionSubmissionHelper.makeDocument(getZipService(),
                        transaction.getRequest().getType(), docId, tempFilePath);
                result.setPaginatedContentIndicator(
                        new PaginationIndicator(transaction.getRequest().getPaging().getStart(),
                                transaction.getRequest().getPaging().getCount(), true));
                documents.add(doc);
            } catch(IOException exception) {
                error("Could not add the export document to the transaction ", exception);
                result.getAuditEntries().add(makeEntry("Could not add the export document to the transaction: " +
                        exception.getMessage()));
                haltProcessing = true;
            }
        }

        // we completed successfully
        if(!haltProcessing) {

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Successfully processed AirVision export file"));
        }

        return result;
    }
}

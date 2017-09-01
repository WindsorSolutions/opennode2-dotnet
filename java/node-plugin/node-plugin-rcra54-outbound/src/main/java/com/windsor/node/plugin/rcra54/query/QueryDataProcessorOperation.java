package com.windsor.node.plugin.rcra54.query;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.rcra54.domain.generated.SolicitHistory;
import com.windsor.node.plugin.rcra54.download.DownloadRequest;
import com.windsor.node.plugin.rcra54.outbound.BaseRcra54Plugin;
import com.windsor.node.plugin.rcra54.solicit.StoredProcedureException;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequestType;
import com.windsor.node.plugin.rcra54.status.GetStatusRequest;
import com.windsor.node.service.helper.client.NodeClientFactory;
import net.exchangenetwork.schema.node._2.DownloadResponse;
import net.exchangenetwork.schema.node._2.NodeDocumentType;
import net.exchangenetwork.schema.node._2.StatusResponseType;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;

import javax.persistence.Query;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.bind.ValidationEvent;
import javax.xml.bind.ValidationEventHandler;
import javax.xml.bind.ValidationException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import static java.lang.String.*;

public class QueryDataProcessorOperation extends BaseRcra54Plugin {

    private static final List<String> NODE_TABLE_NAMES = Arrays.asList(
            "RCRA_ABSFEATUREPROPTYPE", "RCRA_AREAACREAGE", "RCRA_CERT", "RCRA_CITN", "RCRA_CMEFACSUB", "RCRA_CONTACT",
            "RCRA_CONTACTADDRESS", "RCRA_CORRACTAREA", "RCRA_CORRACTAUTH", "RCRA_CORRACTEVENT", "RCRA_CORRACTFACSUB",
            "RCRA_CORRACTRELEVENT", "RCRA_CORRACTRELPERMITUNIT", "RCRA_CORRACTSTATCITN", "RCRA_COSTEST",
            "RCRA_COSTESTRELMECH", "RCRA_CSNYDATE", "RCRA_ENFRCACT", "RCRA_ENVPERMIT", "RCRA_EVAL", "RCRA_EVALCOMMIT",
            "RCRA_EVALVIO", "RCRA_EVENTCOMMIT", "RCRA_FACOWNROPER", "RCRA_FACSUB", "RCRA_FINASSURFACSUB",
            "RCRA_FINASSURSUB", "RCRA_GEOGINF", "RCRA_GEOGINFSUB", "RCRA_GEOGMETA", "RCRA_GISFACSUB", "RCRA_HANDLER",
            "RCRA_HANDLERWASTECODE", "RCRA_HZRDSECONDARYMTRL", "RCRA_HZRDSECONDARYMTRLACT", "RCRA_HZRDWASTECMESUB",
            "RCRA_HZRDWASTECORRACT", "RCRA_HZRDWASTEHANDLERSUB", "RCRA_HZRDWASTEPERMIT", "RCRA_LABHZRDWASTE",
            "RCRA_LOCADDRESS", "RCRA_MAILINGADDRESS", "RCRA_MECH", "RCRA_MECHDETAIL", "RCRA_MEDIA", "RCRA_MLSTN",
            "RCRA_NAICS", "RCRA_OTHERID", "RCRA_PAYMNT", "RCRA_PENALTY", "RCRA_PERMITEVENT", "RCRA_PERMITFACSUB",
            "RCRA_PERMITRELEVENT", "RCRA_PERMITSERIES", "RCRA_PERMITUNIT", "RCRA_PERMITUNITDETAIL", "RCRA_REQUEST",
            "RCRA_SITEWASTEACT", "RCRA_STATEACT", "RCRA_SUPPENVPROJ", "RCRA_UNVWASTEACT", "RCRA_USEDOIL", "RCRA_VIO",
            "RCRA_VIOENFRC", "RCRA_WASTEGENRTR", "RCRA_WHERETYPE"
    );
    public static final String SERVICE_NAME = "RCRAProcessOperation";
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(SERVICE_NAME);
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Query and process the RCRAInfo service for previously solicited info.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(QueryDataProcessorOperation.class.getCanonicalName());
    }

    public QueryDataProcessorOperation() {
        super();
        getConfigurationArguments().put(ARG_STORED_PROCEDURE, "");
        getSupportedPluginTypes().add(ServiceType.TASK);
    }

    public List<SolicitHistory> getPendingSolicits() {
        return getTargetEntityManager().createQuery("SELECT sh FROM SolicitHistory sh WHERE sh.status = :status ORDER BY sh.id")
                .setParameter("status", SolicitHistory.Status.PENDING.getName())
                .getResultList();
    }

    private void recordActivity(ProcessContentResult result, String msgFormat, Object... args) {
        result.getAuditEntries().add(makeEntry(String.format(msgFormat, args)));
    }

    private NodeClientService getNodeClientService(NodeTransaction transaction) {
        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);
        PartnerIdentity partner = new PartnerIdentity();
        partner.setUrl(transaction.getNetworkEndpointUrl());
        partner.setVersion(transaction.getNetworkEndpointVersion());
        return clientFactory.makeAndConfigure(partner);
    }

    private StatusResponseType getTransactionStatus(PartnerIdentity partner,
                                                    NodeClientService clientService,
                                                    String transactionId)
            throws NodeFaultMessage {
        String token = clientService.authenticate();
        logger.info("Received new authentication token: " + token);
        GetStatusRequest getStatusRequest = new GetStatusRequest(partner.getUrl().toString(), token,
                transactionId);
        StatusResponseType responseType = getStatusRequest.execute();
        info(transactionId + " Response: " + responseType.getStatus());
        info(transactionId + " Response: " + responseType.getStatusDetail());

        return responseType;
    }

    /**
     * Handles the processing of the completed transaction. That is, this method
     * downloads the ZIP 6-archive of XML data from the partner endpoint and
     * processes the XML documents therein.
     *
     * @param result        The processing result
     * @param partner       The partner endpoint
     * @param clientService The node client service to use
     * @param transaction   The solicit transaction
     * @throws SQLException        On any issue calling the stored procedure after processing
     * @throws ValidationException On any issue reading the XML data from the partner
     * @throws NodeFaultMessage    On any exception thrown by the partner
     * @throws IOException         On any issue writing to local disk
     */
    private void handleCompletedTransaction(ProcessContentResult result,
                                            PartnerIdentity partner,
                                            NodeClientService clientService,
                                            NodeTransaction transaction,
                                            SolicitRequestType type)
            throws StoredProcedureException, SQLException, ValidationException, NodeFaultMessage, IOException {

        info("The solicit request has completed");

        // setup our temp directory
        Path tempDir = Files.createTempDirectory("rcra");
        info("Will write data to " + tempDir.toAbsolutePath());

        // download the data
        info("Downloading the solicit response from the endpoint...");
        result.getAuditEntries().add(new ActivityEntry("Downloading the solicit response from the "
                + partner.getName() + "..."));
        DownloadRequest downloadRequest = new DownloadRequest(partner.getUrl().toString(),
                clientService.authenticate(), transaction.getNetworkId());
        info("Created new download request");
        info("Executing download request...");
        DownloadResponse downloadResponse = downloadRequest.execute();
        info("Response: Returned " + downloadResponse.getDocuments().size() + " documents");

        // accumulate a list of documents
        List<Document> documents = new ArrayList<>();

        for (NodeDocumentType documentType : downloadResponse.getDocuments()) {
            info("Processing document: " + documentType.getDocumentName() + ", " + documentType.getDocumentFormat());
            result.getAuditEntries().add(new ActivityEntry("  Processing downloaded document: "
                    + documentType.getDocumentName()));

            // write out the document
            Path outPath = Files.createTempFile(tempDir, documentType.getDocumentName(),
                    documentType.getDocumentFormat().toString());
            info("Writing document to " + outPath.toAbsolutePath());
            FileOutputStream outputStream = new FileOutputStream(outPath.toFile());
            IOUtils.copy(documentType.getDocumentContent().getValue().getInputStream(), outputStream);
            outputStream.close();

            // process the document
            File file = outPath.toFile();
            try (ZipFile zipFile = new ZipFile(file);) {
                Enumeration<? extends ZipEntry> zipEntries = zipFile.entries();
                while (zipEntries.hasMoreElements()) {
                    ZipEntry zipEntry = zipEntries.nextElement();

                    if (zipEntry != null) {
                        try (InputStream inputStream = zipFile.getInputStream(zipEntry);) {
                            processData(result, inputStream, type);
                        } catch (Exception exception) {
                            logger.warn(partner.getName() + " sent us unreadable data, we could not parse XML and insert data: " + exception.getMessage(), exception);
                            throw new ValidationException(exception.getMessage(), exception);
                        }
                    }
                }
            }

            // link our document to our result
            try (FileInputStream docInputStream = new FileInputStream(file);) {
                byte[] content = IOUtils.toByteArray(docInputStream);
                String docName = documentType.getDocumentName();
                if (content.length > 0) {
                    Document document = new Document();
                    document.setDocumentName(docName);
                    document.setType(CommonContentType.ZIP);
                    document.setContent(content);
                    info("Document size: " + document.getContent().length);
                    documents.add(document);
                } else {
                    info("Document " + docName + " was of size 0 -- skipping");
                    result.getAuditEntries().add(new ActivityEntry("Document "
                            + documentType.getDocumentName() + " was of size 0 so it was not attached."));
                }
            }
            // cleanup the temp file
            Files.deleteIfExists(outPath);
        }

        result.setDocuments(documents);
        info("Added " + documents.size() + " documents to this result");
        result.setSuccess(true);
        result.setStatus(CommonTransactionStatusCode.Completed);
        result.getAuditEntries().add(new ActivityEntry("Solicit and Download completed successfully!"));

        String storedProcedure = getConfigValueAsStringNoFail(ARG_STORED_PROCEDURE);
        if (StringUtils.isNotBlank(storedProcedure)) {
            result.getAuditEntries().add(new ActivityEntry("Calling stored procedure \""
                    + storedProcedure + "\" to process the data"));
            calledStoredProcedure(storedProcedure, type);
        }

        // cleanup the temp directory
        Files.deleteIfExists(tempDir);
    }

    /**
     * Calls a stored procedure to operate on the data in the staging tables
     * adter they have been loaded.
     *
     * @param storedProcedure The name of the stored procedure
     * @throws SQLException On any issue executing the stored procedure
     */
    public void calledStoredProcedure(String storedProcedure, SolicitRequestType type) throws StoredProcedureException {

        try {
            getTargetEntityManager().getTransaction().begin();
            Query query = getTargetEntityManager()
                    .createNativeQuery(format("call %s(?)", storedProcedure));
            logger.info("Calling stored procedure: " + query.toString());
            query.setParameter(1, type.getDbInfo().getType());
            query.executeUpdate();
            getTargetEntityManager().getTransaction().commit();
        } catch (Exception exception) {
            getTargetEntityManager().getTransaction().rollback();
            String rootCause = ExceptionUtils.getRootCauseMessage(exception);
            logger.info("Rolled back the transaction for the stored procedure", exception);
            throw new StoredProcedureException(rootCause, exception);
        }
    }

    /**
     * Processes the incoming input stream of XML data and loads it into the
     * staging tables. Immediately before loading the data, the staging tables
     * are purged.
     *
     * @param result      The result for holding activity events, etc.
     * @param inputStream The input stream with the XML data
     * @throws JAXBException On any issue reading the XML data
     */
    private void processData(final ProcessContentResult result, InputStream inputStream, SolicitRequestType type) throws JAXBException {

        // get a handle on an unmarshaller for our data type
        // FIXME: memory leak
        JAXBContext jaxbContext = JAXBContext.newInstance(
                "com.windsor.node.plugin.rcra54.domain.generated",
                getClassLoader());
        Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();

        // handle any validation events
        unmarshaller.setEventHandler(new ValidationEventHandler() {

            @Override
            public boolean handleEvent(ValidationEvent event) {

                StringBuilder builderError = new StringBuilder();
                builderError.append("Could not parse the received XML data!\n");
                builderError.append("  SEVERITY:  " + event.getSeverity() + "\n");
                builderError.append("  MESSAGE:  " + event.getMessage() + "\n");
                builderError.append("  LINKED EXCEPTION:  " +
                        event.getLinkedException() + "\n");
                builderError.append("  LOCATOR" + "\n");
                builderError.append("      LINE NUMBER:  " +
                        event.getLocator().getLineNumber() + "\n");
                builderError.append("      COLUMN NUMBER:  " +
                        event.getLocator().getColumnNumber() + "\n");
                builderError.append("      OFFSET:  " +
                        event.getLocator().getOffset() + "\n");
                builderError.append("      OBJECT:  " +
                        event.getLocator().getObject() + "\n");
                builderError.append("      NODE:  " +
                        event.getLocator().getNode() + "\n");
                builderError.append("      URL:  " +
                        event.getLocator().getURL());

                // log our validation event
                logger.info(builderError.toString());

//                result.getAuditEntries().add(
//                        new ActivityEntry(builderError.toString()));

                // ignore validation errors
                return true;
            }
        });

        // unmarshall the input stream
        @SuppressWarnings("rawtypes")
        JAXBElement submissionDataType = (JAXBElement) unmarshaller.unmarshal(inputStream);
        info("Received " + submissionDataType.getValue().getClass() + " from RCRA Info");

        // purge the appropriate staging tables
        cleanupData(type);

        // save our new data to the staging tables
        persistData(submissionDataType.getValue());
    }

    private void cleanupData(SolicitRequestType type) {
        getTargetEntityManager().getTransaction().begin();
        for (String tableName : NODE_TABLE_NAMES) {
            Query query = getTargetEntityManager().createNativeQuery(String.format("TRUNCATE TABLE %s", tableName));
            query.executeUpdate();
        }
        getTargetEntityManager().getTransaction().commit();
    }

    private void persistData(Object object) {
        boolean merge = false;
        if (object instanceof SolicitHistory) {
            SolicitHistory solicitHistory = (SolicitHistory) object;
            merge = solicitHistory.getId() != null;
        }
        getTargetEntityManager().getTransaction().begin();
        if (merge) {
            getTargetEntityManager().merge(object);
        } else {
            getTargetEntityManager().persist(object);
        }
        getTargetEntityManager().getTransaction().commit();
    }

    /**
     * Sets the provided transaction to "failed" and updates the solicit
     * history record, if present.
     *
     * @param result         The processing result that failed
     * @param transaction    The transaction that failed
     * @param solicitHistory The solicit history instance
     */
    private void setTransactionFailed(ProcessContentResult result,
                                      NodeTransaction transaction,
                                      SolicitHistory solicitHistory) {
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Failed));

        if (solicitHistory != null) {
            solicitHistory.setStatus(SolicitHistory.Status.FAILED);
        }
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
        final ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);
        recordActivity(result, "RCRA \"%s\" process starting.", QueryDataProcessorOperation.class.getSimpleName());
        SolicitHistory solicitHistory = null;
        PartnerIdentity partner = null;
        try {
            recordActivity(result, "Checking for \"Pending\" transactions");
            List<SolicitHistory> historyList = getPendingSolicits();
            if (historyList.isEmpty()) {
                recordActivity(result, "No \"Pending\" transactions found in RCRA submission history table.");
            } else {
                recordActivity(result, "Found %s outstanding submission(s).", historyList.size());
                for (SolicitHistory history : historyList) {
                    solicitHistory = history;
                    recordActivity(result, "Looking up local network exchange transaction \"%s\".", solicitHistory.getTransactionId());
                    NodeTransaction solicitTransaction = getTransactionDao().get(solicitHistory.getTransactionId(), Boolean.FALSE);
                    if (solicitTransaction != null && solicitTransaction.getNetworkEndpointUrl() != null) {
                        recordActivity(result, "Found local network exchange transaction.");
                        recordActivity(result, "Creating network exchange client to lookup remote transaction status.");
                        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                                .makeService(NodeClientFactory.class);
                        partner = new PartnerIdentity();
                        partner.setUrl(solicitTransaction.getNetworkEndpointUrl());
                        partner.setVersion(solicitTransaction.getNetworkEndpointVersion());
                        recordActivity(result, "Attempting to retrieve remote status of transaction.");
                        NodeClientService client = getNodeClientService(solicitTransaction);
                        CommonTransactionStatusCode remoteStatus = client.getStatus(solicitTransaction.getNetworkId()).getStatus();
                        recordActivity(result, "Found remote status of \"%s\".", remoteStatus.name());
                        recordActivity(result, "Updating RCRA submission history table with remote status.");
                        if (remoteStatus == CommonTransactionStatusCode.Completed) {
                            String solicitCode = solicitHistory.getSolicitType();
                            SolicitRequestType type = SolicitRequestType.getByCode(solicitCode);
                            //NodeClientService clientService = clientFactory.makeAndConfigure(partner);
                            handleCompletedTransaction(result, partner, client, solicitTransaction, type);
                            transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Completed));
                            solicitHistory.setStatus(SolicitHistory.Status.COMPLETE);
                            solicitTransaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Completed));
                            persistData(solicitHistory);
                        } else {
                            recordActivity(result, String.format("Transaction '%s' is not ready; remote status is '%s'.",
                                    solicitHistory.getTransactionId(), remoteStatus.name()));
                        }
                    } else {
                        recordActivity(result, String.format("No endpoint URL for transaction '%s'.",
                                solicitHistory.getTransactionId()));
                    }
                }
            }
            recordActivity(result, "%s completed successfully.", QueryDataProcessorOperation.class.getSimpleName());
            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
        } catch (IOException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "writing data to the local filesystem. This is usually a " +
                    "configuration issue with the server running your OpenNode 2 " +
                    "instance. The exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch (SQLException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "running the stored procedure and the transaction has been " +
                    "rolled back. This is a problem with the way " +
                    "the stored procedure handled the staged data. The execption was: "
                    + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch (ValidationException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry(partner.getName() +
                    " sent us unreadable data, we could not parse XML and insert " +
                    "data, If you were querying the EPA, " +
                    "please contact nodehelpdesk@epacdx.net for more detailed " +
                    "information. The validation exception was : " +
                    exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch (NodeFaultMessage exception) {
            error(exception.getFaultInfo().getDescription(), exception);
            result.getAuditEntries().add(new ActivityEntry(partner.getName() +
                    " had a problem preparing the data for us. If you were " +
                    "querying the EPA, please contact " +
                    "nodehelpdesk@epacdx.net for more detailed information. " +
                    "The " + partner.getName() + " Node Fault Response was: " +
                    exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch (StoredProcedureException exception) {
            error("Exception while executing the stored procedure: " + exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("The data from " + partner.getName() +
                    " was successfully downloaded and unpacked into the appropriate " +
                    "staging tables, but there was an error when the data in those " +
                    "staging tables was processed by the stored procedure. This " +
                    "is an issue that you should investigate with your Database " +
                    "administrator and the author of this stored procedure. The " +
                    "exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch (Exception exception) {
            error("Exception while communicating with " + partner.getName() + ": " + exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "communicating with " + partner.getName() + " , this could " +
                    "be due to a network issue or downtime at " + partner.getName() +
                    "If you were querying the EPA, please contact " +
                    "nodehelpdesk@epacdx.net for more detailed information. The " +
                    "exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        }
        return result;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> parameters = new ArrayList<>();
        return parameters;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }
}

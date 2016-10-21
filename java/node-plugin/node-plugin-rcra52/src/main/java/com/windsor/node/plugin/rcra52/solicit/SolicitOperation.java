package com.windsor.node.plugin.rcra52.solicit;

import static java.lang.String.format;

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

import javax.persistence.Query;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.bind.ValidationEvent;
import javax.xml.bind.ValidationEventHandler;
import javax.xml.bind.ValidationException;

import org.apache.commons.io.IOUtils;
import org.apache.commons.lang3.StringUtils;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.rcra52.BaseRcra52Plugin;
import com.windsor.node.plugin.rcra52.domain.generated.SolicitHistory;
import com.windsor.node.plugin.rcra52.download.DownloadRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestType;
import com.windsor.node.plugin.rcra52.status.GetStatusRequest;
import com.windsor.node.service.helper.client.NodeClientFactory;

import net.exchangenetwork.schema.node._2.DownloadResponse;
import net.exchangenetwork.schema.node._2.NodeDocumentType;
import net.exchangenetwork.schema.node._2.StatusResponseType;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;

/**
 * Provides the plugin operation for soliciting data from RCRAInfo.
 *
 * T is the type of submission returned by RCRA Info
 */
public abstract class SolicitOperation extends BaseRcra52Plugin {

    /**
     * Classloader instance that can return our RCRA XML beans.
     */
    private ClassLoader classLoader;

    /**
     * Flag indicating that we'll be using/recording the solicit history.
     */
    private Boolean useHistory;

    /**
     * The plugin service implementor description for this plugin.
     * @return Plugin service implementor description instance
     */
    @Override
    public abstract PluginServiceImplementorDescriptor getPluginServiceImplementorDescription();

    /**
     * Returns the solicit request type.
     * @return The solicit request type
     */
    public abstract SolicitRequestType getRequestType();

    /**
     * Handles the creation of the initial solicit request.
     * @param requestFactory Factory that can create request for any solicit type
     * @param namedParams Map of parameters for the schedule
     * @return A new SolicitRequest instance
     */
    public abstract SolicitRequest handleGetRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams);

    public SolicitRequest getRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams) {

        String useHistoryString = (String) namedParams.get(SolicitOperation.PARAM_USE_SOLICIT_HISTORY.getName().toString());

        if(useHistoryString != null && useHistoryString.trim() != null
                && useHistoryString.trim().toLowerCase().equals("true") ||
                useHistoryString.trim().toLowerCase().equals("yes") ||
                useHistoryString.trim().toLowerCase().equals("on")) {
            useHistory = true;
        }

        return handleGetRequest(requestFactory, namedParams);
    };

    /**
     * Returns true if the solicity history is in use.
     * @return Flag indiciating if solicity history is in use
     */
    public Boolean getUseHistory() {
        return useHistory;
    }

    /**
     * If the solicit history is in use, returns the last successful solicit
     * history record or null if there has not yet been a successful solicit.
     * @return Last successful solicit history record
     */
    public SolicitHistory getSolicitHistoryLast() {
        SolicitHistory solicitHistoryMostRecent = null;

        // query for the most recent successful solicit complete for this function type
        Query query = getTargetEntityManager().createQuery(
                "from SolicitHistory where solicitType = :solicitType and status = :status order by runDate desc");
        query.setParameter("solicitType", getRcraServiceName());
        query.setParameter("status", SolicitHistory.Status.COMPLETE.getName());
        List<SolicitHistory> results = query.getResultList();

        if(results != null && results.size() > 0) {
            solicitHistoryMostRecent = results.get(0);
        }

        return solicitHistoryMostRecent;
    }

    /**
     * Returns the RCRA service name for this plugin.
     * @return String with the RCRA service name
     */
    public String getRcraServiceName() {
        return getRequestType().toString();
    }

    /**
     * Creates a new solicit operation.
     */
    public SolicitOperation() {
        super();

        debug("Setting service types");
        getSupportedPluginTypes().add(ServiceType.TASK);
        debug(getRcraServiceName() + " instantiated");
    }

    /**
     * Returns the set of plugin service parameters for this plugin.
     * @return List of plugin service parameters
     */
    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> parameters = new ArrayList<>();
        parameters.addAll(Arrays.asList(ParameterSet.getByName(getRcraServiceName()).getParameterDescriptors()));
        return parameters;
    }

    /**
     * Returns a classloader that can load the RCRA XML bean objects.
     * @return Classloader that can load the RCRA XML bean objects
     */
    @Override
    public ClassLoader getClassLoader() {

        if(classLoader == null) {
            com.windsor.node.plugin.rcra52.domain.generated.ObjectFactory rcraObjectFactory =
                    new com.windsor.node.plugin.rcra52.domain.generated.ObjectFactory();
            classLoader = rcraObjectFactory.getClass().getClassLoader();
        }

        return classLoader;
    }

    /**
     * Returns a query that can be used to purge the staging tables before
     * importing new data.
     * @return Query for purging the stagint tables
     */
    public abstract Query getCleanupQuery();

    /**
     * Persist a data object to the database.
     * @param object
     */
    public void persistData(Object object) {

        getTargetEntityManager().getTransaction().begin();
        getTargetEntityManager().persist(object);
        getTargetEntityManager().getTransaction().commit();
    }

    /**
     * Performs data cleanup on the staging tables before loading new data.
     */
    public void cleanupData() {

        getTargetEntityManager().getTransaction().begin();
        List results = getCleanupQuery().getResultList();
        for(Object item : results) {
            getTargetEntityManager().remove(item);
        }
        getTargetEntityManager().getTransaction().commit();
    }

    /**
     * Calls a stored procedure to operate on the data in the staging tables
     * adter they have been loaded.
     *
     * @param storedProcedure The name of the stored procedure
     * @throws SQLException On any issue executing the stored procedure
     */
    public void calledStoredProcedure(String storedProcedure) throws StoredProcedureException {

        try {
            getTargetEntityManager().getTransaction().begin();
            Query query = getTargetEntityManager()
                    .createNativeQuery(format("call %s()", storedProcedure));
            logger.info("Calling stored procedure: " + query.toString());
            query.executeUpdate();
            getTargetEntityManager().getTransaction().commit();
        } catch(Exception exception) {
            getTargetEntityManager().getTransaction().rollback();
            logger.info("Rolled back the transaction for the stored procedure");
            throw new StoredProcedureException(exception.getMessage(), exception);
        }
    }

    /**
     * Returns the service request parameters specs for the plugin. This
     * implementation does not return any such parameters.
     * @param serviceName
     *            in case a singe plugin implementation class implements more
     *            than one service
     * @return Null, this plugin doesn't implement them
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }


    /**
     * Begins the solicit and download process.
     *
     * @param transaction
     *            typically created by the Node
     * @return ProcessContentResult instance with details of the transaction
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        // setup our result
        transaction.setOperation(getRcraServiceName());
        transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Pending));
        getTransactionDao().save(transaction);
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Pending);
        result.getAuditEntries().add(new ActivityEntry("RCRA Solicit and Download Operation process is starting..."));

        // setup our endpoint
        PartnerIdentity partner = getPartner();
        info("Endpoint: " + partner.getUrl());
        result.getAuditEntries().add(new ActivityEntry("Sending " + getRcraServiceName() + " solicit request to "
                + partner.getName() + " at " + partner.getUrl()));

        // schedule parameters
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        ParameterSet parameterSet = ParameterSet.getByName(getRcraServiceName());
        for(PluginServiceParameterDescriptor parameterDescriptor : parameterSet.getParameterDescriptors()) {
            info(parameterDescriptor.getName() + ": " + namedParams.get(parameterDescriptor.getName()));
        }

        // setup our node client
        NodeClientFactory clientFactory =
                (NodeClientFactory) getServiceFactory().makeService(NodeClientFactory.class);
        NodeClientService clientService = clientFactory.makeAndConfigure(partner);

        // setup our query request
        SolicitRequestFactory requestFactory = new SolicitRequestFactory(partner.getUrl().toString(),
                clientService.authenticate());
        SolicitRequest request = getRequest(requestFactory, namedParams);

        // Current solicit history record
        SolicitHistory solicitHistory = null;

        try {

            // execute our query request against our endpoint
            StatusResponseType queryResponseType = request.execute();
            info("Response: " + queryResponseType.getTransactionId());
            info("Response: " + queryResponseType.getStatus());
            info("Response: " + queryResponseType.getStatusDetail());
            result.getAuditEntries().add(
                    new ActivityEntry("Received response: " +
                            queryResponseType.getStatus() + " with detail \"" +
                            queryResponseType.getStatusDetail() + "\""));
            result.getAuditEntries().add(
                    new ActivityEntry("Solicit request transaction id: " +
                            queryResponseType.getTransactionId()));

            // save our pending transaction id
            transaction.setNetworkId(queryResponseType.getTransactionId());
            getTransactionDao().save(transaction);

            // execute a get status request for our solicit
            StatusResponseType solicitResponseType =
                    getTransactionStatus(partner, clientService, transaction.getNetworkId());
            result.getAuditEntries().add(
                    new ActivityEntry("Current status of solicit request: " +
                            solicitResponseType.getStatus() + " with detail \"" +
                            solicitResponseType.getStatusDetail() + "\""));

            // save our solicit history record
            if(useHistory != null && useHistory) {
                solicitHistory = new SolicitHistory(transaction.getNetworkId(), getRcraServiceName());
                persistData(solicitHistory);
                result.getAuditEntries().add(new ActivityEntry("Using submission history..."));
                if(getSolicitHistoryLast() != null) {
                    result.getAuditEntries().add(new ActivityEntry("Submission history change date: "
                            + getSolicitHistoryLast().getRunDateFormatted()));
                }
            } else {
                String changeDate = (String) namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName().toString());
                result.getAuditEntries().add(new ActivityEntry("Using change date: "
                        + changeDate));
            }

            // loop until our request completed or fails
            while(solicitResponseType.getStatus().toString() == null
                    || (!solicitResponseType.getStatus().toString().equals("COMPLETED")
                      && !solicitResponseType.getStatus().toString().equals("FAILED"))) {

                info("Sleeping for " + POLLING_INTERVAL + "ms...");
                Thread.sleep(POLLING_INTERVAL);

                // execute a get status request for our solicit
                solicitResponseType =
                        getTransactionStatus(partner, clientService, transaction.getNetworkId());
            }

            // log our final status
            info(transaction.getNetworkId() + " FINAL Response Status: " + solicitResponseType.getStatus());
            info(transaction.getNetworkId() + " FINAL Response Detail: " + solicitResponseType.getStatusDetail());

            if(solicitResponseType.getStatus().toString() == "COMPLETED") {

                handleCompletedTransaction(result, partner, clientService, transaction);

                transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Completed));

                if (useHistory != null && useHistory) {
                    solicitHistory.setStatus(SolicitHistory.Status.COMPLETE);
                }

            } else {

                // no exceptions, but a failure from the partner endpoint
                result.setSuccess(false);
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.getAuditEntries().add(new ActivityEntry(partner.getName() + " reports that " +
                        "this transaction has failed. If you were querying the EPA, please contact nodehelpdesk@epacdx.net " +
                        "for more detailed information. The detail from " + partner.getName() + " was: " +
                        solicitResponseType.getStatusDetail()));
                transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Failed));

                if(useHistory != null && useHistory) {
                    solicitHistory.setStatus(SolicitHistory.Status.FAILED);
                }
            }
        } catch(IOException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "writing data to the local filesystem. This is usually a " +
                    "configuration issue with the server running your OpenNode 2 " +
                    "instance. The exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch(SQLException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "running the stored procedure and the transaction has been " +
                    "rolled back. This is a problem with the way " +
                    "the stored procedure handled the staged data. The execption was: "
                    + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch(ValidationException exception) {
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry(partner.getName() +
                    " sent us unreadable data, we could not parse XML and insert " +
                    "data, If you were querying the EPA, " +
                    "please contact nodehelpdesk@epacdx.net for more detailed " +
                    "information. The validation exception was : " +
                    exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch(NodeFaultMessage exception) {
            error(exception.getFaultInfo().getDescription(), exception);
            result.getAuditEntries().add(new ActivityEntry(partner.getName() +
                    " had a problem preparing the data for us. If you were " +
                    "querying the EPA, please contact " +
                    "nodehelpdesk@epacdx.net for more detailed information. " +
                    "The " + partner.getName() + " Node Fault Response was: " +
                    exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch(StoredProcedureException exception) {
            error("Exception while executing the stored procedure: " + exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("The data from " + partner.getName() +
                    " was successfully downloaded and unpacked into the appropriate " +
                    "staging tables, but there was an error when the data in those " +
                    "staging tables was processed by the stored procedure. This " +
                    "is an issue that you should investigate with your Database " +
                    "administrator and the author of this stored procedure. The " +
                    "exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        } catch(Exception exception) {
            error("Exception while communicating with " + partner.getName() + ": " + exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "communicating with " + partner.getName() + " , this could " +
                    "be due to a network issue or downtime at " + partner.getName() +
                    "If you were querying the EPA, please contact " +
                    "nodehelpdesk@epacdx.net for more detailed information. The " +
                    "exception was: " + exception.getMessage()));
            setTransactionFailed(result, transaction, solicitHistory);
        }

        // save our transaction
        getTransactionDao().save(transaction);

        // update our solicit history
        if(useHistory != null && useHistory) {
            persistData(solicitHistory);
            //cleanupSolicitHistory();
        }

        result.getAuditEntries().add(new ActivityEntry("RCRA Solicit and Download Operation process complete."));
        return result;
    }

    /**
     * Performs a "status" request to the partnet against the provided
     * transaction identifier and returns the response from that endpoint.
     *
     * @param partner The partner endpoint
     * @param clientService Node client service instance to use
     * @param transactionId The transaction id whose status will be checked
     * @return The status of the transaction
     * @throws NodeFaultMessage On any exception from the partner endpoint
     */
    private StatusResponseType getTransactionStatus(PartnerIdentity partner,
                                      NodeClientService clientService,
                                      String transactionId)
            throws NodeFaultMessage {

        GetStatusRequest getStatusRequest = new GetStatusRequest(partner.getUrl().toString(), clientService.authenticate(),
                transactionId);
        StatusResponseType responseType = getStatusRequest.execute();
        info(transactionId + " Response: " + responseType.getStatus());
        info(transactionId + " Response: " + responseType.getStatusDetail());

        return responseType;
    }

    /**
     * Sets the provided transaction to "failed" and updates the solicit
     * history record, if present.
     *
     * @param result The processing result that failed
     * @param transaction The transaction that failed
     * @param solicitHistory The solicity history instance
     */
    private void setTransactionFailed(ProcessContentResult result,
                                      NodeTransaction transaction,
                                      SolicitHistory solicitHistory) {
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Failed));

        if(useHistory != null && useHistory) {
            solicitHistory.setStatus(SolicitHistory.Status.FAILED);
        }
    }

    /**
     * Handles the processing of the completed transaction. That is, this method
     * downloads the ZIP 6-archive of XML data from the partner endpoint and
     * processes the XML documents therein.
     *
     * @param result The processing result
     * @param partner The partner endpoint
     * @param clientService The node client service to use
     * @param transaction The solicit transaction
     * @throws SQLException On any issue calling the stored procedure after processing
     * @throws ValidationException On any issue reading the XML data from the partner
     * @throws NodeFaultMessage On any exception thrown by the partner
     * @throws IOException On any issue writing to local disk
     */
    private void handleCompletedTransaction(ProcessContentResult result,
                                            PartnerIdentity partner,
                                            NodeClientService clientService,
                                            NodeTransaction transaction)
            throws StoredProcedureException, SQLException, ValidationException, NodeFaultMessage, IOException {

        info("The solicit request has completed");

        // setup our temp directory
        Path tempDir = Files.createTempDirectory(getRcraServiceName());
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

        for(NodeDocumentType documentType : downloadResponse.getDocuments()) {
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
            ZipFile zipFile = new ZipFile(outPath.toFile());
            Enumeration<? extends ZipEntry> zipEntries = zipFile.entries();
            while(zipEntries.hasMoreElements()) {
                ZipEntry zipEntry = zipEntries.nextElement();

                if(zipEntry != null) {
                    InputStream inputStream = zipFile.getInputStream(zipEntry);
                    try {
                        processData(result, inputStream);
                        documentType.getDocumentContent().getValue().getInputStream();
                    } catch(Exception exception) {
                        logger.warn(partner.getName() + " sent us unreadable data, we could not parse XML and insert data: " + exception.getMessage(), exception);
                        throw new ValidationException(exception.getMessage(), exception);
                    }
                    inputStream.close();
                }
            }
            zipFile.close();

            // link our document to our result
            Document document = new Document();
            document.setDocumentName(documentType.getDocumentName());
            document.setType(CommonContentType.ZIP);
            document.setContent(IOUtils.toByteArray(documentType.getDocumentContent().getValue().getInputStream()));
            info("Document size: " + document.getContent().length);
            documents.add(document);

            // cleanup the temp file
            Files.deleteIfExists(outPath);
        }

        result.setDocuments(documents);
        info("Added " + documents.size() + " documents to this result");
        result.setSuccess(true);
        result.setStatus(CommonTransactionStatusCode.Completed);
        result.getAuditEntries().add(new ActivityEntry("Solicit and Download completed successfully!"));

        String storedProcedure = getConfigValueAsStringNoFail(ARG_STORED_PROCEDURE);
        if(StringUtils.isNotBlank(storedProcedure)) {
            result.getAuditEntries().add(new ActivityEntry("Calling stored procedure \""
                    + storedProcedure + "\" to process the data"));
            calledStoredProcedure(storedProcedure);
        }

        // cleanup the temp directory
        Files.deleteIfExists(tempDir);
    }

    /**
     * Processes the incoming input stream of XML data and loads it into the
     * staging tables. Immediately before loading the data, the staging tables
     * are purged.
     *
     * @param result The result for holding activity events, etc.
     * @param inputStream The input stream with the XML data
     * @throws JAXBException On any issue reading the XML data
     */
    private void processData(final ProcessContentResult result, InputStream inputStream) throws JAXBException {

        // get a handle on an unmarshaller for our data type
        com.windsor.node.plugin.rcra52.domain.generated.ObjectFactory rcraObjectFactory =
                new com.windsor.node.plugin.rcra52.domain.generated.ObjectFactory();
        JAXBContext jaxbContext = JAXBContext.newInstance(
                "com.windsor.node.plugin.rcra52.domain.generated",
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
                        event.getLinkedException()  + "\n");
                builderError.append("  LOCATOR"  + "\n");
                builderError.append("      LINE NUMBER:  " +
                        event.getLocator().getLineNumber()  + "\n");
                builderError.append("      COLUMN NUMBER:  " +
                        event.getLocator().getColumnNumber()  + "\n");
                builderError.append("      OFFSET:  " +
                        event.getLocator().getOffset()  + "\n");
                builderError.append("      OBJECT:  " +
                        event.getLocator().getObject()  + "\n");
                builderError.append("      NODE:  " +
                        event.getLocator().getNode()  + "\n");
                builderError.append("      URL:  " +
                        event.getLocator().getURL());

                // log our validation event
                logger.info(builderError.toString());

                result.getAuditEntries().add(
                        new ActivityEntry(builderError.toString()));

                // bail out of processing
                return false;
            }
        });

        // unmarshall the input stream
        JAXBElement submissionDataType = (JAXBElement) unmarshaller.unmarshal(inputStream);
        info("Received " + submissionDataType.getValue().getClass() + " from RCRA Info");

        // purge the appropriate staging tables
        cleanupData();

        // save our new data to the staging tables
        persistData(submissionDataType.getValue());
    }

    /**
     * Purges all but the most recent, successfully completed solicit history
     * record.
     */
    private void cleanupSolicitHistory() {

        SolicitHistory solicitHistoryMostRecent = getSolicitHistoryLast();

        // query for all solicit history entries for this function type
        Query query = getTargetEntityManager().createQuery(
                "from SolicitHistory where solicitType = :solicitType");
        query.setParameter("solicitType", getRcraServiceName());
        List<SolicitHistory> results = query.getResultList();

        // save most recent successful completion, delete the rest
        getTargetEntityManager().getTransaction().begin();
        for(SolicitHistory solicitHistoryThis : results) {
            if(solicitHistoryMostRecent == null ||
                    !solicitHistoryThis.getId().equals(solicitHistoryMostRecent.getId())) {
                getTargetEntityManager().remove(solicitHistoryThis);
            }
        }

        getTargetEntityManager().getTransaction().commit();
    }
}

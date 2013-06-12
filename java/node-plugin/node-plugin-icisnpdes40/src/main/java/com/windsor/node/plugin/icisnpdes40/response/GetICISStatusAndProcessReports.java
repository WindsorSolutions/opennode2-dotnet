package com.windsor.node.plugin.icisnpdes40.response;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import javax.xml.bind.JAXBException;

import org.apache.commons.lang3.StringUtils;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes40.dao.IcisEntityManagerFactory;
import com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao;
import com.windsor.node.plugin.icisnpdes40.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.dao.jdbc.JdbcIcisStatusAndProcessingDao;
import com.windsor.node.plugin.icisnpdes40.dao.jdbc.JdbcIcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionResultList;
import com.windsor.node.plugin.icisnpdes40.results.xml.IcisProcessingResultsXmlParser;
import com.windsor.node.plugin.icisnpdes40.results.xml.ResultsParser;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class GetICISStatusAndProcessReports extends BaseWnosJaxbPlugin
{
    /**
     * Notification Email Addresses: A semicolon-deliminated list of email
     * addresses. Each address will be added to the XML header submission,
     * instructing CDX to send email notifications when submissions are received
     * by CDX and when processing finished (either completed or failed).
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS = new PluginServiceParameterDescriptor(
                    "Notification Email Addresses", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE);

    public static final PluginServiceParameterDescriptor SERVICE_PARAM_POST_PROCESSING_PROC_NAME = new PluginServiceParameterDescriptor(
                    "Post Processing Procedure Name", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE);

    /**
     * Submission Partner Name: The name of the Network Partner configured in OpenNode2 for the CDX endpoint that the
     * submission data will be sent to. If no partner is set, the XML file created by the plugin will not be submitted.
     * This is useful for manual auditing purposes.
     */
    public static final PluginServiceParameterDescriptor SERVICE_PARAM_SUBMISSION_PARTNER_NAME = new PluginServiceParameterDescriptor(
                    "Submission Partner Name", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE);

    private IcisStatusAndProcessingDao icisStatusAndProcessingDao;
    private IcisWorkflowDao icisWorkflowDao;
    private TransactionDao transactionDao;
    private PartnerDao partnerDao;
    private ResultsParser resultsParser;
    private SettingServiceProvider settingService;
    private EntityManagerFactory emf;

    public GetICISStatusAndProcessReports() {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getSupportedPluginTypes().add(ServiceType.TASK);
        getDataSources().put(ARG_DS_SOURCE, null);

        getConfigurationArguments().put(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), "");//A semicolon delimited list of email addresses used by OpenNode2 to send PDF processing reports downloaded from CDX for completed submissions. PDFs are not distributed in the event of failed processing.
        getConfigurationArguments().put(SERVICE_PARAM_POST_PROCESSING_PROC_NAME.getName(), "");//The name of the stored procedure that copies accepted transactions from Staging-Local to Staging-ICIS. If not set, the procedure is not called. Agencies that do not utilize the plugin’s automated change detection process should not configure the procedure name.
        getConfigurationArguments().put(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), "");//Yes, The name of the Network Partner configured in OpenNode2 for the CDX endpoint that the submission data will be sent to.
    }

    @Override
    public void afterPropertiesSet() {
        super.afterPropertiesSet();
        DataSource dataSource = getDataSources().get(ARG_DS_SOURCE);
        //set daos and their dataSources
        setIcisWorkflowDao(new JdbcIcisWorkflowDao(dataSource));
        setIcisStatusAndProcessingDao(new JdbcIcisStatusAndProcessingDao(getIcisWorkflowDao(), dataSource));

        setTransactionDao((TransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        setPartnerDao((PartnerDao)getServiceFactory().makeService(JdbcPartnerDao.class));

        try {
            setResultsParser(new IcisProcessingResultsXmlParser());
        } catch (JAXBException e) {
            throw new RuntimeException("Unable to create a XML processing context.", e);
        }

        setSettingService((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));

        setEmf(IcisEntityManagerFactory.initEntityManagerFactory(dataSource));
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        /**
         * Check if there is more than one outstanding workflow, if yes, Fail
         */
        int count = getIcisStatusAndProcessingDao().countPendingWorkflows();

        if(count >= 2) {
            result.getAuditEntries().add(new ActivityEntry("Invalid workflow state. More than one pending workflow exists. Exiting."));
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.setSuccess(Boolean.FALSE);
        }

        /**
         * If no workflows exist in Pending, set self Complete
         */
        else if(count == 0) {
            result.getAuditEntries().add(new ActivityEntry("No outstanding submissions to process. Exiting."));
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.setSuccess(Boolean.TRUE);
        }

        /**
         * count must be == 1
         */
        else {

            /**
             * Load pending workflow from ICS_SUBM_TRACK table.
             */
            IcisWorkflow icisWorkflow = getIcisStatusAndProcessingDao().loadPendingWorkflow();

            /**
             * Exit if workflow has not been to ICIS yet, determined by
             * existence of CDX submission transaction id.
             */
            if(StringUtils.isEmpty(icisWorkflow.getSubmissionTransactionId())) {
                result.getAuditEntries().add(new ActivityEntry("Workflow " + icisWorkflow.getId() + " has not been submitted yet. Exiting."));
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }

            /**
             * For the next part, load the original Transaction that we're
             * checking up on, then check with the partner that was configured
             * during its run and check the remote status. Do validation on the
             * lookups, no data is a Failure condition.
             */
            NodeTransaction originalTransaction = getTransactionDao().get(icisWorkflow.getSubmissionTransactionId(), true);

            if(originalTransaction == null) {
                result.getAuditEntries().add(new ActivityEntry("GetStatus operation failed: Workflow id=" + icisWorkflow.getId()
                                                             + "  failed to load the original NodeTransaction of id="
                                                             + icisWorkflow.getSubmissionTransactionId()
                                                             + ".  No more processing can be done."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

            if(originalTransaction.getNetworkEndpointUrl() == null || StringUtils.isEmpty(originalTransaction.getNetworkEndpointUrl().toString())) {

                result.getAuditEntries().add(new ActivityEntry("GetStatus operation failed: Workflow id=" + icisWorkflow.getId() + "  with NodeTransaction of id="
                                                             + icisWorkflow.getSubmissionTransactionId()
                                                             + " failed o find a Remote Partner URL.  No more processing can be done."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

           /**
            * Check the remote status of the transaction.
            */
            PartnerIdentity partner = new PartnerIdentity();
            partner.setUrl(originalTransaction.getNetworkEndpointUrl());
            partner.setVersion(originalTransaction.getNetworkEndpointVersion());

            NodeClientFactory clientFactory = (NodeClientFactory)getServiceFactory().makeService(NodeClientFactory.class);
            NodeClientService client = clientFactory.makeAndConfigure(partner);
            TransactionStatus statusResult = client.getStatus(originalTransaction.getNetworkId());
            if(statusResult != null)
            {
                //2013-02-13 need to set the SUBM_TRANSACTION_STAT every time
                icisWorkflow.setSubmissionTransactionStatus(statusResult.toString());
            }

            if (CommonTransactionStatusCode.Failed.equals(statusResult.getStatus())) {
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                icisWorkflow.setWorkflowStatusMessage("Remote node set transaction to Failed.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                Document responseZipDoc = downloadResponseFile(originalTransaction, client);

                if(responseZipDoc != null) {
                    result.getAuditEntries().add(new ActivityEntry("Successfully downloaded the remote response file, attaching."));
                    attachFileToTransactionAndSave(originalTransaction, responseZipDoc);
                } else {
                    result.getAuditEntries().add(new ActivityEntry("Attempted to download the remote response file, but it was null."));
                }

                result.getAuditEntries().add(new ActivityEntry("Remote node set transaction of id=" + originalTransaction.getNetworkId() + " to Failed. Setting ICS_SUBM_TRACK.WORKFLOW_STAT = Failed."));
                result.getAuditEntries().add(new ActivityEntry("This transaction completed successfully."));
                originalTransaction.getStatus().setStatus(CommonTransactionStatusCode.Failed);
                getTransactionDao().save(transaction);

                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;

            } else if (!CommonTransactionStatusCode.Completed.equals(statusResult.getStatus())) {

                icisWorkflow.setWorkflowStatusMessage("GetStatus returned: " + statusResult.getStatus() + ". Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("GetStatus returned: " + statusResult.getStatus() + ". Exiting."));
                result.getAuditEntries().add(new ActivityEntry("This transaction completed successfully."));
                originalTransaction.getStatus().setStatus(CommonTransactionStatusCode.Failed);
                getTransactionDao().save(transaction);

                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }

            /**
             * When Parse Date Time exists, set WORKFLOW_STAT_MESSAGE to:
             *
             * "Results already downloaded and parsed"
             */
            if (icisWorkflow.getResponseParseDate() != null) {

                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Completed.toString());
                icisWorkflow.setWorkflowStatusMessage("Results already downloaded and parsed.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Results already downloaded and parsed. Exiting."));
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }

            /**
             * Download processing report from CDX, response.zip must be present in response, must contain named files ending with
             */
            result.getAuditEntries().add(new ActivityEntry("Attempting to download response documents for ICIS submission with transaction id \""+originalTransaction.getId()+"\""));

            Document responseZipDoc = downloadResponseFile(originalTransaction, client);


            try {

                if (responseZipDoc == null) {
                    icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Pending.toString());
                    icisWorkflow.setWorkflowStatusMessage("Download did not contain expected files containing processing results.");
                    icisWorkflow.setSubmissionStatusDate(new Date());
                    getIcisWorkflowDao().save(icisWorkflow);

                    result.getAuditEntries().add(new ActivityEntry("Download did not contain expected files containing processing results."));
                    result.setStatus(CommonTransactionStatusCode.Completed);
                    result.setSuccess(Boolean.TRUE);
                    return result;
                }
                //attach to the original transaction and save
                attachFileToTransactionAndSave(originalTransaction, responseZipDoc);

                byte[] accpetedEntry = getAcceptedEntry(responseZipDoc);
                byte[] rejectedEntry = getRejectedEntry(responseZipDoc);

                if(accpetedEntry == null || rejectedEntry == null)
                {
                    //we've chosen to leave this workflow status at Pending
                    icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Pending.toString());
                    icisWorkflow.setWorkflowStatusMessage("Download did not contain expected files containing processing results.");
                    icisWorkflow.setSubmissionStatusDate(new Date());
                    getIcisWorkflowDao().save(icisWorkflow);

                    result.getAuditEntries().add(new ActivityEntry("Download did not contain expected files containing processing results."));
                    result.setStatus(CommonTransactionStatusCode.Completed);
                    result.setSuccess(Boolean.TRUE);
                    return result;
                }

               result.getAuditEntries().add(new ActivityEntry("Attempting to process response documents for ICIS submission with transaction id \""+originalTransaction.getId()+"\" "));

                //Parse the results out of the two byte[] arrays that contain the response files
               parseAndSaveResponseFiles(result, accpetedEntry, rejectedEntry);

            }
            catch(Exception e)
            {
                //If response is improper, local transaction "Failed" and msg: "Download operation failed: {error}. Exiting."
                //OR msg: "Download did not contain expected files containing processing results."
                //Essentially, if anything whatsoever goes wrong, do this (IOException and JAXBException are two big candidates):
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Pending.toString());
                icisWorkflow.setWorkflowStatusMessage("Download operation failed: " + e.getMessage() + ". Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Download operation failed: " + e.getMessage() + ". Exiting."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

            /**
             * Run any configured Post Processing Stored Procedures
             */
            try {

                String procName = getConfigValueAsString(SERVICE_PARAM_POST_PROCESSING_PROC_NAME.getName(), false);

                if(StringUtils.isNotEmpty(procName)) {

                    result.getAuditEntries().add(new ActivityEntry("Executing the stored procedure \"" + procName + "\"."));

                    getIcisStatusAndProcessingDao().runCleanupStoredProc(procName, originalTransaction.getNetworkId());

                    result.getAuditEntries().add(new ActivityEntry("The stored procedure executed successfully."));
                } else  {
                    result.getAuditEntries().add(new ActivityEntry("Post processing stored procedure not configured."));
                }

            } catch (Exception e) {

                //ERRORS result in WORKFLOW_STAT_MESSAGE msg: "Database error copying accepted transactions"
                //and Activity msg: "Database error copying accepted transactions: {DBMS error text}. Exiting."
                //leave in Pending state, manual DB repair will be necessary
                icisWorkflow.setWorkflowStatusMessage("Database error copying accepted transactions");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Database error copying accepted transactions: " + e.getMessage() + ". Exiting."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

            /**
             * Email contacts
             */
            try {
                //SUCCESS  update Complete, WORKFLOW_STAT=Complete, Response Date Time to "now"
                //msg: "Workflow completed successfully. Exiting."
                //This is success, finally!
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Completed.toString());
                icisWorkflow.setWorkflowStatusMessage("Workflow completed successfully. Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                icisWorkflow.setResponseParseDate(new Date());//TODO never set this before, should I have?  confirm and either add where necessary or remove this
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Workflow completed successfully. Exiting."));
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);

                transaction.getStatus().setStatus(CommonTransactionStatusCode.Completed);

                getTransactionDao().save(transaction);

                sendEmailsToContacts(transaction, result);
            }
            catch(Exception e)
            {
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Pending.toString());
                icisWorkflow.setWorkflowStatusMessage("Email to contacts configured, but sending failed with message: " + e.getMessage() + ". Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Email to contacts configured, but sending failed with message: " + e.getMessage() + ". Exiting."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }
        }
        return result;
    }
    private void attachFileToTransactionAndSave(NodeTransaction transaction, Document document) {

        Document doc = getTransactionDao().getDocument(transaction.getNetworkId(), document.getDocumentId());

        /**
         * Does this document already exist in the DB? We need to do this check
         * to avoid duplicate constraint violation.
         */
        if (doc == null) {
            document.setDocumentId(document.getId());
            transaction.getDocuments().add(document);
            getTransactionDao().save(transaction);
        }
    }

    private void parseAndSaveResponseFiles(ProcessContentResult result, byte[] accpetedEntry, byte[] rejectedEntry) throws JAXBException {

        result.getAuditEntries().add(new ActivityEntry("Transforming accepted response file."));
        SubmissionResultList accepted = getResultsParser().parse(result, accpetedEntry, this);

        result.getAuditEntries().add(new ActivityEntry("Transforming rejected response file."));
        SubmissionResultList rejected = getResultsParser().parse(result, rejectedEntry, this);

        // Update ICS_SUBM_RESULTS table with contents of both files, NOTE:
        // blanks are translated to "Accepted" in the InformationCode field

        result.getAuditEntries().add(new ActivityEntry("Saving response data to database."));

        getIcisStatusAndProcessingDao().saveIcisStatusResults(accepted, rejected, emf.createEntityManager());

        /**
         * Get total count saved to DB and log it.
         */
        int totalCountSaved = 0;

        if (accepted != null && accepted.getSubmissionResult() != null) {
            totalCountSaved += accepted.getSubmissionResult().size();
        }

        if (rejected != null && rejected.getSubmissionResult() != null) {
            totalCountSaved += rejected.getSubmissionResult().size();
        }

        result.getAuditEntries().add(new ActivityEntry("Response data saved to database with the following insert row counts: ICS_SUBM_RESULTS ("+totalCountSaved+")"));
    }

    private byte[] getRejectedEntry(Document responseZipDoc) throws IOException {
        return getEntry(responseZipDoc, "rejected");
    }

    private byte[] getAcceptedEntry(Document responseZipDoc) throws IOException {
        return getEntry(responseZipDoc, "accepted");
    }

    private byte[] getEntry(Document responseZipDoc, String entryNameFrangment) throws IOException {

        ZipInputStream zipIn = new ZipInputStream(new ByteArrayInputStream(responseZipDoc.getContent()));

        ZipEntry zipEntry = zipIn.getNextEntry();

        byte[] entry = null;

        while (zipEntry != null) {
            if (zipEntry.getName() != null && zipEntry.getName().toLowerCase().contains(entryNameFrangment)) {
                entry = readZipEntry(zipIn);
            }
            zipEntry = zipIn.getNextEntry();
        }
        return entry;
    }

    private Document downloadResponseFile(NodeTransaction originalTransaction, NodeClientService client) {

        NodeTransaction downloadedTransaction = client.download(originalTransaction);

        Document responseZipDoc = null;

        for (Document currentDoc : downloadedTransaction.getDocuments()) {
            if (currentDoc.getDocumentName().toLowerCase().contains("response.zip")) {
                responseZipDoc = currentDoc;
            }
        }
        return responseZipDoc;
    }

    private void sendEmailsToContacts(NodeTransaction transaction, ProcessContentResult result) {

        String allEmails = getConfigValueAsString(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), false);

        if (StringUtils.isNotEmpty(allEmails)) {

            result.getAuditEntries().add(new ActivityEntry("Sending email notifications to: " + allEmails +  "."));

            String[] emails = allEmails.split(";");

            for(int i = 0; i < emails.length; i++) {

                getNotificationHelper().sendTransactionStatusUpdate(transaction, emails[i], transaction.getFlow().getName());
            }

            result.getAuditEntries().add(new ActivityEntry("Sent email notifications."));

        } else {
            result.getAuditEntries().add(new ActivityEntry("No email contacts configured, no notifications sent."));
        }
    }

    /**
     * Processes a zip entry from it's input stream and returns the resulting byte[]. Utility
     * method.
     *
     * @param zipIn
     * @return
     */
    private byte[] readZipEntry(ZipInputStream zipIn)
    {
        try
        {
            ByteArrayOutputStream out = new ByteArrayOutputStream();
            int interval = 100;
            int start = 0;
            byte[] curr = new byte[interval];
            int read = zipIn.read(curr, start, interval);
            while(read != -1)
            {
                out.write(curr, start, read);
                read = zipIn.read(curr, start, interval);
            }
            return out.toByteArray();
        }catch(IOException e)
        {
            throw new RuntimeException("There was a problem reading an input file.", e);
        }
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    public IcisStatusAndProcessingDao getIcisStatusAndProcessingDao() {
        return icisStatusAndProcessingDao;
    }

    public void setIcisStatusAndProcessingDao(
            IcisStatusAndProcessingDao icisStatusAndProcessingDao) {
        this.icisStatusAndProcessingDao = icisStatusAndProcessingDao;
    }

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public PartnerDao getPartnerDao() {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

    public IcisWorkflowDao getIcisWorkflowDao() {
        return icisWorkflowDao;
    }

    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao) {
        this.icisWorkflowDao = icisWorkflowDao;
    }

    public ResultsParser getResultsParser() {
        return resultsParser;
    }

    public void setResultsParser(ResultsParser resultsParser) {
        this.resultsParser = resultsParser;
    }

    public EntityManagerFactory getEmf() {
        return emf;
    }

    public void setEmf(EntityManagerFactory emf) {
        this.emf = emf;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }
}

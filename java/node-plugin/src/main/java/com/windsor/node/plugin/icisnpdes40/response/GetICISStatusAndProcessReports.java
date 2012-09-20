package com.windsor.node.plugin.icisnpdes40.response;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.io.IOUtils;
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
import com.windsor.node.plugin.icisnpdes40.results.xml.JaxbResultsParser;
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

    public GetICISStatusAndProcessReports()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
        getDataSources().put(ARG_DS_SOURCE, null);

        getConfigurationArguments().put(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), "");//A semicolon delimited list of email addresses used by OpenNode2 to send PDF processing reports downloaded from CDX for completed submissions. PDFs are not distributed in the event of failed processing.
        getConfigurationArguments().put(SERVICE_PARAM_POST_PROCESSING_PROC_NAME.getName(), "");//The name of the stored procedure that copies accepted transactions from Staging-Local to Staging-ICIS. If not set, the procedure is not called. Agencies that do not utilize the plugin’s automated change detection process should not configure the procedure name.
        getConfigurationArguments().put(SERVICE_PARAM_SUBMISSION_PARTNER_NAME.getName(), "");//Yes, The name of the Network Partner configured in OpenNode2 for the CDX endpoint that the submission data will be sent to.
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
        DataSource dataSource = getDataSources().get(ARG_DS_SOURCE);
        //set daos and their dataSources
        setIcisWorkflowDao(new JdbcIcisWorkflowDao(dataSource));
        setIcisStatusAndProcessingDao(new JdbcIcisStatusAndProcessingDao(getIcisWorkflowDao(), dataSource));

        setTransactionDao((TransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        setPartnerDao((PartnerDao)getServiceFactory().makeService(JdbcPartnerDao.class));
        setResultsParser(new JaxbResultsParser());
        setSettingService((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));

        setEmf(IcisEntityManagerFactory.initEntityManagerFactory(dataSource));
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        //check if there is more than one outstanding workflow, if yes, Fail
        //msg: "Invalid workflow state. More than one pending workflow exists. Exiting."
        int count = getIcisStatusAndProcessingDao().countPendingWorkflows();
        if(count >= 2)
        {
            result.getAuditEntries().add(new ActivityEntry("Invalid workflow state. More than one pending workflow exists. Exiting."));
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.setSuccess(Boolean.FALSE);
        }
        //If no workflows exist in Pending, set self Complete
        //msg: "No outstanding submissions to process. Exiting."
        else if(count == 0)
        {
            result.getAuditEntries().add(new ActivityEntry("No outstanding submissions to process. Exiting."));
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.setSuccess(Boolean.TRUE);
        }
        else //count must be == 1
        {
            //load single existing workflow Pending from ICS_SUBM_TRACK table
            IcisWorkflow icisWorkflow = getIcisStatusAndProcessingDao().loadPendingWorkflow();

            //Verify the CDX Transaction Id
            //Failed verification msg: "Workflow {id} has not been submitted yet. Exiting."
            //Set the OpenNode2 local transaction to Complete and exit from further processing.
            if(StringUtils.isEmpty(icisWorkflow.getSubmissionTransactionId()))
            {
                //Failure
                result.getAuditEntries().add(new ActivityEntry("Workflow id=" + icisWorkflow.getId() + "  has not been submitted yet. Exiting."));
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;//TODO single exit point important?
            }

            //For the next part, load the original Transaction that we're checking up on, then check with the partner that was configured
            //during its run and check the remote status.  Do validation on the lookups, no data is a Failure condition.
            NodeTransaction originalTransaction = getTransactionDao().get(icisWorkflow.getSubmissionTransactionId(), true);
            if(originalTransaction == null)
            {
                result.getAuditEntries().add(new ActivityEntry("GetStatus operation failed: Workflow id=" + icisWorkflow.getId()
                                                             + "  failed to load the original NodeTransaction of id="
                                                             + icisWorkflow.getSubmissionTransactionId()
                                                             + ".  No more processing can be done."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }
            else if(originalTransaction.getNetworkEndpointUrl() == null || StringUtils.isEmpty(originalTransaction.getNetworkEndpointUrl().toString()))
            {
                result.getAuditEntries().add(new ActivityEntry("GetStatus operation failed: Workflow id=" + icisWorkflow.getId() + "  with NodeTransaction of id="
                                                             + icisWorkflow.getSubmissionTransactionId()
                                                             + " failed o find a Remote Partner URL.  No more processing can be done."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

            //else check for Remote status
            //Failed means set ICS_SUBM_TRACK.WORKFLOW_STAT = Failed, msg: "Remote node set transaction to Failed."
            //Anything but Failed or Completed: Update the workflow record with the returned transaction status and status date
            //Try for Completed or Failed status one more time, then msg: "GetStatus returned: {status}. Exiting."
            PartnerIdentity partner = new PartnerIdentity();
            partner.setUrl(originalTransaction.getNetworkEndpointUrl());
            partner.setVersion(originalTransaction.getNetworkEndpointVersion());

            NodeClientFactory clientFactory = (NodeClientFactory)getServiceFactory().makeService(NodeClientFactory.class);
            NodeClientService client = clientFactory.makeAndConfigure(partner);
            TransactionStatus statusResult = client.getStatus(originalTransaction.getNetworkId());
            if(CommonTransactionStatusCode.Failed.equals(statusResult.getStatus()))
            {
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                icisWorkflow.setWorkflowStatusMessage("Remote node set transaction to Failed.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Remote node set transaction of id=" + originalTransaction.getNetworkId() + " to Failed.  Setting ICS_SUBM_TRACK.WORKFLOW_STAT = Failed."));
                result.getAuditEntries().add(new ActivityEntry("This transaction completed successfully."));
                originalTransaction.getStatus().setStatus(CommonTransactionStatusCode.Failed);
                getTransactionDao().save(transaction);

                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }
            else if(!CommonTransactionStatusCode.Completed.equals(statusResult.getStatus()))
            {
                //yeah, not actually gonna block and try again, that is needlessly complex
                //icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
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

            //Must be a remote status of Completed, this is the CommonTransactionStatusCode.Completed.equals(statusResult.getStatus()) == true path

            //All Errors in this process() method: msg: "GetStatus operation failed: {error}."

            //Iff Complete
            //If Parse Date Time exists, check WORKFLOW_STAT_MESSAGE for "Results already downloaded and parsed"
            //Set local Complete, then msg: "Results already downloaded and parsed. Exiting."
            if(icisWorkflow.getResponseParseDate() != null)
            {
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Completed.toString());
                icisWorkflow.setWorkflowStatusMessage("Results already downloaded and parsed");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Results already downloaded and parsed. Exiting."));
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }
            //else getResponseParseDate() == null

            //else download processing report from CDX, response.zip must be present in response, must contain named files ending with
            //"Accepted.xml" and "Rejected.xml"
            NodeTransaction downloadedTransaction = client.download(originalTransaction);
            List<Document> downloadedDocuments = downloadedTransaction.getDocuments();
            Document responseZipDoc = null;
            for(int i = 0; downloadedDocuments != null && i < downloadedDocuments.size(); i++)
            {
                Document currentDoc = downloadedDocuments.get(i);
                if(currentDoc.getDocumentName().toLowerCase().contains("response.zip"))
                {
                    responseZipDoc = currentDoc;
                }
            }

            //This will be an argument for the cleanup storec proc later, the response files will contain this, will grab and use later on
            String storedProcedureTransactionIdArgument = null;
            try
            {
                if(responseZipDoc == null)
                {
                    //error condition
                    icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                    icisWorkflow.setWorkflowStatusMessage("Download did not contain expected files containing processing results.");
                    icisWorkflow.setSubmissionStatusDate(new Date());
                    getIcisWorkflowDao().save(icisWorkflow);

                    result.getAuditEntries().add(new ActivityEntry("Download did not contain expected files containing processing results."));
                    result.setStatus(CommonTransactionStatusCode.Completed);
                    result.setSuccess(Boolean.TRUE);
                    return result;
                }

                ZipInputStream zipIn = new ZipInputStream(new ByteArrayInputStream(responseZipDoc.getContent()));
                ZipEntry zipEntry = zipIn.getNextEntry();
                byte[] accpetedEntry = null;
                byte[] rejectedEntry = null;
                while(zipEntry != null)
                {
                    if(zipEntry.getName() != null && zipEntry.getName().toLowerCase().contains("accepted"))
                    {
                        accpetedEntry = readZipEntry(zipIn);
                        String tmpFile = FilenameUtils.concat(
                                getSettingService().getTempDir().getAbsolutePath(), zipEntry.getName());
                        IOUtils.write(accpetedEntry, new FileOutputStream(tmpFile));
                    }
                    if(zipEntry.getName() != null && zipEntry.getName().toLowerCase().contains("rejected"))
                    {
                        rejectedEntry = readZipEntry(zipIn);
                        String tmpFile = FilenameUtils.concat(
                                getSettingService().getTempDir().getAbsolutePath(), zipEntry.getName());
                        IOUtils.write(accpetedEntry, new FileOutputStream(tmpFile));
                    }
                    zipEntry = zipIn.getNextEntry();
                }

                if(accpetedEntry == null || rejectedEntry == null)
                {
                    icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                    icisWorkflow.setWorkflowStatusMessage("Download did not contain expected files containing processing results.");
                    icisWorkflow.setSubmissionStatusDate(new Date());
                    getIcisWorkflowDao().save(icisWorkflow);

                    result.getAuditEntries().add(new ActivityEntry("Download did not contain expected files containing processing results."));
                    result.setStatus(CommonTransactionStatusCode.Completed);
                    result.setSuccess(Boolean.TRUE);
                    return result;
                }

                //Parse the results out of the two byte[] arrays that contain the response files
                /*List<IcisStatusResult> accepted = getResultsParser().parse(accpetedEntry, this);
                List<IcisStatusResult> rejected = getResultsParser().parse(rejectedEntry, this);*/
                SubmissionResultList accepted = getResultsParser().parse(accpetedEntry, this);
                SubmissionResultList rejected = getResultsParser().parse(rejectedEntry, this);

                //Snag the transactionId out of one of the response files for use in the clean up stored proc later on
                if(accepted != null && accepted.getSubmissionResult() != null && !accepted.getSubmissionResult().isEmpty())
                {
                    storedProcedureTransactionIdArgument = accepted.getSubmissionResult().get(0).getSubmissionTransactionId();
                }
                else if(rejected != null && rejected.getSubmissionResult() != null && !rejected.getSubmissionResult().isEmpty())
                {
                    storedProcedureTransactionIdArgument = rejected.getSubmissionResult().get(0).getSubmissionTransactionId();
                }

                //Update ICS_SUBM_RESULTS table with contents of both files, NOTE: blanks are translated to "Accepted" in the InformationCode field
                getIcisStatusAndProcessingDao().saveIcisStatusResults(accepted, rejected, emf.createEntityManager());


            }
            catch(Exception e)
            {
                //If response is improper, local transaction "Failed" and msg: "Download operation failed: {error}. Exiting."
                //OR msg: "Download did not contain expected files containing processing results."
                //Essentially, if anything whatsoever goes wrong, do this (IOException and JAXBException are two big candidates):
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                icisWorkflow.setWorkflowStatusMessage("Download operation failed: " + e.getMessage() + ". Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                getIcisWorkflowDao().save(icisWorkflow);

                result.getAuditEntries().add(new ActivityEntry("Download operation failed: " + e.getMessage() + ". Exiting."));
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.setSuccess(Boolean.FALSE);
                return result;
            }

            //Run any configured Post Processing Stored Procedures
            try
            {
                String procName = getConfigValueAsString(SERVICE_PARAM_POST_PROCESSING_PROC_NAME.getName(), false);
                if(StringUtils.isNotEmpty(procName))
                {
                    getIcisStatusAndProcessingDao().runCleanupStoredProc(procName, storedProcedureTransactionIdArgument);
                }
            }
            catch (Exception e)
            {
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

            //email contacts, inserted my own logic for failure on this step
            try
            {
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
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
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

    private void sendEmailsToContacts(NodeTransaction transaction, ProcessContentResult result)
    {
        String allEmails = getConfigValueAsString(SERVICE_PARAM_NOTIFICATION_EMAIL_ADDRS.getName(), false);
        if(StringUtils.isNotEmpty(allEmails))
        {
            result.getAuditEntries().add(new ActivityEntry("Email contacts configured, notifications will be sent to the following emails: " + allEmails +  "."));
            String[] emails = allEmails.split(";");
            for(int i = 0; i < emails.length; i++)
            {

                getNotificationHelper().sendTransactionStatusUpdate(transaction, emails[i], transaction.getFlow().getName());
            }
        }
        else
        {
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
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }

    public IcisStatusAndProcessingDao getIcisStatusAndProcessingDao()
    {
        return icisStatusAndProcessingDao;
    }

    public void setIcisStatusAndProcessingDao(IcisStatusAndProcessingDao icisStatusAndProcessingDao)
    {
        this.icisStatusAndProcessingDao = icisStatusAndProcessingDao;
    }

    public TransactionDao getTransactionDao()
    {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    public PartnerDao getPartnerDao()
    {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao)
    {
        this.partnerDao = partnerDao;
    }

    public IcisWorkflowDao getIcisWorkflowDao()
    {
        return icisWorkflowDao;
    }

    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao)
    {
        this.icisWorkflowDao = icisWorkflowDao;
    }

    public ResultsParser getResultsParser()
    {
        return resultsParser;
    }

    public void setResultsParser(ResultsParser resultsParser)
    {
        this.resultsParser = resultsParser;
    }

    public EntityManagerFactory getEmf()
    {
        return emf;
    }

    public void setEmf(EntityManagerFactory emf)
    {
        this.emf = emf;
    }

}

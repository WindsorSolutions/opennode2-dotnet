package com.windsor.node.plugin.icisnpdes40;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.sql.DataSource;
import org.apache.commons.lang3.StringUtils;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
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
import com.windsor.node.plugin.icisnpdes40.dao.JdbcIcisStatusAndProcessingDao;
import com.windsor.node.plugin.icisnpdes40.dao.JdbcIcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.service.helper.client.NodeClientFactory;

public class GetICISStatusAndProcessReports extends BaseWnosJaxbPlugin
{
    //TODO use extracted interface instead, when done
    private JdbcIcisStatusAndProcessingDao icisStatusAndProcessingDao;
    private TransactionDao transactionDao;
    private PartnerDao partnerDao;

    public GetICISStatusAndProcessReports()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
        getDataSources().put(ARG_DS_SOURCE, null);

        getConfigurationArguments().put("Notification Email Addresses", "");//A semicolon delimited list of email addresses used by OpenNode2 to send PDF processing reports downloaded from CDX for completed submissions. PDFs are not distributed in the event of failed processing.
        getConfigurationArguments().put("Post Processing Procedure Name", "");//The name of the stored procedure that copies accepted transactions from Staging-Local to Staging-ICIS. If not set, the procedure is not called. Agencies that do not utilize the plugin’s automated change detection process should not configure the procedure name.
        getConfigurationArguments().put("Submission Partner Name", "");//Yes, The name of the Network Partner configured in OpenNode2 for the CDX endpoint that the submission data will be sent to.
        getConfigurationArguments().put("Data Source", "");//Yes, The name of the Data Source configured in OpenNode2 representing a connection to the Staging-Local tables for the ICIS-NPDES exchange.
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
        DataSource dataSource = (DataSource)getDataSources().get(ARG_DS_SOURCE);
        //set daos and their dataSources
        setIcisStatusAndProcessingDao(new JdbcIcisStatusAndProcessingDao());
        getIcisStatusAndProcessingDao().setDataSource(dataSource);

        setTransactionDao((TransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        setPartnerDao((PartnerDao)getServiceFactory().makeService(JdbcPartnerDao.class));

        getIcisStatusAndProcessingDao().setIcisWorkflowDao(new JdbcIcisWorkflowDao(dataSource));
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
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
            NodeTransaction originalTransaction = getTransactionDao().get(icisWorkflow.getSubmissionTransactionId(), false);
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
            partner.setVersion(originalTransaction.getEndpointVersion());

            NodeClientFactory clientFactory = (NodeClientFactory)getServiceFactory().makeService(NodeClientFactory.class);
            NodeClientService client = clientFactory.makeAndConfigure(partner);
            TransactionStatus statusResult = client.getStatus(originalTransaction.getNetworkId());
            if(CommonTransactionStatusCode.Failed.equals(statusResult.getStatus()))
            {
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                icisWorkflow.setWorkflowStatusMessage("Remote node set transaction to Failed.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                //FIXME SAVE ICIS WORKFLOW OBJECT
                result.getAuditEntries().add(new ActivityEntry("Remote node set transaction of id=" + originalTransaction.getNetworkId() + " to Failed.  Setting ICS_SUBM_TRACK.WORKFLOW_STAT = Failed."));
                result.getAuditEntries().add(new ActivityEntry("This transaction completed succesfully."));
                originalTransaction.getStatus().setStatus(CommonTransactionStatusCode.Failed);
                //FIXME save updated originalTransaction
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }
            else if(!CommonTransactionStatusCode.Completed.equals(statusResult.getStatus()))
            {
                //yeah, not actually gonna block and try again, forget that
                icisWorkflow.setWorkflowStatus(CommonTransactionStatusCode.Failed.toString());
                icisWorkflow.setWorkflowStatusMessage("GetStatus returned: " + statusResult.getStatus() + ". Exiting.");
                icisWorkflow.setSubmissionStatusDate(new Date());
                //FIXME SAVE ICIS WORKFLOW OBJECT
                result.getAuditEntries().add(new ActivityEntry("GetStatus returned: " + statusResult.getStatus() + ". Exiting."));
                result.getAuditEntries().add(new ActivityEntry("This transaction completed succesfully."));
                originalTransaction.getStatus().setStatus(CommonTransactionStatusCode.Failed);
                //FIXME save updated originalTransaction
                result.setStatus(CommonTransactionStatusCode.Completed);
                result.setSuccess(Boolean.TRUE);
                return result;
            }

            //Must be a remote status of Completed, this is the CommonTransactionStatusCode.Completed.equals(statusResult.getStatus()) == true path

            //All Errors in this process() method: msg: "GetStatus operation failed: {error}."

            //Iff Complete
            //If Parse Date Time exists, check WORKFLOW_STAT_MESSAGE for "Results already downloaded and parsed"
            //Set local Complete, then msg: "Results already downloaded and parsed. Exiting."

            //else download processing report from CDX, response.zip must be present in response, must contain named files ending with
            //"Accepted.xml" and "Rejected.xml"
            //If response is improper, local transaction "Failed" and msg: "Download operation failed: {error}. Exiting."
            //OR msg: "Download did not contain expected files containing processing results."

            //Update ICS_SUBM_RESULTS table with contents of both files, NOTE: blanks are translated to "Accepted" in the InformationCode field

            //Run any configured Post Processing Stored Procedures
            //ERRORS result in WORKFLOW_STAT_MESSAGE msg: "Database error copying accepted transactions"
            //and Activity msg: "Database error copying accepted transactions: {DBMS error text}. Exiting."
            //leave in Pending state, manual DB repair will be necessary

            //SUCCESS email contacts, update Complete, WORKFLOW_STAT=Complete, Response Date Time to "now"
            //msg: "Workflow completed successfully. Exiting."
        }
            

        return result;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }

    public JdbcIcisStatusAndProcessingDao getIcisStatusAndProcessingDao()
    {
        return icisStatusAndProcessingDao;
    }

    public void setIcisStatusAndProcessingDao(JdbcIcisStatusAndProcessingDao icisStatusAndProcessingDao)
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

}

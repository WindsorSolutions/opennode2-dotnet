package com.windsor.node.plugin.uic;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class UicGetStatus extends BaseUicPlugin
{
    public static final String SERVICE_NAME = "UICGetStatus";
    public static final PluginServiceParameterDescriptor ORG_ID = new PluginServiceParameterDescriptor("Org ID", "java.lang.String", Boolean.TRUE,
                    "The Org ID to be used in the submission Header. Also governs SELECT logic on UIC_ORGANIZATION table.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("UicGetStatus");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("The UicGetStatus service will retrieve the status all outstanding Received or Pending submissions from CDX and update the status in the node's data repository.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(UicGetStatus.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public UicGetStatus()
    {
        debug("UicGetStatus instantiated.");
    }

    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
    }

    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List params = new ArrayList();
        params.add(ORG_ID);
        return params;
    }

    public ProcessContentResult process(NodeTransaction transaction)
    {
        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        try
        {
            List localTranIds = getStatusDao().getPendingTransactionIds(getOrgIdFromTransaction(transaction));

            if(localTranIds.size() == 0)
            {
                result.getAuditEntries().add(makeEntry("No Pending or Processing transactions found"));
            }
            else
            {
                result.getAuditEntries().add(makeEntry("found " + localTranIds.size() + " Pending or Processing transactions"));

                List networkTranIds = new ArrayList(localTranIds.size());

                for (int i = 0; i < localTranIds.size(); i++)
                {
                    NodeTransaction tran = getTransactionDao().get((String) localTranIds.get(0), false);

                    networkTranIds.add(tran.getNetworkId());
                }
                debug("done looking up Network Transaction ids for Local Transaction ids");

                PartnerIdentity partner = makePartner();

                NodeClientService client = makeNodeClient(partner);

                for (int i = 0; i < networkTranIds.size(); i++)
                {
                    String localTranId = (String) localTranIds.get(i);
                    String networkTranId = (String) networkTranIds.get(i);

                    result.getAuditEntries().add(
                                    makeEntry("attempting getStatus for networkTranId: " + networkTranId + " localTranId: " + localTranId + " partnerUrl: "
                                                    + partner.getUrl()));

                    CommonTransactionStatusCode remoteStatus = client.getStatus(networkTranId).getStatus();

                    result.getAuditEntries().add(makeEntry("remote status is " + remoteStatus.name()));

                    if((remoteStatus.equals(CommonTransactionStatusCode.Completed)) || (remoteStatus.equals(CommonTransactionStatusCode.Processed)))
                    {
                        getStatusDao().updateStatus(localTranId, CommonTransactionStatusCode.Completed);
                    }
                    else if(remoteStatus.equals(CommonTransactionStatusCode.Failed))
                    {
                        getStatusDao().updateStatus(localTranId, CommonTransactionStatusCode.Failed);
                    }

                }

            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.getAuditEntries().add(makeEntry("Done: OK"));
        }
        catch(Exception ex)
        {
            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(makeEntry("Error while executing: " + getClass().getName() + " Message: " + ex.getMessage()));
        }

        return result;
    }

    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }
}
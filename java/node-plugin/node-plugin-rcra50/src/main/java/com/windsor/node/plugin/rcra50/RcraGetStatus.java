package com.windsor.node.plugin.rcra50;

import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;

public class RcraGetStatus extends BaseRcra50Plugin {

    public static final String SERVICE_NAME = "RcraGetStatus";

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("RcraGetStatus");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Gets the remote status and updates the transaction history.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(RcraGetStatus.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public RcraGetStatus() {

        super();

        debug("Setting service types");
        getSupportedPluginTypes().add(ServiceType.TASK);

        debug("RcraGetStatus instantiated.");
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            // use statusDao to get pending tran id for an operation type
            RcraOperationType opType = getOperationTypeFromTransaction(transaction);
            String localTranId = getStatusDao().getPendingTransactionId(opType);

            if (localTranId == null) {

                result
                        .getAuditEntries()
                        .add(
                                makeEntry("No Pending or Processing transactions found"));
            } else {

                result
                        .getAuditEntries()
                        .add(
                                makeEntry("found Pending or Processing transactions with Id "
                                        + localTranId));

                // look up the network id & associated partner URL
                NodeTransaction tran = getTransactionDao().get(localTranId,
                        false);

                String networkTranId = tran.getNetworkId();
                debug("found Network Transaction id " + networkTranId);

                PartnerIdentity partner = makePartner();

                NodeClientService client = makeNodeClient(partner);

                // execute getStatus calls
                result.getAuditEntries().add(
                        makeEntry("attempting getStatus for networkTranId: "
                                + networkTranId + " localTranId: "
                                + localTranId + " partnerUrl: "
                                + partner.getUrl()));

                CommonTransactionStatusCode remoteStatus = client.getStatus(
                        networkTranId).getStatus();

                result.getAuditEntries().add(
                        makeEntry("remote status is " + remoteStatus.name()));

                // update status in staging tables
                if (remoteStatus.equals(CommonTransactionStatusCode.Completed)
                        || remoteStatus
                                .equals(CommonTransactionStatusCode.Processed)) {
                    getStatusDao().updateStatus(localTranId,
                            CommonTransactionStatusCode.Completed);
                } else if (remoteStatus
                        .equals(CommonTransactionStatusCode.Failed)) {
                    getStatusDao().updateStatus(localTranId,
                            CommonTransactionStatusCode.Failed);
                }
            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {
            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        return result;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

}

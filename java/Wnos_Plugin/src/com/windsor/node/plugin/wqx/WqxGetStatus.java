package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class WqxGetStatus extends BaseWqxPlugin {

    public static final String SERVICE_NAME = "WQXGetStatus";

    public WqxGetStatus() {

        super();
        debug("WqxGetStatus instantiated.");
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            // use statusDao to get list of pending tran ids
            List localTranIds = statusDao.getPendingTransactionIds();

            if (localTranIds.size() == 0) {

                result
                        .getAuditEntries()
                        .add(
                                makeEntry("No Pending or Processing transactions found"));

            } else {

                result.getAuditEntries().add(
                        makeEntry("found " + localTranIds.size()
                                + " Pending or Processing transactions"));

                // look up the network ids & associated partner URLs
                List networkTranIds = new ArrayList(localTranIds.size());

                for (int i = 0; i < localTranIds.size(); i++) {

                    NodeTransaction tran = transactionDao.get(
                            (String) localTranIds.get(0), false);

                    networkTranIds.add(tran.getNetworkId());
                }
                debug("done looking up Network Transaction ids for Local Transaction ids");

                PartnerIdentity partner = makePartner();

                NodeClientService client = makeNodeClient(partner);

                // execute getStatus calls

                for (int i = 0; i < networkTranIds.size(); i++) {

                    String localTranId = (String) localTranIds.get(i);
                    String networkTranId = (String) networkTranIds.get(i);

                    result
                            .getAuditEntries()
                            .add(
                                    makeEntry("attempting getStatus for networkTranId: "
                                            + networkTranId
                                            + " localTranId: "
                                            + localTranId
                                            + " partnerUrl: "
                                            + partner.getUrl()));

                    CommonTransactionStatusCode remoteStatus = client
                            .getStatus(networkTranId).getStatus();

                    result.getAuditEntries().add(
                            makeEntry("remote status is "
                                    + remoteStatus.getName()));

                    // update status in staging tables
                    if (remoteStatus
                            .equals(CommonTransactionStatusCode.COMPLETED)
                            || remoteStatus
                                    .equals(CommonTransactionStatusCode.PROCESSED)) {
                        statusDao.updateStatus(localTranId,
                                CommonTransactionStatusCode.COMPLETED);
                    } else if (remoteStatus
                            .equals(CommonTransactionStatusCode.FAILED)) {
                        statusDao.updateStatus(localTranId,
                                CommonTransactionStatusCode.FAILED);
                    }
                }

            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.COMPLETED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {
            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        return result;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public IdGenerator getIdGenerator() {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
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

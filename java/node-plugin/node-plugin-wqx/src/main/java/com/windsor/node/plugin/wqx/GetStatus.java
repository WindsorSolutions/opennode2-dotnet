package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.PersistenceException;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.wqx.domain.SubmissionHistory;
import com.windsor.node.plugin.wqx.service.AbstractWqxService;
import com.windsor.node.plugin.wqx.service.ScheduleParameters;

/**
 * Find local pending transactions in the SubmissionHistory table and check on
 * the status at the remote node. Update the local CDX status with that of the
 * remote node transaction status.
 *
 * Type: TASK
 *
 */
public class GetStatus extends AbstractWqxService {

    private static final int PARAM_INDEX_SUBMISSION_PARTNER_NAME = 1;

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("GetStatus");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("The GetStatus service will retrieve the status all outstanding Received or Pending submissions from CDX and update the status in the node’s data repository.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetStatus.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    protected ServiceType supportsServiceType() {
        return ServiceType.TASK;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(ORG_ID);                     // available @ index = 0
        params.add(SUBMISSION_PARTNER_NAME);    // available @ index = 1
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        recordAtivity(result, "WQX \"%s\" process starting.", GetStatus.class.getSimpleName());

        final ScheduleParameters scheduleParameters = new ScheduleParameters(transaction) {

            @Override
            public String getSubmissionPartnerName() {
                return stringValue(GetStatus.PARAM_INDEX_SUBMISSION_PARTNER_NAME);
            }
        };

        try {

            recordAtivity(result, "Checking for \"Pending\" or \"Processing\" transactions with Org ID \"%s\"", scheduleParameters.getOrgId());

            /**
             * Get the list of pending transactions from Submission History table and loop.
             */
            List<SubmissionHistory> historyList =
                    getSubmissionHistoryDao().getPendingTransactionsByOrgId(scheduleParameters.getOrgId());


            if (historyList.isEmpty()) {

                recordAtivity(result, "No \"Pending\" or \"Processing\" transactions found in WQX submission history table.");

            } else {

                recordAtivity(result, "Found %s transaction(s).", historyList.size());

                for (SubmissionHistory history : historyList) {

                    recordAtivity(result, "Looking up local network exchange transaction \"%s\".", history.getLocalTransactionId());

                    NodeTransaction localNodeTransaction = getTransactionDao().get(history.getLocalTransactionId(), Boolean.FALSE);

                    recordAtivity(result, "Found local network exchange transaction.");

                    recordAtivity(result, "Creating network exchange client to lookup remote transaction status.");

                    NodeClientService client = getNodeClientService(scheduleParameters, transaction);

                    recordAtivity(result, "Attempting to retrieve remote status of transaction.");

                    CommonTransactionStatusCode remoteStatus = client.getStatus(localNodeTransaction.getNetworkId()).getStatus();

                    recordAtivity(result, "Found remote status of \"%s\".", remoteStatus.name());

                    if (remoteStatus != null) {

                        try {

                            getEntityManager().getTransaction().begin();

                            recordAtivity(result, "Updating WQX submission history table with remote status.");

                            switch (remoteStatus) {
                                case Completed:
                                    getSubmissionHistoryDao().updateStatus(history, CommonTransactionStatusCode.Completed);
                                    break;
                                case Processed:
                                    getSubmissionHistoryDao().updateStatus(history, CommonTransactionStatusCode.Completed);
                                    break;
                                case Failed:
                                    getSubmissionHistoryDao().updateStatus(history, CommonTransactionStatusCode.Failed);
                                    break;
                                default:
                                    throw new RuntimeException(String.format("Uknown remote status \"%s\".", remoteStatus));
                            }

                            getEntityManager().getTransaction().commit();

                        } catch (PersistenceException pe) {

                            error(pe);

                            getEntityManager().getTransaction().rollback();

                            throw new RuntimeException(String.format("Unable to update processing status in WQX submission history table.  Error: %s", pe.getLocalizedMessage()));
                        }
                    }
                }
            }

            /**
             * Done
             */
            recordAtivity(result, "%s completed successfully.", GetStatus.class.getSimpleName());
            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);

        } catch (Exception e) {

            error(e);

            recordAtivity(result, "%s did not complete successfully. Error: %s",  GetStatus.class.getSimpleName(), e.getLocalizedMessage());
        }

        return result;
    }
}

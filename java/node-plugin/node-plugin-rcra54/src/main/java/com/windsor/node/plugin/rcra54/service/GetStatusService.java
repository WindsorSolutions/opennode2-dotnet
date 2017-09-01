package com.windsor.node.plugin.rcra54.service;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.plugin.rcra54.domain.OperationType;
import com.windsor.node.plugin.rcra54.domain.SubmissionHistory;

import java.util.List;

public class GetStatusService extends AbstractRcraService {
	
	public GetStatusService() {
		super(OperationType.GET_STATUS);
	}
	
	@Override
	public ProcessContentResult process(NodeTransaction transaction) {
		final ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);
        recordActivity(result, "RCRA \"%s\" process starting.", GetStatusService.class.getSimpleName());
		try {
            recordActivity(result, "Checking for \"Pending\" or \"Processing\" transactions");
            List<SubmissionHistory> historyList = getRcraDao().getOutstandingSubmissions();
            if (historyList.isEmpty()) {
                recordActivity(result, "No \"Pending\" or \"Processing\" transactions found in RCRA submission history table.");
            } else {
                recordActivity(result, "Found %s outstanding submission(s).", historyList.size());
                for (SubmissionHistory history : historyList) {
                    recordActivity(result, "Looking up local network exchange transaction \"%s\".", history.getTransactionId());
                    NodeTransaction localNodeTransaction = getTransactionDao().get(history.getTransactionId(), Boolean.FALSE);
                    if (localNodeTransaction.getNetworkEndpointUrl() != null) {
                        recordActivity(result, "Found local network exchange transaction.");
                        recordActivity(result, "Creating network exchange client to lookup remote transaction status.");
                        NodeClientService client = getNodeClientService(localNodeTransaction);
                        recordActivity(result, "Attempting to retrieve remote status of transaction.");
                        CommonTransactionStatusCode remoteStatus = client.getStatus(localNodeTransaction.getNetworkId()).getStatus();
                        recordActivity(result, "Found remote status of \"%s\".", remoteStatus.name());
                        recordActivity(result, "Updating RCRA submission history table with remote status.");
                        getRcraDao().updateSubmissionHistoryStatus(history, remoteStatus);
                    } else {
                        getRcraDao().updateSubmissionHistoryStatus(history, localNodeTransaction.getStatus().getStatus());
                    }
                }
            }
            recordActivity(result, "%s completed successfully.", GetStatusService.class.getSimpleName());
            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
        } catch (Exception e) {
            error(e);
            recordActivity(result, "%s did not complete successfully. Error: %s",  GetStatusService.class.getSimpleName(), e.getLocalizedMessage());
        } finally {
            try {
                destroy();
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
        }
        return result;
	}

}

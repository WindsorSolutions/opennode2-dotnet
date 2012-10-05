package com.windsor.node.plugin.wqx.dao;

import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.wqx.domain.SubmissionHistory;

public interface SubmissionHistoryDao {

    boolean pendingTransactionsExist(String orgId, String operation);

    SubmissionHistory createSubmissionHistoryRecord(String id, String orgId, String submissionType, String localTransactionId, CommonTransactionStatusCode status);

    SubmissionHistory findLatestProcessed(String orgId, String submissionType);

    void resetSubmissionStatusByOrgId(String orgId);

    List<SubmissionHistory> getPendingTransactionsByOrgId(String orgId);

    void updateStatus(SubmissionHistory history, CommonTransactionStatusCode status);

}

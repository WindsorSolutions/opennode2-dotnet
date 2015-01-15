package com.windsor.node.plugin.icisnpdes.dao;

import javax.persistence.EntityManager;
import com.windsor.node.plugin.icisnpdes.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes.generated.SubmissionResultList;

public interface IcisStatusAndProcessingDao
{

    public int countPendingWorkflows();

    /**
     * Will break if there is not exactly 1 result, must call countPendingWorkflows() and handle exception states first
     * @return
     */
    public IcisWorkflow loadPendingWorkflow();

    public void saveIcisStatusResults(SubmissionResultList accepted, SubmissionResultList rejected, EntityManager em);

    public void runCleanupStoredProc(String procName, String storedProcedureTransactionIdArgument);

    public IcisWorkflowDao getIcisWorkflowDao();

    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao);

}
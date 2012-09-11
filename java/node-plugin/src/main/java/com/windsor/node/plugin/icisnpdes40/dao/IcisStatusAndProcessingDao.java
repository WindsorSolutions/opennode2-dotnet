package com.windsor.node.plugin.icisnpdes40.dao;

import java.util.List;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes40.results.IcisStatusResult;

public interface IcisStatusAndProcessingDao
{

    public int countPendingWorkflows();

    /**
     * Will break if there is not exactly 1 result, must call countPendingWorkflows() and handle exception states first
     * @return
     */
    public IcisWorkflow loadPendingWorkflow();

    public void saveIcisStatusResults(List<IcisStatusResult> accepted, List<IcisStatusResult> rejected);

    public void runCleanupStoredProc(String procName, String storedProcedureTransactionIdArgument);

    public IcisWorkflowDao getIcisWorkflowDao();

    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao);

}
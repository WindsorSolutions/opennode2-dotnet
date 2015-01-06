package com.windsor.node.plugin.icisair.dao;

import com.windsor.node.plugin.icisair.domain.IcisWorkflow;

public interface IcisWorkflowDao
{

    /**
     * Returns a count of 'Pending' ICA_SUBM_TRACK records.
     * 
     * @return count of 'Pending' ICA_SUBM_TRACK records.
     */
    public int countPendingWorkflows();

    /**
     * Returns the current 'Pending' workflow record or null if one is not
     * found.
     * 
     * @return The current 'Pending' workflow record.
     */
    public IcisWorkflow findPendingWorkflow();

    public IcisWorkflow loadById(String id);

    public void save(IcisWorkflow icisWorkflow);

}
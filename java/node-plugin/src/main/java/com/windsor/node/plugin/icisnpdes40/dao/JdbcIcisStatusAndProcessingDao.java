package com.windsor.node.plugin.icisnpdes40.dao;

import java.sql.Types;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;

//TODO Extract Interface
public class JdbcIcisStatusAndProcessingDao extends JdbcDaoSupport
{
    private JdbcIcisWorkflowDao icisWorkflowDao;
    public int countPendingWorkflows()
    {
        return getJdbcTemplate().queryForInt("SELECT count(*) from ICS_SUBM_TRACK where WORKFLOW_STAT = ?",
                                             new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR});
    }

    /**
     * Will break if there is not exactly 1 result, must call countPendingWorkflows() and handle exception states first
     * @return
     */
    public IcisWorkflow loadPendingWorkflow()
    {
        String id = (String)getJdbcTemplate().queryForObject("SELECT ICS_SUBM_TRACK_ID where WORKFLOW_STAT = ?",
                                     new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR}, String.class);
        return getIcisWorkflowDao().loadById(id);
    }

    public JdbcIcisWorkflowDao getIcisWorkflowDao()
    {
        return icisWorkflowDao;
    }

    public void setIcisWorkflowDao(JdbcIcisWorkflowDao icisWorkflowDao)
    {
        this.icisWorkflowDao = icisWorkflowDao;
    }
}

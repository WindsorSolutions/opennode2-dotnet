package com.windsor.node.plugin.icisnpdes40.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;

//TODO Extract Interface
public class JdbcIcisStatusAndProcessingDao extends JdbcDaoSupport
{

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
        return (IcisWorkflow)getJdbcTemplate().query("SELECT ICS_SUBM_TRACK_ID, ETL_CMPL_DATE_TIME, DET_CHANGE_CMPL_DATE_TIME, SUBM_DATE_TIME, SUBM_TRANSACTION_ID, SUBM_TRANSACTION_STAT, SUBM_STAT_DATE_TIME, RSPN_PARSE_DATE_TIME, WORKFLOW_STAT, WORKFLOW_STAT_MESSAGE from ICS_SUBM_TRACK where WORKFLOW_STAT = ?",
                                     new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR}, new IcisWorkflowRowMapper());
    }

    class IcisWorkflowRowMapper implements RowMapper
    {
        @Override
        public Object mapRow(ResultSet rs, int rowNum) throws SQLException
        {
            IcisWorkflow icisWorkflow = new IcisWorkflow();
            icisWorkflow.setId(rs.getString("ICS_SUBM_TRACK_ID"));
            icisWorkflow.setEtlCompletionDate(rs.getDate("ETL_CMPL_DATE_TIME"));
            icisWorkflow.setDetectionChangeCompletionDate(rs.getDate("DET_CHANGE_CMPL_DATE_TIME"));
            icisWorkflow.setSubmissionDate(rs.getDate("ICS_SUBM_TRACK_ID"));
            icisWorkflow.setSubmissionTransactionId(rs.getString("SUBM_TRANSACTION_ID"));
            icisWorkflow.setSubmissionTransactionStatus(rs.getString("SUBM_TRANSACTION_STAT"));
            icisWorkflow.setSubmissionStatusDate(rs.getDate("SUBM_STAT_DATE_TIME"));
            icisWorkflow.setResponseParseDate(rs.getDate("RSPN_PARSE_DATE_TIME"));
            icisWorkflow.setWorkflowStatus(rs.getString("WORKFLOW_STAT"));
            icisWorkflow.setWorkflowStatusMessage(rs.getString("WORKFLOW_STAT_MESSAGE"));
            return icisWorkflow;
        }
    }
}

package com.windsor.node.plugin.icisnpdes40.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.UUID;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
//TODO extract interface
public class JdbcIcisWorkflowDao extends JdbcDaoSupport
{
    public IcisWorkflow loadById(String id)
    {
        if(StringUtils.isEmpty(id))
        {
            throw new IllegalArgumentException("JdbcIcisWorkflowDao method loadById(String id) id cannot be null.");
        }
        //FIXME extract sql to static member
        return (IcisWorkflow)getJdbcTemplate().query("SELECT ICS_SUBM_TRACK_ID, ETL_CMPL_DATE_TIME, DET_CHANGE_CMPL_DATE_TIME, SUBM_DATE_TIME, SUBM_TRANSACTION_ID, SUBM_TRANSACTION_STAT, SUBM_STAT_DATE_TIME, RSPN_PARSE_DATE_TIME, WORKFLOW_STAT, WORKFLOW_STAT_MESSAGE from ICS_SUBM_TRACK where ICS_SUBM_TRACK_ID = ?",
                                              new Object[]{id}, new int[]{Types.VARCHAR}, new IcisWorkflowRowMapper());
    }

    public void save(IcisWorkflow icisWorkflow)
    {
        if(icisWorkflow == null)
        {
            throw new IllegalArgumentException("JdbcIcisWorkflowDao method save(IcisWorkflow icisWorkflow) icisWorkflow cannot be null.");
        }
        if(StringUtils.isEmpty(icisWorkflow.getId()))
        {
            //insert
            //err, how do we gen the id for the insert? guess this will do, should always be less than 32 bytes that are allowed... I hope.
            String newId = UUID.randomUUID().toString();
            getJdbcTemplate().update("INSERT INTO ICS_SUBM_TRACK (ICS_SUBM_TRACK_ID, ETL_CMPL_DATE_TIME, DET_CHANGE_CMPL_DATE_TIME,"
                                                     + " SUBM_DATE_TIME, SUBM_TRANSACTION_ID, SUBM_TRANSACTION_STAT, SUBM_STAT_DATE_TIME,"
                                                     + " RSPN_PARSE_DATE_TIME, WORKFLOW_STAT, WORKFLOW_STAT_MESSAGE)"
                                                     + "VALUES (?,?,?,?,?,?,?,?,?,?)",
                                     new Object[]{newId, icisWorkflow.getEtlCompletionDate(), icisWorkflow.getDetectionChangeCompletionDate(),
                                                     icisWorkflow.getSubmissionStatusDate(), icisWorkflow.getSubmissionTransactionId(),
                                                     icisWorkflow.getSubmissionTransactionStatus(), icisWorkflow.getSubmissionStatusDate(),
                                                     icisWorkflow.getResponseParseDate(), icisWorkflow.getWorkflowStatus(),
                                                     icisWorkflow.getWorkflowStatusMessage()},
                                     new int[]{Types.VARCHAR, Types.TIMESTAMP, Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR,
                                                     Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR});
        }
        else
        {
            //save
            getJdbcTemplate().update("UPDATE ICS_SUBM_TRACK SET ETL_CMPL_DATE_TIME = ?, " +
                            		"DET_CHANGE_CMPL_DATE_TIME = ?, " +
                            		"SUBM_DATE_TIME = ?, " +
                            		"SUBM_TRANSACTION_ID = ?, " +
                            		"SUBM_TRANSACTION_STAT = ?, " +
                            		"SUBM_STAT_DATE_TIME = ?, " +
                            		"RSPN_PARSE_DATE_TIME = ?, " +
                            		"WORKFLOW_STAT = ?, " +
                            		"WORKFLOW_STAT_MESSAGE = ?" +
                            		" WHERE ICS_SUBM_TRACK_ID = ?",
                                     new Object[]{icisWorkflow.getEtlCompletionDate(), icisWorkflow.getDetectionChangeCompletionDate(),
                                                     icisWorkflow.getSubmissionStatusDate(), icisWorkflow.getSubmissionTransactionId(),
                                                     icisWorkflow.getSubmissionTransactionStatus(), icisWorkflow.getSubmissionStatusDate(),
                                                     icisWorkflow.getResponseParseDate(), icisWorkflow.getWorkflowStatus(),
                                                     icisWorkflow.getWorkflowStatusMessage(), icisWorkflow.getId()},
                                     new int[]{Types.TIMESTAMP, Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR,
                                                     Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR});
        }
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

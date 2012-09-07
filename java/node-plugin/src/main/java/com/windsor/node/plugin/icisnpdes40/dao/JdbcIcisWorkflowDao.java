package com.windsor.node.plugin.icisnpdes40.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.List;
import java.util.UUID;

import javax.sql.DataSource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.dao.DataAccessException;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;

//TODO extract interface
public class JdbcIcisWorkflowDao extends JdbcDaoSupport
{
    /**
     * Get a count of 'Pending' workflows.
     */
    private static final String SQL_COUNT_PENDING_WORKFLOWS = "select count(*) from ics_subm_track where WORKFLOW_STAT = 'Pending'";
    
    /**
     * Select the 'Pending' workflow, there should only be one 'Pending' record.
     */
    private static final String SQL_PENDING_WORKFLOWS = "select * from ics_subm_track where WORKFLOW_STAT = 'Pending'";

    /**
     * Default constructor.
     * 
     * @param dataSource
     *            the {@link DataSource} where the ICS_SUBM_TRACK table is
     *            located.
     */
    public JdbcIcisWorkflowDao(DataSource dataSource) {
        setDataSource(dataSource);
    }
    
    /**
     * Returns a count of 'Pending' ICS_SUBM_TRACK records.
     * 
     * @return count of 'Pending' ICS_SUBM_TRACK records.
     */
    public int countPendingWorkflows() {
        return getJdbcTemplate().queryForInt(SQL_COUNT_PENDING_WORKFLOWS, null);
    }

    /**
     * Returns the current 'Pending' workflow record or null if one is not
     * found.
     * 
     * @return The current 'Pending' workflow record.
     */
    public IcisWorkflow findPendingWorkflow() {
        
        if (countPendingWorkflows() > 1) {
            throw new DataAccessException("Invalid workflow state, more than one 'Pending' workflow exists.") {

                private static final long serialVersionUID = 1L;

            };
        }
        
        try {
            
            List results = getJdbcTemplate().query(SQL_PENDING_WORKFLOWS, new IcisWorkflowRowMapper());
            
            if(results.size() == 1) {
                return (IcisWorkflow) results.get(0);
            }
            
            return null;
            
        } catch (EmptyResultDataAccessException e) {
            return null;
        }
    }
    
    public IcisWorkflow loadById(String id)
    {
        if(StringUtils.isEmpty(id))
        {
            throw new IllegalArgumentException("JdbcIcisWorkflowDao method loadById(String id) id cannot be null.");
        }
        //FIXME extract sql to static member
        List results = getJdbcTemplate().query("SELECT ICS_SUBM_TRACK_ID, ETL_CMPL_DATE_TIME, DET_CHANGE_CMPL_DATE_TIME, SUBM_DATE_TIME, SUBM_TRANSACTION_ID, SUBM_TRANSACTION_STAT, SUBM_STAT_DATE_TIME, RSPN_PARSE_DATE_TIME, WORKFLOW_STAT, WORKFLOW_STAT_MESSAGE from ICS_SUBM_TRACK where ICS_SUBM_TRACK_ID = ?",
                                              new Object[]{id}, new int[]{Types.VARCHAR}, new IcisWorkflowRowMapper());
        
        if(results.size() == 1) {
            return (IcisWorkflow) results.get(0);
        }
        
        return null;
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
            getJdbcTemplate().update("INSERT INTO ICS_SUBM_TRACK (ICS_SUBM_TRACK_ID, " +
            		                                                "ETL_CMPL_DATE_TIME, " +
            		                                                "DET_CHANGE_CMPL_DATE_TIME," +
            		                                                " SUBM_DATE_TIME, " +
            		                                                "SUBM_TRANSACTION_ID, " +
            		                                                "SUBM_TRANSACTION_STAT, " +
            		                                                "SUBM_STAT_DATE_TIME," + 
            		                                                "RSPN_PARSE_DATE_TIME, " +
            		                                                "WORKFLOW_STAT, " +
            		                                                "WORKFLOW_STAT_MESSAGE)"
                                                     + "VALUES (?,?,?,?,?,?,?,?,?,?)",
                                     new Object[]{newId, 
                                                    icisWorkflow.getEtlCompletionDate(), 
                                                    icisWorkflow.getDetectionChangeCompletionDate(),
                                                    icisWorkflow.getSubmissionDate(), 
                                                    icisWorkflow.getSubmissionTransactionId(),
                                                    icisWorkflow.getSubmissionTransactionStatus(), 
                                                    icisWorkflow.getSubmissionStatusDate(),
                                                    icisWorkflow.getResponseParseDate(), 
                                                    icisWorkflow.getWorkflowStatus(),
                                                    icisWorkflow.getWorkflowStatusMessage()},
                                     new int[]{ Types.VARCHAR, 
                                                Types.TIMESTAMP, 
                                                Types.TIMESTAMP, 
                                                Types.TIMESTAMP, 
                                                Types.VARCHAR, 
                                                Types.VARCHAR,
                                                Types.TIMESTAMP, 
                                                Types.TIMESTAMP, 
                                                Types.VARCHAR, 
                                                Types.VARCHAR});
        }
        else
        {
            //save
            getJdbcTemplate().update("UPDATE ICS_SUBM_TRACK SET " +
                            		                "ETL_CMPL_DATE_TIME = ?, " +
                                            		"DET_CHANGE_CMPL_DATE_TIME = ?, " +
                                            		"SUBM_DATE_TIME = ?, " +
                                            		"SUBM_TRANSACTION_ID = ?, " +
                                            		"SUBM_TRANSACTION_STAT = ?, " +
                                            		"SUBM_STAT_DATE_TIME = ?, " +
                                            		"RSPN_PARSE_DATE_TIME = ?, " +
                                            		"WORKFLOW_STAT = ?, " +
                                            		"WORKFLOW_STAT_MESSAGE = ?" +
                                            		" WHERE ICS_SUBM_TRACK_ID = ?",
                                     new Object[]{icisWorkflow.getEtlCompletionDate(), 
                                                  icisWorkflow.getDetectionChangeCompletionDate(),
                                                  icisWorkflow.getSubmissionDate(), 
                                                  icisWorkflow.getSubmissionTransactionId(),
                                                  icisWorkflow.getSubmissionTransactionStatus(), 
                                                  icisWorkflow.getSubmissionStatusDate(),
                                                  icisWorkflow.getResponseParseDate(),
                                                  icisWorkflow.getWorkflowStatus(),
                                                  icisWorkflow.getWorkflowStatusMessage(),
                                                  icisWorkflow.getId()},
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
            icisWorkflow.setSubmissionDate(rs.getDate("SUBM_DATE_TIME"));
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

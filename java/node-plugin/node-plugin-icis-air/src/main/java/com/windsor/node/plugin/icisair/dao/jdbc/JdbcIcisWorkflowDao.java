package com.windsor.node.plugin.icisair.dao.jdbc;

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
import com.windsor.node.plugin.icisair.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisair.domain.IcisWorkflow;

public class JdbcIcisWorkflowDao extends JdbcDaoSupport implements IcisWorkflowDao
{
    /**
     * Get a count of 'Pending' workflows.
     */
    private static final String SQL_COUNT_PENDING_WORKFLOWS = "select count(*) from ICA_SUBM_TRACK where WORKFLOW_STAT = 'Pending'";
    
    /**
     * Select the 'Pending' workflow, there should only be one 'Pending' record.
     */
    private static final String SQL_PENDING_WORKFLOWS = "select * from ICA_SUBM_TRACK where WORKFLOW_STAT = 'Pending'";

    private static final String SQL_LOAD_ICISWORKFLOW_BY_ID = "SELECT ICA_SUBM_TRACK_ID, ETL_CMPL_DATE_TIME, DET_CHANGE_CMPL_DATE_TIME,"
    		        + " SUBM_DATE_TIME, SUBM_TRANSACTION_ID, SUBM_TRANSACTION_STAT, SUBM_STAT_DATE_TIME, RSPN_PARSE_DATE_TIME, WORKFLOW_STAT,"
    		        + " WORKFLOW_STAT_MESSAGE from ICA_SUBM_TRACK where ICA_SUBM_TRACK_ID = ?";

    private static final String SQL_INSERT_ICISWORKFLOW = "INSERT INTO ICA_SUBM_TRACK (ICA_SUBM_TRACK_ID, " 
                    + " ETL_CMPL_DATE_TIME, "
                    + " DET_CHANGE_CMPL_DATE_TIME," 
                    + " SUBM_DATE_TIME, " 
                    + " SUBM_TRANSACTION_ID, " 
                    + " SUBM_TRANSACTION_STAT, "
                    + " SUBM_STAT_DATE_TIME," 
                    + " RSPN_PARSE_DATE_TIME, " 
                    + " WORKFLOW_STAT, " 
                    + " WORKFLOW_STAT_MESSAGE)"
                    + " VALUES (?,?,?,?,?,?,?,?,?,?)";

    private static final String SQL_UPDATE_ICISWORKFLOW = "UPDATE ICA_SUBM_TRACK SET "
                    + " ETL_CMPL_DATE_TIME = ?, "
                    + " DET_CHANGE_CMPL_DATE_TIME = ?, "
                    + " SUBM_DATE_TIME = ?, "
                    + " SUBM_TRANSACTION_ID = ?, "
                    + " SUBM_TRANSACTION_STAT = ?, "
                    + " SUBM_STAT_DATE_TIME = ?, "
                    + " RSPN_PARSE_DATE_TIME = ?, "
                    + " WORKFLOW_STAT = ?, "
                    + " WORKFLOW_STAT_MESSAGE = ?"
                    + " WHERE ICA_SUBM_TRACK_ID = ?";

    /**
     * Default constructor.
     * 
     * @param dataSource
     *            the {@link DataSource} where the ICA_SUBM_TRACK table is
     *            located.
     */
    public JdbcIcisWorkflowDao(DataSource dataSource) {
        setDataSource(dataSource);
    }
    
    @Override
    public int countPendingWorkflows() {
        return getJdbcTemplate().queryForObject(SQL_COUNT_PENDING_WORKFLOWS, null, Integer.class);
    }

    @Override
    public IcisWorkflow findPendingWorkflow() {
        
        if (countPendingWorkflows() > 1) {
            throw new DataAccessException("Invalid workflow state, more than one 'Pending' workflow exists.") {

                private static final long serialVersionUID = 1L;

            };
        }
        
        try {
            
            List<IcisWorkflow> results = getJdbcTemplate().query(SQL_PENDING_WORKFLOWS, new IcisWorkflowRowMapper());
            
            if(results.size() == 1) {
                return (IcisWorkflow) results.get(0);
            }
            
            return null;
            
        } catch (EmptyResultDataAccessException e) {
            return null;
        }
    }
    
    @Override
    public IcisWorkflow loadById(String id)
    {
        if(StringUtils.isEmpty(id))
        {
            throw new IllegalArgumentException("JdbcIcisWorkflowDao method loadById(String id) id cannot be null.");
        }
        List<IcisWorkflow> results = getJdbcTemplate().query(SQL_LOAD_ICISWORKFLOW_BY_ID ,
                                              new Object[]{id}, new int[]{Types.VARCHAR}, new IcisWorkflowRowMapper());
        
        if(results.size() == 1) {
            return (IcisWorkflow) results.get(0);
        }
        
        return null;
    }

    @Override
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
            getJdbcTemplate().update(SQL_INSERT_ICISWORKFLOW ,
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
                                                Types.DATE, 
                                                Types.DATE, 
                                                Types.DATE, 
                                                Types.VARCHAR, 
                                                Types.VARCHAR,
                                                Types.DATE, 
                                                Types.DATE, 
                                                Types.VARCHAR, 
                                                Types.VARCHAR});
        }
        else
        {
            //save
            getJdbcTemplate().update(SQL_UPDATE_ICISWORKFLOW ,
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
                                     new int[]{Types.DATE, Types.DATE, Types.DATE, Types.VARCHAR, Types.VARCHAR,
                                                     Types.DATE, Types.DATE, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR});
        }
    }

    class IcisWorkflowRowMapper implements RowMapper<IcisWorkflow>
    {
        @Override
        public IcisWorkflow mapRow(ResultSet rs, int rowNum) throws SQLException
        {
            IcisWorkflow icisWorkflow = new IcisWorkflow();
            icisWorkflow.setId(rs.getString("ICA_SUBM_TRACK_ID"));
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

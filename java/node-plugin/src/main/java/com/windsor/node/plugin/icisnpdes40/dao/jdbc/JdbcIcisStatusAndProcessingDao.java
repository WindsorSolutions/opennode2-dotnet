package com.windsor.node.plugin.icisnpdes40.dao.jdbc;

import java.sql.Types;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import javax.sql.DataSource;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.SqlParameter;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import org.springframework.jdbc.object.StoredProcedure;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao;
import com.windsor.node.plugin.icisnpdes40.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes40.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes40.results.IcisStatusResult;

public class JdbcIcisStatusAndProcessingDao extends JdbcDaoSupport implements IcisStatusAndProcessingDao
{
    private static final String SQL_COUNT_PENDING_WORKFLOWS = "SELECT count(*) from ICS_SUBM_TRACK where WORKFLOW_STAT = ?";
    private static final String SQL_LOAD_PENDING_WORKFLOW = "SELECT ICS_SUBM_TRACK_ID where WORKFLOW_STAT = ?";
    private static final String SQL_INSERT_ICIS_STATUS_RESULT = "INSERT INTO ICS_SUBM_RESULTS (ICS_SUBM_RESULTS_ID,"
                    + " TRANSACTION_TYPE, SUBM_TYPE_NAME, PRMT_IDENT, PRMT_IDENT_2, PRMT_FEATR_IDENT, RESULT_CODE, RESULT_TYPE_CODE,"
                    + " RESULT_DESC, CREATE_DATE_TIME) " + " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

    private IcisWorkflowDao icisWorkflowDao;

    public JdbcIcisStatusAndProcessingDao(IcisWorkflowDao icisWorkflowDao, DataSource dataSource)
    {
        super();
        this.icisWorkflowDao = icisWorkflowDao;
        setDataSource(dataSource);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#countPendingWorkflows()
     */
    @Override
    public int countPendingWorkflows()
    {
        return getJdbcTemplate().queryForInt(SQL_COUNT_PENDING_WORKFLOWS ,
                                             new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR});
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#loadPendingWorkflow()
     */
    @Override
    public IcisWorkflow loadPendingWorkflow()
    {
        String id = (String)getJdbcTemplate().queryForObject(SQL_LOAD_PENDING_WORKFLOW ,
                                     new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR}, String.class);
        return getIcisWorkflowDao().loadById(id);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#saveIcisStatusResults(java.util.List, java.util.List)
     */
    @Override
    public void saveIcisStatusResults(List<IcisStatusResult> accepted, List<IcisStatusResult> rejected)
    {
        List<IcisStatusResult> fullList = new ArrayList<IcisStatusResult>();
        fullList.addAll(accepted);
        fullList.addAll(rejected);
        for(int i = 0; i < fullList.size(); i++)
        {
            IcisStatusResult currentResult = fullList.get(i);
            String newId = UUID.randomUUID().toString();
            getJdbcTemplate().update(SQL_INSERT_ICIS_STATUS_RESULT ,
                                     new Object[]{newId,
                                                    //currentResult.getSubmissionDate(), 
                                                    //currentResult.getProcessedDate(),
                                                    currentResult.getSubmissionTransactionTypeCode(), 
                                                    currentResult.getSubmissionTypeName(),
                                                    null,//PRMT_IDENT_2
                                                    currentResult.getPermitIdentifier(), 
                                                    currentResult.getPermittedFeatureIdentifier(),
                                                    currentResult.getErrorCode(),
                                                    currentResult.getErrorTypeCode(),
                                                    currentResult.getErrorDescription(),
                                                    new Date()},
                                     new int[]{ Types.VARCHAR, 
                                                //Types.DATE,
                                                //Types.DATE,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.VARCHAR,
                                                Types.DATE});
        }
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#runCleanupStoredProc(java.lang.String, java.lang.String)
     */
    @Override
    public void runCleanupStoredProc(String procName, String storedProcedureTransactionIdArgument)
    {
        //Run proc, throw any Exceptions right up the chain
        IcisCleanupStoredProc proc = new IcisCleanupStoredProc(procName, getJdbcTemplate());
        proc.execute(storedProcedureTransactionIdArgument);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#getIcisWorkflowDao()
     */
    @Override
    public IcisWorkflowDao getIcisWorkflowDao()
    {
        return icisWorkflowDao;
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.dao.IcisStatusAndProcessingDao#setIcisWorkflowDao(com.windsor.node.plugin.icisnpdes40.dao.IcisWorkflowDao)
     */
    @Override
    public void setIcisWorkflowDao(IcisWorkflowDao icisWorkflowDao)
    {
        this.icisWorkflowDao = icisWorkflowDao;
    }

    class IcisCleanupStoredProc extends StoredProcedure
    {
        IcisCleanupStoredProc(String procName, JdbcTemplate jdbcTemplate)
        {
            super(jdbcTemplate, procName);
            declareParameter(new SqlParameter("transactionId", Types.VARCHAR));
            compile();
        }

        public void execute(String storedProcedureTransactionIdArgument)
        {
            Map<String, Object> params = new HashMap<String, Object>();
            params.put("transactionId", storedProcedureTransactionIdArgument);
            super.execute(params);
        }
    }
}

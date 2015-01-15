package com.windsor.node.plugin.icisnpdes.dao.jdbc;

import java.sql.Types;
import java.util.HashMap;
import java.util.Map;

import javax.persistence.EntityManager;
import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.SqlParameter;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import org.springframework.jdbc.object.StoredProcedure;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao;
import com.windsor.node.plugin.icisnpdes.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisnpdes.domain.IcisWorkflow;
import com.windsor.node.plugin.icisnpdes.generated.SubmissionResult;
import com.windsor.node.plugin.icisnpdes.generated.SubmissionResultList;

public class JdbcIcisStatusAndProcessingDao extends JdbcDaoSupport implements IcisStatusAndProcessingDao
{
    private static final String SQL_COUNT_PENDING_WORKFLOWS = "SELECT count(*) from ICS_SUBM_TRACK where WORKFLOW_STAT = ?";
    private static final String SQL_LOAD_PENDING_WORKFLOW = "SELECT ICS_SUBM_TRACK_ID from ICS_SUBM_TRACK where WORKFLOW_STAT = ?";

    private IcisWorkflowDao icisWorkflowDao;

    public JdbcIcisStatusAndProcessingDao(IcisWorkflowDao icisWorkflowDao, DataSource dataSource)
    {
        super();
        this.icisWorkflowDao = icisWorkflowDao;
        setDataSource(dataSource);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#countPendingWorkflows()
     */
    @Override
    public int countPendingWorkflows()
    {
        return getJdbcTemplate().queryForObject(SQL_COUNT_PENDING_WORKFLOWS ,
                                             new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR}, Integer.class);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#loadPendingWorkflow()
     */
    @Override
    public IcisWorkflow loadPendingWorkflow()
    {
        String id = (String)getJdbcTemplate().queryForObject(SQL_LOAD_PENDING_WORKFLOW ,
                                     new Object[]{CommonTransactionStatusCode.Pending}, new int[]{Types.VARCHAR}, String.class);
        return getIcisWorkflowDao().loadById(id);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#saveIcisStatusResults(java.util.List, java.util.List)
     */
    @Override
    public void saveIcisStatusResults(SubmissionResultList accepted, SubmissionResultList rejected, EntityManager em)
    {
        SubmissionResult entity;

        // FIXME - The transaction demarcation should not be here....should be in the service
        em.getTransaction().begin();

        for(int i = 0; accepted != null && accepted.getSubmissionResult() != null  && i < accepted.getSubmissionResult().size(); i++)
        {
            entity = accepted.getSubmissionResult().get(i);
            em.persist(entity);
        }
        for(int i = 0; rejected != null && rejected.getSubmissionResult() != null  && i < rejected.getSubmissionResult().size(); i++)
        {
            entity = rejected.getSubmissionResult().get(i);
            em.persist(entity);
        }

        // FIXME - The transaction demarcation should not be here....should be in the service
        em.getTransaction().commit();
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#runCleanupStoredProc(java.lang.String, java.lang.String)
     */
    @Override
    public void runCleanupStoredProc(String procName, String storedProcedureTransactionIdArgument)
    {
        //Run proc, throw any Exceptions right up the chain
        IcisCleanupStoredProc proc = new IcisCleanupStoredProc(procName, getJdbcTemplate());
        proc.execute(storedProcedureTransactionIdArgument);
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#getIcisWorkflowDao()
     */
    @Override
    public IcisWorkflowDao getIcisWorkflowDao()
    {
        return icisWorkflowDao;
    }

    /* (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes.dao.IcisStatusAndProcessingDao#setIcisWorkflowDao(com.windsor.node.plugin.icisnpdes.dao.IcisWorkflowDao)
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

package com.windsor.node.plugin.wqx.dao;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.Query;
import javax.persistence.TypedQuery;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.wqx.domain.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.SubmissionHistory;

/**
 *
 * TODO Change JPQL to use Criteria API.
 */
public class SubmissionHistoryDaoJpaImpl implements SubmissionHistoryDao {

    private final EntityManager em;

    private final WqxDao wqxDao;

    public SubmissionHistoryDaoJpaImpl(EntityManager em) {
        this.em = em;
        this.wqxDao = new WqxDaoJpaImpl(em);
    }

    @Override
    public SubmissionHistory createSubmissionHistoryRecord(String id, String orgId, String submissionType, String localTransactionId, CommonTransactionStatusCode status) {

        OrganizationDataType org = wqxDao.findOrganizationByOrgId(orgId);

        SubmissionHistory record = new SubmissionHistory();
        record.setId(id);
        record.setParentId(org.getDbid());
        record.setOrganizationId(orgId);
        record.setSubmissionType(submissionType);
        record.setLocalTransactionId(localTransactionId);
        record.setCdxProcessingStatus(status.name());
        record.setScheduleRunDateTime(new Date());
        record.setWqxDateTime(new Date());
        em.persist(record);
        return record;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean pendingTransactionsExist(String orgId, String operation) {

        String sql =
        		"select " +
        		"  count(x) " +
        		"from" +
        		"  com.windsor.node.plugin.wqx.domain.SubmissionHistory x " +
        		"where " +
        		"  (x.cdxProcessingStatus = :pending or x.cdxProcessingStatus = :processing) " +
        		"   and x.submissionType = :operation " +
        		"   and x.parentId in (select" +
        		"                         o.dbid " +
        		"                      from " +
        		"                         OrganizationDataType o " +
        		"                      where " +
        		"                         o.organizationDescription.organizationIdentifier = :orgId)";

        TypedQuery<Long> query = em.createQuery(sql, Long.class);
        query.setParameter("pending", CommonTransactionStatusCode.Pending.toString());
        query.setParameter("processing", CommonTransactionStatusCode.Processing.toString());
        query.setParameter("operation", operation);
        query.setParameter("orgId", orgId);

        Long result = query.getSingleResult();

        return (result > 0);
    }

    @Override
    public SubmissionHistory findLatestCompleted(String orgId, String operationType) {

        String sql =
                "select " +
                "  x " +
                "from" +
                "  com.windsor.node.plugin.wqx.domain.SubmissionHistory x " +
                "where " +
                "  x.cdxProcessingStatus = :status " +
                "   and x.submissionType = :operation " +
                "   and x.parentId in (select" +
                "                         o.dbid " +
                "                      from " +
                "                         OrganizationDataType o " +
                "                      where " +
                "                         o.organizationDescription.organizationIdentifier = :orgId)" +
                "order by x.wqxDateTime desc";

        Query query = em.createQuery(sql);
        query.setParameter("status", CommonTransactionStatusCode.Completed.toString());
        query.setParameter("operation", operationType);
        query.setParameter("orgId", orgId);

        query.setMaxResults(1);

        try {
            return (SubmissionHistory) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    @Override
    public void resetSubmissionStatusByOrgId(String orgId) {

        String sql = "update " +
        		"SubmissionHistory x " +
        		" set x.cdxProcessingStatus = 'Reset', " +
        		" x.scheduleRunDateTime = :now " +
        		"where (x.cdxProcessingStatus = :pending or x.cdxProcessingStatus = :processing) " +
                "   and x.parentId in (select" +
                "                         o.dbid " +
                "                      from " +
                "                         OrganizationDataType o " +
                "                      where " +
                "                         o.organizationDescription.organizationIdentifier = :orgId)";

        Query query = em.createQuery(sql);

        query.setParameter("now", new Date());
        query.setParameter("pending", CommonTransactionStatusCode.Pending.toString());
        query.setParameter("processing", CommonTransactionStatusCode.Processing.toString());
        query.setParameter("orgId", orgId);
        query.executeUpdate();
    }

    @Override
    public List<SubmissionHistory> getPendingTransactionsByOrgId(String orgId) {

        String sql =
                "select " +
                "  x " +
                "from" +
                "  SubmissionHistory x " +
                "where " +
                "  (x.cdxProcessingStatus = :pending or x.cdxProcessingStatus = :processing) " +
                "   and x.parentId in (select" +
                "                         o.dbid " +
                "                      from " +
                "                         OrganizationDataType o " +
                "                      where " +
                "                         o.organizationDescription.organizationIdentifier = :orgId)" +
                "order by x.wqxDateTime desc";

        Query query = em.createQuery(sql);
        query.setParameter("pending", CommonTransactionStatusCode.Pending.toString());
        query.setParameter("processing", CommonTransactionStatusCode.Processing.toString());
        query.setParameter("orgId", orgId);

        return query.getResultList();
    }

    @Override
    public void updateStatus(SubmissionHistory history, CommonTransactionStatusCode status) {
        history.setCdxProcessingStatus(status.toString());
        em.merge(history);
    }
}

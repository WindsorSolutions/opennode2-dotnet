package com.windsor.node.plugin.rcra54.dao;

import java.util.Arrays;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.StoredProcedureQuery;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.rcra54.domain.FinancialAssuranceSubmissionDataType;
import com.windsor.node.plugin.rcra54.domain.GeographicInformationSubmissionDataType;
import com.windsor.node.plugin.rcra54.domain.HazardousWasteCMESubmissionDataType;
import com.windsor.node.plugin.rcra54.domain.HazardousWasteCorrectiveActionDataType;
import com.windsor.node.plugin.rcra54.domain.HazardousWasteHandlerSubmissionDataType;
import com.windsor.node.plugin.rcra54.domain.HazardousWastePermitDataType;
import com.windsor.node.plugin.rcra54.domain.OperationType;
import com.windsor.node.plugin.rcra54.domain.SubmissionHistory;

public class RcraDaoJpaImpl extends AbstractDaoJpaImpl implements RcraDao {

	private static final List<String> OUTSTANDING_STATUSES = Arrays.asList(
			CommonTransactionStatusCode.Pending.toString(), 
			CommonTransactionStatusCode.Processing.toString());
	private static final String STATUSES_PARAM = "pending";
	private static final String SUBMISSION_HISTORY_QUERY = String.format(
            "select "
            + "  x " 
            + "from"
            + "  SubmissionHistory x "
            + "where "
            + "  x.processingStatus in (:%s) "
            + "order by x.scheduleRunDate desc", 
            STATUSES_PARAM);
	
	private TransactionDao transactionDao;
	
	public RcraDaoJpaImpl(EntityManager entityManager, TransactionDao transactionDao) {
		super(entityManager);
		this.transactionDao = transactionDao;
	}

	@Override
	public HazardousWasteCMESubmissionDataType getCmeRoot() {
		return getEntityManager().createQuery("select x from HazardousWasteCMESubmissionDataType x", HazardousWasteCMESubmissionDataType.class)
				.getSingleResult();
	}

	@Override
	public HazardousWasteCorrectiveActionDataType getCorrectiveActionRoot() {
		return getEntityManager().createQuery("select x from HazardousWasteCorrectiveActionDataType x", HazardousWasteCorrectiveActionDataType.class)
				.getSingleResult();
	}

	@Override
	public FinancialAssuranceSubmissionDataType getFinancialAssuranceRoot() {
		return getEntityManager().createQuery("select x from FinancialAssuranceSubmissionDataType x", FinancialAssuranceSubmissionDataType.class)
				.getSingleResult();
	}

	@Override
	public GeographicInformationSubmissionDataType getGisRoot() {
		return getEntityManager().createQuery("select x from GeographicInformationSubmissionDataType x", GeographicInformationSubmissionDataType.class)
				.getSingleResult();
	}

	@Override
	public HazardousWasteHandlerSubmissionDataType getHandlerRoot() {
		return getEntityManager().createQuery("select x from HazardousWasteHandlerSubmissionDataType x", HazardousWasteHandlerSubmissionDataType.class)
				.getSingleResult();
	}

	@Override
	public HazardousWastePermitDataType getPermitRoot() {
		return getEntityManager().createQuery("select x from HazardousWastePermitDataType x", HazardousWastePermitDataType.class)
				.getSingleResult();
	}
	
	@Override
	public void saveHistory(NodeTransaction transaction, ProcessContentResult result, OperationType operationType) {
		EntityTransaction tx = getEntityManager().getTransaction();
		try {
			tx.begin();
			SubmissionHistory history = new SubmissionHistory();
			history.setScheduleRunDate(new Date());
	    	history.setTransactionId(transaction.getId());
	    	history.setProcessingStatus(result.getStatus().name());
	    	history.setSubmissionType(operationType.getCode());
	    	getEntityManager().persist(history);
	    	tx.commit();
		} catch (Exception e) {
			tx.rollback();
			throw new RuntimeException("Error saving submission history", e);
		}
	}
	
	@Override
	public void updateSubmissionHistoryStatus(SubmissionHistory submissionHistory, CommonTransactionStatusCode status) {
		EntityTransaction tx = getEntityManager().getTransaction();
        try {
			tx.begin();
	        submissionHistory = getEntityManager().merge(submissionHistory);
	        CommonTransactionStatusCode remoteStatus = null;
	        switch (status) {
	            case Completed:
	            case Processed:
	                remoteStatus = CommonTransactionStatusCode.Completed;
	                break;
	            case Failed:
	            	remoteStatus = CommonTransactionStatusCode.Failed;
	                break;
	            default:
	                throw new RuntimeException(String.format("Uknown remote status \"%s\".", remoteStatus));
	        }
	        submissionHistory.setProcessingStatus(remoteStatus.toString());
	        transactionDao.updateStatus(submissionHistory.getTransactionId(), remoteStatus);
	        getEntityManager().getTransaction().commit();
        } catch (Exception e) {
        	tx.rollback();
        	throw new RuntimeException("Error updating the submission history status", e);
        }
	}
	

	@Override
	public void callStoredProcedure(String storedProcedure) {
		EntityTransaction tx = getEntityManager().getTransaction();
		try {
			tx.begin();
			StoredProcedureQuery query = getEntityManager().createStoredProcedureQuery(storedProcedure);
	        query.execute();
	        tx.commit();
		} catch (Exception e) {
			tx.rollback();
			throw new RuntimeException("Error calling stored procedure '" + storedProcedure + "'", e);
		}
	}

	@Override
	public List<SubmissionHistory> getOutstandingSubmissions() {
        return getEntityManager()
        		.createQuery(SUBMISSION_HISTORY_QUERY, SubmissionHistory.class)
        		.setParameter(STATUSES_PARAM, OUTSTANDING_STATUSES)
        		.getResultList();
	}

}

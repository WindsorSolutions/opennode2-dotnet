package com.windsor.node.plugin.rcra54.domain;

import java.util.Date;
import java.util.UUID;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.PrePersist;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
@Table(name = "RCRA_SUBMISSIONHISTORY")
public class SubmissionHistory {

	@Id
	@Column(name = "SUBMISSIONHISTORY_ID", nullable = false)
	private String dbid;
	
	@Column(name = "SCHEDULERUNDATE", nullable = false)
	@Temporal(TemporalType.TIMESTAMP)
	private Date scheduleRunDate;
	
	@Column(name = "TRANSACTIONID", nullable = false)
	private String transactionId;
	
	@Column(name = "PROCESSINGSTATUS", nullable = false)
	private String processingStatus;
	
	@Column(name = "SUBMISSIONTYPE", nullable = false)
	private String submissionType;
	
	public SubmissionHistory() {
		super();
	}

	public String getDbid() {
		return dbid;
	}

	public void setDbid(String dbid) {
		this.dbid = dbid;
	}

	public Date getScheduleRunDate() {
		return scheduleRunDate;
	}

	public void setScheduleRunDate(Date scheduleRunDate) {
		this.scheduleRunDate = scheduleRunDate;
	}

	public String getTransactionId() {
		return transactionId;
	}

	public void setTransactionId(String transactionId) {
		this.transactionId = transactionId;
	}

	public String getProcessingStatus() {
		return processingStatus;
	}

	public void setProcessingStatus(String processingStatus) {
		this.processingStatus = processingStatus;
	}

	public String getSubmissionType() {
		return submissionType;
	}

	public void setSubmissionType(String submissionType) {
		this.submissionType = submissionType;
	}
	
	@PrePersist
	public void prePersist() {
		if (dbid == null) {
			dbid = UUID.randomUUID().toString();
		}
	}
	
}

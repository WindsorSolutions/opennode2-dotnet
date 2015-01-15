package com.windsor.node.plugin.icisnpdes.domain;

import java.util.Date;
import java.util.UUID;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.PrePersist;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

/**
 * Provides the created date field, which is not present in the XML document,
 * but is a required value in the database. Ensures that the created date and
 * the DB PK (UUID) are set.
 *
 */
@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractSubmissionResult {

	/**
	 * Date the submission result was created.
	 */
	@XmlTransient
	protected Date createdDate;

	/**
	 * Returns the DB PK.
	 *
	 * @return the DB PK
	 */
	@Transient
	public abstract String getDbid();

	/**
	 * Sets the DB PK.
	 *
	 * @param dbid
	 *            DB PK
	 */
	public abstract void setDbid(final String dbid);

	/**
	 * Returns the date the submission result was created.
	 *
	 * @return the date the submission result was created
	 */
	@Column(name = "CREATED_DATE_TIME")
	@Temporal(TemporalType.DATE)
	public Date getCreatedDate() {
		return createdDate;
	}

	/**
	 * Sets the date the submission result was created.
	 *
	 * @param createdDate
	 *            the date the submission result was created
	 */
	public void setCreatedDate(final Date createdDate) {
		this.createdDate = createdDate;
	}

	/**
	 * Ensures that the created date and DB PK are set before persisting.
	 */
	@PrePersist
	public void handlePrePersist() {
		if (getCreatedDate() == null) {
			setCreatedDate(new Date());
		}
		if (getDbid() == null) {
			setDbid(UUID.randomUUID().toString());
		}
	}

}

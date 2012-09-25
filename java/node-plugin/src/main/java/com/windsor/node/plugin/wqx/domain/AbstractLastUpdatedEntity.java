package com.windsor.node.plugin.wqx.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

/**
 * Superclass for tables which can be queried using a last updated timestamp
 * column.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractLastUpdatedEntity implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	/**
	 * The last time the data was updated.
	 */
	@XmlTransient
	private Date updatedDate;

	/**
	 * Returns the last time the data was updated.
	 *
	 * @return the last time the data was updated
	 */
	@Column(name = "WQXUPDATEDATE", columnDefinition = "datetime")
	@Temporal(TemporalType.TIMESTAMP)
	public Date getUpdatedDate() {
		return updatedDate;
	}

	/**
	 * Sets the last time the data was updated.
	 *
	 * @param updatedDate
	 *            the last time the data was updated
	 */
	public void setUpdatedDate(final Date updatedDate) {
		this.updatedDate = updatedDate;
	}

}

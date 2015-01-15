package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractHasComplianceMonitoring implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String complianceMonitoringId;

	@Column(name = "ICS_CMPL_MON_ID")
	public String getComplianceMonitoringId() {
		return complianceMonitoringId;
	}

	public void setComplianceMonitoringId(final String limitSetId) {
		this.complianceMonitoringId = limitSetId;
	}

}

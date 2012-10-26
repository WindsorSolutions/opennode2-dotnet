package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractHasDischargeMonitoringReport implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String dischargeMonitoringReportId;

	@Column(name = "ICS_DSCH_MON_REP_ID")
	public String getDischargeMonitoringReportId() {
		return dischargeMonitoringReportId;
	}

	public void setDischargeMonitoringReportId(final String limitSetId) {
		this.dischargeMonitoringReportId = limitSetId;
	}

}

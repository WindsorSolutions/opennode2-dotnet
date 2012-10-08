package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

/**
 * Provides column names to link for use in Hibernate schema validation. Without these
 * mappings, Hibernate will throw a "Unable to find column with logical name"
 * error for the mapping of the referenced column names.
 *
 */
@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public class AbstractComplianceMonitoringAndDmrProgramReportLinkage {

	@XmlTransient
	protected String complianceMonitoringLinkageId;

	@XmlTransient
	protected String dmrProgramReportLinkageId;

	@Column(name = "ICS_CMPL_MON_LNK_ID")
	public String getComplianceMonitoringLinkageId() {
		return complianceMonitoringLinkageId;
	}

	public void setComplianceMonitoringLinkageId(final String complianceMonitoringLinkageId) {
		this.complianceMonitoringLinkageId = complianceMonitoringLinkageId;
	}

	@Column(name = "ICS_DMR_PROG_REP_LNK_ID")
	public String getDmrProgramReportLinkageId() {
		return dmrProgramReportLinkageId;
	}

	public void setDmrProgramReportLinkageId(final String dmrProgramReportLinkageId) {
		this.dmrProgramReportLinkageId = dmrProgramReportLinkageId;
	}


}

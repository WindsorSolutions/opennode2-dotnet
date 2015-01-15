package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractRemovalCredits implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String localLimitsProgramReportId;

	@XmlTransient
	private String pretreatmentInspectionId;

	@XmlTransient
	private String pretreatmentPerformanceSummaryId;

	@Column(name = "ICS_LOC_LMTS_PROG_REP_ID")
	public String getLocalLimitsProgramReportId() {
		return localLimitsProgramReportId;
	}

	public void setLocalLimitsProgramReportId(final String limitSetId) {
		this.localLimitsProgramReportId = limitSetId;
	}

	@Column(name = "ICS_PRETR_INSP_ID")
	public String getPretreatmentInspectionId() {
		return pretreatmentInspectionId;
	}

	public void setPretreatmentInspectionId(final String pretreatmentInspectionId) {
		this.pretreatmentInspectionId = pretreatmentInspectionId;
	}

	@Column(name = "ICS_PRETR_PERF_SUMM_ID")
	public String getPretreatmentPerformanceSummaryId() {
		return pretreatmentPerformanceSummaryId;
	}

	public void setPretreatmentPerformanceSummaryId(final String pretreatmentPerformanceSummaryId) {
		this.pretreatmentPerformanceSummaryId = pretreatmentPerformanceSummaryId;
	}

}

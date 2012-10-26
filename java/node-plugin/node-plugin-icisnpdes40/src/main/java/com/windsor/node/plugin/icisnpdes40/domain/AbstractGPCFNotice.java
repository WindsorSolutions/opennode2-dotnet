package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractGPCFNotice implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String swConstructionPermitId;

	@XmlTransient
	private String swIndustrialPermitId;

	@Column(name = "ICS_SW_CNST_PRMT_ID")
	public String getSwConstructionPermitId() {
		return swConstructionPermitId;
	}

	public void setSwConstructionPermitId(final String swConstructionPermitId) {
		this.swConstructionPermitId = swConstructionPermitId;
	}

	@Column(name = "ICS_SW_INDST_PRMT_ID")
	public String getSwIndustrialPermitId() {
		return swIndustrialPermitId;
	}

	public void setSwIndustrialPermitId(final String swIndustrialPermitId) {
		this.swIndustrialPermitId = swIndustrialPermitId;
	}



}

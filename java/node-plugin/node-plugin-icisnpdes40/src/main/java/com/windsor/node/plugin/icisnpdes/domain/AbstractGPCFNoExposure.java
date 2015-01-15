package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractGPCFNoExposure implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String swIndustrialPermitId;

	@Column(name = "ICS_SW_INDST_PRMT_ID")
	public String getSwIndustrialPermitId() {
		return swIndustrialPermitId;
	}

	public void setSwIndustrialPermitId(final String swIndustrialPermitId) {
		this.swIndustrialPermitId = swIndustrialPermitId;
	}



}

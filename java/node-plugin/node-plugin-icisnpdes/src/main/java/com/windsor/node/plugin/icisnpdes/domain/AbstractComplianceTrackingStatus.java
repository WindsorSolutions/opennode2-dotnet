package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractComplianceTrackingStatus implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String basicPermitId;

	@XmlTransient
	private String generalPermitId;

	@Column(name = "ICS_BASIC_PRMT_ID")
	public String getBasicPermitId() {
		return basicPermitId;
	}

	public void setBasicPermitId(final String basicPermitId) {
		this.basicPermitId = basicPermitId;
	}

	@Column(name = "ICS_GNRL_PRMT_ID")
	public String getGeneralPermitId() {
		return generalPermitId;
	}

	public void setGeneralPermitId(final String generalPermitId) {
		this.generalPermitId = generalPermitId;
	}

}

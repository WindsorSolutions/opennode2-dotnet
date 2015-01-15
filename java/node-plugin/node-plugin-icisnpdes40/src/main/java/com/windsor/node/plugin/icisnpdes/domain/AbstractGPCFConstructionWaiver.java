package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractGPCFConstructionWaiver implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String swms4SmallPermitId;

	@Column(name = "ICS_SWMS_4_SMALL_PRMT_ID")
	public String getSwms4SmallPermitId() {
		return swms4SmallPermitId;
	}

	public void setSwms4SmallPermitId(final String sWMS4SmallPermitId) {
		this.swms4SmallPermitId = sWMS4SmallPermitId;
	}



}

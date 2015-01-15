package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractProjectType implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String stormWaterUnpermittedConstructionInspectionId;

	@Column(name = "ICS_SW_UNPRMT_CNST_INSP_ID")
	public String getStormWaterUnpermittedConstructionInspectionId() {
		return stormWaterUnpermittedConstructionInspectionId;
	}

	public void setStormWaterUnpermittedConstructionInspectionId(final String limitSetId) {
		this.stormWaterUnpermittedConstructionInspectionId = limitSetId;
	}

}

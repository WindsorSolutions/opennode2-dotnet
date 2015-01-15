package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractSWConstructionInspection implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;
	
	@XmlTransient
	private String stormWaterConstructionInspectionId;
	
	@XmlTransient
	private String stormWaterNonConstructionInspectionId;
	
	@XmlTransient
	private String stormWaterConstructionNonConstructionInspectionsId;

	@Column(name = "ICS_SW_CNST_INSP_ID")
	public String getStormWaterConstructionInspectionId() {
		return stormWaterConstructionInspectionId;
	}

	public void setStormWaterConstructionInspectionId(String stormWaterConstructionInspectionId) {
		this.stormWaterConstructionInspectionId = stormWaterConstructionInspectionId;
	}

	@Column(name = "ICS_SW_NON_CNST_INSP_ID")
	public String getStormWaterNonConstructionInspectionId() {
		return stormWaterNonConstructionInspectionId;
	}

	public void setStormWaterNonConstructionInspectionId(
			String stormWaterUnpermittedConstructionInspectionId) {
		this.stormWaterNonConstructionInspectionId = stormWaterUnpermittedConstructionInspectionId;
	}

	@Column(name = "ICS_SW_CNST_NON_CNST_INSP_ID")
	public String getStormWaterConstructionNonConstructionInspectionsId() {
		return stormWaterConstructionNonConstructionInspectionsId;
	}

	public void setStormWaterConstructionNonConstructionInspectionsId(
			String stormWaterConstructionNonConstructionInspectionsId) {
		this.stormWaterConstructionNonConstructionInspectionsId = stormWaterConstructionNonConstructionInspectionsId;
	}

}

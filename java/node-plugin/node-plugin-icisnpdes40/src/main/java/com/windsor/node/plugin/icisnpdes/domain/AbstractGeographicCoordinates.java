package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractGeographicCoordinates implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String facilityId;

	@XmlTransient
	private String unpermittedFacilityId;

	@XmlTransient
	private String permittedFeatureId;

	@Column(name = "ICS_FAC_ID")
	public String getFacilityId() {
		return facilityId;
	}

	public void setFacilityId(final String limitSetId) {
		this.facilityId = limitSetId;
	}

	@Column(name = "ICS_PRMT_FEATR_ID")
	public String getPermittedFeatureId() {
		return permittedFeatureId;
	}

	public void setPermittedFeatureId(final String permittedFeatureId) {
		this.permittedFeatureId = permittedFeatureId;
	}

	@Column(name = "ICS_UNPRMT_FAC_ID")
	public String getUnpermittedFacilityId() {
		return unpermittedFacilityId;
	}

	public void setUnpermittedFacilityId(final String unpermittedFeatureId) {
		this.unpermittedFacilityId = unpermittedFeatureId;
	}

}

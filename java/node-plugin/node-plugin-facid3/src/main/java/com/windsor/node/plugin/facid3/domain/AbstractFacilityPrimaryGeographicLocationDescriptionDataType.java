package com.windsor.node.plugin.facid3.domain;

import javax.persistence.Embedded;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractFacilityPrimaryGeographicLocationDescriptionDataType {

	@XmlTransient
	private GeographicLocation geographicLocation;

	@Embedded
	public GeographicLocation getGeographicLocation() {
		return geographicLocation;
	}

	public void setGeographicLocation(GeographicLocation geographicLocation) {
		this.geographicLocation = geographicLocation;
	}

}

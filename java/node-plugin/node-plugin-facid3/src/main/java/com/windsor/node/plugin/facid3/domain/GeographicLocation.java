package com.windsor.node.plugin.facid3.domain;

import javax.persistence.Column;
import javax.persistence.Embeddable;

@Embeddable
public class GeographicLocation {

	private Double latitude;

	private Double longitude;

	@Column(name = "LATITUDE", insertable = false, updatable = false)
	public Double getLatitude() {
		return latitude;
	}

	public void setLatitude(Double latitude) {
		this.latitude = latitude;
	}

	@Column(name = "LONGITUDE", insertable = false, updatable = false)
	public Double getLongitude() {
		return longitude;
	}

	public void setLongitude(Double longitude) {
		this.longitude = longitude;
	}

}

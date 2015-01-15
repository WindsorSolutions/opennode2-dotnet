package com.windsor.node.plugin.icisnpdes40.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractScheduleEventViolationKeyElements implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String scheduleEventViolationKeyElementsId;

	@Column(name = "ICS_SCHD_EVT_VIOL_ID")
	public String getScheduleEventViolationKeyElementsId() {
		return scheduleEventViolationKeyElementsId;
	}

	public void setScheduleEventViolationKeyElementsId(final String limitSetId) {
		this.scheduleEventViolationKeyElementsId = limitSetId;
	}

}

package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractLimitSetStatus implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String limitSetId;

	@Column(name = "ICS_LMT_SET_ID")
	public String getLimitSetId() {
		return limitSetId;
	}

	public void setLimitSetId(final String limitSetId) {
		this.limitSetId = limitSetId;
	}

}

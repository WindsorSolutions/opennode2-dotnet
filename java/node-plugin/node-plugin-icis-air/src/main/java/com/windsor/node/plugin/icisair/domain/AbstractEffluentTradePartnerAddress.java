package com.windsor.node.plugin.icisair.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractEffluentTradePartnerAddress implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	private String effluentTradePartnerId;

	@Column(name = "ICA_EFFLU_TRADE_PRTNER_ID")
	public String getEffluentTradePartnerId() {
		return effluentTradePartnerId;
	}

	public void setEffluentTradePartnerId(final String limitSetId) {
		this.effluentTradePartnerId = limitSetId;
	}

}

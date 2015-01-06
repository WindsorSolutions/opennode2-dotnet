package com.windsor.node.plugin.icisair.domain;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlTransient;

import com.windsor.node.plugin.icisair.domain.generated.SingleEventKeyElements;

/**
 * Provides column names to link for use in Hibernate schema validation. Without these
 * mappings, Hibernate will throw a "Unable to find column with logical name"
 * error for the mapping of the referenced column names.
 *
 */
@MappedSuperclass
public class AbstractEnhancedSingleEventKeyElements extends SingleEventKeyElements {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	@XmlTransient
	protected String enforcementActionViolationLinkageId;

	@XmlTransient
	protected String finalOrderViolationLinkageId;

	@Column(name = "ICA_ENFRC_ACTN_VIOL_LNK_ID")
	public String getEnforcementActionViolationLinkageId() {
		return enforcementActionViolationLinkageId;
	}

	public void setEnforcementActionViolationLinkageId(final String enforcementActionViolationLinkageId) {
		this.enforcementActionViolationLinkageId = enforcementActionViolationLinkageId;
	}

	@Column(name = "ICA_FINAL_ORDER_VIOL_LNK_ID")
	public String getFinalOrderViolationLinkageId() {
		return finalOrderViolationLinkageId;
	}

	public void setFinalOrderViolationLinkageId(final String finalOrderViolationLinkageId) {
		this.finalOrderViolationLinkageId = finalOrderViolationLinkageId;
	}


}

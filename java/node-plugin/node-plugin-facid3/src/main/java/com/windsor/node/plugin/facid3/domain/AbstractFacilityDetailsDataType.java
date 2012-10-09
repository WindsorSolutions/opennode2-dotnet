package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;

import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDetailsDataType;

/**
 * Abstract base class for {@link FacilityDetailsDataType}.
 *
 */
@MappedSuperclass
public abstract class AbstractFacilityDetailsDataType extends AbstractIndustryCodeInfoDataType {

	/**
	 * Returns the list of alternative names.
	 *
	 * @return the list of alternative names
	 */
	@Transient
	public abstract AlternativeNameListDataType getAlternativeNameList();

	/**
	 * Sets the list of alternative names.
	 *
	 * @param alternativeNameList
	 *            the list of alternative names
	 */
	public abstract void setAlternativeNameList(
			final AlternativeNameListDataType alternativeNameList);

	/**
	 * Nulls out @Embedded fields where the nested @Embeddable fields are null
	 * or empty.
	 */
	@PostLoad
	public void nullEmptyListFields() {
		final AlternativeNameListDataType altNameList = getAlternativeNameList();
		if (altNameList != null
				&& (altNameList.getAlternativeName() == null || altNameList.getAlternativeName()
						.isEmpty())) {
			setAlternativeNameList(null);
		}
	}

}

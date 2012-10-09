package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

/**
 * Abstract base class for {@link FacilityDataType} and
 * {@link EnvironmentalInterestDataType}. This class nulls out the
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractIndustryCodeInfoDataType {

	/**
	 * Returns the list of NAICS info.
	 *
	 * @returns the list of NAICS info
	 */
	@Transient
	public abstract NAICSListDataType getNAICSList();

	/**
	 * Sets the list of NAICS info.
	 *
	 * @param naicsList
	 *            the list of NAICS info
	 */
	public abstract void setNAICSList(NAICSListDataType naicsList);

	/**
	 * Returns the list of SIC info.
	 *
	 * @return the list of SIC info
	 */
	@Transient
	public abstract SICListDataType getSICList();

	/**
	 * Sets the list of SIC info.
	 *
	 * @param sicList
	 *            the list of SIC info
	 */
	public abstract void setSICList(SICListDataType sicList);

	/**
	 * Returns the list of affiliation info.
	 *
	 * @return the list of affiliation info
	 */
	@Transient
	public abstract AffiliationListDataType getAffiliationList();

	/**
	 * Sets the list of affiliation info.
	 *
	 * @param affiliationList
	 *            the list of affiliation info
	 */
	public abstract void setAffiliationList(final AffiliationListDataType affiliationList);

	/**
	 * Returns the list of alternative identifications.
	 *
	 * @return list of alternative identifications
	 */
	@Transient
	public abstract AlternativeIdentificationListDataType getAlternativeIdentificationList();

	/**
	 * Sets the list of alternative identifications.
	 *
	 * @param alternativeIdentificationList
	 *            list of alternative identifications
	 */
	public abstract void setAlternativeIdentificationList(
			final AlternativeIdentificationListDataType alternativeIdentificationList);

	/**
	 * Nulls out @Embedded fields if the nested @Embeddable is null or empty.
	 */
	@PostLoad
	public void nullEmptyIndustryListFields() {
		final NAICSListDataType naicsList = getNAICSList();
		if (naicsList != null
				&& (naicsList.getFacilityNAICS() == null || naicsList.getFacilityNAICS().isEmpty())) {
			setNAICSList(null);
		}
		final SICListDataType sicList = getSICList();
		if (sicList != null
				&& (sicList.getFacilitySIC() == null || sicList.getFacilitySIC().isEmpty())) {
			setSICList(null);
		}
		final AffiliationListDataType affList = getAffiliationList();
		if (affList != null
				&& (affList.getFacilityAffiliation() == null || affList.getFacilityAffiliation()
						.isEmpty())) {
			setAffiliationList(null);
		}
		final AlternativeIdentificationListDataType altIdList = getAlternativeIdentificationList();
		if (altIdList != null
				&& (altIdList.getAlternativeIdentification() == null || altIdList
						.getAlternativeIdentification().isEmpty())) {
			setAlternativeIdentificationList(null);
		}
	}

}

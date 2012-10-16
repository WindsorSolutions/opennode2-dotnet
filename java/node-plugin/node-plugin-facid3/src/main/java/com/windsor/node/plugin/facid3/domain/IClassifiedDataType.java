package com.windsor.node.plugin.facid3.domain;

import java.util.List;

import com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

public interface IClassifiedDataType {

	/**
	 * Returns the list of NAICS info.
	 *
	 * @returns the list of NAICS info
	 */
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
	public abstract AffiliationListDataType getAffiliationList();

	/**
	 * Sets the list of affiliation info.
	 *
	 * @param affiliationList
	 *            the list of affiliation info
	 */
	public abstract void setAffiliationList(AffiliationListDataType affiliationList);

	/**
	 * Returns the list of alternative identifications.
	 *
	 * @return list of alternative identifications
	 */
	public abstract AlternativeIdentificationListDataType getAlternativeIdentificationList();

	/**
	 * Sets the list of alternative identifications.
	 *
	 * @param alternativeIdentificationList
	 *            list of alternative identifications
	 */
	public abstract void setAlternativeIdentificationList(
			AlternativeIdentificationListDataType alternativeIdentificationList);

	public abstract List<FacilitySICDataType> getSicCodes();

	public abstract void setSicCodes(List<FacilitySICDataType> sicCodes);

	public abstract List<FacilityNAICSDataType> getNaicsCodes();

	public abstract void setNaicsCodes(List<FacilityNAICSDataType> naicsCodes);

}
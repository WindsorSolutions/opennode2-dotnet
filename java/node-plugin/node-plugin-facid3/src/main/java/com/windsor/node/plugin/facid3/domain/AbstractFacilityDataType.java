package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;

import com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

/**
 * Abstract base class for {@link FacilityDetailsDataType}.
 *
 */
@MappedSuperclass
public abstract class AbstractFacilityDataType extends AbstractQueryableFacilityDataType implements IClassifiedDataType {

	@Override
	@Transient
	public abstract NAICSListDataType getNAICSList();

	@Override
	public abstract void setNAICSList(NAICSListDataType naicsList);

	@Override
	@Transient
	public abstract SICListDataType getSICList();

	@Override
	public abstract void setSICList(SICListDataType sicList);

	@Override
	@Transient
	public abstract AffiliationListDataType getAffiliationList();

	@Override
	public abstract void setAffiliationList(AffiliationListDataType affiliationList);

	@Override
	@Transient
	public abstract AlternativeIdentificationListDataType getAlternativeIdentificationList();

	@Override
	public abstract void setAlternativeIdentificationList(
			AlternativeIdentificationListDataType alternativeIdentificationListDataType);

	@Transient
	public abstract AlternativeNameListDataType getAlternativeNameList();

	public abstract void setAlternativeNameList(
			AlternativeNameListDataType alternativeNameList);

	@PostLoad
	public void nullEmptyListFields() {
		AlternativeNameListDataType altNameList = getAlternativeNameList();
		if (altNameList != null
				&& (altNameList.getAlternativeName() == null || altNameList.getAlternativeName()
						.isEmpty())) {
			setAlternativeNameList(null);
		}

		///////

		NAICSListDataType naicsList = getNAICSList();
		if (naicsList != null
				&& (naicsList.getFacilityNAICS() == null || naicsList.getFacilityNAICS().isEmpty())) {
			setNAICSList(null);
		}
		SICListDataType sicList = getSICList();
		if (sicList != null
				&& (sicList.getFacilitySIC() == null || sicList.getFacilitySIC().isEmpty())) {
			setSICList(null);
		}
		AffiliationListDataType affList = getAffiliationList();
		if (affList != null
				&& (affList.getFacilityAffiliation() == null || affList.getFacilityAffiliation()
						.isEmpty())) {
			setAffiliationList(null);
		}
		AlternativeIdentificationListDataType altIdList = getAlternativeIdentificationList();
		if (altIdList != null
				&& (altIdList.getAlternativeIdentification() == null || altIdList
						.getAlternativeIdentification().isEmpty())) {
			setAlternativeIdentificationList(null);
		}
	}

}

package com.windsor.node.plugin.facid3.domain;

import java.util.List;

import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlTransient;

import com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

public abstract class AbstractEnvironmentInterestDataType implements IClassifiedDataType {

	@Override
	@Transient
	public abstract NAICSListDataType getNAICSList();

	@Override
	public abstract void setNAICSList(NAICSListDataType naicsList);

	@Override
	@Transient
	public abstract SICListDataType getSICList();

	@Transient
	private List<FacilitySICDataType> sicCodes;

	@XmlTransient
	private List<FacilityNAICSDataType> naicsCodes;

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
			AlternativeIdentificationListDataType alternativeIdentificationList);

	@Override
	@OneToMany(fetch = FetchType.LAZY)
	@JoinColumn(name = "PARENT_ID")
	public List<FacilitySICDataType> getSicCodes() {
		return sicCodes;
	}

	@Override
	public void setSicCodes(List<FacilitySICDataType> sicCodes) {
		this.sicCodes = sicCodes;
	}

	@Override
	@OneToMany(fetch = FetchType.LAZY)
	@JoinColumn(name = "PARENT_ID")
	public List<FacilityNAICSDataType> getNaicsCodes() {
		return naicsCodes;
	}

	@Override
	public void setNaicsCodes(List<FacilityNAICSDataType> naicsCodes) {
		this.naicsCodes = naicsCodes;
	}

	@PostLoad
	public void nullEmptyIndustryListFields() {
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

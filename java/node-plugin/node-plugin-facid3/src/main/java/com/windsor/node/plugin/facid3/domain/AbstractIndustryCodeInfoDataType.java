package com.windsor.node.plugin.facid3.domain;

import java.util.List;

import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.MappedSuperclass;
import javax.persistence.OneToMany;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

import com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

/**
 * Abstract base class for {@link FacilityDataType} and
 * {@link EnvironmentalInterestDataType}. This class nulls out the
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractIndustryCodeInfoDataType implements IClassifiedDataType {

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getNAICSList()
	 */
	@Override
	@Transient
	public abstract NAICSListDataType getNAICSList();

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setNAICSList(com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType)
	 */
	@Override
	public abstract void setNAICSList(NAICSListDataType naicsList);

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getSICList()
	 */
	@Override
	@Transient
	public abstract SICListDataType getSICList();

	@Transient
	private List<FacilitySICDataType> sicCodes;

	@XmlTransient
	private List<FacilityNAICSDataType> naicsCodes;

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setSICList(com.windsor.node.plugin.facid3.domain.generated.SICListDataType)
	 */
	@Override
	public abstract void setSICList(SICListDataType sicList);

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getAffiliationList()
	 */
	@Override
	@Transient
	public abstract AffiliationListDataType getAffiliationList();

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setAffiliationList(com.windsor.node.plugin.facid3.domain.generated.AffiliationListDataType)
	 */
	@Override
	public abstract void setAffiliationList(AffiliationListDataType affiliationList);

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getAlternativeIdentificationList()
	 */
	@Override
	@Transient
	public abstract AlternativeIdentificationListDataType getAlternativeIdentificationList();

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setAlternativeIdentificationList(com.windsor.node.plugin.facid3.domain.generated.AlternativeIdentificationListDataType)
	 */
	@Override
	public abstract void setAlternativeIdentificationList(
			AlternativeIdentificationListDataType alternativeIdentificationList);

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getSicCodes()
	 */
	@Override
	@OneToMany(fetch = FetchType.LAZY)
	@JoinColumn(name = "PARENT_ID")
	public List<FacilitySICDataType> getSicCodes() {
		return sicCodes;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setSicCodes(java.util.List)
	 */
	@Override
	public void setSicCodes(List<FacilitySICDataType> sicCodes) {
		this.sicCodes = sicCodes;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#getNaicsCodes()
	 */
	@Override
	@OneToMany(fetch = FetchType.LAZY)
	@JoinColumn(name = "PARENT_ID")
	public List<FacilityNAICSDataType> getNaicsCodes() {
		return naicsCodes;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#setNaicsCodes(java.util.List)
	 */
	@Override
	public void setNaicsCodes(List<FacilityNAICSDataType> naicsCodes) {
		this.naicsCodes = naicsCodes;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IClassifiedDataType#nullEmptyIndustryListFields()
	 */
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

package com.windsor.node.plugin.facid3.domain;

import java.util.Date;
import java.util.List;

import javax.persistence.MappedSuperclass;

import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityPrimaryGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;

@MappedSuperclass
public interface IQueryableFacility {

	/**
	 * Returns whether the facility is active.
	 *
	 * @return whether the facility is active
	 */
	public abstract String getActive();

	/**
	 * Sets whether the facility is active.
	 *
	 * @param active
	 *            whether the facility is active
	 */
	public abstract void setActive(String active);

	public abstract List<EnvironmentalInterestDataType> getEnvironmentalInterests();

	public abstract void setEnvironmentalInterests(
			List<EnvironmentalInterestDataType> environmentalInterestCodes);

	public abstract String getTribalLandIndicator();

	public abstract void setTribalLandIndicator(String tribalLandIndicator);

	public abstract String getZipCode();

	public abstract void setZipCode(String zipCode);

	public abstract String getFederalFacilityIndicator();

	public abstract void setFederalFacilityIndicator(String federalFacilityIndicator);

	public abstract String getFacilityName();

	public abstract void setFacilityName(String facilityName);

	public abstract List<AlternativeNameDataType> getAlternativeNames();

	public abstract void setAlternativeNames(List<AlternativeNameDataType> alternativeNames);

	public abstract String getCity();

	public abstract void setCity(String city);

	public abstract String getState();

	public abstract void setState(String state);

	public abstract String getCounty();

	public abstract void setCounty(String county);

	public abstract List<FacilitySICDataType> getSicCodes();

	public abstract void setSicCodes(List<FacilitySICDataType> sicCodes);

	public abstract List<FacilityNAICSDataType> getNaicsCodes();

	public abstract void setNaicsCodes(List<FacilityNAICSDataType> naicsCodes);

	Date getLastUpdated();

	void setLastUpdated(Date lastUpdated);

	public String getSiteIdentifier();

	public void setSiteIdentifier(String siteIdentifier);

	public String getOriginatingPartnerName();

	public void setOriginatingPartnerName(String originatingPartnerName);

	public String getInformationSystemAcronymName();

	public void setInformationSystemAcronymName(String informationSystemAcronymName);

	FacilityPrimaryGeographicLocationDescriptionDataType getLocation();

	void setLocation(FacilityPrimaryGeographicLocationDescriptionDataType location);
}
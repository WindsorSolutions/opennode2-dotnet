package com.windsor.node.plugin.facid3.domain;

import java.util.Date;
import java.util.List;

import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.MappedSuperclass;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityPrimaryGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractQueryableFacilityDataType implements IQueryableFacility {

	/**
	 * Whether the facility is active.
	 */
	@XmlTransient
	private String active;

	@XmlTransient
	private List<EnvironmentalInterestDataType> environmentalInterests;

	@XmlTransient
	private String tribalLandIndicator;

	@XmlTransient
	private String zipCode;

	@XmlTransient
	private String federalFacilityIndicator;

	@XmlTransient
	private String facilityName;

	@XmlTransient
	private List<AlternativeNameDataType> alternativeNames;

	@XmlTransient
	private String city;

	@XmlTransient
	private String state;

	@XmlTransient
	private String county;

	@XmlTransient
	private Date lastUpdated;

	@XmlTransient
	private String siteIdentifier;

	@XmlTransient
	private String originatingPartnerName;

	@XmlTransient
	private String informationSystemAcronymName;

	@XmlTransient
	private FacilityPrimaryGeographicLocationDescriptionDataType location;

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getActive()
	 */
	@Override
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "FAC_ACTIVE_INDI")
	public String getActive() {
		return active;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setActive(java.lang.String)
	 */
	@Override
	public void setActive(String active) {
		this.active = active;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getEnvironmentalInterests()
	 */
	@Override
	@OneToMany
	@JoinColumn(name = "FAC_ID")
	public List<EnvironmentalInterestDataType> getEnvironmentalInterests() {
		return environmentalInterests;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setEnvironmentalInterests(java.util.List)
	 */
	@Override
	public void setEnvironmentalInterests(List<EnvironmentalInterestDataType> environmentalInterestCodes) {
		this.environmentalInterests = environmentalInterestCodes;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getTribalLandIndicator()
	 */
	@Override
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "TRIB_LAND_INDI", insertable = false, updatable = false)
	public String getTribalLandIndicator() {
		return tribalLandIndicator;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setTribalLandIndicator(java.lang.String)
	 */
	@Override
	public void setTribalLandIndicator(String tribalLandIndicator) {
		this.tribalLandIndicator = tribalLandIndicator;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getZipCode()
	 */
	@Override
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "ADDR_POST_CODE_VAL", insertable = false, updatable = false)
	public String getZipCode() {
		return zipCode;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setZipCode(java.lang.String)
	 */
	@Override
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getFederalFacilityIndicator()
	 */
	@Override
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "FED_FAC_INDI", insertable = false, updatable = false)
	public String getFederalFacilityIndicator() {
		return federalFacilityIndicator;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setFederalFacilityIndicator(java.lang.String)
	 */
	@Override
	public void setFederalFacilityIndicator(String federalFacilityIndicator) {
		this.federalFacilityIndicator = federalFacilityIndicator;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getFacilityName()
	 */
	@Override
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "FAC_SITE_NAME", insertable = false, updatable = false)
	public String getFacilityName() {
		return facilityName;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setFacilityName(java.lang.String)
	 */
	@Override
	public void setFacilityName(String facilityName) {
		this.facilityName = facilityName;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getAlternativeNames()
	 */
	@Override
	@OneToMany(fetch = FetchType.LAZY)
	@JoinColumn(name = "FAC_ID")
	public List<AlternativeNameDataType> getAlternativeNames() {
		return alternativeNames;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setAlternativeNames(java.util.List)
	 */
	@Override
	public void setAlternativeNames(List<AlternativeNameDataType> alternativeNames) {
		this.alternativeNames = alternativeNames;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getCity()
	 */
	@Override
	@Column(name = "LOCA_NAME", insertable = false, updatable = false)
	public String getCity() {
		return city;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setCity(java.lang.String)
	 */
	@Override
	public void setCity(String city) {
		this.city = city;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getState()
	 */
	@Override
	@Column(name = "STA_CODE", insertable = false, updatable = false)
	public String getState() {
		return state;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setState(java.lang.String)
	 */
	@Override
	public void setState(String state) {
		this.state = state;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#getCounty()
	 */
	@Override
	@Column(name = "CNTY_CODE", insertable = false, updatable = false)
	public String getCounty() {
		return county;
	}

	/* (non-Javadoc)
	 * @see com.windsor.node.plugin.facid3.domain.IQueryableFacilityDataType#setCounty(java.lang.String)
	 */
	@Override
	public void setCounty(String county) {
		this.county = county;
	}

	@Transient
	private List<FacilitySICDataType> sicCodes;

	@XmlTransient
	private List<FacilityNAICSDataType> naicsCodes;

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

	@Override
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "last_updt_date")
	public Date getLastUpdated() {
		return lastUpdated;
	}

	@Override
	public void setLastUpdated(Date lastUpdated) {
		this.lastUpdated = lastUpdated;
	}

	@Override
	@Column(name = "fac_site_iden_val")
	public String getSiteIdentifier() {
		return siteIdentifier;
	}

	@Override
	public void setSiteIdentifier(String siteIdentifier) {
		this.siteIdentifier = siteIdentifier;
	}

	@Override
	@Column(name = "orig_part_name")
	public String getOriginatingPartnerName() {
		return originatingPartnerName;
	}

	@Override
	public void setOriginatingPartnerName(String originatingPartnerName) {
		this.originatingPartnerName = originatingPartnerName;
	}

	@Override
	@Column(name = "info_sys_acro_name")
	public String getInformationSystemAcronymName() {
		return informationSystemAcronymName;
	}

	@Override
	public void setInformationSystemAcronymName(String informationSystemAcronymName) {
		this.informationSystemAcronymName = informationSystemAcronymName;
	}

	@Override
	@OneToOne
	@JoinColumn(name = "FAC_ID")
	public FacilityPrimaryGeographicLocationDescriptionDataType getLocation() {
		return location;
	}

	@Override
	public void setLocation(FacilityPrimaryGeographicLocationDescriptionDataType location) {
		this.location = location;
	}

}

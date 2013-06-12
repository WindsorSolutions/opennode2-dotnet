package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeConstants;
import javax.xml.datatype.DatatypeFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.AddressPostalCodeDataType;
import com.windsor.node.plugin.facid3.domain.CountryCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.CountryIdentityDataType;
import com.windsor.node.plugin.facid3.domain.CountyCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.CountyIdentityDataType;
import com.windsor.node.plugin.facid3.domain.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteIdentityDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteTypeCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.LocationAddressDataType;
import com.windsor.node.plugin.facid3.domain.MailingAddressDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.StateCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.StateIdentityDataType;

public class FacilityDataTypeRowMapper implements RowMapper<FacilityDataType>
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private FacilityDataTypeDao facilityDataTypeDao;
    private EnvironmentalInterestDataTypeDao environmentalInterestDao;
    private AffiliationListDataTypeDao affiliationListDataTypeDao;

    public FacilityDataTypeRowMapper(FacilityDataTypeDao facilityDataTypeDao, EnvironmentalInterestDataTypeDao environmentalInterestDao, AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        setFacilityDataTypeDao(facilityDataTypeDao);
        setEnvironmentalInterestDao(environmentalInterestDao);
        setAffiliationListDataTypeDao(affiliationListDataTypeDao);
    }

    public FacilityDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        DatatypeFactory datatypeFactory = null;
        try
        {
            datatypeFactory = DatatypeFactory.newInstance();
        }
        catch(DatatypeConfigurationException e)
        {
            logger.warn("A serious configuration error occured when trying to create a factory to handle XML date objects, recovering, but no dates can be parsed or included in file.",
                        e.getMessage());
        }

        FacilityDataType facility = fact.createFacilityDataType();

        // BEGIN SC:Facility Site Identity
        FacilitySiteIdentityDataType facilitySiteIdentity = fact.createFacilitySiteIdentityDataType();
        facility.setFacilitySiteIdentity(facilitySiteIdentity);
        FacilitySiteIdentifierDataType facilitySiteIdentifier = fact.createFacilitySiteIdentifierDataType();
        facilitySiteIdentity.setFacilitySiteIdentifier(facilitySiteIdentifier);
        FacilitySiteDataType facilitySite = fact.createFacilitySiteDataType();
        facilitySiteIdentity.setFacilitySiteType(facilitySite);
        FacilitySiteTypeCodeListIdentifierDataType facilitySiteTypeCodeListIdentifier = fact
                        .createFacilitySiteTypeCodeListIdentifierDataType();
        facilitySite.setFacilitySiteTypeCodeListIdentifier(facilitySiteTypeCodeListIdentifier);

        facilitySiteIdentifier.setFacilitySiteIdentifierContext(rs.getString("FAC_SITE_IDEN_CONT"));
        facilitySiteIdentifier.setValue(rs.getString("FAC_SITE_IDEN_VAL"));
        facilitySiteIdentity.setFacilitySiteName(rs.getString("FAC_SITE_NAME"));
        facilitySiteIdentity.setFederalFacilityIndicator(rs.getString("FED_FAC_INDI"));
        facilitySite.setFacilitySiteTypeCode(rs.getString("FAC_SITE_TYPE_CODE"));
        facilitySite.setFacilitySiteTypeName(rs.getString("FAC_SITE_TYPE_NAME"));
        facilitySiteTypeCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("CODE_LIST_VERS_AGN_IDEN"));
        facilitySiteTypeCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CODE_LIST_VERS_IDEN"));
        facilitySiteTypeCodeListIdentifier.setValue(rs.getString("CODE_LST_VER_VAL"));
        // END SC:Facility Site Identity

        // BEGIN SC:Location Address
        LocationAddressDataType locationAddress = fact.createLocationAddressDataType();
        facility.setLocationAddress(locationAddress);
        AddressPostalCodeDataType addressPostalCode = fact.createAddressPostalCodeDataType();
        locationAddress.setAddressPostalCode(addressPostalCode);
        CountryIdentityDataType countryIdentity = fact.createCountryIdentityDataType();
        locationAddress.setCountryIdentity(countryIdentity);
        CountryCodeListIdentifierDataType countryCodeListIdentifier = fact.createCountryCodeListIdentifierDataType();
        countryIdentity.setCountryCodeListIdentifier(countryCodeListIdentifier);
        CountyIdentityDataType countyIdentity = fact.createCountyIdentityDataType();
        CountyCodeListIdentifierDataType countyCodeListIdentifier = fact.createCountyCodeListIdentifierDataType();
        StateIdentityDataType stateIdentity = fact.createStateIdentityDataType();
        locationAddress.setStateIdentity(stateIdentity);
        StateCodeListIdentifierDataType stateCodeListIdentifier = fact.createStateCodeListIdentifierDataType();
        stateIdentity.setStateCodeListIdentifier(stateCodeListIdentifier);

        locationAddress.setLocalityName(rs.getString("LOCA_NAME"));
        locationAddress.setLocationAddressText(rs.getString("LOC_ADDR_TEXT"));
        locationAddress.setLocationDescriptionText(rs.getString("LOC_DESC_TEXT"));
        locationAddress.setSupplementalLocationText(rs.getString("SUPP_LOC_TEXT"));
        locationAddress.setTribalLandIndicator(rs.getString("TRIB_LAND_INDI"));
        locationAddress.setTribalLandName(rs.getString("TRIB_LAND_NAME"));

        addressPostalCode.setAddressPostalCodeContext(rs.getString("ADDR_POST_CODE_CONT"));
        addressPostalCode.setValue(rs.getString("ADDR_POST_CODE_VAL"));

        countryIdentity.setCountryCode(rs.getString("CTRY_CODE"));
        countryIdentity.setCountryName(rs.getString("CTRY_NAME"));

        countryCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("LOC_ADDR_CODE_LIS_VER_AGN_IDE"));
        countryCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VERS_IDE"));
        countryCodeListIdentifier.setValue(rs.getString("LOC_ADDR_COD_LST_VER_VAL"));

        // if(rs.getString("CNTY_CODE") != null && rs.getString("CNTY_NAME") != null)
        // {
        locationAddress.setCountyIdentity(countyIdentity);
        countyIdentity.setCountyCode(rs.getString("CNTY_CODE"));
        countyIdentity.setCountyName(rs.getString("CNTY_NAME"));

        // if(rs.getString("LOC_ADD_COD_LST_VER_VAL") != null)
        // {
        countyIdentity.setCountyCodeListIdentifier(countyCodeListIdentifier);
        countyCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("LOC_ADDR_COD_LIS_VER_AGN_IDE"));
        countyCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VER_IDE"));
        countyCodeListIdentifier.setValue(rs.getString("LOC_ADD_COD_LST_VER_VAL"));
        // }
        // }

        stateIdentity.setStateCode(rs.getString("STA_CODE"));
        stateIdentity.setStateName(rs.getString("STA_NAME"));

        stateCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VER_AGN_IDE"));
        stateCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VERS_IDEN"));
        stateCodeListIdentifier.setValue(rs.getString("LOC_ADDR_CODE_LST_VER_VAL"));
        // END SC:Location Address

        // BEGIN SC:Mailing Address
        MailingAddressDataType mailingAddress = fact.createMailingAddressDataType();
        facility.setMailingAddress(mailingAddress);
        mailingAddress.setMailingAddressCityName(rs.getString("MAIL_ADDR_CITY_NAME"));
        mailingAddress.setMailingAddressText(rs.getString("MAIL_ADDR_TEXT"));
        mailingAddress.setSupplementalAddressText(rs.getString("SUPP_ADDR_TEXT"));

        AddressPostalCodeDataType mailingAddressPostalCode = fact.createAddressPostalCodeDataType();
        mailingAddress.setAddressPostalCode(mailingAddressPostalCode);
        mailingAddressPostalCode.setValue(rs.getString("MAIL_ADDR_ADDR_POST_CODE_VAL"));
        mailingAddressPostalCode.setAddressPostalCodeContext(rs.getString("MAIL_ADDR_ADDR_POST_CODE_CONT"));

        CountryIdentityDataType mailingCountryIdentity = fact.createCountryIdentityDataType();
        mailingAddress.setCountryIdentity(mailingCountryIdentity);
        mailingCountryIdentity.setCountryCode(rs.getString("MAIL_ADDR_CTRY_CODE"));
        mailingCountryIdentity.setCountryName(rs.getString("MAIL_ADDR_CTRY_NAME"));

        CountryCodeListIdentifierDataType mailingCountryCodeListIdentifier = fact.createCountryCodeListIdentifierDataType();
        mailingCountryIdentity.setCountryCodeListIdentifier(mailingCountryCodeListIdentifier);
        mailingCountryCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("MAIL_ADDR_COD_LIS_VER_AGN_IDE"));
        mailingCountryCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("MAIL_ADDR_CODE_LIST_VERS_IDE"));
        mailingCountryCodeListIdentifier.setValue(rs.getString("MAIL_ADDR_COD_LST_VER_VAL"));

        StateIdentityDataType mailingStateIdentity = fact.createStateIdentityDataType();
        mailingAddress.setStateIdentity(mailingStateIdentity);
        mailingStateIdentity.setStateCode(rs.getString("MAIL_ADDR_STA_CODE"));
        mailingStateIdentity.setStateName(rs.getString("MAIL_ADDR_STA_NAME"));

        StateCodeListIdentifierDataType mailingStateCodeListIdentifier = fact.createStateCodeListIdentifierDataType();
        mailingStateIdentity.setStateCodeListIdentifier(mailingStateCodeListIdentifier);
        mailingStateCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("MAIL_ADDR_CODE_LIS_VER_AGN_IDE"));
        mailingStateCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("MAIL_ADDR_CODE_LIST_VERS_IDEN"));
        mailingStateCodeListIdentifier.setValue(rs.getString("MAIL_ADDR_CODE_LST_VER_VAL"));
        // END SC:Mailing Address

        // BEGIN Facility Primary Geographic Location Description
        facility.setFacilityPrimaryGeographicLocationDescription(getFacilityDataTypeDao().loadPrimaryGeoLocationByFacilityId(rs.getString("FAC_ID")));
        // END Facility Primary Geographic Location Description

        // BEGIN Facility Geographic Location Description
        facility.setFacilityGeographicLocationList(getFacilityDataTypeDao().loadGeoLocationByFacilityId(rs.getString("FAC_ID")));
        // END Facility Geographic Location Description

        // BEGIN Alternative Name
        facility.setAlternativeNameList(getFacilityDataTypeDao().loadAlternativeNamesByFacilityId(rs.getString("FAC_ID")));
        // END Alternative Name

        // BEGIN Environmental Interest
        facility.setEnvironmentalInterestList(getEnvironmentalInterestDao().loadEnvironmentalInterestsByFacilityId(rs.getString("FAC_ID")));
        // END Environmental Interest

        DataSourceDataType dataSource = fact.createDataSourceDataType();
        facility.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("LAST_UPDT_DATE"));
            dataSource.setLastUpdatedDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        // BEGIN SC:Facility SIC
        facility.setSICList(getFacilityDataTypeDao().loadSicListByFacilityId(rs.getString("FAC_ID")));
        // END SC:Facility SIC

        // BEGIN SC:Facility NAICS
        facility.setNAICSList(getFacilityDataTypeDao().loadNaicsListByFacilityId(rs.getString("FAC_ID")));
        // END SC:Facility NAICS

        // BEGIN SC:Electronic Address
        facility.setElectronicAddressList(getFacilityDataTypeDao().loadElectronicAddressListByFacilityId(rs.getString("FAC_ID")));
        // END SC:Electronic Address

        //BEGIN Alternative Identification
        facility.setAlternativeIdentificationList(getFacilityDataTypeDao().loadAlternativeIdentificationListByFacilityId(rs.getString("FAC_ID")));
        //END Alternative Identification

        //BEGIN Facility Affiliation
        facility.setAffiliationList(getAffiliationListDataTypeDao().loadAffiliationListByFacilityId(rs.getString("FAC_ID")));
        //END Facility Affiliation

        return facility;
    }

    public FacilityDataTypeDao getFacilityDataTypeDao()
    {
        return facilityDataTypeDao;
    }

    public void setFacilityDataTypeDao(FacilityDataTypeDao facilityDataTypeDao)
    {
        this.facilityDataTypeDao = facilityDataTypeDao;
    }

    public EnvironmentalInterestDataTypeDao getEnvironmentalInterestDao()
    {
        return environmentalInterestDao;
    }

    public void setEnvironmentalInterestDao(EnvironmentalInterestDataTypeDao environmentalInterestDao)
    {
        this.environmentalInterestDao = environmentalInterestDao;
    }

    public AffiliationListDataTypeDao getAffiliationListDataTypeDao()
    {
        return affiliationListDataTypeDao;
    }

    public void setAffiliationListDataTypeDao(AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        this.affiliationListDataTypeDao = affiliationListDataTypeDao;
    }

}

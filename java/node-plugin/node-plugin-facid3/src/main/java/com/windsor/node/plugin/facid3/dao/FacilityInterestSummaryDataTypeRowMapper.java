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
import com.windsor.node.plugin.facid3.domain.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.FacilityInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.FacilityLocationAddressDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.StateCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.StateIdentityDataType;

public class FacilityInterestSummaryDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private EnvironmentalInterestDataTypeDao environmentalInterestDao;
    private FacilityDataTypeDao facilityDataTypeDao;

    public FacilityInterestSummaryDataTypeRowMapper(FacilityDataTypeDao facilityDataTypeDao,
                    EnvironmentalInterestDataTypeDao environmentalInterestDao)
    {
        setFacilityDataTypeDao(facilityDataTypeDao);
        setEnvironmentalInterestDao(environmentalInterestDao);
    }

    public Object mapRow(ResultSet rs, int rowNum) throws SQLException
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

        FacilityInterestSummaryDataType facilityInterestSummary = fact.createFacilityInterestSummaryDataType();
        facilityInterestSummary.setFacilitySiteName(rs.getString("FAC_SITE_NAME"));
        facilityInterestSummary.setFacilityURLText(rs.getString("FAC_URL_TEXT"));

        DataSourceDataType dataSource = fact.createDataSourceDataType();
        facilityInterestSummary.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("LAST_UPDT_DATE"));
            dataSource.setLastUpdatedDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));

        facilityInterestSummary.setEnvironmentalInterestSummaryList(getEnvironmentalInterestDao().loadEnvironmentalSummariesByFacilityId(rs.getString("FAC_ID")));

        FacilityLocationAddressDataType facilityLocationAddress = fact.createFacilityLocationAddressDataType();
        facilityInterestSummary.setFacilityLocationAddress(facilityLocationAddress);
        facilityLocationAddress.setLocalityName(rs.getString("LOCA_NAME"));
        facilityLocationAddress.setLocationAddressText(rs.getString("LOC_ADDR_TEXT"));
        facilityLocationAddress.setSupplementalLocationText(rs.getString("SUPP_LOC_TEXT"));

        AddressPostalCodeDataType addressPostalCode = fact.createAddressPostalCodeDataType();
        facilityLocationAddress.setAddressPostalCode(addressPostalCode);
        addressPostalCode.setAddressPostalCodeContext(rs.getString("ADDR_POST_CODE_CONT"));
        addressPostalCode.setValue(rs.getString("ADDR_POST_CODE_VAL"));

        CountryIdentityDataType countryIdentity = fact.createCountryIdentityDataType();
        facilityLocationAddress.setCountryIdentity(countryIdentity);
        countryIdentity.setCountryCode(rs.getString("CTRY_CODE"));
        countryIdentity.setCountryName(rs.getString("CTRY_NAME"));

        CountryCodeListIdentifierDataType countryCodeListIdentifier = fact.createCountryCodeListIdentifierDataType();
        countryIdentity.setCountryCodeListIdentifier(countryCodeListIdentifier);
        countryCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("LOC_ADDR_CODE_LIS_VER_AGN_IDE"));
        countryCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VERS_IDE"));
        countryCodeListIdentifier.setValue(rs.getString("LOC_ADDR_COD_LST_VER_VAL"));

        StateIdentityDataType stateIdentity = fact.createStateIdentityDataType();
        facilityLocationAddress.setStateIdentity(stateIdentity);
        stateIdentity.setStateCode(rs.getString("STA_CODE"));
        stateIdentity.setStateName(rs.getString("STA_NAME"));

        StateCodeListIdentifierDataType stateCodeListIdentifier = fact.createStateCodeListIdentifierDataType();
        stateIdentity.setStateCodeListIdentifier(stateCodeListIdentifier);
        stateCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VER_AGN_IDE"));
        stateCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("LOC_ADDR_CODE_LIST_VERS_IDEN"));
        stateCodeListIdentifier.setValue(rs.getString("LOC_ADDR_CODE_LST_VER_VAL"));

        FacilitySiteIdentifierDataType facilitySiteIdentifier = fact.createFacilitySiteIdentifierDataType();
        facilityInterestSummary.setFacilitySiteIdentifier(facilitySiteIdentifier);
        facilitySiteIdentifier.setFacilitySiteIdentifierContext(rs.getString("FAC_SITE_IDEN_CONT"));
        facilitySiteIdentifier.setValue(rs.getString("FAC_SITE_IDEN_VAL"));

        facilityInterestSummary.setFacilitySummaryGeographicLocation(getFacilityDataTypeDao().loadFacilitySummaryGeographicLocationByFacilityId(rs.getString("FAC_ID")));

        return facilityInterestSummary;
    }

    public EnvironmentalInterestDataTypeDao getEnvironmentalInterestDao()
    {
        return environmentalInterestDao;
    }

    public void setEnvironmentalInterestDao(EnvironmentalInterestDataTypeDao environmentalInterestDao)
    {
        this.environmentalInterestDao = environmentalInterestDao;
    }

    public FacilityDataTypeDao getFacilityDataTypeDao()
    {
        return facilityDataTypeDao;
    }

    public void setFacilityDataTypeDao(FacilityDataTypeDao facilityDataTypeDao)
    {
        this.facilityDataTypeDao = facilityDataTypeDao;
    }
}

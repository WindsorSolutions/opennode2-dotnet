package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.facid3.domain.generated.AddressPostalCodeDataType;
import com.windsor.node.plugin.facid3.domain.generated.CountryCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.generated.CountryIdentityDataType;
import com.windsor.node.plugin.facid3.domain.generated.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityLocationAddressDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySiteIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.generated.StateCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.generated.StateIdentityDataType;

public class FacilitySummaryDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private FacilityDataTypeDao facilityDataTypeDao;

    public FacilitySummaryDataTypeRowMapper(FacilityDataTypeDao facilityDataTypeDao)
    {
        setFacilityDataTypeDao(facilityDataTypeDao);
    }

    @Override
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

        FacilitySummaryDataType facilitySummary = fact.createFacilitySummaryDataType();
        facilitySummary.setFacilitySiteName(rs.getString("FAC_SITE_NAME"));
        facilitySummary.setFacilityURLText(rs.getString("FAC_URL_TEXT"));

        FacilitySiteIdentifierDataType facilitySiteIdentifier = fact.createFacilitySiteIdentifierDataType();
        facilitySummary.setFacilitySiteIdentifier(facilitySiteIdentifier);
        facilitySiteIdentifier.setFacilitySiteIdentifierContext(rs.getString("FAC_SITE_IDEN_CONT"));
        facilitySiteIdentifier.setValue(rs.getString("FAC_SITE_IDEN_VAL"));

        DataSourceDataType dataSource = fact.createDataSourceDataType();
        facilitySummary.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            dataSource.setLastUpdatedDate(rs.getDate("LAST_UPDT_DATE"));
        }
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));

        FacilityLocationAddressDataType facilityLocationAddress = fact.createFacilityLocationAddressDataType();
        facilitySummary.setFacilityLocationAddress(facilityLocationAddress);
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

        facilitySummary.setFacilitySummaryGeographicLocation(getFacilityDataTypeDao().loadFacilitySummaryGeographicLocationByFacilityId(rs.getString("FAC_ID")));

        return facilitySummary;
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

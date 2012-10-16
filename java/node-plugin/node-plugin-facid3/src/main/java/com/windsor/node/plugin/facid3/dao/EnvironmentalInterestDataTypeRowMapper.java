package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.facid3.domain.generated.AgencyTypeCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.generated.AgencyTypeDataType;
import com.windsor.node.plugin.facid3.domain.generated.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.generated.YesNoIndicatorDataType;

public class EnvironmentalInterestDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao;
    private AffiliationListDataTypeDao affiliationListDataTypeDao;

    public EnvironmentalInterestDataTypeRowMapper(EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao, AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        setEnvironmentalInterestDataTypeDao(environmentalInterestDataTypeDao);
        setAffiliationListDataTypeDao(affiliationListDataTypeDao);
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
        EnvironmentalInterestDataType environmentalInterest = fact.createEnvironmentalInterestDataType();
        environmentalInterest.setEnvironmentalInterestIdentifier(rs.getString("ENVR_INTR_IDEN"));
        environmentalInterest.setEnvironmentalInterestTypeText(rs.getString("ENVR_INTR_TYPE_TEXT"));
        if(rs.getString("ENVR_INTR_START_DATE") != null && datatypeFactory != null)
        {
            environmentalInterest.setEnvironmentalInterestStartDate(rs.getDate("ENVR_INTR_START_DATE"));
        }
        environmentalInterest.setEnvironmentalInterestStartDateQualifierText(rs.getString("ENVR_INTR_START_DATE_QUAL_TEXT"));
        if(rs.getString("ENVR_INTR_END_DATE") != null && datatypeFactory != null)
        {
            environmentalInterest.setEnvironmentalInterestEndDate(rs.getDate("ENVR_INTR_END_DATE"));
        }
        environmentalInterest.setEnvironmentalInterestEndDateQualifierText(rs.getString("ENVR_INTR_END_DATE_QUAL_TEXT"));

        if("Y".equalsIgnoreCase(rs.getString("ENVR_INTR_ACTIVE_INDI")))
        {
            environmentalInterest.setEnvironmentalInterestActiveIndicator(YesNoIndicatorDataType.Y);
        }
        else if("N".equalsIgnoreCase(rs.getString("ENVR_INTR_ACTIVE_INDI")))
        {
            environmentalInterest.setEnvironmentalInterestActiveIndicator(YesNoIndicatorDataType.N);
        }

        // BEGIN Agency Type
        AgencyTypeDataType agencyType = fact.createAgencyTypeDataType();
        environmentalInterest.setAgencyType(agencyType);
        agencyType.setAgencyTypeCode(rs.getString("AGN_TYPE_CODE"));
        agencyType.setAgencyTypeName(rs.getString("AGN_TYPE_NAME"));

        AgencyTypeCodeListIdentifierDataType agencyTypeCodeListIdentifier = fact.createAgencyTypeCodeListIdentifierDataType();
        agencyType.setAgencyTypeCodeListIdentifier(agencyTypeCodeListIdentifier);
        agencyTypeCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("CODE_LIST_VERS_AGN_IDEN"));
        agencyTypeCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CODE_LIST_VERS_IDEN"));
        agencyTypeCodeListIdentifier.setValue(rs.getString("CODE_LST_VER_VAL"));
        // END Agency Type

        // BEGIN DataSource
        DataSourceDataType dataSource = fact.createDataSourceDataType();
        environmentalInterest.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            dataSource.setLastUpdatedDate(rs.getDate("LAST_UPDT_DATE"));
        }
        // END DataSource

        // BEGIN SC:Facility SIC
        environmentalInterest.setSICList(getEnvironmentalInterestDataTypeDao().loadSicListByEnvironmentalInterestId(rs.getString("ENVR_INTR_ID")));
        // END SC:Facility SIC

        // BEGIN SC:Facility NAICS
        environmentalInterest.setNAICSList(getEnvironmentalInterestDataTypeDao().loadNaicsListByEnvironmentalInterestId(rs.getString("ENVR_INTR_ID")));
        // END SC:Facility NAICS

        // BEGIN SC:Electronic Address
        environmentalInterest.setElectronicAddressList(getEnvironmentalInterestDataTypeDao().loadElectronicAddressListByEnvironmentalInterestId(rs.getString("ENVR_INTR_ID")));
        // END SC:Electronic Address

        // BEGIN Alternative Identification
        environmentalInterest.setAlternativeIdentificationList(getEnvironmentalInterestDataTypeDao().loadAlternativeIdentificationListByEnvironmentalInterestId(rs.getString("ENVR_INTR_ID")));
        // END Alternative Identification

        // BEGIN Facility Affiliation
        environmentalInterest.setAffiliationList(getAffiliationListDataTypeDao().loadAffiliationListByEnvironmentalInterestId(rs.getString("ENVR_INTR_ID")));
        // END Facility Affiliation

        return environmentalInterest;
    }

    public EnvironmentalInterestDataTypeDao getEnvironmentalInterestDataTypeDao()
    {
        return environmentalInterestDataTypeDao;
    }

    public void setEnvironmentalInterestDataTypeDao(EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao)
    {
        this.environmentalInterestDataTypeDao = environmentalInterestDataTypeDao;
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

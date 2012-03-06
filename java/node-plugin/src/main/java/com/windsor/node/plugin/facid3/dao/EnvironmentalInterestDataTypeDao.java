package com.windsor.node.plugin.facid3.dao;

import java.sql.Types;
import java.util.List;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.facid3.domain.AlternativeIdentificationDataType;
import com.windsor.node.plugin.facid3.domain.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressListDataType;
import com.windsor.node.plugin.facid3.domain.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.EnvironmentalInterestListDataType;
import com.windsor.node.plugin.facid3.domain.EnvironmentalInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.EnvironmentalInterestSummaryListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.SICListDataType;

public class EnvironmentalInterestDataTypeDao extends JdbcDaoSupport
{
    private AffiliationListDataTypeDao affiliationListDataTypeDao;

    public EnvironmentalInterestDataTypeDao(AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        setAffiliationListDataTypeDao(affiliationListDataTypeDao);
    }

    public EnvironmentalInterestListDataType loadEnvironmentalInterestsByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        EnvironmentalInterestListDataType environmentalInterestList = fact.createEnvironmentalInterestListDataType();
        @SuppressWarnings("unchecked")
        List<EnvironmentalInterestDataType> results = (List<EnvironmentalInterestDataType>)getJdbcTemplate()
                        .query(loadEnvironmentalInterestsByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new EnvironmentalInterestDataTypeRowMapper(this, getAffiliationListDataTypeDao()));
        environmentalInterestList.getEnvironmentalInterest().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return environmentalInterestList;
    }

    public EnvironmentalInterestSummaryListDataType loadEnvironmentalSummariesByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        EnvironmentalInterestSummaryListDataType environmentalInterestSummaryList = fact.createEnvironmentalInterestSummaryListDataType();
        @SuppressWarnings("unchecked")
        List<EnvironmentalInterestSummaryDataType> results = (List<EnvironmentalInterestSummaryDataType>)getJdbcTemplate()
                        .query(loadEnvironmentalInterestsByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new EnvironmentalInterestSummaryDataTypeRowMapper(this));
        environmentalInterestSummaryList.getEnvironmentalInterestSummary().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return environmentalInterestSummaryList;
    }

    public SICListDataType loadSicListByEnvironmentalInterestId(String enviromenalInterestId)
    {
        if(StringUtils.isBlank(enviromenalInterestId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        SICListDataType sicList = fact.createSICListDataType();
        @SuppressWarnings("unchecked")
        List<FacilitySICDataType> results = (List<FacilitySICDataType>)getJdbcTemplate()
                        .query(loadSicListByEnvironmentalInterestIdSql, new Object[]{enviromenalInterestId},
                               new int[]{Types.VARCHAR}, new FacilitySicDataTypeRowMapper());
        sicList.getFacilitySIC().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return sicList;
    }

    public NAICSListDataType loadNaicsListByEnvironmentalInterestId(String enviromenalInterestId)
    {
        if(StringUtils.isBlank(enviromenalInterestId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        NAICSListDataType naicsList = fact.createNAICSListDataType();
        @SuppressWarnings("unchecked")
        List<FacilityNAICSDataType> results = (List<FacilityNAICSDataType>)getJdbcTemplate()
                        .query(loadNaicsListByEnvironmentalInterestIdSql, new Object[]{enviromenalInterestId},
                               new int[]{Types.VARCHAR}, new FacilityNaicsDataTypeRowMapper());
        naicsList.getFacilityNAICS().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return naicsList;
    }

    public ElectronicAddressListDataType loadElectronicAddressListByEnvironmentalInterestId(String enviromenalInterestId)
    {
        if(StringUtils.isBlank(enviromenalInterestId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        ElectronicAddressListDataType electronicAddressList = fact.createElectronicAddressListDataType();
        @SuppressWarnings("unchecked")
        List<ElectronicAddressDataType> results = (List<ElectronicAddressDataType>)getJdbcTemplate()
                        .query(loadElectronicAddressListByEnvironmentalInterestIdSql, new Object[]{enviromenalInterestId},
                               new int[]{Types.VARCHAR}, new ElectronicAddressDataTypeRowMapper());
        electronicAddressList.getElectronicAddress().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return electronicAddressList;
    }

    public AlternativeIdentificationListDataType loadAlternativeIdentificationListByEnvironmentalInterestId(String enviromenalInterestId)
    {
        if(StringUtils.isBlank(enviromenalInterestId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        AlternativeIdentificationListDataType alternativeIdentificationList = fact.createAlternativeIdentificationListDataType();
        @SuppressWarnings("unchecked")
        List<AlternativeIdentificationDataType> results = (List<AlternativeIdentificationDataType>)getJdbcTemplate()
                        .query(loadAlternativeIdentificationListByEnvironmentalInterestIdSql, new Object[]{enviromenalInterestId},
                               new int[]{Types.VARCHAR}, new AlternativeIdentificationDataTypeRowMapper());
        alternativeIdentificationList.getAlternativeIdentification().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return alternativeIdentificationList;
    }

    private final static String loadSicListByEnvironmentalInterestIdSql = "SELECT ENVR_INTR_FAC_SIC_ID, "
        + " ENVR_INTR_ID, "
        + " SIC_CODE, "
        + " SIC_PRI_INDI "
        + " FROM FACID_ENVR_INTR_FAC_SIC WHERE ENVR_INTR_ID = ?";

    private final static String loadNaicsListByEnvironmentalInterestIdSql = "SELECT ENVR_INTR_FAC_NAICS_ID, "
        + " ENVR_INTR_ID, "
        + " FAC_NAICS_CODE, "
        + " FAC_NAICS_PRI_INDI "
        + " FROM FACID_ENVR_INTR_FAC_NAICS WHERE ENVR_INTR_ID = ?";

    private final static String loadElectronicAddressListByEnvironmentalInterestIdSql = "SELECT ENVR_INTR_ELEC_ADDR_ID, "
        + " ENVR_INTR_ID, "
        + " ELEC_ADDR_TEXT, "
        + " ELEC_ADDR_TYPE_NAME "
        + " FROM FACID_ENVR_INTR_ELEC_ADDR WHERE ENVR_INTR_ID = ?";

    private final static String loadAlternativeIdentificationListByEnvironmentalInterestIdSql = "SELECT ENVR_INTR_ALT_IDEN_ID, "
        + " ENVR_INTR_ID, "
        + " ALT_IDEN_IDEN, "
        + " ALT_IDEN_TYPE_TEXT "
        + " FROM FACID_ENVR_INTR_ALT_IDEN WHERE ENVR_INTR_ID = ?";

    private final static String loadEnvironmentalInterestsByFacilityIdSql = "select ENVR_INTR_ID, " 
        + " FAC_ID, "
        + " ENVR_INTR_IDEN, "
        + " ENVR_INTR_TYPE_TEXT, "
        + " ENVR_INTR_START_DATE, "
        + " ENVR_INTR_START_DATE_QUAL_TEXT, "
        + " ENVR_INTR_END_DATE, "
        + " ENVR_INTR_END_DATE_QUAL_TEXT, "
        + " ENVR_INTR_ACTIVE_INDI, "
        + " ENVR_INTR_URL_TEXT, "
        + " ORIG_PART_NAME, "
        + " INFO_SYS_ACRO_NAME, "
        + " LAST_UPDT_DATE, "
        + " AGN_TYPE_CODE, "
        + " AGN_TYPE_NAME, "
        + " CODE_LIST_VERS_IDEN, "
        + " CODE_LIST_VERS_AGN_IDEN, "
        + " CODE_LST_VER_VAL "
        + " FROM facid_envr_intr "
        + " WHERE FAC_ID = ?";
    public AffiliationListDataTypeDao getAffiliationListDataTypeDao()
    {
        return affiliationListDataTypeDao;
    }

    public void setAffiliationListDataTypeDao(AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        this.affiliationListDataTypeDao = affiliationListDataTypeDao;
    }
}

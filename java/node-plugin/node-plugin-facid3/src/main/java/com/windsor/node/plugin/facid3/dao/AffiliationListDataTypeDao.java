package com.windsor.node.plugin.facid3.dao;

import java.sql.Types;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.facid3.domain.AffiliationListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityAffiliationDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class AffiliationListDataTypeDao extends JdbcDaoSupport
{
    private Set<String> affiliationIds;

    public AffiliationListDataTypeDao()
    {
        setAffiliationIds(new HashSet<String>());
    }

    public void clearAffiliationIds()
    {
        setAffiliationIds(new HashSet<String>());
    }

    public AffiliationListDataType loadAffiliationListByEnvironmentalInterestId(String environmentalInterestId)
    {
        if(StringUtils.isBlank(environmentalInterestId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        AffiliationListDataType affiliationList = fact.createAffiliationListDataType();
        List<FacilityAffiliationDataType> results = (List<FacilityAffiliationDataType>)getJdbcTemplate()
                        .query(loadAffiliationListByEnvironmentalInterestIdSql, new Object[]{environmentalInterestId},
                               new int[]{Types.VARCHAR}, new FacilityAffiliationDataTypeRowMapper(getAffiliationIds()));
        affiliationList.getFacilityAffiliation().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return affiliationList;
    }

    public AffiliationListDataType loadAffiliationListByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        AffiliationListDataType affiliationList = fact.createAffiliationListDataType();
        List<FacilityAffiliationDataType> results = (List<FacilityAffiliationDataType>)getJdbcTemplate()
                        .query(loadAffiliationListByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilityAffiliationDataTypeRowMapper(getAffiliationIds()));
        affiliationList.getFacilityAffiliation().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return affiliationList;
    }

    private static final String loadAffiliationListByFacilityIdSql = "SELECT FAC_FAC_AFFL_ID, "
        + " FAC_ID, "
        + " AFFL_IDEN, "
        + " AFFL_TYPE_TEXT, "
        + " AFFL_START_DATE, "
        + " AFFL_END_DATE, "
        + " AFFL_STAT_TEXT, "
        + " AFFL_STAT_DETR_DATE "
        + " FROM FACID_FAC_FAC_AFFL WHERE FAC_ID = ? ";

    private static final String loadAffiliationListByEnvironmentalInterestIdSql = "SELECT ENVR_INTR_FAC_AFFL_ID, "
        + " ENVR_INTR_ID, "
        + " AFFL_IDEN, "
        + " AFFL_TYPE_TEXT, "
        + " AFFL_START_DATE, "
        + " AFFL_END_DATE, "
        + " AFFL_STAT_TEXT, "
        + " AFFL_STAT_DETR_DATE "
        + " FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID = ? ";

    public Set<String> getAffiliationIds()
    {
        return affiliationIds;
    }

    public void setAffiliationIds(Set<String> affiliationIds)
    {
        this.affiliationIds = affiliationIds;
    }
}

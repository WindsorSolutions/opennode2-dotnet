package com.windsor.node.plugin.facid3.dao;

import java.sql.Types;
import java.util.List;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.facid3.domain.AffiliateDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.TelephonicDataType;
import com.windsor.node.plugin.facid3.domain.TelephonicListDataType;

public class AffiliateDataTypeDao extends JdbcDaoSupport
{
    public AffiliateDataType loadAffiliateById(String affiliateId)
    {
        if(StringUtils.isBlank(affiliateId))
        {
            return null;
        }
        return (AffiliateDataType)getJdbcTemplate().queryForObject(loadAffiliateDataTypeByIdSql, new Object[]{affiliateId},
                                                                   new int[]{Types.VARCHAR}, new AffiliateDataTypeRowMapper(this));
    }

    public ElectronicAddressListDataType loadElectronicAddressesById(String affiliateId)
    {
        if(StringUtils.isBlank(affiliateId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        ElectronicAddressListDataType electronicAddressListDataType = fact.createElectronicAddressListDataType();
        @SuppressWarnings("unchecked")
        List<ElectronicAddressDataType> results = (List<ElectronicAddressDataType>)getJdbcTemplate()
                        .query(loadElectronicAddressListDataTypeByAffiliateIdSql, new Object[]{affiliateId},
                               new int[]{Types.VARCHAR}, new ElectronicAddressDataTypeRowMapper());
        electronicAddressListDataType.getElectronicAddress().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return electronicAddressListDataType;
    }

    public TelephonicListDataType loadTelephonicById(String affiliateId)
    {
        if(StringUtils.isBlank(affiliateId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        TelephonicListDataType telephonicListDataType = fact.createTelephonicListDataType();
        @SuppressWarnings("unchecked")
        List<TelephonicDataType> results = (List<TelephonicDataType>)getJdbcTemplate()
                        .query(loadTelephonicDataTypeByAffiliateIdSql, new Object[]{affiliateId},
                               new int[]{Types.VARCHAR}, new TelephonicDataTypeRowMapper());
        telephonicListDataType.getTelephonic().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return telephonicListDataType;
    }

    private static final String loadAffiliateDataTypeByIdSql = "SELECT AFFL_ID, "
        + " FAC_DTLS_ID, "
        + " AFFL_IDEN, "
        + " INDV_TITLE_TEXT, "
        + " NAME_PREFIX_TEXT, "
        + " INDV_FULL_NAME, "
        + " FIRST_NAME, "
        + " MIDDLE_NAME, "
        + " LAST_NAME, "
        + " NAME_SUFFIX_TEXT, "
        + " INDV_IDEN_CONT, "
        + " INDV_IDEN_VAL, "
        + " ORG_FORMAL_NAME, "
        + " ORG_IDEN_CONT, "
        + " ORG_IDEN_VAL, "
        + " MAIL_ADDR_TEXT, "
        + " SUPP_ADDR_TEXT, "
        + " MAIL_ADDR_CITY_NAME, "
        + " STA_CODE, "
        + " STA_NAME, "
        + " CODE_LIST_VERS_IDEN, "
        + " CODE_LIST_VERS_AGN_IDEN, "
        + " CODE_LST_VER_VAL, "
        + " ADDR_POST_CODE_CONT, "
        + " ADDR_POST_CODE_VAL, "
        + " CTRY_CODE, "
        + " CTRY_NAME, "
        + " CTRY_IDEN_CODE_LIST_VERS_IDEN, "
        + " CTRY_IDEN_CODE_LIS_VER_AGN_IDE, "
        + " CTRY_IDEN_CODE_LST_VER_VAL "
        + " FROM FACID_AFFL WHERE AFFL_IDEN = ? ";

    private static final String loadElectronicAddressListDataTypeByAffiliateIdSql = "SELECT AFFL_ELEC_ADDR_ID, "
        + " AFFL_ID "
        + " ELEC_ADDR_TEXT, "
        + " ELEC_ADDR_TYPE_NAME "
        + " FROM FACID_AFFL_ELEC_ADDR WHERE AFFL_ID = ?";
    private static final String loadTelephonicDataTypeByAffiliateIdSql = "SELECT TELEPHONIC_ID, "
        + " AFFL_ID "
        + " TELE_NUM_TEXT, "
        + " TELE_NUM_TYPE_NAME, "
        + " TELE_EXT_NUM_TEXT "
        + " FROM FACID_TELEPHONIC WHERE AFFL_ID = ?";
}

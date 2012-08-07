package com.windsor.node.plugin.facid3.dao;

import java.sql.Types;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.facid3.BaseFacIdGetFacilityService;
import com.windsor.node.plugin.facid3.BaseFacIdPlugin;
import com.windsor.node.plugin.facid3.GetDeletedFacilityByChangeDate;
import com.windsor.node.plugin.facid3.domain.AlternativeIdentificationDataType;
import com.windsor.node.plugin.facid3.domain.AlternativeIdentificationListDataType;
import com.windsor.node.plugin.facid3.domain.AlternativeNameDataType;
import com.windsor.node.plugin.facid3.domain.AlternativeNameListDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressDataType;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.FacilityGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.FacilityGeographicLocationListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.FacilityPrimaryGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryGeographicLocationDataType;
import com.windsor.node.plugin.facid3.domain.NAICSListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.SICListDataType;

public class FacilityDataTypeDao extends JdbcDaoSupport
{
    /* All the sql queries at bottom */
    private EnvironmentalInterestDataTypeDao environmentalInterestDao;

    public FacilityDataTypeDao(EnvironmentalInterestDataTypeDao environmentalInterestDao)
    {
        setEnvironmentalInterestDao(environmentalInterestDao);
    }

    public FacilityDataType loadFacilityById(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        return (FacilityDataType)getJdbcTemplate().queryForObject(loadFacilityDataTypeByIdSql, new Object[]{facilityId}, new int[]{Types.VARCHAR},
                                                          new FacilityDataTypeRowMapper(this, getEnvironmentalInterestDao(), getEnvironmentalInterestDao().getAffiliationListDataTypeDao()));
    }

    public FacilityInterestSummaryDataType loadFacilityInterestSummaryById(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        return (FacilityInterestSummaryDataType)getJdbcTemplate().queryForObject(loadFacilityDataTypeByIdSql, new Object[]{facilityId}, new int[]{Types.VARCHAR},
                                                          new FacilityInterestSummaryDataTypeRowMapper(this, getEnvironmentalInterestDao()));
    }

    public FacilitySummaryDataType loadFacilitySummaryById(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        return (FacilitySummaryDataType)getJdbcTemplate().queryForObject(loadFacilityDataTypeByIdSql, new Object[]{facilityId}, new int[]{Types.VARCHAR},
                                                          new FacilitySummaryDataTypeRowMapper(this));
    }

    public FacilitySummaryDataType loadDeletedFacilitySummaryById(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        return (FacilitySummaryDataType)getJdbcTemplate().queryForObject(loadDeletedFacilityDataTypeByIdSql, new Object[]{facilityId}, new int[]{Types.VARCHAR},
                                                          new DeletedFacilitySummaryDataTypeRowMapper());
    }

    public SICListDataType loadSicListByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        SICListDataType sicList = fact.createSICListDataType();
        @SuppressWarnings("unchecked")
        List<FacilitySICDataType> results = (List<FacilitySICDataType>)getJdbcTemplate()
                        .query(loadSicListByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilitySicDataTypeRowMapper());
        sicList.getFacilitySIC().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return sicList;
    }

    public NAICSListDataType loadNaicsListByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        NAICSListDataType naicsList = fact.createNAICSListDataType();
        @SuppressWarnings("unchecked")
        List<FacilityNAICSDataType> results = (List<FacilityNAICSDataType>)getJdbcTemplate()
                        .query(loadNaicsListByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilityNaicsDataTypeRowMapper());
        naicsList.getFacilityNAICS().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return naicsList;
    }

    @SuppressWarnings("unchecked")
    public List<String> loadAllFacilityIdsByParams(Map<String, Object> params)
    {
        StringBuffer sql = new StringBuffer();
        List<Object> args = new ArrayList<Object>();
        List<Integer> types = new ArrayList<Integer>();
        sql.append(loadAllFacilityDataTypeIdsSql);

        if(params.get(BaseFacIdGetFacilityService.STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName());
            sql.append(" AND  (");
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(" OR ");
                }
                sql.append(" UPPER(ei.envr_intr_type_text) like ");
                if(i != 0)
                {
                    sql.append(", ");
                }
                sql.append("?");
                String param = items.get(i);
                if(param.length() > 5)
                {
                    param = param.substring(0, 5);
                }
                param += "%";//add wildcard
                args.add(param.toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(" ) ");
        }
        if(params.get(BaseFacIdGetFacilityService.ZIP_CODE.getName()) != null)
        {
            //List, of starts with, parsing out the 4 digit codes, if they exist, everything is STARTS WITH according to the spec
            //so add wild cards
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.ZIP_CODE.getName());
            sql.append(" AND  (");
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(" OR ");
                }
                sql.append(" UPPER(f.addr_post_code_val) like ");
                if(i != 0)
                {
                    sql.append(", ");
                }
                sql.append("?");
                String param = items.get(i);
                if(param.length() > 5)
                {
                    param = param.substring(0, 5);
                }
                param += "%";//add wildcard
                args.add(param.toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(" ) ");
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.TRIBAL_LAND_CODE.getName())))
        {
            sql.append(" AND UPPER(f.trib_land_indi) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.TRIBAL_LAND_CODE.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.FEDERAL_FACILITY.getName())))
        {
            sql.append(" AND UPPER(f.fed_fac_indi) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.FEDERAL_FACILITY.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.FACILITY_NAME.getName())))
        {
            sql.append(" AND UPPER(f.fac_site_name) like ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.FACILITY_NAME.getName())).toUpperCase());//Do a straight pass through, which probably means _ won't be supported, but % will be
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.FACILITY_STATUS.getName())))
        {
            sql.append(" AND UPPER(f.fac_active_indi) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.FACILITY_STATUS.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(params.get(BaseFacIdGetFacilityService.SIC_CODE.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.SIC_CODE.getName());
            if(items.size() > 0)
            {
                sql.append(" AND (");
            }
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(" OR ");
                }
                sql.append(" fsic.sic_code LIKE ? ");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
                sql.append(" OR eisic.sic_code like ? ");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(")");
        }
        if(params.get(BaseFacIdGetFacilityService.NAICS_CODE.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.NAICS_CODE.getName());
            if(items.size() > 0)
            {
                sql.append(" AND (");
            }
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(" OR ");
                }
                sql.append(" fnaics.fac_naics_code LIKE ? ");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
                sql.append(" OR einaics.fac_naics_code like ? ");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(")");
        }
        if(params.get(BaseFacIdGetFacilityService.CITY_NAME.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.CITY_NAME.getName());
            sql.append(" AND UPPER(f.loca_name) in (");
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(", ");
                }
                sql.append("?");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(" ) ");
        }
        if(params.get(BaseFacIdGetFacilityService.STATE.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.STATE.getName());
            sql.append(" AND UPPER(f.sta_code) in (");
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(", ");
                }
                sql.append("?");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(" ) ");
        }
        if(params.get(BaseFacIdGetFacilityService.COUNTY_NAME.getName()) != null)
        {
            List<String> items = (List<String>)params.get(BaseFacIdGetFacilityService.COUNTY_NAME.getName());
            sql.append(" AND UPPER(f.cnty_code) in (");//might be cnty_name, but that field is much longer than max size of each param, listed as 35 characters
            for(int i = 0; i < items.size(); i++)
            {
                if(i != 0)
                {
                    sql.append(", ");
                }
                sql.append("?");
                args.add(items.get(i).toUpperCase());
                types.add(Types.VARCHAR);
            }
            sql.append(" ) ");
        }
        if(params.get(BaseFacIdGetFacilityService.N_BOUNDING_LAT.getName()) != null)//if one exists, they all do
        {
            sql.append(" AND pg.latitude <= ? ");
            args.add((Double)params.get(BaseFacIdGetFacilityService.N_BOUNDING_LAT.getName()));
            types.add(Types.NUMERIC);

            sql.append(" AND pg.latitude >= ? ");
            args.add((Double)params.get(BaseFacIdGetFacilityService.S_BOUNDING_LAT.getName()));
            types.add(Types.NUMERIC);

            sql.append(" AND pg.longitude <= ? ");
            args.add((Double)params.get(BaseFacIdGetFacilityService.W_BOUNDING_LONG.getName()));
            types.add(Types.NUMERIC);

            sql.append(" AND pg.longitude >= ? ");
            args.add((Double)params.get(BaseFacIdGetFacilityService.E_BOUNDING_LONG.getName()));
            types.add(Types.NUMERIC);
        }
        //the following support GetFacilityByID and GetFacilityByChangeDate
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.FACILITY_SITE_IDENTIFIER.getName())))
        {
            sql.append(" AND UPPER(f.fac_site_iden_val) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.FACILITY_SITE_IDENTIFIER.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.ORIGINATING_PARTNER_NAME.getName())))
        {
            sql.append(" AND UPPER(f.orig_part_name) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.ORIGINATING_PARTNER_NAME.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdGetFacilityService.INFO_SYSTEM_ACORNYM_NAME.getName())))
        {
            sql.append(" AND UPPER(f.info_sys_acro_name) = ? ");
            args.add(((String)params.get(BaseFacIdGetFacilityService.INFO_SYSTEM_ACORNYM_NAME.getName())).toUpperCase());
            types.add(Types.VARCHAR);
        }
        if(params.get(BaseFacIdGetFacilityService.CHANGE_DATE.getName()) != null)
        {
            sql.append(" AND f.last_updt_date >= ? ");
            args.add(params.get(BaseFacIdGetFacilityService.CHANGE_DATE.getName()));
            types.add(Types.DATE);
        }
        return (List<String>)getJdbcTemplate().queryForList(sql.toString(), args.toArray(),
                                                            ArrayUtils.toPrimitive(types.toArray(new Integer[types.size()])), String.class);
    }

    @SuppressWarnings("unchecked")
    public List<String> loadAllDeletedFacilityIdsByParams(Map<String, Object> params)
    {
        StringBuffer sql = new StringBuffer();
        List<Object> args = new ArrayList<Object>();
        List<Integer> types = new ArrayList<Integer>();
        sql.append(loadAllDeletedFacilityDataTypeIdsSql);
        if(params.get(BaseFacIdPlugin.CHANGE_DATE.getName()) != null)
        {
            sql.append(" AND LAST_UPDT_DATE > ? ");
            args.add(params.get(BaseFacIdPlugin.CHANGE_DATE.getName()));
            types.add(Types.DATE);
        }
        if(StringUtils.isNotBlank((String)params.get(BaseFacIdPlugin.ORIGINATING_PARTNER_NAME.getName())))
        {
            sql.append(" AND UPPER(ORIG_PART_NAME) = UPPER(?) ");
            args.add(params.get(BaseFacIdPlugin.ORIGINATING_PARTNER_NAME.getName()));
            types.add(Types.VARCHAR);
        }
        if(StringUtils.isNotBlank((String)params.get(GetDeletedFacilityByChangeDate.INFO_SYSTEM_ACORNYM_NAME.getName())))
        {
            sql.append(" AND UPPER(INFO_SYS_ACRO_NAME) = UPPER(?) ");
            args.add(params.get(BaseFacIdPlugin.INFO_SYSTEM_ACORNYM_NAME.getName()));
            types.add(Types.VARCHAR);
        }
        return (List<String>)getJdbcTemplate().queryForList(sql.toString(), args.toArray(),
                                                            ArrayUtils.toPrimitive(types.toArray(new Integer[types.size()])), String.class);
    }

    public FacilityPrimaryGeographicLocationDescriptionDataType loadPrimaryGeoLocationByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        @SuppressWarnings("unchecked")
        List<FacilityPrimaryGeographicLocationDescriptionDataType> results = (List<FacilityPrimaryGeographicLocationDescriptionDataType>)getJdbcTemplate()
                        .query(loadFacilityPrimaryGeographicLocationDataTypeByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilityPrimaryGeographicLocationDescriptionDataTypeRowMapper(this));
        if(results == null || results.size() < 1)
        {
            return null;
        }
        return results.get(0);
    }

    public FacilitySummaryGeographicLocationDataType loadFacilitySummaryGeographicLocationByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        @SuppressWarnings("unchecked")
        List<FacilitySummaryGeographicLocationDataType> results = (List<FacilitySummaryGeographicLocationDataType>)getJdbcTemplate()
                        .query(loadFacilityPrimaryGeographicLocationDataTypeByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilitySummaryGeographicLocationDataTypeRowMapper(this));
        if(results == null || results.size() < 1)
        {
            return null;
        }
        return results.get(0);
    }

    public FacilityGeographicLocationListDataType loadGeoLocationByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        FacilityGeographicLocationListDataType facilityGeographicLocationList = fact.createFacilityGeographicLocationListDataType();
        @SuppressWarnings("unchecked")
        List<FacilityGeographicLocationDescriptionDataType> results = (List<FacilityGeographicLocationDescriptionDataType>)getJdbcTemplate()
                        .query(loadFacilityGeographicLocationDataTypeByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new FacilityGeographicLocationDescriptionDataTypeRowMapper(this));
        facilityGeographicLocationList.getFacilityGeographicLocationDescription().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return facilityGeographicLocationList;
    }

    public AlternativeNameListDataType loadAlternativeNamesByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        AlternativeNameListDataType alternativeNameList = fact.createAlternativeNameListDataType();
        @SuppressWarnings("unchecked")
        List<AlternativeNameDataType> results = (List<AlternativeNameDataType>)getJdbcTemplate()
                        .query(loadAlternativeNamesByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new AlternativeNameDataTypeRowMapper());
        alternativeNameList.getAlternativeName().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return alternativeNameList;
    }

    public ElectronicAddressListDataType loadElectronicAddressListByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        ElectronicAddressListDataType electronicAddressList = fact.createElectronicAddressListDataType();
        @SuppressWarnings("unchecked")
        List<ElectronicAddressDataType> results = (List<ElectronicAddressDataType>)getJdbcTemplate()
                        .query(loadElectronicAddressListByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new ElectronicAddressDataTypeRowMapper());
        electronicAddressList.getElectronicAddress().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return electronicAddressList;
    }

    public AlternativeIdentificationListDataType loadAlternativeIdentificationListByFacilityId(String facilityId)
    {
        if(StringUtils.isBlank(facilityId))
        {
            return null;
        }
        ObjectFactory fact = new ObjectFactory();
        AlternativeIdentificationListDataType alternativeIdentificationList = fact.createAlternativeIdentificationListDataType();
        @SuppressWarnings("unchecked")
        List<AlternativeIdentificationDataType> results = (List<AlternativeIdentificationDataType>)getJdbcTemplate()
                        .query(loadAlternativeIdentificationListByFacilityIdSql, new Object[]{facilityId},
                               new int[]{Types.VARCHAR}, new AlternativeIdentificationDataTypeRowMapper());
        alternativeIdentificationList.getAlternativeIdentification().addAll(results);
        if(results == null || results.size() == 0)
        {
            return null;
        }
        return alternativeIdentificationList;
    }

    private final static String loadAlternativeIdentificationListByFacilityIdSql = "SELECT FAC_ALT_IDEN_ID, "
        + " FAC_ID, "
        + " ALT_IDEN_IDEN, "
        + " ALT_IDEN_TYPE_TEXT "
        + " FROM FACID_FAC_ALT_IDEN WHERE FAC_ID = ?";

    private final static String loadElectronicAddressListByFacilityIdSql = "SELECT FAC_ELEC_ADDR_ID, "
        + " FAC_ID, "
        + " ELEC_ADDR_TEXT, "
        + " ELEC_ADDR_TYPE_NAME "
        + " FROM FACID_FAC_ELEC_ADDR WHERE FAC_ID = ?";

    private static final String loadAllFacilityDataTypeIdsSql = "Select distinct f.fac_id from FACID_FAC f " 
        + " left join FACID_ENVR_INTR ei on f.fac_id = ei.fac_id "
        + " left join FACID_FAC_FAC_SIC fsic on f.fac_id = fsic.fac_id "
        + " left join FACID_FAC_FAC_NAICS fnaics on f.fac_id = fnaics.fac_id "
        + " left join FACID_ENVR_INTR_FAC_SIC eisic on ei.envr_intr_id = eisic.envr_intr_id "
        + " left join FACID_ENVR_INTR_FAC_NAICS einaics on ei.envr_intr_id = einaics.envr_intr_id "
        + " left join FACID_FAC_PRI_GEO_LOC_DESC pg on f.fac_id = pg.fac_id "
        + " where 1=1 ";
    private static final String loadAllDeletedFacilityDataTypeIdsSql = "Select fac_site_iden_val from FACID_FAC_DEL WHERE 1=1 ";

    private static final String loadAlternativeNamesByFacilityIdSql = "SELECT FAC_ID, ALT_NAME_TEXT, ALT_NAME_TYPE_TEXT FROM FACID_ALT_NAME WHERE FAC_ID = ?";

    private static final String loadFacilityDataTypeByIdSql = "SELECT FAC_ID, "
    	+ " FAC_DTLS_ID, "
        + " CONG_DIST_NUM_CODE, "
        + " LEGI_DIST_NUM_CODE, "
        + " HUC_CODE, "
        + " FAC_URL_TEXT, "
        + " DELETED_ON_DATE, "
        + " FAC_ACTIVE_INDI, "
        + " FAC_SITE_NAME, "
        + " FED_FAC_INDI, "
        + " FAC_SITE_IDEN_CONT, "
        + " FAC_SITE_IDEN_VAL, "
        + " FAC_SITE_TYPE_CODE, "
        + " FAC_SITE_TYPE_NAME, "
        + " CODE_LIST_VERS_IDEN, "
        + " CODE_LIST_VERS_AGN_IDEN, "
        + " CODE_LST_VER_VAL, "
        + " LOC_ADDR_TEXT, "
        + " SUPP_LOC_TEXT, "
        + " LOCA_NAME, "
        + " TRIB_LAND_NAME, "
        + " TRIB_LAND_INDI, "
        + " LOC_DESC_TEXT, "
        + " STA_CODE, "
        + " STA_NAME, "
        + " LOC_ADDR_CODE_LST_VER_VAL, "
        + " LOC_ADDR_CODE_LIST_VERS_IDEN, "
        + " LOC_ADDR_CODE_LIST_VER_AGN_IDE, "
        + " ADDR_POST_CODE_VAL, "
        + " ADDR_POST_CODE_CONT, "
        + " CTRY_CODE, "
        + " CTRY_NAME, "
        + " LOC_ADDR_COD_LST_VER_VAL, "
        + " LOC_ADDR_CODE_LIST_VERS_IDE, "
        + " LOC_ADDR_CODE_LIS_VER_AGN_IDE, "
        + " CNTY_CODE, "
        + " CNTY_NAME, "
        + " LOC_ADDR_CODE_LIST_VER_IDE, "
        + " LOC_ADDR_COD_LIS_VER_AGN_IDE, "
        + " LOC_ADD_COD_LST_VER_VAL, "
        + " MAIL_ADDR_TEXT, "
        + " SUPP_ADDR_TEXT, "
        + " MAIL_ADDR_CITY_NAME, "
        + " MAIL_ADDR_STA_CODE, "
        + " MAIL_ADDR_STA_NAME, "
        + " MAIL_ADDR_CODE_LST_VER_VAL, "
        + " MAIL_ADDR_CODE_LIST_VERS_IDEN, "
        + " MAIL_ADDR_CODE_LIS_VER_AGN_IDE, "
        + " MAIL_ADDR_ADDR_POST_CODE_VAL, "
        + " MAIL_ADDR_ADDR_POST_CODE_CONT, "
        + " MAIL_ADDR_CTRY_CODE, "
        + " MAIL_ADDR_CTRY_NAME, "
        + " MAIL_ADDR_COD_LST_VER_VAL, "
        + " MAIL_ADDR_CODE_LIST_VERS_IDE, "
        + " MAIL_ADDR_COD_LIS_VER_AGN_IDE, "
        + " ORIG_PART_NAME, "
        + " INFO_SYS_ACRO_NAME, "
        + " LAST_UPDT_DATE "
        + " FROM FACID_FAC WHERE FACID_FAC.FAC_ID = ?";

    private static final String loadFacilityPrimaryGeographicLocationDataTypeByFacilityIdSql = "SELECT FAC_ID, " 
        + " SRC_MAP_SCALE_NUM, "
        + " DATA_COLL_DATE, "
        + " LOC_COMM_TEXT, "
        + " SRS_NAME, "
        + " SRS_DIM, "
        + " LATITUDE, "
        + " LONGITUDE, "
        + " ELEVATION, "
        + " MEAS_VAL, "
        + " MEAS_PREC_TEXT, "
        + " MEAS_UNIT_CODE, "
        + " MEAS_UNIT_NAME, "
        + " CODE_LIST_VERS_IDEN, "
        + " CODE_LIST_VERS_AGN_IDEN, "
        + " CODE_LST_VER_VAL, "
        + " RSLT_QUAL_CODE, "
        + " RSLT_QUAL_NAME, "
        + " RSLT_QUAL_CODE_LIST_VERS_IDEN, "
        + " RSLT_QUAL_CODE_LIS_VER_AGN_IDE, "
        + " RSLT_QUAL_CODE_LST_VER_VAL, "
        + " METH_IDEN_CODE, "
        + " METH_NAME, "
        + " METH_DESC_TEXT, "
        + " METH_DEVI_TEXT, "
        + " HORZ_COLL_METH_COD_LIS_VER_IDE, "
        + " HOR_COL_MET_COD_LIS_VER_AGN_ID, "
        + " HORZ_COLL_METH_COD_LST_VER_VAL, "
        + " GEO_REF_PT_CODE, "
        + " GEO_REF_PT_NAME, "
        + " GEO_REF_PT_CODE_LIST_VERS_IDEN, "
        + " GEO_REF_PT_COD_LIS_VER_AGN_IDE, "
        + " GEO_REF_PT_CODE_LST_VER_VAL, "
        + " VERT_COLL_METH_METH_IDEN_CODE, "
        + " VERT_COLL_METH_METH_NAME, "
        + " VERT_COLL_METH_METH_DESC_TEXT, "
        + " VERT_COLL_METH_METH_DEVI_TEXT, "
        + " VERT_COLL_METH_COD_LST_VER_VAL, "
        + " VERT_COLL_METH_COD_LIS_VER_IDE, "
        + " VER_COL_MET_COD_LIS_VER_AGN_ID, "
        + " VERF_METH_METH_IDEN_CODE, "
        + " VERF_METH_METH_NAME, "
        + " VERF_METH_METH_DESC_TEXT, "
        + " VERF_METH_METH_DEVI_TEXT, "
        + " VERF_METH_CODE_LST_VER_VAL, "
        + " VERF_METH_CODE_LIST_VERS_IDEN, "
        + " VERF_METH_CODE_LIS_VER_AGN_IDE, "
        + " CORD_DATA_SRC_CODE, "
        + " CORD_DATA_SRC_NAME, "
        + " CORD_DATA_SRC_CODE_LIS_VER_IDE, "
        + " COR_DAT_SRC_COD_LIS_VER_AGN_ID, "
        + " CORD_DATA_SRC_CODE_LST_VER_VAL "
        + " FROM FACID_FAC_PRI_GEO_LOC_DESC "
        + " WHERE FAC_ID = ?";

    private static final String loadFacilityGeographicLocationDataTypeByFacilityIdSql = "SELECT FAC_ID, " 
        + " SRC_MAP_SCALE_NUM, "
        + " DATA_COLL_DATE, "
        + " LOC_COMM_TEXT, "
        + " SRS_NAME, "
        + " SRS_DIM, "
        + " LATITUDE, "
        + " LONGITUDE, "
        + " ELEVATION, "
        + " MEAS_VAL, "
        + " MEAS_PREC_TEXT, "
        + " MEAS_UNIT_CODE, "
        + " MEAS_UNIT_NAME, "
        + " CODE_LIST_VERS_IDEN, "
        + " CODE_LIST_VERS_AGN_IDEN, "
        + " CODE_LST_VER_VAL, "
        + " RSLT_QUAL_CODE, "
        + " RSLT_QUAL_NAME, "
        + " RSLT_QUAL_CODE_LIST_VERS_IDEN, "
        + " RSLT_QUAL_CODE_LIS_VER_AGN_IDE, "
        + " RSLT_QUAL_CODE_LST_VER_VAL, "
        + " METH_IDEN_CODE, "
        + " METH_NAME, "
        + " METH_DESC_TEXT, "
        + " METH_DEVI_TEXT, "
        + " HORZ_COLL_METH_COD_LIS_VER_IDE, "
        + " HOR_COL_MET_COD_LIS_VER_AGN_ID, "
        + " HORZ_COLL_METH_COD_LST_VER_VAL, "
        + " GEO_REF_PT_CODE, "
        + " GEO_REF_PT_NAME, "
        + " GEO_REF_PT_CODE_LIST_VERS_IDEN, "
        + " GEO_REF_PT_COD_LIS_VER_AGN_IDE, "
        + " GEO_REF_PT_CODE_LST_VER_VAL, "
        + " VERT_COLL_METH_METH_IDEN_CODE, "
        + " VERT_COLL_METH_METH_NAME, "
        + " VERT_COLL_METH_METH_DESC_TEXT, "
        + " VERT_COLL_METH_METH_DEVI_TEXT, "
        + " VERT_COLL_METH_COD_LST_VER_VAL, "
        + " VERT_COLL_METH_COD_LIS_VER_IDE, "
        + " VER_COL_MET_COD_LIS_VER_AGN_ID, "
        + " VERF_METH_METH_IDEN_CODE, "
        + " VERF_METH_METH_NAME, "
        + " VERF_METH_METH_DESC_TEXT, "
        + " VERF_METH_METH_DEVI_TEXT, "
        + " VERF_METH_CODE_LST_VER_VAL, "
        + " VERF_METH_CODE_LIST_VERS_IDEN, "
        + " VERF_METH_CODE_LIS_VER_AGN_IDE, "
        + " CORD_DATA_SRC_CODE, "
        + " CORD_DATA_SRC_NAME, "
        + " CORD_DATA_SRC_CODE_LIS_VER_IDE, "
        + " COR_DAT_SRC_COD_LIS_VER_AGN_ID, "
        + " CORD_DATA_SRC_CODE_LST_VER_VAL "
        + " FROM FACID_FAC_GEO_LOC_DESC "
        + " WHERE FAC_ID = ?";

    private final static String loadDeletedFacilityDataTypeByIdSql = "SELECT FAC_SITE_IDEN_VAL, " 
        + " FAC_SITE_IDEN_CONT, "
        + " FAC_SITE_NAME, " 
        + " INFO_SYS_ACRO_NAME, " 
        + " ORIG_PART_NAME, " 
        + " DELETED_ON_DATE, "
        + " LAST_UPDT_DATE "
        + " FROM FACID_FAC_DEL WHERE FAC_SITE_IDEN_VAL = ?";

    private final static String loadSicListByFacilityIdSql = "SELECT FAC_FAC_SIC_ID, "
        + " FAC_ID, "
        + " SIC_CODE, "
        + " SIC_PRI_INDI "
        + " FROM FACID_FAC_FAC_SIC WHERE FAC_ID = ?";

    private final static String loadNaicsListByFacilityIdSql = "SELECT FAC_FAC_NAICS_ID, "
        + " FAC_ID, "
        + " FAC_NAICS_CODE, "
        + " FAC_NAICS_PRI_INDI "
        + " FROM FACID_FAC_FAC_NAICS WHERE FAC_ID = ?";

    public EnvironmentalInterestDataTypeDao getEnvironmentalInterestDao()
    {
        return environmentalInterestDao;
    }

    public void setEnvironmentalInterestDao(EnvironmentalInterestDataTypeDao environmentalInterestDao)
    {
        this.environmentalInterestDao = environmentalInterestDao;
    }
}

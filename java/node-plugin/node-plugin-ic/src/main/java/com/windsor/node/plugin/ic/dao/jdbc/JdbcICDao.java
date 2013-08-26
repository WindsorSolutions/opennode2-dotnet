package com.windsor.node.plugin.ic.dao.jdbc;

import java.sql.Types;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.ic.GetICDataByChangeDate;
import com.windsor.node.plugin.ic.dao.ICDao;

public class JdbcICDao extends JdbcDaoSupport implements ICDao
{
    private String instrumentIdsByCriteriaSql = "select IC_INSTR_ID from IC_INSTR where LAST_UPDATED_DATE >= ?";
    private String affiliateIdsByCriteriaSql = "select IC_AFFIL_ID from IC_AFFIL where LAST_UPDATED_DATE >= ?";
    private String locationIdsByCriteriaSql = "select IC_LOC_ID from IC_LOC where LAST_UPDATED_DATE >= ?";

    public JdbcICDao(DataSource dataSource)
    {
        setDataSource(dataSource);
    }

    public List<String> findIntrumentIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findIntrumentIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }
        if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) == null)
        {
            throw new IllegalArgumentException(
                            "JdbcICDao method findIntrumentIdsByCriteria parameter Map<String, Object> params was missing a required value:  "
                                            + GetICDataByChangeDate.CHANGE_DATE.getName() + ".");
        }
        return getJdbcTemplate().queryForList(instrumentIdsByCriteriaSql, new Object[]{params.get(GetICDataByChangeDate.CHANGE_DATE.getName())},
                                              new int[]{Types.DATE}, String.class);
    }

    public List<String> findAffiliateIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findAffiliateIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }
        if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) == null)
        {
            throw new IllegalArgumentException(
                            "JdbcICDao method findAffiliateIdsByCriteria parameter Map<String, Object> params was missing a required value:  "
                                            + GetICDataByChangeDate.CHANGE_DATE.getName() + ".");
        }
        return getJdbcTemplate().queryForList(affiliateIdsByCriteriaSql, new Object[]{params.get(GetICDataByChangeDate.CHANGE_DATE.getName())},
                                              new int[]{Types.DATE}, String.class);
    }

    public List<String> findLocationIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findLocationIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }
        if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) == null)
        {
            throw new IllegalArgumentException(
                            "JdbcICDao method findLocationIdsByCriteria parameter Map<String, Object> params was missing a required value:  "
                                            + GetICDataByChangeDate.CHANGE_DATE.getName() + ".");
        }
        return getJdbcTemplate().queryForList(locationIdsByCriteriaSql, new Object[]{params.get(GetICDataByChangeDate.CHANGE_DATE.getName())},
                                              new int[]{Types.DATE}, String.class);
    }
}

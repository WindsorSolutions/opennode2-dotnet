package com.windsor.node.plugin.ic.dao.jdbc;

import java.math.BigDecimal;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import javax.sql.DataSource;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.ic.GetICDataByBoundingBox;
import com.windsor.node.plugin.ic.GetICDataByChangeDate;
import com.windsor.node.plugin.ic.GetICDataByParameters;
import com.windsor.node.plugin.ic.dao.ICDao;

public class JdbcICDao extends JdbcDaoSupport implements ICDao
{
    private String instrumentIdsByCriteriaSql = "select inst.IC_INSTR_ID from IC_INSTR inst "
                    + " left join IC_INSTR_LOC il on il.IC_INSTR_ID = inst.IC_INSTR_ID "
                    + " left join IC_LOC loc on loc.LOC_IDEN = il.LOC_IDEN "
                    + " left join IC_FAC fac on fac.IC_LOC_ID = loc.IC_LOC_ID "
                    + " left join IC_USE_RSTCT use on use.IC_INSTR_ID = inst.IC_INSTR_ID "
                    + " where 1=1 ";
    private String affiliateIdsByCriteriaSql = "select affil.IC_AFFIL_ID from IC_INSTR inst "
                    + " inner join IC_INSTR_AFFIL ia on ia.IC_INSTR_ID = inst.IC_INSTR_ID "
                    + " inner join IC_AFFIL affil on affil.affil_iden = ia.affil_iden "
                    + " where 1=1 ";
    private String locationIdsByCriteriaSql = "select loc.IC_LOC_ID from IC_INSTR inst "
                    + " inner join IC_INSTR_LOC il on il.IC_INSTR_ID = inst.IC_INSTR_ID "
                    + " inner join IC_LOC loc on loc.LOC_IDEN = il.LOC_IDEN "
                    + " where 1=1 ";

    private String orderBySql = " ORDER BY inst.INSTR_IDEN ";

    private String instrumentIdsByBoundingBoxSelect = "SELECT inst.IC_INSTR_ID FROM IC_INSTR inst ";
    private String instrumentIdsByBoundingBoxSelectPolygon = "SELECT inst.IC_INSTR_ID, poly.lat, poly.lon FROM IC_INSTR inst ";
    private String instrumentIdsByBoundingBoxSelectJoins = " inner join IC_INSTR_LOC il on il.IC_INSTR_ID = inst.IC_INSTR_ID "
                    + " inner join IC_LOC loc on loc.LOC_IDEN = il.LOC_IDEN "
                    + " inner join IC_GEO_LOC_DESC geoloc on loc.ic_loc_id = geoloc.ic_loc_id ";
    private String instrumentIdsByBoundBoxSelectPolygonJoin = " inner join IC_LAT_LON_POLYGON poly on poly.IC_GEO_LOC_DESC_ID = geoloc.IC_GEO_LOC_DESC_ID ";
    private String coordinateWhereClause = " WHERE 1=1 "
                    + " and ( "
                    + "         ( "
                    + "             geoloc.PT_LAT < ? and geoloc.PT_LON < ? "//-- maxlat, maxlon 
                    + "             and geoloc.PT_LAT > ? and geoloc.PT_LON > ?  "//-- minlat, minlon
                    + "         ) "
                    + "         or "
                    + "         ( "
                    + "             (geoloc.ENVELOPE_UPPER_LAT < ? and geoloc.ENVELOPE_UPPER_LON < ?  "//-- maxlat, maxlon
                    + "             and geoloc.ENVELOPE_UPPER_LAT > ? and geoloc.ENVELOPE_UPPER_LON > ?)  "//-- minlat, minlon
                    + "             or (geoloc.ENVELOPE_LOWER_LAT < ? and geoloc.ENVELOPE_LOWER_LON < ?  "//-- maxlat, maxlon
                    + "             and geoloc.ENVELOPE_LOWER_LAT > ? and geoloc.ENVELOPE_LOWER_LON > ?)  "//-- minlat, minlon
                    + "         ) "
                    + "         or "
                    + "         ( "
                    + "             (geoloc.LINE_START_LAT < ? and geoloc.LINE_START_LON < ?  "//-- maxlat, maxlon
                    + "             and geoloc.LINE_START_LAT > ? and geoloc.LINE_START_LON > ?)  "//-- minlat, minlon
                    + "             or (geoloc.LINE_END_LAT < ? and geoloc.LINE_START_LON < ?  "//-- maxlat, maxlon
                    + "             and geoloc.LINE_END_LAT > ? and geoloc.LINE_END_LON > ?) "//-- minlat, minlon 
                    + "         ) "
                    + "     )";

    public JdbcICDao(DataSource dataSource)
    {
        setDataSource(dataSource);
    }

    @SuppressWarnings("unchecked")
    public List<String> findIntrumentIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findIntrumentIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }

        List<Object> sqlParams = new ArrayList<Object>();
        List<Integer> sqlTypes = new ArrayList<Integer>();
        StringBuffer sql = new StringBuffer(instrumentIdsByCriteriaSql);
        if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) != null)
        {
            sql.append(" AND inst.LAST_UPDATED_DATE >= ? ");
            sqlParams.add(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()));
            sqlTypes.add(Types.DATE);
        }
        if(params.get(GetICDataByParameters.INSTRUMENT_IDENTIFIER.getName()) != null)
        {
            //inst.INSTR_IDEN
            addInClause((List<String>)params.get(GetICDataByParameters.INSTRUMENT_IDENTIFIER.getName()), sql, sqlParams, sqlTypes, "inst.INSTR_IDEN",
                        Types.VARCHAR);
        }
        if(params.get(GetICDataByParameters.FACILITY_IDENTIFIER.getName()) != null)
        {
            //IC_FAC.FAC_SITE_IDEN_VALUE = fac.FAC_SITE_IDEN_VALUE
            addInClause((List<String>)params.get(GetICDataByParameters.FACILITY_IDENTIFIER.getName()), sql, sqlParams, sqlTypes, "fac.FAC_SITE_IDEN_VALUE",
                        Types.VARCHAR);
        }
        if(params.get(GetICDataByParameters.FACILITY_SITE_NAME.getName()) != null)
        {
            //IC_FAC.FAC_SITE_NAME = fac.FAC_SITE_NAME
            addInClause((List<String>)params.get(GetICDataByParameters.FACILITY_SITE_NAME.getName()), sql, sqlParams, sqlTypes, "fac.FAC_SITE_NAME",
                        Types.VARCHAR);
        }
        if(params.get(GetICDataByParameters.USE_RESTRICTION_TYPE_CODE.getName()) != null)
        {
            //IC_USE_RSTCT.USE_RSTCT_CODE = use.USE_RSTCT_CODE
            addInClause((List<String>)params.get(GetICDataByParameters.USE_RESTRICTION_TYPE_CODE.getName()), sql, sqlParams, sqlTypes,
                        "use.USE_RSTCT_CODE", Types.VARCHAR);
        }

        sql.append(orderBySql);

        List<String> matches = getJdbcTemplate().queryForList(sql.toString(),
                                                              sqlParams.toArray(),
                                                              createIntArray(sqlTypes), String.class);
        //easy way to get "DISTINCT" while retaining order and not having to select the ORDER BY clause
        matches = new ArrayList<String>(new LinkedHashSet<String>(matches));

        List<String> geoLocationIdMatches = new ArrayList<String>();

        List<String> intersectionMatches = new ArrayList<String>();
        if(params.get(GetICDataByBoundingBox.BOUNDING_COORDINATE_NORTH.getName()) != null)
        {
            geoLocationIdMatches = findInstrumentIdsByBoundingBox(params);
        }
        else
        {
            intersectionMatches = matches;
        }

        //Do an intersection of all matches
        if(geoLocationIdMatches != null && geoLocationIdMatches.size() > 0)
        {
            for(int i = 0; i < matches.size(); i++)
            {
                if(geoLocationIdMatches.contains(matches.get(i)))
                {
                    intersectionMatches.add(matches.get(i));
                }
            }
        }

        //Now apply maxRows and rowId requests, doing it in SQL and database agnostically is a nightmare compared to this.
        if(params.get("rowId") != null && params.get("maxRows") == null)
        {
            Integer rowId = new Integer((Integer)params.get("rowId") - 1);//reduce by one so it's a 0 based count to match the List
            List<String> restrictedMatches = new ArrayList<String>();
            if(rowId <= intersectionMatches.size())
            {
                for(int i = rowId; i < intersectionMatches.size(); i++)
                {
                    restrictedMatches.add(intersectionMatches.get(i));
                }
                intersectionMatches = restrictedMatches;
            }
        }
        if(params.get("maxRows") != null)
        {
            Integer rowId = new Integer((Integer)params.get("rowId") - 1);//reduce by one so it's a 0 based count to match the List
            Integer maxRows = new Integer((Integer)params.get("maxRows") - 1);//reduce by one so it's a 0 based count to match the List
            List<String> restrictedMatches = new ArrayList<String>();
            if((rowId+maxRows) <= intersectionMatches.size())
            {
                for(int i = rowId; i <= (rowId+maxRows); i++)
                {
                    restrictedMatches.add(intersectionMatches.get(i));
                }
                intersectionMatches = restrictedMatches;
            }
                
        }

        return intersectionMatches;
    }

    private int[] createIntArray(List<Integer> sqlTypes)
    {
        int[] sqlTypes2 = new int[sqlTypes.size()];
        for(int i = 0; i < sqlTypes.size(); i++)
        {
            sqlTypes2[i] = sqlTypes.get(i);
        }
        return sqlTypes2;
    }

    private void addInClause(List<String> matches, StringBuffer sql, List<Object> sqlParams, List<Integer> sqlTypes, String fieldName, int argumentType)
    {
       /* StringBuffer inClause = new StringBuffer();
        for(int i = 0; i < matches.size(); i++)
        {
            if(inClause.length() > 0)
            {
                inClause.append(", ");
            }
            else
            {
                inClause.append(" AND ").append(fieldName).append(" like (");
            }
            inClause.append("?");
            sqlParams.add(matches.get(i));
            sqlTypes.add(argumentType);
        }
        inClause.append(") ");
        sql.append(inClause);*/
        //Since this has to work with wildcards, an IN clause will not work
        StringBuffer inClause = new StringBuffer();
        for(int i = 0; i < matches.size(); i++)
        {
            if(inClause.length() > 0)
            {
                inClause.append(" OR ");
            }
            else
            {
                inClause.append(" AND ").append(" (");
            }
            inClause.append(fieldName).append(" LIKE ").append("?");
            sqlParams.add(matches.get(i));
            sqlTypes.add(argumentType);
        }
        inClause.append(") ");
        sql.append(inClause);
    }

    private List<String> findInstrumentIdsByBoundingBox(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findInstrumentIdsByBoundingBox parameter Map<String, Object> params cannot be null.");
        }
        BigDecimal maxLatitude = (BigDecimal)params.get(GetICDataByBoundingBox.BOUNDING_COORDINATE_NORTH.getName());
        BigDecimal maxLongitude = (BigDecimal)params.get(GetICDataByBoundingBox.BOUNDING_COORDINATE_EAST.getName());
        BigDecimal minLatitude = (BigDecimal)params.get(GetICDataByBoundingBox.BOUNDING_COORDINATE_SOUTH.getName());
        BigDecimal minLongitude = (BigDecimal)params.get(GetICDataByBoundingBox.BOUNDING_COORDINATE_WEST.getName());
        Object[] args = {maxLatitude, maxLongitude, minLatitude, minLongitude, 
                        maxLatitude, maxLongitude, minLatitude, minLongitude, maxLatitude, maxLongitude, minLatitude, minLongitude,
                        maxLatitude, maxLongitude, minLatitude, minLongitude, maxLatitude, maxLongitude, minLatitude, minLongitude};
        int[] types = {Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL,
                        Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL,
                        Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL,Types.DECIMAL, Types.DECIMAL, Types.DECIMAL, Types.DECIMAL};
        List<String> nonPolygonMatches = getJdbcTemplate().queryForList(instrumentIdsByBoundingBoxSelect + instrumentIdsByBoundingBoxSelectJoins
                                                                                        + coordinateWhereClause, args, types, String.class);
        Set<String> results = new HashSet<String>(nonPolygonMatches);
        Set<String> polygonMatches = new HashSet<String>();

        StringBuffer sql = new StringBuffer(instrumentIdsByBoundingBoxSelectPolygon + instrumentIdsByBoundingBoxSelectJoins
                                            + instrumentIdsByBoundBoxSelectPolygonJoin + " WHERE 1=1 ");
        List<PolygonResult> allPolygons = getJdbcTemplate().query(sql.toString(), new PolygonRowMapper());
        for(int i = 0; i < allPolygons.size(); i++)
        {
            PolygonResult currentPoly = allPolygons.get(i);
            if(currentPoly.getLatitude().compareTo(maxLatitude) < 1 /*less than or equal to*/
                            && currentPoly.getLatitude().compareTo(minLatitude) > -1 /*greater than or equal to*/
                            && currentPoly.getLongitude().compareTo(maxLongitude) < 1 /*less than or equal to*/
                            && currentPoly.getLongitude().compareTo(minLongitude) > -1 /*greater than or equal to*/)
            {
                polygonMatches.add(currentPoly.getInstrumentId());
            }
        }

        //create a full set of all results and return
        results.addAll(polygonMatches);
        return new ArrayList<String>(results);
    }

    public List<String> findAffiliateIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findAffiliateIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }
        /*if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) == null)
        {
            throw new IllegalArgumentException(
                            "JdbcICDao method findAffiliateIdsByCriteria parameter Map<String, Object> params was missing a required value:  "
                                            + GetICDataByChangeDate.CHANGE_DATE.getName() + ".");
        }
        return getJdbcTemplate().queryForList(affiliateIdsByCriteriaSql, String.class);*/
        List<String> instrumentIds = findIntrumentIdsByCriteria(params);

        List<Object> sqlParams = new ArrayList<Object>();
        List<Integer> sqlTypes = new ArrayList<Integer>();
        StringBuffer sql = new StringBuffer(affiliateIdsByCriteriaSql);
        if(instrumentIds != null && instrumentIds.size() > 0)
        {
            addInClause(instrumentIds, sql, sqlParams, sqlTypes, "inst.IC_INSTR_ID", Types.VARCHAR);
        }
        else
        {
            return new ArrayList<String>();//If there are no instruments there are no locations or affiliates either
        }

        List<String> matches = getJdbcTemplate().queryForList(sql.toString(),
                                                              sqlParams.toArray(),
                                                              createIntArray(sqlTypes), String.class);
        return matches;
    }

    public List<String> findLocationIdsByCriteria(Map<String, Object> params)
    {
        if(params == null)
        {
            throw new IllegalArgumentException("JdbcICDao method findLocationIdsByCriteria parameter Map<String, Object> params cannot be null.");
        }
        /*if(params.get(GetICDataByChangeDate.CHANGE_DATE.getName()) == null)
        {
            throw new IllegalArgumentException(
                            "JdbcICDao method findLocationIdsByCriteria parameter Map<String, Object> params was missing a required value:  "
                                            + GetICDataByChangeDate.CHANGE_DATE.getName() + ".");
        }
        return getJdbcTemplate().queryForList(locationIdsByCriteriaSql, String.class);*/
        List<String> instrumentIds = findIntrumentIdsByCriteria(params);

        List<Object> sqlParams = new ArrayList<Object>();
        List<Integer> sqlTypes = new ArrayList<Integer>();
        StringBuffer sql = new StringBuffer(locationIdsByCriteriaSql);
        if(instrumentIds != null && instrumentIds.size() > 0)
        {
            addInClause(instrumentIds, sql, sqlParams, sqlTypes, "inst.IC_INSTR_ID", Types.VARCHAR);
        }
        else
        {
            return new ArrayList<String>();//If there are no instruments there are no locations or affiliates either
        }

        List<String> matches = getJdbcTemplate().queryForList(sql.toString(),
                                                              sqlParams.toArray(),
                                                              createIntArray(sqlTypes), String.class);
        return matches;
    }

    class PolygonRowMapper implements RowMapper<PolygonResult>
    {
        @Override
        public PolygonResult mapRow(ResultSet rs, int rowNum) throws SQLException
        {
            PolygonResult poly = new PolygonResult();
            poly.setInstrumentId(rs.getString("IC_INSTR_ID"));
            poly.setLatitude(rs.getBigDecimal("lat"));
            poly.setLongitude(rs.getBigDecimal("lon"));
            return poly;
        }
    }

    class PolygonResult
    {
        private String instrumentId;
        private BigDecimal latitude;
        private BigDecimal longitude;
        public String getInstrumentId()
        {
            return instrumentId;
        }
        public void setInstrumentId(String instrumentId)
        {
            this.instrumentId = instrumentId;
        }
        public BigDecimal getLatitude()
        {
            return latitude;
        }
        public void setLatitude(BigDecimal latitude)
        {
            this.latitude = latitude;
        }
        public BigDecimal getLongitude()
        {
            return longitude;
        }
        public void setLongitude(BigDecimal longitude)
        {
            this.longitude = longitude;
        }
    }
}
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.data.dao.jdbc;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;
import java.util.Map.Entry;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.dao.DataAccessException;
import org.springframework.jdbc.core.ResultSetExtractor;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.service.helper.IdGenerator;

public class BaseJdbcDao extends JdbcDaoSupport {

    /** Logger for this class and subclasses */
    protected Logger logger = Logger.getLogger(getClass());

    protected IdGenerator idGenerator;

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {
        super.checkDaoConfig();

        if (idGenerator == null) {
            throw new RuntimeException("idGenerator Not Set");
        }
    }

    /**
     * printourArgs
     * 
     * @param args
     */
    public void printourArgs(Object[] args) {

        if (args != null) {
            for (int i = 0; i < args.length; i++) {
                logger.debug(args[i]);
            }
        }
    }

    /**
     * delete
     * 
     * @param sql
     * @param id
     */
    public void delete(String sql, String id) {

        validateStringArg(id);

        int result = getJdbcTemplate().update(sql, new Object[] { id });

        logger.debug("delete result: " + result);

    }

    public boolean exists(String sql, String id) {

        validateStringArg(id);

        int result = getJdbcTemplate().queryForInt(sql, new Object[] { id });

        logger.debug("exists result: " + result);

        return result > 0;

    }

    /**
     * getMap
     * 
     * @param sql
     * @param upperKey
     * @return
     */
    @SuppressWarnings("unchecked")
    protected Map<String, String> getMap(String sql, boolean upperKey) {

        validateStringArg(sql);

        return (Map<String, String>) getJdbcTemplate().query(sql,
                new MapExtractor(upperKey));
    }

    /**
     * getMap
     * 
     * @param sql
     * @param id
     * @param upperKey
     * @return
     */
    @SuppressWarnings("unchecked")
    protected Map<String, String> getMap(String sql, String id, boolean upperKey) {

        validateStringArg(sql);

        return (Map) getJdbcTemplate().query(sql, new Object[] { id },
                new MapExtractor(upperKey));
    }

    /**
     * getByIndexOrNameMap
     * 
     * @param sql
     * @param id
     * @return
     */
    protected ByIndexOrNameMap getByIndexOrNameMap(String sql, String id) {

        validateStringArg(sql);

        ByIndexOrNameMap indeNameMap = new ByIndexOrNameMap();

        Map<String, String> map = getMap(sql, id, true);

        for (Iterator<Entry<String, String>> it = map.entrySet().iterator(); it
                .hasNext();) {

            Map.Entry<String, String> entry = (Map.Entry<String, String>) it
                    .next();
            indeNameMap.put((String) entry.getKey(), entry.getValue());

        }

        return indeNameMap;
    }

    /**
     * getArray
     * 
     * @param sql
     * @param id
     * @return
     */
    protected String[] getArray(String sql, String id) {

        validateStringArg(sql);
        validateStringArg(id);

        List<?> list = getList(sql, id);

        return (String[]) list.toArray(new String[list.size()]);
    }

    /**
     * getList
     * 
     * @param sql
     * @param id
     * @return
     */
    protected List<?> getList(String sql, String id) {

        validateStringArg(sql);
        validateStringArg(id);

        return getJdbcTemplate().query(sql, new Object[] { id },
                new ArrayMapper());

    }

    /**
     * getList
     * 
     * @param sql
     * @return
     */
    protected List<?> getList(String sql) {

        validateStringArg(sql);

        return getJdbcTemplate().query(sql, new ArrayMapper());

    }

    /**
     * getArray
     * 
     * @param sql
     * @return
     */
    protected String[] getArray(String sql) {

        validateStringArg(sql);

        List<?> list = getJdbcTemplate().query(sql, new ArrayMapper());

        return (String[]) list.toArray(new String[list.size()]);
    }

    protected static List<String> getColumnNames(ResultSet rs)
            throws SQLException {

        List<String> columnNames = new ArrayList<String>();

        ResultSetMetaData rsm = rs.getMetaData();
        int columnCount = rsm.getColumnCount();

        for (int i = 1; i <= columnCount; i++) {

            columnNames.add(rsm.getColumnName(i));

        }

        return columnNames;
    }

    protected static boolean containsColumnNamed(ResultSet rs, String columnName)
            throws SQLException {

        return getColumnNames(rs).contains(columnName);

    }

    /**
     * ArrayMapper
     * 
     * @author mchmarny
     * 
     */
    protected class ArrayMapper implements RowMapper {
        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {
            return rs.getString(1);
        }
    }

    /**
     * 
     * @param sql
     * @param args
     * @param rowMapper
     * @return
     * @throws DataAccessException
     */
    public Object queryForObject(String sql, Object[] args, RowMapper rowMapper)
            throws DataAccessException {

        logger.debug("SQL: " + sql);
        printourArgs(args);

        List<?> result = getJdbcTemplate().query(sql, args, rowMapper);

        if (result == null || result.size() != 1) {
            return null;
        } else {
            return result.get(0);
        }
    }

    /**
     * 
     * @author mchmarny
     * 
     */
    protected class MapExtractor implements ResultSetExtractor {

        private boolean makeKeyUpper = false;

        public MapExtractor(boolean upperKey) {
            makeKeyUpper = upperKey;
        }

        public Object extractData(ResultSet rs) throws SQLException,
                DataAccessException {

            Map<String, String> map = new TreeMap<String, String>(
                    String.CASE_INSENSITIVE_ORDER);

            while (rs.next()) {

                String key = rs.getString(1);
                String val = rs.getString(2);

                if (makeKeyUpper) {
                    map.put(key.toUpperCase(), val);
                } else {
                    map.put(key, val);
                }

            }

            return map;

        }

    }

    /**
     * SimpleStringMapper
     * 
     * @author mchmarny
     * 
     */
    protected class SimpleStringMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            return rs.getString(1);

        }

    }

    /**
     * validateStringArg
     * 
     * @param arg
     */
    protected void validateStringArg(String arg) {
        if (StringUtils.isBlank(arg)) {
            throw new IllegalArgumentException("Argument cannot be null.");
        }
    }

    /**
     * validateObjectArg
     * 
     * @param instance
     * @param typeName
     */
    protected void validateObjectArg(Object instance, String typeName) {
        if (instance == null) {
            throw new IllegalArgumentException("Argument " + typeName
                    + " instance cannot be null.");
        }
    }

    public IdGenerator getIdGenerator() {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

}

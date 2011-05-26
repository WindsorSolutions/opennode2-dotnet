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

package com.windsor.node.plugin.common.dao;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringEscapeUtils;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

public abstract class BaseJdbcDao extends JdbcDaoSupport {

    public static final String COMMA = ", ";
    public static final String DOT = ".";
    public static final String APOS = "'";
    public static final String WHERE = " WHERE ";
    public static final String FROM = " FROM  ";
    public static final String SELECT = " SELECT ";
    public static final String UPDATE = " UPDATE ";
    public static final String SET = " SET ";
    public static final String INSERT = " INSERT INTO ";
    public static final String AND = " AND ";
    public static final String OR = " OR ";
    public static final String SELECT_COUNT_ALL_FROM = " SELECT COUNT(*) FROM ";
    public static final String ORDER_BY = " ORDER BY ";
    public static final String SELECT_ALL_FROM = " SELECT * FROM ";
    public static final String EQUALS = " = ";
    public static final String IN = " IN ";
    public static final String R_PAREN = ")";
    public static final String L_PAREN = "(";
    public static final String VALUES = " VALUES ";
    public static final String MAX = " MAX(";
    public static final String DISTINCT = " DISTINCT ";

    public static final String PARAM = " ? ";
    public static final String GT_PARAM = " > ? ";
    public static final String EQUALS_PARAM = " = ? ";
    public static final String NOT_EQUALS_PARAM = " != ? ";
    // "ROWNUM" is Oracle-specific, but so is NY-DOH and NY-DEC
    // see http://en.wikipedia.org/wiki/Select_(SQL) for other
    // dbms approaches
    public static final String ROWNUM_PARAM = "ROWNUM <= ? ";

    private static final String DATA_SOURCE_CANNOT_BE_NULL = "DataSource cannot be null.";

    protected Logger logger = LoggerFactory.getLogger(getClass());

    protected void checkDaoConfig() {
        super.checkDaoConfig();

        if (getDataSource() == null) {
            logger.error(DATA_SOURCE_CANNOT_BE_NULL);
            throw new RuntimeException(DATA_SOURCE_CANNOT_BE_NULL);
        }
    }

    protected boolean validateStringArg(String arg) {

        if (StringUtils.isBlank(arg)) {

            throw new RuntimeException("String arg was blank");
        }

        return true;
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

    public static boolean containsColumnNamed(ResultSet rs, String columnName)
            throws SQLException {

        return getColumnNames(rs).contains(columnName);

    }

    protected static String trimToXml(String s) {

        return StringUtils.trimToNull(StringEscapeUtils.escapeXml(s));
    }

    public static Integer getInteger(ResultSet rs, String columnName)
            throws SQLException {

        Integer value = null;

        int i = rs.getInt(columnName);

        if (!rs.wasNull()) {

            value = new Integer(i);
        }

        return value;
    }

    public static Long getLong(ResultSet rs, String columnName)
            throws SQLException {

        Long value = null;

        int i = rs.getInt(columnName);

        if (!rs.wasNull()) {

            value = new Long(i);
        }

        return value;
    }

    public static Double getDouble(ResultSet rs, String columnName)
            throws SQLException {

        Double value = null;

        double d = rs.getDouble(columnName);

        if (!rs.wasNull()) {

            value = new Double(d);
        }

        return value;
    }

    protected int countRowsStringKey(String value, String column,
            String tableName) {

        String sql = "select count(*) from " + tableName + " where " + column
                + " = '" + value + APOS;

        return getJdbcTemplate().queryForInt(sql);

    }

}

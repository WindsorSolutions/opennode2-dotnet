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

package com.windsor.node.plugin.common.velocity.jdbc;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.sql.Types;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Iterator;
import javax.sql.DataSource;
import org.apache.commons.beanutils.BasicDynaBean;
import org.apache.commons.beanutils.BasicDynaClass;
import org.apache.commons.beanutils.ConvertUtils;
import org.apache.commons.beanutils.DynaBean;
import org.apache.commons.beanutils.PropertyUtils;
import org.apache.commons.beanutils.ResultSetDynaClass;
import org.apache.commons.lang3.StringUtils;
import com.windsor.node.plugin.common.velocity.TemplateHelper;

/**
 * Provides an API for embedding SQL in Velocity templates, plus a handful of
 * utility methods.
 * 
 * <p>
 * The getList() variants return an array of single values from the query
 * results (e.g., a set of primary keys to iterate over for subqueries).
 * </p>
 * 
 * <p>
 * The getObject() and getData() methods return objects and collections of
 * objects respectively. Returned objects are dynamically created using
 * org.apache.commons.beanutils.*. The returned objects have a field for each
 * column corresponding to the query results, and can be accessed from the
 * Velocity Template Language (VTL), e.g.:
 * 
 * <pre>
 * #set ( $fac = $helper.getObject(&quot;SELECT * FROM frs_fac WHERE st_fac_ind = ? &quot;, $facId) )
 * ...
 * &lt;FacilityRegistryIdentifier&gt;$fac.get(&quot;st_fac_ind&quot;)&lt;/FacilityRegistryIdentifier&gt;
 * </pre>
 * 
 * </p>
 * <p>
 * To invoke any of the methods here, use $helper.&lt;methodName(param)&gt;, for
 * example:
 * 
 * <pre>
 * $helper.print(myObject)
 * </pre>
 * 
 * </p>
 * 
 * @see http://velocity.apache.org for a guide to the Velocity Template Language
 */
public class JdbcTemplateHelper extends TemplateHelper {

    public static enum DbType {
        Oracle, MSSQL, MySQL, Unrecognized
    };

    private static final String ORACLE = "oracle";
    private static final String MS_SQL = "microsoft sql server";
    private static final String MY_SQL = "mysql";

    private Connection connection;
    private int resultingRecordCount = 0;

    /**
     * Default constructor, a convenience for testing utility methods.
     * 
     * <p>
     * If using this constructor, {@link #setConnection(Connection)} must be
     * called prior to attempting any queries.
     * 
     */
    public JdbcTemplateHelper() {
        super();
    }

    /**
     * Creates an instance pointed to a single database/schema; the instance can
     * be referenced as $helper from within VTL.
     * 
     * @param dataSource
     */
    public JdbcTemplateHelper(DataSource dataSource) {

        if (dataSource == null) {
            throw new IllegalArgumentException("null datasource");
        }
        try {
            this.connection = dataSource.getConnection();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

    }

    /**
     * Infer database vendor/type from the JDBC driver name.
     * 
     * @return one of Oracle, MSSQL, MySQL, or Unrecognized
     */
    public DbType getDbType() {

        DbType type = DbType.Unrecognized;

        if (null != connection) {

            String driverName;

            try {

                driverName = connection.getMetaData().getDriverName();
                logger.debug("Driver name: " + driverName);

            } catch (SQLException sqle) {

                throw new RuntimeException(
                        "couldn't get jdbc driver name from connection");
            }

            if (StringUtils.containsIgnoreCase(driverName, ORACLE)) {

                type = DbType.Oracle;

            } else if (StringUtils.containsIgnoreCase(driverName, MS_SQL)) {

                type = DbType.MSSQL;

            } else if (StringUtils.containsIgnoreCase(driverName, MY_SQL)) {

                type = DbType.MySQL;
            }
        }

        logger.debug("Using database type " + type);

        return type;
    }

    /**
     * Reformats a String formatted in one of the eight patterns supported by
     * this class into a pattern that the database can parse as a Date without
     * calling a conversion function.
     * 
     * <p>
     * Essentially a workaround for Oracle's default date format. Tested with
     * MySql, SqlServer, and Oracle.
     * </p>
     * 
     * @param dateString
     *            the String to convert
     * @return for Oracle, a String in dd-MMM-yy format; for all others, a
     *         String in yyyy-MM-dd format (i.e., XML Date)
     * @deprecated use covertToDbDate(String dateString) instead
     */
    public String toDbDateString(String dateString) {

        logger.debug("toDbDateString: " + dateString);

        Date date;

        try {

            date = makeSqlDate(dateString);

        } catch (ParseException pe) {

            throw new IllegalArgumentException(
                    "Not a recognized date format, root exception: " + pe);
        }

        String formatStr;

        if (getDbType().equals(DbType.Oracle)) {

            formatStr = DATE_FORMAT_ORACLE_DEFAULT;

        } else {

            formatStr = XML_DATE_FORMAT;
        }

        SimpleDateFormat sdf = new SimpleDateFormat(formatStr);

        String output = sdf.format(date);
        logger.debug("toDbDateString output: " + output);

        return output;
    }

    /**
     * Converts a String representation of a date into an actual Date that can be used in a
     * prepared statement.
     * @param dateString
     * @return java.sql.Date
     */
    public Date covertToDbDate(String dateString)
    {
        logger.debug("covertToDbDate: " + dateString);
        Date date;
        try
        {
            date = makeSqlDate(dateString);
        }
        catch(ParseException pe)
        {
            throw new IllegalArgumentException("Not a recognized date format, root exception: " + pe);
        }

      /* SimpleDateFormat sdf = new SimpleDateFormat(XML_DATE_FORMAT) ;
        String output = sdf.format(date);
        if(getDbType().equals(DbType.Oracle))
        {
            output = " to_date('" + output + "', 'YYYY-MM-DD') ";
        }
        else if(getDbType().equals(DbType.MSSQL))
        {
            output = " CONVERT(DATETIME,'" + output + " 00:00:00 AM',20) ";
        }
        else if(getDbType().equals(DbType.MySQL))
        {
            output = "#[[ STR_TO_DATE('" + output + "', '%Y-%m-%d') ]]#";
        }
        else
        {
            //there's really nothing to do if the DB type is unknown, compare to a VARCHAR and hope for the best
            output = " '" + output + "'";
        }*/
        SimpleDateFormat sdf = new SimpleDateFormat(XML_DATE_FORMAT);
        logger.debug("covertToDbDate output: " + sdf.format(date));
        return date;
    }

    /**
     * Given an SQL statment with no query parameters return an array of single
     * values suitable for iterating over with a VTL #foreach construct.
     * 
     * <p>
     * Treats the query parameter as VARCHAR; to specify the SQL datatype, use
     * {@link #getList(String, Object, String, int)}.
     * </p>
     * 
     * @param sql
     *            the SQL query containing one replacement parameter
     * 
     * @param propertyName
     *            the name of the table column whose values will populate the
     *            returned array
     * @return an array of single values
     */
    public Object[] getList(String sql, String propertyName) {

        return getList(sql, null, propertyName, Types.VARCHAR);
    }

    /**
     * Given an SQL statment with one query parameter &quot;?&quot; return an
     * array of single values suitable for iterating over with a VTL #foreach
     * construct.
     * 
     * <p>
     * Treats the query parameter as VARCHAR; to specify the SQL datatype, use
     * {@link #getList(String, Object, String, int)}.
     * </p>
     * 
     * @param sql
     *            the SQL query containing one replacement parameter
     * @param arg
     *            the value to replace the parameter in the query (literal, or a
     *            VTL variable)
     * @param propertyName
     *            the name of the table column whose values will populate the
     *            returned array
     * @return an array of single values
     */
    public Object[] getList(String sql, Object arg, String propertyName) {

        return getList(sql, trapArrayList(arg), propertyName, Types.VARCHAR);
    }

    /**
     * Given an SQL statment with one query parameter &quot;?&quot;, return an
     * object array suitable for iterating over with a VTL #foreach construct.
     * 
     * <p>
     * Allows specifying the JDBC datatype for the query parameter.
     * </p>
     * 
     * 
     * @param sql
     *            the SQL query containing one replacement parameter
     * @param arg
     *            the value to replace the parameter in the query (literal, or a
     *            VTL variable)
     * @param propertyName
     *            the name of the table column whose values will populate the
     *            returned array
     * @param type
     *            the JDBC type constant
     * @return an array of single values
     * @see http://java.sun.com/j2se/1.4.2/docs/api/java/sql/Types.html
     */
    public Object[] getList(String sql, Object arg, String propertyName,
            int type) {

        return getList(sql, trapArrayList(arg), propertyName, type);
    }

    /**
     * Given an SQL statment with multiple query parameters &quot;?&quot;,
     * return an object array suitable for iterating over with a VTL #foreach
     * construct.
     * 
     * @param sql
     *            the SQL query containing multiple replacement parameters
     * @param args
     *            an array of values to replace the parameter in the query
     *            (literal, or a VTL variable)
     * @param propertyName
     *            the name of the table column whose values will populate the
     *            returned array
     * @param type
     *            the JDBC type constant
     * @see http://java.sun.com/j2se/1.4.2/docs/api/java/sql/Types.html
     */
    @SuppressWarnings("unchecked")
    public Object[] getList(String sql, Object[] args, String propertyName,
            int type) {

        try {

            PreparedStatement ps = getPreparedStatement(sql, args, type);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            ArrayList<Object> results = new ArrayList<Object>();

            Iterator<Object> rows = rsdc.iterator();
            while (rows.hasNext()) {
                DynaBean bean = (DynaBean) rows.next();
                results.add(bean.get(propertyName));
            }

            ps.close();

            return results.toArray();

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while getting list: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Given an SQL statement with a single query parameter, return a single
     * object.
     * 
     * <p>
     * Treats the parameter as a VARCHAR.
     * </p>
     * 
     * @param sql
     *            the SQL query
     * @param arg
     *            the query parameter
     * @return a java.lang.Object
     */
    public Object getObject(String sql, Object arg) {

        return getObject(sql, trapArrayList(arg));
    }

    /**
     * Given an SQL statement with a multiple query parameters, return a single
     * object.
     * 
     * <p>
     * Treats the parameter as a VARCHAR.
     * </p>
     * 
     * @param sql
     *            the SQL query
     * @param args
     *            an array of query parameters
     * @return a java.lang.Object
     */
    @SuppressWarnings("unchecked")
    public Object getObject(String sql, Object[] args) {

        try {

            PreparedStatement ps = getPreparedStatement(sql, args,
                    Types.VARCHAR);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            BasicDynaClass bdc = new BasicDynaClass("objectCopy",
                    BasicDynaBean.class, rsdc.getDynaProperties());

            DynaBean newRow = null;

            Iterator<Object> rows = rsdc.iterator();
            if (rows.hasNext()) {
                DynaBean oldRow = (DynaBean) rows.next();
                newRow = bdc.newInstance();
                PropertyUtils.copyProperties(newRow, oldRow);
            }

            // again, ugly but required for large sets
            ps.close();

            return newRow;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error in getObject(): "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Given an SQL statment with no query parameters, return an Iterator
     * suitable for iterating over with a VTL #foreach construct.
     * 
     * @param sql
     *            the SQL query
     * @return a java.util.Iterator
     */
    public Iterator<DynaBean> getData(String sql) {

        return getData(sql, null);
    }

    /**
     * Given an SQL statment with one query parameter &quot;?&quot;, return an
     * Iterator suitable for iterating over with a VTL #foreach construct.
     * 
     * <p>
     * Treats the query parameter as a VARCHAR.
     * </p>
     * 
     * @param sql
     *            the SQL query
     * @param arg
     *            the value to replace the parameter in the query (literal, or a
     *            VTL variable)
     * @return a java.util.Iterator
     */
    public Iterator<DynaBean> getData(String sql, Object arg) {

        return getData(sql, trapArrayList(arg));
    }

    /**
     * Given an SQL statment with multiple query parameters &quot;?&quot;,
     * return an Iterator suitable for iterating over with a VTL #foreach
     * construct.
     * 
     * <p>
     * Treats the query parameter as a VARCHAR.
     * </p>
     * 
     * @param sql
     *            the SQL query
     * @param args
     *            the value to replace the parameter in the query (literal, or a
     *            VTL variable)
     * @return a java.util.Iterator
     */
    public Iterator<DynaBean> getData(String sql, Object[] args) {

        return getData(sql, args, Types.VARCHAR);

    }

    /**
     * Given an SQL statment with multiple query parameters &quot;?&quot;,
     * return an Iterator suitable for iterating over with a VTL #foreach
     * construct.
     * 
     * <p>
     * Allows specifying the JDBC datatype for the query parameters.
     * </p>
     * 
     * @param sql
     *            the SQL query
     * @param args
     *            the value to replace the parameter in the query (literal, or a
     *            VTL variable)
     * @param type
     *            the JDBC type constant of the query param
     * @return a java.util.Iterator
     * @see http://java.sun.com/j2se/1.4.2/docs/api/java/sql/Types.html
     */
    @SuppressWarnings("unchecked")
    public Iterator<DynaBean> getData(String sql, Object[] args, int type) {

        try {

            PreparedStatement ps = getPreparedStatement(sql, args, type);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            ArrayList<DynaBean> results = new ArrayList<DynaBean>();
            BasicDynaClass bdc = new BasicDynaClass("objectCopy",
                    BasicDynaBean.class, rsdc.getDynaProperties());

            // Note: This is ugly but necessary to disconnect the Iterator
            // from the underlining result set and its connection.
            Iterator<Object> rows = rsdc.iterator();
            while (rows.hasNext()) {
                DynaBean oldRow = (DynaBean) rows.next();
                DynaBean newRow = bdc.newInstance();
                PropertyUtils.copyProperties(newRow, oldRow);
                results.add(newRow);
            }

            // again, ugly but required for large sets
            ps.close();

            logger.trace("query returned " + results.size() + " results");
            return results.iterator();

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(
                    "Error in getData(): " + ex.getMessage(), ex);
        }

    }

    private PreparedStatement getPreparedStatement(String sql, Object[] args,
            int type) {

        checkConnection();

        traceArgs(sql, args, null, type);

        try {

            PreparedStatement ps = connection.prepareStatement(sql);

            if (args != null && args.length > 0) {

                for (int i = 1; i <= args.length; i++) {

                    Object argVal = args[i - 1];

                    if (type == Types.BIGINT || type == Types.INTEGER) {

                        logger.trace("Converting " + argVal + " to int");
                        ps.setInt(i, ((Integer) ConvertUtils.convert(argVal,
                                int.class)).intValue());

                    } else if (type == Types.TIMESTAMP) {

                        logger.trace("Converting " + argVal + " to Timestamp");
                        ps.setTimestamp(i, new Timestamp(makeSqlDate(argVal)
                                .getTime()));

                    } else if (type == Types.DATE) {

                        logger.trace("Converting " + argVal + " to Sql Date");
                        ps.setDate(i, makeSqlDate(argVal));

                    } else {

                        ps.setObject(i, argVal);
                    }
                }
            }

            return ps;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error preparing statement : "
                    + ex.getMessage(), ex);
        }

    }

    private void traceArgs(String sql, Object[] args, String propertyName,
            int type) {

        if (StringUtils.isNotBlank(sql)) {
            logger.trace("sql = " + sql);
        }

        if (null != args && args.length > 0) {

            logger.trace("args.length = " + args.length);

            for (int i = 0; i < args.length; i++) {
                logger.trace("args[" + i + "] = " + args[i]);
            }
        }

        if (StringUtils.isNotBlank(propertyName)) {
            logger.trace("propertyName = " + propertyName);
        }
        logger.trace("type = " + type);
    }

    private void checkConnection() {

        if (null == connection) {
            throw new RuntimeException("Connection is null");
        }

        try {
            if (connection.isClosed()) {
                throw new RuntimeException("Connection is closed");
            }
        } catch (SQLException e) {
            throw new RuntimeException("Problem checking connection status: "
                    + e);
        }
    }

    /**
     * @return
     */
    public int getResultingRecordCount() {
        return resultingRecordCount;
    }

    /**
     * @param resultingRecordCount
     */
    public void setResultingRecordCount(int resultingRecordCount) {
        this.resultingRecordCount = resultingRecordCount;
    }

    /**
     * @return the connection
     */
    public Connection getConnection() {
        return connection;
    }

    /**
     * @param connection
     *            the connection to set
     */
    public void setConnection(Connection connection) {
        this.connection = connection;
    }

}

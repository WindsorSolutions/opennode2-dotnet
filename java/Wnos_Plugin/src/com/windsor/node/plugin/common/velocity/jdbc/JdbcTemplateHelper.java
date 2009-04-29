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
import org.apache.commons.beanutils.converters.BooleanConverter;
import org.apache.commons.lang.NullArgumentException;
import org.apache.commons.lang.StringEscapeUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.time.DateUtils;
import org.apache.commons.lang.time.StopWatch;
import org.apache.log4j.Logger;

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
public class JdbcTemplateHelper {

    public static final String XML_DATE_FORMAT = "yyyy-MM-dd";
    public static final String TIMESTAMP_FORMAT_MINS = "yyyy-MM-dd HH:mm";
    public static final String TIMESTAMP_FORMAT_SECS = "yyyy-MM-dd HH:mm:ss";
    public static final String TIMESTAMP_FORMAT_MILLI = "yyyy-MM-dd HH:mm:ss.S";
    public static final String TIMESTAMP_FORMAT_MILLI2 = "yyyy-MM-dd HH:mm:ss.SS";
    public static final String TIMESTAMP_FORMAT_MILLI3 = "yyyy-MM-dd HH:mm:ss.SSS";
    public static final String TIMESTAMP_FORMAT_MILLI4 = "yyyy-MM-dd HH:mm:ss.SSSS";

    private static final String[] DATE_FORMATS = { XML_DATE_FORMAT,
            TIMESTAMP_FORMAT_MINS, TIMESTAMP_FORMAT_SECS,
            TIMESTAMP_FORMAT_MILLI, TIMESTAMP_FORMAT_MILLI2,
            TIMESTAMP_FORMAT_MILLI3, TIMESTAMP_FORMAT_MILLI4 };

    protected Logger logger = Logger.getLogger(getClass());

    private Connection connection;
    private StopWatch watch = new StopWatch();
    private BooleanConverter booleanConverter;
    private SimpleDateFormat simpleDateFormat;
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
    }

    /**
     * Creates an instance pointed to a single database/schema; the instance can
     * be referenced as $helper from within VTL.
     * 
     * @param dataSource
     */
    public JdbcTemplateHelper(DataSource dataSource) {

        if (dataSource == null) {
            throw new NullArgumentException("null datasource");
        }
        try {
            this.connection = dataSource.getConnection();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

    }

    /**
     * Start the timer - only one StopWatch per instance of this class.
     */
    public void startStopWatch() {
        watch.start();
    }

    /**
     * Stop the timer.
     */
    public void stopStopWatch() {
        watch.stop();
    }

    /**
     * Prints elapsed time to the Log4j subsystem (INFO log level).
     */
    public void printElapsedTime() {
        print(watch.toString());
    }

    /**
     * Calls org.apache.commons.lang.StringEscapeUtils to escape XML entities
     * (&lt;, &gt;, &amp; &quot; &apos;).
     * 
     * <p>
     * An optional method, we configure the Velocity engine to use its own
     * escaping mechanism.
     * </p>
     * 
     * @param val
     * @return the escaped String
     */
    public String escapeXml(String val) {
        return StringEscapeUtils.escapeXml(val);
    }

    /**
     * Calls the corresponding method in
     * org.apache.commons.lang.StringEscapeUtils.
     * 
     * @param val
     * @return the escaped String
     */
    public String escapeCsv(String val) {
        return StringEscapeUtils.escapeCsv(val);
    }

    /**
     * Calls the corresponding method in
     * org.apache.commons.lang.StringEscapeUtils.
     * 
     * @param val
     * @return the escaped String
     */
    public String escapeHtml(String val) {
        return StringEscapeUtils.escapeHtml(val);
    }

    /**
     * Calls the corresponding method in
     * org.apache.commons.lang.StringEscapeUtils.
     * 
     * @param val
     * @return the escaped String
     */
    public String escapeSql(String val) {
        return StringEscapeUtils.escapeSql(val);
    }

    /**
     * Convert any value to "true" or "false"; use for elements of type
     * &lt;xsd:boolean&gt;.
     * 
     * <p>
     * For example:
     * 
     * <pre>
     * &lt;SomeBooleanElement&gt;$helper.toBoolean($myElement.get(&quot;some_column&quot;))&lt;/SomeBooleanElement&gt;
     * </pre>
     * 
     * </p>
     * 
     * <p>
     * Wraps org.apache.commons.beanutils.converters.BooleanConverter, using
     * default configuration.
     * </p>
     * 
     * @param val
     * @return
     */
    public String toXmlBoolean(Object val) {

        if (null == booleanConverter) {

            booleanConverter = new BooleanConverter();
        }
        return ((Boolean) booleanConverter.convert(null, val)).toString();

    }

    /**
     * Given the contents of a Date, DateTime, or TimeStamp column, return a
     * proper XML date (i.e., in yyyy-MM-dd format).
     * 
     * @param val
     * @return
     * @throws ParseException
     */
    public String toXmlDate(Object val) throws ParseException {

        if (null == simpleDateFormat) {

            simpleDateFormat = new SimpleDateFormat(XML_DATE_FORMAT);
        }

        return simpleDateFormat.format(DateUtils.parseDate(val.toString(),
                DATE_FORMATS));
    }

    /**
     * Given the contents of a DateTime or TimeStamp column, return a proper XML
     * datetime (i.e., in yyyy-MM-dd'T'HH:mm:ss.S format).
     * 
     * @param val
     * @return
     */
    public String toXmlDateTime(Object val) {

        SimpleDateFormat sdfInput = new SimpleDateFormat(
                "yyyy-MM-dd'T'HH:mm:ss.S");
        return sdfInput.format(val);

    }

    public String getCurrentDateTime() {

        return toXmlDateTime(new Long(System.currentTimeMillis()));
    }

    /**
     * Logs the object by implicitly calling its toString() method.
     * 
     * @param val
     */
    public void print(Object val) {
        logger.info(val);
    }

    /**
     * Given an SQL statment with one query parameter &quot;?&quot; return an
     * array of single values suitable for iterating over with a VTL #foreach
     * construct.
     * 
     * <p>
     * Treats the query parameter as VARCHAR; to specify the SQL datatype, use
     * {@link #getList(String, Object, String)}.
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
        return getList(sql, new Object[] { arg }, propertyName, Types.VARCHAR);
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
        return getList(sql, new Object[] { arg }, propertyName, type);
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
    public Object[] getList(String sql, Object[] args, String propertyName,
            int type) {

        traceArgs(sql, args, propertyName, type);

        try {

            PreparedStatement ps = getPreparedStatement(sql, args, type);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            ArrayList results = new ArrayList();

            Iterator rows = rsdc.iterator();
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
        return getObject(sql, new Object[] { arg });
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
    public Object getObject(String sql, Object[] args) {

        traceArgs(sql, args, null, Types.VARCHAR);

        try {

            PreparedStatement ps = getPreparedStatement(sql, args,
                    Types.VARCHAR);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            BasicDynaClass bdc = new BasicDynaClass("objectCopy",
                    BasicDynaBean.class, rsdc.getDynaProperties());

            DynaBean newRow = null;

            Iterator rows = rsdc.iterator();
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
    public Iterator getData(String sql, Object arg) {

        Object[] newArgs = null;

        // VTL syntax ["foo", "bar"] creates an ArrayList thru Velocity 1.5
        if (arg instanceof ArrayList) {

            logger.debug("converting ArrayList to Object[]");

            ArrayList realArgs = (ArrayList) arg;

            newArgs = realArgs.toArray();

        } else {

            newArgs = new Object[] { arg };
        }
        return getData(sql, newArgs);
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
    public Iterator getData(String sql, Object[] args) {

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
    public Iterator getData(String sql, Object[] args, int type) {

        traceArgs(sql, args, null, type);

        try {

            PreparedStatement ps = getPreparedStatement(sql, args, type);

            ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());

            ArrayList results = new ArrayList();
            BasicDynaClass bdc = new BasicDynaClass("objectCopy",
                    BasicDynaBean.class, rsdc.getDynaProperties());

            // Note: This is ugly but necessary to disconnect the Iterator
            // from the underlining result set and its connection.
            Iterator rows = rsdc.iterator();
            while (rows.hasNext()) {
                DynaBean oldRow = (DynaBean) rows.next();
                DynaBean newRow = bdc.newInstance();
                PropertyUtils.copyProperties(newRow, oldRow);
                results.add(newRow);
            }

            // again, ugly but required for large sets
            ps.close();

            return results.iterator();

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(
                    "Error in getData(): " + ex.getMessage(), ex);
        }

    }

    private Date makeSqlDate(Object val) throws ParseException {
        return new Date(DateUtils.parseDate(val.toString(), DATE_FORMATS)
                .getTime());
    }

    private PreparedStatement getPreparedStatement(String sql, Object[] args,
            int type) {

        checkConnection();

        try {

            PreparedStatement ps = connection.prepareStatement(sql);

            if (args != null && args.length > 0) {

                for (int i = 1; i <= args.length; i++) {

                    Object argVal = args[i - 1];

                    if (type == Types.BIGINT || type == Types.INTEGER) {
                        ps.setInt(i, ((Integer) ConvertUtils.convert(argVal,
                                int.class)).intValue());
                    } else if (type == Types.TIMESTAMP) {
                        ps.setTimestamp(i, new Timestamp(makeSqlDate(argVal)
                                .getTime()));
                    } else if (type == Types.DATE) {
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

        if (args.length > 0) {

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
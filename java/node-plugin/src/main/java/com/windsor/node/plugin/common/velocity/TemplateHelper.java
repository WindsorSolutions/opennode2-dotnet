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

package com.windsor.node.plugin.common.velocity;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

import org.apache.commons.beanutils.converters.BooleanConverter;
import org.apache.commons.lang.StringEscapeUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.time.DateUtils;
import org.apache.commons.lang.time.StopWatch;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Provides a handful of utility methods for rendering data in a VTL template.
 * 
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
public class TemplateHelper {

    public static final String XML_DATE_FORMAT = "yyyy-MM-dd";
    public static final String DATE_FORMAT_ORACLE_DEFAULT = "dd-MMM-yy";
    public static final String TIMESTAMP_FORMAT_MINS = "yyyy-MM-dd HH:mm";
    public static final String TIMESTAMP_FORMAT_SECS = "yyyy-MM-dd HH:mm:ss";
    public static final String TIMESTAMP_FORMAT_MILLI = "yyyy-MM-dd HH:mm:ss.S";
    public static final String TIMESTAMP_FORMAT_MILLI2 = "yyyy-MM-dd HH:mm:ss.SS";
    public static final String TIMESTAMP_FORMAT_MILLI3 = "yyyy-MM-dd HH:mm:ss.SSS";
    public static final String TIMESTAMP_FORMAT_MILLI4 = "yyyy-MM-dd HH:mm:ss.SSSS";
    public static final String AM_PM_INPUT_ERROR = "input must be in hh:mm:ss [AM|PM] format";

    public static final String[] DATE_FORMATS = { XML_DATE_FORMAT,
            DATE_FORMAT_ORACLE_DEFAULT, TIMESTAMP_FORMAT_MINS,
            TIMESTAMP_FORMAT_SECS, TIMESTAMP_FORMAT_MILLI,
            TIMESTAMP_FORMAT_MILLI2, TIMESTAMP_FORMAT_MILLI3,
            TIMESTAMP_FORMAT_MILLI4 };
    protected static final int NUM_TIME_PARTS = 3;
    protected static final int HOURS_IN_HALF_DAY = 12;

    protected Logger logger = LoggerFactory.getLogger(getClass());

    protected StopWatch watch = new StopWatch();
    protected BooleanConverter booleanConverter;
    protected SimpleDateFormat simpleDateFormat;

    /**
     * Default constructor, a convenience for testing utility methods.
     * 
     * <p>
     * If using this constructor, {@link #setConnection(Connection)} must be
     * called prior to attempting any queries.
     * 
     */
    public TemplateHelper() {
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
     * Returns the current time in yyyy-MM-dd format; i.e., today.
     * 
     * @return
     */
    public String currentTimeAsXmlDate() {

        SimpleDateFormat sdfInput = new SimpleDateFormat(XML_DATE_FORMAT);
        return sdfInput.format(Calendar.getInstance(TimeZone.getDefault())
                .getTime());
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

    /**
     * Given a String in hh:mm:ss [AM|PM] format, return a proper XML time
     * String (i.e., in HH:mm:ss format); if input is in hh:mm:ss format, assume
     * 24-hour time.
     * 
     * @param val
     * @return
     */
    public String amPmStringToXmlTime(Object val) {

        String input = (String) val;
        logger.trace("amPmStringToXmlTime: input = " + input);

        boolean isPm = false;

        String[] timeAndAmPm = StringUtils.split(input);

        if (timeAndAmPm.length == 2) {

            String amPm = timeAndAmPm[1];
            isPm = amPm.equalsIgnoreCase("PM");

        } else if (timeAndAmPm.length > 2) {

            throw new IllegalArgumentException(AM_PM_INPUT_ERROR);
        }

        String[] timeParts = StringUtils.split(timeAndAmPm[0], ":");

        if (timeParts.length != NUM_TIME_PARTS) {
            throw new IllegalArgumentException(AM_PM_INPUT_ERROR);
        }

        int hour = Integer.parseInt(timeParts[0]);
        if (isPm) {
            hour = hour + HOURS_IN_HALF_DAY;
        }

        int minute = Integer.parseInt(timeParts[1]);
        int second = Integer.parseInt(timeParts[2]);

        GregorianCalendar cal = new GregorianCalendar();
        cal.set(Calendar.HOUR_OF_DAY, hour);
        cal.set(Calendar.MINUTE, minute);
        cal.set(Calendar.SECOND, second);

        SimpleDateFormat sdfOutput = new SimpleDateFormat("HH:mm:ss");
        String output = sdfOutput.format(cal.getTime());
        logger.trace("amPmStringToXmlTime: output = " + output);

        return output;
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
        if(val != null)
        {
            logger.info(val.toString());
        }
        else
        {
            logger.info(StringUtils.EMPTY);
        }
    }

    protected Date makeSqlDate(Object val) throws ParseException {
        return new Date(DateUtils.parseDate(val.toString(), DATE_FORMATS)
                .getTime());
    }

    protected Object[] trapArrayList(Object arg) {

        Object[] newArgs = null;

        if (null != arg) {

            // VTL syntax ["foo", "bar"] creates an ArrayList thru Velocity 1.5
            if (arg instanceof ArrayList<?>) {

                logger.debug("converting ArrayList to Object[]");

                ArrayList<?> realArgs = (ArrayList<?>) arg;

                newArgs = realArgs.toArray();

            } else {

                newArgs = new Object[] { arg };
            }
        }

        return newArgs;
    }
}

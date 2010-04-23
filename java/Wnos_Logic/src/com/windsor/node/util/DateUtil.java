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

package com.windsor.node.util;

import java.sql.Timestamp;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.TimeZone;

import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormatter;
import org.joda.time.format.ISODateTimeFormat;

public final class DateUtil {

    public static final int YEARS_PER_CENTURY = 100;
    public static final int MONTHS_PER_YEAR = 12;
    public static final int WEEKS_PER_MONTH = 4;
    public static final int DAYS_PER_WEEK = 7;
    public static final int HOURS_PER_DAY = 24;
    public static final int MINUTES_PER_HOUR = 60;
    public static final int SECONDS_PER_MINUTE = 60;

    public static final String XML_DATETIME_FORMAT = "yyyy-MM-dd'T'HH:mm:ss.SSSSZ";

    private static final int YEAR_OFFSET = 4716;

    private static final float DATE_OFFSET = 1524.5f;
    private static final float DAYS_PER_MONTH = 30.6001f;
    private static final float DAYS_PER_YEAR = 365.25f;

    private DateUtil() {
    }

    public static Timestamp getTimestamp() {
        return new Timestamp(System.currentTimeMillis());
    }

    public static Timestamp getTimestamp(Long time) {
        return new Timestamp(time.longValue());
    }

    public static Date getNow() {
        Calendar cal = Calendar.getInstance(TimeZone.getDefault());
        Date today = cal.getTime();
        return today;
    }

    public static Date getStartDate(Date date) {

        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);

        calendar.set(GregorianCalendar.HOUR_OF_DAY, calendar
                .getActualMinimum(GregorianCalendar.HOUR_OF_DAY));

        calendar.set(GregorianCalendar.MINUTE, calendar
                .getActualMinimum(GregorianCalendar.MINUTE));

        calendar.set(GregorianCalendar.SECOND, calendar
                .getActualMinimum(GregorianCalendar.SECOND));

        calendar.set(GregorianCalendar.MILLISECOND, calendar
                .getActualMinimum(GregorianCalendar.MILLISECOND));

        return (Date) calendar.getTime().clone();
    }

    public static Date getEndDate(Date date) {

        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);

        calendar.set(GregorianCalendar.HOUR_OF_DAY, calendar
                .getActualMaximum(GregorianCalendar.HOUR_OF_DAY));

        calendar.set(GregorianCalendar.MINUTE, calendar
                .getActualMaximum(GregorianCalendar.MINUTE));

        calendar.set(GregorianCalendar.SECOND, calendar
                .getActualMaximum(GregorianCalendar.SECOND));

        calendar.set(GregorianCalendar.MILLISECOND, calendar
                .getActualMaximum(GregorianCalendar.MILLISECOND));

        return (Date) calendar.getTime().clone();
    }

    public static Date getNextNMinute(Date date, int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.MINUTE, n);
        return (Date) calendar.getTime().clone();
    }

    public static Date getNextNHour(Date date, int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.HOUR_OF_DAY, n);
        return (Date) calendar.getTime().clone();
    }

    public static Date getNextDay(Date date) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.DAY_OF_MONTH, 1);
        return (Date) calendar.getTime().clone();
    }

    public static Date getNextNDay(Date date, int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.DAY_OF_MONTH, n);
        return (Date) calendar.getTime().clone();
    }

    public static Date getNextNWeek(Date date, int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.DAY_OF_MONTH, n * DAYS_PER_WEEK);
        return (Date) calendar.getTime().clone();
    }

    public static Date getNextNMonth(Date date, int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.add(GregorianCalendar.MONTH, n);
        return (Date) calendar.getTime().clone();
    }

    public static Date getBeginOfMonth(Date date, int months) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        if (months != 0) {
            calendar.add(GregorianCalendar.MONTH, months);
        }
        calendar.set(GregorianCalendar.DAY_OF_MONTH, calendar
                .getActualMinimum(GregorianCalendar.DAY_OF_MONTH));
        return (Date) calendar.getTime().clone();
    }

    public static Date getEndOfMonth(Date date, int months) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        if (months != 0) {
            calendar.add(GregorianCalendar.MONTH, months);
        }
        calendar.set(GregorianCalendar.DAY_OF_MONTH, calendar
                .getActualMaximum(GregorianCalendar.DAY_OF_MONTH));
        return (Date) calendar.getTime().clone();
    }

    public static Date getBeginOfYear(Date date) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.set(GregorianCalendar.MONTH, calendar
                .getActualMinimum(GregorianCalendar.MONTH));
        calendar.set(GregorianCalendar.DAY_OF_MONTH, calendar
                .getActualMinimum(GregorianCalendar.DAY_OF_MONTH));
        calendar.set(GregorianCalendar.HOUR_OF_DAY, calendar
                .getActualMinimum(GregorianCalendar.HOUR_OF_DAY));
        calendar.set(GregorianCalendar.MINUTE, calendar
                .getActualMinimum(GregorianCalendar.MINUTE));
        calendar.set(GregorianCalendar.SECOND, calendar
                .getActualMinimum(GregorianCalendar.SECOND));
        calendar.set(GregorianCalendar.MILLISECOND, calendar
                .getActualMinimum(GregorianCalendar.MILLISECOND));
        return (Date) calendar.getTime().clone();
    }

    public static Date getEndOfYear(Date date) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        calendar.set(GregorianCalendar.MONTH, calendar
                .getActualMaximum(GregorianCalendar.MONTH));
        calendar.set(GregorianCalendar.DAY_OF_MONTH, calendar
                .getActualMaximum(GregorianCalendar.DAY_OF_MONTH));
        calendar.set(GregorianCalendar.HOUR_OF_DAY, calendar
                .getActualMaximum(GregorianCalendar.HOUR_OF_DAY));
        calendar.set(GregorianCalendar.MINUTE, calendar
                .getActualMaximum(GregorianCalendar.MINUTE));
        calendar.set(GregorianCalendar.SECOND, calendar
                .getActualMaximum(GregorianCalendar.SECOND));
        calendar.set(GregorianCalendar.MILLISECOND, calendar
                .getActualMaximum(GregorianCalendar.MILLISECOND));
        return (Date) calendar.getTime().clone();
    }

    public static int getYearOfDate(Date date) {
        GregorianCalendar calendar = new GregorianCalendar();
        return calendar.get(Calendar.YEAR);
    }

    public static Date getEndOfYear(int year) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.set(GregorianCalendar.YEAR, year);
        calendar.set(GregorianCalendar.MONTH, calendar
                .getActualMaximum(GregorianCalendar.MONTH));
        calendar.set(GregorianCalendar.DAY_OF_MONTH, calendar
                .getActualMaximum(GregorianCalendar.DAY_OF_MONTH));
        calendar.set(GregorianCalendar.HOUR_OF_DAY, calendar
                .getActualMaximum(GregorianCalendar.HOUR_OF_DAY));
        calendar.set(GregorianCalendar.MINUTE, calendar
                .getActualMaximum(GregorianCalendar.MINUTE));
        calendar.set(GregorianCalendar.SECOND, calendar
                .getActualMaximum(GregorianCalendar.SECOND));
        calendar.set(GregorianCalendar.MILLISECOND, calendar
                .getActualMaximum(GregorianCalendar.MILLISECOND));
        return (Date) calendar.getTime().clone();
    }

    public static int monthsBetween(Date startDate, Date endDate) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(startDate);
        int startMonth = calendar.get(GregorianCalendar.MONTH);
        int startYear = calendar.get(GregorianCalendar.YEAR);
        calendar.setTime(endDate);
        int endMonth = calendar.get(GregorianCalendar.MONTH);
        int endYear = calendar.get(GregorianCalendar.YEAR);
        return (endYear - startYear) * MONTHS_PER_YEAR
                + (endMonth - startMonth);
    }

    public static int daysBetween(Date startDate, Date endDate) {
        Calendar c1 = Calendar.getInstance();
        Calendar c2 = Calendar.getInstance();
        c1.setTime(startDate);
        c2.setTime(endDate);
        return daysBetween(c1, c2);
    }

    public static int daysBetween(Calendar early, Calendar late) {
        return (int) (toJulian(late) - toJulian(early));
    }

    public static float toJulian(Calendar cal) {
        int y = cal.get(Calendar.YEAR);
        int m = cal.get(Calendar.MONTH);
        int d = cal.get(Calendar.DATE);
        int a = y / YEARS_PER_CENTURY;
        int b = a / WEEKS_PER_MONTH;
        int c = 2 - a + b;
        float e = (int) (DAYS_PER_YEAR * (y + YEAR_OFFSET));
        float f = (int) (DAYS_PER_MONTH * (m + 1));
        float jd = (c + d + e + f) - DATE_OFFSET;
        return jd;
    }

    /**
     * Given these forms of an XML Datetime
     * 
     * <pre>
     * 2009-05-12T11:58:40.8125-07:00
     * 2009-05-12T11:58:40.8125Z
     * </pre>
     * 
     * (with or without milliseconds), return the milliseconds since the
     * beginning of Java time.
     * 
     * @param xmlDateTimeString
     * @return
     */
    public static long xmlDateTimeToMillisec(String xmlDateTimeString) {

        DateTimeFormatter dtf = ISODateTimeFormat.dateTime();

        DateTime dt = dtf.parseDateTime(xmlDateTimeString);

        return dt.getMillis();
    }

    /**
     * Given this form of an XML Datetime
     * 
     * <pre>
     * 2009-05-12T11:58:40.8125-07:00
     * </pre>
     * 
     * (with or without milliseconds), return a JDBC Timestamp encapsulating the
     * same time.
     * 
     * @param xmlDateTimeString
     * @return
     */
    public static Timestamp xmlDateTimeToJdbcTimestamp(String xmlDateTimeString) {

        return new Timestamp(xmlDateTimeToMillisec(xmlDateTimeString));

    }
}
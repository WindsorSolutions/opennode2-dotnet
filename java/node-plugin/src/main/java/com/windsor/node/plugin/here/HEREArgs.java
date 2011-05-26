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

package com.windsor.node.plugin.here;

import java.io.File;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.TimeZone;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.builder.ReflectionToStringBuilder;

import com.windsor.node.common.domain.DomainStringStyle;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.plugin.here.dao.HereDao;

public class HEREArgs {

    private static final String YYYY_MM_DD = "yyyy-MM-dd";
    private static final int HALF_CENTURY = 50;

    private String flowId;
    private int numOfDays;
    private String serviceName;
    private String tempFilePath;
    private String tempFileName;
    private Date changeDate;
    private Timestamp changeDateTime;

    public HEREArgs(NodeTransaction transaction, File targetDir,
            boolean argAsDate) {

        if (transaction == null || transaction.getRequest() == null) {
            throw new RuntimeException("bad or null transaction");
        }

        if (transaction.getRequest().getParameterValues() == null
                || transaction.getRequest().getParameterValues().length != 1) {

            String errMsg = null;

            if (argAsDate) {

                errMsg = "Invalid arguments. Need one arg with a date in "
                        + YYYY_MM_DD + " format.";

            } else {

                errMsg = "Invalid arguments. Need one arg with a number of days.";
            }

            throw new RuntimeException(errMsg);
        }

        if (targetDir == null || !targetDir.exists()
                || !targetDir.isDirectory()) {
            throw new RuntimeException("Invalid targetDir argument");
        }

        String[] args = transaction.getRequest().getParameterValues();
        this.flowId = transaction.getRequest().getFlowName();
        this.serviceName = transaction.getRequest().getService().getName();

        if (argAsDate) {
            this.changeDate = parseDate(args[0]);
        } else {
            this.numOfDays = Integer.parseInt(args[0]);
            this.changeDate = getDate(numOfDays);
        }

        this.changeDateTime = new Timestamp(this.changeDate.getTime());

        this.tempFileName = serviceName + System.currentTimeMillis() + ".xml";
        this.tempFilePath = FilenameUtils.concat(targetDir.getAbsolutePath(),
                tempFileName);

    }

    public Date parseDate(String text) {

        try {
            SimpleDateFormat sdfInput = new SimpleDateFormat(YYYY_MM_DD);
            return sdfInput.parse(text);
        } catch (ParseException pex) {
            throw new RuntimeException(
                    "Invalid date format. Expected: yyyy-MM-dd Got: " + text);
        }

    }

    public Date getNow() {
        Calendar cal = Calendar.getInstance(TimeZone.getDefault());
        Date today = cal.getTime();
        return today;
    }

    public Date getDate(int numOfDays) {

        if (numOfDays < 0 || numOfDays > HereDao.MIN_FULL_REFRESH_DAY_COUNT) {
            return getMinDay();
        } else {
            return getNextNDay(-numOfDays);
        }

    }

    public String toXmlDateTime(Object obj) {

        SimpleDateFormat sdfInput = new SimpleDateFormat(
                "yyyy-MM-dd'T'HH:mm:ss.S");
        return sdfInput.format(obj);

    }

    public String toXmlDate(Date date) {

        SimpleDateFormat sdfInput = new SimpleDateFormat(YYYY_MM_DD);
        return sdfInput.format(date);

    }

    public Date getNextNDay(int n) {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(getNow());
        calendar.add(GregorianCalendar.DAY_OF_MONTH, n);
        return getStartDate((Date) calendar.getTime().clone());
    }

    public Date getStartDate(Date date) {

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

    public Date getMinDay() {
        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(getNow());
        calendar.add(GregorianCalendar.YEAR, -HALF_CENTURY);
        return (Date) calendar.getTime().clone();
    }

    public String getFlowId() {
        return flowId;
    }

    public int getNumOfDays() {
        return numOfDays;
    }

    public String getServiceName() {
        return serviceName;
    }

    public String getTempFilePath() {
        return tempFilePath;
    }

    public Date getChangeDate() {
        return changeDate;
    }

    public String getTempFileName() {
        return tempFileName;
    }

    public Timestamp getChangeDateTime() {
        return changeDateTime;
    }

    /**
     * Constructs a <code>String</code> with all attributes in name = value
     * format.
     * 
     * @return a <code>String</code> representation of this object.
     */

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();

    }
}
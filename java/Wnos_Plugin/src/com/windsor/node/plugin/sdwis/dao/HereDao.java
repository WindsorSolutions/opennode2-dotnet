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

package com.windsor.node.plugin.sdwis.dao;

import java.sql.Timestamp;
import java.sql.Types;
import java.util.Date;

import javax.sql.DataSource;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.jdbc.core.JdbcTemplate;

public class HereDao extends JdbcTemplate {

    public static final String HERE_YES = "Y";
    public static final String HERE_NO = "N";

    public static final int MIN_FULL_REFRESH_DAY_COUNT = 365;

    public static final String FLOW_HERE = "HERE";
    public static final String FLOW_HERE_DOMAIN = "HERE-DOMAIN";
    public static final String FLOW_HERE_DELETE = "HERE-DELETE";
    public static final String FLOW_HERE_FRS = "HERE-FRS";
    public static final String FLOW_HERE_CAFO = "HERE-CAFO";
    public static final String FLOW_HERE_TIER2 = "HERE-TIER2";

    public static final String SQL_DELETE_BY_FLOW_NAME = "DELETE FROM HERE_Manifest WHERE DataExchangeName = ? ";

    public static final String SQL_INSERT = "INSERT INTO HERE_MANIFEST "
            + "(TRANSACTIONID, ENDPOINTURL, DATAEXCHANGENAME, "
            + "ISFACILITYSOURCEINDICATOR, SOURCESYSTEMNAME, "
            + "FULLREPLACEINDICATOR, CREATEDDATE) VALUES (?,?,?,?,?,?,?)";

    protected Logger logger = Logger.getLogger(getClass());

    public HereDao(DataSource ds) {
        super.setDataSource(ds);
    }

    public void saveResults(String transactionId, String flowName,
            String endpointUri, boolean isFacility, String sourceSystemName,
            int numberOfDays) {

        if (StringUtils.isBlank(transactionId)) {
            throw new IllegalArgumentException("transactionId not set");
        }
        logger.debug("transactionId = " + transactionId);

        if (StringUtils.isBlank(endpointUri)) {
            throw new IllegalArgumentException("endpointUri not set");
        }
        logger.debug("endpointUri = " + endpointUri);

        if (StringUtils.isBlank(flowName)) {
            throw new IllegalArgumentException("flowName not set");
        }
        logger.debug("flowName = " + flowName);

        boolean isFullReplace = numberOfDays > MIN_FULL_REFRESH_DAY_COUNT
                || numberOfDays < 0;
        logger.debug("isFullReplace = " + isFullReplace);

        try {

            if (isFullReplace) {

                logger.debug(SQL_DELETE_BY_FLOW_NAME + " : " + flowName);

                update(SQL_DELETE_BY_FLOW_NAME, new Object[] { flowName });

                if ((flowName.equalsIgnoreCase(FLOW_HERE_FRS))
                        || (flowName.equalsIgnoreCase(FLOW_HERE_CAFO))
                        || (flowName.equalsIgnoreCase(FLOW_HERE_TIER2))
                        || (flowName.equalsIgnoreCase(FLOW_HERE_DOMAIN))) {
                    update("DELETE FROM HERE_Manifest WHERE DataExchangeName = '"
                            + FLOW_HERE_DELETE + "' ");
                }
            }

            Object[] args = new Object[7];
            args[0] = transactionId;
            args[1] = endpointUri;
            args[2] = flowName;
            args[3] = isFacility ? HERE_YES : HERE_NO;
            args[4] = sourceSystemName;
            args[5] = isFullReplace ? HERE_YES : HERE_NO;
            args[6] = new Timestamp(new Date().getTime());

            int[] types = new int[7];
            types[0] = Types.VARCHAR;
            types[1] = Types.VARCHAR;
            types[2] = Types.VARCHAR;
            types[3] = Types.VARCHAR;
            types[4] = Types.VARCHAR;
            types[5] = Types.VARCHAR;
            types[6] = Types.DATE;

            logger.debug(SQL_INSERT);

            update(SQL_INSERT, args, types);

        } catch (Exception ex) {

            logger.error(ex);

            throw new RuntimeException("Errors while saving manifest results: "
                    + ex.getMessage(), ex);

        }

    }

}
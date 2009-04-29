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

/**
 * 
 */
package com.windsor.node.plugin.wqx.dao;

import java.sql.Timestamp;
import java.sql.Types;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.common.dao.BaseJdbcDao;

/**
 * Handles saving submission status to WQX_SUBMISSIONHISTORY table.
 * 
 */
public class WqxStatusDao extends BaseJdbcDao {

    public static final String TABLE_NAME = "WQX_SUBMISSIONHISTORY";
    public static final String ORG_TABLE_NAME = "WQX_ORGANIZATION";
    public static final String RECORD_ID = "RECORDID";
    public static final String SUBMISSION_TYPE = "SUBMISSIONTYPE";
    public static final String STATUS = "CDXPROCESSINGSTATUS";
    public static final String WQXUPDATEDATE = "WQXUPDATEDATE";

    public static final String RESET = "Reset";

    public static final String SQL_INSERT = INSERT + TABLE_NAME
            + " VALUES( ?, ?, ?, ?, ?, ?, ? )";

    public static final String SQL_UPDATE_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS_PARAM + WHERE + RECORD_ID + EQUALS_PARAM;

    public static final String SQL_RESET_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS + APOS + RESET + APOS + WHERE + STATUS + EQUALS
            + APOS + CommonTransactionStatusCode.PENDING_STR + APOS;

    public static final String SQL_SELECT_ID_BY_OPERATION_TYPE = SELECT
            + RECORD_ID + FROM + TABLE_NAME + WHERE + SUBMISSION_TYPE
            + EQUALS_PARAM;

    public static final String SQL_SELECT_ID_BY_OPERATION_TYPE_AND_STATUS = SQL_SELECT_ID_BY_OPERATION_TYPE
            + AND + STATUS + EQUALS_PARAM;

    public static final String SQL_SELECT_LATEST_PENDING_DATE = SELECT + "max("
            + WQXUPDATEDATE + R_PAREN + FROM + TABLE_NAME + WHERE + STATUS
            + EQUALS + APOS + CommonTransactionStatusCode.PENDING_STR + APOS;

    public static final String SQL_SELECT_ORG_PK_BY_ORG_ID = SELECT + RECORD_ID
            + FROM + ORG_TABLE_NAME + WHERE + "ORGID" + EQUALS_PARAM;

    public static final String NO_NEW_STATUS_WHEN_PENDING = "Can't create \"Pending\" status when a transaction is already pending.";

    private int[] argTypes = new int[] { Types.VARCHAR, Types.VARCHAR,
            Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR,
            Types.VARCHAR };

    /**
     * @param dataSource
     */
    public WqxStatusDao(DataSource dataSource) {
        super();
        super.setDataSource(dataSource);
    }

    protected void checkDaoConfig() {
        super.checkDaoConfig();
    }

    public String createStatus(String id, String orgId, String submissionType,
            String localTransactionId, String status) {

        checkDaoConfig();
        logger.debug("createStatus");

        if (status.equals(CommonTransactionStatusCode.PENDING_STR)
                && getLatestPendingTimestamp() != null) {

            throw new UnsupportedOperationException(NO_NEW_STATUS_WHEN_PENDING);
        }

        Object[] args = new Object[] { id, orgId,
                new Timestamp(System.currentTimeMillis()),
                new Timestamp(System.currentTimeMillis()),
                submissionType.toString(), localTransactionId, status };

        logger.debug("args: ");
        for (int i = 0; i < args.length; i++) {
            logger.debug(args[i].toString());
        }

        logger.debug("sql: " + SQL_INSERT);
        getJdbcTemplate().update(SQL_INSERT, args, argTypes);

        return id;
    }

    public void updateStatus(String id, String status) {

        checkDaoConfig();
        logger.debug("updateStatus");

        if (status.equals(CommonTransactionStatusCode.PENDING_STR)
                && getLatestPendingTimestamp() != null) {

            throw new UnsupportedOperationException(NO_NEW_STATUS_WHEN_PENDING);
        }

        logger.debug("sql: " + SQL_UPDATE_STATUS);
        getJdbcTemplate().update(SQL_UPDATE_STATUS,
                new Object[] { id, status },
                new int[] { Types.VARCHAR, Types.VARCHAR });

    }

    public void resetStatus() {

        checkDaoConfig();
        logger.debug("resetStatus");

        logger.debug("sql: " + SQL_RESET_STATUS);
        getJdbcTemplate().update(SQL_RESET_STATUS);

    }

    public Timestamp getLatestPendingTimestamp() {

        checkDaoConfig();
        logger.debug("getLatestPendingDate");

        Timestamp t = null;

        logger.debug("sql: " + SQL_SELECT_LATEST_PENDING_DATE);
        t = (Timestamp) getJdbcTemplate().queryForObject(
                SQL_SELECT_LATEST_PENDING_DATE, Timestamp.class);

        return t;
    }

    public String getPrimaryKeyForOrgId(String orgId) {

        checkDaoConfig();
        logger.debug("getPrimaryKeyForOrgId");

        logger.debug("sql: " + SQL_SELECT_ORG_PK_BY_ORG_ID);
        return (String) getJdbcTemplate().queryForObject(
                SQL_SELECT_ORG_PK_BY_ORG_ID, new Object[] { orgId },
                String.class);
    }

}

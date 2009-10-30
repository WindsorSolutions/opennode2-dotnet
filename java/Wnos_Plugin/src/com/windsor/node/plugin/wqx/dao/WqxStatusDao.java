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
import java.util.List;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.common.dao.BaseJdbcDao;
import com.windsor.node.plugin.wqx.WqxOperationType;

/**
 * Handles saving submission status to WQX_SUBMISSIONHISTORY table.
 * 
 */
public class WqxStatusDao extends BaseJdbcDao {

    /** Constant for the table we're dealing with. */
    public static final String TABLE_NAME = "WQX_SUBMISSIONHISTORY";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String ORG_TABLE_NAME = "WQX_ORGANIZATION";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String RECORD_ID = "RECORDID";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String PARENT_ID = "PARENTID";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String SUBMISSION_TYPE = "SUBMISSIONTYPE";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String STATUS = "CDXPROCESSINGSTATUS";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String WQXUPDATEDATE = "WQXUPDATEDATE";

    /** Column name from WQX_SUBMISSIONHISTORY. */
    public static final String TRAN_ID = "LOCALTRANSACTIONID";

    /** Column name from WQX_ORGANIZATION. */
    public static final String ORG_ID = "ORGID";

    public static final String RESET = "Reset";

    public static final String NO_NEW_STATUS_WHEN_PENDING = "Can't create \"Pending\" "
            + " or \"Processing\" status when a transaction "
            + "for that Organization and Operation type is already Pending or Processing.";

    public static final String NO_PENDING_FOUND = "No Pending or Processing transactions found for orgId ";

    private static final String SQL_SELECT_ORG_PK_BY_ORG_ID = SELECT
            + RECORD_ID + FROM + ORG_TABLE_NAME + WHERE + ORG_ID + EQUALS_PARAM;

    private static final String ORG_PK_FROM_ORG_ID = PARENT_ID + IN + L_PAREN
            + SQL_SELECT_ORG_PK_BY_ORG_ID + R_PAREN;

    private static final String SQL_INSERT = INSERT + TABLE_NAME
            + " VALUES( ?, ?, ?, ?, ?, ?, ? )";

    private static final String SQL_UPDATE_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS_PARAM + WHERE + TRAN_ID + EQUALS_PARAM;

    private static final String STATUS_PENDING_OR_PROCESSING = L_PAREN
            + L_PAREN + STATUS + EQUALS + APOS
            + CommonTransactionStatusCode.PENDING.name() + APOS + R_PAREN + OR
            + L_PAREN + STATUS + EQUALS + APOS
            + CommonTransactionStatusCode.PROCESSING.name() + APOS + R_PAREN
            + R_PAREN;

    private static final String SQL_RESET_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS + APOS + RESET + APOS + WHERE
            + STATUS_PENDING_OR_PROCESSING + AND + ORG_PK_FROM_ORG_ID;

    private static final String SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE = SELECT
            + "max("
            + WQXUPDATEDATE
            + R_PAREN
            + FROM
            + TABLE_NAME
            + WHERE
            + SUBMISSION_TYPE
            + EQUALS_PARAM
            + AND
            + STATUS_PENDING_OR_PROCESSING + AND + ORG_PK_FROM_ORG_ID;

    private static final String SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID = SELECT
            + " COUNT(*)"
            + FROM
            + TABLE_NAME
            + WHERE
            + STATUS_PENDING_OR_PROCESSING
            + AND
            + SUBMISSION_TYPE
            + EQUALS_PARAM + AND + ORG_PK_FROM_ORG_ID;

    private static final String SQL_SELECT_PENDING_TRAN = SELECT + TRAN_ID
            + FROM + TABLE_NAME + WHERE + STATUS_PENDING_OR_PROCESSING + AND
            + SUBMISSION_TYPE + EQUALS_PARAM + AND + ORG_PK_FROM_ORG_ID;

    private static final String SQL_SELECT_ALL_PENDING_TRANS = SELECT + TRAN_ID
            + FROM + TABLE_NAME + WHERE + STATUS_PENDING_OR_PROCESSING + AND
            + ORG_PK_FROM_ORG_ID;

    private static final String OPERATION_TYPE_EQUALS = ", operationType = ";
    private static final String SQL = "sql: ";

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

    /**
     * Creates a row in WQX_SUBMISSIONHISTORY if no row with an operation type
     * of <code>WqxOperationType.UPDATE_INSERT</code> or
     * <code>WqxOperationType.DELETE</code> and status of &quot;pending&quot;
     * exists - otherwise throws an {@link UnsupportedOperationException}.
     * 
     * @param id
     *            primary key for the new row
     * @param orgId
     *            Organization identifier
     * @param operationType
     *            one of WqxOperationType.UPDATE_INSERT or
     *            WqxOperationType.DELETE
     * @param localTransactionId
     * @param status
     *            values specified by {@link CommonTransactionStatusCode}
     * 
     */
    public void createStatus(String id, String orgId,
            WqxOperationType operationType, String localTransactionId,
            CommonTransactionStatusCode status) {

        checkDaoConfig();
        logger.debug("createStatus");
        logger.debug("id = " + id);
        logger.debug("orgId = " + orgId);
        logger.debug("operationType = " + operationType);
        logger.debug("localTransactionId = " + localTransactionId);
        logger.debug("status = " + status);

        if (null != getPendingTransactionId(orgId, operationType)) {

            throw new UnsupportedOperationException(NO_NEW_STATUS_WHEN_PENDING);
        }

        String orgPk = getPrimaryKeyForOrgId(orgId);

        Object[] args = new Object[] { id, orgPk,
                new Timestamp(System.currentTimeMillis()),
                new Timestamp(System.currentTimeMillis()),
                operationType.getName(), localTransactionId, status.name() };

        logger.debug("args: ");
        for (int i = 0; i < args.length; i++) {
            logger.debug(args[i].toString());
        }

        logger.debug(SQL + SQL_INSERT);
        getJdbcTemplate().update(SQL_INSERT, args, argTypes);

    }

    public String getPendingTransactionId(String orgId,
            WqxOperationType operationType) {

        String tranId = null;

        checkDaoConfig();
        logger.debug("getPendingTransactionId: orgId = " + orgId
                + OPERATION_TYPE_EQUALS + operationType);

        if (countPending(orgId, operationType) > 0) {
            tranId = (String) getJdbcTemplate().queryForObject(
                    SQL_SELECT_PENDING_TRAN,
                    new Object[] { operationType.getName(), orgId },
                    String.class);
        }
        return tranId;

    }

    @SuppressWarnings("unchecked")
    public List<String> getPendingTransactionIds(String orgId) {

        List<String> idList = null;

        checkDaoConfig();
        logger.debug("getPendingTransactionIds for orgId " + orgId);

        logger.debug(SQL + SQL_SELECT_ALL_PENDING_TRANS);
        idList = (List<String>) getJdbcTemplate().queryForList(
                SQL_SELECT_ALL_PENDING_TRANS, new Object[] { orgId },
                String.class);

        return idList;
    }

    public Timestamp getLatestProcessedTimestamp(String orgId,
            WqxOperationType operationType) {

        Timestamp ts = null;

        logger.debug("getLatestProcessedTimestamp: orgId = " + orgId
                + OPERATION_TYPE_EQUALS + operationType);
        checkDaoConfig();

        logger.debug(SQL
                + SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE);

        ts = (Timestamp) getJdbcTemplate().queryForObject(
                SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE,
                new Object[] { operationType.getName(), orgId },
                Timestamp.class);

        return ts;

    }

    public void updateStatus(String tranId,
            CommonTransactionStatusCode newStatus) {

        checkDaoConfig();
        logger.debug("updateStatus: tranId = " + tranId + ", newStatus = "
                + newStatus);

        logger.debug(SQL + SQL_UPDATE_STATUS);
        getJdbcTemplate().update(SQL_UPDATE_STATUS,
                new Object[] { newStatus.name(), tranId });
    }

    /**
     * Sets value of &quot;CDXPROCESSINGSTATUS&quot; from &quot;Pending&quot; to
     * &quot;Reset&quot; for a given OrgId.
     */
    public int resetStatus(String orgId) {

        checkDaoConfig();
        logger.debug("resetStatus");

        int rowCount;

        logger.debug(SQL + SQL_RESET_STATUS);
        rowCount = getJdbcTemplate().update(SQL_RESET_STATUS,
                new Object[] { orgId });

        logger.debug("Reset " + rowCount + " rows for OrgId " + orgId);
        return rowCount;

    }

    public String getPrimaryKeyForOrgId(String orgId) {

        checkDaoConfig();
        logger.debug("getPrimaryKeyForOrgId");

        logger.debug(SQL + SQL_SELECT_ORG_PK_BY_ORG_ID);
        return (String) getJdbcTemplate().queryForObject(
                SQL_SELECT_ORG_PK_BY_ORG_ID, new Object[] { orgId },
                String.class);
    }

    private int countPending(String orgId, WqxOperationType operationType) {

        checkDaoConfig();

        logger.debug(SQL + SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID);
        return getJdbcTemplate().queryForInt(
                SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID,
                new Object[] { operationType.getName(), orgId });
    }

}

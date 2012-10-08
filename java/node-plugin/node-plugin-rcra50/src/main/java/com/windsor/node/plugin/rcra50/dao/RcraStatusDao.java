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
package com.windsor.node.plugin.rcra50.dao;

import java.sql.Timestamp;
import java.sql.Types;
import java.util.List;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.common.dao.BaseJdbcDao;
import com.windsor.node.plugin.rcra50.RcraOperationType;

/**
 * Handles saving submission status to RCRA_SUBMISSIONHISTORY table.
 * 
 */
public class RcraStatusDao extends BaseJdbcDao {

    /** Constant for the table we're dealing with. */
    public static final String TABLE_NAME = "RCRA_SUBMISSIONHISTORY";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String RECORD_ID = "RECORDID";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String PARENT_ID = "PARENTID";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String SUBMISSION_TYPE = "SUBMISSIONTYPE";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String STATUS = "CDXPROCESSINGSTATUS";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String RCRAUPDATEDATE = "RCRAUPDATEDATE";

    /** Column name from RCRA_SUBMISSIONHISTORY. */
    public static final String TRAN_ID = "LOCALTRANSACTIONID";

    public static final String RESET = "Reset";

    public static final String NO_PENDING_FOUND = "No Pending or Processing transactions found for operation type";
    private static final String SQL_INSERT = INSERT + TABLE_NAME
            + " VALUES( ?, ?, ?, ?, ?, ?)";

    private static final String SQL_UPDATE_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS_PARAM + WHERE + TRAN_ID + EQUALS_PARAM;

    private static final String STATUS_PENDING_OR_PROCESSING = L_PAREN
            + L_PAREN + STATUS + EQUALS + APOS
            + CommonTransactionStatusCode.Pending.name() + APOS + R_PAREN + OR
            + L_PAREN + STATUS + EQUALS + APOS
            + CommonTransactionStatusCode.Processing.name() + APOS + R_PAREN
            + R_PAREN;

    private static final String STATUS_PROCESSED = L_PAREN + STATUS + EQUALS
            + APOS + CommonTransactionStatusCode.Processed.name() + APOS
            + R_PAREN;

    private static final String SQL_RESET_STATUS = UPDATE + TABLE_NAME + SET
            + STATUS + EQUALS + APOS + RESET + APOS + WHERE
            + STATUS_PENDING_OR_PROCESSING + AND + SUBMISSION_TYPE
            + EQUALS_PARAM;

    private static final String SQL_SELECT_LATEST_PROCESSED_BY_OPERATION_TYPE = SELECT
            + "max("
            + RCRAUPDATEDATE
            + R_PAREN
            + FROM
            + TABLE_NAME
            + WHERE
            + SUBMISSION_TYPE + EQUALS_PARAM + AND + STATUS_PROCESSED;

    private static final String SQL_COUNT_PENDING_BY_OPERATION_TYPE = SELECT
            + " COUNT(*)" + FROM + TABLE_NAME + WHERE
            + STATUS_PENDING_OR_PROCESSING + AND + SUBMISSION_TYPE
            + EQUALS_PARAM;

    private static final String SQL_SELECT_PENDING_TRAN = SELECT + TRAN_ID
            + FROM + TABLE_NAME + WHERE + STATUS_PENDING_OR_PROCESSING + AND
            + SUBMISSION_TYPE + EQUALS_PARAM;

    private static final String SQL_SELECT_ALL_PENDING_TRANS = SELECT + TRAN_ID
            + FROM + TABLE_NAME + WHERE + STATUS_PENDING_OR_PROCESSING;

    private static final String OPERATION_TYPE_EQUALS = ", operationType = ";
    private static final String SQL = "sql: ";

    private int[] argTypes = new int[] { Types.VARCHAR, Types.TIMESTAMP,
            Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR };

    /**
     * @param dataSource
     */
    public RcraStatusDao(DataSource dataSource) {
        super();
        super.setDataSource(dataSource);
    }

    protected void checkDaoConfig() {
        super.checkDaoConfig();
    }

    /**
     * Creates a row in RCRA_SUBMISSIONHISTORY if no row with an operation of
     * the given type and status of &quot;pending&quot; exists - otherwise
     * throws an {@link UnsupportedOperationException}.
     * 
     * @param id
     *            primary key for the new row
     * @param operationType
     * @param localTransactionId
     * @param status
     *            values specified by {@link CommonTransactionStatusCode}
     * 
     */
    public void createStatus(String id, RcraOperationType operationType,
            String localTransactionId, CommonTransactionStatusCode status) {

        checkDaoConfig();
        logger.debug("createStatus");
        logger.debug("id = " + id);
        logger.debug("operationType = " + operationType);
        logger.debug("localTransactionId = " + localTransactionId);
        logger.debug("status = " + status);

        if (null != getPendingTransactionId(operationType)) {

            throw new UnsupportedOperationException(
                    "Can't create status record when a \""
                            + operationType.toString()
                            + "\" transaction is Pending or Processing");
        }

        Object[] args = new Object[] { id,
                new Timestamp(System.currentTimeMillis()),
                new Timestamp(System.currentTimeMillis()),
                operationType.toString(), localTransactionId, status.name() };

        logger.debug("args: ");
        for (int i = 0; i < args.length; i++) {
            logger.debug(args[i].toString());
        }

        logger.debug(SQL + SQL_INSERT);
        getJdbcTemplate().update(SQL_INSERT, args, argTypes);

    }

    public String getPendingTransactionId(RcraOperationType operationType) {

        String tranId = null;

        checkDaoConfig();
        logger.debug("getPendingTransactionId: " + OPERATION_TYPE_EQUALS
                + operationType);

        if (countPending(operationType) > 0) {
            tranId = (String) getJdbcTemplate().queryForObject(
                    SQL_SELECT_PENDING_TRAN,
                    new Object[] { operationType.toString() }, String.class);
        }
        return tranId;

    }

    @SuppressWarnings("unchecked")
    public List<String> getPendingTransactionIds() {

        List<String> idList = null;

        checkDaoConfig();
        logger.debug("getPendingTransactionIds");

        logger.debug(SQL + SQL_SELECT_ALL_PENDING_TRANS);
        idList = (List<String>) getJdbcTemplate().queryForList(
                SQL_SELECT_ALL_PENDING_TRANS, String.class);

        return idList;
    }

    public Timestamp getLatestProcessedTimestamp(RcraOperationType operationType) {

        Timestamp ts = null;

        logger.debug("getLatestProcessedTimestamp: " + OPERATION_TYPE_EQUALS
                + operationType);
        checkDaoConfig();

        logger.debug(SQL + SQL_SELECT_LATEST_PROCESSED_BY_OPERATION_TYPE);

        ts = (Timestamp) getJdbcTemplate().queryForObject(
                SQL_SELECT_LATEST_PROCESSED_BY_OPERATION_TYPE,
                new Object[] { operationType.toString() },
                new int[] { Types.VARCHAR }, Timestamp.class);

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
     * &quot;Reset&quot; for a given RcraOperationType.
     */
    public int resetStatus(RcraOperationType opType) {

        checkDaoConfig();
        logger.debug("resetStatus");

        int rowCount;

        logger.debug(SQL + SQL_RESET_STATUS);
        rowCount = getJdbcTemplate().update(SQL_RESET_STATUS,
                new Object[] { opType.toString() });

        logger.debug("Reset " + rowCount + " rows for OrgId " + opType);
        return rowCount;

    }

    private int countPending(RcraOperationType operationType) {

        checkDaoConfig();

        logger.debug(SQL + SQL_COUNT_PENDING_BY_OPERATION_TYPE);
        return getJdbcTemplate().queryForInt(
                SQL_COUNT_PENDING_BY_OPERATION_TYPE,
                new Object[] { operationType.toString() });
    }

}

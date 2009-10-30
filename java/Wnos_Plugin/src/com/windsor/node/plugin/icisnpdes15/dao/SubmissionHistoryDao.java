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

package com.windsor.node.plugin.icisnpdes15.dao;

import java.sql.Timestamp;
import java.sql.Types;
import java.util.List;

import javax.sql.DataSource;

import com.windsor.node.plugin.common.dao.BaseJdbcDao;
import com.windsor.node.service.helper.id.UUIDGenerator;

public class SubmissionHistoryDao extends BaseJdbcDao {

    /**
     * 
     */
    private static final String MSG_ICIS_ID = "icisId: ";

    /** Constant for the table we're dealing with. */
    protected static final String TABLE_NAME = "ICIS_SUBM_HISTORY";

    /** Column name. */
    protected static final String SUBM_HISTORY_ID = "SUBM_HISTORY_ID";

    /** Column name. */
    protected static final String DOCUMENT_HEADER_ID = "DOCUMENT_HEADER_ID";

    /** Column name. */
    protected static final String SUBMIT_DATE = "SUBMIT_DATE";

    /** Column name. */
    protected static final String LAST_PAYLOAD_UPDATE_DATE = "LAST_PAYLOAD_UPDATE_DATE";

    /** Column name. */
    protected static final String LOCAL_TRANS_ID = "LOCAL_TRANS_ID";

    protected static final String SQL_INSERT_SUBM_HIST = INSERT + TABLE_NAME
            + VALUES + L_PAREN + "?, ?, ?, ?, ?" + R_PAREN;

    protected static final String SQL_GET_LAST_UPDATE_BY_HEADER_ID = SELECT
            + MAX + LAST_PAYLOAD_UPDATE_DATE + R_PAREN + FROM + TABLE_NAME
            + WHERE + DOCUMENT_HEADER_ID + EQUALS_PARAM;

    protected static final String SQL_GET_LAST_SUBMIT_BY_HEADER_ID = SELECT
            + MAX + SUBMIT_DATE + R_PAREN + FROM + TABLE_NAME + WHERE
            + DOCUMENT_HEADER_ID + EQUALS_PARAM;

    protected static final String SQL_GET_LAST_TRAN_ID_BY_HEADER_ID = SELECT
            + LOCAL_TRANS_ID + FROM + TABLE_NAME + WHERE + DOCUMENT_HEADER_ID
            + EQUALS_PARAM + AND + SUBMIT_DATE + EQUALS_PARAM;

    protected static final String SQL_GET_DISTINCT_TRAN_IDS = SELECT + DISTINCT
            + LOCAL_TRANS_ID + FROM + TABLE_NAME;

    // protected static final String SQL_GET_LAST_TRAN_ID_BY_HEADER_ID = SELECT
    // + LOCAL_TRANS_ID + FROM + TABLE_NAME + WHERE + DOCUMENT_HEADER_ID
    // + EQUALS_PARAM + AND + SUBMIT_DATE + IN + L_PAREN
    // + SQL_GET_LAST_SUBMIT_BY_HEADER_ID + R_PAREN;

    public SubmissionHistoryDao(DataSource dataSource) {
        super();
        super.setDataSource(dataSource);
    }

    protected void checkDaoConfig() {
        super.checkDaoConfig();
    }

    public void insertSubmissionHistory(String icisId, Timestamp submitDate,
            Timestamp lastPayloadUpdate, String localTranId) {

        int[] argTypes = new int[] { Types.VARCHAR, Types.VARCHAR,
                Types.TIMESTAMP, Types.TIMESTAMP, Types.VARCHAR };

        String newId = UUIDGenerator.makeId();
        Object[] args = new Object[] { newId, icisId, submitDate,
                lastPayloadUpdate, localTranId };

        logger.debug(SQL_INSERT_SUBM_HIST);
        logger.debug("args: " + newId + COMMA + icisId + COMMA + submitDate
                + COMMA + lastPayloadUpdate + COMMA + localTranId);

        getJdbcTemplate().update(SQL_INSERT_SUBM_HIST, args, argTypes);

    }

    public Timestamp getLastPayloadUpdateByIcisId(String icisId) {

        logger.debug(SQL_GET_LAST_UPDATE_BY_HEADER_ID);
        logger.debug(MSG_ICIS_ID + icisId);

        Timestamp lastPayloadUpdateDate = (Timestamp) getJdbcTemplate()
                .queryForObject(SQL_GET_LAST_UPDATE_BY_HEADER_ID,
                        new Object[] { icisId }, Timestamp.class);

        return lastPayloadUpdateDate;
    }

    public String getLatestTranIdForIcisId(String icisId) {

        String tranId = null;

        /*
         * Pre-emptive query to avoid a Spring exception when an "in" clause
         * doesn't return any data (see commented sql string). Inefficient, but
         * reliable.
         */
        Timestamp ts = (Timestamp) getJdbcTemplate().queryForObject(
                SQL_GET_LAST_SUBMIT_BY_HEADER_ID, new Object[] { icisId },
                Timestamp.class);

        if (null != ts) {

            logger.debug(SQL_GET_LAST_TRAN_ID_BY_HEADER_ID);
            logger.debug(MSG_ICIS_ID + icisId);

            tranId = (String) getJdbcTemplate().queryForObject(
                    SQL_GET_LAST_TRAN_ID_BY_HEADER_ID,
                    new Object[] { icisId, ts },
                    new int[] { Types.VARCHAR, Types.TIMESTAMP }, String.class);
        }

        return tranId;
    }

    @SuppressWarnings("unchecked")
    public List<String> getAllTranIds() {

        List<String> idList = null;

        logger.debug(SQL_GET_DISTINCT_TRAN_IDS);

        idList = getJdbcTemplate().queryForList(SQL_GET_DISTINCT_TRAN_IDS,
                String.class);

        return idList;

    }
}

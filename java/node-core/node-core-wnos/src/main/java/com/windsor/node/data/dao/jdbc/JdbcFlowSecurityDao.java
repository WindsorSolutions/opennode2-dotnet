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

package com.windsor.node.data.dao.jdbc;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.common.domain.flowsecurity.FlowRequest;
import com.windsor.node.data.dao.FlowSecurityDao;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.FormatUtil;

/**
 * Manages interactions with flow-security tables in the Node metadata database.
 * 
 */
public class JdbcFlowSecurityDao extends BaseJdbcDao implements FlowSecurityDao {

    public static final String TABLE_NAME = "NAccountAuthRequest";
    public static final String FLOW_REQ_TABLE_NAME = "NAccountAuthRequestFlow";

    private static final String SQL_SELECT_AUTH_REQ = SELECT_ALL_FROM
            + TABLE_NAME;

    private static final String SQL_SELECT_AUTH_REQ_BY_ID = SQL_SELECT_AUTH_REQ
            + WHERE + " Id = ?";

    private static final String SQL_SELECT_AUTH_REQ_BY_TRAN_ID = SQL_SELECT_AUTH_REQ
            + WHERE + " TransactionId = ?";

    private static final String SQL_COUNT_PENDING_BY_NASS_ID = SELECT_COUNT_ALL_FROM
            + TABLE_NAME
            + WHERE
            + " AuthorizationGeneratedOn IS NULL AND NAASAccount = ? ";

    private static final String SQL_SELECT_PENDING = SQL_SELECT_AUTH_REQ
            + WHERE + " AuthorizationGeneratedOn IS NULL " + ORDER_BY
            + "RequestGeneratedOn";

    private static final String SQL_INSERT_NEW_AUTH_REQ = INSERT
            + TABLE_NAME
            + L_PAREN
            + "TransactionId, RequestGeneratedOn, RequestType, NAASAccount, FullName, "
            + "OrganizationAffiliation, TelephoneNumber, EmailAddress, AffiliatedNodeId, "
            + "AffiliatedCounty, PurposeDescription, RequestedNodeIds, AuthorizationAccountId, "
            + "AuthorizationComments, AuthorizationGeneratedOn, DidCreateInNaas, Id "
            + R_PAREN + VALUES + L_PAREN
            + " ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? " + R_PAREN;

    private static final String SQL_UPDATE_AUTH_REQ = UPDATE
            + TABLE_NAME
            + SET
            + "TransactionId = ?, "
            + "RequestGeneratedOn = ?, RequestType = ?, NAASAccount = ?, FullName = ?, "
            + "OrganizationAffiliation = ?, TelephoneNumber = ?, EmailAddress = ?, AffiliatedNodeId = ?, "
            + "AffiliatedCounty = ?, PurposeDescription = ?, RequestedNodeIds = ?, AuthorizationAccountId = ?, "
            + "AuthorizationComments = ?, AuthorizationGeneratedOn = ?, DidCreateInNaas = ? WHERE Id = ?";

    private static final String SQL_SELECT_ALL_FLOW_REQ = SELECT_ALL_FROM
            + FLOW_REQ_TABLE_NAME;

    private static final String SQL_SELECT_ALL_FLOW_REQ_BY_AUTH_REQ_ID = SQL_SELECT_ALL_FLOW_REQ
            + " WHERE AccountAuthRequestId = ?";

    private static final String SQL_INSERT_NEW_FLOW_REQ = INSERT
            + FLOW_REQ_TABLE_NAME + L_PAREN
            + "AccountAuthRequestId, FlowName, AccessGranted, Id " + R_PAREN
            + VALUES + L_PAREN + "?, ?, ?, ? " + R_PAREN;

    private static final String SQL_UPDATE_NEW_FLOW_REQ = UPDATE
            + FLOW_REQ_TABLE_NAME
            + SET
            + "AccountAuthRequestId = ?, FlowName = ?, AccessGranted = ? WHERE Id = ?";

    protected void checkDaoConfig() {
        super.checkDaoConfig();
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.jdbc.FlowSecurityDao#saveAuthRequest(com.windsor
     * .node.common.domain.flowsecurity.AuthorizationRequest)
     */
    public AuthorizationRequest saveAuthRequest(AuthorizationRequest req) {

        checkDaoConfig();
        validateAuthRequest(req);

        String sql = SQL_UPDATE_AUTH_REQ;

        if (StringUtils.isBlank(req.getId())) {

            req.setId(idGenerator.createId());
            sql = SQL_INSERT_NEW_AUTH_REQ;
        }

        logger.debug(sql);

        Object[] args = { req.getTransactionId(), req.getRequestGeneratedOn(),
                req.getRequestType(), req.getNaasUserName(), req.getFullName(),
                req.getOrgAffiliation(), req.getPhoneNumber(),
                req.getEmailAddress(), req.getAffiliatedNodeId(),
                req.getAffiliatedCounty(), req.getPurposeDescription(),
                req.getRequestedNodeIds(), req.getAuthorizationAccountId(),
                req.getAuthorizationComments(),
                req.getAuthorizationGeneratedOn(),
                FormatUtil.toYNFromBoolean(req.isDidCreateInNaas()),
                req.getId() };

        getJdbcTemplate().update(sql, args);

        if (null != req.getRequestedFlows()
                && req.getRequestedFlows().size() != 0) {

            saveFlowRequests(req.getId(), req.getRequestedFlows());
        }

        logger.debug("AuthorizationRequest saved");

        return getById(req.getId());
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.jdbc.FlowSecurityDao#getById(java.lang.String)
     */
    public AuthorizationRequest getById(String id) {

        checkDaoConfig();
        validateStringArg(id);

        AuthorizationRequest req;
        logger.debug(SQL_SELECT_AUTH_REQ_BY_ID + "id = " + id);

        req = (AuthorizationRequest) getJdbcTemplate().queryForObject(
                SQL_SELECT_AUTH_REQ_BY_ID, new Object[] { id },
                new AuthorizationRequestMapper());

        req.setRequestedFlows(getFlowRequests(id));

        return req;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.FlowSecurityDao#getByTransactionId(java.lang
     * .String)
     */
    public AuthorizationRequest getByTransactionId(String tranId) {

        checkDaoConfig();
        validateStringArg(tranId);

        AuthorizationRequest req;
        logger.debug(SQL_SELECT_AUTH_REQ_BY_TRAN_ID + "id = " + tranId);

        req = (AuthorizationRequest) getJdbcTemplate().queryForObject(
                SQL_SELECT_AUTH_REQ_BY_TRAN_ID, new Object[] { tranId },
                new AuthorizationRequestMapper());

        req.setRequestedFlows(getFlowRequests(req.getId()));

        return req;
    }

    public boolean hasPending(String naasUserName) {

        boolean b = false;

        if (getJdbcTemplate().queryForInt(SQL_COUNT_PENDING_BY_NASS_ID,
                new Object[] { naasUserName }) > 0) {

            b = true;
        }

        return b;
    }

    public List<AuthorizationRequest> getPendingRequests() {

        List<AuthorizationRequest> pendingRequests = null;

        checkDaoConfig();

        logger.debug(SQL_SELECT_PENDING);

        pendingRequests = (List<AuthorizationRequest>) getJdbcTemplate().query(
                SQL_SELECT_PENDING, new AuthorizationRequestMapper());

        for (AuthorizationRequest pendingRequest : pendingRequests) {

            List<FlowRequest> requestedFlows = getFlowRequests(pendingRequest
                    .getId());
            pendingRequest.setRequestedFlows(requestedFlows);
        }

        logger.debug("returning " + pendingRequests.size()
                + " AuthorizationRequests");

        return pendingRequests;
    }

    private List<FlowRequest> getFlowRequests(String authReqId) {

        validateStringArg(authReqId);

        List<FlowRequest> flowReqs = (List<FlowRequest>) getJdbcTemplate()
                .query(SQL_SELECT_ALL_FLOW_REQ_BY_AUTH_REQ_ID,
                        new Object[] { authReqId }, new FlowRequestMapper());

        return flowReqs;
    }

    private void saveFlowRequests(String authReqId, List<FlowRequest> flowReqs) {

        validateStringArg(authReqId);

        for (FlowRequest req : flowReqs) {

            validateStringArg(req.getFlowName());

            String sql = SQL_UPDATE_NEW_FLOW_REQ;

            if (StringUtils.isBlank(req.getId())) {

                req.setId(UUIDGenerator.makeId());
                sql = SQL_INSERT_NEW_FLOW_REQ;
            }

            logger.debug(sql);

            Object[] args = new Object[] { authReqId, req.getFlowName(),
                    FormatUtil.toYNFromBoolean(req.isAccessGranted()),
                    req.getId() };
            getJdbcTemplate().update(sql, args);
        }
    }

    // CHECKSTYLE:OFF

    private boolean validateAuthRequest(AuthorizationRequest req) {

        boolean isValid = true;
        StringBuffer sb = new StringBuffer();

        sb.append("AuthorizationRequest validation error(s):\n");

        if (StringUtils.isBlank(req.getTransactionId())) {
            sb.append("Blank transactionId\n");
            isValid = false;
        }

        if (null == req.getRequestGeneratedOn()) {
            sb.append("null generatedOn date\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getRequestType())) {
            sb.append("Blank requestType\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getNaasUserName())) {
            sb.append("Blank NAAS userName\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getFullName())) {
            sb.append("Blank FullName\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getOrgAffiliation())) {
            sb.append("Blank OrgAffiliation\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getPhoneNumber())) {
            sb.append("Blank PhoneNumber\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getEmailAddress())) {
            sb.append("Blank EmailAddress\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getAffiliatedNodeId())) {
            sb.append("Blank AffiliatedNodeId\n");
            isValid = false;
        }

        if (StringUtils.isBlank(req.getRequestedNodeIds())) {
            sb.append("Blank RequestedNodeIds\n");
            isValid = false;
        }

        if (!isValid) {

            logger.debug(sb.toString());
            throw new RuntimeException(sb.toString());
        }

        return isValid;

        // CHECKSTYLE:ON
    }

    private class AuthorizationRequestMapper implements RowMapper<AuthorizationRequest> {

        public AuthorizationRequest mapRow(ResultSet rs, int i) throws SQLException {

            AuthorizationRequest req = new AuthorizationRequest();

            req.setId(rs.getString("Id"));
            req.setTransactionId(rs.getString("TransactionId"));
            req.setRequestGeneratedOn(rs.getTimestamp("RequestGeneratedOn"));
            req.setRequestType(rs.getString("RequestType"));
            req.setNaasUserName(rs.getString("NAASAccount"));
            req.setFullName(rs.getString("FullName"));
            req.setOrgAffiliation(rs.getString("OrganizationAffiliation"));
            req.setPhoneNumber(rs.getString("TelephoneNumber"));
            req.setEmailAddress(rs.getString("EmailAddress"));
            req.setAffiliatedNodeId(rs.getString("AffiliatedNodeId"));
            req.setAffiliatedCounty(rs.getString("AffiliatedCounty"));
            req.setPurposeDescription(rs.getString("PurposeDescription"));
            req.setRequestedNodeIds(rs.getString("RequestedNodeIds"));
            req.setAuthorizationAccountId(rs
                    .getString("AuthorizationAccountId"));
            req.setAuthorizationComments(rs.getString("AuthorizationComments"));
            req.setAuthorizationGeneratedOn(rs
                    .getTimestamp("AuthorizationGeneratedOn"));
            req.setDidCreateInNaas(FormatUtil.toBooleanFromYN(rs
                    .getString("DidCreateInNaas")));

            return req;
        }
    }

    private class FlowRequestMapper implements RowMapper<FlowRequest> {

        public FlowRequest mapRow(ResultSet rs, int i) throws SQLException {

            FlowRequest req = new FlowRequest();
            req.setId(rs.getString("Id"));
            req.setFlowName(rs.getString("FlowName"));
            req.setAccessGranted(FormatUtil.toBooleanFromYN(rs
                    .getString("AccessGranted")));

            return req;
        }
    }
}

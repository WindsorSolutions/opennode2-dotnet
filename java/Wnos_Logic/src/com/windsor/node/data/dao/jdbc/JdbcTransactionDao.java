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
import java.sql.Types;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.DateUtil;

public class JdbcTransactionDao extends BaseJdbcDao implements TransactionDao,
        InitializingBean {

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, FlowId, NetworkId, "
            + "Status, ModifiedBy, ModifiedOn, StatusDetail, Operation, WebMethod  FROM NTransaction ";

    private static final String SQL_SELECT_ALL = SQL_SELECT
            + " ORDER BY ModifiedOn DESC ";

    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    private static final String SQL_SELECT_ENID = SQL_SELECT
            + " WHERE UPPER(NetworkId) = ? ";

    private static final String SQL_SELECT_N_METHOD = SQL_SELECT
            + " WHERE WebMethod = ? ";

    private static final String SQL_SELECT_STATUS_N_METHOD = SQL_SELECT
            + " WHERE Status = ? AND WebMethod = ? ORDER BY ModifiedOn DESC";

    private static final String SQL_SELECT_STATUS_DOCS = SQL_SELECT
            + " WHERE Status = ? AND ID IN (SELECT TransactionId FROM NDocument)";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NTransaction ( Id, FlowId, "
            + "NetworkId, Status, ModifiedBy, ModifiedOn, StatusDetail, Operation, WebMethod ) "
            + "VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    private static final String SQL_UPDATE_STATUS_TRAN = "UPDATE NTransaction SET Status = ? WHERE Id = ? AND Status = ?";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NTransaction SET Status = ? WHERE Id = ?";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE_NETWORK_ID = "UPDATE NTransaction SET NetworkId = ? WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NTransaction WHERE Id = ?";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_DOC_WITH_CONTENT = "SELECT Id, DocumentName, DocumentType, "
            + "DocumentId, Status, StatusDetail, DocumentContent FROM NDocument WHERE TransactionId = ? ";

    private static final String SQL_SELECT_DOC_NO_CONTENT = "SELECT Id, DocumentName, DocumentType, "
            + "DocumentId, Status, StatusDetail, null as DocumentContent FROM NDocument WHERE TransactionId = ? ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_DOC_ID = SQL_SELECT_DOC_WITH_CONTENT
            + " AND DocumentId = ? ";

    private static final String SQL_SELECT_DOC_NAME = SQL_SELECT_DOC_WITH_CONTENT
            + " AND UPPER(DocumentName) = ? ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_DOC_EN_WITH_CONTENT = "SELECT Id, DocumentName, "
            + " DocumentType, DocumentId, Status, StatusDetail, DocumentContent "
            + "FROM NDocument WHERE TransactionId IN (SELECT Id FROM NTransaction "
            + "WHERE UPPER(NetworkId) = ? ) ";

    private static final String SQL_SELECT_DOC_EN_NO_CONTENT = "SELECT Id, DocumentName, "
            + " DocumentType, DocumentId, Status, StatusDetail, null as DocumentContent "
            + "FROM NDocument WHERE TransactionId IN (SELECT Id FROM NTransaction "
            + "WHERE UPPER(NetworkId) = ? ) ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT_DOC = "INSERT INTO NDocument "
            + "( Id, TransactionId, DocumentName, DocumentType, DocumentId, Status, StatusDetail, DocumentContent) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?)";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE_DOC = "DELETE FROM NDocument WHERE TransactionId = ?";

    private FlowDao flowDao;
    private AccountDao accountDao;

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {
        super.checkDaoConfig();

        if (flowDao == null) {
            throw new RuntimeException("flowDao not set");
        }

        if (accountDao == null) {
            throw new RuntimeException("accountDao not set");
        }
    }

    /**
     * addDocument
     */
    public Document addDocument(String transactionId, Document instance) {

        validateObjectArg(instance, "Document");

        validateStringArg(transactionId);

        // Id, TransactionId, DocumentName, DocumentType, DocumentId, Status,
        // StatusDetail, Content

        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(UUIDGenerator.makeId());
        }

        Object[] args = new Object[8];

        args[0] = instance.getId();
        args[1] = transactionId;
        args[2] = instance.getDocumentName();
        args[3] = instance.getType().getName();
        args[4] = (instance.getDocumentId() == null) ? instance.getId()
                : instance.getDocumentId();
        args[5] = instance.getDocumentStatus().getName();
        args[6] = instance.getDocumentStatusDetail();
        args[7] = instance.getContent();

        int[] types = new int[8];
        types[0] = Types.VARCHAR;
        types[1] = Types.VARCHAR;
        types[2] = Types.VARCHAR;
        types[3] = Types.VARCHAR;
        types[4] = Types.VARCHAR;
        types[5] = Types.VARCHAR;
        types[6] = Types.VARCHAR;
        types[7] = Types.BINARY;

        try {

            getJdbcTemplate().update(SQL_INSERT_DOC, args, types);
            return instance;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(
                    "Error while saving document for Transaction Id: "
                            + transactionId + " and document name: "
                            + instance.getDocumentName(), ex);
        }

    }

    /**
     * get
     */
    public NodeTransaction get(String id, boolean useNetworkId) {

        validateStringArg(id);

        String sql = SQL_SELECT_ID;

        if (useNetworkId) {
            sql = SQL_SELECT_ENID;
            id = id.toUpperCase();
        }

        return (NodeTransaction) queryForObject(sql, new Object[] { id },
                new TransactionMapper());
    }

    /**
     * get
     */
    public List get(CommonTransactionStatusCode status, NodeMethodType method) {

        validateObjectArg(status, "CommonTransactionStatusCode");
        validateObjectArg(method, "NodeMethodType");

        return getJdbcTemplate().query(SQL_SELECT_STATUS_N_METHOD,
                new Object[] { status.getName(), method.getName() },
                new TransactionMapper());
    }

    /**
     * getByMethodType
     */
    public List get(NodeMethodType method) {

        validateObjectArg(method, "NodeMethodType");

        return getJdbcTemplate().query(SQL_SELECT_N_METHOD,
                new Object[] { method.getName() }, new TransactionMapper());
    }

    public NodeTransaction getNextReceived(NodeMethodType method) {

        List transactions = get(CommonTransactionStatusCode.RECEIVED, method);

        logger.debug("Transactions found: " + transactions.size());

        for (int i = 0; i < transactions.size(); i++) {

            NodeTransaction tran = (NodeTransaction) transactions.get(i);

            logger.debug("Transaction: " + tran);

            Object[] args = new Object[3];

            // New, Id, Old

            args[0] = CommonTransactionStatusCode.PROCESSING.getName();
            args[1] = tran.getId();
            args[2] = tran.getStatus().getStatus().getName();

            if (1 == getJdbcTemplate().update(SQL_UPDATE_STATUS_TRAN, args)) {
                tran.getStatus().setStatus(
                        CommonTransactionStatusCode.PROCESSING);
                return tran;
            }

        }

        return null;

    }

    /**
     * getSubmittedDocumentTransactions
     */
    public List getSubmittedDocumentTransactions() {

        return getJdbcTemplate().query(SQL_SELECT_STATUS_DOCS,
                new Object[] { CommonTransactionStatusCode.RECEIVED_STR },
                new TransactionMapper());
    }

    /**
     * getDocuments
     */
    public List getDocuments(String transactionId, boolean useNetworkId,
            boolean loadDocContent) {

        validateStringArg(transactionId);

        String sql = SQL_SELECT_DOC_NO_CONTENT;

        if (loadDocContent) {
            sql = SQL_SELECT_DOC_WITH_CONTENT;
        }

        if (useNetworkId) {
            sql = SQL_SELECT_DOC_EN_NO_CONTENT;

            if (loadDocContent) {
                sql = SQL_SELECT_DOC_EN_WITH_CONTENT;
            }

            transactionId = transactionId.toUpperCase();
        }

        return getJdbcTemplate().query(sql, new Object[] { transactionId },
                new DocumentMapper());
    }

    /**
     * getDocuments
     */
    public Document getDocument(String transactionId, String documentId) {

        validateStringArg(transactionId);
        validateStringArg(documentId);

        return (Document) queryForObject(SQL_SELECT_DOC_ID, new Object[] {
                transactionId, documentId }, new DocumentMapper());
    }

    /**
     * getDocumentByName
     */
    public Document getDocumentByName(String transactionId, String documentName) {

        validateStringArg(transactionId);
        validateStringArg(documentName);

        return (Document) queryForObject(SQL_SELECT_DOC_NAME, new Object[] {
                transactionId, documentName.toUpperCase() },
                new DocumentMapper());
    }

    /**
     * make
     */
    public NodeTransaction make(String flowId, String createdById,
            NodeMethodType method, CommonTransactionStatusCode status) {

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException("Null flowId");
        }

        if (StringUtils.isBlank(createdById)) {
            throw new RuntimeException("Null createdById");
        }

        if (method == null) {
            throw new RuntimeException("Null method");
        }

        if (status == null) {
            throw new RuntimeException("Null status");
        }

        NodeTransaction tran = new NodeTransaction();

        tran.setId(UUIDGenerator.makeId());
        tran.setFlow(flowDao.get(flowId));
        tran.setNetworkId(tran.getId());
        tran.setStatus(new TransactionStatus(tran.getNetworkId(), status,
                "Transaction Created"));
        tran.setModifiedById(createdById);
        tran.setWebMethod(method);

        return save(tran);

    }

    /**
     * save
     */
    public NodeTransaction save(NodeTransaction instance) {

        validateObjectArg(instance, "NodeTransaction");

        instance.setId(UUIDGenerator.makeId());

        // Id, FlowId, NetworkId, Status, ModifiedBy, ModifiedOn, StatusDetail,
        // Operation, WebMethod

        Object[] args = new Object[9];

        args[0] = instance.getId();
        args[1] = instance.getFlow().getId();
        args[2] = instance.getNetworkId();
        args[3] = instance.getStatus().getStatus().getName();
        args[4] = instance.getModifiedById();
        args[5] = DateUtil.getTimestamp();
        args[6] = instance.getStatus().getDescription();
        args[7] = instance.getOperation();
        args[8] = instance.getWebMethod().getName();

        getJdbcTemplate().update(SQL_INSERT, args);

        return instance;
    }

    /**
     * updateStatus
     */
    public void updateStatus(String transactionId,
            CommonTransactionStatusCode status) {

        validateObjectArg(status, "CommonTransactionStatusCode");

        validateStringArg(transactionId);

        // Status, Id

        Object[] args = new Object[2];

        args[0] = status.getName();
        args[1] = transactionId;

        getJdbcTemplate().update(SQL_UPDATE, args);

    }

    /**
     * updateNetworkId
     * 
     * @param transactionId
     * @param networkId
     */
    public void updateNetworkId(String transactionId, String networkId) {

        validateStringArg(networkId);

        validateStringArg(transactionId);

        // NetworkId, Id

        Object[] args = new Object[2];

        args[0] = networkId;
        args[1] = transactionId;

        getJdbcTemplate().update(SQL_UPDATE_NETWORK_ID, args);

    }

    /**
     * delete
     */
    public void delete(String id) {

        validateStringArg(id);

        delete(SQL_DELETE_DOC, id);
        delete(SQL_DELETE, id);

    }

    /**
     * get
     */
    public List get() {
        return getJdbcTemplate().query(SQL_SELECT_ALL, new TransactionMapper());
    }

    /**
     * TransactionMapper
     * 
     * @author mchmarny
     * 
     */
    private class TransactionMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            NodeTransaction obj = new NodeTransaction();

            // Id, FlowId, NetworkId, Status, ModifiedBy, ModifiedOn,
            // StatusDetail, Operation, WebMethod

            obj.setId(rs.getString("Id"));
            obj.setFlow(flowDao.get(rs.getString("FlowId")));
            obj.setNetworkId(rs.getString("NetworkId"));
            obj.setStatus(new TransactionStatus(rs.getString("Id"), rs
                    .getString("Status"), rs.getString("StatusDetail")));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setOperation(rs.getString("Operation"));
            obj.setWebMethod((NodeMethodType) NodeMethodType.getEnumMap().get(
                    rs.getString("WebMethod")));

            return obj;

        }
    }

    /**
     * DocumentMapper
     * 
     * @author mchmarny
     * 
     */
    private class DocumentMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            Document obj = new Document();

            // Id, DocumentName, DocumentType, DocumentId, Status, StatusDetail

            obj.setId(rs.getString("Id"));
            obj.setDocumentName(rs.getString("DocumentName"));
            obj.setType((CommonContentType) CommonContentType.getEnumMap().get(
                    rs.getString("DocumentType")));
            obj.setDocumentId(rs.getString("DocumentId"));
            obj
                    .setDocumentStatus((CommonTransactionStatusCode) CommonTransactionStatusCode
                            .getEnumMap().get(rs.getString("Status")));
            obj.setDocumentStatusDetail(rs.getString("StatusDetail"));
            obj.setContent(rs.getBytes("DocumentContent"));

            return obj;

        }

    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

}
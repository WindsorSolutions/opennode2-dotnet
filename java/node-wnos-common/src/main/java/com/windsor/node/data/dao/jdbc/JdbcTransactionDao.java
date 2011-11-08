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

import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.List;
import org.apache.commons.lang.StringUtils;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.ScheduledItemTargetType;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.CommonTransactionStatusCodeConverter;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.DateUtil;

public class JdbcTransactionDao extends BaseJdbcDao implements TransactionDao
{

    private static final String SQL_SELECT = "SELECT Id, FlowId, NetworkId, "
                    + "Status, ModifiedBy, ModifiedOn, StatusDetail, Operation, WebMethod, "
                    + "EndpointVersion, NetworkEndpointVersion, NetworkEndpointUrl, NetworkEndpointStatus, NetworkEndpointStatusDetail FROM NTransaction ";

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
                    + "NetworkId, Status, ModifiedBy, ModifiedOn, StatusDetail, Operation, "
                    + "WebMethod, EndpointVersion, NetworkEndpointVersion, NetworkEndpointUrl, NetworkEndpointStatus, NetworkEndpointStatusDetail ) "
                    + "VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    private static final String SQL_UPDATE = "UPDATE NTransaction SET FlowId = ?, "
                    + " NetworkId = ?, Status = ?, ModifiedBy = ?, ModifiedOn = ?, StatusDetail = ?, Operation = ?, "
                    + " WebMethod = ?, EndpointVersion = ?, NetworkEndpointVersion = ?, NetworkEndpointUrl = ?, NetworkEndpointStatus = ?, NetworkEndpointStatusDetail = ? "
                    + " WHERE Id = ?";

    private static final String SQL_UPDATE_STATUS_TRAN = "UPDATE NTransaction SET Status = ? WHERE Id = ? AND Status = ?";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE_STATUS = "UPDATE NTransaction SET Status = ? WHERE Id = ?";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE_NETWORK_ID = "UPDATE NTransaction SET NetworkId = ? WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NTransaction WHERE Id = ?";

    private static final String SQL_SELECT_DOC_WITH_CONTENT = "SELECT Id, DocumentName, DocumentType, "
            + "DocumentId, Status, StatusDetail, DocumentContent FROM NDocument WHERE TransactionId = ? ";

    private static final String SQL_SELECT_DOC_NO_CONTENT = "SELECT Id, DocumentName, DocumentType, "
            + "DocumentId, Status, StatusDetail FROM NDocument WHERE TransactionId = ? ";

    private static final String SQL_SELECT_DOC_ID = SQL_SELECT_DOC_WITH_CONTENT
            + " AND DocumentId = ? ";

    private static final String SQL_SELECT_DOC_NAME = SQL_SELECT_DOC_WITH_CONTENT
            + " AND UPPER(DocumentName) = ? ";

    private static final String SQL_SELECT_DOC_EN_WITH_CONTENT = "SELECT Id, DocumentName, "
            + " DocumentType, DocumentId, Status, StatusDetail, DocumentContent "
            + "FROM NDocument WHERE TransactionId IN (SELECT Id FROM NTransaction "
            + "WHERE UPPER(NetworkId) = ? ) ";

    private static final String SQL_SELECT_DOC_EN_NO_CONTENT = "SELECT Id, DocumentName, "
            + " DocumentType, DocumentId, Status, StatusDetail "
            + "FROM NDocument WHERE TransactionId IN (SELECT Id FROM NTransaction "
            + "WHERE UPPER(NetworkId) = ? ) ";

    private static final String SQL_ID_EXISTS = "select count(*) from NTransaction where id = ?";

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
    private PartnerDao partnerDao;

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {
        super.checkDaoConfig();

        if(flowDao == null)
        {
            throw new RuntimeException("flowDao not set");
        }

        if(accountDao == null)
        {
            throw new RuntimeException("accountDao not set");
        }

        if(partnerDao == null)
        {
            throw new RuntimeException("partnerDao not set");
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
        args[5] = instance.getDocumentStatus().name();
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

        String adjustedId;

        if (useNetworkId) {

            sql = SQL_SELECT_ENID;
            adjustedId = id.toUpperCase();

        } else {

            adjustedId = id;
        }

        return (NodeTransaction) queryForObject(sql,
                new Object[] { adjustedId }, new TransactionMapper());
    }

    /**
     * get
     */
    @SuppressWarnings("unchecked")
    public List<NodeTransaction> get(CommonTransactionStatusCode status, NodeMethodType method) {

        validateObjectArg(status, "CommonTransactionStatusCode");
        validateObjectArg(method, "NodeMethodType");

        return (List<NodeTransaction>)getJdbcTemplate().query(SQL_SELECT_STATUS_N_METHOD,
                new Object[] { status.name(), method.getName() },
                new TransactionMapper());
    }

    /**
     * getByMethodType
     */
    @SuppressWarnings("unchecked")
    public List<NodeTransaction> get(NodeMethodType method) {

        validateObjectArg(method, "NodeMethodType");

        return (List<NodeTransaction>)getJdbcTemplate().query(SQL_SELECT_N_METHOD,
                new Object[] { method.getName() }, new TransactionMapper());
    }

    public NodeTransaction getNextReceived(NodeMethodType method) {

        List<NodeTransaction> transactions = get(CommonTransactionStatusCode.Received, method);

        logger.debug("Transactions found: " + transactions.size());

        for (int i = 0; i < transactions.size(); i++) {

            NodeTransaction tran = (NodeTransaction) transactions.get(i);

            logger.debug("Transaction: " + tran);

            Object[] args = new Object[3];

            // New, Id, Old

            args[0] = CommonTransactionStatusCode.Processing.name();
            args[1] = tran.getId();
            args[2] = tran.getStatus().getStatus().name();

            if (1 == getJdbcTemplate().update(SQL_UPDATE_STATUS_TRAN, args)) {
                tran.getStatus().setStatus(
                        CommonTransactionStatusCode.Processing);
                return tran;
            }

        }

        return null;

    }

    /**
     * getSubmittedDocumentTransactions
     */
    @SuppressWarnings("unchecked")
    public List<NodeTransaction> getSubmittedDocumentTransactions() {

        return (List<NodeTransaction>)getJdbcTemplate().query(SQL_SELECT_STATUS_DOCS,
                new Object[] { CommonTransactionStatusCode.Received.name() },
                new TransactionMapper());
    }

    /**
     * getDocuments
     */
    @SuppressWarnings("unchecked")
    public List<Document> getDocuments(String transactionId,
            boolean useNetworkId, boolean loadDocContent) {

        validateStringArg(transactionId);

        String sql = SQL_SELECT_DOC_NO_CONTENT;

        String adjustedId;

        if (loadDocContent) {
            sql = SQL_SELECT_DOC_WITH_CONTENT;
        }

        if (useNetworkId) {
            sql = SQL_SELECT_DOC_EN_NO_CONTENT;

            if (loadDocContent) {
                sql = SQL_SELECT_DOC_EN_WITH_CONTENT;
            }

            adjustedId = transactionId.toUpperCase();

        } else {

            adjustedId = transactionId;
        }

        return (List<Document>) getJdbcTemplate().query(sql,
                new Object[] { adjustedId }, new DocumentMapper());
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
     * @deprecated
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

    public NodeTransaction make(ScheduledItem schedule, NodeMethodType method, CommonTransactionStatusCode status)
    {
        if(schedule == null)
        {
            throw new IllegalArgumentException("Null schedule");
        }
        if(StringUtils.isBlank(schedule.getFlowId()))
        {
            throw new IllegalArgumentException("Null flowId");
        }
        if(StringUtils.isBlank(schedule.getModifiedById()))
        {
            throw new IllegalArgumentException("Null modifiedById");
        }
        if(method == null)
        {
            throw new IllegalArgumentException("Null method");
        }
        if(status == null)
        {
            throw new IllegalArgumentException("Null status");
        }

        NodeTransaction tran = new NodeTransaction();
        tran.setId(UUIDGenerator.makeId());
        tran.setFlow(flowDao.get(schedule.getFlowId()));
        tran.setNetworkId(tran.getId());
        tran.setStatus(new TransactionStatus(tran.getNetworkId(), status, "Transaction Created"));
        tran.setModifiedById(schedule.getModifiedById());
        tran.setWebMethod(method);
        //TODO set EndpointVersion, no use yet as no functionality that would set it makes use of the updated function, will fix the function to work for non schedules
        if(schedule.getTargetType().equals(ScheduledItemTargetType.Partner) && StringUtils.isNotBlank(schedule.getTargetId()))
        {
            PartnerIdentity partner = getPartnerDao().get(schedule.getTargetId());
            tran.updateWithPartnerDetails(partner);
        }
        return save(tran);
    }

    /**
     * save
     */
    public NodeTransaction save(NodeTransaction instance) {

        validateObjectArg(instance, "NodeTransaction");

        if(StringUtils.isBlank(instance.getId()) || !currentDatabaseRecord(instance))
        {
            instance = insert(instance);
        }
        else
        {
            instance = update(instance);
        }
        return instance;
    }

    private boolean currentDatabaseRecord(NodeTransaction instance)
    {
        if(instance != null && StringUtils.isNotBlank(instance.getId()))
        {
            int count = getJdbcTemplate().queryForInt(SQL_ID_EXISTS, new Object[] {instance.getId()}, new int[]{Types.VARCHAR});
            if(count > 0)
            {
                return true;
            }
        }
        return false;
    }

    private NodeTransaction update(NodeTransaction instance)
    {
        // FlowId, NetworkId, Status, ModifiedBy, ModifiedOn, StatusDetail,
        // Operation, WebMethod WHERE Id
        Object[] args = new Object[14];

        args[0] = instance.getFlow().getId();
        args[1] = instance.getNetworkId();
        args[2] = instance.getStatus().getStatus().name();
        args[3] = instance.getModifiedById();
        args[4] = DateUtil.getTimestamp();
        args[5] = instance.getStatus().getDescription();
        args[6] = instance.getOperation();
        args[7] = instance.getWebMethod().getName();

        //new as of version 2.01
        //EndpointVersion, NetworkEndpointVersion, NetworkEndpointUrl, NetworkEndpointStatus, NetworkEndpointStatusDetail
        if(instance.getEndpointVersion() != null)
        {
            args[8] = instance.getEndpointVersion().toString();
        }
        else
        {
            args[8] = "";
        }
        if(instance.getNetworkEndpointVersion() != null)
        {
            args[9] = instance.getNetworkEndpointVersion().toString();
        }
        else
        {
            args[9] = "";
        }
        if(instance.getNetworkEndpointUrl() != null)
        {
            args[10] = instance.getNetworkEndpointUrl().toString();
        }
        else
        {
            args[10] = "";
        }    
        args[11] = instance.getNetworkEndpointStatus();
        args[12] = instance.getNetworkEndpointStatusDetail();

        args[13] = instance.getId();

        getJdbcTemplate().update(SQL_UPDATE,
                                 args,
                                 new int[]{Types.VARCHAR, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR, Types.TIMESTAMP, Types.VARCHAR,
                                                 Types.VARCHAR, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR, Types.VARCHAR,
                                                 Types.VARCHAR, Types.VARCHAR});

        return instance;
    }

    private NodeTransaction insert(NodeTransaction instance)
    {
        instance.setId(UUIDGenerator.makeId());

        // Id, FlowId, NetworkId, Status, ModifiedBy, ModifiedOn, StatusDetail,
        // Operation, WebMethod
        Object[] args = new Object[14];

        args[0] = instance.getId();
        args[1] = instance.getFlow().getId();
        args[2] = instance.getNetworkId();
        args[3] = instance.getStatus().getStatus().name();
        args[4] = instance.getModifiedById();
        args[5] = DateUtil.getTimestamp();
        args[6] = instance.getStatus().getDescription();
        args[7] = instance.getOperation();
        args[8] = instance.getWebMethod().getName();

        //new as of version 2.01
        //EndpointVersion, NetworkEndpointVersion, NetworkEndpointUrl, NetworkEndpointStatus, NetworkEndpointStatusDetail
        if(instance.getEndpointVersion() != null)
        {
            args[9] = instance.getEndpointVersion().toString();
        }
        else
        {
            args[9] = "";
        }
        if(instance.getNetworkEndpointVersion() != null)
        {
            args[10] = instance.getNetworkEndpointVersion().toString();
        }
        else
        {
            args[10] = "";
        }
        if(instance.getNetworkEndpointUrl() != null)
        {
            args[11] = instance.getNetworkEndpointUrl().toString();
        }
        else
        {
            args[11] = "";
        }    
        args[12] = instance.getNetworkEndpointStatus();
        args[13] = instance.getNetworkEndpointStatusDetail();

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

        args[0] = status.name();
        args[1] = transactionId;

        getJdbcTemplate().update(SQL_UPDATE_STATUS, args);

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
    @SuppressWarnings("unchecked")
    public List<NodeTransaction> get() {
        return (List<NodeTransaction>)getJdbcTemplate().query(SQL_SELECT_ALL, new TransactionMapper());
    }

    /**
     * TransactionMapper
     * 
     * @author mchmarny
     * 
     */
    private class TransactionMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            NodeTransaction transaction = new NodeTransaction();

            // Id, FlowId, NetworkId, Status, ModifiedBy, ModifiedOn,
            // StatusDetail, Operation, WebMethod
            //new in 2.01
            //NetworkEndpointVersion, NetworkEndpointUrl, NetworkEndpointStatus, NetworkEndpointStatusDetail

            transaction.setId(rs.getString("Id"));
            transaction.setFlow(flowDao.get(rs.getString("FlowId")));
            transaction.setNetworkId(rs.getString("NetworkId"));
            transaction.setStatus(new TransactionStatus(rs.getString("Id"), rs
                    .getString("Status"), rs.getString("StatusDetail")));
            transaction.setModifiedById(rs.getString("ModifiedBy"));
            transaction.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            transaction.setOperation(rs.getString("Operation"));
            transaction.setWebMethod((NodeMethodType) NodeMethodType.getEnumMap().get(
                    rs.getString("WebMethod")));

            transaction.setEndpointVersion(EndpointVersionType.fromString(rs.getString("EndpointVersion")));
            transaction.setNetworkEndpointVersion(EndpointVersionType.fromString(rs.getString("NetworkEndpointVersion")));
            String url = rs.getString("NetworkEndpointUrl");
            try
            {
                if(StringUtils.isNotBlank(url))
                {
                    transaction.setNetworkEndpointUrl(new URL(url));
                }
            }
            catch (Exception e)
            {
                //recover but warn
                logger.warn("Url of \"" + url + "\" was provided but could not be parsed, will not use in this NodeTransaction instance, id:  " 
                            + transaction.getId() + ".");
            }
            transaction.setNetworkEndpointStatus(rs.getString("NetworkEndpointStatus"));
            transaction.setNetworkEndpointStatusDetail(rs.getString("NetworkEndpointStatusDetail"));

            return transaction;

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
                    .setDocumentStatus((CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                            .convert(rs.getString("Status")));
            obj.setDocumentStatusDetail(rs.getString("StatusDetail"));

            if (containsColumnNamed(rs, "DocumentContent")) {
                obj.setContent(rs.getBytes("DocumentContent"));
            }

            return obj;

        }

    }

    public void setFlowDao(FlowDao flowDao)
    {
        this.flowDao = flowDao;
    }

    public void setAccountDao(AccountDao accountDao)
    {
        this.accountDao = accountDao;
    }

    public PartnerDao getPartnerDao()
    {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao)
    {
        this.partnerDao = partnerDao;
    }

    public FlowDao getFlowDao()
    {
        return flowDao;
    }

    public AccountDao getAccountDao()
    {
        return accountDao;
    }

}
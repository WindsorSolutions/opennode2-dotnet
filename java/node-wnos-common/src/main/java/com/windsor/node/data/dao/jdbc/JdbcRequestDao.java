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
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.WnosTransactionNotificationType;
import com.windsor.node.data.dao.RequestDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.DateUtil;

public class JdbcRequestDao extends BaseJdbcDao implements RequestDao,
        InitializingBean {

    private ServiceDao serviceDao;

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, TransactionId, ServiceId, RowIndex, MaxRowCount, RequestType, ModifiedBy, ModifiedOn FROM NRequest ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_TRAN = SQL_SELECT
            + " WHERE TransactionId = ? ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_STATUS = SQL_SELECT
            + " WHERE TransactionId IN (SELECT Id FROM NTransaction WHERE Status = ?) ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_STATUS_TYPE = SQL_SELECT
            + " WHERE RequestType = ? AND TransactionId IN (SELECT Id FROM NTransaction WHERE Status = ?) ";

    private static final String SQL_INSERT_REQ_NOTIF = "INSERT INTO NTransactionNotification (Id, TransactionId, Uri, Type)  VALUES(?, ?, ?, ?)";

    private static final String SQL_DELETE_REQ_NOTIF = "DELETE FROM NTransactionNotification WHERE Id = ? ";

    private static final String SQL_SELECT_REQ_NOTIF = "SELECT Uri, Type FROM NTransactionNotification WHERE TransactionId = ? ";

    private static final String SQL_INSERT_REQ_RECIPIENTS = "INSERT INTO NTransactionRecipient (Id, TransactionId, Uri)  VALUES(?, ?, ?)";

    private static final String SQL_DELETE_REQ_RECIPIENTS = "DELETE FROM NTransactionRecipient WHERE Id = ? ";

    private static final String SQL_SELECT_REQ_RECIPIENTS = "SELECT Uri FROM NTransactionRecipient WHERE TransactionId = ? ";

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {

        super.checkDaoConfig();

        if (serviceDao == null) {
            throw new RuntimeException("Service Dao Not Set");
        }

    }

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NRequest ( "
            + " TransactionId, ServiceId, RowIndex, MaxRowCount, RequestType, ModifiedBy, ModifiedOn, Id ) "
            + "VALUES ( ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NRequest SET TransactionId = ?, "
            + "ServiceId = ?, RowIndex = ?, MaxRowCount = ?, RequestType = ?, "
            + "ModifiedBy = ?, ModifiedOn = ? WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NRequest WHERE Id = ?";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_ARG = "SELECT ArgKey, ArgValue  FROM NRequestArg WHERE RequestId = ? ORDER BY ArgKey ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT_ARG = "INSERT INTO NRequestArg ( Id, RequestId, ArgKey, ArgValue ) VALUES ( ?, ?, ?, ? ) ";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE_ARG = "DELETE FROM NRequestArg WHERE RequestId = ? ";

    /**
     * get
     */
    public DataRequest get(String id) {

        validateStringArg(id);

        return (DataRequest) queryForObject(SQL_SELECT_ID, new Object[] { id },
                new RequestMapper());
    }

    /**
     * get
     */
    public List get(CommonTransactionStatusCode status) {

        validateObjectArg(status, "CommonTransactionStatusCode");

        return getJdbcTemplate().query(SQL_SELECT_STATUS,
                new Object[] { status.toString() }, new RequestMapper());
    }

    /**
     * get
     */
    public List get(CommonTransactionStatusCode status, RequestType type) {

        validateObjectArg(status, "CommonTransactionStatusCode");
        validateObjectArg(type, "RequestType");

        return getJdbcTemplate().query(SQL_SELECT_STATUS_TYPE,
                new Object[] { type.toString(), status.toString() },
                new RequestMapper());
    }

    /**
     * getByTransactionId
     */
    public DataRequest getByTransactionId(String id) {

        validateStringArg(id);

        return (DataRequest) queryForObject(SQL_SELECT_TRAN,
                new Object[] { id }, new RequestMapper());
    }

    /**
     * loadRequestArgs
     * 
     * @param obj
     * @return
     */
    private DataRequest loadRequestArgs(DataRequest obj) {

        validateObjectArg(obj, "RequestIdentity");

        obj.setParameters(getByIndexOrNameMap(SQL_SELECT_ARG, obj.getId()));

        return obj;
    }

    /**
     * save
     */
    public DataRequest save(DataRequest instance) {

        logger.debug("Saving request: " + instance);

        validateObjectArg(instance, "RequestIdentity");

        try {

            boolean isUpdate = true;
            String sql = SQL_UPDATE;
            if (StringUtils.isBlank(instance.getId())) {
                instance.setId(UUIDGenerator.makeId());
                sql = SQL_INSERT;
                isUpdate = false;
            }

            logger.debug("sql: " + sql);

            // TransactionId, ServiceId, RowIndex, MaxRowCount, RequestType,
            // ModifiedBy, ModifiedOn, Id

            Object[] args = new Object[8];

            args[0] = instance.getTransactionId();
            args[1] = instance.getService().getId();
            args[2] = new Integer(instance.getPaging().getStart());
            args[3] = new Integer(instance.getPaging().getCount());
            args[4] = instance.getType().getType();
            args[5] = instance.getModifiedById();
            args[6] = DateUtil.getTimestamp();
            args[7] = instance.getId();

            int[] types = new int[8];
            types[0] = Types.VARCHAR;
            types[1] = Types.VARCHAR;
            types[2] = Types.BIGINT;
            types[3] = Types.BIGINT;
            types[4] = Types.VARCHAR;
            types[5] = Types.VARCHAR;
            types[6] = Types.TIMESTAMP;
            types[7] = Types.VARCHAR;

            logger.debug("args:");
            printourArgs(args);

            getJdbcTemplate().update(sql, args, types);

            // Delete args
            if (isUpdate) {
                logger.debug("Deleting old request arguments...");
                delete(SQL_DELETE_ARG, instance.getId());
            }

            Object[] args2 = new Object[4];

            int[] types2 = new int[4];
            types2[0] = Types.VARCHAR;
            types2[1] = Types.VARCHAR;
            types2[2] = Types.VARCHAR;
            types2[3] = Types.VARCHAR;

            if (instance.getParameters() != null
                    && instance.getParameters().size() > 0) {

                for (Iterator it = instance.getParameters().keySet().iterator(); it
                        .hasNext();) {

                    logger.debug("Saving request parameters...");

                    // Id, RequestId, ArgKey, ArgValue
                    String key = (String) it.next();

                    args2[0] = UUIDGenerator.makeId();
                    args2[1] = instance.getId();
                    args2[2] = key;
                    args2[3] = instance.getParameters().get(key);

                    logger.debug("args2:");
                    printourArgs(args2);

                    getJdbcTemplate().update(SQL_INSERT_ARG, args2, types2);

                }
            }

            // Delete notifs
            if (isUpdate) {
                logger.debug("Deleting old request notifications...");
                delete(SQL_DELETE_REQ_NOTIF, instance.getTransactionId());
            }

            if (instance.getNotifications() != null
                    && instance.getNotifications().size() > 0) {

                logger.debug("Saving request notifications...");

                Object[] args3 = new Object[4];

                int[] types3 = new int[4];
                types3[0] = Types.VARCHAR;
                types3[1] = Types.VARCHAR;
                types3[2] = Types.VARCHAR;
                types3[3] = Types.VARCHAR;

                int notifSize = instance.getNotifications().size();
                logger.debug("Numberof notifications: " + notifSize);

                Iterator notifKeyValuePair = instance.getNotifications()
                        .entrySet().iterator();

                for (int i = 0; i < notifSize; i++) {

                    Map.Entry entry = (Map.Entry) notifKeyValuePair.next();

                    logger.debug("Map.Entry: " + entry);

                    WnosTransactionNotificationType notifType = (WnosTransactionNotificationType) entry
                            .getValue();

                    logger.debug("notifType: " + notifType);
                    logger.debug("entry.getKey(): " + entry.getKey());

                    args3[0] = UUIDGenerator.makeId();
                    args3[1] = instance.getTransactionId();
                    args3[2] = entry.getKey();
                    args3[3] = notifType.getType();

                    logger.debug("args3:");
                    printourArgs(args3);

                    getJdbcTemplate().update(SQL_INSERT_REQ_NOTIF, args3,
                            types3);

                }

            }

            // Delete RECIPIENTS
            if (isUpdate) {
                logger.debug("Deleting old request recipients...");
                delete(SQL_DELETE_REQ_RECIPIENTS, instance.getTransactionId());
            }

            if (instance.getRecipients() != null
                    && instance.getRecipients().size() > 0) {

                logger.debug("Saving request recipients...");

                Object[] args4 = new Object[3];

                int[] types4 = new int[3];
                types4[0] = Types.VARCHAR;
                types4[1] = Types.VARCHAR;
                types4[2] = Types.VARCHAR;

                for (int r = 0; r < instance.getRecipients().size(); r++) {

                    String recipient = (String) instance.getRecipients().get(r);

                    if (StringUtils.isNotBlank(recipient)) {

                        // Id, TransactionId, Uri
                        args4[0] = UUIDGenerator.makeId();
                        args4[1] = instance.getTransactionId();
                        args4[2] = recipient;

                        logger.debug("args4:");
                        printourArgs(args4);
                        getJdbcTemplate().update(SQL_INSERT_REQ_RECIPIENTS,
                                args4, types4);

                    }

                }
            }

        } catch (Exception reqEx) {

            logger.error("Error while saving request: ", reqEx);

            if (instance != null && StringUtils.isNotBlank(instance.getId())) {
                delete(instance.getId());
            }

            throw new RuntimeException(reqEx);

        }

        return instance;
    }

    /**
     * delete
     */
    public void delete(String id) {

        validateStringArg(id);
        delete(SQL_DELETE_ARG, id);
        delete(SQL_DELETE, id);
    }

    /**
     * RequestMapper
     * 
     * @author mchmarny
     * 
     */
    private class RequestMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            DataRequest obj = new DataRequest();

            // Id, TransactionId, ServiceId, RowIndex, MaxRowCount, RequestType,
            // ModifiedBy, ModifiedOn

            obj.setId(rs.getString("Id"));
            obj.setTransactionId(rs.getString("TransactionId"));
            obj.setService(serviceDao.get(rs.getString("ServiceId")));
            obj.setPaging(new PaginationIndicator(rs.getInt("RowIndex"), rs
                    .getInt("MaxRowCount"), true));
            obj.setType(RequestType.valueOf(rs.getString("RequestType")));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setNotifications(getMap(SQL_SELECT_REQ_NOTIF, obj
                    .getTransactionId(), false));
            obj.setRecipients(getList(SQL_SELECT_REQ_RECIPIENTS, obj
                    .getTransactionId()));

            return loadRequestArgs(obj);

        }
    }

    public void setServiceDao(ServiceDao serviceDao) {
        this.serviceDao = serviceDao;
    }

}
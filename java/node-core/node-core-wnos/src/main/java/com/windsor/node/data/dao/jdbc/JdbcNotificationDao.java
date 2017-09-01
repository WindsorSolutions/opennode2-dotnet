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

import org.springframework.beans.factory.InitializingBean;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.NotificationType;
import com.windsor.node.common.domain.UserFlowNotification;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.NotificationDao;
import com.windsor.node.util.FormatUtil;

public class JdbcNotificationDao extends BaseJdbcDao implements
        NotificationDao, InitializingBean {

    private FlowDao flowDao;
    private AccountDao accountDao;

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, FlowId, AccountId, OnSolicit, OnQuery, "
            + "OnSubmit, OnNotify, OnSchedule, OnDownload, OnExecute FROM NNotification ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_ACCOUNT = SQL_SELECT
            + " WHERE AccountId = ? ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_FLOW = SQL_SELECT
            + " WHERE FlowId = ? ORDER BY FlowId ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NNotification ( FlowId, AccountId, OnSolicit, "
            + "OnQuery, OnSubmit, OnNotify, OnSchedule, OnDownload, OnExecute, Id  ) "
            + "VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE_USER = "DELETE FROM NNotification WHERE AccountId = ?";

    private static final String SQL_DELETE_FLOW = "DELETE FROM NNotification WHERE FlowId = ?";

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {

        super.checkDaoConfig();

        if (flowDao == null) {
            throw new RuntimeException("Flow Dao Not Set");
        }

        if (accountDao == null) {
            throw new RuntimeException("Account Not Set");
        }
    }

    /**
     * getByFlowIdAndType
     */
    public List<String> getByFlowIdAndType(String id, NotificationType type) {

        validateStringArg(id);
        validateObjectArg(type, "NotificationType");

        String sql = "SELECT DISTINCT NAASAccount FROM NAccount "
                + "WHERE IsActive = ? AND Id IN "
                + "  (SELECT AccountId FROM NNotification "
                + "    WHERE FlowId = ? AND " + type.getType() + " = ?)";

        return getJdbcTemplate().query(sql,
                new Object[] { FormatUtil.YES, id, FormatUtil.YES },
                new ArrayMapper());

    }

    /**
     * getByAccountId
     */
    public List<UserFlowNotification> getByAccountId(String id) {

        validateStringArg(id);

        return getJdbcTemplate().query(SQL_SELECT_ACCOUNT, new Object[] { id },
                new NotificationMapper());

    }

    /**
     * getByFlowId
     */
    public List<UserFlowNotification> getByFlowId(String id) {

        validateStringArg(id);

        return getJdbcTemplate().query(SQL_SELECT_FLOW, new Object[] { id },
                new NotificationMapper());
    }

    /**
     * save
     */
    public void save(String accountId, List<UserFlowNotification> notifications) {

        validateStringArg(accountId);
        validateObjectArg(notifications, "Notifications");

        deleteByUserId(accountId);

        for (int i = 0; i < notifications.size(); i++) {

            UserFlowNotification instance = notifications.get(i);

            logger.debug("Saving Notifcation: " + instance);

            Object[] args = new Object[10];

            // FlowId, AccountId, OnSolicit, OnQuery, OnSubmit, OnNotify,
            // OnSchedule, OnDownload, OnExecute, Id,

            args[0] = instance.getFlow().getId();
            args[1] = accountId;
            args[2] = getYNFlagFromNotifications(instance.isOnSolicit());
            args[3] = getYNFlagFromNotifications(instance.isOnQuery());
            args[4] = getYNFlagFromNotifications(instance.isOnSubmit());
            args[5] = getYNFlagFromNotifications(instance.isOnNotify());
            args[6] = getYNFlagFromNotifications(instance.isOnSchedule());
            args[7] = getYNFlagFromNotifications(instance.isOnDownload());
            args[8] = getYNFlagFromNotifications(instance.isOnExecute());
            args[9] = idGenerator.createId();

            getJdbcTemplate().update(SQL_INSERT, args);

        }

    }

    /**
     * getYNFlagFromNotifications
     * 
     * @param on
     * @return
     */
    private String getYNFlagFromNotifications(boolean on) {

        return (on) ? FormatUtil.YES : FormatUtil.NO;

    }

    public void deleteByUserId(String id) {
        validateStringArg(id);
        delete(SQL_DELETE_USER, id);
    }

    public void deleteByFlowId(String id) {
        validateStringArg(id);
        delete(SQL_DELETE_FLOW, id);
    }

    /**
     * get
     */
    public List<UserFlowNotification> get() {

        return getJdbcTemplate().query(SQL_SELECT, new NotificationMapper());

    }

    /**
     * 
     * @author mchmarny
     * 
     */
    private class NotificationMapper implements RowMapper<UserFlowNotification> {

        public UserFlowNotification mapRow(ResultSet rs, int rowNum) throws SQLException {

            UserFlowNotification obj = new UserFlowNotification();

            // Id, FlowId, AccountId, OnSolicit, OnQuery, OnSubmit, OnNotify,
            // OnSchedule, OnDownload, OnExecute

            obj.setId(rs.getString("Id"));
            obj.setFlow(flowDao.get(rs.getString("FlowId")));
            obj.setModifiedById(rs.getString("AccountId"));

            obj.setOnSolicit(getNotificationType(rs, "OnSolicit"));
            obj.setOnSubmit(getNotificationType(rs, "OnSubmit"));
            obj.setOnQuery(getNotificationType(rs, "OnQuery"));
            obj.setOnNotify(getNotificationType(rs, "OnNotify"));
            obj.setOnSchedule(getNotificationType(rs, "OnSchedule"));
            obj.setOnDownload(getNotificationType(rs, "OnDownload"));
            obj.setOnExecute(getNotificationType(rs, "OnExecute"));
            obj.setOnExecute(getNotificationType(rs, "OnError"));

            return obj;

        }

    }

    /**
     * Internal use only
     * 
     * @param rs
     * @param colName
     * @return
     * @throws SQLException
     */
    private boolean getNotificationType(ResultSet rs, String colName)
            throws SQLException {

        return FormatUtil.toBooleanFromYN(rs.getString(colName));

    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

}
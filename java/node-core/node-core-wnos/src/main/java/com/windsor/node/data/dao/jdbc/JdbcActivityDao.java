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
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.ActivitySearchCriteria;
import com.windsor.node.common.domain.ActivitySearchLookups;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.ChartItem;
import com.windsor.node.common.domain.DashboardContent;
import com.windsor.node.data.dao.ActivityDao;
import com.windsor.node.util.DateUtil;

public class JdbcActivityDao extends BaseJdbcDao implements ActivityDao {

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT L.Id, L.ActivityType, "
            + "L.TransactionId, L.IP, A.NAASAccount AS ModifiedBy, "
            + "A.Id as ModifiedById, L.ModifiedOn, COALESCE(L.WebMethod, T.WebMethod) AS WebMethod, F.Code As FlowCode "
            + "FROM NActivity L JOIN NAccount A ON A.Id = L.ModifiedBy "
            + "LEFT JOIN NTransaction T ON L.TransactionId = T.Id "
            + "LEFT JOIN NFlow F ON T.FlowId = F.Id " + "WHERE L.Id = ?  ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SEARCH = "SELECT L.Id, L.ActivityType, "
            + "L.TransactionId, L.IP, A.NAASAccount AS ModifiedBy, "
            + "A.Id as ModifiedById, L.ModifiedOn, COALESCE(L.WebMethod, T.WebMethod) AS WebMethod, F.Code As FlowCode "
            + "FROM NActivity L JOIN NAccount A ON A.Id = L.ModifiedBy "
            + "LEFT JOIN NTransaction T ON L.TransactionId = T.Id "
            + "LEFT JOIN NFlow F ON T.FlowId = F.Id "
            + "WHERE L.ModifiedOn BETWEEN ? AND ? ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NActivity "
            + "( Id, ActivityType, TransactionId, IP, ModifiedBy, ModifiedOn, WebMethod, FlowName, Operation ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_DETAIL = "SELECT Detail, ModifiedOn FROM NActivityDetail WHERE ActivityId = ? ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT_DETAIL = "INSERT INTO NActivityDetail ( Id, ActivityId, Detail, ModifiedOn, OrderIndex ) VALUES ( ?, ?, ?, ?, ? )";

    /**
     * Lookup SQL TransactionId
     */
    private static final String SQL_LOOKUP_TRAN = "SELECT DISTINCT T.NetworkId FROM NTransaction "
            + "T WHERE T.Id IN (SELECT A.TransactionId FROM NActivity A) ORDER BY T.NetworkId ";

    /**
     * Lookup SQL IP
     */
    private static final String SQL_LOOKUP_IP = "SELECT DISTINCT IP FROM NActivity ORDER BY IP ";

    /**
     * Lookup SQL ActivityType
     */
    private static final String SQL_LOOKUP_TYPE = "SELECT DISTINCT ActivityType FROM NActivity ORDER BY ActivityType ";

    /**
     * Lookup SQL Account
     */
    private static final String SQL_LOOKUP_ACCOUNT = "SELECT DISTINCT A.NAASAccount FROM NAccount A "
            + "JOIN NActivity L ON A.Id = L.ModifiedBy ORDER BY A.NAASAccount ";

    private static final String SQL_DASHBOARD_USER = "SELECT A.NAASAccount AS AccountName, "
            + "COUNT(*) AS AccountCount "
            + "FROM NActivity L "
            + "JOIN NAccount A ON A.Id = L.ModifiedBy "
            + "GROUP BY A.NAASAccount " + "ORDER BY 2 DESC";

    private static final String SQL_DASHBOARD_METHOD = "SELECT T.WebMethod AS MethodName, "
            + "COUNT(*) AS MethodCount "
            + "FROM NActivity L "
            + "JOIN NTransaction T ON L.TransactionId = T.Id "
            + "GROUP BY T.WebMethod " + "ORDER BY 2 DESC ";

    private static final int MAX_NUM_OF_DETAIL_CHARS = 3900;

    /**
     * getDashboardContent
     */
    public DashboardContent getDashboardContent() {

        DashboardContent content = new DashboardContent();

        content.setActivityItems(getJdbcTemplate().query(SQL_DASHBOARD_USER,
                new ChartItemMapper()));

        content.setTransactionItems(getJdbcTemplate().query(
                SQL_DASHBOARD_METHOD, new ChartItemMapper()));

        ActivitySearchCriteria criteria = new ActivitySearchCriteria();
        criteria.setMaxRecords(10);
        criteria.setOnlyWithTransactions(true);

        content.setResult(search(criteria));

        logger.debug("Found: " + content.getResult().size());

        return content;
    }

    /**
     * create
     */
    public void make(Activity instance) {

        validateObjectArg(instance, "Activity");

        try {

            String objId = idGenerator.createId();
            instance.setId(objId);

            // Id, ActivityType, TransactionId, IP, ModifiedBy, ModifiedOn

            Object[] args = new Object[9];
            args[0] = instance.getId();
            args[1] = instance.getType().name();
            args[2] = instance.getTransactionId();
            args[3] = instance.getIp();
            args[4] = instance.getModifiedById();
            args[5] = DateUtil.getTimestamp();
            args[6] = instance.getWebMethod();
            args[7] = instance.getFlowName();
            args[8] = instance.getOperation();

            int[] types = new int[9];
            types[0] = Types.VARCHAR;
            types[1] = Types.VARCHAR;
            types[2] = Types.VARCHAR;
            types[3] = Types.VARCHAR;
            types[4] = Types.VARCHAR;
            types[5] = Types.TIMESTAMP;
            types[6] = Types.VARCHAR;
            types[7] = Types.VARCHAR;
            types[8] = Types.VARCHAR;

            printourArgs(args);

            logger.debug("Inserting Activity");

            getJdbcTemplate().update(SQL_INSERT, args, types);

            // Insert Detail
            Object[] args2 = new Object[5];

            int[] types2 = new int[5];
            types2[0] = Types.VARCHAR;
            types2[1] = Types.VARCHAR;
            types2[2] = Types.VARCHAR;
            types2[3] = Types.TIMESTAMP;
            types2[4] = Types.NUMERIC;

            // For each detail
            for (Iterator<ActivityEntry> it = instance.getEntries().iterator(); it.hasNext();) {

                ActivityEntry entry = it.next();

                logger.debug("entry: " + entry);

                if (StringUtils.isNotBlank(entry.getMessage())) {

                    String msgDetail = entry.getMessage();

                    // Id, ActivityId, Detail, ModifiedOn
                    if (msgDetail != null
                            && msgDetail.length() > MAX_NUM_OF_DETAIL_CHARS) {
                        logger
                                .error("Activity detail too long, trimming to first "
                                        + MAX_NUM_OF_DETAIL_CHARS + " chars");
                        logger.error(msgDetail);
                        msgDetail = msgDetail.substring(0,
                                MAX_NUM_OF_DETAIL_CHARS);
                    }

                    args2[0] = idGenerator.createId();
                    args2[1] = instance.getId();
                    args2[2] = msgDetail;
                    args2[3] = entry.getModifiedOn();
                    args2[4] = entry.getOrderIndex();

                    printourArgs(args2);

                    logger.debug("Inserting Activity Entry");
                    getJdbcTemplate().update(SQL_INSERT_DETAIL, args2, types2);
                    logger.debug("Inserted Activity Entry");

                }
            }

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(ex);
        }

    }

    /**
     * get
     */
    public Activity get(String id) {

        validateStringArg(id);

        Activity obj = (Activity) getJdbcTemplate().queryForObject(SQL_SELECT,
                new Object[] { id }, new ActivityMapper());

        obj.setEntries(getJdbcTemplate().query(SQL_SELECT_DETAIL,
                new Object[] { id }, new ActivityDetailMapper()));

        return obj;

    }

    /**
     * getLookups
     */
    public ActivitySearchLookups getLookups() {

        ActivitySearchLookups obj = new ActivitySearchLookups();

        // Account
        obj.setAccountList(getList(SQL_LOOKUP_ACCOUNT));

        // ActivityType
        obj.setEntryTypes(getList(SQL_LOOKUP_TYPE));

        // IP
        obj.setIpList(getList(SQL_LOOKUP_IP));

        // Transaction
        obj.setTransactionList(getList(SQL_LOOKUP_TRAN));

        return obj;

    }

    /**
     * search
     */
    public List<Activity> search(ActivitySearchCriteria instance) {

        validateObjectArg(instance, "ActivitySearchCriteria");

        if (instance.getCreatedFrom() == null
                || instance.getCreatedTo() == null) {
            throw new IllegalArgumentException(
                    "Arguments From and To cannot be null.");
        }

        if (instance.getCreatedFrom().after(instance.getCreatedTo())) {
            throw new IllegalArgumentException(
                    "\"From\" date must be earlier than \"To\" date.");
        }

        String sql = SQL_SEARCH;

        ArrayList<Object> args = new ArrayList<Object>();

        args.add(instance.getCreatedFrom());
        args.add(instance.getCreatedTo());

        // Id, Type, TransactionId, IP, ModifiedBy, ModifiedOn

        // Type
        if (StringUtils.isNotBlank(instance.getType())) {
            sql += " AND UPPER(L.ActivityType) = ? ";
            args.add(instance.getType().trim().toUpperCase());
        }

        // TransactionId
        if (StringUtils.isNotBlank(instance.getTransactionId())) {
            sql += " AND L.TransactionId IN (SELECT T2.Id FROM NTransaction T2 WHERE UPPER(T2.NetworkId) = ?) ";
            args.add(instance.getTransactionId().trim().toUpperCase());
        } else if (instance.isOnlyWithTransactions()) {
            sql += " AND L.TransactionId IS NOT NULL ";
        }

        // IP
        if (StringUtils.isNotBlank(instance.getIp())) {
            sql += " AND L.IP = ? ";
            args.add(instance.getIp());
        }

        // NAASAccount
        if (StringUtils.isNotBlank(instance.getCreatedById())) {
            sql += " AND A.Id = ? ";
            args.add(instance.getCreatedById());
        }

        // Detail
        if (StringUtils.isNotBlank(instance.getDetailContains())) {
            sql += " AND L.Id IN (SELECT D.ActivityId FROM NActivityDetail D WHERE UPPER(D.Detail) LIKE ? ) ";
            args.add("%" + instance.getDetailContains().trim().toUpperCase()
                    + "%");
        }

        // FlowId
        if (StringUtils.isNotBlank(instance.getFlowId())) {
            sql += " AND L.TransactionId IN (SELECT T.Id FROM NTransaction T WHERE T.FlowId = ?) ";
            args.add(instance.getFlowId());
        }

        sql += " ORDER BY L.ModifiedOn DESC ";

        logger.debug("sql: " + sql);
        printourArgs(args.toArray());

        JdbcTemplate template = getJdbcTemplate();
        template.setMaxRows(instance.getMaxRecords());

        return template.query(sql, args.toArray(), new ActivityMapper());

    }

    /**
     * ActivityDetailMapper
     * 
     * @author mchmarny
     * 
     */
    private class ActivityDetailMapper implements RowMapper<ActivityEntry> {

        public ActivityEntry mapRow(ResultSet rs, int rowNum) throws SQLException {

            ActivityEntry obj = new ActivityEntry();

            // Detail, ModifiedOn

            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setMessage(rs.getString("Detail"));

            return obj;

        }

    }

    private class ChartItemMapper implements RowMapper<ChartItem> {

        public ChartItem mapRow(ResultSet rs, int rowNum) throws SQLException {

            ChartItem item = new ChartItem();

            item.setLabel(rs.getString(1));
            item.setCount(rs.getInt(2));

            return item;

        }

    }

    /**
     * ActivityMapper
     * 
     * @author mchmarny
     * 
     */
    private class ActivityMapper implements RowMapper<Activity> {

        public Activity mapRow(ResultSet rs, int rowNum) throws SQLException {

            Activity obj = new Activity();

            // L.Id, L.ActivityType, L.TransactionId, L.IP, A.NAASAccount AS
            // ModifiedBy,
            // L.ModifiedOn

            obj.setId(rs.getString("Id"));
            obj.setUserName(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setIp(rs.getString("IP"));
            obj.setTransactionId(rs.getString("TransactionId"));
            obj.setFlowName(rs.getString("FlowCode"));
            obj.setWebMethod(rs.getString("WebMethod"));

            obj.setType((ActivityType) ActivityType.valueOf(rs
                    .getString("ActivityType")));

            return obj;

        }

    }

}
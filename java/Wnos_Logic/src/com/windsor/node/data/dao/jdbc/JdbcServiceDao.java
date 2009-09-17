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

import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NamedSystemConfigItem;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.data.dao.ConnectionDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.FormatUtil;

/**
 * Saves and retrieves {@link com.windsor.node.common.domain.DataService
 * DataServices} to/from the Node metadata database.
 */
public class JdbcServiceDao extends BaseJdbcDao implements ServiceDao,
        InitializingBean {

    /**
     * Select the service arguments for a given DataService id.
     */
    protected static final String SQL_SELECT_ARG = "SELECT ArgKey, ArgValue FROM NServiceArg WHERE ServiceId = ? ORDER BY ArgKey  ";

    /**
     * Insert the service arguments for a given DataService id.
     */
    protected static final String SQL_INSERT_ARG = "INSERT INTO NServiceArg ( Id, ServiceId, ArgKey, ArgValue ) VALUES ( ?, ?, ?, ? )";

    /**
     * Delete the service arguments for a given DataService id.
     */
    protected static final String SQL_DELETE_ARG = "DELETE FROM NServiceArg WHERE ServiceId = ?";

    /**
     * Insert a data source for a given DataService id.
     */
    protected static final String SQL_INSERT_CONN = "INSERT INTO NServiceConn ( Id, ServiceId, ConnectionId, KeyName ) VALUES ( ?, ?, ?, ? )";

    /**
     * Delete a data source for a given DataService id.
     */
    protected static final String SQL_DELETE_CONN = "DELETE FROM NServiceConn WHERE ServiceId = ? ";

    /**
     * Base &quot;select&quot; statement.
     */
    private static final String SQL_SELECT = "SELECT Id, Name, FlowId, IsActive, ServiceType, "
            + "Implementor, AuthLevel, ModifiedBy, ModifiedOn FROM NService ";

    /**
     * For ENDS2 support.
     */
    private static final String SQL_SELECT_WITH_FLOW_NAME = "SELECT s.Id, s.Name, s.FlowId, s.IsActive, s.ServiceType, "
            + "s.Implementor, s.AuthLevel, s.ModifiedBy, s.ModifiedOn, f.Code FROM NService s, NFlow f "
            + "WHERE s.IsActive = 'Y' AND f.Id = s.FlowId ORDER BY f.Code, s.Name";

    private static final String SQL_SELECT_ACTIVE_BY_IMLPEMENTOR = SQL_SELECT
            + " WHERE IsActive = 'Y' and Implementor = ? ";

    /**
     * Select active DataService ids and names.
     */
    private static final String SQL_SELECT_ID_AND_NAME_LIST = "SELECT Id, Name FROM NService WHERE IsActive = 'Y'  ORDER BY Name";

    /**
     * Select active DataService ids and names for a given DataFlow id.
     */
    private static final String SQL_SELECT_ID_AND_NAME_LIST_BY_FLOW = "SELECT Id, Name FROM NService"
            + " WHERE FlowId = ? AND IsActive = 'Y' ORDER BY Name";

    /**
     * Select all columns and rows.
     */
    private static final String SQL_SELECT_ALL = SQL_SELECT + " ORDER BY Name";

    /**
     * Select all columns and rows for a given DataFlow id.
     */
    private static final String SQL_SELECT_FLOW = SQL_SELECT
            + " WHERE FlowId = ? ORDER BY Name ";

    /**
     * Select all columns for a given DataService id.
     */
    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    /**
     * Select all columns for a given DataService name and DataFlow id.
     */
    private static final String SQL_SELECT_NAME_AND_ID = SQL_SELECT
            + " WHERE FlowId = ? AND UPPER(Name) = ? ";

    /**
     * Select all columns for a given DataService name.
     */
    private static final String SQL_SELECT_NAME = SQL_SELECT
            + " WHERE UPPER(Name) = ? ";

    /**
     * Insert a new DataService
     */
    private static final String SQL_INSERT = "INSERT INTO NService ( Name, FlowId, IsActive, "
            + "ServiceType, Implementor, AuthLevel, ModifiedBy, ModifiedOn, Id ) VALUES "
            + "( ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * Update an existing DataService for a given DataService id.
     */
    private static final String SQL_UPDATE = "UPDATE NService SET Name = ?, FlowId = ?, "
            + "IsActive = ?, ServiceType = ?, Implementor = ?, AuthLevel = ?, ModifiedBy = ?, "
            + "ModifiedOn = ? WHERE Id = ?";

    /**
     * Delete an existing DataService for a given DataService id.
     */
    private static final String SQL_DELETE = "DELETE FROM NService WHERE Id = ?";

    /**
     * Dao for related data sources.
     */
    private ConnectionDao connectionDao;

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.jdbc.BaseJdbcDao#checkDaoConfig()
     */
    protected void checkDaoConfig() {

        super.checkDaoConfig();

        if (connectionDao == null) {
            throw new RuntimeException("connectionDao Not Set");
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.ServiceDao#get(java.lang.String)
     */
    public DataService get(String id) {

        validateStringArg(id);

        return (DataService) queryForObject(SQL_SELECT_ID, new Object[] { id },
                new ServiceMapper());

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.ServiceDao#getByServiceName(java.lang.String)
     */
    public DataService getByServiceName(String name) {

        validateStringArg(name);

        return (DataService) queryForObject(SQL_SELECT_NAME,
                new Object[] { name.toUpperCase() }, new ServiceMapper());
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.ServiceDao#getByServiceName(java.lang.String,
     * java.lang.String)
     */
    public DataService getByServiceName(String flowId, String name) {

        validateStringArg(flowId);
        validateStringArg(name);

        return (DataService) queryForObject(SQL_SELECT_NAME_AND_ID,
                new Object[] { flowId, name.toUpperCase() },
                new ServiceMapper());
    }

    private void saveConn(List<?> dataSources, String serviceId) {

        validateObjectArg(dataSources, "Map");

        int[] types = new int[4];
        types[0] = Types.VARCHAR;
        types[1] = Types.VARCHAR;
        types[2] = Types.VARCHAR;
        types[3] = Types.VARCHAR;

        Object[] args = new Object[4];
        args[1] = serviceId;

        for (Iterator<?> it = dataSources.iterator(); it.hasNext();) {

            DataProviderInfo dataSource = (DataProviderInfo) it.next();

            if (null == dataSource.getId()) {
                throw new RuntimeException(
                        "Please select a configured DataSource");
            }

            args[0] = idGenerator.createId();
            args[1] = serviceId;
            args[2] = dataSource.getId();
            args[3] = dataSource.getCode();

            // Id, ServiceId, ConnectionId, KeyName

            getJdbcTemplate().update(SQL_INSERT_CONN, args, types);

        }

    }

    private void saveArgs(List<?> serviceArgs, String serviceId) {

        validateObjectArg(serviceArgs, "Map");

        int[] types = new int[4];
        types[0] = Types.VARCHAR;
        types[1] = Types.VARCHAR;
        types[2] = Types.VARCHAR;
        types[3] = Types.VARCHAR;

        Object[] args = new Object[4];

        for (Iterator<?> it = serviceArgs.iterator(); it.hasNext();) {

            NamedSystemConfigItem serviceArg = (NamedSystemConfigItem) it
                    .next();

            // Id, ServiceId, ArgKey, ArgValue
            args[0] = idGenerator.createId();
            args[1] = serviceId;
            args[2] = serviceArg.getKey();
            if (serviceArg.isGlobal()) {
                args[3] = NamedSystemConfigItem.GLOBAL_ARG_INDICATOR_CHAR
                        + serviceArg.getValue();
            } else {
                args[3] = serviceArg.getValue();
            }

            getJdbcTemplate().update(SQL_INSERT_ARG, args, types);

        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.ServiceDao#save(com.windsor.node.common.domain
     * .DataService)
     */
    public DataService save(DataService instance) {

        validateObjectArg(instance, "DataService");

        String sql = SQL_UPDATE;

        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        } else {

            // For update delete the connections
            delete(SQL_DELETE_CONN, instance.getId());
            // And the args
            delete(SQL_DELETE_ARG, instance.getId());
        }

        if (StringUtils.isBlank(instance.getName())) {
            throw new RuntimeException("Null service name");
        }

        Object[] args = new Object[9];

        args[0] = instance.getName();
        args[1] = instance.getFlowId();
        args[2] = FormatUtil.toYNFromBoolean(instance.isActive());
        args[3] = instance.getType().toString();
        args[4] = instance.getImplementingClassName();
        args[5] = ServiceRequestAuthorizationType.BASIC.getName();
        args[6] = instance.getModifiedById();
        args[7] = DateUtil.getTimestamp();
        args[8] = instance.getId();

        int[] types = new int[9];
        types[0] = Types.VARCHAR;
        types[1] = Types.VARCHAR;
        types[2] = Types.VARCHAR;
        types[3] = Types.VARCHAR;
        types[4] = Types.VARCHAR;
        types[5] = Types.VARCHAR;
        types[6] = Types.VARCHAR;
        types[7] = Types.TIMESTAMP;
        types[8] = Types.VARCHAR;

        printourArgs(args);

        getJdbcTemplate().update(sql, args, types);

        try {

            // Save connections
            saveConn(instance.getDataSources(), instance.getId());

            // Save args
            saveArgs(instance.getArgs(), instance.getId());

        } catch (Exception srvEx) {
            delete(instance.getId());
            throw new WinNodeException("Error while saving DataService: "
                    + srvEx.getMessage(), srvEx);
        }

        return instance;

    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.DeletableDao#delete(java.lang.String)
     */
    public void delete(String id) {

        validateStringArg(id);
        // delete the connections
        delete(SQL_DELETE_CONN, id);
        // and the args
        delete(SQL_DELETE_ARG, id);

        delete(SQL_DELETE, id);
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.ServiceDao#getByFlowId(java.lang.String)
     */
    @SuppressWarnings("unchecked")
    public List<DataService> getByFlowId(String id) {

        validateStringArg(id);

        return getJdbcTemplate().query(SQL_SELECT_FLOW, new Object[] { id },
                new ServiceMapper());
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.ServiceDao#getActive()
     */
    public Map<String, String> getActive() {

        return getMap(SQL_SELECT_ID_AND_NAME_LIST, false);
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.data.dao.ServiceDao#getActiveByFlowId(java.lang.String)
     */
    public Map<String, String> getActiveByFlowId(String id) {

        validateStringArg(id);

        return getMap(SQL_SELECT_ID_AND_NAME_LIST_BY_FLOW, id, false);
    }

    @SuppressWarnings("unchecked")
    private List<NamedSystemConfigItem> getServiceArgs(String serviceId) {

        validateStringArg(serviceId);

        return getJdbcTemplate().query(SQL_SELECT_ARG,
                new Object[] { serviceId }, new ServiceArgMapper(serviceId));
    }

    @SuppressWarnings("unchecked")
    public List<DataService> get() {
        return getJdbcTemplate().query(SQL_SELECT_ALL, new ServiceMapper());
    }

    @SuppressWarnings("unchecked")
    public List<DataService> getServicesForEnds2() {
        return getJdbcTemplate().query(SQL_SELECT_WITH_FLOW_NAME,
                new ServiceMapper());
    }

    @SuppressWarnings("unchecked")
    public List<DataService> getActiveByImplementor(String implementorName) {

        validateStringArg(implementorName);

        return getJdbcTemplate().query(SQL_SELECT_ACTIVE_BY_IMLPEMENTOR,
                new Object[] { implementorName }, new ServiceMapper());
    }

    /**
     * Maps a database row to a DataService instance.
     * 
     */
    private class ServiceMapper implements RowMapper {

        /*
         * (non-Javadoc)
         * 
         * @see
         * org.springframework.jdbc.core.RowMapper#mapRow(java.sql.ResultSet,
         * int)
         */
        @SuppressWarnings("unchecked")
        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            DataService obj = new DataService();

            obj.setId(rs.getString("Id"));
            obj.setName(rs.getString("Name"));
            obj.setFlowId(rs.getString("FlowId"));
            obj.setActive(FormatUtil.toBooleanFromYN(rs.getString("IsActive")));
            obj.setType((ServiceType) ServiceType.fromString(rs
                    .getString("ServiceType")));
            obj.setImplementingClassName(rs.getString("Implementor"));
            obj.setArgs(getServiceArgs(rs.getString("Id")));
            obj.setDataSources(connectionDao.getBySerivceId(obj.getId()));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));

            if (containsColumnNamed(rs, "Code")) {
                obj.setFlowName(rs.getString("Code"));
            }

            return obj;
        }

    }

    /**
     * Maps a database row to a
     * {@link com.windsor.node.common.domain.NamedSystemConfigItem
     * NamedSystemConfigItem} instance.
     * 
     */
    private class ServiceArgMapper implements RowMapper {

        private String serviceId;

        /**
         * @param serviceId
         */
        public ServiceArgMapper(String serviceId) {
            this.serviceId = serviceId;
        }

        /*
         * (non-Javadoc)
         * 
         * @see
         * org.springframework.jdbc.core.RowMapper#mapRow(java.sql.ResultSet,
         * int)
         */
        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            NamedSystemConfigItem obj = new NamedSystemConfigItem();

            // ArgKey, ArgValue
            obj.setServiceId(serviceId);
            obj.setGlobal(false);
            obj.setKey(rs.getString("ArgKey"));

            String argValue = rs.getString("ArgValue");

            if (StringUtils.isNotBlank(argValue)) {

                obj
                        .setGlobal(argValue
                                .startsWith(NamedSystemConfigItem.GLOBAL_ARG_INDICATOR_CHAR));

                if (obj.isGlobal()) {
                    argValue = argValue
                            .substring(NamedSystemConfigItem.GLOBAL_ARG_INDICATOR_CHAR
                                    .length());
                }
            }

            obj.setValue(argValue);

            return obj;
        }

    }

    public void setConnectionDao(ConnectionDao connectionDao) {
        this.connectionDao = connectionDao;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

}

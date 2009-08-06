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

import org.apache.commons.lang.StringUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.data.dao.ConnectionDao;

public class JdbcConnectionDao extends BaseJdbcDao implements ConnectionDao {

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, Code, Provider, ConnectionString, ModifiedBy, ModifiedOn FROM NConnection ";

    private static final String SQL_SELECT_ALL = SQL_SELECT + " ORDER BY Id";

    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    private static final String SQL_SELECT_SERVICE = "SELECT Id, ConnectionId, KeyName FROM NServiceConn WHERE ServiceId = ? ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NConnection ( Code, Provider, ConnectionString, ModifiedBy, ModifiedOn, Id ) VALUES ( ?, ?, ?, ?, ?, ?) ";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NConnection SET Code = ?, Provider = ?, ConnectionString = ?, "
            + "ModifiedBy = ?, ModifiedOn = ? WHERE Id = ? ";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NConnection WHERE Id = ? ";

    /**
     * save
     */
    public DataProviderInfo save(DataProviderInfo instance) {

        validateObjectArg(instance, "DataProviderInfo");

        String sql = SQL_UPDATE;
        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        Object[] args = new Object[6];

        args[0] = instance.getCode();
        args[1] = instance.getProviderType();
        args[2] = instance.getConnectionString();
        args[3] = instance.getModifiedById();
        args[4] = instance.getModifiedOn();
        args[5] = instance.getId();

        printourArgs(args);

        getJdbcTemplate().update(sql, args);

        return instance;

    }

    /**
     * delete
     */
    public void delete(String id) {
        validateStringArg(id);
        delete(SQL_DELETE, id);
    }

    /**
     * Fetches all record.
     * 
     * @return List of type <DataProviderInfo>
     */
    public List get() {

        return getJdbcTemplate().query(SQL_SELECT_ALL, new DataSourceMapper());

    }

    public DataProviderInfo get(String id) {

        validateStringArg(id);

        return (DataProviderInfo) queryForObject(SQL_SELECT_ID,
                new Object[] { id }, new DataSourceMapper());

    }

    /**
     * getBySerivceId
     */
    public List getBySerivceId(String serviceId) {

        validateStringArg(serviceId);
        return getJdbcTemplate().query(SQL_SELECT_SERVICE,
                new Object[] { serviceId }, new ServiceConnectionMapper());

    }

    private class ServiceConnectionMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            DataProviderInfo obj = new DataProviderInfo();

            String connectionId = rs.getString("ConnectionId");

            if (connectionId != null) {
                obj = get(connectionId);
            }

            obj.setCode(rs.getString("KeyName"));

            return obj;
        }
    }

    /**
     * DataSourceMapper
     * 
     * @author mchmarny
     * 
     */
    private class DataSourceMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            DataProviderInfo obj = new DataProviderInfo();

            obj.setId(rs.getString("Id"));
            obj.setCode(rs.getString("Code"));
            obj.setProviderType(rs.getString("Provider"));
            obj.setConnectionString(rs.getString("ConnectionString"));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));

            return obj;

        }

    }

}
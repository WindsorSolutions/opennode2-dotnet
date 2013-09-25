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

import org.springframework.beans.factory.InitializingBean;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.data.dao.PluginDao;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.DateUtil;

public class JdbcPluginDao extends BaseJdbcDao implements PluginDao,
        InitializingBean {

    protected final String SQL_SELECT_CONTENT = "SELECT PluginContent FROM NPlugin WHERE Id = ? ";

    protected final String SQL_INSERT = "INSERT INTO NPlugin (Id, FlowId, ModifiedBy, ModifiedOn, PluginContent) VALUES(?, ?, ?, ?, ?)";

    protected final String SQL_SELECT_LATEST = "SELECT Id FROM NPlugin WHERE FlowId = ? AND ModifiedOn = (SELECT MAX(ModifiedOn) FROM NPlugin WHERE FlowId = ?)";

    public byte[] get(String id) {
        return (byte[]) getJdbcTemplate().queryForObject(SQL_SELECT_CONTENT,
                new Object[] { id }, byte[].class);
    }

    public String getLatestId(String flowId) {
        return (String) queryForObject(SQL_SELECT_LATEST, new Object[] {
                flowId, flowId }, new SimpleStringMapper());
    }

    private class SimpleStringMapper implements RowMapper<String> {
        public String mapRow(ResultSet rs, int rowNum) throws SQLException {
            return rs.getString("Id");
        }
    }

    public String save(String flowId, String accountId, byte[] content) {

        validateObjectArg(flowId, "String");
        validateObjectArg(accountId, "String");
        validateObjectArg(content, "byte[]");

        logger.debug("Saving Plugin:" + flowId);

        // Id, FlowId, ModifiedBy, ModifiedOn, PluginContent

        String pluginId = UUIDGenerator.makeId();

        Object[] args = new Object[5];

        args[0] = pluginId;
        args[1] = flowId;
        args[2] = accountId;
        args[3] = DateUtil.getTimestamp();
        args[4] = content;

        int[] types = new int[5];
        types[0] = Types.VARCHAR;
        types[1] = Types.VARCHAR;
        types[2] = Types.VARCHAR;
        types[3] = Types.TIMESTAMP;
        types[4] = Types.BINARY;

        getJdbcTemplate().update(SQL_INSERT, args, types);

        return pluginId;

    }

}
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
import java.util.Map;

import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.ConfigItem;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.data.dao.ConfigDao;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.FormatUtil;

public class JdbcConfigDao extends BaseJdbcDao implements ConfigDao {

    private static final String SQL_SELECT = "SELECT Id, ConfigValue, Description, ModifiedBy, ModifiedOn, IsEditable FROM NConfig ORDER BY Id ";

    private static final String SQL_SELECT_BY_ID = "SELECT Id, ConfigValue, Description, ModifiedBy, ModifiedOn, IsEditable FROM NConfig WHERE Id = ?";

    private static final String SQL_SELECT_EXISTS = "SELECT COUNT(*) FROM NConfig WHERE Id = ? ";

    private static final String SQL_SELECT_MAP = "SELECT Id, ConfigValue FROM NConfig ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NConfig ( ConfigValue, Description, ModifiedBy, ModifiedOn, IsEditable, Id ) VALUES ( ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NConfig SET ConfigValue = ?, Description = ?, ModifiedBy = ?, ModifiedOn = ?, IsEditable = ? WHERE Id = ?";

    protected final String SQL_SELECT_ARG = "SELECT Id, ServiceId, ArgKey, ArgValue FROM NServiceArg WHERE ServiceId = ? ORDER BY ArgKey  ";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NConfig WHERE Id = ?";

    private ConfigItem save(ConfigItem instance, boolean isUpdate) {

        validateObjectArg(instance, "ConfigItem");

        validateStringArg(instance.getId());

        String sql = SQL_UPDATE;
        if (!isUpdate) {

            if (exists(SQL_SELECT_EXISTS, instance.getId())) {
                throw new WinNodeException("Duplicate Id");
            }

            sql = SQL_INSERT;
        }

        // ConfigValue, Description, ModifiedBy, ModifiedOn, Id

        Object[] args = new Object[6];

        args[0] = instance.getValue();
        args[1] = instance.getDescription();
        args[2] = instance.getModifiedById();
        args[3] = DateUtil.getTimestamp();
        args[4] = FormatUtil.toYNFromBoolean(instance.isEditable());
        args[5] = instance.getId();

        for (int i = 0; i < args.length; i++) {
            validateObjectArg(args[i], "Object");
        }

        printourArgs(args);

        getJdbcTemplate().update(sql, args);

        return instance;

    }

    /**
     * save
     */
    public ConfigItem insert(ConfigItem instance) {

        return save(instance, false);
    }

    /**
     * update
     */
    public void update(ConfigItem instance) {
        save(instance, true);
    }

    /**
     * delete
     */
    public void delete(String id) {
        validateStringArg(id);
        delete(SQL_DELETE, id);
    }

    /**
     * get
     */
    public List get() {

        return getJdbcTemplate().query(SQL_SELECT, new ConfigItemMapper());

    }

    public ConfigItem get(String id) {

        return (ConfigItem) queryForObject(SQL_SELECT_BY_ID,
                new String[] { id }, new ConfigItemMapper());
    }

    public Map<String, String> getKeyValueMap(boolean upperKey) {

        return getMap(SQL_SELECT_MAP, upperKey);

    }

    private class ConfigItemMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            ConfigItem obj = new ConfigItem();

            obj.setId(rs.getString("Id"));
            obj.setValue(rs.getString("ConfigValue"));
            obj.setDescription(rs.getString("Description"));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setEditable(FormatUtil.toBooleanFromYN(rs
                    .getString("IsEditable")));

            return obj;

        }

    }

}
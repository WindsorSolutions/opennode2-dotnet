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

import java.net.MalformedURLException;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.service.helper.NodePartnerProvider;
import com.windsor.node.util.DateUtil;

public class JdbcPartnerDao extends BaseJdbcDao implements PartnerDao,
        NodePartnerProvider {

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, Name, Url, ModifiedBy, ModifiedOn, Version FROM NPartner  ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_ALL = SQL_SELECT + " ORDER BY Name ";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    private static final String SQL_SELECT_URL = SQL_SELECT
            + " WHERE UPPER(Url) = ? ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NPartner ( Name, Url, ModifiedBy, ModifiedOn, Version, Id ) VALUES ( ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NPartner SET Name = ?, Url = ?, ModifiedBy = ?, ModifiedOn = ?, Version = ? WHERE Id = ? ";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NPartner WHERE Id = ?";

    /**
     * get
     */
    public PartnerIdentity get(String id) {

        validateStringArg(id);

        return (PartnerIdentity) queryForObject(SQL_SELECT_ID,
                new Object[] { id }, new PartnerMapper());
    }

    public PartnerIdentity getByUrl(String url) {

        validateStringArg(url);

        return (PartnerIdentity) queryForObject(SQL_SELECT_URL,
                new Object[] { url.toUpperCase() }, new PartnerMapper());

    }

    public PartnerIdentity saveIfNew(PartnerIdentity instance) {

        validateObjectArg(instance, "PartnerIdentity");

        String partnerUrl = instance.getUrl().toString().toUpperCase();
        logger.debug("URL: " + partnerUrl);

        PartnerIdentity partner = (PartnerIdentity) queryForObject(
                SQL_SELECT_URL, new Object[] { partnerUrl },
                new PartnerMapper());

        if (partner == null) {
            logger.debug("URL not found, saving...");
            partner = save(instance);
        } else {
            logger.debug("URL already in the system...");
        }

        return partner;

    }

    /**
     * save
     */
    public PartnerIdentity save(PartnerIdentity instance) {

        validateObjectArg(instance, "PartnerIdentity");

        String sql = SQL_UPDATE;

        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        // Name, Url, IsProduction, ModifiedBy, ModifiedOn, Id

        Object[] args = new Object[6];

        args[0] = instance.getName();
        args[1] = instance.getUrl().toString();
        args[2] = instance.getModifiedById();
        args[3] = DateUtil.getTimestamp();
        args[4] = instance.getVersion().getName();
        args[5] = instance.getId();

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
     * get
     */
    public List get() {
        return getJdbcTemplate().query(SQL_SELECT_ALL, new PartnerMapper());
    }

    /**
     * PartnerMapper
     * 
     * @author mchmarny
     * 
     */
    private class PartnerMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            PartnerIdentity obj = new PartnerIdentity();

            try {
                obj.setId(rs.getString("Id"));
                obj.setName(rs.getString("Name"));
                obj.setUrl(new URL(rs.getString("Url")));
                obj.setModifiedById(rs.getString("ModifiedBy"));
                obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
                obj.setVersion((EndpointVersionType) EndpointVersionType
                        .getEnumMap().get(rs.getString("Version")));
            } catch (MalformedURLException mue) {
                throw new SQLException(
                        "Url format error. How did it get intot he Db?");
            }

            return obj;

        }
    }

}
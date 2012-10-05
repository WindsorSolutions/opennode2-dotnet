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

import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.data.dao.UserAccessPolicyDao;
import com.windsor.node.util.FormatUtil;

public class JdbcUserAccessPolicyDao extends BaseJdbcDao implements
        UserAccessPolicyDao {

    protected static final String WHERE_ID = "WHERE Id = ? ";
    protected static final String SQL = "SQL: ";

    /**
     * Base SQL SELECT statement
     */
    protected static final String SQL_SELECT = "SELECT * FROM NAccountPolicy ";

    /**
     * SQL statement for selecting by UserAccessPolicy Id
     */
    protected static final String SQL_SELECT_BY_ID = SQL_SELECT + WHERE_ID;

    /**
     * SQL statement for selecting by AccountId
     */
    protected static final String SQL_SELECT_BY_ACCOUNT_ID = SQL_SELECT
            + "WHERE AccountId = ?";

    /**
     * Base SQL DELETE statement
     */
    protected static final String SQL_DELETE = "DELETE FROM NAccountPolicy ";

    /**
     * SQL statement for deleting by UserAccessPolicy Id
     */
    protected static final String SQL_DELETE_BY_ID = SQL_DELETE + WHERE_ID;

    /**
     * SQL statement for deleting by UserAccessPolicy Id
     */
    protected static final String SQL_DELETE_BY_ACCOUNT_ID = SQL_DELETE
            + "WHERE AccountId = ? ";

    /**
     * SQL INSERT statement for this table
     */
    protected static final String SQL_INSERT = "INSERT INTO NAccountPolicy "
            + "(AccountId, PolicyType, Qualifier, IsAllowed, ModifiedBy, ModifiedOn, Id) "
            + "VALUES ( ?, ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NAccountPolicy SET  AccountId= ?, "
            + "PolicyType = ?, Qualifier = ?, IsAllowed = ?, ModifiedBy = ?, ModifiedOn = ? WHERE Id = ?";

    public UserAccessPolicy get(String id) {
        validateStringArg(id);
        logger.debug("Retrieving UserAccessPolicy with id=" + id);
        logger.debug(SQL + SQL_SELECT_BY_ID);
        return (UserAccessPolicy) queryForObject(SQL_SELECT_BY_ID,
                new Object[] { id }, new UserAccessPolicyMapper());
    }

    @SuppressWarnings("unchecked")
    public List<UserAccessPolicy> getByUserAccountId(String accountId) {
        validateStringArg(accountId);
        logger.debug("Getting UserAccessPolicies for AccountId: " + accountId);
        return (List<UserAccessPolicy>) getJdbcTemplate().query(
                SQL_SELECT_BY_ACCOUNT_ID, new Object[] { accountId },
                new UserAccessPolicyMapper());
    }

    public UserAccessPolicy save(UserAccessPolicy instance) {
        logger.debug("Validating UserAccessPolicy instance");
        validateObjectArg(instance, "UserAccessPolicy");

        String sql = SQL_UPDATE;

        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        logger.debug(SQL + sql);

        Object[] args = new Object[] { instance.getAccountId(),
                instance.getPolicyType().getType(),
                instance.getTypeQualifier(),
                FormatUtil.toYNFromBoolean(instance.isAllowed()),
                instance.getModifiedById(), instance.getModifiedOn(),
                instance.getId() };

        logger.debug("Saving UserAccessPolicy");
        printourArgs(args);
        getJdbcTemplate().update(sql, args);
        logger.debug("UserAccessPolicy saved");

        return get(instance.getId());
    }

    public void delete(String id) {
        validateStringArg(id);
        logger.debug("Deleting UserAccessPolicy with id=" + id);
        logger.debug(SQL + SQL_DELETE_BY_ID);
        delete(SQL_DELETE_BY_ID, id);
    }

    public void deletePoliciesByAccountId(String accountId) {
        validateStringArg(accountId);
        logger.debug("Deleting UserAccessPolicies with AccountId=" + accountId);
        logger.debug(SQL + SQL_DELETE_BY_ACCOUNT_ID);
        delete(SQL_DELETE_BY_ACCOUNT_ID, accountId);
    }

    private class UserAccessPolicyMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            UserAccessPolicy obj = new UserAccessPolicy();
            obj.setId(rs.getString("Id"));
            obj.setAccountId(rs.getString("AccountId"));
            obj
                    .setPolicyType(ServiceRequestAuthorizationType.valueOf(rs.getString("PolicyType")));
            obj.setTypeQualifier(rs.getString("Qualifier"));
            obj.setAllowed(FormatUtil
                    .toBooleanFromYN(rs.getString("IsAllowed")));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));

            logger.debug("UserAccessPolicyMapper: " + obj);

            return obj;

        }
    }
}
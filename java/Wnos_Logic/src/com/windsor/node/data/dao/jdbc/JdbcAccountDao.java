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
import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.domain.UserAccessPolicy;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.FormatUtil;

public class JdbcAccountDao extends BaseJdbcDao implements AccountDao {

    private static final String SQL_SELECT = "SELECT Id, NAASAccount, IsActive, "
            + "SystemRole, ModifiedBy, ModifiedOn, Affiliation FROM NAccount ";

    private static final String SQL_SELECT_ALL = SQL_SELECT
            + "WHERE IsActive = ?  ORDER BY NAASAccount ";

    private static final String SQL_SELECT_BY_ID = SQL_SELECT + "WHERE Id = ?";

    /*
     * Local Users
     */
    private static final String SQL_SELECT_BY_CODE = SQL_SELECT
            + "WHERE IsActive = ? AND ((UPPER(Affiliation) = ?) OR (SystemRole = ? OR SystemRole = ?))";

    private static final String SQL_SELECT_BY_CODE_ALL = SQL_SELECT
            + "WHERE ((UPPER(Affiliation) = ?) OR (SystemRole = ? OR SystemRole = ?))";

    private static final String SQL_SELECT_NAMES = "SELECT NAASAccount FROM NAccount "
            + "WHERE IsActive = ? ORDER BY NAASAccount ";

    private static final String SQL_SELECT_BY_NAAS = SQL_SELECT
            + "WHERE NAASAccount = ?";

    private static final String SQL_INSERT = "INSERT INTO NAccount (NAASAccount,"
            + "IsActive,SystemRole,ModifiedBy,ModifiedOn, Affiliation, Id) VALUES "
            + "(?,?,?,?,?,?,?) ";

    private static final String SQL_UPDATE = "UPDATE NAccount SET NAASAccount = ?,"
            + "IsActive = ?,SystemRole = ?,ModifiedBy = ?, "
            + "ModifiedOn = ?, Affiliation = ? WHERE Id = ?";

    private static final String SQL_DELETE = "UPDATE NAccount SET IsActive = ? WHERE Id = ?";

    private static final String SQL_SELECT_ACTIVE_ADMINS = SQL_SELECT
            + " WHERE IsActive = ? and SystemRole = ?";

    private JdbcUserAccessPolicyDao userAccessPolicyDao;

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {

        super.checkDaoConfig();

        if (userAccessPolicyDao == null) {
            throw new RuntimeException("userAccessPolicyDao Not Set");
        }
    }

    /**
     * Creates or returns an existent account
     * 
     * @param naasAccount
     * @return UserAccount
     */
    public UserAccount getOrCreateAccount(String naasAccount,
            String affiliationCode, String adminUserId) {

        logger.debug("getOrCreateAccount: " + naasAccount);
        logger.debug("getOrCreateAccount: " + affiliationCode);

        if (StringUtils.isBlank(naasAccount)) {
            throw new IllegalArgumentException("Username not provided.");
        }

        if (StringUtils.isBlank(affiliationCode)) {
            throw new IllegalArgumentException("AffiliationCode not provided.");
        }

        if (StringUtils.isBlank(adminUserId)) {
            throw new IllegalArgumentException("AdminUserId not provided.");
        }

        UserAccount account = getByNAASAccount(naasAccount);

        if (account == null) {

            account = new UserAccount();
            account.setActive(true);
            account.setModifiedById(adminUserId);
            account.setNaasUserName(naasAccount);
            account.setRole(SystemRoleType.AUTHED);
            account.setAffiliationCode(affiliationCode);

            account = save(account);

        }

        return account;

    }

    /**
     * Save account instance
     */
    public UserAccount save(UserAccount instance) {

        validateObjectArg(instance, "UserAccount");

        logger.debug("Saving UserAccount: " + instance);

        String sql = SQL_UPDATE;

        if (StringUtils.isBlank(instance.getId())) {
            logger.debug("Generating id for UserAccount");
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        logger.debug("SQL: " + sql);

        Object[] args = new Object[7];
        args[0] = instance.getNaasUserName();
        args[1] = FormatUtil.toYNFromBoolean(instance.isActive());
        args[2] = instance.getRole().getName();
        args[3] = instance.getModifiedById();
        args[4] = DateUtil.getTimestamp();
        args[5] = instance.getAffiliationCode();
        args[6] = instance.getId();

        printourArgs(args);

        getJdbcTemplate().update(sql, args);

        logger.debug("Account saved");

        // First cleanup all old policies
        logger.debug("Deleting policies");
        userAccessPolicyDao.deletePoliciesByAccountId(instance.getId());

        // then, if we have some, add them to the user
        if (null != instance.getPolicies()) {

            List policyList = instance.getPolicies();
            Iterator i = policyList.iterator();

            while (i.hasNext()) {

                UserAccessPolicy policy = (UserAccessPolicy) i.next();

                logger.debug("Saving policy [" + i + "]: " + policy);
                if (StringUtils.isBlank(policy.getAccountId())) {
                    policy.setAccountId(instance.getId());
                }
                userAccessPolicyDao.save(policy);

            }
            logger.debug("User Access Policies saved");

        }
        return get(instance.getId());

    }

    /**
     * get account by id
     */
    public UserAccount get(String id) {

        validateStringArg(id);

        return (UserAccount) queryForObject(SQL_SELECT_BY_ID,
                new Object[] { id }, new UserAccountMapper(true));

    }

    /**
     * getNames
     */
    public String[] getNames() {
        return (String[]) getArray(SQL_SELECT_NAMES, FormatUtil.YES);
    }

    /**
     * get list of all users
     */
    public List get(boolean includeInactive, boolean loadPolicies) {

        if (includeInactive) {
            return getJdbcTemplate().query(SQL_SELECT,
                    new UserAccountMapper(loadPolicies));
        } else {
            return getJdbcTemplate().query(SQL_SELECT_ALL,
                    new Object[] { FormatUtil.YES },
                    new UserAccountMapper(loadPolicies));
        }

    }

    public List get(String code, boolean includeInactive) {

        validateStringArg(code);

        logger.debug("Looking for NAAS Account: " + code);

        if (includeInactive) {
            return getJdbcTemplate().query(
                    SQL_SELECT_BY_CODE_ALL,
                    new Object[] { code.toUpperCase(),
                            SystemRoleType.ADMIN.getName(),
                            SystemRoleType.PROGRAM.getName() },
                    new UserAccountMapper(true));

        } else {
            return getJdbcTemplate().query(
                    SQL_SELECT_BY_CODE,
                    new Object[] { FormatUtil.YES, code.toUpperCase(),
                            SystemRoleType.ADMIN.getName(),
                            SystemRoleType.PROGRAM.getName() },
                    new UserAccountMapper(true));

        }

    }

    /**
     * get account by naas username
     */
    public UserAccount getByNAASAccount(String naasAccount) {

        validateStringArg(naasAccount);

        logger.debug("Looking for NAAS Account: " + naasAccount);

        UserAccount account = (UserAccount) queryForObject(SQL_SELECT_BY_NAAS,
                new Object[] { naasAccount }, new UserAccountMapper(true));

        logger.debug("Retrieved UserAccount: " + account);

        return account;
    }

    /**
     * delete particular account
     */
    public void delete(String id) {

        validateStringArg(id);

        logger.debug("Inactivating account: " + id);

        getJdbcTemplate()
                .update(SQL_DELETE, new Object[] { FormatUtil.NO, id });

    }

    private class UserAccountMapper implements RowMapper {

        private final boolean loadPolicies;

        public UserAccountMapper(boolean loadPolicies) {
            this.loadPolicies = loadPolicies;
        }

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            UserAccount obj = new UserAccount();
            String accountId = rs.getString("Id");
            obj.setId(accountId);
            obj.setNaasUserName(rs.getString("NAASAccount"));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setAffiliationCode(rs.getString("Affiliation"));
            obj.setRole((SystemRoleType) SystemRoleType.getEnumMap().get(
                    rs.getString("SystemRole")));
            obj.setActive(FormatUtil.toBooleanFromYN(rs.getString("IsActive")));

            if (loadPolicies) {
                obj.setPolicies(userAccessPolicyDao
                        .getByUserAccountId(accountId));
            }
            logger.debug("UserAccountMapper: " + obj);

            return obj;

        }
    }

    public void setUserAccessPolicyDao(JdbcUserAccessPolicyDao policyDao) {
        this.userAccessPolicyDao = policyDao;
    }

    /**
     * Get a list of active administrators, protected because this just supports
     * testing.
     * 
     * @return a list of UserAccounts representing active administrators
     */
    protected List getActiveAdmins() {

        List activeAdmins = getJdbcTemplate()
                .query(
                        SQL_SELECT_ACTIVE_ADMINS,
                        new Object[] { FormatUtil.YES,
                                SystemRoleType.ADMIN.getName() },
                        new UserAccountMapper(false));

        return activeAdmins;
    }

}

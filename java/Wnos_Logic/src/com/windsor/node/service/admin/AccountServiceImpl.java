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

package com.windsor.node.service.admin;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.AuthenticationRequest;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.data.dao.UserAccessPolicyDao;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.helper.AuthenticationHelper;
import com.windsor.node.service.helper.NotificationHelper;
import com.windsor.node.service.helper.UserManagerHelper;
import com.windsor.node.util.IpValidator;
import com.windsor.node.util.PasswordUtil;

public class AccountServiceImpl extends BaseService implements AccountService,
        InitializingBean {

    private NotificationHelper notificationHelper;
    private AuthenticationHelper authenticationHelper;
    private UserManagerHelper userManagerHelper;
    private UserAccessPolicyDao policyDao;

    /**
     * Make sure the helpers are set
     */
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper Not Set");
        }

        if (authenticationHelper == null) {
            throw new RuntimeException("NAASAuthenticationHelper Not Set");
        }

        if (userManagerHelper == null) {
            throw new RuntimeException("NAASManagerHelper Not Set");
        }

    }

    /**
     * getLocalNodeId
     */
    public String getLocalNodeId() {
        return getNaasConfig().getNodeId();
    }

    /**
     * adminAuthenticate
     */
    public NodeVisit adminAuthenticate(AuthenticationRequest request) {

        // These first validations are bug prevention.
        // no point hiding it if there is a problem

        if (request == null) {
            throw new RuntimeException("Null request");
        }

        if (StringUtils.isBlank(request.getIp())) {
            throw new RuntimeException("Null ip");
        }

        NodeVisit visit = null;

        Activity logEntry = new Activity();
        logEntry.setModifiedById(getAdminAccount().getId());
        logEntry.setIp(request.getIp());
        logEntry.setType(ActivityType.AdminAuth);

        try {

            if (StringUtils.isBlank(request.getPassword())) {
                throw new IllegalArgumentException("Password not provided.");
            }

            if (StringUtils.isBlank(request.getUsername())) {
                throw new IllegalArgumentException("Username not provided.");
            }

            // If there is a white list make sure the call is from the white
            // list. If there is no white list just move on

            logger.debug("Whitelist: " + getNosConfig().getAdminWhiteList());

            if (getNosConfig().getAdminWhiteList() != null
                    && getNosConfig().getAdminWhiteList().size() > 0) {

                if (!IpValidator.contains(getNosConfig().getAdminWhiteList(),
                        request.getIp())) {

                    throw new IllegalArgumentException(
                            "Request initiated from an IP address that does "
                                    + "not appear on the Node Admin whitelist.");
                }
            }

            logEntry.addEntry("Authentication attempt by: {0}",
                    new Object[] { request.getUsername() });

            // NAAS Auth
            String naasToken = authenticationHelper.authenticateUser(request
                    .getUsername(), request.getPassword(), request.getIp());

            if (StringUtils.isBlank(naasToken)) {
                throw new RuntimeException("Empty token");
            }

            // When authed from admin we do not create accounts, but rather make
            // sure the use has the nessary rights (program or better)
            UserAccount account = getActiveAdminUser(request.getUsername());

            if (account == null) {
                throw new RuntimeException("Uknown user");
            }

            logEntry.setModifiedById(account.getId());

            visit = new NodeVisit(account, request.getIp());

            logEntry.addEntry("Result: Success");

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.setType(ActivityType.Error);
            logEntry.addEntry("Error while authenticating: " + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);

        }

        return visit;
    }

    /**
     * Create a user account.
     * 
     * @param accountRequest
     * @param visit
     * @return
     */
    public UserAccount save(UserAccount accountRequest, NodeVisit visit) {

        if (accountRequest == null) {
            throw new IllegalArgumentException(
                    "AccountRequest argument not provided.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        logger.debug("Account to create: " + accountRequest);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        UserAccount account = null;
        String password = null;
        String username = accountRequest.getNaasUserName().toLowerCase();

        boolean accountCreatedInNaas = false;

        try {

            logEntry.addEntry("{0} attempted to create new account {1}.",
                    new Object[] { visit.getUserAccount().getNaasUserName(),
                            accountRequest });

            logger.debug("Checking if user exists in local DB.");
            account = getAccountDao().getByNAASAccount(username);
            logger.debug("Db Account: " + account);

            if (account != null) {
                logEntry.addEntry("Account {0} was already in Db: {1}.",
                        new Object[] { username, account });

                if (!account.getAffiliationCode().equals(
                        getNaasConfig().getNodeId())) {
                    logEntry
                            .addEntry("Account not affiliated with the local Node.");
                    throw new RuntimeException(
                            "User already exists in NAAS and affiliated with: "
                                    + account.getAffiliationCode());
                } else {
                    logEntry
                            .addEntry("Attempting to create a duplicate account.");
                    throw new RuntimeException("Account already exists");
                }
            }

            logEntry.addEntry("Account {0} was not in local Db: {1}.",
                    new Object[] { username, account });

            logger.debug("Preparing to create account in NAAS.");
            password = PasswordUtil.getRandomNAASPassword();

            logger.debug("Creating new account in Naas: " + username);
            userManagerHelper.addUser(username, password);
            accountCreatedInNaas = true;

            logEntry.addEntry("Account {0} was created in NAAS",
                    new Object[] { username });

            logger.debug("Creating new local account: " + accountRequest);

            account = new UserAccount();
            account.setActive(true);
            account.setModifiedById(getAdminVisit().getUserAccount().getId());
            account.setNaasUserName(username);
            account.setAffiliationCode(getNaasConfig().getNodeId());
            account.setRole(accountRequest.getRole());
            account = getAccountDao().save(account); // Will returned the
            // DB

            // values
            logger.debug("Local account saved: " + account);

            logEntry.addEntry("Account {0} was created in local data store.",
                    new Object[] { account.getNaasUserName() });

            if (accountRequest.getRole().equals(SystemRoleType.Program)
                    || accountRequest.getRole().equals(SystemRoleType.Admin)) {

                notificationHelper.sendNewLocalUser(account, password);
            }

        } catch (Exception ex) {

            logger.error(ex);

            String mesg = ex.getMessage();
            logEntry.addEntry(mesg);
            logEntry.setType(ActivityType.Error);

            if (accountCreatedInNaas) {
                try {

                    logger.error("Attempting to delete user from NAAS.");
                    userManagerHelper.deleteUser(username);

                    logEntry.addEntry("Account {0} was deleted from NAAS.",
                            new Object[] { username });

                } catch (Exception delNAASEx) {

                    logEntry.addEntry(delNAASEx.getMessage());
                }
            }

            throw new RuntimeException("Error while creating account: " + mesg);

        } finally {

            getActivityDao().make(logEntry);
        }

        return account;

    }

    /**
     * Update a user account.
     * 
     * @param instance
     * @param visit
     */
    public void update(UserAccount instance, NodeVisit visit) {

        logger.debug("Updating user account: " + instance);

        if (instance == null) {
            throw new IllegalArgumentException(
                    "Authentication Credentials not provided.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        instance.setModifiedById(visit.getUserAccount().getId());

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            UserAccount testAccount = getAccountDao().get(instance.getId());

            if (testAccount == null) {
                throw new RuntimeException("User does not exist in local Db.");
            }

            instance = getAccountDao().save(instance);

            logEntry.addEntry("{0} updated account {1}.", new Object[] {
                    visit.getUserAccount().getNaasUserName(),
                    instance.getNaasUserName() });

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while updating account: "
                    + ex.getMessage());

            throw new RuntimeException("Error while updating account: "
                    + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * @see com.windsor.node.common.service.admin.AccountService#delete(com.windsor.node.common.domain.UserAccount,
     *      com.windsor.node.common.domain.NodeVisit)
     */
    public void delete(UserAccount account, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        if (StringUtils.isBlank(account.getId())) {
            throw new RuntimeException("User not present in local database.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to delete account {1}.",
                    new Object[] { visit.getUserAccount().getNaasUserName(),
                            account.getNaasUserName() });

            if (!account.getAffiliationCode().equals(
                    getNaasConfig().getNodeId())) {

                throw new RuntimeException("Account is affiliated "
                        + "with another Node. Accounts can be deleted "
                        + "only by their owner.");
            }

            // NAAS
            logEntry.addEntry("Attempting to delete account from NAAS.");
            logger.debug("Attempting to delete account from NAAS");
            userManagerHelper.deleteUser(account.getNaasUserName());

            logEntry.addEntry("Account deleted from NAAS.");

            // DB
            logger.debug("Attempting to delete account from DB");
            getAccountDao().delete(account.getId());
            logEntry.addEntry("Account deleted from DB.");

        } catch (Exception naasEx) {
            logger.error(naasEx);
            throw new RuntimeException("Error while deleting from DB: "
                    + naasEx.getMessage());
        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * @see com.windsor.node.common.service.admin.AccountService#resetPassword(com.windsor.node.common.domain.UserAccount,
     *      com.windsor.node.common.domain.NodeVisit)
     */
    public void resetPassword(UserAccount instance, NodeVisit visit) {

        if (instance == null) {
            throw new IllegalArgumentException(
                    "AuthenticationCredentials argument not provided.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry
                    .addEntry("{0} attempted to reset password for {1}.",
                            new Object[] { visit.getName(),
                                    instance.getNaasUserName() });

            validateByRole(visit, SystemRoleType.Admin);

            if (!instance.getAffiliationCode().equals(
                    getNaasConfig().getNodeId())) {

                throw new RuntimeException("Account is affiliated "
                        + "with another Node. Accounts can be modified "
                        + "only by their owner.");
            }

            String newPassword = userManagerHelper.resetPassword(instance
                    .getNaasUserName());

            notificationHelper.sendNewPassword(instance, newPassword);

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while changing password: "
                    + ex.getMessage());

            throw new RuntimeException("Error while changing password: "
                    + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * resetPassword
     */
    public void resetPassword(String currentPassword, String newPassword,
            NodeVisit visit) {

        if (StringUtils.isBlank(currentPassword)) {
            throw new IllegalArgumentException("Null current password");
        }

        if (StringUtils.isBlank(newPassword)) {
            throw new IllegalArgumentException("Null new password");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to change password.",
                    new Object[] { visit.getName() });

            validateByRole(visit, SystemRoleType.Program);

            userManagerHelper.changePassword(visit.getName(), currentPassword,
                    newPassword);

            notificationHelper.sendNewPassword(visit.getUserAccount(),
                    newPassword);

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while changing password: "
                    + ex.getMessage());

            throw new RuntimeException("Error while changing password: "
                    + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * changePassword
     */
    public void changePassword(String currentPassword, String newPassword,
            AuthenticationRequest instance, NodeVisit visit) {

        if (instance == null) {
            throw new IllegalArgumentException(
                    "AuthenticationCredentials not provided.");
        }

        if (currentPassword == null || newPassword == null
                || currentPassword == newPassword) {
            throw new IllegalArgumentException(
                    "Old & new passwords not provided or the same.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to change NAAS password for {1}",
                    new Object[] { visit.getUserAccount().getNaasUserName(),
                            instance.getUsername() });

            userManagerHelper.changePassword(instance.getUsername(),
                    currentPassword, newPassword);

        } catch (Exception ex) {

            logger.error(ex);

            throw new WinNodeException("Error while changing password: "
                    + ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * @see com.windsor.node.common.service.admin.AccountService#getByAccountId(java.lang.String,
     *      com.windsor.node.common.domain.NodeVisit)
     */
    public UserAccount getByAccountId(String accountId, NodeVisit visit) {

        if (accountId == null) {
            throw new IllegalArgumentException("AccountId not provided.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);
        logger.debug("Getting account for: " + accountId);
        return getAccountDao().get(accountId);
    }

    public UserAccount getByUserName(String username, NodeVisit visit) {

        UserAccount account = null;

        if (username == null) {
            throw new IllegalArgumentException(
                    "username argument not provided.");
        }

        validateByRole(visit, SystemRoleType.Program);
        logger.debug("Getting account for: " + username);
        account = getAccountDao().getByNAASAccount(username);
        logger.debug("Retrieved UserAccount: " + account);

        return account;
    }

    public UserAccount getActiveAdminUser(String username) {

        if (username == null) {
            throw new IllegalArgumentException(
                    "username argument not provided.");
        }

        logger.debug("Getting account for: " + username);
        UserAccount user = getAccountDao().getByNAASAccount(username);

        validateByRole(user, SystemRoleType.Program);

        if (!user.isActive()) {
            throw new RuntimeException("User inactive");
        }

        return user;
    }

    /**
     * get
     */
    public List getLocalUsers(boolean includeInactive, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);
        logger.debug("Getting account list");
        return getAccountDao()
                .get(getNaasConfig().getNodeId(), includeInactive);
    }

    /**
     * getNAASUserNames
     */
    public String[] getNAASUserNames(NodeVisit visit) {
        validateByRole(visit, SystemRoleType.Admin);
        logger.debug("Getting naas name list");
        return getAccountDao().getNames();
    }

    public String[] getActiveUsernames(NodeVisit visit) {
        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);
        logger.debug("Getting naas account name list");
        return getAccountDao().getNames();
    }

    /**
     * getNAASUsers
     */
    public List getNAASUsers(NodeVisit visit) {
        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);
        logger.debug("Getting naas account list");
        return getAccountDao().get(getNaasConfig().getNodeId(), false);
    }

    /**
     * setSimpleNAASPolicies
     */
    public void setSimpleNAASPolicies(String username, List policies,
            NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {
            logEntry.addEntry("{0} attempted to set simple NAAS policy {1}.",
                    new Object[] { visit.getUserAccount().getNaasUserName(),
                            username });

            // This will make sure the account exists
            UserAccount account = getOrCreateAccount(username, visit);

            logger.debug("Attempted to set simple NAAS policy");
            policyDao.deletePoliciesByAccountId(account.getId());

            for (int i = 0; i < policies.size(); i++) {

                UserAccessPolicy policy = (UserAccessPolicy) policies.get(i);

                logger.debug("Policy: " + policy);

                logEntry.addEntry("Policy: {0} ({1}).", new Object[] {
                        policy.getPolicyType().getName(),
                        policy.getTypeQualifier() });

                policyDao.save(policy);
            }

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while creating policy in NAAS: "
                    + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public void validateAccess(UserAccount account, String flowId) {

        logger.debug("account: " + account);
        logger.debug("flowId: " + flowId);

        if (account == null) {
            throw new RuntimeException(
                    "Unable to create local account instance.");
        }

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException(
                    "Null flowCode. No need to validate policy");
        }

        if (!account.isActive()) {
            throw new RuntimeException("User inactive.");
        }

        // Validate the flow grant if the flow is not null
        if (StringUtils.isNotBlank(flowId)) {

            List userPolicies = policyDao.getByUserAccountId(account.getId());

            boolean hasGrantPolicy = false;
            for (int i = 0; i < userPolicies.size(); i++) {

                UserAccessPolicy policy = (UserAccessPolicy) userPolicies
                        .get(i);

                if (policy.getPolicyType() == ServiceRequestAuthorizationType.FLOW
                        && policy.getTypeQualifier().equalsIgnoreCase(flowId)
                        && policy.isAllowed()) {
                    hasGrantPolicy = true;
                    break;
                }
            }

            if (!hasGrantPolicy) {
                throw new RuntimeException(
                        "User has not been granted access to this flow.");
            } else {

                logger.debug("Access granted.");
            }

        }

    }

    /**
     * setNAASPolicy
     */
    public void setNAASPolicy(String username, UserAccessPolicy policy,
            NodeVisit visit) {

        List policies = new ArrayList();
        policies.add(policy);

        setSimpleNAASPolicies(username, policies, visit);

    }

    /**
     * getOrCreateAccount
     */
    public UserAccount getOrCreateAccount(String naasAccount, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        return getAccountDao().getOrCreateAccount(naasAccount,
                getNaasConfig().getNodeId(), getAdminAccount().getId());

    }

    public void setNotificationHelper(NotificationHelper notificationHelper) {
        this.notificationHelper = notificationHelper;
    }

    public void setAuthenticationHelper(
            AuthenticationHelper authenticationHelper) {
        this.authenticationHelper = authenticationHelper;
    }

    public void setUserManagerHelper(UserManagerHelper userManagerHelper) {
        this.userManagerHelper = userManagerHelper;
    }

    public void setPolicyDao(UserAccessPolicyDao policyDao) {
        this.policyDao = policyDao;
    }

}
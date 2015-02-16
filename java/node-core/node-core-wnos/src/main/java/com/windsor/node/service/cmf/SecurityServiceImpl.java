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

package com.windsor.node.service.cmf;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.EndpointAuthenticationRequest;
import com.windsor.node.common.domain.EndpointTokenValidationRequest;
import com.windsor.node.common.domain.EndpointVisit;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.cmf.SecurityService;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.admin.AccountServiceImpl;
import com.windsor.node.service.helper.AuthenticationHelper;

public class SecurityServiceImpl extends BaseService implements
        SecurityService, InitializingBean {

    public final Logger logger = LoggerFactory.getLogger(this.getClass());
    private AccountServiceImpl accountService;
    private AuthenticationHelper authenticationHelper;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (accountService == null) {
            throw new RuntimeException("AccountService Not Set");
        }

        if (authenticationHelper == null) {
            throw new RuntimeException("NAASAuthenticationHelper Not Set");
        }

    }

    /**
     * endpointAuthenticate
     */
    public EndpointVisit endpointAuthenticate(
            EndpointAuthenticationRequest request) {

        EndpointVisit visit = null;

        // These first validations are bug prevention.
        // no point hiding it if there is a problem
        if (request == null) {
            throw new RuntimeException("Null request");
        }

        if (StringUtils.isBlank(request.getIp())) {
            throw new RuntimeException("Null ip");
        }

        Activity logEntry = makeNewActivity(ActivityType.ServiceAuth, request
                .getIp());

        try {

            logger.debug("Authenticating: " + request);

            String token = authenticationHelper.authenticateUser(request
                    .getUsername(), request.getPassword(), request
                    .getAuthTypeOrDomain(), request.getIp());

            if (StringUtils.isBlank(token)) {
                throw new IllegalArgumentException(
                        "Authentication did not return token or error.");
            }

            logger.debug("getOrCreateAccount: " + request.getUsername());

            // In case the NAAS sync is out of sync we want to create the
            // account
            // with a default Node id, so that later, we can fix it with the
            // real affiliation
            UserAccount userAccount = getAccountDao().getOrCreateAccount(
                    request.getUsername(), NAASConfig.DEFAULT_NODE_ID,
                    getAdminAccount().getId());

            if (userAccount == null) {
                throw new RuntimeException("Unable to get a local account.");
            }

            visit = new EndpointVisit(token);
            visit.setEndpointVersion(request.getEndpointVersion());
            visit.setIp(request.getIp());
            visit.setUserAccount(userAccount);

            logEntry.setModifiedById(userAccount.getId());
            logEntry.addEntry("Authentication attempt from {0} by {1}.",
                    new Object[] { request.getIp(), request.getUsername() });
            logEntry.addEntry("Result token {0}.", new Object[] { token });

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);

            logEntry.setType(ActivityType.Error);

            logEntry.addEntry(ex.getMessage());

            throw new RuntimeException("Error while authenticating: "
                    + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

        return visit;

    }

    /**
     * endpointValidate
     */
    public EndpointVisit endpointValidate(EndpointTokenValidationRequest request) {

        // These first validations are bug prevention.
        // no point hiding it if there is a problem

        if (request == null) {
            throw new RuntimeException("Null request");
        }

        if (StringUtils.isBlank(request.getIp())) {
            throw new RuntimeException("Null ip");
        }

        EndpointVisit visit = null;
        visit = new EndpointVisit();
        visit.setEndpointVersion(request.getEndpointVersion());
        visit.setIp(request.getIp());

        //If the service is allowed to be anonymous, the rest is uneccesary and will cause errors
        if(request.getAnonymousVisit())
        {
            visit.setAnonymousVisit(Boolean.TRUE);
            visit.setUserAccount(getAnonymousAccount());
        }
        else
        {
            logger.debug("endpointValidate request: " + request);
            Activity logEntry = makeNewActivity(ActivityType.Audit, request.getIp());

            try
            {
                logger.debug("Validating: " + request);

                String username = authenticationHelper.validateToken(request.getToken(), request.getIp());
                if(StringUtils.isBlank(username))
                {
                    throw new IllegalArgumentException("Authentication did not return username or error.");
                }

                logger.debug("getting Db user for: " + username);

                UserAccount userAccount = getAccountDao().getOrCreateAccount(username, NAASConfig.DEFAULT_NODE_ID, getAdminAccount().getId());

                logger.debug("Db user: " + username);

                if(userAccount == null)
                {
                    throw new RuntimeException("Unable to get a local account.");
                }
                visit.setUserAccount(userAccount);

                logEntry.setModifiedById(userAccount.getId());
                logEntry.addEntry("Authentication attempt from {0} by {1}.", new Object[]{ request.getIp(), userAccount.getNaasUserName() });
                logEntry.addEntry("Result username {0}.", new Object[]{ username });
            }
            catch(Exception ex)
            {
                logger.error(ex.getMessage(), ex);
                logEntry.setType(ActivityType.Error);
                logEntry.addEntry(ex.getMessage());

                throw new RuntimeException("Error while validating: " + ex.getMessage(), ex);
            }
            finally
            {
                getActivityDao().make(logEntry);
            }
        }
        return visit;
    }

    public void setAuthenticationHelper(
            AuthenticationHelper authenticationHelper) {
        this.authenticationHelper = authenticationHelper;
    }

    public void setAccountService(AccountServiceImpl accountService) {
        this.accountService = accountService;
    }

}

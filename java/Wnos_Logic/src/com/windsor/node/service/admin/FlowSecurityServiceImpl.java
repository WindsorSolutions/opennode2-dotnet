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

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.common.domain.flowsecurity.FlowRequest;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowSecurityService;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.FlowSecurityDao;
import com.windsor.node.service.BaseService;

public class FlowSecurityServiceImpl extends BaseService implements
        FlowSecurityService, InitializingBean {

    private static final String CREATING_POLICY_FOR = "Creating policy for ";
    private static final String COULDNT_FIND_FLOW = "Couldn't find a flow by that name, ignoring.";
    private static final String LOOKING_UP_FLOW = "Looking up flow named ";
    private static final String DOESNT_EXIST_CREATING = " doesn't exist but is affiliated with this Node, creating...";

    private Logger logger = Logger.getLogger(getClass());
    private AccountService accountService;
    private FlowSecurityDao flowSecurityDao;
    private FlowDao flowDao;

    /*
     * (non-Javadoc)
     * 
     * @seecom.windsor.node.common.service.admin.FlowSecurityService#
     * getAuthorizationRequest(java.lang.String)
     */
    public AuthorizationRequest getAuthorizationRequest(String id) {

        return flowSecurityDao.getById(id);
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.common.service.admin.FlowSecurityService#acceptRequest
     * (com.windsor.node.common.domain.flowsecurity.AuthorizationRequest)
     */
    public void acceptRequest(AuthorizationRequest authReq, NodeVisit visit) {

        logger.debug("acceptRequest()");

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        String naasName = authReq.getNaasUserName();

        boolean didCreateInNaas = false;

        logger.debug(visit.getUserAccount().getNaasUserName()
                + " accepting Authorization Request for  " + naasName);

        logEntry.addEntry("{0} accepting Authorization Request for {1}",
                new Object[] { visit.getUserAccount().getNaasUserName(),
                        naasName });

        try {

            /* (1) Create account if it doesn't already exist. */
            UserAccount naasAccount = accountService.getByUserName(naasName,
                    visit);

            if (null == naasAccount) {

                if (authReq.getAffiliatedNodeId().equals(
                        getNaasConfig().getNodeId())) {

                    logger.debug(naasName + DOESNT_EXIST_CREATING);
                    logEntry.addEntry(naasName + DOESNT_EXIST_CREATING);

                    naasAccount = new UserAccount();
                    naasAccount.setNaasUserName(naasName);

                    naasAccount = accountService.save(naasAccount, visit);

                    didCreateInNaas = true;

                } else {

                    String mesg = naasName
                            + " not affiliated with this Node and not in NAAS. "
                            + "The request shouldn't have made it into the system.";
                    logger.error(mesg);
                    throw new RuntimeException(mesg);
                }
            }

            logger.debug("Using NAASAccount: " + naasAccount);

            /*
             * (2) for each requested flow, create a UserAccessPolicy, then
             * update the account.
             */
            naasAccount.setPolicies(approveFlowsForUser(naasAccount, authReq,
                    visit, logEntry));

            logger.debug("Saving new UserAccessPolicies for " + naasName);

            accountService.update(naasAccount, visit);

            /* (3) update request with approver, etc. */
            authReq.setDidCreateInNaas(didCreateInNaas);
            authReq.setAuthorizationAccountId(visit.getUserAccount().getId());
            authReq.setAuthorizationGeneratedOn(new Timestamp(System
                    .currentTimeMillis()));

            flowSecurityDao.saveAuthRequest(authReq);

        } catch (Exception ex) {

            logger.error(ex);

            logEntry.addEntry(ex.getMessage());
            logEntry.setType(ActivityType.Error);

            throw new RuntimeException(
                    "Error while accepting Authorization Request: "
                            + ex.getMessage());

        } finally {

            getActivityDao().make(logEntry);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.common.service.admin.FlowSecurityService#getPendingRequests
     * ()
     */
    public List<AuthorizationRequest> listPendingRequests() {

        return flowSecurityDao.getPendingRequests();
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.common.service.admin.FlowSecurityService#rejectRequest
     * (com.windsor.node.common.domain.flowsecurity.AuthorizationRequest)
     */
    public void rejectRequest(AuthorizationRequest authReq, NodeVisit visit) {

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        String naasName = authReq.getNaasUserName();

        logger.debug(visit.getUserAccount().getNaasUserName()
                + " rejecting Authorization Request for  " + naasName);

        logEntry.addEntry("{0} rejecting Authorization Request for {1}",
                new Object[] { visit.getUserAccount().getNaasUserName(),
                        naasName });

        try {

            authReq.setAuthorizationAccountId(visit.getUserAccount().getId());
            authReq.setAuthorizationGeneratedOn(new Timestamp(System
                    .currentTimeMillis()));

            for (FlowRequest flowReq : authReq.getRequestedFlows()) {

                flowReq.setAccessGranted(false);
            }

            flowSecurityDao.saveAuthRequest(authReq);

        } catch (Exception ex) {

            logger.error(ex);

            logEntry.addEntry(ex.getMessage());
            logEntry.setType(ActivityType.Error);

            throw new RuntimeException(
                    "Error while rejecting Authorization Request: "
                            + ex.getMessage());

        } finally {

            getActivityDao().make(logEntry);
        }

    }

    private List<UserAccessPolicy> approveFlowsForUser(UserAccount naasAccount,
            AuthorizationRequest authReq, NodeVisit visit, Activity logEntry) {

        List<UserAccessPolicy> assignedPolicies = new ArrayList<UserAccessPolicy>(
                authReq.getRequestedFlows().size());

        logger.debug("Creating UserAccessPolicies for approved flows...");

        for (FlowRequest flowReq : authReq.getRequestedFlows()) {

            if (flowReq.isAccessGranted()) {

                String flowName = flowReq.getFlowName();

                logger.debug(LOOKING_UP_FLOW + flowName);
                logEntry.addEntry(LOOKING_UP_FLOW + flowName);

                DataFlow flow = flowDao.getByCode(flowName);

                if (null == flow) {

                    logger.debug(COULDNT_FIND_FLOW);
                    logEntry.addEntry(COULDNT_FIND_FLOW);

                } else {
                    logger.debug(CREATING_POLICY_FOR + flow.getName());
                    logEntry.addEntry(CREATING_POLICY_FOR + flow.getName());
                    UserAccessPolicy policy = new UserAccessPolicy();

                    policy.setAccountId(naasAccount.getId());
                    policy.setAllowed(true);
                    policy.setPolicyType(ServiceRequestAuthorizationType.FLOW);
                    policy.setTypeQualifier(flow.getId());
                    policy.setModifiedById(visit.getUserAccount().getId());

                    assignedPolicies.add(policy);
                }
            }
        }

        return assignedPolicies;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * org.springframework.beans.factory.InitializingBean#afterPropertiesSet()
     */
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (null == flowSecurityDao) {
            throw new RuntimeException("flowSecurityDao cannot be null.");
        }

        if (null == flowDao) {
            throw new RuntimeException("flowDao cannot be null.");
        }

        if (null == accountService) {
            throw new RuntimeException("accountService cannot be null.");
        }
    }

    public FlowSecurityDao getFlowSecurityDao() {
        return flowSecurityDao;
    }

    public void setFlowSecurityDao(FlowSecurityDao flowSecurityDao) {
        this.flowSecurityDao = flowSecurityDao;
    }

    public FlowDao getFlowDao() {
        return flowDao;
    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public AccountService getAccountService() {
        return accountService;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

}

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

package com.windsor.node.plugin.flowsecurity;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;

/**
 * @author jniski
 * 
 */
public class AuthorizedUserListHelper {

    private AccountDao accountDao;
    private FlowDao flowDao;

    protected List<AuthorizedUser> getAuthorizedUserList(String nodeId) {

        List<DataFlow> unsecuredFlows = flowDao.getUnsecuredFlows();

        List<UserAccount> users = accountDao.get(nodeId, false);
        List<AuthorizedUser> authedUsers = new ArrayList<AuthorizedUser>();

        for (UserAccount user : users) {

            AuthorizedUser authedUser = new AuthorizedUser();
            authedUser.setNAASUserName(user.getNaasUserName());

            List<String> userFlowNames = new ArrayList<String>(unsecuredFlows
                    .size());

            for (DataFlow flow : unsecuredFlows) {
                userFlowNames.add(flow.getName());
            }

            for (UserAccessPolicy policy : user.getPolicies()) {

                if (policy.getPolicyType().equals(
                        ServiceRequestAuthorizationType.Flow)) {

                    DataFlow authedFlow = flowDao
                            .get(policy.getTypeQualifier());
                    userFlowNames.add(authedFlow.getName());
                }
            }

            authedUser.setAuthorizedFlowNames(userFlowNames);
            authedUsers.add(authedUser);

        }

        return authedUsers;
    }

    protected AccountDao getAccountDao() {
        return accountDao;
    }

    protected void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

    protected FlowDao getFlowDao() {
        return flowDao;
    }

    protected void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }
}

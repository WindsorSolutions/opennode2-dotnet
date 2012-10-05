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

package com.windsor.node.common.service.admin;

/* TODO: this appears to be an unimplemented interface! */

import java.util.List;

import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;

public interface PolicyService {

    /**
     * getNaasUsernameList
     * 
     * @param forceFreshFromNaas
     * @param visit
     * @return
     */
    List getNaasUsernameList(boolean forceFreshFromNaas, NodeVisit visit);

    /**
     * getOrCreateUser
     * 
     * @param username
     * @param visit
     * @return
     */
    UserAccount getOrCreateUser(String username, NodeVisit visit);

    /**
     * resetPolicies
     * 
     * @param userId
     * @param visit
     */
    void resetPolicies(String userId, NodeVisit visit);

    /**
     * save
     * 
     * @param user
     * @param visit
     * @return
     */
    UserAccount save(UserAccount user, NodeVisit visit);

    /**
     * Return true if access to the flow specified by dataFlowName is permitted
     * given the input policy list. UserAccessPolicy
     * 
     * @param policies
     * @param flowName
     * @return
     */
    boolean isFlowPermitted(List policies, String flowName);

    /**
     * createPolicy
     * 
     * @param userId
     * @param flowName
     * @param isAllowed
     * @return
     */
    UserAccessPolicy createPolicy(String userId, String flowName,
            boolean isAllowed);
}
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

import java.util.List;
import com.windsor.node.common.domain.AuthenticationRequest;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.UserAccount;

public interface AccountService {

    String getLocalNodeId();

    /**
     * Authenticate a user from Admin interface
     * 
     * @param request
     * @return NodeVisit
     */
    NodeVisit adminAuthenticate(AuthenticationRequest request);

    /**
     * save
     * 
     * @param instance
     * @param naasCreatePassword
     * @param visit
     * @return
     */
    UserAccount save(UserAccount instance, NodeVisit visit);

    /**
     * update
     * 
     * @param instance
     * @param visit
     */
    void update(UserAccount instance, NodeVisit visit);

    /**
     * resetPassword
     * 
     * @param instance
     * @param visit
     */
    void resetPassword(UserAccount instance, NodeVisit visit);

    /**
     * resetPassword
     * 
     * @param currentPassword
     * @param newPassword
     * @param visit
     */
    void resetPassword(String currentPassword, String newPassword,
            NodeVisit visit);

    /**
     * get
     * 
     * @param username
     * @param visit
     * @return
     */
    UserAccount getByUserName(String username, NodeVisit visit);

    /**
     * getById
     * 
     * @param id
     * @param visit
     * @return
     */
    UserAccount getByAccountId(String id, NodeVisit visit);

    /**
     * @param naasAccount
     * @param visit
     * @return
     */
    UserAccount getOrCreateAccount(String naasAccount, NodeVisit visit);

    /**
     * 
     * @param includeInactive
     * @param visit
     * @return
     */
    List<UserAccount> getLocalUsers(boolean includeInactive, NodeVisit visit);

    /**
     * Lists all Users
     * 
     * @param visit
     * @return
     */
    List<UserAccount> getNAASUsers(NodeVisit visit);

    /**
     * Returns a complete list of active users
     * 
     * @param visit
     * @return
     */
    String[] getActiveUsernames(NodeVisit visit);

    /**
     * delete
     * 
     * @param instance
     * @param visit
     */
    void delete(UserAccount instance, NodeVisit visit);

    /**
     * Validates a user's access to a Flow
     * @param visit
     * @param transaction
     */
    void validateAccess(NodeVisit visit, NodeTransaction transaction);

}
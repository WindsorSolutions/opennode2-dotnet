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

package com.windsor.node.service.helper.naas.usrmgr;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.NaasUserInfo;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.service.helper.UserManagerHelper;
import com.windsor.node.util.PasswordUtil;

public class NAASUserManagerHelper implements UserManagerHelper,
        InitializingBean {

    private static final Logger logger = Logger
            .getLogger(NAASUserManagerHelper.class);

    private UserMgrBindingStub proxy = null;
    private NAASConfig naasConfig;

    public void afterPropertiesSet() {

        if (naasConfig == null) {
            throw new IllegalArgumentException("NAASConfig not set");
        }

        try {
            proxy = new UserMgrBindingStub(naasConfig.getMgrEndpoint(), null);
        } catch (Exception ex) {

            logger.error("Error while configuring NAAS User proxy: "
                    + ex.getMessage(), ex);
            throw new IllegalArgumentException(
                    "Error while configuring UserMgrBindingStub: "
                            + ex.getMessage());
        }

    }

    /**
     * addUser
     */
    public void addUser(String username, String password) {

        if (username == null) {
            throw new IllegalArgumentException("username not set");
        }

        if (password == null) {
            throw new IllegalArgumentException("password not set");
        }

        try {

            logger.debug("Executing addUser with:");
            logger.debug("username: " + username);

            String result = proxy.addUser(naasConfig.getAdminAccount()
                    .getUsername(), naasConfig.getAdminAccount().getPassword(),
                    username, UserType.user, password, password, naasConfig
                            .getNodeId());

            logger.debug("Result: " + result);

        } catch (Exception ex) {
            throw getCustomException("Error while executing addUser: "
                    + ex.getMessage(), ex);
        }

    }

    public void changePassword(String username, String password,
            String newPassword) {

        if (username == null) {
            throw new IllegalArgumentException("username not set");
        }

        if (password == null) {
            throw new IllegalArgumentException("password not set");
        }

        if (newPassword == null) {
            throw new IllegalArgumentException("newPassword not set");
        }

        try {

            logger.debug("Executing changePwd");

            String result = proxy.changePwd(username, password, newPassword);

            logger.debug("Result: " + result);

        } catch (Exception ex) {
            throw getCustomException("Error while executing changePwd: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * deleteUser
     */
    public void deleteUser(String username) {

        if (username == null) {
            throw new IllegalArgumentException("username not set");
        }

        try {

            logger.debug("Executing deleteUser with:");
            logger.debug("username: " + username);

            String result = proxy.deleteUser(naasConfig.getAdminAccount()
                    .getUsername(), naasConfig.getAdminAccount().getPassword(),
                    username);

            logger.debug("Result: " + result);

        } catch (Exception ex) {
            throw getCustomException("Error while executing deleteUser: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * resetPassword
     */
    public String resetPassword(String username) {

        if (username == null) {
            throw new IllegalArgumentException("username not set");
        }

        try {

            logger.debug("Executing updateUser");
            logger.debug("username: " + username);

            String newPassword = PasswordUtil.getRandomNAASPassword();

            String result = proxy.updateUser(naasConfig.getAdminAccount()
                    .getUsername(), naasConfig.getAdminAccount().getPassword(),
                    username, UserType.user, newPassword, naasConfig
                            .getAdminAccount().getUsername(), naasConfig
                            .getNodeId());

            logger.debug("Result: " + result);

            return newPassword;

        } catch (Exception ex) {
            throw getCustomException("Error while executing updateUser: "
                    + ex.getMessage(), ex);
        }
    }

    private BigInteger makeMig(int val) {
        return BigInteger.valueOf(val);
    }

    /**
     * getUsers
     */
    public List getUsers() {

        try {

            logger.debug("Executing getUserList");

            List list = new ArrayList();
            boolean hasMore = true;
            int chunkSize = 1500;
            int recordCounter = 0;

            while (hasMore) {

                UserInfo[] info = proxy.getUserList(naasConfig
                        .getAdminAccount().getUsername(), naasConfig
                        .getAdminAccount().getPassword(), "", "",
                        makeMig(recordCounter), makeMig(chunkSize));

                if (info == null || info.length == 0) {
                    hasMore = false;
                } else {

                    list.addAll(mapUsers(info));

                    recordCounter += info.length;

                }

            }

            return list;

        } catch (Exception ex) {
            throw getCustomException("Error while retrieving NAAS users: "
                    + ex.getMessage()
                    + ". Note: this is often due to network timeouts.", ex);
        }
    }

    private List mapUsers(UserInfo[] users) {

        List list = new ArrayList();

        if (users != null) {

            for (int i = 0; i < users.length; i++) {

                try {
                    UserInfo info = users[i];
                    String username = info.getUserId();
                    // Do not import nulls or usernames that are not email
                    // addresses
                    if (StringUtils.isNotBlank(username)
                            && username.indexOf("@") > 2) {
                        String affiliation = info.getNode();
                        if (StringUtils.isBlank(affiliation)) {
                            logger.debug("Null Node for: " + username);
                            affiliation = info.getAffiliate();
                            if (StringUtils.isBlank(affiliation)) {
                                affiliation = NAASConfig.DEFAULT_NODE_ID;
                                logger
                                        .debug("Null Affiliation also, using default: "
                                                + affiliation);
                            }
                        }
                        list.add(new NaasUserInfo(username, affiliation));
                    }
                } catch (Exception ex) {
                    logger.error(ex.getMessage(), ex);
                }
            }

        }

        return list;

    }

    private RuntimeException getCustomException(String message, Exception ex) {
        String result = message + ": " + ex.getMessage();
        logger.error(result, ex);
        return new RuntimeException(result, ex);
    }

    public void setNaasConfig(NAASConfig naasConfig) {
        this.naasConfig = naasConfig;
    }

}
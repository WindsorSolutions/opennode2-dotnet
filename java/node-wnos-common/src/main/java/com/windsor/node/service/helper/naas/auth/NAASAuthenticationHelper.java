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

package com.windsor.node.service.helper.naas.auth;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.conf.NAASConfig;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.service.helper.AuthenticationHelper;

public class NAASAuthenticationHelper implements AuthenticationHelper,
        InitializingBean {

    private NetworkSecurityBindingStub proxy = null;
    private static final Logger logger = LoggerFactory
            .getLogger(NAASAuthenticationHelper.class);

    private NAASConfig naasConfig;
    private NOSConfig nosConfig;

    public void afterPropertiesSet() {

        if (naasConfig == null) {
            throw new IllegalArgumentException("NAASConfig not set");
        }

        if (nosConfig == null) {
            throw new IllegalArgumentException("NOSConfig not set");
        }

        try {
            proxy = new NetworkSecurityBindingStub(
                    naasConfig.getAuthEndpoint(), null);
        } catch (Exception ex) {

            logger.error("Error while configuring NAAS Auth proxy: "
                    + ex.getMessage());
            throw new IllegalArgumentException(
                    "Error while configuring NetworkSecurityBindingStub: "
                            + ex.getMessage());
        }

    }

    /**
     * authenticateUser
     */
    public String authenticateUser(String username, String password,
            String clientHostIP) {

        return authenticateUser(username, password, AuthMethod._password,
                clientHostIP);
    }

    /**
     * authenticateUser
     */
    public String authenticateUser(String username, String password,
            String authenticationMethod, String clientHostIP) {

        try {

            logger.debug("Parsing AuthMethod from: " + authenticationMethod);

            AuthMethod method = AuthMethod.fromValue(authenticationMethod);

            // if (nosConfig.isSkipNaas()) {
            // logger
            // .info("SkipNaas Switch is on. NOT performing NAAS auth on this request");
            // return UUIDGenerator.makeId();
            // }

            logger.debug("Executing centralAuth using: " + username + " from "
                    + clientHostIP);

            return proxy.centralAuth(username, password, method, clientHostIP,
                    "");

        } catch (Exception ex) {
            logger.error("NAAS Error: " + ex.getMessage(), ex);

            throw new RuntimeException("NAAS Error: " + ex.getMessage());
        }

    }

    /**
     * validate
     * 
     * @param securityToken
     * @param clientHostIP
     * @return
     */
    public String validateToken(String securityToken, String clientHostIP) {

        try {

            // TODO: remove before production deployment
            if (nosConfig.isSkipNaas()) {
                logger
                        .info("SkipNaas Switch is on. NOT performing NAAS token validation");
                return naasConfig.getAdminAccount().getUsername();
            }

            logger.debug("Executing centralAuth using: " + securityToken
                    + " at " + clientHostIP);

            String username = proxy.validate(securityToken, clientHostIP, "");

            if (StringUtils.isBlank(username)) {
                throw new RuntimeException("Null username");
            }

            return username;

        } catch (Exception ex) {

            logger.error("Error while executing validate: " + ex.getMessage(),
                    ex);

            throw new RuntimeException("Error while validating token: "
                    + ex.getMessage());
        }
    }

    public void setNaasConfig(NAASConfig naasConfig) {
        this.naasConfig = naasConfig;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

}

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

package com.windsor.node.conf;

import java.net.URL;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.builder.ReflectionToStringBuilder;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.DomainStringStyle;
import com.windsor.node.common.domain.NAASAccount;

public class NAASConfig implements InitializingBean {

    public static final String DEFAULT_NODE_ID = "WINDSOR";

    private URL authEndpoint;
    private URL mgrEndpoint;
    private NAASAccount adminAccount;
    private NAASAccount runtimeAccount;
    private String nodeId;

    /**
     * Make sure the helpers are set
     */
    public void afterPropertiesSet() {

        if (authEndpoint == null) {
            throw new RuntimeException("authEndpoint not set");
        }

        if (mgrEndpoint == null) {
            throw new RuntimeException("mgrEndpoint not set");
        }

        validateNAASAccount(adminAccount);
        validateNAASAccount(runtimeAccount);

        if (StringUtils.isBlank(nodeId)) {
            throw new RuntimeException("nodeId not set");
        }

    }

    /**
     * Prevents duplicate validation on the same type
     * 
     * @param account
     */
    private void validateNAASAccount(NAASAccount account) {
        if (adminAccount == null) {
            throw new RuntimeException("NASSAccount not set");
        }

        if (StringUtils.isBlank(adminAccount.getUsername())) {
            throw new RuntimeException("username not set");
        }

        if (StringUtils.isBlank(adminAccount.getPassword())) {
            throw new RuntimeException("password not set");
        }

        if (StringUtils.isBlank(adminAccount.getDomain())) {
            throw new RuntimeException("domain not set");
        }

        if (StringUtils.isBlank(adminAccount.getAuthMethod())) {
            throw new RuntimeException("auth method not set");
        }

    }

    public URL getAuthEndpoint() {
        return authEndpoint;
    }

    public void setAuthEndpoint(URL authEndpoint) {
        this.authEndpoint = authEndpoint;
    }

    public URL getMgrEndpoint() {
        return mgrEndpoint;
    }

    public void setMgrEndpoint(URL mgrEndpoint) {
        this.mgrEndpoint = mgrEndpoint;
    }

    public NAASAccount getAdminAccount() {
        return adminAccount;
    }

    public void setAdminAccount(NAASAccount adminAccount) {
        this.adminAccount = adminAccount;
    }

    public NAASAccount getRuntimeAccount() {
        return runtimeAccount;
    }

    public void setRuntimeAccount(NAASAccount runtimeAccount) {
        this.runtimeAccount = runtimeAccount;
    }

    public String getNodeId() {
        return nodeId;
    }

    public void setNodeId(String nodeId) {
        this.nodeId = nodeId;
    }

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

}
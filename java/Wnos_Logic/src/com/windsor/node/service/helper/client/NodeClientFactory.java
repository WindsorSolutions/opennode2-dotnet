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

package com.windsor.node.service.helper.client;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.conf.NOSConfig;

public class NodeClientFactory implements InitializingBean,
        DualEndpointNodeClientFactory {

    private static final Logger logger = Logger
            .getLogger(NodeClientFactory.class.getName());

    private NAASConfig naasConfig;
    private NOSConfig nosConfig;
    private NodeClientService client11;
    private NodeClientService client20;

    public void afterPropertiesSet() {

        if (naasConfig == null) {
            throw new RuntimeException("Null NOSConfig");
        }

        if (nosConfig == null) {
            throw new RuntimeException("Null NOSConfig");
        }

        if (client11 == null) {
            throw new RuntimeException("Null Client11");
        }

        if (client20 == null) {
            throw new RuntimeException("Null Client20");
        }

    }

    /**
     * make
     */
    public NodeClientService makeAndConfigure(PartnerIdentity partner) {

        return makeAndConfigure(partner, naasConfig.getRuntimeAccount());

    }

    /**
     * make
     */
    public NodeClientService makeAndConfigure(PartnerIdentity partner,
            NAASAccount credentials) {

        logger.debug("Creating from: " + partner);

        NodeClientService client = null;

        if (partner.getVersion() == EndpointVersionType.EN11) {
            client = client11;
            client.configure(partner.getUrl(), nosConfig
                    .getWebServiceEndpoint1(), credentials, nosConfig
                    .getTempDir());
        } else if (partner.getVersion() == EndpointVersionType.EN20) {
            client = client20;
            client.configure(partner.getUrl(), nosConfig
                    .getWebServiceEndpoint2(), credentials, nosConfig
                    .getTempDir());
        } else {
            throw new RuntimeException("Invalid endpoint version number");
        }

        return client;

    }

    public void setNaasConfig(NAASConfig naasConfig) {
        this.naasConfig = naasConfig;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    public void setClient11(NodeClientService client11) {
        this.client11 = client11;
    }

    public void setClient20(NodeClientService client20) {
        this.client20 = client20;
    }

}
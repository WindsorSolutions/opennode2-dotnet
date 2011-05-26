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

package com.windsor.node.common.domain;

import org.apache.commons.lang.builder.ToStringBuilder;

public class EndpointAuthenticationRequest extends AuthenticationRequest {

    private static final long serialVersionUID = 1;
    private String authTypeOrDomain;
    private EndpointVersionType endpointVersion;

    public EndpointAuthenticationRequest() {
        super();
    }

    public EndpointAuthenticationRequest(EndpointVersionType endpointVersion,
            String userName, String password, String fromIp) {
        this(endpointVersion, userName, password, "password", fromIp);
    }

    public EndpointAuthenticationRequest(EndpointVersionType endpointVersion,
            String userName, String password, String authTypeOrDomain,
            String fromIp) {
        super(userName, password, fromIp);
        this.authTypeOrDomain = authTypeOrDomain;
        this.endpointVersion = endpointVersion;
    }

    public String getAuthTypeOrDomain() {
        return authTypeOrDomain;
    }

    public void setAuthTypeOrDomain(String authTypeOrDomain) {
        this.authTypeOrDomain = authTypeOrDomain;
    }

    public EndpointVersionType getEndpointVersion() {
        return endpointVersion;
    }

    public void setEndpointVersion(EndpointVersionType endpointVersion) {
        this.endpointVersion = endpointVersion;
    }

  //CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = super.hashCode();
        result = prime
                * result
                + ((authTypeOrDomain == null) ? 0 : authTypeOrDomain.hashCode());
        result = prime * result
                + ((endpointVersion == null) ? 0 : endpointVersion.hashCode());
        return result;
    }
  //CHECKSTYLE:ON

  //CHECKSTYLE:OFF
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (!super.equals(obj))
            return false;
        if (getClass() != obj.getClass())
            return false;
        final EndpointAuthenticationRequest other = (EndpointAuthenticationRequest) obj;
        if (authTypeOrDomain == null) {
            if (other.authTypeOrDomain != null)
                return false;
        } else if (!authTypeOrDomain.equals(other.authTypeOrDomain))
            return false;
        if (endpointVersion == null) {
            if (other.endpointVersion != null)
                return false;
        } else if (!endpointVersion.equals(other.endpointVersion))
            return false;
        return true;
    }
  //CHECKSTYLE:ON

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).append(
                super.toString()).append("authTypeOrDomain", authTypeOrDomain)
                .append("endpointVersion", endpointVersion).toString();
    }

}
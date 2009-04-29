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

import java.net.URL;
import java.util.Random;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

public class PartnerIdentity extends AuditableIdentity {

    private static final long serialVersionUID = 2;
    private String name;
    private URL url;
    private EndpointVersionType version = EndpointVersionType.EN20;

    public PartnerIdentity() {
    }

    public PartnerIdentity(String id, String name, URL endpointUrl,
            EndpointVersionType version) {
        super.setId(id);
        this.name = name;
        this.url = endpointUrl;
        this.version = version;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public URL getUrl() {
        return url;
    }

    public void setUrl(URL url) {
        this.url = url;
    }

    public EndpointVersionType getVersion() {
        return version;
    }

    public void setVersion(EndpointVersionType version) {
        this.version = version;
    }

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).appendSuper(
                super.toString()).append("name", name).append("url", url)
                .append("version", version).toString();
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).appendSuper(super.hashCode())
                .append(name).append(url).append(version).toHashCode();
    }

    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj == this) {
            return true;
        }
        if (obj.getClass() != getClass()) {
            return false;
        }
        PartnerIdentity partner = (PartnerIdentity) obj;
        return new EqualsBuilder().appendSuper(super.equals(obj)).append(name,
                partner.name).append(url, partner.url).append(version,
                partner.version).isEquals();
    }
}
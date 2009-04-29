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

import java.util.Random;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

public class UserAccessPolicy extends AuditableIdentity {

    private static final long serialVersionUID = 1;
    private String accountId;
    private ServiceRequestAuthorizationType policyType;
    /* Null, Primitive Method Name, Flow Name, Service Name */
    private String typeQualifier;
    private boolean allowed;

    public UserAccessPolicy() {
    }

    public UserAccessPolicy(String userAccountId,
            ServiceRequestAuthorizationType type, String qualifier,
            boolean isAllowed) {
        accountId = userAccountId;
        policyType = type;
        typeQualifier = qualifier;
        allowed = isAllowed;
    }

    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public ServiceRequestAuthorizationType getPolicyType() {
        return policyType;
    }

    public void setPolicyType(ServiceRequestAuthorizationType policyType) {
        this.policyType = policyType;
    }

    public String getTypeQualifier() {
        return typeQualifier;
    }

    public void setTypeQualifier(String typeQualifier) {
        this.typeQualifier = typeQualifier;
    }

    public boolean isAllowed() {
        return allowed;
    }

    public void setAllowed(boolean allowed) {
        this.allowed = allowed;
    }

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).appendSuper(
                super.toString()).append("accountId", accountId).append(
                "policyType", policyType)
                .append("typeQualifier", typeQualifier).toString();
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).appendSuper(super.hashCode())
                .append(accountId).append(policyType).append(typeQualifier)
                .toHashCode();
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
        UserAccessPolicy uap = (UserAccessPolicy) obj;
        return new EqualsBuilder().appendSuper(super.equals(obj)).append(
                accountId, uap.accountId).append(policyType, uap.policyType)
                .append(typeQualifier, uap.typeQualifier).isEquals();
    }
}
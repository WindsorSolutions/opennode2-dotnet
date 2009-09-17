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

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.builder.ToStringBuilder;

import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;

public class UserAccount extends AuditableIdentity {

    private static final long serialVersionUID = 2;
    private String naasUserName;
    private boolean active;
    private SystemRoleType role;
    private List<UserAccessPolicy> policies;
    private String affiliationCode;

    public UserAccount() {
        role = SystemRoleType.None;
        policies = new ArrayList<UserAccessPolicy>();
    }

    public String getNaasUserName() {
        return naasUserName;
    }

    public void setNaasUserName(String naasUserName) {
        this.naasUserName = naasUserName;
    }

    public String getAffiliationCode() {
        return affiliationCode;
    }

    public void setAffiliationCode(String affiliationCode) {
        this.affiliationCode = affiliationCode;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public SystemRoleType getRole() {
        return role;
    }

    public void setRole(SystemRoleType role) {
        this.role = role;
    }

    public List<UserAccessPolicy> getPolicies() {
        return policies;
    }

    public void setPolicies(List<UserAccessPolicy> policies) {
        this.policies = policies;
    }

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).appendSuper(
                super.toString()).append("naasUserName", naasUserName).append(
                "active", active).append("role", role).append(
                "affiliationCode", affiliationCode)
                .append("policies", policies).toString();
    }

    // CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = super.hashCode();
        result = prime * result + (active ? 1231 : 1237);
        result = prime * result
                + ((affiliationCode == null) ? 0 : affiliationCode.hashCode());
        result = prime * result
                + ((naasUserName == null) ? 0 : naasUserName.hashCode());
        result = prime * result
                + ((policies == null) ? 0 : policies.hashCode());
        result = prime * result + ((role == null) ? 0 : role.hashCode());
        return result;
    }

    // CHECKSTYLE:ON

    // CHECKSTYLE:OFF
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (!super.equals(obj))
            return false;
        if (getClass() != obj.getClass())
            return false;
        final UserAccount other = (UserAccount) obj;
        if (active != other.active)
            return false;
        if (affiliationCode == null) {
            if (other.affiliationCode != null)
                return false;
        } else if (!affiliationCode.equals(other.affiliationCode))
            return false;
        if (naasUserName == null) {
            if (other.naasUserName != null)
                return false;
        } else if (!naasUserName.equals(other.naasUserName))
            return false;
        if (policies == null) {
            if (other.policies != null)
                return false;
        } else if (!policies.equals(other.policies))
            return false;
        if (role == null) {
            if (other.role != null)
                return false;
        } else if (!role.equals(other.role))
            return false;
        return true;
    }
    // CHECKSTYLE:ON

}
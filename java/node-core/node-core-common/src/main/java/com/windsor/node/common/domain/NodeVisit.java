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

import java.io.Serializable;
import java.sql.Timestamp;

import org.apache.commons.lang3.builder.ReflectionToStringBuilder;

public class NodeVisit implements Serializable {

    private static final long serialVersionUID = 1;
    private UserAccount userAccount;
    private Timestamp createdOn = new Timestamp(System.currentTimeMillis());
    private String ip;
    private Boolean anonymousVisit = Boolean.FALSE;

    public NodeVisit() {
    }

    public NodeVisit(UserAccount account, String requestedFromIp) {
        this.ip = requestedFromIp;
        this.userAccount = account;
    }

    public String getName() {
        if (userAccount != null) {
            return userAccount.getNaasUserName();
        } else {
            return null;
        }
    }

    public UserAccount getUserAccount() {
        return userAccount;
    }

    public void setUserAccount(UserAccount userAccount) {
        this.userAccount = userAccount;
    }

    public Timestamp getCreatedOn() {
        return createdOn;
    }

    public void setCreatedOn(Timestamp createdOn) {
        this.createdOn = createdOn;
    }

    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public Boolean getAnonymousVisit()
    {
        return anonymousVisit;
    }

    public void setAnonymousVisit(Boolean anonymousVisit)
    {
        this.anonymousVisit = anonymousVisit;
    }

    // CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result
                + ((createdOn == null) ? 0 : createdOn.hashCode());
        result = prime * result + ((ip == null) ? 0 : ip.hashCode());
        result = prime * result
                + ((userAccount == null) ? 0 : userAccount.hashCode());
        result = prime * result + ((anonymousVisit == null) ? 0 : anonymousVisit.hashCode());
        return result;
    }
    // CHECKSTYLE:ON

    // CHECKSTYLE:OFF
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        final NodeVisit other = (NodeVisit) obj;
        if (createdOn == null) {
            if (other.createdOn != null)
                return false;
        } else if (!createdOn.equals(other.createdOn))
            return false;
        if (ip == null) {
            if (other.ip != null)
                return false;
        } else if (!ip.equals(other.ip))
            return false;
        if (userAccount == null) {
            if (other.userAccount != null)
                return false;
        } else if (!userAccount.equals(other.userAccount))
            return false;
        if (anonymousVisit == null) {
            if (other.anonymousVisit != null)
                return false;
        } else if (!anonymousVisit.equals(other.anonymousVisit))
            return false;
        return true;
    }
    // CHECKSTYLE:ON

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

}
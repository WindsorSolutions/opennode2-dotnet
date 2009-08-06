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
package com.windsor.node.common.domain.flowsecurity;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

import com.windsor.node.common.domain.DomainStringStyle;

/**
 * Encapsulates a request for access to specific Exchanges (aka Flows) on the
 * Node.
 * 
 */
public class AuthorizationRequest {

    private String id;
    private String transactionId;
    private Timestamp requestGeneratedOn;
    private boolean existsInNaas;
    private String requestType;
    private String naasUserName;
    private String fullName;
    private String orgAffiliation;
    private String phoneNumber;
    private String emailAddress;
    private String affiliatedNodeId;
    private String affiliatedCounty;
    private String purposeDescription;
    private String requestedNodeIds;
    private String authorizationAccountId;
    private String authorizationComments;
    private Timestamp authorizationGeneratedOn;
    private boolean didCreateInNaas;
    private List<FlowRequest> requestedFlows;

    public AuthorizationRequest() {
        requestedFlows = new ArrayList<FlowRequest>();
    }

    @Override
    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public Timestamp getRequestGeneratedOn() {
        return requestGeneratedOn;
    }

    public void setRequestGeneratedOn(Timestamp generatedOn) {
        this.requestGeneratedOn = generatedOn;
    }

    public boolean isExistsInNaas() {
        return existsInNaas;
    }

    public void setExistsInNaas(boolean existsInNaas) {
        this.existsInNaas = existsInNaas;
    }

    public String getRequestType() {
        return requestType;
    }

    public void setRequestType(String requestType) {
        this.requestType = requestType;
    }

    public String getNaasUserName() {
        return naasUserName;
    }

    public void setNaasUserName(String naasUserName) {
        this.naasUserName = naasUserName;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getOrgAffiliation() {
        return orgAffiliation;
    }

    public void setOrgAffiliation(String orgAffiliation) {
        this.orgAffiliation = orgAffiliation;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getEmailAddress() {
        return emailAddress;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    public String getAffiliatedNodeId() {
        return affiliatedNodeId;
    }

    public void setAffiliatedNodeId(String affiliatedNodeId) {
        this.affiliatedNodeId = affiliatedNodeId;
    }

    public String getAffiliatedCounty() {
        return affiliatedCounty;
    }

    public void setAffiliatedCounty(String affiliatedCounty) {
        this.affiliatedCounty = affiliatedCounty;
    }

    public String getPurposeDescription() {
        return purposeDescription;
    }

    public void setPurposeDescription(String purposeDescription) {
        this.purposeDescription = purposeDescription;
    }

    public String getRequestedNodeIds() {
        return requestedNodeIds;
    }

    public void setRequestedNodeIds(String requestedNodeIds) {
        this.requestedNodeIds = requestedNodeIds;
    }

    public String getAuthorizationAccountId() {
        return authorizationAccountId;
    }

    public void setAuthorizationAccountId(String authorizationAccountId) {
        this.authorizationAccountId = authorizationAccountId;
    }

    public String getAuthorizationComments() {
        return authorizationComments;
    }

    public void setAuthorizationComments(String authorizationComments) {
        this.authorizationComments = authorizationComments;
    }

    public Timestamp getAuthorizationGeneratedOn() {
        return authorizationGeneratedOn;
    }

    public void setAuthorizationGeneratedOn(Timestamp authorizationGeneratedOn) {
        this.authorizationGeneratedOn = authorizationGeneratedOn;
    }

    public boolean isDidCreateInNaas() {
        return didCreateInNaas;
    }

    public void setDidCreateInNaas(boolean didCreateInNaas) {
        this.didCreateInNaas = didCreateInNaas;
    }

    public List<FlowRequest> getRequestedFlows() {
        return requestedFlows;
    }

    public void setRequestedFlows(List<FlowRequest> requestedFlows) {
        this.requestedFlows = requestedFlows;
    }

    // CHECKSTYLE:OFF

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime
                * result
                + ((affiliatedCounty == null) ? 0 : affiliatedCounty.hashCode());
        result = prime
                * result
                + ((affiliatedNodeId == null) ? 0 : affiliatedNodeId.hashCode());
        result = prime
                * result
                + ((authorizationAccountId == null) ? 0
                        : authorizationAccountId.hashCode());
        result = prime
                * result
                + ((authorizationComments == null) ? 0 : authorizationComments
                        .hashCode());
        result = prime
                * result
                + ((authorizationGeneratedOn == null) ? 0
                        : authorizationGeneratedOn.hashCode());
        result = prime * result + (didCreateInNaas ? 1231 : 1237);
        result = prime * result
                + ((emailAddress == null) ? 0 : emailAddress.hashCode());
        result = prime * result + (existsInNaas ? 1231 : 1237);
        result = prime * result
                + ((fullName == null) ? 0 : fullName.hashCode());
        result = prime
                * result
                + ((requestGeneratedOn == null) ? 0 : requestGeneratedOn
                        .hashCode());
        result = prime * result + ((id == null) ? 0 : id.hashCode());
        result = prime * result
                + ((naasUserName == null) ? 0 : naasUserName.hashCode());
        result = prime * result
                + ((orgAffiliation == null) ? 0 : orgAffiliation.hashCode());
        result = prime * result
                + ((phoneNumber == null) ? 0 : phoneNumber.hashCode());
        result = prime
                * result
                + ((purposeDescription == null) ? 0 : purposeDescription
                        .hashCode());
        result = prime * result
                + ((requestType == null) ? 0 : requestType.hashCode());
        result = prime * result
                + ((requestedFlows == null) ? 0 : requestedFlows.hashCode());
        result = prime
                * result
                + ((requestedNodeIds == null) ? 0 : requestedNodeIds.hashCode());
        result = prime * result
                + ((transactionId == null) ? 0 : transactionId.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        AuthorizationRequest other = (AuthorizationRequest) obj;
        if (affiliatedCounty == null) {
            if (other.affiliatedCounty != null)
                return false;
        } else if (!affiliatedCounty.equals(other.affiliatedCounty))
            return false;
        if (affiliatedNodeId == null) {
            if (other.affiliatedNodeId != null)
                return false;
        } else if (!affiliatedNodeId.equals(other.affiliatedNodeId))
            return false;
        if (authorizationAccountId == null) {
            if (other.authorizationAccountId != null)
                return false;
        } else if (!authorizationAccountId.equals(other.authorizationAccountId))
            return false;
        if (authorizationComments == null) {
            if (other.authorizationComments != null)
                return false;
        } else if (!authorizationComments.equals(other.authorizationComments))
            return false;
        if (authorizationGeneratedOn == null) {
            if (other.authorizationGeneratedOn != null)
                return false;
        } else if (!authorizationGeneratedOn
                .equals(other.authorizationGeneratedOn))
            return false;
        if (didCreateInNaas != other.didCreateInNaas)
            return false;
        if (emailAddress == null) {
            if (other.emailAddress != null)
                return false;
        } else if (!emailAddress.equals(other.emailAddress))
            return false;
        if (existsInNaas != other.existsInNaas)
            return false;
        if (fullName == null) {
            if (other.fullName != null)
                return false;
        } else if (!fullName.equals(other.fullName))
            return false;
        if (requestGeneratedOn == null) {
            if (other.requestGeneratedOn != null)
                return false;
        } else if (!requestGeneratedOn.equals(other.requestGeneratedOn))
            return false;
        if (id == null) {
            if (other.id != null)
                return false;
        } else if (!id.equals(other.id))
            return false;
        if (naasUserName == null) {
            if (other.naasUserName != null)
                return false;
        } else if (!naasUserName.equals(other.naasUserName))
            return false;
        if (orgAffiliation == null) {
            if (other.orgAffiliation != null)
                return false;
        } else if (!orgAffiliation.equals(other.orgAffiliation))
            return false;
        if (phoneNumber == null) {
            if (other.phoneNumber != null)
                return false;
        } else if (!phoneNumber.equals(other.phoneNumber))
            return false;
        if (purposeDescription == null) {
            if (other.purposeDescription != null)
                return false;
        } else if (!purposeDescription.equals(other.purposeDescription))
            return false;
        if (requestType == null) {
            if (other.requestType != null)
                return false;
        } else if (!requestType.equals(other.requestType))
            return false;
        if (requestedFlows == null) {
            if (other.requestedFlows != null)
                return false;
        } else if (!requestedFlows.equals(other.requestedFlows))
            return false;
        if (requestedNodeIds == null) {
            if (other.requestedNodeIds != null)
                return false;
        } else if (!requestedNodeIds.equals(other.requestedNodeIds))
            return false;
        if (transactionId == null) {
            if (other.transactionId != null)
                return false;
        } else if (!transactionId.equals(other.transactionId))
            return false;
        return true;
    }
    // CHECKSTYLE:ON

}

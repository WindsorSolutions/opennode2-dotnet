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

package com.windsor.node.admin.domain;

import java.util.Date;
import java.util.List;

import com.windsor.node.common.domain.ActivitySearchCriteria;
import com.windsor.node.common.domain.ActivitySearchLookups;

public class ActivitySearchForm {

    private ActivitySearchCriteria criteria;
    private ActivitySearchLookups lookups;
    private List exchanges;

    public ActivitySearchForm() {

        criteria = new ActivitySearchCriteria();
        lookups = new ActivitySearchLookups();

    }

    public ActivitySearchCriteria getCriteria() {
        return criteria;
    }

    public void setCriteria(ActivitySearchCriteria criteria) {
        this.criteria = criteria;
    }

    public List getActivityTypeNames() {
        return lookups.getEntryTypes();
    }

    public void setActivityTypeNames(List activityTypeNames) {
        this.lookups.setEntryTypes(activityTypeNames);
    }

    public List getIpList() {
        return lookups.getIpList();
    }

    public void setIpList(List ipList) {
        this.lookups.setIpList(ipList);
    }

    public List getAccountList() {
        return lookups.getAccountList();
    }

    public void setAccountList(List accountList) {
        this.lookups.setAccountList(accountList);
    }

    public List getExchanges() {
        return exchanges;
    }

    public void setExchanges(List exchanges) {
        this.exchanges = exchanges;
    }

    public String getType() {
        return criteria.getType();
    }

    public void setType(String type) {
        criteria.setType(type);
    }

    public String getTransactionId() {
        return criteria.getTransactionId();
    }

    public void setTransactionId(String transactionId) {
        criteria.setTransactionId(transactionId);
    }

    public String getIp() {
        return criteria.getIp();
    }

    public void setIp(String ip) {
        criteria.setIp(ip);
    }

    public String getCreatedById() {
        return criteria.getCreatedById();
    }

    public void setCreatedById(String createdById) {
        criteria.setCreatedById(createdById);
    }

    public Date getCreatedFrom() {
        return criteria.getCreatedFrom();
    }

    public void setCreatedFrom(Date createdFrom) {
        criteria.setCreatedFrom(createdFrom);
    }

    public Date getCreatedTo() {
        return criteria.getCreatedTo();
    }

    public void setCreatedTo(Date createdTo) {
        criteria.setCreatedTo(createdTo);
    }

    public String getDetailContains() {
        return criteria.getDetailContains();
    }

    public void setDetailContains(String detailContains) {
        criteria.setDetailContains(detailContains);
    }

    public ActivitySearchLookups getLookups() {
        return lookups;
    }

    public void setLookups(ActivitySearchLookups lookups) {
        this.lookups = lookups;
    }

    public String getFlowId() {
        return criteria.getFlowId();
    }

    public void setFlowId(String flowId) {
        criteria.setFlowId(flowId);
    }

    public int getMaxRecords() {
        return criteria.getMaxRecords();
    }

    public void setMaxRecords(int maxRecords) {
        criteria.setMaxRecords(maxRecords);
    }
}
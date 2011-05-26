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
import java.util.Date;
import java.util.List;

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

public class ActivitySearchLookups implements Serializable {

    private static final long serialVersionUID = 1;
    private Date minDate;
    private Date maxDate;
    private List entryTypes;
    private List ipList;
    private List accountList;
    private List transactionList;

    public ActivitySearchLookups() {

    }

    public Date getMinDate() {
        return minDate;
    }

    public void setMinDate(Date minDate) {
        this.minDate = minDate;
    }

    public Date getMaxDate() {
        return maxDate;
    }

    public void setMaxDate(Date maxDate) {
        this.maxDate = maxDate;
    }

    public List getEntryTypes() {
        return entryTypes;
    }

    public void setEntryTypes(List entryTypes) {
        this.entryTypes = entryTypes;
    }

    public List getIpList() {
        return ipList;
    }

    public void setIpList(List ipList) {
        this.ipList = ipList;
    }

    public List getAccountList() {
        return accountList;
    }

    public void setAccountList(List accountList) {
        this.accountList = accountList;
    }

    public List getTransactionList() {
        return transactionList;
    }

    public void setTransactionList(List transactionList) {
        this.transactionList = transactionList;
    }
    // CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result
                + ((accountList == null) ? 0 : accountList.hashCode());
        result = prime * result
                + ((entryTypes == null) ? 0 : entryTypes.hashCode());
        result = prime * result + ((ipList == null) ? 0 : ipList.hashCode());
        result = prime * result + ((maxDate == null) ? 0 : maxDate.hashCode());
        result = prime * result + ((minDate == null) ? 0 : minDate.hashCode());
        result = prime * result
                + ((transactionList == null) ? 0 : transactionList.hashCode());
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
        final ActivitySearchLookups other = (ActivitySearchLookups) obj;
        if (accountList == null) {
            if (other.accountList != null)
                return false;
        } else if (!accountList.equals(other.accountList))
            return false;
        if (entryTypes == null) {
            if (other.entryTypes != null)
                return false;
        } else if (!entryTypes.equals(other.entryTypes))
            return false;
        if (ipList == null) {
            if (other.ipList != null)
                return false;
        } else if (!ipList.equals(other.ipList))
            return false;
        if (maxDate == null) {
            if (other.maxDate != null)
                return false;
        } else if (!maxDate.equals(other.maxDate))
            return false;
        if (minDate == null) {
            if (other.minDate != null)
                return false;
        } else if (!minDate.equals(other.minDate))
            return false;
        if (transactionList == null) {
            if (other.transactionList != null)
                return false;
        } else if (!transactionList.equals(other.transactionList))
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
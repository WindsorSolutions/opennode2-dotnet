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
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

public class ProcessContentResult implements Serializable {

    private static final long serialVersionUID = 2;

    private CommonTransactionStatusCode status;

    /**
     * List of type com.windsor.node.common.domain.Document
     */
    private List<Document> documents;
    private PaginationIndicator paginatedContentIndicator;
    private List<ActivityEntry> auditEntries;
    private boolean success;

    public ProcessContentResult() {
        status = CommonTransactionStatusCode.Unknown;
        this.auditEntries = new ArrayList<ActivityEntry>();
        this.documents = new ArrayList<Document>();
        success = false;
    }

    public CommonTransactionStatusCode getStatus() {
        return status;
    }

    public void setStatus(CommonTransactionStatusCode status) {
        this.status = status;
    }

    public List<Document> getDocuments() {
        return documents;
    }

    public List<ActivityEntry> getAuditEntries() {
        return auditEntries;
    }

    public boolean isSuccess() {
        return success;
    }

    public void setSuccess(boolean success) {
        this.success = success;
    }

    public void setDocuments(List<Document> documents) {
        this.documents = documents;
    }

    public PaginationIndicator getPaginatedContentIndicator() {
        return paginatedContentIndicator;
    }

    public void setPaginatedContentIndicator(
            PaginationIndicator paginatedContentIndicator) {
        this.paginatedContentIndicator = paginatedContentIndicator;
    }

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

}

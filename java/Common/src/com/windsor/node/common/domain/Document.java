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

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

public class Document extends SimpleContent {

    private static final long serialVersionUID = 1;
    private String documentId;
    private String documentName;
    private CommonTransactionStatusCode documentStatus;
    private String documentStatusDetail;

    public Document() {
        documentStatus = CommonTransactionStatusCode.Received;
    }

    public Document(String documentId, String documentName,
            CommonContentType type) {
        this(documentId, documentName, type, null);

    }

    public Document(String documentId, String documentName,
            CommonContentType type, byte[] content) {
        super(type, content);
        this.documentStatus = CommonTransactionStatusCode.Unknown;
        this.documentId = documentId;
        this.documentName = documentName;
    }

    public Document(String documentName, CommonContentType type, byte[] content)

    {
        super(type, content);
        this.documentName = documentName;
        this.documentStatus = CommonTransactionStatusCode.Unknown;
    }

    public String getDocumentId() {
        return documentId;
    }

    public void setDocumentId(String documentId) {
        this.documentId = documentId;
    }

    public String getDocumentName() {
        return documentName;
    }

    public void setDocumentName(String documentName) {
        this.documentName = documentName;
    }

    public CommonTransactionStatusCode getDocumentStatus() {
        return documentStatus;
    }

    public void setDocumentStatus(CommonTransactionStatusCode documentStatus) {
        this.documentStatus = documentStatus;
    }

    public String getDocumentStatusDetail() {
        return documentStatusDetail;
    }

    public void setDocumentStatusDetail(String documentStatusDetail) {
        this.documentStatusDetail = documentStatusDetail;
    }

  //CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = super.hashCode();
        result = prime * result
                + ((documentId == null) ? 0 : documentId.hashCode());
        result = prime * result
                + ((documentName == null) ? 0 : documentName.hashCode());
        result = prime * result
                + ((documentStatus == null) ? 0 : documentStatus.hashCode());
        result = prime
                * result
                + ((documentStatusDetail == null) ? 0 : documentStatusDetail
                        .hashCode());
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
        final Document other = (Document) obj;
        if (documentId == null) {
            if (other.documentId != null)
                return false;
        } else if (!documentId.equals(other.documentId))
            return false;
        if (documentName == null) {
            if (other.documentName != null)
                return false;
        } else if (!documentName.equals(other.documentName))
            return false;
        if (documentStatus == null) {
            if (other.documentStatus != null)
                return false;
        } else if (!documentStatus.equals(other.documentStatus))
            return false;
        if (documentStatusDetail == null) {
            if (other.documentStatusDetail != null)
                return false;
        } else if (!documentStatusDetail.equals(other.documentStatusDetail))
            return false;
        return true;
    }
  //CHECKSTYLE:ON

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());

        String[] excludes = { "content" };
        rtsb.setExcludeFieldNames(excludes);
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

}
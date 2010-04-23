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

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

import com.windsor.node.common.util.CommonTransactionStatusCodeConverter;

public class TransactionStatus implements Serializable {

    private static final long serialVersionUID = 1;

    private CommonTransactionStatusCode status;
    private String description;
    private String transactionId;

    public TransactionStatus() {
    }

    public TransactionStatus(String transactionId) {
        this.transactionId = transactionId;
        this.status = CommonTransactionStatusCode.Received;
        this.description = "";
    }

    public TransactionStatus(CommonTransactionStatusCode status) {
        this.status = status;
        this.description = "";
    }

    public TransactionStatus(CommonTransactionStatusCode status,
            String description) {
        this.status = status;
        this.description = description;
    }

    public TransactionStatus(String transactionId,
            CommonTransactionStatusCode status, String description) {
        this(transactionId);
        this.status = status;
        this.description = description;
    }

    public TransactionStatus(String transactionId, String status,
            String description) {
        this(transactionId,
                (CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                        .convert(status), description);
    }

    public TransactionStatus(String status, String description) {
        this((CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                .convert(status), description);
    }

    public CommonTransactionStatusCode getStatus() {
        return status;
    }

    public void setStatus(CommonTransactionStatusCode status) {
        this.status = status;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    // CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result
                + ((description == null) ? 0 : description.hashCode());
        result = prime * result + ((status == null) ? 0 : status.hashCode());
        result = prime * result
                + ((transactionId == null) ? 0 : transactionId.hashCode());
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
        final TransactionStatus other = (TransactionStatus) obj;
        if (description == null) {
            if (other.description != null)
                return false;
        } else if (!description.equals(other.description))
            return false;
        if (status == null) {
            if (other.status != null)
                return false;
        } else if (!status.equals(other.status))
            return false;
        if (transactionId == null) {
            if (other.transactionId != null)
                return false;
        } else if (!transactionId.equals(other.transactionId))
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
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

import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.enums.ValuedEnum;

public final class CommonTransactionStatusCode extends ValuedEnum {

    public static final String UNKNOWN_STR = "Unknown";
    public static final String RECEIVED_STR = "Received";
    public static final String PROCESSING_STR = "Processing";
    public static final String PENDING_STR = "Pending";
    public static final String FAILED_STR = "Failed";
    public static final String CANCELLED_STR = "Cancelled";
    public static final String APPROVED_STR = "Approved";
    public static final String PROCESSED_STR = "Processed";
    public static final String COMPLETED_STR = "Completed";
    
    public static final CommonTransactionStatusCode UNKNOWN = new CommonTransactionStatusCode(
            UNKNOWN_STR, 0x00);
    public static final CommonTransactionStatusCode RECEIVED = new CommonTransactionStatusCode(
            RECEIVED_STR, 0x02);
    public static final CommonTransactionStatusCode PROCESSING = new CommonTransactionStatusCode(
            PROCESSING_STR, 0x04);
    public static final CommonTransactionStatusCode PENDING = new CommonTransactionStatusCode(
            PENDING_STR, 0x08);
    public static final CommonTransactionStatusCode FAILED = new CommonTransactionStatusCode(
            FAILED_STR, 0x10);
    public static final CommonTransactionStatusCode CANCELLED = new CommonTransactionStatusCode(
            CANCELLED_STR, 0x20);;
    public static final CommonTransactionStatusCode APPROVED = new CommonTransactionStatusCode(
            APPROVED_STR, 0x20);;
    public static final CommonTransactionStatusCode PROCESSED = new CommonTransactionStatusCode(
            PROCESSED_STR, 0x40);;
    public static final CommonTransactionStatusCode COMPLETED = new CommonTransactionStatusCode(
            COMPLETED_STR, 0x80);

    private static final long serialVersionUID = 1;

    private CommonTransactionStatusCode(String s, int i) {
        super(s, i);
    }

    public static Map getEnumMap() {
        return getEnumMap(CommonTransactionStatusCode.class);
    }

    public static List getEnumList() {
        return getEnumList(CommonTransactionStatusCode.class);
    }

    public static Iterator iterator() {
        return iterator(CommonTransactionStatusCode.class);
    }

}
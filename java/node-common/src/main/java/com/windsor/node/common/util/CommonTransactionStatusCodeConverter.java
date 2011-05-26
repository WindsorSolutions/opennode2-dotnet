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

package com.windsor.node.common.util;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Wsdl11TransactionStatusCode;

public final class CommonTransactionStatusCodeConverter {

    private CommonTransactionStatusCodeConverter() {
    }

    public static CommonTransactionStatusCode convert(String s) {

        CommonTransactionStatusCode ctsc = null;

        Object o = CommonTransactionStatusCode.valueOf(initCap(s));

        if ((null != o) && (o instanceof CommonTransactionStatusCode)) {
            ctsc = (CommonTransactionStatusCode) o;
        } else {
            throw new IllegalArgumentException("The string \"" + s
                    + "\" does not represent a common transaction status code.");
        }
        return ctsc;
    }

    private static String initCap(String s) {

        StringBuilder buf = new StringBuilder(s.length());
        buf.append(s.substring(0, 1).toUpperCase());
        buf.append(s.substring(1).toLowerCase());

        return buf.toString();
    }

    public static Wsdl11TransactionStatusCode convertTo11Type(
            CommonTransactionStatusCode ctsc) {
        Wsdl11TransactionStatusCode wtsc = null;

        // account for special types that do not directly map to the common type
        if (ctsc.equals(CommonTransactionStatusCode.Processing)) {
            wtsc = Wsdl11TransactionStatusCode.PENDING;
        } else if (ctsc.equals(CommonTransactionStatusCode.Cancelled)) {
            wtsc = Wsdl11TransactionStatusCode.FAILED;
        } else if (ctsc.equals(CommonTransactionStatusCode.Approved)) {
            wtsc = Wsdl11TransactionStatusCode.PROCESSED;
        } else {
            String s = ctsc.toString();
            Object o = Wsdl11TransactionStatusCode.getEnumMap().get(s);
            if ((null != o) && (o instanceof Wsdl11TransactionStatusCode)) {
                wtsc = (Wsdl11TransactionStatusCode) o;
            } else {
                throw new IllegalArgumentException(
                        "The transaction status code \""
                                + ctsc.name()
                                + "\" does not map to a WSDL 1.1 transaction status code.");
            }
        }
        return wtsc;
    }
}
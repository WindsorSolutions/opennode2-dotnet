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

package com.windsor.node.common.exception;

import java.io.Serializable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.enums.Enum;

public final class ENExceptionCodeType extends Enum implements Serializable {
    
    public static final ENExceptionCodeType E_INTERNALERROR = new ENExceptionCodeType(
            "E_InternalError");
    public static final ENExceptionCodeType E_UNKNOWNUSER = new ENExceptionCodeType(
            "E_UnknownUser");
    public static final ENExceptionCodeType E_INVALIDCREDENTIAL = new ENExceptionCodeType(
            "E_InvalidCredential");
    public static final ENExceptionCodeType E_TRASNACTIONID = new ENExceptionCodeType(
            "E_TransactionId");
    public static final ENExceptionCodeType E_UNKNOWNMETHOD = new ENExceptionCodeType(
            "E_UnknownMethod");
    public static final ENExceptionCodeType E_SERVICEUNAVAILABLE = new ENExceptionCodeType(
            "E_ServiceUnavailable");
    public static final ENExceptionCodeType E_ACCESSDENIED = new ENExceptionCodeType(
            "E_AccessDenied");
    public static final ENExceptionCodeType E_INVALIDTOKEN = new ENExceptionCodeType(
            "E_InvalidToken");
    public static final ENExceptionCodeType E_TOKENEXPIRED = new ENExceptionCodeType(
            "E_TokenExpired");
    public static final ENExceptionCodeType E_FILENOTFOUND = new ENExceptionCodeType(
            "E_FileNotFound");
    public static final ENExceptionCodeType E_VALIDATIONFAILED = new ENExceptionCodeType(
            "E_ValidationFailed");
    public static final ENExceptionCodeType E_SERVERBUSY = new ENExceptionCodeType(
            "E_ServerBusy");
    public static final ENExceptionCodeType E_ROWIDOUTOFRANGE = new ENExceptionCodeType(
            "E_RowIdOutofRange");
    public static final ENExceptionCodeType E_FEATUREUNSUPPORTED = new ENExceptionCodeType(
            "E_FeatureUnsupported");
    public static final ENExceptionCodeType E_VERSIONMISMATCH = new ENExceptionCodeType(
            "E_VersionMismatch");
    public static final ENExceptionCodeType E_INVALIDFILENAME = new ENExceptionCodeType(
            "E_InvalidFileName");
    public static final ENExceptionCodeType E_INVALIDFILETYPE = new ENExceptionCodeType(
            "E_InvalidFileType");
    public static final ENExceptionCodeType E_INVALIDDATAFLOW = new ENExceptionCodeType(
            "E_InvalidDataFlow");
    public static final ENExceptionCodeType E_INVALIDPARAMETER = new ENExceptionCodeType(
            "E_InvalidParameter");

    private static final long serialVersionUID = 1;

    private ENExceptionCodeType(String type) {
        super(type);
    }

    public static Map getEnumMap() {
        return getEnumMap(ENExceptionCodeType.class);
    }

    public static List getEnumList() {
        return getEnumList(ENExceptionCodeType.class);
    }

    public static Iterator iterator() {
        return iterator(ENExceptionCodeType.class);
    }

}
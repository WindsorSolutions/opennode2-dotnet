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
//TODO are these even needed?  They don't seem to be referenced in any useful way.
public enum ENExceptionCodeType implements Serializable
{
    E_InternalError("E_InternalError"), E_UnknownUser("E_UnknownUser"), E_InvalidCredential("E_InvalidCredential"), E_TransactionId(
                    "E_TransactionId"), E_UnknownMethod("E_UnknownMethod"), E_ServiceUnavailable("E_ServiceUnavailable"), E_AccessDenied(
                    "E_AccessDenied"), E_InvalidToken("E_InvalidToken"), E_TokenExpired("E_TokenExpired"), E_FileNotFound("E_FileNotFound"), E_ValidationFailed(
                    "E_ValidationFailed"), E_ServerBusy("E_ServerBusy"), E_RowIdOutofRange("E_RowIdOutofRange"), E_FeatureUnsupported(
                    "E_FeatureUnsupported"), E_VersionMismatch("E_VersionMismatch"), E_InvalidFileName("E_InvalidFileName"), E_InvalidFileType(
                    "E_InvalidFileType"), E_InvalidDataFlow("E_InvalidDataFlow"), E_InvalidParameter("E_InvalidParameter");

    private static final long serialVersionUID = 1;
    private final String type;

    private ENExceptionCodeType(String type)
    {
        this.type = type;
    }

    public String getType()
    {
        return type;
    }
}
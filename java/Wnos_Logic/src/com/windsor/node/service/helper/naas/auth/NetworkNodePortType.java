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

/**
 * NetworkNodePortType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.naas.auth;

public interface NetworkNodePortType extends java.rmi.Remote {

    /**
     * Direct authentication for network users. The security token can then be
     * used to access all participating network nodes. Network node should call
     * the CentralAuth method instead.
     */
    public java.lang.String authenticate(
            java.lang.String userId,
            java.lang.String credential,
            com.windsor.node.service.helper.naas.auth.AuthMethod authenticationMethod)
            throws java.rmi.RemoteException;

    /**
     * Central authentication method, used only by participating newwork nodes.
     * Users should call the Auth method directly
     */
    public java.lang.String centralAuth(java.lang.String uid,
            java.lang.String cred,
            com.windsor.node.service.helper.naas.auth.AuthMethod authMethod,
            java.lang.String clientHost, java.lang.String resourceURI)
            throws java.rmi.RemoteException;

    /**
     * Validate a previously issued authToken.
     */
    public java.lang.String validate(java.lang.String authToken,
            java.lang.String clientHost, java.lang.String resourceURI)
            throws java.rmi.RemoteException;
}
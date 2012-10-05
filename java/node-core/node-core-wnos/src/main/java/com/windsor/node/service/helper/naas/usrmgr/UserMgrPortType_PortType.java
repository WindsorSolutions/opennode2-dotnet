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
 * UserMgrPortType_PortType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.naas.usrmgr;

public interface UserMgrPortType_PortType extends java.rmi.Remote {

    /**
     * Add a new user.The system uses email address as the user id. All
     * parameters are required.Password should contain a mix of lower case,
     * upper case and numeric characters.
     */
    public java.lang.String addUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail,
            com.windsor.node.service.helper.naas.usrmgr.UserType userType,
            java.lang.String userPwd, java.lang.String confirmUserPwd,
            java.lang.String affiliate) throws java.rmi.RemoteException;

    /**
     * Remove a user, you must be an administrator and the owner of the account.
     */
    public java.lang.String deleteUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail)
            throws java.rmi.RemoteException;

    /**
     * Update a user account information. The Password should contain a mix of
     * lower case, upper case and numeric characters
     */
    public java.lang.String updateUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail,
            com.windsor.node.service.helper.naas.usrmgr.UserType userType,
            java.lang.String userPwd, java.lang.String owner,
            java.lang.String affiliate) throws java.rmi.RemoteException;

    /**
     * Set additional user identity information.
     */
    public java.lang.String setUserProperty(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userId,
            java.lang.String commonName, java.lang.String organization,
            java.lang.String organizationUnit, java.lang.String address,
            java.lang.String city, java.lang.String state,
            java.lang.String zipCode, java.lang.String phone,
            java.lang.String supervisor, java.lang.String supervisorPhone,
            java.lang.String userData, java.lang.String securityLevel,
            java.lang.String certificateStatus, java.lang.String lastChange)
            throws java.rmi.RemoteException;

    /**
     * Get additional user identity information.
     */
    public com.windsor.node.service.helper.naas.usrmgr.UserProperty[] getUserProperty(
            java.lang.String adminName, java.lang.String adminPwd,
            java.lang.String userEmail) throws java.rmi.RemoteException;

    /**
     * Get a list of users
     */
    public com.windsor.node.service.helper.naas.usrmgr.UserInfo[] getUserList(
            java.lang.String adminName, java.lang.String adminPwd,
            java.lang.String userEmail, java.lang.String userState,
            java.math.BigInteger rowId, java.math.BigInteger maxRows)
            throws java.rmi.RemoteException;

    /**
     * The new password should contain a mix of lower case, upper case and
     * numeric characters. The minimum password length is 8
     */
    public java.lang.String changePwd(java.lang.String userEmail,
            java.lang.String password, java.lang.String newPwd)
            throws java.rmi.RemoteException;
}
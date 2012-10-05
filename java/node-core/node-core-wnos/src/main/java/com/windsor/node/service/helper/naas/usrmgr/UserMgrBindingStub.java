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
 * UserMgrBindingStub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.naas.usrmgr;

import java.rmi.RemoteException;

public class UserMgrBindingStub extends org.apache.axis.client.Stub implements
        com.windsor.node.service.helper.naas.usrmgr.UserMgrPortType_PortType {

    private static final long serialVersionUID = 1;
    private static final int TIMEOUT_IN_MIL_SEC = 30000000;

    private java.util.Vector cachedSerClasses = new java.util.Vector();
    private java.util.Vector cachedSerQNames = new java.util.Vector();
    private java.util.Vector cachedSerFactories = new java.util.Vector();
    private java.util.Vector cachedDeserFactories = new java.util.Vector();

    static org.apache.axis.description.OperationDesc[] _operations;

    static {
        _operations = new org.apache.axis.description.OperationDesc[7];
        _initOperationDesc1();
    }

    private static void _initOperationDesc1() {
        org.apache.axis.description.OperationDesc oper;
        org.apache.axis.description.ParameterDesc param;
        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("AddUser");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);

        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);

        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userType"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "UserType"),
                com.windsor.node.service.helper.naas.usrmgr.UserType.class,
                false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "confirmUserPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);

        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "affiliate"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);

        oper.setReturnType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[0] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("DeleteUser");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[1] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("UpdateUser");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userType"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "UserType"),
                com.windsor.node.service.helper.naas.usrmgr.UserType.class,
                false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "owner"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "affiliate"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[2] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("SetUserProperty");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "UserId"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "CommonName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "Organization"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "OrganizationUnit"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "Address"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "City"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "State"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "ZipCode"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "Phone"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "Supervisor"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "SupervisorPhone"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "UserData"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "SecurityLevel"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "CertificateStatus"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "LastChange"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[3] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("GetUserProperty");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserPropertyList"));
        oper
                .setReturnClass(com.windsor.node.service.helper.naas.usrmgr.UserProperty[].class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[4] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("GetUserList");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminName"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "adminPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userState"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "rowId"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "integer"),
                java.math.BigInteger.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "maxRows"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "integer"),
                java.math.BigInteger.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserList"));
        oper
                .setReturnClass(com.windsor.node.service.helper.naas.usrmgr.UserInfo[].class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[5] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("ChangePwd");
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "userEmail"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://www.w3.org/2001/XMLSchema", "string"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "password"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(
                new javax.xml.namespace.QName("", "newPwd"),
                org.apache.axis.description.ParameterDesc.IN,
                new javax.xml.namespace.QName(
                        "http://neien.org/schema/usermgr.xsd", "PasswordType"),
                java.lang.String.class, false, false);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        oper.setReturnClass(java.lang.String.class);
        oper.setReturnQName(new javax.xml.namespace.QName("", "return"));
        oper.setStyle(org.apache.axis.constants.Style.RPC);
        oper.setUse(org.apache.axis.constants.Use.ENCODED);
        _operations[6] = oper;

    }

    public UserMgrBindingStub() throws org.apache.axis.AxisFault {
        this(null);
        this.setTimeout(TIMEOUT_IN_MIL_SEC);
    }

    public UserMgrBindingStub(java.net.URL endpointURL,
            javax.xml.rpc.Service service) throws org.apache.axis.AxisFault {
        this(service);
        super.cachedEndpoint = endpointURL;
    }

    public UserMgrBindingStub(javax.xml.rpc.Service service)
            throws org.apache.axis.AxisFault {
        if (service == null) {
            super.service = new org.apache.axis.client.Service();
        } else {
            super.service = service;
        }
        ((org.apache.axis.client.Service) super.service)
                .setTypeMappingVersion("1.2");
        java.lang.Class cls;
        javax.xml.namespace.QName qName;
        javax.xml.namespace.QName qName2;
        java.lang.Class beansf = org.apache.axis.encoding.ser.BeanSerializerFactory.class;
        java.lang.Class beandf = org.apache.axis.encoding.ser.BeanDeserializerFactory.class;
        java.lang.Class enumsf = org.apache.axis.encoding.ser.EnumSerializerFactory.class;
        java.lang.Class enumdf = org.apache.axis.encoding.ser.EnumDeserializerFactory.class;
        // java.lang.Class arraysf =
        // org.apache.axis.encoding.ser.ArraySerializerFactory.class;
        // java.lang.Class arraydf =
        // org.apache.axis.encoding.ser.ArrayDeserializerFactory.class;
        // java.lang.Class simplesf =
        // org.apache.axis.encoding.ser.SimpleSerializerFactory.class;
        // java.lang.Class simpledf =
        // org.apache.axis.encoding.ser.SimpleDeserializerFactory.class;
        // java.lang.Class simplelistsf =
        // org.apache.axis.encoding.ser.SimpleListSerializerFactory.class;
        // java.lang.Class simplelistdf =
        // org.apache.axis.encoding.ser.SimpleListDeserializerFactory.class;
        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "PasswordType");
        cachedSerQNames.add(qName);
        cls = java.lang.String.class;
        cachedSerClasses.add(cls);
        cachedSerFactories
                .add(org.apache.axis.encoding.ser.BaseSerializerFactory
                        .createFactory(
                                org.apache.axis.encoding.ser.SimpleSerializerFactory.class,
                                cls, qName));
        cachedDeserFactories
                .add(org.apache.axis.encoding.ser.BaseDeserializerFactory
                        .createFactory(
                                org.apache.axis.encoding.ser.SimpleDeserializerFactory.class,
                                cls, qName));

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "StateId");
        cachedSerQNames.add(qName);
        cls = java.lang.String.class;
        cachedSerClasses.add(cls);
        cachedSerFactories.add(enumsf);
        cachedDeserFactories.add(enumdf);

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserInfo");
        cachedSerQNames.add(qName);
        cls = com.windsor.node.service.helper.naas.usrmgr.UserInfo.class;
        cachedSerClasses.add(cls);
        cachedSerFactories.add(beansf);
        cachedDeserFactories.add(beandf);

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserList");
        cachedSerQNames.add(qName);
        cls = com.windsor.node.service.helper.naas.usrmgr.UserInfo[].class;
        cachedSerClasses.add(cls);
        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserInfo");
        qName2 = null;
        cachedSerFactories
                .add(new org.apache.axis.encoding.ser.ArraySerializerFactory(
                        qName, qName2));
        cachedDeserFactories
                .add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserProperty");
        cachedSerQNames.add(qName);
        cls = com.windsor.node.service.helper.naas.usrmgr.UserProperty.class;
        cachedSerClasses.add(cls);
        cachedSerFactories.add(beansf);
        cachedDeserFactories.add(beandf);

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserPropertyList");
        cachedSerQNames.add(qName);
        cls = com.windsor.node.service.helper.naas.usrmgr.UserProperty[].class;
        cachedSerClasses.add(cls);
        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserProperty");
        qName2 = null;
        cachedSerFactories
                .add(new org.apache.axis.encoding.ser.ArraySerializerFactory(
                        qName, qName2));
        cachedDeserFactories
                .add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

        qName = new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserType");
        cachedSerQNames.add(qName);
        cls = com.windsor.node.service.helper.naas.usrmgr.UserType.class;
        cachedSerClasses.add(cls);
        cachedSerFactories.add(enumsf);
        cachedDeserFactories.add(enumdf);

    }

    protected org.apache.axis.client.Call createCall()
            throws java.rmi.RemoteException {
        try {
            org.apache.axis.client.Call _call = super._createCall();
            if (super.maintainSessionSet) {
                _call.setMaintainSession(super.maintainSession);
            }
            if (super.cachedUsername != null) {
                _call.setUsername(super.cachedUsername);
            }
            if (super.cachedPassword != null) {
                _call.setPassword(super.cachedPassword);
            }
            if (super.cachedEndpoint != null) {
                _call.setTargetEndpointAddress(super.cachedEndpoint);
            }

            _call.setTimeout(new Integer(TIMEOUT_IN_MIL_SEC));

            if (super.cachedPortName != null) {
                _call.setPortName(super.cachedPortName);
            }
            java.util.Enumeration keys = super.cachedProperties.keys();
            while (keys.hasMoreElements()) {
                java.lang.String key = (java.lang.String) keys.nextElement();
                _call.setProperty(key, super.cachedProperties.get(key));
            }
            // All the type mapping information is registered
            // when the first call is made.
            // The type mapping information is actually registered in
            // the TypeMappingRegistry of the service, which
            // is the reason why registration is only needed for the first call.
            synchronized (this) {
                if (firstCall()) {
                    // must set encoding style before registering serializers
                    _call
                            .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
                    _call
                            .setEncodingStyle(org.apache.axis.Constants.URI_SOAP11_ENC);
                    for (int i = 0; i < cachedSerFactories.size(); ++i) {
                        java.lang.Class cls = (java.lang.Class) cachedSerClasses
                                .get(i);
                        javax.xml.namespace.QName qName = (javax.xml.namespace.QName) cachedSerQNames
                                .get(i);
                        java.lang.Object x = cachedSerFactories.get(i);
                        if (x instanceof Class) {
                            java.lang.Class sf = (java.lang.Class) cachedSerFactories
                                    .get(i);
                            java.lang.Class df = (java.lang.Class) cachedDeserFactories
                                    .get(i);
                            _call
                                    .registerTypeMapping(cls, qName, sf, df,
                                            false);
                        } else if (x instanceof javax.xml.rpc.encoding.SerializerFactory) {
                            org.apache.axis.encoding.SerializerFactory sf = (org.apache.axis.encoding.SerializerFactory) cachedSerFactories
                                    .get(i);
                            org.apache.axis.encoding.DeserializerFactory df = (org.apache.axis.encoding.DeserializerFactory) cachedDeserFactories
                                    .get(i);
                            _call
                                    .registerTypeMapping(cls, qName, sf, df,
                                            false);
                        }
                    }
                }
            }
            return _call;
        } catch (java.lang.Throwable _t) {
            throw new org.apache.axis.AxisFault(
                    "Failure trying to get the Call object", _t);
        }
    }

    public java.lang.String addUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail,
            com.windsor.node.service.helper.naas.usrmgr.UserType userType,
            java.lang.String userPwd, java.lang.String confirmUserPwd,
            java.lang.String affiliate) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[0]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "AddUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    adminName, adminPwd, userEmail, userType, userPwd,
                    confirmUserPwd, affiliate });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (java.lang.String) _resp;
                } catch (java.lang.Exception _exception) {
                    return (java.lang.String) org.apache.axis.utils.JavaUtils
                            .convert(_resp, java.lang.String.class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

    public java.lang.String deleteUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[1]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "DeleteUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    adminName, adminPwd, userEmail });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (java.lang.String) _resp;
                } catch (java.lang.Exception _exception) {
                    return (java.lang.String) org.apache.axis.utils.JavaUtils
                            .convert(_resp, java.lang.String.class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

    public java.lang.String updateUser(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userEmail,
            com.windsor.node.service.helper.naas.usrmgr.UserType userType,
            java.lang.String userPwd, java.lang.String owner,
            java.lang.String affiliate) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[2]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UpdateUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    adminName, adminPwd, userEmail, userType, userPwd, owner,
                    affiliate });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (java.lang.String) _resp;
                } catch (java.lang.Exception _exception) {
                    return (java.lang.String) org.apache.axis.utils.JavaUtils
                            .convert(_resp, java.lang.String.class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

    public java.lang.String setUserProperty(java.lang.String adminName,
            java.lang.String adminPwd, java.lang.String userId,
            java.lang.String commonName, java.lang.String organization,
            java.lang.String organizationUnit, java.lang.String address,
            java.lang.String city, java.lang.String state,
            java.lang.String zipCode, java.lang.String phone,
            java.lang.String supervisor, java.lang.String supervisorPhone,
            java.lang.String userData, java.lang.String securityLevel,
            java.lang.String certificateStatus, java.lang.String lastChange)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[3]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "SetUserProperty"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    adminName, adminPwd, userId, commonName, organization,
                    organizationUnit, address, city, state, zipCode, phone,
                    supervisor, supervisorPhone, userData, securityLevel,
                    certificateStatus, lastChange });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (java.lang.String) _resp;
                } catch (java.lang.Exception _exception) {
                    return (java.lang.String) org.apache.axis.utils.JavaUtils
                            .convert(_resp, java.lang.String.class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

    public com.windsor.node.service.helper.naas.usrmgr.UserProperty[] getUserProperty(
            java.lang.String adminName, java.lang.String adminPwd,
            java.lang.String userEmail) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[4]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "GetUserProperty"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    adminName, adminPwd, userEmail });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (com.windsor.node.service.helper.naas.usrmgr.UserProperty[]) _resp;
                } catch (java.lang.Exception _exception) {
                    return (com.windsor.node.service.helper.naas.usrmgr.UserProperty[]) org.apache.axis.utils.JavaUtils
                            .convert(
                                    _resp,
                                    com.windsor.node.service.helper.naas.usrmgr.UserProperty[].class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

    public com.windsor.node.service.helper.naas.usrmgr.UserInfo[] getUserList(
            java.lang.String adminName, java.lang.String adminPwd,
            java.lang.String userEmail, java.lang.String userState,
            java.math.BigInteger rowId, java.math.BigInteger maxRows)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[5]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "GetUserList"));

        _call.setTimeout(new Integer(TIMEOUT_IN_MIL_SEC));
        setRequestHeaders(_call);
        setAttachments(_call);

        try {

            Object _resp = _call.invoke(new Object[] { adminName, adminPwd,
                    userEmail, userState, rowId, maxRows });

            if (_resp instanceof RemoteException) {

                throw (RemoteException) _resp;

            } else {

                extractAttachments(_call);

                try {

                    return (com.windsor.node.service.helper.naas.usrmgr.UserInfo[]) _resp;

                } catch (Exception _exception) {

                    return (com.windsor.node.service.helper.naas.usrmgr.UserInfo[]) org.apache.axis.utils.JavaUtils
                            .convert(
                                    _resp,
                                    com.windsor.node.service.helper.naas.usrmgr.UserInfo[].class);

                }
            }

        } catch (Exception ex) {
            throw new RemoteException("Error: " + ex.getMessage(), ex);
        }

    }

    public java.lang.String changePwd(java.lang.String userEmail,
            java.lang.String password, java.lang.String newPwd)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[6]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("");
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "ChangePwd"));

        setRequestHeaders(_call);
        setAttachments(_call);
        try {
            java.lang.Object _resp = _call.invoke(new java.lang.Object[] {
                    userEmail, password, newPwd });

            if (_resp instanceof java.rmi.RemoteException) {
                throw (java.rmi.RemoteException) _resp;
            } else {
                extractAttachments(_call);
                try {
                    return (java.lang.String) _resp;
                } catch (java.lang.Exception _exception) {
                    return (java.lang.String) org.apache.axis.utils.JavaUtils
                            .convert(_resp, java.lang.String.class);
                }
            }
        } catch (org.apache.axis.AxisFault axisFaultException) {
            throw axisFaultException;
        }
    }

}
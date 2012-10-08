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
 * AQDEDataLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis WSDL2Java emitter.
 */

package com.windsor.node.plugin.aqs.wsdl;

import java.net.URL;

import javax.xml.rpc.ServiceException;

public class AQDEDataLocator extends org.apache.axis.client.Service implements
        AQDEData {

    public static final long serialVersionUID = 1;

    // Use to get a proxy class for AQDEDataSoap12
    private final java.lang.String AQDEDataSoap12_address = "http://134.179.217.247/reporter/AQDEData.asmx";

    public java.lang.String getAQDEDataSoap12Address() {
        return AQDEDataSoap12_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String AQDEDataSoap12WSDDServiceName = "AQDEDataSoap12";

    public java.lang.String getAQDEDataSoap12WSDDServiceName() {
        return AQDEDataSoap12WSDDServiceName;
    }

    public void setAQDEDataSoap12WSDDServiceName(java.lang.String name) {
        AQDEDataSoap12WSDDServiceName = name;
    }

    // Use to get a proxy class for AQDEDataSoap
    private final java.lang.String AQDEDataSoap_address = "http://134.179.217.247/reporter/AQDEData.asmx";

    public java.lang.String getAQDEDataSoapAddress() {
        return AQDEDataSoap_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String AQDEDataSoapWSDDServiceName = "AQDEDataSoap";

    public java.lang.String getAQDEDataSoapWSDDServiceName() {
        return AQDEDataSoapWSDDServiceName;
    }

    public void setAQDEDataSoapWSDDServiceName(java.lang.String name) {
        AQDEDataSoapWSDDServiceName = name;
    }

    public AQDEDataSoap getAQDEDataSoap() throws javax.xml.rpc.ServiceException {
        java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(AQDEDataSoap_address);
        } catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getAQDEDataSoap(endpoint);
    }

    public AQDEDataSoap getAQDEDataSoap(java.net.URL portAddress)
            throws javax.xml.rpc.ServiceException {
        try {
            AQDEDataSoapStub _stub = new AQDEDataSoapStub(portAddress, this);
            _stub.setPortName(getAQDEDataSoapWSDDServiceName());
            return _stub;
        } catch (Exception e) {
            return null;
        }
    }

    public AQDEDataSoap getAQDEDataSoap12() throws ServiceException {
        throw new RuntimeException("Soap12 Not supported");
    }

    public AQDEDataSoap getAQDEDataSoap12(URL portAddress)
            throws ServiceException {
        throw new RuntimeException("Soap12 Not supported");
    }

    public java.rmi.Remote getPort(Class serviceEndpointInterface)
            throws ServiceException {
        try {

            AQDEDataSoapStub _stub = new AQDEDataSoapStub(new java.net.URL(
                    AQDEDataSoap_address), this);

            _stub.setPortName(getAQDEDataSoapWSDDServiceName());

            return _stub;

        } catch (Throwable t) {
            throw new RuntimeException(t);
        }

    }

    /**
     * For the given interface, get the stub implementation. If this service has
     * no port for the given interface, then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(javax.xml.namespace.QName portName,
            Class serviceEndpointInterface)
            throws javax.xml.rpc.ServiceException {
        if (portName == null) {
            return getPort(serviceEndpointInterface);
        }
        String inputPortName = portName.getLocalPart();
        if ("AQDEDataSoap12".equals(inputPortName)) {
            return getAQDEDataSoap12();
        } else if ("AQDEDataSoap".equals(inputPortName)) {
            return getAQDEDataSoap();
        } else {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName(
                "urn:schemas-drdas-com:reporter.aqde.webservice", "AQDEData");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("AQDEDataSoap12"));
            ports.add(new javax.xml.namespace.QName("AQDEDataSoap"));
        }
        return ports.iterator();
    }

}
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
 * AQDEDataSoapStub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis WSDL2Java emitter.
 */

package com.windsor.node.plugin.aqs.wsdl;

import java.rmi.RemoteException;

import org.apache.axis.utils.JavaUtils;
import org.apache.log4j.Logger;

public class AQDEDataSoapStub extends org.apache.axis.client.Stub implements
        AQDEDataSoap {

    private static final Logger logger = Logger
            .getLogger(AQDEDataSoapStub.class);

    static org.apache.axis.description.OperationDesc[] _operations;

    static {

        logger.debug("AQDEDataSoapStub.static");

        try {

            _operations = new org.apache.axis.description.OperationDesc[3];

            org.apache.axis.description.OperationDesc oper = new org.apache.axis.description.OperationDesc();

            oper.setName("solicitAQSRawData");

            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FileGenerationPurposeCode"),
                    new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "BeginDate"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "BeginTime"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(
                    new javax.xml.namespace.QName(
                            "urn:schemas-drdas-com:reporter.aqde.webservice",
                            "EndDate"), new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(
                    new javax.xml.namespace.QName(
                            "urn:schemas-drdas-com:reporter.aqde.webservice",
                            "EndTime"), new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "TimeType"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SampleDuration"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SubstanceName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MonitorType"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "DataValidityCode"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "DataApprovalIndicator"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "StateName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CountyName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CityName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "TribeName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FacilitySiteIdentifier"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "LastUpdatedDate"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "IncludeMonitorDetails"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "IncludeEventData"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SchemaVersion"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "RequestId"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CompressionEnabled"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.setReturnType(new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"));
            oper.setReturnClass(java.lang.String.class);
            oper.setReturnQName(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "solicitAQSRawDataResult"));
            // change for JDK 1.5
            oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
            oper.setUse(org.apache.axis.constants.Use.LITERAL);
            // oper.setStyle(org.apache.axis.enum.Style.WRAPPED);
            // oper.setUse(org.apache.axis.enum.Use.LITERAL);
            _operations[0] = oper;

            oper = new org.apache.axis.description.OperationDesc();
            oper.setName("queryAQSRawData");
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FileGenerationPurposeCode"),
                    new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "BeginDate"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "BeginTime"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(
                    new javax.xml.namespace.QName(
                            "urn:schemas-drdas-com:reporter.aqde.webservice",
                            "EndDate"), new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(
                    new javax.xml.namespace.QName(
                            "urn:schemas-drdas-com:reporter.aqde.webservice",
                            "EndTime"), new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "TimeType"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SampleDuration"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SubstanceName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MonitorType"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "DataValidityCode"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "DataApprovalIndicator"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "StateName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CountyName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CityName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "TribeName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FacilitySiteIdentifier"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "LastUpdatedDate"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "IncludeMonitorDetails"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "IncludeEventData"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SchemaVersion"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.setReturnType(new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"));
            oper.setReturnClass(java.lang.String.class);
            oper.setReturnQName(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "queryAQSRawDataResult"));
            // change for JDK 1.5
            oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
            oper.setUse(org.apache.axis.constants.Use.LITERAL);
            // oper.setStyle(org.apache.axis.enum.Style.WRAPPED);
            // oper.setUse(org.apache.axis.enum.Use.LITERAL);
            _operations[1] = oper;

            oper = new org.apache.axis.description.OperationDesc();
            oper.setName("queryAQSMonitorData");
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FileGenerationPurposeCode"),
                    new javax.xml.namespace.QName(
                            "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SubstanceName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MonitorType"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "StateName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CountyName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "CityName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "TribeName"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "FacilitySiteIdentifier"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLatitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MinLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "MaxLongitudeMeasure"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "LastUpdatedDate"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.addParameter(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "SchemaVersion"), new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"),
                    java.lang.String.class,
                    org.apache.axis.description.ParameterDesc.IN, false, false);
            oper.setReturnType(new javax.xml.namespace.QName(
                    "http://www.w3.org/2001/XMLSchema", "string"));
            oper.setReturnClass(java.lang.String.class);
            oper.setReturnQName(new javax.xml.namespace.QName(
                    "urn:schemas-drdas-com:reporter.aqde.webservice",
                    "queryAQSMonitorDataResult"));
            // change for JDK 1.5
            oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
            oper.setUse(org.apache.axis.constants.Use.LITERAL);
            // oper.setStyle(org.apache.axis.enum.Style.WRAPPED);
            // oper.setUse(org.apache.axis.enum.Use.LITERAL);
            _operations[2] = oper;

        } catch (Throwable thr) {
            logger.error(thr.getMessage(), thr);
            throw new RuntimeException(
                    "Error while static initializing AQDEDataSoapStub: "
                            + thr.getMessage(), thr);
        }

    }

    public AQDEDataSoapStub(java.net.URL endpointURL,
            javax.xml.rpc.Service service) {

        logger.debug("new AQDEDataSoapStub");

        try {
            super.service = new org.apache.axis.client.Service();
            super.cachedEndpoint = endpointURL;
            this.setTimeout((1000 * 60) * 60);
        } catch (Throwable thr) {
            logger.error(thr.getMessage(), thr);
            throw new RuntimeException(
                    "Error while new initializing AQDEDataSoapStub: "
                            + thr.getMessage(), thr);
        }

    }

    private org.apache.axis.client.Call createCall()
            throws java.rmi.RemoteException {
        try {
            org.apache.axis.client.Call _call = (org.apache.axis.client.Call) super.service
                    .createCall();
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
            if (super.cachedPortName != null) {
                _call.setPortName(super.cachedPortName);
            }
            java.util.Enumeration keys = super.cachedProperties.keys();
            while (keys.hasMoreElements()) {
                java.lang.String key = (java.lang.String) keys.nextElement();
                _call.setProperty(key, super.cachedProperties.get(key));
            }

            _call.setTimeout(new Integer((1000 * 60) * 60));

            return _call;
        } catch (java.lang.Throwable t) {
            throw new org.apache.axis.AxisFault(
                    "Failure trying to get the Call object", t);
        }
    }

    public java.lang.String solicitAQSRawData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String beginDate, java.lang.String beginTime,
            java.lang.String endDate, java.lang.String endTime,
            java.lang.String timeType, java.lang.String sampleDuration,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String dataValidityCode,
            java.lang.String dataApprovalIndicator, java.lang.String stateName,
            java.lang.String countyName, java.lang.String cityName,
            java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate,
            java.lang.String includeMonitorDetails,
            java.lang.String includeEventData, java.lang.String schemaVersion,
            java.lang.String requestId, java.lang.String compressionEnabled)
            throws java.rmi.RemoteException {

        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[0]);
        _call.setUseSOAPAction(true);
        _call
                .setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/solicitAQSRawData");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR,
                Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS,
                Boolean.FALSE);
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "urn:schemas-drdas-com:reporter.aqde.webservice",
                "solicitAQSRawData"));

        setRequestHeaders(_call);
        setAttachments(_call);

        Object[] argsToSend = new java.lang.Object[] {
                fileGenerationPurposeCode, beginDate, beginTime, endDate,
                endTime, timeType, sampleDuration, substanceName, monitorType,
                dataValidityCode, dataApprovalIndicator, stateName, countyName,
                cityName, tribeName, facilitySiteIdentifier,
                minLatitudeMeasure, maxLatitudeMeasure, minLongitudeMeasure,
                maxLongitudeMeasure, lastUpdatedDate, includeMonitorDetails,
                includeEventData, schemaVersion, requestId, compressionEnabled };

        try {

            java.lang.Object _resp = _call.invoke(argsToSend);

            if (_resp instanceof RemoteException) {
                throw (RemoteException) _resp;
            }

            return (String) JavaUtils.convert(_resp, String.class);

        } catch (Exception ex) {

            throw new RuntimeException("Error while executting remote call: "
                    + ex.getMessage() + " Args: " + argsToString(argsToSend));
        }
    }

    private String argsToString(Object[] args) {

        StringBuffer sb = new StringBuffer();
        sb.append("\n");

        for (int i = 0; i < args.length; i++) {
            sb.append("" + i + " = '" + args[i] + "'\n");
        }

        return sb.toString();

    }

    public java.lang.String queryAQSRawData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String beginDate, java.lang.String beginTime,
            java.lang.String endDate, java.lang.String endTime,
            java.lang.String timeType, java.lang.String sampleDuration,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String dataValidityCode,
            java.lang.String dataApprovalIndicator, java.lang.String stateName,
            java.lang.String countyName, java.lang.String cityName,
            java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate,
            java.lang.String includeMonitorDetails,
            java.lang.String includeEventData, java.lang.String schemaVersion)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[1]);
        _call.setUseSOAPAction(true);
        _call
                .setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSRawData");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR,
                Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS,
                Boolean.FALSE);
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "urn:schemas-drdas-com:reporter.aqde.webservice",
                "queryAQSRawData"));

        setRequestHeaders(_call);
        setAttachments(_call);

        Object[] argsToSend = new java.lang.Object[] {
                fileGenerationPurposeCode, beginDate, beginTime, endDate,
                endTime, timeType, sampleDuration, substanceName, monitorType,
                dataValidityCode, dataApprovalIndicator, stateName, countyName,
                cityName, tribeName, facilitySiteIdentifier,
                minLatitudeMeasure, maxLatitudeMeasure, minLongitudeMeasure,
                maxLongitudeMeasure, lastUpdatedDate, includeMonitorDetails,
                includeEventData, schemaVersion };

        try {

            java.lang.Object _resp = _call.invoke(argsToSend);

            if (_resp instanceof RemoteException) {
                throw (RemoteException) _resp;
            }

            return (String) JavaUtils.convert(_resp, String.class);

        } catch (Exception ex) {

            throw new RuntimeException("Error while executting remote call: "
                    + ex.getMessage() + " Args: " + argsToString(argsToSend));
        }
    }

    public java.lang.String queryAQSMonitorData(
            java.lang.String fileGenerationPurposeCode,
            java.lang.String substanceName, java.lang.String monitorType,
            java.lang.String stateName, java.lang.String countyName,
            java.lang.String cityName, java.lang.String tribeName,
            java.lang.String facilitySiteIdentifier,
            java.lang.String minLatitudeMeasure,
            java.lang.String maxLatitudeMeasure,
            java.lang.String minLongitudeMeasure,
            java.lang.String maxLongitudeMeasure,
            java.lang.String lastUpdatedDate, java.lang.String schemaVersion)
            throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[2]);
        _call.setUseSOAPAction(true);
        _call
                .setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSMonitorData");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR,
                Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS,
                Boolean.FALSE);
        _call
                .setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName(
                "urn:schemas-drdas-com:reporter.aqde.webservice",
                "queryAQSMonitorData"));

        setRequestHeaders(_call);
        setAttachments(_call);

        Object[] argsToSend = new java.lang.Object[] {
                fileGenerationPurposeCode, substanceName, monitorType,
                stateName, countyName, cityName, tribeName,
                facilitySiteIdentifier, minLatitudeMeasure, maxLatitudeMeasure,
                minLongitudeMeasure, maxLongitudeMeasure, lastUpdatedDate,
                schemaVersion };

        try {

            java.lang.Object _resp = _call.invoke(argsToSend);

            if (_resp instanceof RemoteException) {
                throw (RemoteException) _resp;
            }

            return (String) JavaUtils.convert(_resp, String.class);

        } catch (Exception ex) {

            throw new RuntimeException("Error while executting remote call: "
                    + ex.getMessage() + " Args: " + argsToString(argsToSend));
        }
    }

}
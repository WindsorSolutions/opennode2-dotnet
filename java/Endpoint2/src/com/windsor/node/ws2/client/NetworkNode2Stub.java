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
 * NetworkNode2Stub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:24:30 EDT)
 */
package com.windsor.node.ws2.client;

import java.util.ArrayList;
import java.util.List;

import org.apache.axis2.transport.http.HTTPConstants;
import org.apache.commons.httpclient.Header;
import org.apache.log4j.Logger;

import com.windsor.node.ws2.Endpoint2FaultMessage;
import com.windsor.node.ws2.util.FaultUtil;

/*
 * NetworkNode2Stub java implementation
 */

public class NetworkNode2Stub extends org.apache.axis2.client.Stub {

    private static final Logger logger = Logger
            .getLogger(NetworkNode2Stub.class.getName());

    protected org.apache.axis2.description.AxisOperation[] _operations;

    private static int counter = 0;

    private final List headers = new ArrayList();
    private static final long soTimeout = 30 * 60 * 1000; // 30 minutes

    private static synchronized String getUniqueSuffix() {
        // reset the counter if it is greater than 99999
        if (counter > 99999) {
            counter = 0;
        }
        counter = counter + 1;
        return Long.toString(System.currentTimeMillis()) + "_" + counter;
    }

    private void populateAxisService() throws org.apache.axis2.AxisFault {

        // creating the Service with a unique name
        _service = new org.apache.axis2.description.AxisService("NetworkNode2"
                + getUniqueSuffix());
        addAnonymousOperations();

        // creating the operations
        org.apache.axis2.description.AxisOperation __operation;

        _operations = new org.apache.axis2.description.AxisOperation[10];

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Execute"));
        _service.addOperation(__operation);
        _operations[0] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Authenticate"));
        _service.addOperation(__operation);
        _operations[1] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Download"));
        _service.addOperation(__operation);
        _operations[2] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "GetStatus"));
        _service.addOperation(__operation);
        _operations[3] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "NodePing"));
        _service.addOperation(__operation);
        _operations[4] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "GetServices"));
        _service.addOperation(__operation);
        _operations[5] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Submit"));
        _service.addOperation(__operation);
        _operations[6] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Notify"));
        _service.addOperation(__operation);
        _operations[7] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Solicit"));
        _service.addOperation(__operation);
        _operations[8] = __operation;

        __operation = new org.apache.axis2.description.OutInAxisOperation();
        __operation.setName(new javax.xml.namespace.QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Query"));
        _service.addOperation(__operation);
        _operations[9] = __operation;

    }

    /**
     * Constructor
     * 
     * @param configurationContext
     * @param targetEndpoint
     * @param useSeparateListener
     * @throws org.apache.axis2.AxisFault
     */
    public NetworkNode2Stub(
            org.apache.axis2.context.ConfigurationContext configurationContext,
            String targetEndpoint, boolean useSeparateListener)
            throws org.apache.axis2.AxisFault {

        logger.debug("Creating endpoint stub: " + targetEndpoint);

        // To populate AxisService
        populateAxisService();

        _serviceClient = new org.apache.axis2.client.ServiceClient(
                configurationContext, _service);

        configurationContext = _serviceClient.getServiceContext()
                .getConfigurationContext();

        _serviceClient.getOptions().setTo(
                new org.apache.axis2.addressing.EndpointReference(
                        targetEndpoint));
        _serviceClient.getOptions().setUseSeparateListener(useSeparateListener);

        // Set the soap version
        _serviceClient
                .getOptions()
                .setSoapVersionURI(
                        org.apache.axiom.soap.SOAP12Constants.SOAP_ENVELOPE_NAMESPACE_URI);

        // WINDSOR HACKS
        logger.debug("Resetting action to empty string");
        _serviceClient.getOptions().setAction("\"\"");
        logger.debug("Resetting timeout to: " + soTimeout);
        _serviceClient.getOptions().setTimeOutInMilliSeconds(soTimeout);
        logger.debug("Adding empty SOAP ACTION header");
        headers.add(new Header(HTTPConstants.HEADER_SOAP_ACTION, ""));

        // TransportOutDescription tOut =
        // _serviceClient.getOptions().getTransportOut();
        // TransportSender tSender = tOut.getSender();
        // tSender.stop()

    }

    /**
     * Constructor taking the target endpoint
     */
    public NetworkNode2Stub(java.lang.String targetEndpoint)
            throws org.apache.axis2.AxisFault {
        this(null, targetEndpoint, false);
    }

    /**
     * Auto generated method signature Request the node to invoke a specified
     * web services.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Execute
     * @param execute0
     * 
     * @throws com.windsor.node.ws2.service.NodeFaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.ExecuteResponse Execute(
            net.exchangenetwork.www.schema.node._2.Execute execute0)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[0].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), execute0,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Execute")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.ExecuteResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.ExecuteResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature User authentication method, must be
     * called initially.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Authenticate
     * @param authenticate2
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.AuthenticateResponse Authenticate(
            net.exchangenetwork.www.schema.node._2.Authenticate authenticate2)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[1].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = toEnvelope(
                    getFactory(_operationClient.getOptions()
                            .getSoapVersionURI()), authenticate2,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Authenticate")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);

            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.AuthenticateResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.AuthenticateResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Download one or more documents from the
     * node
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Download
     * @param download4
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.DownloadResponse Download(
            net.exchangenetwork.www.schema.node._2.Download download4)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[2].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), download4,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Download")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.DownloadResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.DownloadResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Check the status of a transaction
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#GetStatus
     * @param getStatus6
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.GetStatusResponse GetStatus(
            net.exchangenetwork.www.schema.node._2.GetStatus getStatus6)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[3].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), getStatus6,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "GetStatus")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.GetStatusResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.GetStatusResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Check the status of the service
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#NodePing
     * @param nodePing8
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.NodePingResponse NodePing(
            net.exchangenetwork.www.schema.node._2.NodePing nodePing8)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[4].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), nodePing8,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "NodePing")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.NodePingResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.NodePingResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Query services offered by the node
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#GetServices
     * @param getServices10
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.GetServicesResponse GetServices(
            net.exchangenetwork.www.schema.node._2.GetServices getServices10)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[5].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), getServices10,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "GetServices")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.GetServicesResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.GetServicesResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Submit one or more documents to the node.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Submit
     * @param submit12
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.SubmitResponse Submit(
            net.exchangenetwork.www.schema.node._2.Submit submit12)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {

            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[6].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), submit12,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Submit")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message context to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.SubmitResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.SubmitResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Notify document availability, network
     * events, submission statuses
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Notify
     * @param notify14
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.NotifyResponse Notify(
            net.exchangenetwork.www.schema.node._2.Notify notify14)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[7].getName());
            /* setting an empty Action gives us interop w/.NET 2.0 services */
            // _operationClient.getOptions().setAction("\"\"");
            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), notify14,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Notify")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message context to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.NotifyResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.NotifyResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Solicit a lengthy database operation.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Solicit
     * @param solicit16
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.SolicitResponse Solicit(
            net.exchangenetwork.www.schema.node._2.Solicit solicit16)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {

            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[8].getName());
            /* setting an empty Action gives us interop w/.NET 2.0 services */
            // _operationClient.getOptions().setAction("\"\"");
            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), solicit16,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Solicit")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message context to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(
                    _returnEnv.getBody().getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.SolicitResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.SolicitResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * Auto generated method signature Execute a database query
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Query
     * @param query18
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     *             :
     */

    public net.exchangenetwork.www.schema.node._2.QueryResponse Query(
            net.exchangenetwork.www.schema.node._2.Query query18)
            throws java.rmi.RemoteException, Endpoint2FaultMessage {

        org.apache.axis2.context.MessageContext _messageContext = null;

        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient
                    .createClient(_operations[9].getName());

            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(
                    true);

            addPropertyToOperationClient(
                    _operationClient,
                    org.apache.axis2.description.WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR,
                    "&");

            // create a message context
            _messageContext = new org.apache.axis2.context.MessageContext();

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            env = toEnvelope(getFactory(_operationClient.getOptions()
                    .getSoapVersionURI()), query18,
                    optimizeContent(new javax.xml.namespace.QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Query")));

            // adding SOAP soap_headers
            _serviceClient.addHeadersToEnvelope(env);
            // set the message context with that soap envelope
            _messageContext.setEnvelope(env);

            // WINDSOR HACK
            _messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
            _messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);

            // add the message context to the operation client
            _operationClient.addMessageContext(_messageContext);

            // execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient
                    .getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext
                    .getEnvelope();

            java.lang.Object object = fromOM(_returnEnv.getBody()
                    .getFirstElement(),
                    net.exchangenetwork.www.schema.node._2.QueryResponse.class,
                    getEnvelopeNamespaces(_returnEnv));

            return (net.exchangenetwork.www.schema.node._2.QueryResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            _messageContext.getTransportOut().getSender().cleanup(
                    _messageContext);
        }
    }

    /**
     * A utility method that copies the namepaces from the SOAPEnvelope
     */
    private java.util.Map getEnvelopeNamespaces(
            org.apache.axiom.soap.SOAPEnvelope env) {
        java.util.Map returnMap = new java.util.HashMap();
        java.util.Iterator namespaceIterator = env.getAllDeclaredNamespaces();
        while (namespaceIterator.hasNext()) {
            org.apache.axiom.om.OMNamespace ns = (org.apache.axiom.om.OMNamespace) namespaceIterator
                    .next();
            returnMap.put(ns.getPrefix(), ns.getNamespaceURI());
        }
        return returnMap;
    }

    private javax.xml.namespace.QName[] opNameArray = null;

    private boolean optimizeContent(javax.xml.namespace.QName opName) {

        if (opNameArray == null) {
            return false;
        }
        for (int i = 0; i < opNameArray.length; i++) {
            if (opName.equals(opNameArray[i])) {
                return true;
            }
        }
        return false;
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Execute param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Execute.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Authenticate param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Authenticate.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Download param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Download.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.GetStatus param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.GetStatus.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.NodePing param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.NodePing.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.GetServices param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.GetServices.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Submit param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Submit.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Notify param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Notify.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Solicit param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Solicit.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Query param,
            boolean optimizeContent) throws org.apache.axis2.AxisFault {

        try {

            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Query.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }

    }

    private java.lang.Object fromOM(org.apache.axiom.om.OMElement param,
            java.lang.Class type, java.util.Map extraNamespaces)
            throws org.apache.axis2.AxisFault {

        logger.debug(param);

        try {

            if (net.exchangenetwork.www.schema.node._2.Execute.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Execute.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.ExecuteResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.ExecuteResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Authenticate.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Authenticate.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.AuthenticateResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.AuthenticateResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Download.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Download.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.DownloadResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.DownloadResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.GetStatus.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.GetStatus.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.GetStatusResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.GetStatusResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodePing.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodePing.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodePingResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodePingResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.GetServices.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.GetServices.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.GetServicesResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.GetServicesResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Submit.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Submit.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.SubmitResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.SubmitResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Notify.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Notify.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NotifyResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NotifyResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Solicit.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Solicit.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.SolicitResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.SolicitResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.Query.class.equals(type)) {

                return net.exchangenetwork.www.schema.node._2.Query.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.QueryResponse.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.QueryResponse.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

            if (net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.class
                    .equals(type)) {

                return net.exchangenetwork.www.schema.node._2.NodeFaultDetailType.Factory
                        .parse(param.getXMLStreamReaderWithoutCaching());

            }

        } catch (java.lang.Exception e) {
            throw org.apache.axis2.AxisFault.makeFault(e);
        }
        return null;
    }

}
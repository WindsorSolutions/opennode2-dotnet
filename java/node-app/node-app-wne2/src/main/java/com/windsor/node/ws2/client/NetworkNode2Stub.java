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

import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.xml.namespace.QName;

import net.exchangenetwork.www.schema.node._2.Authenticate;
import net.exchangenetwork.www.schema.node._2.AuthenticateResponse;
import net.exchangenetwork.www.schema.node._2.Download;
import net.exchangenetwork.www.schema.node._2.DownloadResponse;
import net.exchangenetwork.www.schema.node._2.Execute;
import net.exchangenetwork.www.schema.node._2.ExecuteResponse;
import net.exchangenetwork.www.schema.node._2.GetServices;
import net.exchangenetwork.www.schema.node._2.GetServicesResponse;
import net.exchangenetwork.www.schema.node._2.GetStatus;
import net.exchangenetwork.www.schema.node._2.GetStatusResponse;
import net.exchangenetwork.www.schema.node._2.NodeFaultDetailType;
import net.exchangenetwork.www.schema.node._2.NodePing;
import net.exchangenetwork.www.schema.node._2.NodePingResponse;
import net.exchangenetwork.www.schema.node._2.Notify;
import net.exchangenetwork.www.schema.node._2.NotifyResponse;
import net.exchangenetwork.www.schema.node._2.Query;
import net.exchangenetwork.www.schema.node._2.QueryResponse;
import net.exchangenetwork.www.schema.node._2.Solicit;
import net.exchangenetwork.www.schema.node._2.SolicitResponse;
import net.exchangenetwork.www.schema.node._2.Submit;
import net.exchangenetwork.www.schema.node._2.SubmitResponse;

import org.apache.axiom.om.OMElement;
import org.apache.axiom.om.OMNamespace;
import org.apache.axiom.soap.SOAP12Constants;
import org.apache.axiom.soap.SOAPEnvelope;
import org.apache.axiom.soap.SOAPFactory;
import org.apache.axis2.AxisFault;
import org.apache.axis2.Constants;
import org.apache.axis2.addressing.EndpointReference;
import org.apache.axis2.client.OperationClient;
import org.apache.axis2.client.ServiceClient;
import org.apache.axis2.client.Stub;
import org.apache.axis2.context.ConfigurationContext;
import org.apache.axis2.context.MessageContext;
import org.apache.axis2.databinding.ADBException;
import org.apache.axis2.description.AxisOperation;
import org.apache.axis2.description.AxisService;
import org.apache.axis2.description.OutInAxisOperation;
import org.apache.axis2.description.WSDL2Constants;
import org.apache.axis2.transport.http.HTTPConstants;
import org.apache.axis2.wsdl.WSDLConstants;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.ws2.Endpoint2FaultMessage;
import com.windsor.node.ws2.util.FaultUtil;

/*
 * NetworkNode2Stub java implementation
 */

public class NetworkNode2Stub extends Stub {

    /**
     * 
     */
    private static final int MAX_SUFFIX = 99999;

    protected org.apache.axis2.description.AxisOperation[] operations;

    private final Logger logger = LoggerFactory.getLogger(NetworkNode2Stub.class.getName());
    private static final long soTimeout = 30 * 60 * 1000; // 30 minutes

    private static int counter = 0;

    private final List<?> headers = new ArrayList<Object>();

    private QName[] opNameArray = null;

    /**
     * Constructor
     * 
     * @param configurationContext
     * @param targetEndpoint
     * @param useSeparateListener
     * @throws org.apache.axis2.AxisFault
     */
    public NetworkNode2Stub(ConfigurationContext configurationContext,
            String targetEndpoint, boolean useSeparateListener)
            throws org.apache.axis2.AxisFault {

        logger.debug("Creating endpoint stub: " + targetEndpoint);

        // To populate AxisService
        populateAxisService();

        _serviceClient = new ServiceClient(configurationContext, _service);

        _serviceClient.getOptions()
                .setTo(new EndpointReference(targetEndpoint));
        _serviceClient.getOptions().setUseSeparateListener(useSeparateListener);

        // Set the soap version
        _serviceClient.getOptions().setSoapVersionURI(
                SOAP12Constants.SOAP_ENVELOPE_NAMESPACE_URI);

        logger.debug("Resetting timeout to: " + soTimeout);
        _serviceClient.getOptions().setTimeOutInMilliSeconds(soTimeout);

    }

    /**
     * Constructor taking the datatarget endpoint
     */
    public NetworkNode2Stub(java.lang.String targetEndpoint) throws AxisFault {
        this(null, targetEndpoint, false);
    }

    /**
     * Auto generated method signature Request the node to invoke a specified
     * web services.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Execute
     * @param execute
     * 
     * @throws com.windsor.node.ws2.service.NodeFaultMessage
     * 
     */
    public ExecuteResponse Execute(Execute execute) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[0].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = toEnvelope(
                    getFactory(operationClient.getOptions().getSoapVersionURI()),
                    execute, optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Execute")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    ExecuteResponse.class, getEnvelopeNamespaces(returnEnv));

            return (ExecuteResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature User authentication method, must be
     * called initially.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Authenticate
     * @param authenticate
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     * 
     */
    public AuthenticateResponse Authenticate(Authenticate authenticate)
            throws RemoteException, Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[1].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), authenticate,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Authenticate")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    AuthenticateResponse.class,
                    getEnvelopeNamespaces(returnEnv));

            return (AuthenticateResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Download one or more documents from the
     * node
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Download
     * @param download
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public DownloadResponse Download(Download download) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[2].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), download,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Download")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    DownloadResponse.class, getEnvelopeNamespaces(returnEnv));

            return (DownloadResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Check the status of a transaction
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#GetStatus
     * @param getStatus
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public GetStatusResponse GetStatus(GetStatus getStatus)
            throws RemoteException, Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[3].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), getStatus,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "GetStatus")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    GetStatusResponse.class, getEnvelopeNamespaces(returnEnv));

            return (GetStatusResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Check the status of the service
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#NodePing
     * @param nodePing
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public NodePingResponse NodePing(NodePing nodePing) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            org.apache.axis2.client.OperationClient operationClient = _serviceClient
                    .createClient(operations[4].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), nodePing,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "NodePing")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    NodePingResponse.class, getEnvelopeNamespaces(returnEnv));

            return (NodePingResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Query services offered by the node
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#GetServices
     * @param getServices
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public GetServicesResponse GetServices(GetServices getServices)
            throws RemoteException, Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            org.apache.axis2.client.OperationClient operationClient = _serviceClient
                    .createClient(operations[5].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), getServices,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "GetServices")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    GetServicesResponse.class, getEnvelopeNamespaces(returnEnv));

            return (GetServicesResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Submit one or more documents to the node.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Submit
     * @param submit
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public SubmitResponse Submit(Submit submit) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {

            OperationClient operationClient = _serviceClient
                    .createClient(operations[6].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), submit,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Submit")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    SubmitResponse.class, getEnvelopeNamespaces(returnEnv));

            return (SubmitResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Notify document availability, network
     * events, submission statuses
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Notify
     * @param notify
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public NotifyResponse Notify(Notify notify) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[7].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), notify,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Notify")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    NotifyResponse.class, getEnvelopeNamespaces(returnEnv));

            return (NotifyResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Solicit a lengthy database operation.
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Solicit
     * @param solicit
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public SolicitResponse Solicit(Solicit solicit) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {

            OperationClient operationClient = _serviceClient
                    .createClient(operations[8].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), solicit,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Solicit")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    SolicitResponse.class, getEnvelopeNamespaces(returnEnv));

            return (SolicitResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * Auto generated method signature Execute a database query
     * 
     * @see com.windsor.node.ws2.client.NetworkNode2Client#Query
     * @param query
     * 
     * @throws com.windsor.node.ws2.Endpoint2FaultMessage
     */
    public QueryResponse Query(Query query) throws RemoteException,
            Endpoint2FaultMessage {

        MessageContext messageContext = null;

        try {
            OperationClient operationClient = _serviceClient
                    .createClient(operations[9].getName());

            configureOperationClient(operationClient);

            // create SOAP envelope with that payload
            SOAPEnvelope env = toEnvelope(getFactory(operationClient
                    .getOptions().getSoapVersionURI()), query,
                    optimizeContent(new QName(
                            "http://www.exchangenetwork.net/wsdl/node/2",
                            "Query")));

            messageContext = createMessageContext(env);

            SOAPEnvelope returnEnv = executeOperation(messageContext,
                    operationClient);

            Object object = fromOM(returnEnv.getBody().getFirstElement(),
                    QueryResponse.class, getEnvelopeNamespaces(returnEnv));

            return (QueryResponse) object;

        } catch (Exception gex) {
            throw FaultUtil.parseNodeFault(gex);
        } finally {
            messageContext.getTransportOut().getSender()
                    .cleanup(messageContext);
        }
    }

    /**
     * @param operationClient
     */
    private void configureOperationClient(OperationClient operationClient) {

        operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(true);

        addPropertyToOperationClient(operationClient,
                WSDL2Constants.ATTR_WHTTP_QUERY_PARAMETER_SEPARATOR, "&");

        /*
         * Disable pesky "action" in the HTTP content-type header. It shows up
         * in outgoing client requests regardless of how the "OmitSOAP12Action"
         * property in axis2.xml is configured.
         */
        addPropertyToOperationClient(operationClient,
                Constants.Configuration.DISABLE_SOAP_ACTION, Boolean.TRUE);
    }

    /**
     * @param env
     * @return
     * @throws AxisFault
     */
    private MessageContext createMessageContext(SOAPEnvelope env)
            throws AxisFault {
        MessageContext messageContext;
        // create a message context
        messageContext = new MessageContext();

        // set the message context with that soap envelope
        messageContext.setEnvelope(env);

        // eliminate the CONTENT_LENGTH http header to avoid problems
        // w/Microsoft's ISA Server
        messageContext.setProperty(HTTPConstants.HTTP_HEADERS, headers);
        messageContext.removeProperty(HTTPConstants.HEADER_CONTENT_LENGTH);
        return messageContext;
    }

    /**
     * @param messageContext
     * @param operationClient
     * @return
     * @throws AxisFault
     */
    private SOAPEnvelope executeOperation(MessageContext messageContext,
            OperationClient operationClient) throws AxisFault {
        operationClient.addMessageContext(messageContext);

        operationClient.execute(true);

        MessageContext returnMessageContext = operationClient
                .getMessageContext(WSDLConstants.MESSAGE_LABEL_IN_VALUE);
        SOAPEnvelope returnEnv = returnMessageContext.getEnvelope();
        return returnEnv;
    }

    /**
     * A utility method that copies the namepaces from the SOAPEnvelope
     */
    private Map<String, String> getEnvelopeNamespaces(SOAPEnvelope env) {

        Map<String, String> returnMap = new HashMap<String, String>();
        Iterator<?> namespaceIterator = env.getAllDeclaredNamespaces();

        while (namespaceIterator.hasNext()) {
            OMNamespace ns = (OMNamespace) namespaceIterator.next();
            returnMap.put(ns.getPrefix(), ns.getNamespaceURI());
        }
        return returnMap;
    }

    private static synchronized String getUniqueSuffix() {
        // reset the counter if it is greater than 99999
        if (counter > MAX_SUFFIX) {
            counter = 0;
        }
        counter = counter + 1;
        return Long.toString(System.currentTimeMillis()) + "_" + counter;
    }

    private void populateAxisService() throws org.apache.axis2.AxisFault {

        // creating the Service with a unique name
        _service = new AxisService("NetworkNode2" + getUniqueSuffix());
        addAnonymousOperations();

        // creating the operations
        AxisOperation operation;

        operations = new AxisOperation[10];

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Execute"));
        _service.addOperation(operation);
        operations[0] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Authenticate"));
        _service.addOperation(operation);
        operations[1] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Download"));
        _service.addOperation(operation);
        operations[2] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "GetStatus"));
        _service.addOperation(operation);
        operations[3] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "NodePing"));
        _service.addOperation(operation);
        operations[4] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "GetServices"));
        _service.addOperation(operation);
        operations[5] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Submit"));
        _service.addOperation(operation);
        operations[6] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Notify"));
        _service.addOperation(operation);
        operations[7] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Solicit"));
        _service.addOperation(operation);
        operations[8] = operation;

        operation = new OutInAxisOperation();
        operation.setName(new QName(
                "http://www.exchangenetwork.net/wsdl/node/2", "Query"));
        _service.addOperation(operation);
        operations[9] = operation;

    }

    private boolean optimizeContent(QName opName) {

        boolean b = false;

        if (null != opNameArray) {
            for (QName q : opNameArray) {
                if (opName.equals(q)) {
                    b = true;
                }
            }
        }

        return b;
    }

    private SOAPEnvelope toEnvelope(SOAPFactory factory, Execute param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope.getBody().addChild(
                    param.getOMElement(Execute.MY_QNAME, factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide backward compatibility */
    private SOAPEnvelope toEnvelope(SOAPFactory factory, Authenticate param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope.getBody().addChild(
                    param.getOMElement(Authenticate.MY_QNAME, factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Download param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Download.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.GetStatus param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.GetStatus.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.NodePing param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.NodePing.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.GetServices param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.GetServices.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Submit param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Submit.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Notify param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Notify.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide back word compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Solicit param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope
                    .getBody()
                    .addChild(
                            param
                                    .getOMElement(
                                            net.exchangenetwork.www.schema.node._2.Solicit.MY_QNAME,
                                            factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    /* methods to provide backward compatibility */
    private SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory,
            net.exchangenetwork.www.schema.node._2.Query param,
            boolean optimizeContent) throws AxisFault {

        try {

            SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
            emptyEnvelope.getBody().addChild(
                    param.getOMElement(Query.MY_QNAME, factory));
            return emptyEnvelope;
        } catch (ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    private Object fromOM(OMElement param, Class<?> type,
            Map<String, String> extraNamespaces) throws AxisFault {

        Object o = null;

        if(param != null)
        {
            logger.debug(param.toString());
        }
        else
        {
            logger.debug("OMElement param was null");
        }

        try {

            if (Execute.class.equals(type)) {

                o = Execute.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (ExecuteResponse.class.equals(type)) {

                o = ExecuteResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Authenticate.class.equals(type)) {

                o = Authenticate.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (AuthenticateResponse.class.equals(type)) {

                o = AuthenticateResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Download.class.equals(type)) {

                o = Download.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (DownloadResponse.class.equals(type)) {

                o = DownloadResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (GetStatus.class.equals(type)) {

                o = GetStatus.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (GetStatusResponse.class.equals(type)) {

                o = GetStatusResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodePing.class.equals(type)) {

                o = NodePing.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodePingResponse.class.equals(type)) {

                o = NodePingResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (GetServices.class.equals(type)) {

                o = GetServices.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (GetServicesResponse.class.equals(type)) {

                o = GetServicesResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Submit.class.equals(type)) {

                o = Submit.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (SubmitResponse.class.equals(type)) {

                o = SubmitResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Notify.class.equals(type)) {

                o = Notify.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NotifyResponse.class.equals(type)) {

                o = NotifyResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Solicit.class.equals(type)) {

                o = Solicit.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (SolicitResponse.class.equals(type)) {

                o = SolicitResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (Query.class.equals(type)) {

                o = Query.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (QueryResponse.class.equals(type)) {

                o = QueryResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            } else if (NodeFaultDetailType.class.equals(type)) {

                o = NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());
            }

        } catch (Exception e) {

            throw AxisFault.makeFault(e);
        }

        return o;
    }

}

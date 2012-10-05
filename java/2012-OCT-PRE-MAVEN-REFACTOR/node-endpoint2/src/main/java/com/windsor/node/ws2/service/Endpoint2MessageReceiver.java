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
 * Endpoint2MessageReceiver.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:24:30 EDT)
 */
package com.windsor.node.ws2.service;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

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
import org.apache.axiom.soap.SOAPBody;
import org.apache.axiom.soap.SOAPEnvelope;
import org.apache.axis2.AxisFault;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.ws2.Endpoint2FaultMessage;
import com.windsor.node.ws2.util.FaultUtil;

/**
 * Endpoint2MessageReceiver message receiver
 */

public class Endpoint2MessageReceiver extends
        org.apache.axis2.receivers.AbstractInOutMessageReceiver {

    private final Logger logger = LoggerFactory.getLogger(getClass());

    public void invokeBusinessLogic(
            org.apache.axis2.context.MessageContext msgContext,
            org.apache.axis2.context.MessageContext newMsgContext)
            throws AxisFault {

        try {

            // get the implementation class for the Web Service
            Object obj = getTheImplementationObject(msgContext);

            Endpoint2Service skel = (Endpoint2Service) obj;
            // Out Envelop
            org.apache.axiom.soap.SOAPEnvelope envelope = null;

            /*org.apache.axiom.soap.SOAPBody inputEnvelope = msgContext
                    .getEnvelope().getBody();*/

            // Find the axisOperation that has been set by the Dispatch phase.
            org.apache.axis2.description.AxisOperation op = msgContext
                    .getOperationContext().getAxisOperation();

            if (op == null) {
                throw new AxisFault(
                        "Operation is not located, if this is doclit style the "
                                + "SOAP-ACTION should specified via the SOAP Action to "
                                + "use the RawXMLProvider");
            }

            String methodName;
            if ((op.getName() != null)
                    && ((methodName = org.apache.axis2.util.JavaUtils
                            .xmlNameToJava(op.getName().getLocalPart())) != null)) {

                SOAPEnvelope inEnvelope = msgContext.getEnvelope();
                logger.debug("Envelope: " + inEnvelope);
                SOAPBody inBody = inEnvelope.getBody();
                OMElement firstElement = inBody.getFirstElement();
                Map<String, String> namespaceMap = getEnvelopeNamespaces(inEnvelope);

                if ("Execute".equals(methodName)) {

                    logger.debug("Processing Execute...");

                    Execute wrappedParam = (Execute) fromOM(firstElement,
                            Execute.class, namespaceMap);

                    ExecuteResponse executeResponse41 = skel
                            .Execute(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            executeResponse41, false);

                } else if ("Authenticate".equals(methodName)) {

                    logger.debug("Processing Authenticate...");

                    Authenticate wrappedParam = (Authenticate) fromOM(
                            firstElement, Authenticate.class, namespaceMap);

                    AuthenticateResponse authenticateResponse43 = skel
                            .Authenticate(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            authenticateResponse43, false);

                } else if ("Download".equals(methodName)) {

                    logger.debug("Processing Download...");

                    Download wrappedParam = (Download) fromOM(firstElement,
                            Download.class, namespaceMap);

                    DownloadResponse downloadResponse45 = skel
                            .Download(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            downloadResponse45, false);

                } else if ("GetStatus".equals(methodName)) {

                    GetStatus wrappedParam = (GetStatus) fromOM(firstElement,
                            GetStatus.class, namespaceMap);

                    GetStatusResponse getStatusResponse47 = skel
                            .GetStatus(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            getStatusResponse47, false);

                } else if ("NodePing".equals(methodName)) {

                    logger.debug("Processing NodePing...");

                    NodePing wrappedParam = (NodePing) fromOM(firstElement,
                            NodePing.class, namespaceMap);

                    NodePingResponse nodePingResponse49 = skel
                            .NodePing(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            nodePingResponse49, false);

                } else if ("GetServices".equals(methodName)) {

                    logger.debug("Processing GetServices...");

                    GetServices wrappedParam = (GetServices) fromOM(
                            firstElement, GetServices.class, namespaceMap);

                    GetServicesResponse getServicesResponse51 = skel
                            .GetServices(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            getServicesResponse51, false);

                } else if ("Submit".equals(methodName)) {

                    logger.debug("Processing Submit...");

                    Submit wrappedParam = (Submit) fromOM(firstElement,
                            Submit.class, namespaceMap);

                    SubmitResponse submitResponse53 = skel.Submit(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            submitResponse53, false);

                } else if ("Notify".equals(methodName)) {

                    logger.debug("Processing Notify...");

                    Notify wrappedParam = (Notify) fromOM(firstElement,
                            Notify.class, namespaceMap);

                    logger.debug("Input params: " + wrappedParam);

                    NotifyResponse notifyResponse55 = skel.Notify(wrappedParam);

                    logger.debug("Output params: " + notifyResponse55);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            notifyResponse55, false);

                } else if ("Solicit".equals(methodName)) {

                    logger.debug("Processing Solicit...");

                    Solicit wrappedParam = (Solicit) fromOM(firstElement,
                            Solicit.class, namespaceMap);

                    SolicitResponse solicitResponse57 = skel
                            .Solicit(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            solicitResponse57, false);

                } else if ("Query".equals(methodName)) {

                    logger.debug("Processing Query...");

                    Query wrappedParam = (Query) fromOM(firstElement,
                            Query.class, namespaceMap);

                    QueryResponse queryResponse59 = skel.Query(wrappedParam);

                    envelope = toEnvelope(getSOAPFactory(msgContext),
                            queryResponse59, false);

                } else {
                    logger.error("Unsupported method: " + methodName);
                    throw new RuntimeException("method not found");
                }

                newMsgContext.setEnvelope(envelope);
            }

        } catch (Endpoint2FaultMessage e) {

            msgContext.setProperty(org.apache.axis2.Constants.FAULT_NAME,
                    "NodeFaultDetailType");

            AxisFault f = createAxisFault(e);

            if (e.getFaultMessage() != null) {
                f.setDetail(toOM(e.getFaultMessage(), false));
            }

            throw f;
        }

        catch (Exception ex) {

            Endpoint2FaultMessage e = FaultUtil.parseNodeFault(ex);

            msgContext.setProperty(org.apache.axis2.Constants.FAULT_NAME,
                    "NodeFaultDetailType");

            AxisFault f = createAxisFault(e);

            if (e.getFaultMessage() != null) {
                f.setDetail(toOM(e.getFaultMessage(), false));
            }

            throw f;

        }
    }

    private org.apache.axiom.om.OMElement toOM(NodeFaultDetailType param,
            boolean optimizeContent) throws AxisFault {

        try {
            return param.getOMElement(NodeFaultDetailType.MY_QNAME,
                    org.apache.axiom.om.OMAbstractFactory.getOMFactory());
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }

    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, ExecuteResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(ExecuteResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            AuthenticateResponse param, boolean optimizeContent)
            throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(AuthenticateResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, DownloadResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(DownloadResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, GetStatusResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(GetStatusResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, NodePingResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(NodePingResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory,
            GetServicesResponse param, boolean optimizeContent)
            throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(GetServicesResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, SubmitResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(SubmitResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, NotifyResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(NotifyResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, SolicitResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(SolicitResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
            org.apache.axiom.soap.SOAPFactory factory, QueryResponse param,
            boolean optimizeContent) throws AxisFault {
        try {
            org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory
                    .getDefaultEnvelope();

            emptyEnvelope.getBody().addChild(
                    param.getOMElement(QueryResponse.MY_QNAME, factory));

            return emptyEnvelope;
        } catch (org.apache.axis2.databinding.ADBException e) {
            throw AxisFault.makeFault(e);
        }
    }

    private Object fromOM(org.apache.axiom.om.OMElement param, Class<?> type,
            Map<String, String> extraNamespaces) throws AxisFault {

        try {

            logger.debug("Parsing for type: " + type);

            if (Execute.class.equals(type)) {

                return Execute.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (ExecuteResponse.class.equals(type)) {

                return ExecuteResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Authenticate.class.equals(type)) {

                return Authenticate.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (AuthenticateResponse.class.equals(type)) {

                return AuthenticateResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Download.class.equals(type)) {

                return Download.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (DownloadResponse.class.equals(type)) {

                return DownloadResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (GetStatus.class.equals(type)) {

                return GetStatus.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (GetStatusResponse.class.equals(type)) {

                return GetStatusResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodePing.class.equals(type)) {

                return NodePing.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodePingResponse.class.equals(type)) {

                return NodePingResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (GetServices.class.equals(type)) {

                return GetServices.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (GetServicesResponse.class.equals(type)) {

                return GetServicesResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Submit.class.equals(type)) {

                return Submit.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (SubmitResponse.class.equals(type)) {

                return SubmitResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Notify.class.equals(type)) {

                logger.debug("Notify Factory parsing...");

                return Notify.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NotifyResponse.class.equals(type)) {

                return NotifyResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Solicit.class.equals(type)) {

                return Solicit.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (SolicitResponse.class.equals(type)) {

                return SolicitResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (Query.class.equals(type)) {

                return Query.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (QueryResponse.class.equals(type)) {

                return QueryResponse.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

            if (NodeFaultDetailType.class.equals(type)) {

                return NodeFaultDetailType.Factory.parse(param
                        .getXMLStreamReaderWithoutCaching());

            }

        } catch (Exception e) {
            logger.error(e.getMessage(), e);
            throw AxisFault.makeFault(e);
        }
        return null;
    }

    /**
     * A utility method that copies the namepaces from the SOAPEnvelope
     */
    private Map<String, String> getEnvelopeNamespaces(org.apache.axiom.soap.SOAPEnvelope env) {

        Map<String, String> returnMap = new HashMap<String, String>();
        @SuppressWarnings("unchecked")
        Iterator<OMNamespace> namespaceIterator = (Iterator<OMNamespace>)env.getAllDeclaredNamespaces();

        while (namespaceIterator.hasNext()) {
            OMNamespace ns = namespaceIterator.next();
            returnMap.put(ns.getPrefix(), ns.getNamespaceURI());
        }

        return returnMap;

    }

    private AxisFault createAxisFault(Exception e) {

        AxisFault f;

        Throwable cause = e.getCause();

        if (cause != null) {
            f = new AxisFault(e.getMessage(), cause);
        } else {
            f = new AxisFault(e.getMessage());
        }

        return f;
    }

}// end of class

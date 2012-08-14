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
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:24:30 EDT)
 */
package com.windsor.node.ws2.service;

import java.math.BigInteger;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;

import javax.servlet.http.HttpServletRequest;

import net.exchangenetwork.www.schema.node._2.Authenticate;
import net.exchangenetwork.www.schema.node._2.AuthenticateResponse;
import net.exchangenetwork.www.schema.node._2.Download;
import net.exchangenetwork.www.schema.node._2.DownloadResponse;
import net.exchangenetwork.www.schema.node._2.ErrorCodeList;
import net.exchangenetwork.www.schema.node._2.Execute;
import net.exchangenetwork.www.schema.node._2.ExecuteResponse;
import net.exchangenetwork.www.schema.node._2.GetServices;
import net.exchangenetwork.www.schema.node._2.GetServicesResponse;
import net.exchangenetwork.www.schema.node._2.GetStatus;
import net.exchangenetwork.www.schema.node._2.GetStatusResponse;
import net.exchangenetwork.www.schema.node._2.NodeDocumentType;
import net.exchangenetwork.www.schema.node._2.NodePing;
import net.exchangenetwork.www.schema.node._2.NodePingResponse;
import net.exchangenetwork.www.schema.node._2.NodeStatusCode;
import net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType;
import net.exchangenetwork.www.schema.node._2.NotificationMessageType;
import net.exchangenetwork.www.schema.node._2.NotificationTypeCode;
import net.exchangenetwork.www.schema.node._2.NotificationURIType;
import net.exchangenetwork.www.schema.node._2.Notify;
import net.exchangenetwork.www.schema.node._2.NotifyResponse;
import net.exchangenetwork.www.schema.node._2.ParameterType;
import net.exchangenetwork.www.schema.node._2.Query;
import net.exchangenetwork.www.schema.node._2.QueryResponse;
import net.exchangenetwork.www.schema.node._2.ResultSetType;
import net.exchangenetwork.www.schema.node._2.Solicit;
import net.exchangenetwork.www.schema.node._2.SolicitResponse;
import net.exchangenetwork.www.schema.node._2.StatusResponseType;
import net.exchangenetwork.www.schema.node._2.Submit;
import net.exchangenetwork.www.schema.node._2.SubmitResponse;
import net.exchangenetwork.www.schema.node._2.TransactionStatusCode;

import org.apache.axis2.transport.http.HTTPConstants;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.AsyncComplexContent;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.ComplexContent;
import com.windsor.node.common.domain.ComplexNotification;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointAuthenticationRequest;
import com.windsor.node.common.domain.EndpointTokenValidationRequest;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.EndpointVisit;
import com.windsor.node.common.domain.NodeStatusCodeType;
import com.windsor.node.common.domain.Notification;
import com.windsor.node.common.domain.OperationDataFlow;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.WnosNotificationMessageCategoryType;
import com.windsor.node.common.domain.WnosTransactionNotificationType;
import com.windsor.node.common.service.cmf.ContentService;
import com.windsor.node.common.service.cmf.SecurityService;
import com.windsor.node.common.service.cmf.TransactionService;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.CommonTransactionStatusCodeConverter;
import com.windsor.node.ws2.Endpoint2FaultMessage;
import com.windsor.node.ws2.util.FaultUtil;
import com.windsor.node.ws2.util.NodeUtil;

/**
 * Endpoint2ServiceImpl
 * 
 * @author mchmarny
 * 
 */
public class Endpoint2ServiceImpl extends BaseEndpoint2Service implements
        Endpoint2Service, InitializingBean {

    private final Logger logger = LoggerFactory.getLogger(getClass());
    private ContentService contentService;
    private SecurityService securityService;
    private TransactionService transactionService;
    private String requestIPHeaderProperty;
    private String nodePingReadyMessage;
    private static final String HTTP_HEADER_FORWARD_FOR = "X-Forward-For";

    private static final EndpointVersionType endpointVersion = EndpointVersionType.EN20;

    /**
     * Endpoint2ServiceImpl
     * 
     * @throws RemoteException
     */
    public Endpoint2ServiceImpl() throws RemoteException {

        requestIPHeaderProperty = null;
        logger.debug("[Endpoint2ServiceImpl]: Constructor.");

    }

    public void afterPropertiesSet() throws Exception {

        if (contentService == null) {
            throw new Exception("Endpoint2ServiceImpl: contentService not set");
        }

        if (securityService == null) {
            throw new Exception("Endpoint2ServiceImpl: securityService not set");
        }

        if (transactionService == null) {
            throw new Exception(
                    "Endpoint2ServiceImpl: transactionService not set");
        }

        logger.debug("Properties set, NOS Services acquired");
    }

    /**
     * Authenticate
     */
    public AuthenticateResponse Authenticate(Authenticate authRequest)
            throws Endpoint2FaultMessage {

        logger.debug("[Authenticate]: Start.");
        if (authRequest == null)
        {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential, NULL_AUTH_REQUEST);
        }

        if(StringUtils.isBlank(authRequest.getUserId()))
        {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential, NULL_USER_ID);
        }

        if(StringUtils.isBlank(authRequest.getCredential()))
        {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential, NULL_PASSWORD);
        }

        if(StringUtils.isBlank(authRequest.getAuthenticationMethod()))
        {
            authRequest.setAuthenticationMethod(DEFAULT_AUTH_METHOD);
        }

        if(StringUtils.isBlank(authRequest.getDomain()))
        {
            logger.debug("Domain was blank, setting to \"" + DEFAULT_AUTH_DOMAIN + "\".");
            authRequest.setDomain(DEFAULT_AUTH_DOMAIN);
        }
        else if(!authRequest.getDomain().equals(DEFAULT_AUTH_DOMAIN))
        {
            logger.info("Found invalid domain " + authRequest.getDomain() + ", returning Fault: E_UNKNOWN_USER.");
            Endpoint2FaultMessage fault = FaultUtil.makeFault(ErrorCodeList.E_UnknownUser, UNKNOWN_DOMAIN);
            logger.debug("Throwing new fault: " + fault);
            throw fault;
        }

        try
        {
            logger.debug("Request: " + authRequest.getUserId());
            logger.debug("credential: *************");
            logger.debug("authenticationMethod: " + authRequest.getAuthenticationMethod());

            EndpointVisit visit = securityService .endpointAuthenticate(new EndpointAuthenticationRequest(
                            endpointVersion, authRequest.getUserId(),
                            authRequest.getCredential(), authRequest
                                    .getAuthenticationMethod(), getClientHost()));
            logger.debug("Visit: " + visit);

            AuthenticateResponse response = new AuthenticateResponse();
            response.setSecurityToken(visit.getToken());

            return response;

        }
        catch(Exception ex)
        {
            String msg;
            if(null == ex.getMessage())
            {
                msg = ex.getClass().getName();
            }
            else
            {
                msg = ex.getMessage();
            }
            logger.error("[Authenticate]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential, msg);
        }
    }

    /**
     * Execute
     */
    public ExecuteResponse Execute(Execute execute0)
            throws Endpoint2FaultMessage {

        logger.debug("[Execute]: Start.");
        if (execute0 == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null execute parameter");
        }

        if (StringUtils.isBlank(execute0.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (StringUtils.isBlank(execute0.getMethodName())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    "Null method name");
        }

        if (StringUtils.isBlank(execute0.getInterfaceName())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    "Null interface name");
        }

        EndpointVisit visit = getVisit(execute0.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {
            logger.debug("method: " + execute0.getMethodName());
            logger.debug("interface: " + execute0.getInterfaceName());

            DataRequest dataReq = new DataRequest();
            logger.debug("Getting parameters...");
            dataReq.setParameters(createParameters(execute0.getParameters()));
            dataReq.setService(new DataService(execute0.getMethodName(),
                    execute0.getInterfaceName()));
            dataReq.setType(RequestType.Execute);

            ProcessContentResult result = transactionService.execute(visit,
                    dataReq);

            logger.debug("execute result: " + result);

            if (result == null || result.getStatus() == null
                    || result.getDocuments() == null
                    || result.getDocuments().size() != 1) {
                throw new RuntimeException("Invalid WNOS result");
            }

            ExecuteResponse response = new ExecuteResponse();

            logger.debug("Parsing status from: " + result.getStatus());
            response.setStatus(TransactionStatusCode.Factory.fromValue(result
                    .getStatus().toString()));
            response.setTransactionId(null);

            Document doc = (Document) result.getDocuments().get(0);

            response.setResults(NodeUtil.getGenericXmlType(doc.getType(), doc
                    .getContent()));

            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Execute]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * Download
     */
    public DownloadResponse Download(Download downloadRequest)
            throws Endpoint2FaultMessage {

        logger.debug("[Download]: Start.");
        if (downloadRequest == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DOWNLOAD_REQUEST);
        }

        if (StringUtils.isBlank(downloadRequest.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (StringUtils.isBlank(downloadRequest.getTransactionId())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_TRANSACTION_ID);
        }

        if (downloadRequest.getDataflow() == null
                || StringUtils
                        .isBlank(downloadRequest.getDataflow().toString())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DATA_FLOW);
        }

        EndpointVisit visit = getVisit(downloadRequest.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {
            logger.debug("transaction Id: "
                    + downloadRequest.getTransactionId());
            logger.debug("flow: " + downloadRequest.getDataflow().toString());
            logger.debug("documents: " + downloadRequest.getDocuments());

            ComplexContent content = new ComplexContent();
            content.setFlow(new OperationDataFlow(downloadRequest.getDataflow()
                    .toString()));
            content.setTransactionId(downloadRequest.getTransactionId());
            content.setDocuments(new ArrayList());

            if (downloadRequest.getDocuments() != null
                    && downloadRequest.getDocuments().length > 0) {

                logger.debug("Transforming documents...");

                for (int d = 0; d < downloadRequest.getDocuments().length; d++) {

                    NodeDocumentType docIn = downloadRequest.getDocuments()[d];

                    Document wnosDoc = new Document();

                    // If we have an id
                    if (docIn.getDocumentId() != null
                            && StringUtils.isNotBlank(docIn.getDocumentId()
                                    .toString())) {
                        wnosDoc.setDocumentId(docIn.getDocumentId().toString());
                        content.getDocuments().add(wnosDoc);

                        // else if we have a document name
                    } else if (StringUtils.isNotBlank(docIn.getDocumentName()
                            .toString())) {
                        wnosDoc.setDocumentName(docIn.getDocumentName());
                        content.getDocuments().add(wnosDoc);
                    }

                }
            }

            logger.debug("Sending download request with content: " + content);
            List nosDocList = contentService.download(visit, content);

            if (nosDocList == null) {
                throw new RuntimeException("Null list");
            }

            logger.debug("Received: " + nosDocList.size());

            DownloadResponse response = new DownloadResponse();

            if (null != nosDocList) {

                for (int d = 0; d < nosDocList.size(); d++) {

                    Document wnosDoc = (Document) nosDocList.get(d);
                    logger.debug("Parsing WSDL doc from WNOS Doc: " + wnosDoc);

                    NodeDocumentType resultDoc = NodeUtil
                            .getNodeDocumentFromWnosDoc((Document) nosDocList
                                    .get(d));

                    logger.debug("Adding WSDL doc to collection: " + resultDoc);
                    response.addDocuments(resultDoc);
                }

            } else {
                // Seems to cause all kinds of issues on the client side
                // Resetting this to emoty array seems to address it
                response.setDocuments(new NodeDocumentType[0]);
            }

            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Download]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }
    }

    /**
     * GetStatus
     */
    public GetStatusResponse GetStatus(GetStatus getStatus6)
            throws Endpoint2FaultMessage {

        logger.debug("[GetStatus]: Enter.");
        if (getStatus6 == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null status request");
        }

        if (StringUtils.isBlank(getStatus6.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (StringUtils.isBlank(getStatus6.getTransactionId())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_TRANSACTION_ID);
        }

        EndpointVisit visit = getVisit(getStatus6.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            logger.debug("getStatus with transactionId: "
                    + getStatus6.getTransactionId() + ", visit: " + visit);

            TransactionStatus status = transactionService.getStatus(visit,
                    getStatus6.getTransactionId());

            StatusResponseType responseType = new StatusResponseType();
            responseType.setStatus(TransactionStatusCode.Factory
                    .fromValue(status.getStatus().toString()));
            responseType.setStatusDetail(status.getDescription());
            responseType.setTransactionId(status.getTransactionId());

            GetStatusResponse response = new GetStatusResponse();
            response.setGetStatusResponse(responseType);

            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[GetStatus]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * NodePing
     */
    public NodePingResponse NodePing(NodePing nodePingRequest)
            throws Endpoint2FaultMessage {
        NodePingResponse response = new NodePingResponse();
        NodeStatusCode statusCode = NodeStatusCode.Factory
                .fromValue(NodeStatusCodeType.READY.toString());
        response.setNodeStatus(statusCode);
        response.setStatusDetail(getNodePingReadyMessage());
        return response;
    }

    /**
     * GetServices
     */
    public GetServicesResponse GetServices(GetServices getServices10)
            throws Endpoint2FaultMessage {

        logger.debug("[GetServices]: Enter.");

        if (getServices10 == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null status request");
        }

        if (StringUtils.isBlank(getServices10.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (StringUtils.isBlank(getServices10.getServiceCategory())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null service category");
        }

        EndpointVisit visit = getVisit(getServices10.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            logger.debug("serviceType: " + getServices10.getServiceCategory());

            SimpleContent content = contentService.getServices(visit,
                    getServices10.getServiceCategory());

            GetServicesResponse response = new GetServicesResponse();
            response.setGetServicesResponse(NodeUtil.getGenericXmlType(content
                    .getType(), content.getContent()));

            logger.debug("Returning result");
            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[GetServices]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * Submit
     */
    public SubmitResponse Submit(Submit submitRequest)
            throws Endpoint2FaultMessage {

        logger.debug("[Submit]: Enter.");
        logger.debug("submitRequest: " + submitRequest);
        if (submitRequest == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_SUBMIT_REQUEST);
        }

        if (StringUtils.isBlank(submitRequest.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (submitRequest.getDataflow() == null
                || StringUtils.isBlank(submitRequest.getDataflow().toString())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DATA_FLOW);
        }

        if (submitRequest.getDocuments() == null
                || submitRequest.getDocuments().length < 1) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DOCUMENTS);
        }

        EndpointVisit visit = getVisit(submitRequest.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            NodeDocumentType[] documents = submitRequest.getDocuments();
            logger.debug("Number of documents submitted: " + documents.length);

            AsyncComplexContent content = new AsyncComplexContent();
            content.setFlow(new OperationDataFlow(submitRequest.getDataflow()
                    .toString(), submitRequest.getFlowOperation()));
            content.setTransactionId(submitRequest.getTransactionId());
            content.setDocuments(new ArrayList());

            for (int i = 0; i < documents.length; i++) {
                content.getDocuments().add(
                        NodeUtil.getDocumentFromNodeDocumentType(documents[i]));
            }

            logger.debug("Submitting request content...");
            TransactionStatus status = contentService.submit(visit, content);

            SubmitResponse response = new SubmitResponse();

            StatusResponseType statusResponseType = new StatusResponseType();

            logger.debug("Setting StatusResponseType.status to "
                    + TransactionStatusCode.Received);
            statusResponseType.setStatus(TransactionStatusCode.Received);

            logger.debug("Setting StatusResponseType.transactionId to "
                    + status.getTransactionId());
            statusResponseType.setTransactionId(status.getTransactionId());

            logger.debug("Setting StatusResponseType.statusDetail to "
                    + status.getDescription());
            statusResponseType.setStatusDetail(status.getDescription());

            logger.debug("Setting StatusResponseType in SubmitResponse...");
            response.setSubmitResponse(statusResponseType);

            logger.debug("Returning response...");
            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Submit]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * Notify
     */
    public NotifyResponse Notify(Notify notify14) throws Endpoint2FaultMessage {

        logger.debug("[Notify]: Enter.");

        if (notify14 == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null notify request");
        }

        if (StringUtils.isBlank(notify14.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (notify14.getDataflow() == null
                || StringUtils.isBlank(notify14.getDataflow().toString())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DATA_FLOW);
        }

        if (notify14.getMessages() == null || notify14.getMessages().length < 1) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_MESSAGES);
        }

        EndpointVisit visit = getVisit(notify14.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            ComplexNotification complexNotification = new ComplexNotification();

            complexNotification.setFlowName(notify14.getDataflow().toString());
            complexNotification.setUri(notify14.getNodeAddress());
            complexNotification.setNotifications(new ArrayList());

            logger.debug("Spooling messages");
            for (int m = 0; m < notify14.getMessages().length; m++) {

                NotificationMessageType wsdlNotif = notify14.getMessages()[m];
                Notification wnosNotif = new Notification();

                wnosNotif.setCategory(WnosNotificationMessageCategoryType.valueOf(wsdlNotif.getMessageCategory().getValue()));

                if (wsdlNotif.getMessageCategory().equals(
                        NotificationMessageCategoryType.Document)
                        || wsdlNotif.getMessageCategory().equals(
                                NotificationMessageCategoryType.Status)) {
                    wnosNotif.setName(wsdlNotif.getObjectId().toString());
                } else {
                    wnosNotif.setName(wsdlNotif.getMessageName());
                }

                TransactionStatus status = new TransactionStatus();
                status
                        .setStatus((CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                                .convert(wsdlNotif.getStatus().getValue()));
                status.setDescription(wsdlNotif.getStatusDetail());
                wnosNotif.setStatus(status);

                logger.debug("Spooled notification: " + wnosNotif);
                complexNotification.getNotifications().add(wnosNotif);

            }

            logger.debug("Executing notify with: " + complexNotification);

            TransactionStatus result = transactionService.notify(visit,
                    complexNotification);
            logger.debug("Notify transaction status: " + result);

            NotifyResponse response = new NotifyResponse();
            StatusResponseType responseType = new StatusResponseType();

            logger.debug("Setting StatusResponseType.status to "
                    + TransactionStatusCode.Factory.fromValue(result
                            .getStatus().toString()));
            responseType.setStatus(TransactionStatusCode.Factory
                    .fromValue(result.getStatus().toString()));

            logger.debug("Setting StatusResponseType.statusDetail to "
                    + result.getDescription());
            responseType.setStatusDetail(result.getDescription());

            logger.debug("Setting StatusResponseType.transactionId to "
                    + result.getTransactionId());
            responseType.setTransactionId(result.getTransactionId());

            logger.debug("Putting StatusResponseType in NotifyResponse...");
            response.setNotifyResponse(responseType);

            logger.debug("Returning NotifyResponse...");
            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Notify]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * Solicit
     */
    public SolicitResponse Solicit(Solicit req) throws Endpoint2FaultMessage {

        logger.debug("[Solicit]: Enter.");

        if (req == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null solicit request");
        }

        if (StringUtils.isBlank(req.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (req.getDataflow() == null
                || StringUtils.isBlank(req.getDataflow().toString())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DATA_FLOW);
        }

        if (StringUtils.isBlank(req.getRequest())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_REQUEST);
        }

        EndpointVisit visit = getVisit(req.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            logger.debug("Creating request...");
            DataRequest dataRequest = new DataRequest();
            dataRequest.setService(new DataService(req.getRequest()));
            logger.debug("Getting parameters...");
            dataRequest.setParameters(createParameters(req.getParameters()));

            if (req.getRecipient() != null) {
                logger.debug("Spooling recipients");
                for (int r = 0; r < req.getRecipient().length; r++) {
                    String recipient = req.getRecipient()[r];
                    logger.debug("Recipient: " + recipient);
                    if (StringUtils.isNotBlank(recipient)) {
                        dataRequest.getRecipients().add(recipient);
                    }
                }
            }

            if (req.getNotificationURI() != null) {
                logger.debug("Spooling notifications");
                for (int n = 0; n < req.getNotificationURI().length; n++) {
                    NotificationURIType wsdlNotif = req.getNotificationURI()[n];
                    if (wsdlNotif != null) {

                        String notifStr = wsdlNotif.getString();

                        logger.debug("Notif: " + notifStr);
                        logger.debug("NotifType: "
                                + wsdlNotif.getNotificationType());

                        if (wsdlNotif.getNotificationType() == null) {
                            wsdlNotif
                                    .setNotificationType(NotificationTypeCode.All);
                        }

                        if (StringUtils.isNotBlank(notifStr)) {

                            // TODO: Create Transaction Notifcation Conversion Utility
                            dataRequest.getNotifications().put(wsdlNotif.getString(),
                                                               WnosTransactionNotificationType.valueOf(wsdlNotif.getNotificationType()
                                                                               .getValue()));
                        }
                    }
                }
            }

            logger.debug("Executing solicit request: " + dataRequest);
            TransactionStatus status = transactionService.solicit(visit,
                    dataRequest);

            logger.debug("Status: " + status);

            StatusResponseType responseType = new StatusResponseType();

            logger.debug("Setting StatusResponseType.status to "
                    + TransactionStatusCode.Factory.fromValue(status
                            .getStatus().toString()));
            responseType.setStatus(TransactionStatusCode.Factory
                    .fromValue(status.getStatus().toString()));

            logger.debug("Setting StatusResponseType.statusDetail to "
                    + status.getDescription());
            responseType.setStatusDetail(status.getDescription());

            logger.debug("Setting StatusResponseType.transactionId to "
                    + status.getTransactionId());
            responseType.setTransactionId(status.getTransactionId());

            logger.debug("Putting StatusResponseType in SolicitResponse...");
            SolicitResponse response = new SolicitResponse();
            response.setSolicitResponse(responseType);

            logger.debug("Returning SolicitResponse...");
            return response;

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Solicit]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /**
     * Auto generated method signature Execute a database query
     * 
     * @param query18
     * @throws Endpoint2FaultMessage
     *             :
     */

    public QueryResponse Query(Query query18) throws Endpoint2FaultMessage {

        logger.debug("[Query]: Enter.");

        if (query18 == null) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    "Null Query");
        }

        logger.debug("Query request: " + query18);

        if (StringUtils.isBlank(query18.getSecurityToken())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_TOKEN);
        }

        if (query18.getDataflow() == null
                || StringUtils.isBlank(query18.getDataflow().toString())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidParameter,
                    NULL_DATA_FLOW);
        }

        if (StringUtils.isBlank(query18.getRequest())) {
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidCredential,
                    NULL_REQUEST);
        }

        EndpointVisit visit = getVisit(query18.getSecurityToken());
        logger.debug("Visit: " + visit);

        try {

            DataRequest dataRequest = new DataRequest();
            dataRequest.setService(new DataService(query18.getRequest()));
            logger.debug("Getting parameters...");
            dataRequest
                    .setParameters(createParameters(query18.getParameters()));

            dataRequest.setPaging(new PaginationIndicator());
            dataRequest.getPaging().setStart(query18.getRowId().intValue());
            dataRequest.getPaging().setCount(query18.getMaxRows().intValue());

            logger.debug("Sending request: " + dataRequest);
            ProcessContentResult wnosResult = transactionService.query(visit,
                    dataRequest);

            logger.debug("Result: " + wnosResult);

            if (wnosResult.getDocuments() == null) {
                throw new RuntimeException(NULL_DOCUMENTS);
            }
            if (wnosResult.getDocuments().size() == 0) {
                throw new RuntimeException(ZERO_DOCUMENTS);
                // }
                // if (wnosResult.getDocuments().size() > 1) {
                // throw new RuntimeException(MORE_THAN_ONE_DOCUMENT);
            } else {

                Document doc = (Document) wnosResult.getDocuments().get(0);
                logger.debug("Document: " + doc);

                ResultSetType responseType = new ResultSetType();

                logger.debug("Setting ResultSetType.rowId to "
                        + BigInteger.valueOf(wnosResult
                                .getPaginatedContentIndicator().getStart()));
                responseType.setRowId(BigInteger.valueOf(wnosResult
                        .getPaginatedContentIndicator().getStart()));

                logger.debug("Setting ResultSetType.rowCount to "
                        + BigInteger.valueOf(wnosResult
                                .getPaginatedContentIndicator().getCount()));
                responseType.setRowCount(BigInteger.valueOf(wnosResult
                        .getPaginatedContentIndicator().getCount()));

                logger.debug("Setting ResultSetType.lastSet to "
                        + wnosResult.getPaginatedContentIndicator().isLast());
                responseType.setLastSet(wnosResult
                        .getPaginatedContentIndicator().isLast());
                responseType.setResults(NodeUtil.getGenericXmlType(doc
                        .getType(), doc.getContent()));

                QueryResponse response = new QueryResponse();

                logger.debug("Setting ResultSetType in QueryResponse...");
                response.setQueryResponse(responseType);

                logger.debug("Returning response...");
                return response;

            }

        } catch (Exception ex) {

            String msg;

            if (null == ex.getMessage()) {
                msg = ex.getClass().getName();
            } else {
                msg = ex.getMessage();
            }

            logger.error("[Query]: Exception: " + msg);
            throw FaultUtil.makeFault(ErrorCodeList.E_Unknown, msg);
        }

    }

    /*
     * 
     * 
     * 
     * PRIVATES
     */

    private String getClientHost() {

        org.apache.axis2.context.MessageContext msgContext = org.apache.axis2.context.MessageContext
                .getCurrentMessageContext();
        HttpServletRequest request = (HttpServletRequest) msgContext
                .getProperty(HTTPConstants.MC_HTTP_SERVLETREQUEST);

        String clientHost = null;

        if (StringUtils.isBlank(requestIPHeaderProperty)) {

            clientHost = request.getRemoteAddr();
            logger.debug("RemoteAddr: " + clientHost);

            Enumeration hdEnum = request.getHeaderNames();

            while (hdEnum.hasMoreElements()) {

                String hdKey = (String) hdEnum.nextElement();
                if (StringUtils.isNotBlank(hdKey)
                        && hdKey.equalsIgnoreCase(HTTP_HEADER_FORWARD_FOR)) {
                    clientHost = request.getHeader(hdKey);
                    logger.debug(HTTP_HEADER_FORWARD_FOR + ": " + clientHost);
                }
            }

        } else {
            clientHost = request.getHeader(requestIPHeaderProperty);
            logger.debug(requestIPHeaderProperty + ": " + clientHost);
        }

        logger.debug("[host]: " + clientHost);
        return clientHost;

    }

    private EndpointVisit getVisit(String securityToken)
            throws Endpoint2FaultMessage {
        EndpointVisit visit = null;
        try {
            logger.debug("[token]: " + securityToken);
            EndpointTokenValidationRequest request = new EndpointTokenValidationRequest(
                    endpointVersion, securityToken, getClientHost());
            logger.debug("[request]: " + request);
            visit = securityService.endpointValidate(request);
            logger.debug("[visit]: " + request);
        } catch (Exception ex) {
            logger.error("[token]: ERROR: " + ex.getMessage());
            throw FaultUtil.makeFault(ErrorCodeList.E_InvalidToken, ex
                    .getMessage());
        }
        return visit;
    }

    private ByIndexOrNameMap createParameters(ParameterType[] params) {

        ByIndexOrNameMap map = new ByIndexOrNameMap();

        if (params != null && params.length > 0) {
            for (int i = 0; i < params.length; i++) {

                String paramName = params[i].getParameterName();
                String paramValue = params[i].getString();

                logger.debug("Name:  " + paramName);
                logger.debug("Value: " + paramValue);

                map.put(paramName, paramValue);

            }

        } else {
            logger.debug("Null parameters");
        }

        return map;
    }

    public void setRequestIPHeaderProperty(String requestIPHeaderProperty) {
        this.requestIPHeaderProperty = requestIPHeaderProperty;
    }

    public void setContentService(ContentService contentService) {
        this.contentService = contentService;
    }

    public void setSecurityService(SecurityService securityService) {
        this.securityService = securityService;
    }

    public void setTransactionService(TransactionService transactionService) {
        this.transactionService = transactionService;
    }

    public String getNodePingReadyMessage()
    {
        return nodePingReadyMessage;
    }

    public void setNodePingReadyMessage(String nodePingReadyMessage)
    {
        this.nodePingReadyMessage = nodePingReadyMessage;
    }

}

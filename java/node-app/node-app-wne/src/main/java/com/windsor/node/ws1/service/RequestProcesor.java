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

package com.windsor.node.ws1.service;

import java.math.BigInteger;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.Iterator;
import java.util.List;
import javax.servlet.http.HttpServletRequest;
import org.apache.axis.Message;
import org.apache.axis.MessageContext;
import org.apache.axis.attachments.Attachments;
import org.apache.axis.transport.http.HTTPConstants;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
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
import com.windsor.node.common.domain.Notification;
import com.windsor.node.common.domain.OperationDataFlow;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.WnosNotificationMessageCategoryType;
import com.windsor.node.common.service.cmf.ContentService;
import com.windsor.node.common.service.cmf.SecurityService;
import com.windsor.node.common.service.cmf.TransactionService;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.CommonContentAndFormatConverter;
import com.windsor.node.common.util.CommonTransactionStatusCodeConverter;
import com.windsor.node.ws1.util.NodeFault;
import com.windsor.node.ws1.wsdl.ArrayofDocHolder;
import com.windsor.node.ws1.wsdl.NetworkNodePortType;
import com.windsor.node.ws1.wsdl.NodeDocument;

public class RequestProcesor implements NetworkNodePortType {

    private static final EndpointVersionType ENDPOINT_VERSION = EndpointVersionType.EN11;
    private static final String HTTP_HEADER_FORWARD_FOR = "X-Forward-For";
    private static final String TRAN_NOT_PROVIDED = "Transaction Id not provided";
    private static final String TOKEN_NOT_PROVIDED = "Token not provided";
    private static final String REQUEST_NOT_PROVIDED = "Request not provided";
    private static final String PARAMETERS = "parameters: ";
    private static final String REQUEST = "request: ";
    private static final String COLON = ": ";
    private static final String REQUEST_IP_HEADER_KEY = "requestIPHeaderProperty";

    private final Logger logger = LoggerFactory.getLogger(getClass());
    private ContentService contentService;
    private SecurityService securityService;
    private TransactionService transactionService;
    private String requestIPHeaderProperty;
    private String nodePingReadyMessage;

    public RequestProcesor() throws RemoteException {

        logger.debug("[RequestProcesor]: Constructor.");

        logger.debug("Getting ApplicationContext from endpoint.xml.");
        ApplicationContext context = new ClassPathXmlApplicationContext(
                new String[] { "endpoint.xml" });

        logger.debug("Getting NOS services.");
        contentService = (ContentService) context.getBean("contentService");
        securityService = (SecurityService) context.getBean("securityService");
        transactionService = (TransactionService) context
                .getBean("transactionService");
        logger.debug("NOS Services Acquired");

        requestIPHeaderProperty = (String) context.getBean(REQUEST_IP_HEADER_KEY);
        this.nodePingReadyMessage = (String)context.getBean("nodePingReadyMessage");
        logger.debug(REQUEST_IP_HEADER_KEY + COLON + requestIPHeaderProperty);
    }

    public String authenticate(String userId, String credential,
            String authenticationMethod) throws RemoteException {
        logger.debug("[authenticate]: Start.");
        if (StringUtils.isBlank(userId)) {
            NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                    "User Id not provided");
        }
        if (StringUtils.isBlank(credential)) {
            NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                    "Password not provided");
        }
        if (StringUtils.isBlank(authenticationMethod)) {
            NodeFault.throwFault(NodeFault.E_AUTHMETHOD,
                    "Authentication method not provided");
        }
        try {
            logger.debug("userId: " + userId);
            logger.debug("credential: *************");
            logger.debug("authenticationMethod: " + authenticationMethod);
            EndpointVisit visit = securityService
                    .endpointAuthenticate(new EndpointAuthenticationRequest(
                            ENDPOINT_VERSION, userId, credential,
                            getClientHost()));
            logger.debug("Visit: " + visit);
            return visit.getToken();
        } catch (Exception ex) {
            logger.error("[authenticate]: Exception: " + ex.getMessage());
        }
        NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                "Authentication failed.");
        return null;
    }

    public String submit(String securityToken, String transactionId,
            String dataflow, NodeDocument[] documents) throws RemoteException {
        logger.debug("[submit]: Enter.");
        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(dataflow)) {
            NodeFault
                    .throwFault(NodeFault.E_INTERNALERROR, "Flow not provided");
        }
        if (documents == null || documents.length == 0) {
            NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                    "Submission does not contain documents");
        }
        EndpointVisit visit = getVisit(securityToken);
        try {
            logger.debug("Number of documents submitted: " + documents.length);
            AsyncComplexContent content = new AsyncComplexContent();
            content.setFlow(new OperationDataFlow(dataflow));
            content.setTransactionId(transactionId);
            content.setDocuments(new ArrayList());
            logger.debug("documents submitted: " + documents.length);
            Document[] nosDocs = new Document[documents.length];
            logger.debug("nosDocs: " + nosDocs.length);
            for (int i = 0; i < documents.length; i++) {
                nosDocs[i] = new Document();
                nosDocs[i].setDocumentId(null);
                nosDocs[i].setDocumentName(documents[i].getName());
                nosDocs[i].setType(CommonContentAndFormatConverter
                        .convert(documents[i].getType()));
                logger.debug("setting content from obtainContentBytes()");
                byte[] docContentBytes = documents[i].retreaveContentCustom();
                if (docContentBytes == null) {
                    throw new RuntimeException("Document content was NULL");
                }
                logger.debug("document content: " + docContentBytes.length);
                nosDocs[i].setContent(docContentBytes);
                content.getDocuments().add(nosDocs[i]);
            }

            logger.debug("Submitting request content...");
            TransactionStatus status = contentService.submit(visit, content);
            return status.getTransactionId();
        } catch (Exception ex) {
            logger.error("[submit]: Error: " + ex.getMessage(), ex);
            NodeFault.throwFault(NodeFault.E_SERVICEUNAVAILABLE, ex
                    .getMessage());
            return null;
        }
    }

    public String getStatus(String securityToken, String transactionId)
            throws RemoteException {
        logger.debug("[getStatus]: Enter.");
        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(transactionId)) {
            NodeFault.throwFault(NodeFault.E_TRANSACTIONID, TRAN_NOT_PROVIDED);
        }
        EndpointVisit visit = getVisit(securityToken);
        try {
            logger.debug("getStatus with transactionId: " + transactionId
                    + ", visit: " + visit);
            TransactionStatus status = transactionService.getStatus(visit,
                    transactionId);
            String result = CommonTransactionStatusCodeConverter
                    .convertTo11Type(status.getStatus()).getType();
            return result;
        } catch (Exception ex) {
            logger.error("[getStatus]: Error: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_TRANSACTIONID, ex.getMessage());
            return null;
        }
    }

    public String notify(String securityToken, String nodeAddress,
            String dataflow, NodeDocument[] documents) throws RemoteException {

        logger.debug("[notify]: Enter.");

        String newNodeAddress = nodeAddress;

        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }

        if (StringUtils.isBlank(dataflow)) {
            NodeFault.throwFault(NodeFault.E_INVALIDDATAFLOW,
                    "Data flow not provided");
        }

        if (documents == null || documents.length == 0) {
            NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                    "Notify does not contain documents");
        }

        if (documents.length != 1) {
            NodeFault.throwFault(NodeFault.E_INTERNALERROR,
                    "Notify allows for only one document at this time");
        }

        if (StringUtils.isBlank(nodeAddress)) {
            newNodeAddress = null;
        }

        EndpointVisit visit = getVisit(securityToken);

        try {
            WnosNotificationMessageCategoryType messageCategory = WnosNotificationMessageCategoryType.None;
            if (dataflow.trim().equalsIgnoreCase(
                    "http://www.exchangenetwork.net/node/event")) {
                messageCategory = WnosNotificationMessageCategoryType.Event;
            } else if (dataflow.trim().equalsIgnoreCase(
                    "http://www.exchangenetwork.net/node/status")) {
                messageCategory = WnosNotificationMessageCategoryType.Status;
            } else {
                messageCategory = WnosNotificationMessageCategoryType.Document;
            }

            ComplexNotification complexNotification = new ComplexNotification();
            complexNotification.setFlowName(dataflow);
            complexNotification.setUri(newNodeAddress);
            complexNotification.setNotifications(new ArrayList());

            logger.debug("Spooling document");
            NodeDocument inDoc = documents[0];
            Notification notification = new Notification();
            notification.setCategory(messageCategory);
            notification.setName(inDoc.getName());

            TransactionStatus status = new TransactionStatus();
            status.setStatus(CommonTransactionStatusCode.Received);

            if (inDoc.getContent() != null) {
                status
                        .setDescription(new String(inDoc
                                .retreaveContentCustom()));
            } else {
                status.setDescription("No DIME content in the message");
            }

            notification.setStatus(status);
            logger.debug("Spooled notification: " + notification);
            complexNotification.getNotifications().add(notification);
            logger.debug("Executing notify with visit " + visit);
            TransactionStatus result = transactionService.notify(visit,
                    complexNotification);
            logger.debug("Notify transaction status: " + result);
            return CommonTransactionStatusCodeConverter.convertTo11Type(
                    result.getStatus()).getType();
        } catch (Exception ex) {
            logger.error("[notify]: Error: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_SERVICEUNAVAILABLE, ex
                    .getMessage());
            return null;
        }
    }

    public void download(String securityToken, String transactionId,
            String dataflow, ArrayofDocHolder refDocuments)
            throws RemoteException {
        logger.debug("[download]: Enter.");
        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(transactionId)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TRAN_NOT_PROVIDED);
        }
        MessageContext msgContext = MessageContext.getCurrentContext();
        Message msg = msgContext.getResponseMessage();
        Attachments atts = msg.getAttachmentsImpl();
        atts.setSendType(Attachments.SEND_TYPE_DIME);
        logger.debug("[download]: atts: " + atts);
        NodeDocument[] responseDocumentsArray = null;
        EndpointVisit visit = getVisit(securityToken);
        try {
            ComplexContent content = new ComplexContent();
            content.setFlow(new OperationDataFlow(dataflow));
            content.setTransactionId(transactionId);
            logger
                    .debug("Submitting download request with content: "
                            + content);
            List nosDocList = contentService.download(visit, content);
            responseDocumentsArray = new NodeDocument[nosDocList.size()];
            logger.debug("Spooling documents...");
            int i = 0;
            for (Iterator iter = nosDocList.iterator(); iter.hasNext();) {
                NodeDocument responseDocument = new NodeDocument();
                Document nosDoc = (Document) iter.next();
                responseDocument.setName(nosDoc.getDocumentName());
                responseDocument.setType(CommonContentAndFormatConverter
                        .convertTo11Type(nosDoc.getType()).getType());
                responseDocument.populateContentCustom(nosDoc.getContent(),
                        true);
                logger.debug("responseDocument set");
                responseDocumentsArray[i] = responseDocument;
                logger
                        .info("responseDocument assigned to responseDocumentsArray");
                i++;
            }

            logger.debug("setting refDocuments.value");
            refDocuments.value = responseDocumentsArray;
            logger.debug("refDocuments.value set");
        } catch (Exception ex) {
            logger.error("[download]: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_INTERNALERROR, ex.getMessage());
        }
    }

    public String query(String securityToken, String request, BigInteger rowId,
            BigInteger maxRows, String[] parameters) throws RemoteException {

        logger.debug("[query]: Enter.");

        BigInteger newRowId = rowId;

        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(request)) {
            NodeFault.throwFault(NodeFault.E_INVALIDPARAMETER,
                    REQUEST_NOT_PROVIDED);
        }
        if (rowId == null) {
            newRowId = BigInteger.ZERO;
        }
        if (maxRows == null) {
            newRowId = BigInteger.valueOf(-1L);
        }
        EndpointVisit visit = getVisit(securityToken);
        try {
            logger.debug(REQUEST + request);
            logger.debug("rowId: " + newRowId.intValue());
            logger.debug("maxRows: " + maxRows.intValue());
            logger.debug(PARAMETERS + parameters);
            DataRequest dataRequest = new DataRequest();
            dataRequest.setService(new DataService(request));
            dataRequest.setPaging(new PaginationIndicator());
            dataRequest.getPaging().setStart(newRowId.intValue());
            dataRequest.getPaging().setCount(maxRows.intValue());
            dataRequest.setParameters(createParameters(parameters));
            logger.debug("Querying with paginated request: " + dataRequest);
            ProcessContentResult result = transactionService.query(visit,
                    dataRequest);
            logger.debug("Result: " + result);
            if (result.getDocuments() == null) {
                throw new RuntimeException("Null documents");
            }
            if (result.getDocuments().size() != 1) {
                throw new RuntimeException("Result not one document");
            } else {
                Document doc = (Document) result.getDocuments().get(0);
                logger.debug("Document: " + doc);
                return new String(doc.getContent());
            }
        } catch (Exception ex) {
            logger.error("[query]: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_INTERNALERROR, ex.getMessage());
            return null;
        }
    }

    public String solicit(String securityToken, String returnURL,
            String request, String[] parameters) throws RemoteException {
        logger.debug("[solicit]: Enter.");
        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(request)) {
            NodeFault.throwFault(NodeFault.E_INVALIDPARAMETER,
                    REQUEST_NOT_PROVIDED);
        }
        EndpointVisit visit = getVisit(securityToken);
        try {
            logger.debug("returnURL: " + returnURL);
            logger.debug(REQUEST + request);
            logger.debug(PARAMETERS + parameters);
            DataRequest dataRequest = new DataRequest();
            dataRequest.setService(new DataService(request));
            dataRequest.setParameters(createParameters(parameters));
            if (!StringUtils.isEmpty(returnURL)) {
                dataRequest.getRecipients().add(returnURL);
            }
            TransactionStatus status = transactionService.solicit(visit,
                    dataRequest);
            return status.getTransactionId();
        } catch (Exception ex) {
            logger.error("[solicit]: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_INTERNALERROR, ex.getMessage());
            return null;
        }
    }

    public String execute(String securityToken, String request,
            String[] parameters) throws RemoteException {
        NodeFault.throwFault(NodeFault.E_UNKNOWNMETHOD,
                "For security reasons the execute method is not supported.");
        return null;
    }

    public String nodePing(String hello) throws RemoteException {
        logger.debug("[nodePing]: hello: " + hello);
        return this.nodePingReadyMessage;
    }

    public String[] getServices(String securityToken, String serviceType)
            throws RemoteException {
        logger.debug("[getServices]: Enter.");
        if (StringUtils.isBlank(securityToken)) {
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, TOKEN_NOT_PROVIDED);
        }
        if (StringUtils.isBlank(serviceType)) {
            NodeFault.throwFault(NodeFault.E_INVALIDPARAMETER,
                    "Service type not provided");
        }
        EndpointVisit visit = getVisit(securityToken);
        try {
            logger.debug("serviceType: " + serviceType);
            return new String[] { contentService.getServicesSimple(visit,
                    serviceType).toString() };
        } catch (Exception ex) {
            logger.error("[getServices]: Error: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_INTERNALERROR, ex.getMessage());
            return null;
        }
    }

    private String getClientHost() {
        MessageContext msgContext = MessageContext.getCurrentContext();
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
                    logger.debug(HTTP_HEADER_FORWARD_FOR + COLON + clientHost);
                }
            }

        } else {
            clientHost = request.getHeader(requestIPHeaderProperty);
            logger.debug(requestIPHeaderProperty + COLON + clientHost);
        }

        logger.debug("[host]: " + clientHost);
        return clientHost;
    }

    private EndpointVisit getVisit(String securityToken) throws RemoteException {
        EndpointVisit visit = null;
        try {
            logger.debug("[token]: " + securityToken);
            EndpointTokenValidationRequest request = new EndpointTokenValidationRequest(
                    ENDPOINT_VERSION, securityToken, getClientHost());
            logger.debug("[request]: " + request);
            visit = securityService.endpointValidate(request);
            logger.debug("[visit]: " + request);
        } catch (Exception ex) {
            logger.error("[token]: ERROR: " + ex.getMessage());
            NodeFault.throwFault(NodeFault.E_INVALIDTOKEN, ex.getMessage());
        }
        return visit;
    }

    private ByIndexOrNameMap createParameters(String[] params) {
        ByIndexOrNameMap map = new ByIndexOrNameMap();
        if (null != params && params.length > 0) {
            for (int i = 0; i < params.length; i++) {
                map.put(i, params[i]);
            }

        }
        return map;
    }

    public void setRequestIPHeaderProperty(String requestIPHeaderProperty) {
        this.requestIPHeaderProperty = requestIPHeaderProperty;
    }

}

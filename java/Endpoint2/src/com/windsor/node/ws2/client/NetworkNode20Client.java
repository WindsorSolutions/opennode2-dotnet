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

package com.windsor.node.ws2.client;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.math.BigInteger;
import java.net.URL;
import java.util.Iterator;
import java.util.Map;

import javax.activation.DataHandler;
import javax.xml.namespace.QName;

import net.exchangenetwork.www.schema.node._2.Authenticate;
import net.exchangenetwork.www.schema.node._2.AuthenticateResponse;
import net.exchangenetwork.www.schema.node._2.DocumentFormatType;
import net.exchangenetwork.www.schema.node._2.Download;
import net.exchangenetwork.www.schema.node._2.DownloadResponse;
import net.exchangenetwork.www.schema.node._2.EncodingType;
import net.exchangenetwork.www.schema.node._2.GetStatus;
import net.exchangenetwork.www.schema.node._2.GetStatusResponse;
import net.exchangenetwork.www.schema.node._2.NodeDocumentType;
import net.exchangenetwork.www.schema.node._2.NotificationMessageType;
import net.exchangenetwork.www.schema.node._2.NotificationTypeCode;
import net.exchangenetwork.www.schema.node._2.NotificationURIType;
import net.exchangenetwork.www.schema.node._2.Notify;
import net.exchangenetwork.www.schema.node._2.NotifyResponse;
import net.exchangenetwork.www.schema.node._2.ParameterType;
import net.exchangenetwork.www.schema.node._2.Query;
import net.exchangenetwork.www.schema.node._2.QueryResponse;
import net.exchangenetwork.www.schema.node._2.Solicit;
import net.exchangenetwork.www.schema.node._2.SolicitResponse;
import net.exchangenetwork.www.schema.node._2.Submit;
import net.exchangenetwork.www.schema.node._2.SubmitResponse;
import net.exchangenetwork.www.schema.node._2.TransactionStatusCode;

import org.apache.axis2.AxisFault;
import org.apache.axis2.databinding.types.Id;
import org.apache.axis2.databinding.types.NCName;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;

import sun.misc.BASE64Decoder;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.Notification;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.WnosNotificationMessageCategoryType;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.CommonTransactionStatusCodeConverter;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.ws2.util.NodeUtil;

public class NetworkNode20Client implements NodeClientService {

    private static final String NO_TRANSACTION_DOCUMENTS = "No transaction documents";

    private static final String NULL_TRANSACTION = "Null transaction";

    private static final Logger logger = Logger
            .getLogger(NetworkNode20Client.class.getName());

    private URL partnerEndpointUrl;
    private NAASAccount credential;
    private String localEndpointUrl;
    private File tempDir;

    public void configure(URL partnerEndpointUrl, String localEndpointUrl,
            NAASAccount credentials, File tempDir) {

        if (tempDir == null || !tempDir.exists() || !tempDir.isDirectory()) {
            throw new RuntimeException("Null tempDir");
        }

        if (partnerEndpointUrl == null) {
            throw new RuntimeException("Null partner");
        }

        if (StringUtils.isBlank(localEndpointUrl)) {
            throw new RuntimeException("Null partner");
        }

        if (credentials == null
                || StringUtils.isBlank(credentials.getUsername())
                || StringUtils.isBlank(credentials.getPassword())) {
            throw new RuntimeException("Null credentials");
        }

        this.partnerEndpointUrl = partnerEndpointUrl;
        logger.debug("En20Client created with URL: " + partnerEndpointUrl);

        this.credential = credentials;
        logger.debug("Using account: " + credentials.getUsername());

        this.localEndpointUrl = localEndpointUrl;
        logger.debug("Local endpoint: " + localEndpointUrl);

        this.tempDir = tempDir;
        logger.debug("Temp Dir: " + tempDir);
    }

    /**
     * getStub
     * 
     * @param operationId
     * @return
     * @throws AxisFault
     */
    private NetworkNode2Stub getStub(String operation) throws AxisFault {
        logger.debug("Getting stub for: " + partnerEndpointUrl.toString());
        return new NetworkNode2Stub(partnerEndpointUrl.toString());
    }

    /**
     * authenticate
     * 
     * @return
     */
    private String authenticate() {

        try {

            logger.debug("Invoking authenticate...");

            Authenticate authRequest = new Authenticate();
            authRequest.setAuthenticationMethod(credential.getAuthMethod());
            authRequest.setCredential(credential.getPassword());
            authRequest.setDomain(credential.getDomain());
            authRequest.setUserId(credential.getUsername());

            AuthenticateResponse response = getStub("Authenticate")
                    .Authenticate(authRequest);

            if (response == null
                    || StringUtils.isBlank(response.getSecurityToken())) {
                throw new RuntimeException("Null token");
            }

            logger.debug("Security token: " + response.getSecurityToken());

            return response.getSecurityToken();

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while authenticating to: "
                    + partnerEndpointUrl + " using: "
                    + credential.getUsername() + " Message: " + ex.getMessage());
        }
    }

    /**
     * download
     */
    public NodeTransaction download(NodeTransaction transaction) {

        if (transaction == null) {
            throw new RuntimeException(NULL_TRANSACTION);
        }

        if (StringUtils.isBlank(transaction.getNetworkId())) {
            throw new RuntimeException("Null network transaction Id");
        }

        if (transaction.getFlow() == null
                || StringUtils.isBlank(transaction.getFlow().getName())) {
            throw new RuntimeException("Null data flow name");
        }

        try {

            String token = authenticate();
            logger.debug("token: " + token);

            File targetDir = new File(FilenameUtils.concat(tempDir
                    .getAbsolutePath(), "Temp-" + System.currentTimeMillis()));
            logger.debug("creating temp dir: " + targetDir);
            FileUtils.forceMkdir(targetDir);

            if (!targetDir.exists()) {
                throw new RuntimeException("Unable to create temp dir: "
                        + targetDir);
            }

            Download downloadReq = new Download();
            downloadReq
                    .setDataflow(new NCName(transaction.getFlow().getName()));
            downloadReq.setSecurityToken(token);
            downloadReq.setTransactionId(transaction.getNetworkId());

            // If documents are specified
            if (transaction.getDocuments() != null) {
                for (int d = 0; d < transaction.getDocuments().size(); d++) {

                    Document wnosDoc = (Document) transaction.getDocuments()
                            .get(d);
                    NodeDocumentType reqDoc = new NodeDocumentType();

                    logger.debug("Setting document format type from: "
                            + wnosDoc.getType());

                    reqDoc.setDocumentFormat(DocumentFormatType.Factory
                            .fromValue(wnosDoc.getType().getName()));

                    if (StringUtils.isNotBlank(wnosDoc.getDocumentId())) {

                        reqDoc.setDocumentId(new Id(wnosDoc.getDocumentId()));
                        reqDoc.setDocumentName("");

                    } else if (StringUtils
                            .isNotBlank(wnosDoc.getDocumentName())) {

                        reqDoc.setDocumentName(wnosDoc.getDocumentName());

                    } else {
                        throw new RuntimeException(
                                "Document Id or Name required");
                    }

                    downloadReq.addDocuments(reqDoc);
                }
            }

            logger.debug("Downloading...");
            DownloadResponse downloadResp = getStub("Download").Download(
                    downloadReq);

            if (downloadResp == null) {
                throw new RuntimeException("Null DownloadResponse");
            }

            transaction.getDocuments().clear();

            logger.debug("Spooling files...");
            for (int i = 0; i < downloadResp.getDocuments().length; i++) {

                NodeDocumentType nodeDoc = downloadResp.getDocuments()[i];

                File targetFile = new File(FilenameUtils.concat(targetDir
                        .getAbsolutePath(), nodeDoc.getDocumentName()));

                logger.debug("Target : " + targetFile);

                DataHandler docHandler = nodeDoc.getDocumentContent()
                        .getBase64Binary();

                FileOutputStream dest = new FileOutputStream(targetFile
                        .getAbsoluteFile());
                docHandler.writeTo(dest);
                dest.flush();
                dest.close();

                if (!targetFile.exists()) {
                    throw new RuntimeException("Null result file: "
                            + targetFile);
                }

                Document doc = new Document();

                // Content
                FileInputStream decodedStream = new FileInputStream(targetFile);
                doc.setContent(new BASE64Decoder().decodeBuffer(decodedStream));
                decodedStream.close();

                if (nodeDoc.getDocumentId() != null
                        && StringUtils.isNotBlank(nodeDoc.getDocumentId()
                                .toString())) {
                    doc.setDocumentId(nodeDoc.getDocumentId().toString());
                }
                doc.setDocumentName(nodeDoc.getDocumentName());
                doc.setDocumentStatus(CommonTransactionStatusCode.RECEIVED);
                doc.setDocumentStatusDetail("Document downloaded");

                if (nodeDoc.getDocumentFormat() != null
                        && StringUtils.isNotBlank(nodeDoc.getDocumentFormat()
                                .getValue())) {
                    doc.setType((CommonContentType) CommonContentType
                            .getEnumMap().get(
                                    nodeDoc.getDocumentFormat().getValue()));
                }

                transaction.getDocuments().add(doc);

            }

            TransactionStatus status = new TransactionStatus(transaction
                    .getNetworkId());
            status.setDescription("Notification performed");
            status.setStatus(CommonTransactionStatusCode.UNKNOWN);

            transaction.setStatus(status);

            return transaction;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while downloading from: "
                    + partnerEndpointUrl + " using: " + transaction, ex);
        }

    }

    /**
     * getStatus
     */
    public TransactionStatus getStatus(String transactionId) {

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("Null transactionId");
        }

        try {

            logger.debug("Invoking authenticate...");
            logger.debug("TransactionId: " + transactionId);

            GetStatus request = new GetStatus();
            request.setSecurityToken(authenticate());
            request.setTransactionId(transactionId);

            GetStatusResponse response = getStub("GetStatus")
                    .GetStatus(request);

            logger.debug("Response: " + response);

            if (response == null || response.getGetStatusResponse() == null) {
                throw new RuntimeException("Empty token returned");
            }

            TransactionStatus status = new TransactionStatus(response
                    .getGetStatusResponse().getTransactionId());
            status.setDescription(response.getGetStatusResponse()
                    .getStatusDetail());
            status
                    .setStatus((CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                            .convert(
                                    response.getGetStatusResponse().getStatus()
                                            .getValue()));

            logger.debug("Status: " + status);

            return status;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while getting status to: "
                    + partnerEndpointUrl + " using: " + transactionId, ex);
        }

    }

    /**
     * notify
     */
    public TransactionStatus notify(Notification notification) {

        if (notification == null) {
            throw new RuntimeException("Null notification");
        }

        try {

            logger.debug("Creating Notification: " + notification.getName());
            logger.debug("Notification: " + notification);

            Notify request = new Notify();
            request.setNodeAddress(localEndpointUrl);
            NotificationMessageType msg = new NotificationMessageType();

            if (notification.getCategory() == WnosNotificationMessageCategoryType.STATUS) {
                msg
                        .setMessageCategory(net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType.Status);
                msg.setObjectId(notification.getStatus().getTransactionId());

                logger.debug("Request: " + request);
            } else if (notification.getCategory() == WnosNotificationMessageCategoryType.EVENT) {
                msg
                        .setMessageCategory(net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType.Event);
                msg.setObjectId(notification.getName());

            } else if (notification.getCategory() == WnosNotificationMessageCategoryType.DOCUMENT) {
                msg
                        .setMessageCategory(net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType.Document);
                msg.setObjectId(notification.getStatus().getTransactionId());

            } else {
                throw new RuntimeException(
                        "Null NotificationMessageCategoryType");
            }

            msg.setMessageName(notification.getStatus().getStatus().getName());
            msg.setStatus(TransactionStatusCode.Factory.fromString(notification
                    .getStatus().getStatus().getName(), null));
            msg.setStatusDetail(notification.getStatus().getDescription());

            request.addMessages(msg);
            request.setDataflow(new NCName(notification.getFlowName()));
            request.setSecurityToken(authenticate());

            logger.debug("Invoking notify...");
            NotifyResponse response = getStub("Notify").Notify(request);

            if (response == null || response.getNotifyResponse() == null) {
                throw new RuntimeException("Empty response returned");
            }

            logger.debug("Response: " + response);

            TransactionStatus status = new TransactionStatus(response
                    .getNotifyResponse().getTransactionId());
            status.setDescription(response.getNotifyResponse()
                    .getStatusDetail());
            status.setStatus(CommonTransactionStatusCode.RECEIVED);

            logger.debug("Status: " + status);

            return status;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while notifying: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * query
     */
    public SimpleContent query(DataRequest request) {

        if (request == null) {
            throw new RuntimeException("Null request");
        }

        try {

            logger.debug("Invoking Query with DataRequest: " + request);

            Query queryReq = new Query();
            queryReq.setDataflow(new NCName(request.getFlowName()));
            queryReq.setSecurityToken(authenticate());
            queryReq.setRowId(BigInteger
                    .valueOf(request.getPaging().getStart()));
            queryReq.setMaxRows(BigInteger.valueOf(request.getPaging()
                    .getCount()));
            queryReq.setRequest(request.getService().getName());

            ByIndexOrNameMap map = request.getParameters();
            logger.debug("Request parameters size: " + map.size());
            logger.debug("Request parameters: " + map);

            for (Iterator it = map.keySet().iterator(); it.hasNext();) {
                String key = (String) it.next();
                ParameterType queryParam = new ParameterType();
                queryParam.setParameterEncoding(EncodingType.XML);
                queryParam.setParameterType(new QName("xsd", "string"));
                queryParam.setParameterName(key);
                queryParam.setString((String) map.get(key));
                queryReq.addParameters(queryParam);
            }

            QueryResponse response = getStub("Query").Query(queryReq);

            logger.debug("Response received");

            if (response == null || response.getQueryResponse() == null) {
                throw new RuntimeException("Empty response returned");
            }

            Document doc = NodeUtil.getBytesFromGenericXmlType(response
                    .getQueryResponse().getResults());

            SimpleContent content = new SimpleContent();
            content.setContent(doc.getContent());
            content.setType(doc.getType());

            logger.debug("Document received");

            return content;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while querying: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * submit
     */
    public NodeTransaction submit(NodeTransaction transaction) {

        if (transaction == null) {
            logger.error(NULL_TRANSACTION);
            throw new RuntimeException(NULL_TRANSACTION);
        }

        if (transaction.getDocuments() == null
                || transaction.getDocuments().size() < 1) {
            logger.error(NO_TRANSACTION_DOCUMENTS);
            throw new RuntimeException(NO_TRANSACTION_DOCUMENTS);
        }

        try {

            logger.debug("Invoking submit...");
            logger.debug("Transaction: " + transaction);

            Submit submitRequest = new Submit();
            submitRequest.setSecurityToken(authenticate());
            submitRequest.setDataflow(new NCName(transaction.getFlow()
                    .getName()));
            submitRequest.setFlowOperation(transaction.getOperation());

            logger.debug("Add notifications for ALL: " + localEndpointUrl);
            NotificationURIType notifType = new NotificationURIType();
            notifType.setNotificationType(NotificationTypeCode.All);
            notifType.setString(localEndpointUrl);
            submitRequest
                    .setNotificationURI(new NotificationURIType[] { notifType });

            for (int d = 0; d < transaction.getDocuments().size(); d++) {
                Document doc = (Document) transaction.getDocuments().get(d);
                logger.debug("Local Doc: " + doc);
                submitRequest.addDocuments(NodeUtil
                        .getNodeDocumentFromWnosDoc(doc));
            }

            String transactionIdToSubmit = "";

            if (transaction.getWebMethod() == NodeMethodType.SOLICIT) {
                transactionIdToSubmit = transaction.getNetworkId();
            }

            submitRequest.setTransactionId(transactionIdToSubmit);

            SubmitResponse response = getStub("Submit").Submit(submitRequest);

            logger.debug("Response: " + response);

            if (response == null
                    || response.getSubmitResponse() == null
                    || StringUtils.isBlank(response.getSubmitResponse()
                            .getTransactionId())) {
                throw new RuntimeException("Empty response returned");
            }

            logger.debug("Remote Transaction Id: "
                    + response.getSubmitResponse().getTransactionId());

            transaction.setNetworkId(response.getSubmitResponse()
                    .getTransactionId());
            transaction.getStatus().setTransactionId(
                    response.getSubmitResponse().getTransactionId());
            transaction.getStatus().setDescription(
                    response.getSubmitResponse().getStatusDetail());
            transaction.getStatus().setStatus(
                    (CommonTransactionStatusCode) CommonTransactionStatusCodeConverter
                                    .convert(
                                    response.getSubmitResponse().getStatus()
                                            .getValue()));

            logger.debug("Transaction: " + transaction);

            return transaction;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while submitting: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * solicit
     */
    public TransactionStatus solicit(DataRequest request) {

        if (request == null) {
            throw new RuntimeException("Null request");
        }

        try {

            logger.debug("Invoking solicit...");
            logger.debug("Request: " + request);

            Solicit solicitReq = new Solicit();
            solicitReq.setDataflow(new NCName(request.getFlowName()));
            solicitReq.setSecurityToken(authenticate());
            solicitReq.setRequest(request.getService().getName());

            if (request.getParameters() != null) {
                ByIndexOrNameMap map = request.getParameters();
                logger.debug("Params: " + map);
                for (Iterator it = map.keySet().iterator(); it.hasNext();) {

                    String key = (String) it.next();

                    ParameterType queryParam = new ParameterType();

                    queryParam.setParameterName(key);
                    queryParam.setString((String) map.get(key));

                    solicitReq.addParameters(queryParam);
                }
            }

            if (request.getRecipients() != null) {
                logger.debug("Recipients: " + request.getRecipients());
                for (int i = 0; i < request.getRecipients().size(); i++) {
                    solicitReq.addRecipient((String) request.getRecipients()
                            .get(i));
                }
            }

            if (request.getNotifications() != null) {
                logger.debug("Notifications: " + request.getNotifications());

                int mapsize = request.getNotifications().size();
                Iterator notifPairs = request.getNotifications().entrySet()
                        .iterator();
                for (int i = 0; i < mapsize; i++) {
                    Map.Entry entry = (Map.Entry) notifPairs.next();

                    NotificationURIType notif = new NotificationURIType();

                    notif.setNotificationType(NotificationTypeCode.All);
                    notif.setString((String) entry.getKey());

                    solicitReq.addNotificationURI(notif);
                }
            }

            logger.debug("Soliciting...");
            SolicitResponse response = getStub("Solicit").Solicit(solicitReq);

            if (response == null || response.getSolicitResponse() == null) {
                throw new RuntimeException("Empty response returned");
            }

            logger.debug("Parsing response...");
            TransactionStatus status = new TransactionStatus(response
                    .getSolicitResponse().getTransactionId());
            status.setDescription(response.getSolicitResponse()
                    .getStatusDetail());
            status.setStatus(CommonTransactionStatusCode.RECEIVED);
            logger.debug("Status: " + status);

            return status;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while soliciting: "
                    + ex.getMessage(), ex);
        }

    }
}

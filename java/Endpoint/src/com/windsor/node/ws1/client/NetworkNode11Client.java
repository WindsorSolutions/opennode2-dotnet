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

package com.windsor.node.ws1.client;

import java.io.File;
import java.math.BigInteger;
import java.net.URL;

import org.apache.axis.AxisFault;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.Notification;
import com.windsor.node.common.domain.WnosNotificationMessageCategoryType;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.ws1.wsdl.ArrayofDocHolder;
import com.windsor.node.ws1.wsdl.NetworkNodeBindingStub;
import com.windsor.node.ws1.wsdl.NetworkNodeLocator;
import com.windsor.node.ws1.wsdl.NodeDocument;

/**
 * @author mchmarny
 * 
 */
public class NetworkNode11Client implements NodeClientService {

    // static {
    // System.setProperty("axis.ClientConfigFile",
    // "com/windsor/node/ws1/client/client-config.wsdd");
    // }

    private static final Logger logger = Logger
            .getLogger(NetworkNode11Client.class.getName());

    private URL partnerEndpointUrl;
    private NAASAccount credential;
    private String localEndpointUrl;
    private File tempDir;

    /**
     * En11Client
     * 
     * @param partner
     * @param credentials
     */
    public void configure(URL partnerEndpointUrl, String localEndpointUrl,
            NAASAccount credentials, File tempDir) {

        if (tempDir == null || !tempDir.exists() || !tempDir.isDirectory()) {
            throw new RuntimeException("Null tempDir");
        }

        if (partnerEndpointUrl == null) {
            throw new RuntimeException("Null partnerEndpointUrl");
        }

        if (StringUtils.isBlank(localEndpointUrl)) {
            throw new RuntimeException("Null localEndpointUrl");
        }

        if (credentials == null
                || StringUtils.isBlank(credentials.getUsername())
                || StringUtils.isBlank(credentials.getPassword())) {
            throw new RuntimeException("Null credentials");
        }

        this.partnerEndpointUrl = partnerEndpointUrl;
        this.credential = credentials;
        this.localEndpointUrl = localEndpointUrl;
        this.tempDir = tempDir;

        logger.debug("En11Client created with URL: " + partnerEndpointUrl);
    }

    /**
     * getStub
     * 
     * @param operationId
     * @return
     * @throws AxisFault
     */
    private NetworkNodeBindingStub getStub(String operationId) throws AxisFault {

        NetworkNodeLocator locator = new NetworkNodeLocator();
        NetworkNodeBindingStub stub = new NetworkNodeBindingStub(
                partnerEndpointUrl, locator);

        if (StringUtils.isNotBlank(operationId)) {
            stub._setProperty("operationId", operationId);
        }

        return stub;
    }

    /**
     * getStatus
     */
    public TransactionStatus getStatus(String transactionId) {

        TransactionStatus status = new TransactionStatus(transactionId);
        status
                .setStatus((CommonTransactionStatusCode) CommonTransactionStatusCode
                        .getEnumMap().get(
                                getStatus(authenticate(), transactionId)));

        return status;

    }

    /**
     * download
     */
    public NodeTransaction download(NodeTransaction transaction) {

        if (transaction == null) {
            throw new RuntimeException("Null transaction");
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

            logger.debug("downloading...");
            download(token, transaction.getNetworkId(), transaction.getFlow()
                    .getName(), targetDir);

            logger.debug("spooling files...");
            for (int i = 0; i < targetDir.list().length; i++) {

                File tempFile = new File(targetDir.list()[i]);
                logger.debug("File: " + tempFile);
                Document doc = new Document();

                doc.setContent(FileUtils.readFileToByteArray(tempFile));
                doc.setDocumentName(tempFile.getName());
                doc.setDocumentStatus(CommonTransactionStatusCode.RECEIVED);
                doc.setDocumentStatusDetail("Document downloaded");

                transaction.getDocuments().add(doc);

            }

            logger.debug("Deleting on exit: " + targetDir);
            FileUtils.forceDeleteOnExit(targetDir);

            TransactionStatus status = new TransactionStatus(transaction
                    .getNetworkId());
            status.setDescription("Notification performed");
            status.setStatus(CommonTransactionStatusCode.UNKNOWN);

            transaction.setStatus(status);

            return transaction;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while downloading: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * notify
     */
    public TransactionStatus notify(Notification notification) {

        try {
            NetworkNodeBindingStub port = getStub("notify");
            logger.debug("Creating Notification: " + notification.getName());

            String token = authenticate();
            logger.debug("token: " + token);

            String dataFlow = null;

            if (notification.getCategory() == WnosNotificationMessageCategoryType.STATUS) {
                dataFlow = "http://www.exchangenetwork.net/node/status";

            } else if (notification.getCategory() == WnosNotificationMessageCategoryType.EVENT) {
                dataFlow = "http://www.exchangenetwork.net/node/event";

            } else {
                dataFlow = "Other";
            }

            NodeDocument document = new NodeDocument();
            document.setName(notification.getStatus().getTransactionId());
            document.setType(notification.getStatus().getStatus().getName());
            document.setContent(notification.getStatus().getDescription()
                    .getBytes("UTF-8"));
            logger.debug("Node Document: " + document);

            NodeDocument[] documents = new NodeDocument[1];
            documents[0] = document;

            logger.debug("Invoking notify...");
            String transactionId = port.notify(token, localEndpointUrl,
                    dataFlow, documents);

            logger.debug("Result: " + transactionId);

            TransactionStatus status = new TransactionStatus(transactionId);
            status.setDescription("Notification performed");
            status.setStatus(CommonTransactionStatusCode.RECEIVED);

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

        SimpleContent content = new SimpleContent();

        try {
            NetworkNodeBindingStub port = getStub("query");
            logger.debug("Invoking query...");

            String token = authenticate();
            logger.debug("token: " + token);

            String serviceName = request.getService().getName();
            logger.debug("serviceName: " + serviceName);

            BigInteger start = BigInteger.valueOf(request.getPaging()
                    .getStart());
            logger.debug("start: " + start);

            BigInteger end = BigInteger.valueOf(request.getPaging().getCount());
            logger.debug("end: " + end);

            String[] args = new String[request.getParameters().size()];
            for (int i = 0; i < args.length; i++) {
                args[i] = (String) request.getParameters().get(i);
            }

            logger.debug("args: " + StringUtils.join(args));

            String queryResult = port.query(token, serviceName, start, end,
                    args);

            content.setContent(queryResult.getBytes("UTF-8"));

            content.setType(CommonContentType.XML);

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while downloading: "
                    + ex.getMessage(), ex);
        }

        return content;

    }

    /**
     * authenticate
     * 
     * @return
     */
    private String authenticate() {

        try {
            String token = null;
            NetworkNodeBindingStub stub = getStub("authenticate");
            logger.debug("Invoking authenticate...");
            token = stub.authenticate(credential.getUsername(), credential
                    .getPassword(), "password");
            logger.debug("Result: " + token);

            if (StringUtils.isBlank(token)) {
                throw new RuntimeException("Empty token returned");
            }

            return token;

        } catch (Exception ex) {
            logger.error(ex);
            String message = ex.getMessage();
            if (StringUtils.isBlank(message)) {
                message = "Endpoint has thrown an unhanded exception. "
                        + "Most likely the remote service is not operational.";
            }
            throw new RuntimeException("Error while authenticating to: "
                    + partnerEndpointUrl + " using: "
                    + credential.getUsername() + ". Message: " + message);
        }
    }

    /**
     * submit
     */
    public NodeTransaction submit(NodeTransaction transaction) {

        try {

            logger.debug("Transaction to submit: " + transaction);

            if (transaction == null) {
                throw new Exception("Null transaction");
            }

            if (transaction.getDocuments() == null
                    || transaction.getDocuments().size() < 1) {
                throw new Exception("Null transaction documents");
            }

            NetworkNodeBindingStub port = getStub("submit");

            String token = authenticate();

            NodeDocument[] documents = new NodeDocument[transaction
                    .getDocuments().size()];
            for (int d = 0; d < transaction.getDocuments().size(); d++) {

                Document doc = (Document) transaction.getDocuments().get(d);
                logger.debug("Local Doc: " + doc);

                NodeDocument document = new NodeDocument();
                document.setName(doc.getDocumentName());
                document.setType(doc.getType().getName());

                logger.debug("Local Document Content Size: "
                        + doc.getContent().length);

                document.populateContentCustom(doc.getContent(), true);

                logger.debug("WSDL Document Content Size: "
                        + document.retreaveContentCustom().length);

                logger.debug("Local should equal to the WSDL size!");

                documents[d] = document;
                logger.debug("Network Doc: " + doc);

            }

            logger.debug("Invoking submit...");

            String transactionIdToSubmit = "";

            if (transaction.getWebMethod() == NodeMethodType.SOLICIT) {
                transactionIdToSubmit = transaction.getNetworkId();
            }

            logger.debug("Submitting...");
            String remoteTransactionId = port.submit(token,
                    transactionIdToSubmit, transaction.getFlow().getName(),
                    documents);
            logger.debug("Remote Transaction Id: " + remoteTransactionId);

            transaction.setNetworkId(remoteTransactionId);

            return transaction;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while submitting: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Download
     * 
     * @param securityToken
     * @param transactionId
     * @param dataflowType
     * @param saveToDirectory
     * @return
     * @throws Exception
     */
    public File[] download(String securityToken, String transactionId,
            String dataflowType, File saveToDirectory) {

        logger.debug("Invoking download...");

        try {

            NetworkNodeBindingStub port = getStub("download");
            NodeDocument[] documents = new NodeDocument[0];

            ArrayofDocHolder array = new ArrayofDocHolder(documents);
            port.download(securityToken, transactionId, dataflowType, array);
            logger.debug("Getting Files...");
            return array.getFiles(saveToDirectory);

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while downloading: "
                    + ex.getMessage(), ex);
        }
    }

    /**
     * solicit
     */
    public TransactionStatus solicit(DataRequest request) {

        try {

            NetworkNodeBindingStub port = getStub("solicit");
            logger.debug("Invoking solicit...");

            String token = authenticate();
            logger.debug("token: " + token);

            String serviceName = request.getService().getName();
            logger.debug("serviceName: " + serviceName);

            String[] args = new String[request.getParameters().size()];
            for (int i = 0; i < args.length; i++) {
                args[i] = (String) request.getParameters().get(i);
            }

            logger.debug("args: " + StringUtils.join(args));

            String returnUrl = null;

            if (request.getRecipients() != null) {

                if (request.getRecipients().size() != 1) {
                    throw new RuntimeException(
                            "1.1 Client allows only one return Url. Got: "
                                    + request.getRecipients().size());
                }

                returnUrl = (String) request.getRecipients().get(0);

            }

            String transactionId = port.solicit(token, returnUrl, serviceName,
                    args);
            logger.debug("Result: " + transactionId);

            TransactionStatus status = new TransactionStatus(transactionId);
            status.setDescription("Notification performed");
            status.setStatus(CommonTransactionStatusCode.RECEIVED);

            return status;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while solicitung: "
                    + ex.getMessage(), ex);
        }
    }

    /**
     * Notifying
     * 
     * @param securityToken
     * @param nodeAddress
     * @param dataflowType
     * @param documentName
     * @param documentType
     * @return
     * @throws Exception
     */
    public String notify(String securityToken, String nodeAddress,
            String dataflowType, String documentName, String documentType) {

        try {
            NetworkNodeBindingStub port = getStub("notify");
            logger.debug("Creating Document: (Name: " + documentName
                    + "; Type: " + documentType + ")");
            NodeDocument[] documents = new NodeDocument[1];
            NodeDocument document = new NodeDocument();
            document.setName(documentName);
            document.setType(documentType);
            document.setContent(documentName.getBytes("UTF-8"));
            documents[0] = document;
            logger.debug("Invoking notify...");
            String transactionId = port.notify(securityToken, nodeAddress,
                    dataflowType, documents);
            logger.debug("Result: " + transactionId);
            return transactionId;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while notifying: "
                    + ex.getMessage(), ex);
        }
    }

    /**
     * Pinging
     * 
     * @param hello
     * @return
     * @throws Exception
     */
    public String nodePing(String hello) {

        try {
            String response = null;
            NetworkNodeBindingStub port = getStub("nodePing");
            logger.debug("Invoking nodePing...");
            response = port.nodePing(hello);
            logger.debug("Result: " + response);
            return response;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while pinging: "
                    + ex.getMessage(), ex);
        }
    }

    /**
     * Service list
     * 
     * @param securityToken
     * @param serviceType
     * @return
     * @throws Exception
     */
    public String[] getServices(String securityToken, String serviceType) {

        try {
            String[] services = null;
            logger.debug("Getting stub...");
            NetworkNodeBindingStub port = getStub("getServices");
            logger.debug("Invoking getServices...");
            services = port.getServices(securityToken, serviceType);
            if (services != null) {
                for (int i = 0; i < services.length; i++) {
                    logger.debug("Result: " + services[i]);
                }
            }
            return services;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while getting services: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Gets Status
     * 
     * @param securityToken
     * @param transactionId
     * @return
     * @throws Exception
     */
    public String getStatus(String securityToken, String transactionId) {

        try {
            String status = null;
            NetworkNodeBindingStub port = getStub("getStatus");
            logger.debug("Invoking getStatus...");
            status = port.getStatus(securityToken, transactionId);
            logger.debug("Result: " + status);
            return status;

        } catch (Exception ex) {
            logger.error(ex);
            throw new RuntimeException("Error while getting status: "
                    + ex.getMessage(), ex);
        }
    }

}
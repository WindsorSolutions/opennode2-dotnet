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

package com.windsor.node.service.cmf;

import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.AsyncComplexContent;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.ComplexContent;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.EndpointVisit;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.cmf.ContentService;
import com.windsor.node.common.util.CommonContentAndFormatConverter;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.RequestDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.admin.AccountServiceImpl;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.NotificationHelper;

public class ContentServiceImpl extends BaseService implements ContentService,
        InitializingBean {

    public final Logger logger = Logger.getLogger(this.getClass());

    private TransactionDao transactionDao;
    private AccountServiceImpl accountService;
    private ServiceDao serviceDao;
    private RequestDao requestDao;
    private FlowDao flowDao;
    private NotificationHelper notificationHelper;
    private CompressionService compressionHelper;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (requestDao == null) {
            throw new RuntimeException("RequestDao Not Set");
        }

        if (flowDao == null) {
            throw new RuntimeException("FlowDao Not Set");
        }

        if (accountService == null) {
            throw new RuntimeException("AccountService Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        if (serviceDao == null) {
            throw new RuntimeException("ServiceDao Not Set");
        }

        if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper Not Set");
        }

        if (compressionHelper == null) {
            throw new RuntimeException("CompressionService Not Set");
        }

    }

    /**
     * download
     */
    public List download(EndpointVisit visit, ComplexContent content) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        Activity logEntry = makeNewActivity(ActivityType.AUDIT, visit);

        try {

            // TRAN
            if (StringUtils.isBlank(content.getTransactionId())) {
                throw new IllegalArgumentException("Null transaction");
            }

            logger.debug("Getting transaction: " + content.getTransactionId());

            NodeTransaction tran = transactionDao.get(content
                    .getTransactionId(), true);

            if (tran == null) {
                throw new RuntimeException(
                        "Unable to local transaction with that Id: "
                                + content.getTransactionId());
            }

            logEntry.addEntry("Transaction: {0}", new Object[] { tran
                    .getNetworkId() });

            logEntry.setTransactionId(tran.getId());

            if (tran.getFlow() == null) {
                throw new RuntimeException("Null transaction flow");
            }

            logEntry.addEntry("Flow: {0}", new Object[] { tran.getFlow()
                    .getName() });

            // VISIT
            UserAccount account = visit.getUserAccount();

            if (tran.getFlow().isSecured()) {
                accountService
                        .validateAccess(account, tran.getFlow().getName());
            }

            logEntry.setModifiedById(account.getId());

            List docs = null;

            // If no documents specified than get all docs
            if (content.getDocuments() == null
                    || content.getDocuments().size() == 0) {
                logEntry
                        .addEntry("Getting all documents for this transaction: "
                                + tran.getNetworkId());
                docs = transactionDao.getDocuments(tran.getNetworkId(), true,
                        true);
            } else {
                // if docs specified than get only the one we need

                logEntry.addEntry("Getting documents by name and Id...");

                docs = new ArrayList();

                for (int d = 0; d < content.getDocuments().size(); d++) {

                    Document wnosDocIn = (Document) content.getDocuments().get(
                            d);

                    Document wnosDocOut = null;

                    if (StringUtils.isNotBlank(wnosDocIn.getDocumentId())) {

                        logEntry.addEntry("Getting document by Id: "
                                + wnosDocIn.getDocumentId());

                        wnosDocOut = transactionDao.getDocument(tran.getId(),
                                wnosDocIn.getDocumentId());

                        if (wnosDocOut == null) {
                            throw new RuntimeException("Invalid document Id: "
                                    + wnosDocIn.getDocumentId()
                                    + " for transaction Id: "
                                    + tran.getNetworkId());
                        }

                    } else if (StringUtils.isNotBlank(wnosDocIn
                            .getDocumentName())) {

                        logEntry.addEntry("Getting document by Name: "
                                + wnosDocIn.getDocumentName());

                        wnosDocOut = transactionDao.getDocumentByName(tran
                                .getId(), wnosDocIn.getDocumentName());

                        if (wnosDocOut == null) {
                            throw new RuntimeException(
                                    "Invalid document Name: "
                                            + wnosDocIn.getDocumentName()
                                            + " for transaction Id: "
                                            + tran.getNetworkId());
                        }
                    }

                    docs.add(wnosDocOut);

                }

            }

            logEntry.addEntry("Documents: " + docs.size());

            return docs;

        } catch (Exception ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.ERROR);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException("Error while downloading documents: "
                    + ex.getMessage(), ex);

        } finally {

            getActivityDao().make(logEntry);
        }

    }

    /**
     * getServices
     */
    public SimpleContent getServices(EndpointVisit visit, String category) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        Activity logEntry = makeNewActivity(ActivityType.AUDIT, visit);

        // TODO: Implement for real when the spec becomes final (3)
        SimpleContent content = new SimpleContent();

        try {

            // VISIT
            UserAccount account = visit.getUserAccount();

            logEntry.setModifiedById(account.getId());

            StringBuffer sb = new StringBuffer();
            sb.append("<services>");

            Map services = serviceDao.getActive();

            Iterator keyValueIt = services.entrySet().iterator();
            for (int i = 0; i < services.size(); i++) {
                Map.Entry entry = (Map.Entry) keyValueIt.next();
                sb.append("<service>");
                sb.append("" + entry.getValue());
                sb.append("</service>");
            }

            sb.append("</services>");

            try {
                content.setContent(sb.toString().getBytes("UTF-8"));
            } catch (UnsupportedEncodingException uee) {
                throw new RuntimeException(
                        "Error whole converting string to byte[]");
            }

            content.setType(CommonContentType.XML);

        } catch (Exception ex) {
            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.ERROR);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException("Error: " + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

        return content;
    }

    /**
     * This is as good as it is going to get in 1.1
     */
    public String[] getServicesSimple(EndpointVisit visit, String category) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        Activity logEntry = makeNewActivity(ActivityType.AUDIT, visit);

        try {

            // VISIT
            UserAccount account = visit.getUserAccount();

            logEntry.setModifiedById(account.getId());

            Map services = serviceDao.getActive();

            String[] serviceNames = new String[services.size()];
            Iterator keyValueIt = services.entrySet().iterator();
            for (int i = 0; i < services.size(); i++) {
                Map.Entry entry = (Map.Entry) keyValueIt.next();
                serviceNames[i] = (String) entry.getValue();
            }

            return serviceNames;

        } catch (Exception ex) {
            logger.debug(ex.getMessage(), ex);

            logEntry.setType(ActivityType.ERROR);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException("Error: " + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /**
     * submit
     */
    public TransactionStatus submit(EndpointVisit visit,
            AsyncComplexContent content) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        if (content == null) {
            throw new RuntimeException("Null content");
        }

        Activity logEntry = makeNewActivity(ActivityType.AUDIT, visit);

        try {

            if (content.getFlow() == null
                    || StringUtils.isBlank(content.getFlow().getFlowName())) {
                throw new IllegalArgumentException("Data flow not set.");
            }

            // FLOW
            DataFlow flow = flowDao.getByCode(content.getFlow().getFlowName());

            if (flow == null) {
                throw new IllegalArgumentException("Invalid flow: "
                        + content.getFlow().getFlowName());
            }

            logEntry.addEntry("Flow: {0}", new Object[] { flow.getName() });

            // OPERATION - only for 2.0 endpoint
            DataService submitProcessingService = null;
            if (visit.getEndpointVersion().equals(EndpointVersionType.EN20)
                    && StringUtils.isNotBlank(content.getFlow().getOperation())) {

                logEntry.addEntry("Operation: {0}", new Object[] { content
                        .getFlow().getOperation() });

                logger.debug("Flow Id: " + flow.getId());
                logger.debug("Operation: " + content.getFlow().getOperation());

                // Check if we have a serivce with the operation name
                submitProcessingService = serviceDao.getByServiceName(flow
                        .getId(), content.getFlow().getOperation());

                if (submitProcessingService == null) {
                    logger.error("Unable to find service with this operation: "
                            + content.getFlow().getOperation());
                    throw new IllegalArgumentException(
                            "Invalid flow operation: "
                                    + content.getFlow().getOperation());
                }

            } else {

                logEntry
                        .addEntry(
                                "Looking for default flow submission processor for: {0}",
                                new Object[] { content.getFlow().getFlowName() });
                logger.debug("Flow Id: " + flow.getId());

                // Check if we have a serivce with flow name
                submitProcessingService = serviceDao.getByServiceName(flow
                        .getId(), content.getFlow().getFlowName());

                if (submitProcessingService == null) {
                    logger.error("Unable to find service with this operation: "
                            + content.getFlow().getFlowName());
                }

            }

            // DOCS
            if (content.getDocuments() == null
                    || content.getDocuments().size() == 0) {
                throw new IllegalArgumentException("No documents to process");
            }

            // VISIT
            UserAccount account = visit.getUserAccount();

            if (flow.isSecured()) {
                accountService.validateAccess(account, flow.getName());
            }

            logEntry.setModifiedById(account.getId());

            // TRAN
            NodeTransaction tran = null;

            if (StringUtils.isBlank(content.getTransactionId())) {
                tran = transactionDao.make(flow.getId(), account.getId(),
                        NodeMethodType.SUBMIT,
                        CommonTransactionStatusCode.RECEIVED);
            } else {
                tran = transactionDao.get(content.getTransactionId(), true);
                if (tran == null) {
                    throw new RuntimeException("Invalid transaction Id: "
                            + content.getTransactionId());
                }
            }

            if (tran == null) {
                throw new RuntimeException("Unable to create a transaction");
            }

            tran.setFlow(flow);
            tran.setCreator(account);
            logEntry.setTransactionId(tran.getId());

            // DOCS
            for (int i = 0; i < content.getDocuments().size(); i++) {

                logger.debug("Saving document");

                Document doc = (Document) content.getDocuments().get(i);

                if (!doc.getType().equals(CommonContentType.ZIP)) {

                    String newFileName = doc.getDocumentName() + "."
                            + CommonContentAndFormatConverter.ZIP_EXT;
                    doc.setContent(compressionHelper.zip(doc.getContent(), doc
                            .getDocumentName()));
                    doc.setType(CommonContentType.ZIP);
                    doc.setDocumentName(newFileName);

                } else {
                    doc.setType(CommonContentType.ZIP);
                }

                transactionDao.addDocument(tran.getId(), doc);

                logEntry.addEntry("Document {0} ({1} - {2}: {3})",
                        new Object[] { doc.getDocumentName(),
                                doc.getDocumentStatus().getName(),
                                doc.getType().getName(),
                                doc.getDocumentStatusDetail() });

            }

            notificationHelper.sendSubmits(tran);

            // If there was an operation from 2.0 or for default flow
            // submission processor and we already have a service
            // mapped, than save the request for processing
            if (submitProcessingService != null) {

                // Savew Request
                DataRequest submitProcessingRequest = new DataRequest();
                submitProcessingRequest.setModifiedById(account.getId());
                submitProcessingRequest.setNotifications(content
                        .getNotifications());
                submitProcessingRequest.setRecipients(content.getRecipients());
                submitProcessingRequest.setRequestor(account);
                submitProcessingRequest.setService(submitProcessingService);
                submitProcessingRequest.setTransactionId(tran.getId());
                submitProcessingRequest.setType(RequestType.NONE);

                tran.setRequest(requestDao.save(submitProcessingRequest));
            }

            TransactionStatus status = new TransactionStatus();
            status.setTransactionId(tran.getNetworkId());
            status.setDescription("Received " + content.getDocuments().size()
                    + " documents");
            status.setStatus(CommonTransactionStatusCode.RECEIVED);

            return status;

        } catch (Exception ex) {
            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.ERROR);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException("Error: " + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    public void setCompressionHelper(CompressionService compressionHelper) {
        this.compressionHelper = compressionHelper;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setAccountService(AccountServiceImpl accountService) {
        this.accountService = accountService;
    }

    public void setServiceDao(ServiceDao serviceDao) {
        this.serviceDao = serviceDao;
    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setNotificationHelper(NotificationHelper notificationHelper) {
        this.notificationHelper = notificationHelper;
    }

    public void setRequestDao(RequestDao requestDao) {
        this.requestDao = requestDao;
    }

}
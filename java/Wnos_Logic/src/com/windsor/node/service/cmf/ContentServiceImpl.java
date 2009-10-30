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

import java.io.File;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
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
import com.windsor.node.plugin.WnosPluginHelper;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.Ends2Service;
import com.windsor.node.service.admin.AccountServiceImpl;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.NotificationHelper;

public class ContentServiceImpl extends BaseService implements ContentService,
        InitializingBean {

    /**
     * 
     */
    private static final String UNABLE_TO_FIND_SERVICE = "Unable to find service with this operation: ";

    private static final String ENDS2_PLUGIN_CLASSNAME = "com.windsor.node.plugin.ends2.Ends2GetServicesQueryProcessor";

    private final Logger logger = Logger.getLogger(this.getClass());

    private TransactionDao transactionDao;
    private AccountServiceImpl accountService;
    private ServiceDao serviceDao;
    private RequestDao requestDao;
    private FlowDao flowDao;
    private NotificationHelper notificationHelper;
    private CompressionService compressionHelper;
    private WnosPluginHelper pluginHelper;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (requestDao == null) {
            throw new RuntimeException("RequestDao not set");
        }

        if (flowDao == null) {
            throw new RuntimeException("FlowDao not set");
        }

        if (accountService == null) {
            throw new RuntimeException("AccountService not set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao not set");
        }

        if (serviceDao == null) {
            throw new RuntimeException("ServiceDao not set");
        }

        if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper not set");
        }

        if (compressionHelper == null) {
            throw new RuntimeException("CompressionService not set");
        }

        if (pluginHelper == null) {
            throw new RuntimeException("Plugin Helper not set");
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.common.service.cmf.ContentService#download(com.windsor
     * .node.common.domain.EndpointVisit,
     * com.windsor.node.common.domain.ComplexContent)
     */
    public List download(EndpointVisit visit, ComplexContent content) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

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
                        "Unable to find local transaction with that Id: "
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
                accountService.validateAccess(account, tran.getFlow().getId());
            }

            logEntry.setModifiedById(account.getId());

            List<Document> docs = null;

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

                docs = new ArrayList<Document>();

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

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException("Error while downloading documents: "
                    + ex.getMessage(), ex);

        } finally {

            getActivityDao().make(logEntry);
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.common.service.cmf.ContentService#getServices(com.windsor
     * .node.common.domain.EndpointVisit, java.lang.String)
     */
    public SimpleContent getServices(EndpointVisit visit, String category) {

        if (visit == null) {
            throw new RuntimeException("Null visit");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);
        logEntry.addEntry("GetServices invoked");

        SimpleContent content = null;

        try {

            // VISIT
            UserAccount account = visit.getUserAccount();
            logEntry.setModifiedById(account.getId());

            /* is ENDS2 service & plugin installed and active? */
            List<DataService> endsServices = serviceDao
                    .getActiveByImplementor(ENDS2_PLUGIN_CLASSNAME);

            logger.debug("Found " + endsServices.size()
                    + " services with implementor " + ENDS2_PLUGIN_CLASSNAME);

            if (endsServices.size() > 1) {

                throw new RuntimeException(
                        "Can't have more than one active service with implementor "
                                + ENDS2_PLUGIN_CLASSNAME);

            } else if (endsServices.size() == 1) {

                logEntry
                        .addEntry("Found 1 active Ends2 service, instantiating plugin...");

                content = getServices20FromEndsPlugin(endsServices.get(0),
                        logEntry);

            } else {
                logEntry
                        .addEntry("Ends2 plugin unavailable, falling back to XML list of service names");
                content = getServices20NoPlugin();
            }

            content.setType(CommonContentType.XML);

        } catch (Exception ex) {

            String msg = "Exception message: " + ex.getMessage()
                    + "\n Exception type: " + ex.getClass().getName();
            logger.debug(msg);

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(msg);
            throw new RuntimeException("Error: " + msg, ex);

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

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            // VISIT
            UserAccount account = visit.getUserAccount();

            logEntry.setModifiedById(account.getId());

            Map<String, String> services = serviceDao.getActive();

            String[] serviceNames = new String[services.size()];
            Iterator<Map.Entry<String, String>> keyValueIt = services
                    .entrySet().iterator();
            for (int i = 0; i < services.size(); i++) {
                Map.Entry<String, String> entry = (Map.Entry<String, String>) keyValueIt
                        .next();
                serviceNames[i] = (String) entry.getValue() + "\n";
            }

            Arrays.sort(serviceNames);
            return serviceNames;

        } catch (Exception ex) {
            logger.debug(ex.getMessage(), ex);

            logEntry.setType(ActivityType.Error);
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

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

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
                    logger.error(UNABLE_TO_FIND_SERVICE
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
                    logger.error(UNABLE_TO_FIND_SERVICE
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
                accountService.validateAccess(account, flow.getId());
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
                                doc.getDocumentStatus().name(),
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

            logEntry.setType(ActivityType.Error);
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

    public void setPluginHelper(WnosPluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

    private SimpleContent getServices20NoPlugin() {

        SimpleContent content = new SimpleContent();
        StringBuffer sb = new StringBuffer();

        sb.append("<services>\n");

        Map<String, String> services = serviceDao.getActive();

        ArrayList<String> serviceNames = new ArrayList<String>(services
                .values());
        Collections.sort(serviceNames);

        for (String name : serviceNames) {

            sb.append("<service>");
            sb.append(name);
            sb.append("</service>\n");
        }

        sb.append("</services>\n");

        try {
            content.setContent(sb.toString().getBytes("UTF-8"));
        } catch (UnsupportedEncodingException uee) {
            throw new RuntimeException(
                    "Error while converting String to byte[]");
        }

        return content;
    }

    private SimpleContent getServices20FromEndsPlugin(DataService endsService,
            Activity logEntry) {

        SimpleContent content = new SimpleContent();

        DataFlow flow = flowDao.get(endsService.getFlowId());

        logEntry
                .addEntry("Looking for Ends2Service implementation among installed plugins...");

        File pluginSourceDir = pluginHelper.getPluginContentDir(flow);

        Ends2Service ends2Service = (Ends2Service) pluginHelper
                .getClassLoader().getPluginInstance(pluginSourceDir,
                        ENDS2_PLUGIN_CLASSNAME);

        logEntry
                .addEntry("Got Ends2Service plugin instance, invoking GetServices...");

        content = ends2Service.getServices(getNaasConfig(), getNosConfig(),
                serviceDao, flowDao, pluginHelper, pluginSourceDir,
                getNosConfig().getTempDir());

        logEntry.addEntry("Returning service descriptions for Node.");

        return content;
    }

}

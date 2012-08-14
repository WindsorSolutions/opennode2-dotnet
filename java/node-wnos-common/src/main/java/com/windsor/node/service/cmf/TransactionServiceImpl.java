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

import java.net.URL;
import java.text.FieldPosition;
import java.text.MessageFormat;
import java.text.NumberFormat;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.ComplexNotification;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointVisit;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.Notification;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.cmf.TransactionService;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.RequestDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.PluginHelper;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.admin.AccountServiceImpl;
import com.windsor.node.service.cmf.domain.LogableNodeTransaction;
import com.windsor.node.service.helper.NotificationHelper;

public class TransactionServiceImpl extends BaseService implements
        TransactionService, InitializingBean {

    /**
     * 
     */
    private static final String VISIT_OBJECT_NOT_SET = "Visit object not set";
    /**
     * 
     */
    private static final String SERVICE_DOES_NOT_SUPPORT = "Service does not support: ";
    /**
     * 
     */
    private static final String NULL_RESULT_FROM_THE_PLUGIN = "Null result from the plugin";
    /**
     * 
     */
    private static final String GET_STATUS_REQUEST_FROM_0_BY_1_FOR_TRANSACTION_ID_2 = "GetStatus request from {0} by {1} for transaction Id {2}.";
    /**
     * 
     */
    private static final String ERROR_PREFIX = "Error: ";
    /**
     * 
     */
    private static final String NULL_SERVICE = "Null service";
    /**
     * 
     */
    private static final String NULL_REQUEST = "Null request";
    /**
     * 
     */
    private static final String NULL_VISIT = "Null visit";
    private final Logger logger = LoggerFactory.getLogger(this.getClass());
    private TransactionDao transactionDao;
    private AccountServiceImpl accountService;
    private ServiceDao serviceDao;
    private FlowDao flowDao;
    private NotificationHelper notificationHelper;
    private RequestDao requestDao;
    private PluginHelper pluginHelper;
    private PartnerDao partnerDao;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (partnerDao == null) {
            throw new RuntimeException("PartnerDao Not Set");
        }

        else if (flowDao == null) {
            throw new RuntimeException("FlowDao Not Set");
        }

        else if (accountService == null) {
            throw new RuntimeException("AccountService Not Set");
        }

        else if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        else if (serviceDao == null) {
            throw new RuntimeException("ServiceDao Not Set");
        }

        else if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper Not Set");
        }

        else if (requestDao == null) {
            throw new RuntimeException("RequestDao Not Set");
        }

        else if (pluginHelper == null) {
            throw new RuntimeException("PluginHelper Not Set");
        }

    }

    /**
     * execute
     */
    public ProcessContentResult execute(EndpointVisit visit, DataRequest request) {

        if (visit == null) {
            throw new RuntimeException(NULL_VISIT);
        }

        if (request == null) {
            throw new RuntimeException(NULL_REQUEST);
        }

        if (request.getService() == null) {
            throw new RuntimeException(NULL_SERVICE);
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        NodeTransaction tran = null;

        try {

            LogableNodeTransaction info = processRequest(visit, request,
                    new LogableNodeTransaction(logEntry, ServiceType.EXECUTE));

            tran = info.getTransaction();
            logEntry = info.getActivity();
            logEntry.setTransactionId(tran.getId());

            ProcessContentResult queryResult = pluginHelper
                    .processTransaction(tran);

            if (queryResult == null) {
                throw new RuntimeException(NULL_RESULT_FROM_THE_PLUGIN);
            }

            return queryResult;

        } catch (Exception ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());

            if (tran != null) {
                transactionDao.updateStatus(tran.getId(),
                        CommonTransactionStatusCode.Failed);
            }

            throw new RuntimeException(ERROR_PREFIX + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /**
     * getStatus
     */
    public TransactionStatus getStatus(EndpointVisit visit, String transactionId) {

        if (visit == null) {
            throw new RuntimeException(NULL_VISIT);
        }

        logger.debug("getStatus visit: " + visit);

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("Null transaction");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logger.debug("Getting transaction: " + transactionId);

            NodeTransaction tran = transactionDao.get(transactionId, true);

            if (tran == null) {
                throw new RuntimeException(
                        "Unable to find local transaction with that Id: "
                                + transactionId);
            }

            logEntry.addEntry("Transaction flow: {0}", new Object[] { tran
                    .getFlow() });
            logEntry.addEntry("Transaction operation: {0}", new Object[] { tran
                    .getOperation() });

            logEntry.setWebMethod(tran.getWebMethod().getType());

            logEntry.setTransactionId(tran.getId());

            // VISIT
            UserAccount account = visit.getUserAccount();

            if (tran.getFlow().isSecured()) {
                accountService.validateAccess(visit.getUserAccount(), tran
                        .getFlow().getId());
            }

            logEntry.setModifiedById(account.getId());

            logEntry.addEntry(
                    GET_STATUS_REQUEST_FROM_0_BY_1_FOR_TRANSACTION_ID_2,
                    new Object[] { visit.getIp(), account.getNaasUserName(),
                            tran.getNetworkId() });

            logEntry.addEntry("Results: {0}", new Object[] { tran.getStatus(),
                    tran.getNetworkId() });

            TransactionStatus status = new TransactionStatus();

            status.setTransactionId(tran.getNetworkId());
            status.setStatus(tran.getStatus().getStatus());
            status.setDescription(tran.getStatus().getDescription());

            logEntry.addEntry("Transaction status: {0}", new Object[] { tran
                    .getStatus() });

            logger.debug("Returning transactionStatus: " + status);
            return status;

        } catch (Exception ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException(ERROR_PREFIX + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /**
     * notify
     */
    public TransactionStatus notify(EndpointVisit visit,
            ComplexNotification notification) {

        if (visit == null) {
            throw new RuntimeException(NULL_VISIT);
        }

        if (notification == null) {
            throw new RuntimeException("Null notification");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            if (StringUtils.isBlank(notification.getFlowName())) {
                throw new IllegalArgumentException("Null data flow");
            }

            // VISIT
            UserAccount account = visit.getUserAccount();

            logEntry.setModifiedById(account.getId());

            DataFlow flow = flowDao.getByCode(notification.getFlowName());

            logger.debug("Flow: " + flow);

            if (flow == null) {
                throw new RuntimeException(
                        "Unable to local flow witht that code: "
                                + notification.getFlowName());
            }

            NodeTransaction tran = transactionDao.make(flow.getId(), account
                    .getId(), NodeMethodType.Notify,
                    CommonTransactionStatusCode.Received);

            logger.debug("Transaction: " + tran);

            if (tran == null) {
                throw new RuntimeException("Unable to create local transaction");
            }

            tran.setFlow(flow);
            tran.setCreator(account);

            logEntry.addEntry("Transaction: {0}", new Object[] { tran
                    .getNetworkId() });

            logEntry.setTransactionId(tran.getId());

            logEntry.addEntry(
                    GET_STATUS_REQUEST_FROM_0_BY_1_FOR_TRANSACTION_ID_2,
                    new Object[] { visit.getIp(), account.getNaasUserName(),
                            tran.getNetworkId() });

            logEntry.addEntry("Notification Name {0} ({1})", new Object[] {
                    notification.getFlowName(), notification.getUri() });

            // notifs
            for (int i = 0; i < notification.getNotifications().size(); i++) {

                logger.debug("Saving document");

                Notification notif = (Notification) notification
                        .getNotifications().get(i);

                logger.debug("Notification prior to save: " + notif);

                // Temprorary work around until the 2.0 spec is flashed out

                MessageFormat mf = new MessageFormat(
                        "<notification><id>{0}</id><category>{1}</category><name>{2}</name><status>{3}</status></notification>");
                StringBuffer sb = new StringBuffer();
                FieldPosition fp = new FieldPosition(NumberFormat.INTEGER_FIELD);

                Object[] args = new Object[] {
                        notif.getStatus().getTransactionId(),
                        (notif.getCategory() == null) ? null : notif
                                .getCategory().getType(),
                        notif.getName(),
                        (notif.getStatus() == null) ? null : (notif.getStatus()
                                .getStatus() == null) ? null : notif
                                .getStatus().getStatus().name() };

                logger.debug("Creating local doc...");

                Document doc = new Document();
                doc.setContent(mf.format(args, sb, fp).toString().getBytes(
                        "UTF-8"));
                doc.setDocumentName(notif.getName());
                doc.setDocumentStatus(CommonTransactionStatusCode.Received);
                doc
                        .setDocumentStatusDetail("Notification messages parsed into XML");
                doc.setType(CommonContentType.XML);

                logger.debug("Local doc: " + doc);

                tran.getDocuments().add(
                        transactionDao.addDocument(tran.getId(), doc));

                logEntry.addEntry("Document {0} ({1} - {2}: {3})",
                        new Object[] { doc.getDocumentName(),
                                doc.getDocumentStatus().name(),
                                doc.getType().getType(),
                                doc.getDocumentStatusDetail() });

            }

            logger.debug("Saving transaction: " + tran);

            notificationHelper.sendNotifs(tran);

            TransactionStatus status = new TransactionStatus();
            status.setTransactionId(tran.getNetworkId());
            status.setDescription("Received notification with "
                    + tran.getDocuments().size() + " documents");
            status.setStatus(CommonTransactionStatusCode.Received);

            logger.debug("Status: " + status);

            return status;

        } catch (Exception ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());
            throw new RuntimeException(ERROR_PREFIX + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /**
     * query
     */
    public ProcessContentResult query(EndpointVisit visit, DataRequest request) {

        if (visit == null) {
            throw new RuntimeException(NULL_VISIT);
        }

        if (request == null) {
            throw new RuntimeException(NULL_REQUEST);
        }

        if (request.getService() == null) {
            throw new RuntimeException(NULL_SERVICE);
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        NodeTransaction tran = null;

        try {

            LogableNodeTransaction info = processRequest(visit, request,
                    new LogableNodeTransaction(logEntry, ServiceType.QUERY));

            tran = info.getTransaction();
            logEntry = info.getActivity();
            logEntry.setTransactionId(tran.getId());

            ProcessContentResult queryResult = pluginHelper
                    .processTransaction(tran);

            if (queryResult == null) {
                throw new RuntimeException(NULL_RESULT_FROM_THE_PLUGIN);
            }

            return queryResult;

        } catch (Exception ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());

            if (tran != null) {
                transactionDao.updateStatus(tran.getId(),
                        CommonTransactionStatusCode.Failed);
            }

            throw new RuntimeException(ERROR_PREFIX + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /**
     * solicit
     */
    public TransactionStatus solicit(EndpointVisit visit, DataRequest request) {

        if (visit == null) {
            throw new RuntimeException(VISIT_OBJECT_NOT_SET);
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        NodeTransaction tran = null;

        try {

            LogableNodeTransaction info = processRequest(visit, request,
                    new LogableNodeTransaction(logEntry, ServiceType.SOLICIT));

            if (request.getRecipients() != null
                    && request.getRecipients().size() > 0) {

                logEntry.addEntry("Saving Recipients");

                for (int i = 0; i < request.getRecipients().size(); i++) {

                    String uri = (String) request.getRecipients().get(i);

                    if (StringUtils.isNotBlank(uri)
                            && uri.trim().toLowerCase().startsWith("http")) {

                        logEntry.addEntry("Partner: " + uri);

                        PartnerIdentity partner = new PartnerIdentity();

                        URL url = new URL(uri);

                        partner.setVersion(visit.getEndpointVersion());
                        partner.setUrl(url);
                        partner.setName(url.toString().toLowerCase());
                        partner.setModifiedById(visit.getUserAccount().getId());
                        partner.setId(null);

                        partnerDao.saveIfNew(partner);

                    }
                }
            }

            logEntry = info.getActivity();
            tran = info.getTransaction();

            return tran.getStatus();

        } catch (Exception ex) {

            logger.debug(ex.getMessage(), ex);

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(ex.getMessage());

            if (tran != null) {
                transactionDao.updateStatus(tran.getId(),
                        CommonTransactionStatusCode.Failed);
            }

            throw new RuntimeException(ERROR_PREFIX + ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);

        }

    }

    /***************************************************************************
     * 
     * Private
     * 
     **************************************************************************/
    private LogableNodeTransaction processRequest(EndpointVisit visit,
            DataRequest request, LogableNodeTransaction info) {

        if (visit == null) {
            throw new RuntimeException(VISIT_OBJECT_NOT_SET);
        }

        if (request == null) {
            throw new IllegalArgumentException("Request argument not set.");
        }

        NodeTransaction tran = null;

        try {

            // SERVICE
            logger.debug("Getting service from request: " + request);
            request.setService(serviceDao.getByServiceName(request.getService()
                    .getName()));

            if (request.getService() == null) {
                throw new RuntimeException(
                        "Unable to find a service with that name.");
            }

            if (!request.getService().isActive()) {
                throw new RuntimeException("Service is currently inactive.");
            }

            logger.debug("Service Type: " + request.getService().getType());
            logger.debug("Info Type: " + info.getType());

            if (info.getType() == ServiceType.EXECUTE) {

                if (request.getService().getType() != ServiceType.EXECUTE) {
                    throw new RuntimeException(SERVICE_DOES_NOT_SUPPORT
                            + ServiceType.EXECUTE);
                }

            } else if (info.getType() == ServiceType.QUERY) {

                if (request.getService().getType() != ServiceType.QUERY
                        && request.getService().getType() != ServiceType.QUERY_OR_SOLICIT
                        && request.getService().getType() != ServiceType.QUERY_OR_SOLICIT_OR_EXECUTE) {
                    throw new RuntimeException(SERVICE_DOES_NOT_SUPPORT
                            + ServiceType.QUERY);
                }

            } else if (info.getType() == ServiceType.SOLICIT) {

                if (request.getService().getType() != ServiceType.SOLICIT
                        && request.getService().getType() != ServiceType.QUERY_OR_SOLICIT
                        && request.getService().getType() != ServiceType.QUERY_OR_SOLICIT_OR_EXECUTE) {
                    throw new RuntimeException(SERVICE_DOES_NOT_SUPPORT
                            + ServiceType.SOLICIT);
                }

            } else {

                throw new RuntimeException("Unrecognized Service Type: "
                        + request.getService().getType());

            }

            DataFlow flow = flowDao.get(request.getService().getFlowId());

            if (flow == null) {
                throw new RuntimeException("Unable to flow by this Id: "
                        + request.getService().getFlowId());
            }

            // VISIT
            UserAccount account = visit.getUserAccount();

            if (flow.isSecured()) {
                accountService.validateAccess(account, flow.getId());
            }

            request.setRequestor(account);
            request.setModifiedById(account.getId());

            info.getActivity().setModifiedById(account.getId());

            info.getActivity().addEntry("Query request from {0} by {1}.",
                    new Object[] { visit.getIp(), account.getNaasUserName() });

            info.getActivity().addEntry(
                    "Service:{0} Parameters:{1} Paging:{2}.",
                    new Object[] { request.getService().getName(),
                            request.getParameters(), request.getPaging() });

            // TRAN
            logger.debug("Getting transaction for: " + flow.getName()
                    + " and user Id: " + request.getModifiedById());

            if (info.getType() == ServiceType.QUERY) {

                tran = transactionDao.make(flow.getId(), request
                        .getModifiedById(), NodeMethodType.Query,
                        CommonTransactionStatusCode.Processed);

                notificationHelper.sendQueries(request);

                request.setType(RequestType.Query);

            } else {

                tran = transactionDao.make(flow.getId(), request
                        .getModifiedById(), NodeMethodType.Solicit,
                        CommonTransactionStatusCode.Received);

                notificationHelper.sendSolicits(request);

                request.setType(RequestType.Solicit);

            }

            if (tran == null) {
                throw new RuntimeException("Unable to create a transaction");
            }

            tran.setFlow(flow);
            tran.setRequest(request);
            tran.setCreator(account);

            info.getActivity().setTransactionId(tran.getId());

            // REQUEST
            request.setTransactionId(tran.getId());

            logger.debug("Saving request: " + request);

            request = requestDao.save(request);

            info.getActivity().addEntry("Request: {0} ",
                    new Object[] { request.getService() });

            info.getActivity().addEntry("Global Transaction Id: {0} ",
                    new Object[] { tran.getNetworkId() });

            logger.debug("tran: " + tran);

            info.setTransaction(tran);

            return info;

        } catch (Exception ex) {
            String msg = "Error while saving request: " + ex.getMessage();
            logger.error(msg, ex);
            throw new RuntimeException(msg, ex);
        }

    }

    /***************************************************************************
     * 
     * Setters
     * 
     **************************************************************************/
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

    public void setPluginHelper(PluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

    public void setPartnerDao(PartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

}

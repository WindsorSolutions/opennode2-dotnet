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

package com.windsor.node.worker;

import java.text.FieldPosition;
import java.text.MessageFormat;
import java.text.NumberFormat;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.RequestDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.PluginHelper;
import com.windsor.node.service.helper.NotificationHelper;
import com.windsor.node.util.ValidationUtil;
import com.windsor.node.worker.schedule.processor.PartnerDataProcessor;

public class NodeTransactionTaskWorker extends NodeWorker implements
        InitializingBean {

    private TransactionDao transactionDao;
    private AccountDao accountDao;
    private RequestDao requestDao;
    private NotificationHelper notificationHelper;
    private PluginHelper pluginHelper;
    private PartnerDataProcessor partnerDataProcessor;

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (pluginHelper == null) {
            throw new RuntimeException("PluginHelper Not Set");
        }

        if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper Not Set");
        }

        if (requestDao == null) {
            throw new RuntimeException("RequestDao Not Set");
        }

        if (accountDao == null) {
            throw new RuntimeException("AccountDao Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }
    }

    protected synchronized NodeTransaction getNextTransaction(
            NodeMethodType method) {

        logger
                .debug("Getting next transaction that has a request and a service for: "
                        + method);
        NodeTransaction transaction = null;

        while ((transaction = transactionDao.getNextReceived(method)) != null) {

            logger.debug("Transaction to process: " + transaction);

            // Get a request to see if there is anything to process
            transaction.setRequest(requestDao.getByTransactionId(transaction
                    .getId()));

            logger.debug("Transaction request: " + transaction.getRequest());

            // if the request does not exist or it does not have a service
            // associated with it
            if (transaction.getRequest() == null
                    || transaction.getRequest().getService() == null) {

                // just mark it processed and move on
                transactionDao.updateStatus(transaction.getId(),
                        CommonTransactionStatusCode.Processed);

                logger
                        .debug("Updating transaction status to processed as there is nothing to do");

                Activity logEntry = new Activity();
                logEntry.setModifiedById(transaction.getModifiedById());
                logEntry.setIp(getNosConfig().getLocalhostIp());
                logEntry.setType(ActivityType.Info);
                logEntry.addEntry("Machine Id: " + getMachineId());
                logEntry.setTransactionId(transaction.getId());
                logEntry.addEntry("Transaction Id: " + transaction.getNetworkId());
                logEntry
                        .addEntry("No processors defined for this type of transaction/flow.");
                logEntry.addEntry("Transaction marked Processed.");
                getActivityService().insert(logEntry);

            } else {

                logger.debug("Transaction request service: "
                        + transaction.getRequest().getService());

                // if there request has a service than load all its children
                // to make it complete and ready for process

                // tran
                transaction.setDocuments(transactionDao.getDocuments(
                        transaction.getId(), false, true));

                // account
                transaction.setCreator(accountDao.get(transaction
                        .getModifiedById()));

                // requestor
                transaction.getRequest().setRequestor(transaction.getCreator());

                // return only that one transaction
                return transaction;

            }

        }

        // if there is nothing to process
        return null;

    }

    /**
     * run
     */
    public void run(NodeMethodType documentType) {

        try {

            logger.debug("Getting unprocessed transactions for: "
                    + documentType);

            NodeTransaction transaction = null;
            while ((transaction = getNextTransaction(documentType)) != null) {

                logger.debug("Found transaction: " + transaction);
                process(transaction, documentType);

            }

            logger.debug("Processed all outstanding transactions");

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
        }

    }

    /**
     * process
     * 
     * @param transaction
     */
    private void process(NodeTransaction transaction,
            NodeMethodType documentType) {

        logger.debug("processing: " + transaction);

        if (transaction == null) {
            throw new RuntimeException("Null transaction");
        }

        Activity logEntry = new Activity();
        logEntry.setModifiedById(transaction.getModifiedById());
        logEntry.setIp(getNosConfig().getLocalhostIp());
        logEntry.setType(ActivityType.Info);
        logEntry.setTransactionId(transaction.getId());
        logEntry.addEntry("Machine Id: " + getMachineId());
        logEntry.addEntry("Transaction Id: " + transaction.getNetworkId());

        try {

            // TODO: Not sure about this logic
            // It is the safest approach for now however
            if (transaction.getRequest() == null
                    || transaction.getRequest().getService() == null) {

                logEntry
                        .addEntry(makeAndDebug("Transaction does not have request or service:"));
                logEntry.addEntry(makeAndDebug("Request: "
                        + transaction.getRequest()));

                if (transaction.getRequest() != null) {
                    logEntry.addEntry(makeAndDebug("Service: "
                            + transaction.getRequest().getService()));
                }

                getTransactionDao().updateStatus(transaction.getId(),
                        CommonTransactionStatusCode.Processed);

            } else {

                // send notifications about submitted documents transaction
                if (documentType.equals(NodeMethodType.SUBMIT)
                        || documentType.equals(NodeMethodType.NOTIFY)) {
                    getNotificationHelper().sendProcessedSubmits(transaction);
                }

                logEntry.addEntry(makeAndDebug("Executing plugin..."));
                ProcessContentResult result = pluginHelper
                        .processTransaction(transaction);

                if (result == null) {
                    throw new RuntimeException("Null Result");
                }

                logEntry.addEntryAll(result.getAuditEntries());

                // if success than do the rest
                if (result.isSuccess()) {

                    // save results if the documents are not already in Db
                    if (result.getDocuments() != null) {
                        logEntry
                                .addEntry(makeAndDebug("Saving any new documents..."));
                        for (int d = 0; d < result.getDocuments().size(); d++) {

                            Document resultDoc = (Document) result
                                    .getDocuments().get(d);

                            // make surewe save only new documents
                            if (StringUtils.isBlank(resultDoc.getId())) {

                                logEntry
                                        .addEntry(makeAndDebug("Saving document: "
                                                + resultDoc.getDocumentName()));

                                transactionDao.addDocument(transaction.getId(),
                                        resultDoc);

                            } else {
                                logger.debug("Document was alrady in Db: "
                                        + resultDoc);
                            }

                        }
                    }

                    // send notifications about submitted documents transaction
                    if (documentType == NodeMethodType.SOLICIT) {

                        // Send the results
                        if (transaction.getRequest() != null
                                && transaction.getRequest().getRecipients() != null
                                && transaction.getRequest().getRecipients()
                                        .size() > 0) {

                            for (int i = 0; i < transaction.getRequest()
                                    .getRecipients().size(); i++) {

                                String uri = (String) transaction.getRequest()
                                        .getRecipients().get(i);
                                logEntry.addEntry(makeAndDebug("Recipient: "
                                        + uri));

                                try {

                                    if (ValidationUtil.isValidURI(uri)) {

                                        logEntry
                                                .addEntry(makeAndDebug("Submitting to partner..."));

                                        try {
                                            logEntry
                                                    .addEntryAll(partnerDataProcessor
                                                            .getAndSendDataByUrl(
                                                                    transaction,
                                                                    uri,
                                                                    transaction
                                                                            .getFlow()
                                                                            .getName()));
                                        } catch (Exception urlEx) {
                                            logEntry
                                                    .addEntry(makeAndDebug("Error while sending url notification to: "
                                                            + uri
                                                            + " Message: "
                                                            + urlEx
                                                                    .getMessage()));
                                        }

                                    } else if (ValidationUtil
                                            .isValidEmailAddress(uri)) {

                                        logEntry
                                                .addEntry(makeAndDebug("Emailing to partner..."));

                                        try {
                                            notificationHelper
                                                    .sendTransactionStatusUpdate(
                                                            transaction, uri,
                                                            transaction
                                                                    .getFlow()
                                                                    .getName());
                                        } catch (Exception emailEx) {
                                            logEntry
                                                    .addEntry(makeAndDebug("Error while sending email notification to: "
                                                            + uri
                                                            + " Message: "
                                                            + emailEx
                                                                    .getMessage()));
                                        }

                                    }

                                } catch (Exception pex) {

                                    logEntry
                                            .addEntry(makeAndDebug(
                                                    "Error while submiting to Recipient:{0} - {1}",
                                                    new Object[] { uri,
                                                            pex.getMessage() }));

                                }
                            }

                        }

                        getNotificationHelper().sendProcessedSolicits(
                                transaction.getRequest());
                    }

                    getTransactionDao().updateStatus(transaction.getId(),
                            result.getStatus());

                } else {

                    logEntry.setType(ActivityType.Error);

                    getTransactionDao().updateStatus(transaction.getId(),
                            CommonTransactionStatusCode.Failed);

                } // checking if result was a success

            } // checking transaction has a service

        } catch (Throwable ex) {

            logger.debug(ex.getMessage());

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry(makeAndDebug("Error:{0}", new Object[] { ex
                    .getMessage() }));

            if (transaction != null) {
                getTransactionDao().updateStatus(transaction.getId(),
                        CommonTransactionStatusCode.Failed);
            }

        } finally {
            getActivityService().insert(logEntry);
        }

    }

    private ActivityEntry makeAndDebug(String message) {
        logger.debug(message);
        return ActivityEntry.make(message);
    }

    private ActivityEntry makeAndDebug(String message, Object[] args) {
        MessageFormat mf = new MessageFormat(message);
        StringBuffer sb = new StringBuffer();
        FieldPosition fp = new FieldPosition(NumberFormat.INTEGER_FIELD);
        return makeAndDebug(mf.format(args, sb, fp).toString());
    }

    /*
     * 
     * 
     * 
     * Setters
     */

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public AccountDao getAccountDao() {
        return accountDao;
    }

    public void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

    public RequestDao getRequestDao() {
        return requestDao;
    }

    public void setRequestDao(RequestDao requestDao) {
        this.requestDao = requestDao;
    }

    public NotificationHelper getNotificationHelper() {
        return notificationHelper;
    }

    public void setNotificationHelper(NotificationHelper notificationHelper) {
        this.notificationHelper = notificationHelper;
    }

    public void setPluginHelper(PluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

    public PartnerDataProcessor getPartnerDataProcessor() {
        return partnerDataProcessor;
    }

    public void setPartnerDataProcessor(
            PartnerDataProcessor partnerDataProcessor) {
        this.partnerDataProcessor = partnerDataProcessor;
    }

}
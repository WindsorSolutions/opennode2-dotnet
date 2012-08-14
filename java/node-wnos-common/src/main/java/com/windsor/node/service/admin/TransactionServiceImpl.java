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

package com.windsor.node.service.admin;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.admin.TransactionService;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.RequestDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.BaseService;
import com.windsor.node.service.helper.IdGenerator;

public class TransactionServiceImpl extends BaseService implements
        TransactionService, InitializingBean {

    private TransactionDao transactionDao;
    private FlowDao flowDao;
    private RequestDao requestDao;
    private String[] permittedDocumentTypes;
    private IdGenerator idGenerator;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (permittedDocumentTypes == null) {
            throw new RuntimeException("Permitted Document Types Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        if (flowDao == null) {
            throw new RuntimeException("FlowDao Not Set");
        }

        if (requestDao == null) {
            throw new RuntimeException("RequestDao Not Set");
        }

        if (idGenerator == null) {
            throw new RuntimeException("idGenerator Not Set");
        }
    }

    /**
     * downloadContent
     */
    public byte[] downloadContent(String transactionID, String documentID,
            NodeVisit visit) {

        if (StringUtils.isBlank(transactionID)) {
            throw new RuntimeException("transactionID not set.");
        }

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        return getDocument(transactionID, documentID, false).getContent();

    }

    /**
     * get Called from the workers
     */
    public List get(CommonTransactionStatusCode status, NodeVisit visit) {
        return transactionDao.get(status, NodeMethodType.Any);
    }

    /**
     * updateStatus - Internal use only
     * 
     * @param transactionId
     * @param status
     */
    public void updateStatus(String transactionId,
            CommonTransactionStatusCode status) {
        transactionDao.updateStatus(transactionId, status);
    }

    /**
     * Used by worker to change the network Id as a result of submit
     * 
     * @param transactionId
     * @param networkId
     */
    public void updateNetworkId(String transactionId, String networkId) {

        transactionDao.updateNetworkId(transactionId, networkId);
    }

    /**
     * @see com.windsor.node.common.service.admin.TransactionService#update(java.lang.String,
     *      com.windsor.node.common.domain.CommonTransactionStatusCode,
     *      com.windsor.node.common.domain.NodeVisit)
     */
    public void update(String transactionId,
            CommonTransactionStatusCode status, NodeVisit visit) {

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("transactionID not set.");
        }

        if (status == null) {
            throw new RuntimeException("status not set.");
        }

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to update transaction {1}.",
                    new Object[] { visit.getName(), transactionId });

            // NAAS
            logger.debug("Attempting to update transaction: " + transactionId);
            transactionDao.updateStatus(transactionId, status);
            logEntry.addEntry("Schedule transaction from DB.");

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            logEntry.addEntry("Error while update transaction: "
                    + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * getRequests Used internally by the worker
     * 
     * @param status
     * @return
     */
    public List getRequests(CommonTransactionStatusCode status) {

        if (status == null) {
            throw new RuntimeException("CommonTransactionStatusCode Not Set");
        }

        return requestDao.get(status);

    }

    /**
     * getRequests Used internally by the worker
     * 
     * @param status
     * @param type
     * @return
     */
    public List getRequests(CommonTransactionStatusCode status, RequestType type) {

        if (status == null) {
            throw new RuntimeException("CommonTransactionStatusCode Not Set");
        }

        if (type == null) {
            throw new RuntimeException("RequestType Not Set");
        }

        return requestDao.get(status, type);

    }

    /**
     * getDocument returns fully populated document including the content
     * 
     * @param transactionId
     * @param documentId
     * @param useNetworkId
     * @return
     */
    public Document getDocument(String transactionId, String documentId,
            boolean useNetworkId) {

        if (StringUtils.isBlank(documentId)) {
            throw new RuntimeException("documentId Not Set");
        }

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("transactionId Not Set");
        }

        NodeTransaction tran = transactionDao.get(transactionId, useNetworkId);

        if (tran == null) {
            throw new RuntimeException(
                    "Unable to find a transaction with this id");
        }

        Document doc = transactionDao.getDocument(tran.getId(), documentId);

        if (doc == null) {
            throw new RuntimeException("Unable to find a document with this id");
        }

        return doc;

    }

    /**
     * getTransactions - Expensive!!!
     * 
     * @param status
     * @param withDocs
     *            - will result in each document being populated with the
     *            content
     * @return
     */
    public List getTransactions(CommonTransactionStatusCode status,
            boolean withDocs) {

        if (status == null) {
            throw new RuntimeException("CommonTransactionStatusCode Not Set");
        }

        // get all trans for that status
        // no docs

        if (!withDocs) {
            return transactionDao.get(status, NodeMethodType.Any);
        } else {

            List tranList = transactionDao.getSubmittedDocumentTransactions();

            List resultList = new ArrayList();

            for (int i = 0; i < tranList.size(); i++) {

                // geta transaction
                NodeTransaction tran = (NodeTransaction) tranList.get(i);

                // get all dao docs for this tran
                resultList.add(transactionDao.getDocuments(tran.getId(), false,
                        withDocs));

            } // for trans

            return resultList;

        } // with docs

    }

    public List getByMethodType(NodeMethodType method, NodeVisit visit) {

        validateByRole(visit, SystemRoleType.Program);

        List resultList = transactionDao.get(method);
        return resultList;
    }

    /**
     * get
     */
    public NodeTransaction get(String transactionID, NodeVisit visit) {

        validateByRole(visit, SystemRoleType.Program);

        if (StringUtils.isBlank(transactionID)) {
            throw new RuntimeException("transactionID not set.");
        }

        NodeTransaction tran = getTransaction(transactionID, false, true, false);

        if (tran != null) {
            tran.setRequest(requestDao.getByTransactionId(tran.getId()));
        }

        return tran;

    }

    /**
     * getTransaction
     * 
     * @param transactionId
     * @param useNetworkId
     * @param withDocs
     * @return
     */
    public NodeTransaction getTransaction(String transactionId,
            boolean useNetworkId, boolean withDocs, boolean withDocContent) {

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("transactionId Not Set");
        }

        logger.debug("Getting transaction");
        NodeTransaction tran = transactionDao.get(transactionId, useNetworkId);

        if (tran == null) {
            throw new RuntimeException(
                    "Unable to find transaction with that id.");
        }

        tran.setCreator(getAccountDao().get(tran.getModifiedById()));
        tran.setRequest(requestDao.getByTransactionId(tran.getModifiedById()));

        logger.debug("With Docs: " + withDocs);
        if (withDocs) {

            logger.debug("Getting dao documents");
            tran.setDocuments(transactionDao.getDocuments(transactionId,
                    useNetworkId, withDocContent));

            logger.debug("Found: " + tran.getDocuments().size());

        }

        return tran;

    }

    /**
     * saveRequest
     * 
     * @param instance
     * @return
     */
    public DataRequest saveRequest(DataRequest instance) {

        return requestDao.save(instance);

    }

    /**
     * makeTransaction
     * 
     * @param flowId
     * @param createdById
     * @return
     */
    public NodeTransaction makeTransaction(String flowId, String createdById) {

        return makeTransaction(flowId, createdById, null);

    }

    /**
     * makeTransaction
     * 
     * @param flowId
     * @param createdById
     * @param networkId
     * @return
     */
    public NodeTransaction makeTransaction(String flowId, String createdById,
            String networkId) {

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException("flowId Not Set");
        }

        if (StringUtils.isBlank(createdById)) {
            throw new RuntimeException("createdById Not Set");
        }

        DataFlow flow = flowDao.get(flowId);

        if (flow == null) {
            throw new RuntimeException("Unable to find flow with that id: "
                    + flowId);
        }

        UserAccount account = getAccountDao().get(createdById);

        if (account == null) {
            throw new RuntimeException("Unable to find acount with that id: "
                    + createdById);
        }

        NodeTransaction tran = new NodeTransaction();
        tran.setFlow(flow);

        if (StringUtils.isBlank(networkId)) {
            tran.setNetworkId(idGenerator.createId());
        } else {
            tran.setNetworkId(networkId);
        }

        tran.setModifiedById(account.getId());
        tran.setCreator(account);
        tran.setStatus(new TransactionStatus(
                CommonTransactionStatusCode.Received));

        return transactionDao.save(tran);

    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setRequestDao(RequestDao requestDao) {
        this.requestDao = requestDao;
    }

    public void setPermittedDocumentTypes(String[] permittedDocumentTypes) {
        this.permittedDocumentTypes = permittedDocumentTypes;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

}
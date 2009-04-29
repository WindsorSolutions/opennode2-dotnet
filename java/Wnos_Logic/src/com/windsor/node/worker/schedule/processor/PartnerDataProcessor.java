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

package com.windsor.node.worker.schedule.processor;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ScheduledItemSourceType;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.client.DualEndpointNodeClientFactory;

public class PartnerDataProcessor implements InitializingBean {

    public final Logger logger = Logger.getLogger(this.getClass());

    private PartnerDao partnerDao;
    private DualEndpointNodeClientFactory clientFactory;
    private TransactionDao transactionDao;
    private NOSConfig nosConfig;
    private CompressionService compressionService;

    public void afterPropertiesSet() {
        if (partnerDao == null) {
            throw new RuntimeException("PartnerDao Not Set");
        }

        if (clientFactory == null) {
            throw new RuntimeException("PartnerDao Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        if (nosConfig == null) {
            throw new RuntimeException("NosConfig Not Set");
        }
    }

    public List getAndSaveData(String transactionId, String partnerId,
            String serviceName, ScheduledItemSourceType requestType,
            ByIndexOrNameMap serviceArgs, String flowName) {

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("Null transactionId");
        }

        if (StringUtils.isBlank(partnerId)) {
            throw new RuntimeException("Null partnerId");
        }

        if (StringUtils.isBlank(serviceName)) {
            throw new RuntimeException("Null serviceName");
        }

        if (requestType == null) {
            throw new RuntimeException("Null requestType");
        }

        try {

            List info = new ArrayList();

            logger.debug("PartnerId: " + partnerId);
            info.add(new ActivityEntry("Getting partner..."));

            PartnerIdentity partner = partnerDao.get(partnerId);

            logger.debug("Partner: " + partner);

            if (partner == null) {
                throw new RuntimeException("Partner not found:" + partnerId);
            }

            info.add(new ActivityEntry("Making client..."));
            NodeClientService clientService = clientFactory
                    .makeAndConfigure(partner);

            logger.debug("Setting client to the parner Url: "
                    + partner.getUrl());

            info.add(new ActivityEntry("Making request..."));
            DataRequest request = new DataRequest(serviceName, serviceArgs);
            request.setFlowName(flowName);
            request.setPaging(new PaginationIndicator(0, -1, true));

            logger.debug("Request: " + request);
            info.add(new ActivityEntry("Executing request..."));

            if (requestType == ScheduledItemSourceType.WEBSERVICE_QUERY) {

                SimpleContent queryResult = clientService.query(request);

                logger.debug("Response: " + queryResult);
                info.add(new ActivityEntry("Compressing results..."));

                byte[] compressedBytes = compressionService.zip(queryResult
                        .getContent(), serviceName + ".xml");

                info.add(new ActivityEntry("Creating document..."));
                Document doc = new Document(serviceName
                        + "-Partner-Results.zip", CommonContentType.ZIP,
                        compressedBytes);
                doc.setDocumentStatus(CommonTransactionStatusCode.PROCESSING);

                doc.setDocumentStatusDetail("Results of schedule query for "
                        + serviceName
                        + " were compressed, saved and marked for processing.");

                info.add(new ActivityEntry("Saving document..."));

                transactionDao.addDocument(transactionId, doc);

            } else if (requestType == ScheduledItemSourceType.WEBSERVICE_SOLICIT) {

                request.getRecipients().clear();
                if (partner.getVersion() == EndpointVersionType.EN11) {

                    info.add(new ActivityEntry(
                            "Setting return Url to v1.1 endpoint..."));
                    request.getRecipients().add(
                            nosConfig.getWebServiceEndpoint1());

                } else {

                    info.add(new ActivityEntry(
                            "Setting return Url to v2.0 endpoint..."));
                    request.getRecipients().add(
                            nosConfig.getWebServiceEndpoint2());
                }

                TransactionStatus status = clientService.solicit(request);
                String solicitTranId = status.getTransactionId();

                info.add(new ActivityEntry("Remote transaction Id: "
                        + solicitTranId));
                logger.debug("Result Tran Id: " + solicitTranId);

                info.add(new ActivityEntry("Updating transaction..."));

                logger.debug("Updating transaction id");
                transactionDao.updateNetworkId(transactionId, solicitTranId);

            }

            return info;

        } catch (Exception ex) {

            logger.error("Get And Save Data: " + ex.getMessage(), ex);

            throw new RuntimeException("Error while retrieving source data: "
                    + ex.getMessage(), ex);
        }
    }

    /**
     * getAndSendDataByUrl
     * 
     * @param transaction
     * @param partnerUrl
     * @param dataFlowName
     * @return
     */
    public List getAndSendDataByUrl(NodeTransaction transaction,
            String partnerUrl, String dataFlowName) {

        if (StringUtils.isBlank(partnerUrl)) {
            throw new RuntimeException("Null partnerUrl");
        }

        logger.debug("Getting partner: " + partnerUrl);
        PartnerIdentity partner = partnerDao.getByUrl(partnerUrl);
        logger.debug("Partner: " + partner);

        if (partner == null) {
            throw new RuntimeException("Partner not found:" + partnerUrl);
        }

        return getAndSendData(transaction, partner, dataFlowName);
    }

    /**
     * getAndSendData
     * 
     * @param transaction
     * @param partnerId
     * @param dataFlowName
     * @return
     */
    public List getAndSendData(NodeTransaction transaction, String partnerId,
            String dataFlowName) {

        if (StringUtils.isBlank(partnerId)) {
            throw new RuntimeException("Null partnerId");
        }

        logger.debug("Getting partner: " + partnerId);
        PartnerIdentity partner = partnerDao.get(partnerId);
        logger.debug("Partner: " + partner);

        if (partner == null) {
            throw new RuntimeException("Partner not found:" + partnerId);
        }

        return getAndSendData(transaction, partner, dataFlowName);
    }

    /**
     * getAndSendData
     * 
     * @param transaction
     * @param partner
     * @param dataFlowName
     * @return
     */
    public List getAndSendData(NodeTransaction transaction,
            PartnerIdentity partner, String dataFlowName) {

        if (transaction == null) {
            throw new RuntimeException("Null transactionId");
        }

        if (partner == null) {
            throw new RuntimeException("Null partner");
        }

        if (StringUtils.isBlank(dataFlowName)) {
            throw new RuntimeException("Null dataFlowName");
        }

        try {

            List info = new ArrayList();

            info.add(new ActivityEntry("Getting documents..."));

            logger.debug("Getting documents for transaction: "
                    + transaction.getId());
            List docs = transactionDao.getDocuments(transaction.getId(), false,
                    true);

            if (docs == null || docs.size() < 1) {
                throw new RuntimeException(
                        "No documents to send. At least one required.");
            }

            logger.debug("Documents: " + docs.size());
            info.add(new ActivityEntry("Found: " + docs.size()));

            transaction.setDocuments(docs);

            info.add(new ActivityEntry("Making partner client..."));
            NodeClientService clientService = clientFactory
                    .makeAndConfigure(partner);

            info.add(new ActivityEntry("Submitting..."));
            transaction = clientService.submit(transaction);

            info.add(new ActivityEntry("Updating network transaction Id: "
                    + transaction.getNetworkId()));

            transactionDao.updateNetworkId(transaction.getId(), transaction
                    .getNetworkId());

            return info;

        } catch (Exception ex) {

            logger.error("Get And Send Data: " + ex.getMessage(), ex);

            throw new RuntimeException("Error while retrieving source data: "
                    + ex.getMessage(), ex);
        }
    }

    public void setPartnerDao(PartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

    public void setClientFactory(DualEndpointNodeClientFactory clientFactory) {
        this.clientFactory = clientFactory;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    public void setCompressionService(CompressionService compressionService) {
        this.compressionService = compressionService;
    }

}
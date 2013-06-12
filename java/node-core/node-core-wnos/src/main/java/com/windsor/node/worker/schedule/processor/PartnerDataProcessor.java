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

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
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

    private Logger logger = LoggerFactory.getLogger(this.getClass());

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

    public List<ActivityEntry> getAndSaveData(NodeTransaction transaction,
            String partnerId, String serviceName,
            ScheduledItemSourceType requestType, ByIndexOrNameMap serviceArgs,
            String flowName) {

        if (transaction == null || StringUtils.isBlank(transaction.getId())) {
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

            List<ActivityEntry> info = new ArrayList<ActivityEntry>();

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

            if (requestType == ScheduledItemSourceType.WebServiceQuery) {

                SimpleContent queryResult = clientService.query(request);

                logger.debug("Response: " + queryResult);
                info.add(new ActivityEntry("Compressing results..."));

                byte[] compressedBytes = compressionService.zip(queryResult
                        .getContent(), serviceName + ".xml");

                info.add(new ActivityEntry("Creating document..."));
                Document doc = new Document(serviceName
                        + "-Partner-Results.zip", CommonContentType.ZIP,
                        compressedBytes);
                doc.setDocumentStatus(CommonTransactionStatusCode.Processing);

                doc.setDocumentStatusDetail("Results of schedule query for "
                        + serviceName
                        + " were compressed, saved and marked for processing.");

                info.add(new ActivityEntry("Saving document..."));

                transaction.getDocuments().add(doc);
                transactionDao.save(transaction);

            } else if (requestType == ScheduledItemSourceType.WebServiceSolicit) {

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

                logger.debug("Updating transaction");
                //transaction.setNetworkId(solicitTranId);//FIXME verify removing this is correct!!!!!!!!!!!
                transactionDao.save(transaction);
            }

            return info;

        } catch (Exception ex) {

            /*
             * Avoid trying to get the exception itself, as the type may not be
             * on the classpath - who knows what the partner's throwing? a
             * ClassNotFoundException will only mask the real error message -
             * even with our own v20 endpoint!
             */
            logger.error("Get And Save Data: " + ex.getMessage());

            throw new RuntimeException("Error while retrieving source data: "
                    + ex.getMessage());
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
    public List<ActivityEntry> getAndSendDataByUrl(NodeTransaction transaction,
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
    public List<ActivityEntry> getAndSendData(NodeTransaction transaction,
            String partnerId, String dataFlowName) {

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
    public List<ActivityEntry> getAndSendData(NodeTransaction transaction,
            PartnerIdentity partner, String dataFlowName) {

        if (transaction == null) {
            throw new RuntimeException("Null transaction");
        }

        if (partner == null) {
            throw new RuntimeException("Null partner");
        }

        if (StringUtils.isBlank(dataFlowName)) {
            throw new RuntimeException("Null dataFlowName");
        }

        try {

            List<ActivityEntry> info = new ArrayList<ActivityEntry>();

            info.add(new ActivityEntry("Getting documents..."));

            logger.debug("Getting documents for transaction: "
                    + transaction.getId());
            List<Document> docs = transactionDao.getDocuments(transaction
                    .getId(), false, true);

            if (docs == null || docs.size() < 1) {
                throw new RuntimeException(
                        "No documents to send. At least one required.");
            }

            logger.debug("Documents: " + docs.size());
            info.add(new ActivityEntry("Found: " + docs.size()));

            transaction.setDocuments(docs);

            String mesg = "Making partner client...";
            logger.debug(mesg);
            info.add(new ActivityEntry(mesg));
            NodeClientService clientService = clientFactory
                    .makeAndConfigure(partner);

            mesg = "Submitting...";
            logger.debug(mesg);
            info.add(new ActivityEntry(mesg));
            NodeTransaction resultTransaction = clientService
                    .submit(transaction);

            mesg = "Updating network transaction Id: "
                    + resultTransaction.getNetworkId();
            logger.debug(mesg);
            info.add(new ActivityEntry(mesg));

            transactionDao.updateNetworkId(transaction.getId(),
                    resultTransaction.getNetworkId());

            return info;

        } catch (Exception ex) {

            /*
             * Avoid trying to get the exception itself, as the type may not be
             * on the classpath - who knows what the partner's throwing? a
             * ClassNotFoundException will only mask the real error message -
             * even with our own v20 endpoint!
             */

            StringBuffer buf = new StringBuffer();

            buf.append(ex.getMessage());

            if (null != ex.getCause()) {

                buf.append(ex.getCause().getMessage());

                if (null != ex.getCause().getCause()) {

                    buf.append(ex.getCause().getCause());
                }

            }

            throw new RuntimeException("getAndSendData: " + buf.toString());
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

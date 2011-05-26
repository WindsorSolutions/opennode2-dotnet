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

package com.windsor.node.plugin.icisnpdes20;

import java.util.List;

import javax.sql.DataSource;

import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.icisnpdes20.dao.SubmissionHistoryDao;

public class DmrStatusChecker extends BaseWnosPlugin implements
        InitializingBean {

    public static final String ARG_PARTNER_URI = "Submission Partner URL";
    public static final String SERVICE_NAME = "GetDMRStatus";

    private DataSource pluginDataSource;
    private SubmissionHistoryDao submissionHistoryDao;
    private TransactionDao transactionDao;
    private String partnerUri;
    private NodeClientService nodeClient;

    public DmrStatusChecker() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        getSupportedPluginTypes().add(ServiceType.TASK);

        getConfigurationArguments().put(ARG_PARTNER_URI, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#process(com.windsor.node.common
     * .domain.NodeTransaction)
     */
    @SuppressWarnings("unchecked")
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Validating transaction...");
        validateTransaction(transaction);

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        result
                .getAuditEntries()
                .add(
                        makeEntry("Preparing to check status of pending DMR submissions..."));

        try {
            /*
             * 1. get tran network ids for flow where status
             * not(processed|failed)
             */
            List<String> idList = submissionHistoryDao.getAllTranIds();
            result.getAuditEntries().add(
                    makeEntry("Found " + idList.size()
                            + " transaction(s) to check."));

            /*
             * prior DMR submissions will have local status PROCESSED if
             * successfully generated and submitted, otherwise FAILED
             */
            for (String tranId : idList) {

                NodeTransaction tran = transactionDao.get(tranId, false);

                /* 2. getStatus & update local */
                result.getAuditEntries().add(
                        makeEntry("Checking status for local transaction id "
                                + tran.getId() + ", network id "
                                + tran.getNetworkId()));
                checkAndUpdateStatus(tran);

            }

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        return result;
    }

    /**
     * @param tran
     */
    private CommonTransactionStatusCode checkAndUpdateStatus(
            NodeTransaction tran) {

        CommonTransactionStatusCode status = tran.getStatus().getStatus();
        CommonTransactionStatusCode remoteStatus = null;

        if (!status.equals(CommonTransactionStatusCode.Completed)
                && !status.equals(CommonTransactionStatusCode.Failed)) {

            debug("Contacting partner...");
            remoteStatus = nodeClient.getStatus(tran.getNetworkId())
                    .getStatus();

            debug("Remote status: " + remoteStatus
                    + ", updating local transaction...");

            transactionDao.updateStatus(tran.getId(), remoteStatus);
        }

        return remoteStatus;

    }

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (getDataSources() == null
                && !getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source datasource not set");
        }

        if (null == pluginDataSource) {
            pluginDataSource = getDataSources().get(ARG_DS_SOURCE);
        }

        submissionHistoryDao = new SubmissionHistoryDao(pluginDataSource);

        transactionDao = (JdbcTransactionDao) getServiceFactory().makeService(
                JdbcTransactionDao.class);

        if (transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        partnerUri = getRequiredConfigValueAsString(ARG_PARTNER_URI);

        nodeClient = makeAndConfigureNodeClientService(partnerUri);
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public SubmissionHistoryDao getSubmissionHistoryDao() {
        return submissionHistoryDao;
    }

    public void setSubmissionHistoryDao(
            SubmissionHistoryDao submissionHistoryDao) {
        this.submissionHistoryDao = submissionHistoryDao;
    }

}

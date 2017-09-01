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
import java.util.LinkedList;
import java.util.List;

import com.windsor.node.worker.schedule.ScheduleProcessingException;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.PluginHelper;

public class LocalServiceDataProcessor implements InitializingBean {

    public final Logger logger = LoggerFactory.getLogger(this.getClass());

    private static final String ENTRY_SEPERATOR = ";\n";

    private ServiceDao serviceDao;
    private TransactionDao transactionDao;
    private PluginHelper pluginHelper;

    public void afterPropertiesSet() {
        if (serviceDao == null) {
            throw new RuntimeException("serviceDao Not Set");
        }

        if (pluginHelper == null) {
            throw new RuntimeException("PluginHelper Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }
    }

    public List getAndSaveData(NodeTransaction transaction,
            String localServiceId, String createdById,
            ByIndexOrNameMap serviceArgs) throws ScheduleProcessingException {

        if (transaction == null) {
            throw new RuntimeException("Null transaction");
        }

        if (StringUtils.isBlank(localServiceId)) {
            throw new RuntimeException("Null localServiceId");
        }

        List<ActivityEntry> info = new LinkedList<>();
        DataService service = null;
        DataRequest req = null;
        ProcessContentResult result = null;

        try {

            logger.debug("Local service Id: " + localServiceId);
            info.add(ActivityEntry.make("Getting local service..."));

            service = serviceDao.get(localServiceId);

            if (service == null) {
                throw new IllegalArgumentException(
                        "Unable to find a service with that id: "
                                + localServiceId);
            }

            logger.debug("Service: " + service);
            info.add(ActivityEntry.make("Building request..."));

            // REQUEST
            req = new DataRequest();

            req.setParameters(serviceArgs);
            req.setModifiedById(createdById);
            req.setService(service);
            req.setTransactionId(transaction.getId());
            req.setType(RequestType.Solicit);
            req.setFlowName(transaction.getFlow().getName());

            transaction.setRequest(req);

            info.add(ActivityEntry.make("Executing plugin..."));
            logger.debug("Transaction before processing: " + transaction);
        } catch(Exception exception) {
            logger.error(exception.getMessage(), exception);
            throw new ScheduleProcessingException("An error occurred setting up the environment for the plugin, this error " +
                    "occurred before the plugin was run and usually indicates a problem with your data source, exchange " +
                    "configuration or schedule configuration. Please double check these settings to ensure they are " +
                    "correct. The error was: " + exception.getMessage(), exception, info);
        }

        try {

            // PLUGIN EXECUTION
            // bad things could happen here
            result = pluginHelper.processTransaction(transaction);

            logger.debug("Plugin result audit entries: " + result.getAuditEntries());
            logger.debug("Plugin result status: " + result.getStatus());
            logger.debug("Plugin result paginatedContentIndicator: " + result.getPaginatedContentIndicator());
            logger.debug("Plugin result number of documents: " + result.getDocuments().size());
            logger.debug("Plugin result isSuccess: " + result.isSuccess());

            info.addAll(result.getAuditEntries());

            for (int d = 0; d < result.getDocuments().size(); d++) {

                Document resultDoc = (Document) result.getDocuments().get(d);
                info.add(ActivityEntry.make("Document: "
                        + resultDoc.getDocumentName()));

                transactionDao.addDocument(transaction.getId(), resultDoc);

            }

            if (!result.isSuccess()) {
                logger.error("Throwing a ScheduleProcessingException");
                throw new ScheduleProcessingException("Error while executing plugin!", info);
            }

            return info;
        } catch (Exception ex) {

            if(ex instanceof ScheduleProcessingException){
                logger.error("Re-throwing a ScheduleProcessingException");
                throw (ScheduleProcessingException) ex;
            }

            logger.error(ex.getMessage(), ex);
            logger.error("Throwing a ScheduleProcessingException");
            throw new ScheduleProcessingException("An error occurred while the plugin was executing that prevented the plugin " +
                    "from running. This usually indicates a " +
                    "problem with your data source, exchange configuration or schedule configuration. Please double " +
                    "check these settings to ensure they are correct. The error was: "+ ex.getMessage(), ex, info);

        }
    }

    /**
     * getDetailErrorMessage
     * 
     * @param entries
     * @return
     */
    private String getDetailErrorMessage(List entries) {

        if (entries == null) {
            return "";
        }

        StringBuffer sb = new StringBuffer();

        for (int i = 0; i < entries.size(); i++) {
            ActivityEntry entry = (ActivityEntry) entries.get(i);
            sb.append(entry.getMessage());
            sb.append(ENTRY_SEPERATOR);
        }

        return sb.toString();

    }

    public void setServiceDao(ServiceDao serviceDao) {
        this.serviceDao = serviceDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setPluginHelper(PluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

}

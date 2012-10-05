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

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NotificationType;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.NotificationDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.SchematronService;

public class SchematronDataProcessor implements InitializingBean {

    public final Logger logger = LoggerFactory.getLogger(this.getClass());

    private SchematronService schematronService;
    private TransactionDao transactionDao;
    private NotificationDao notificationDao;
    private NOSConfig nosConfig;

    public void afterPropertiesSet() {

        if (schematronService == null) {
            throw new RuntimeException("SchematronService Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        if (notificationDao == null) {
            throw new RuntimeException("NotificationDao Not Set");
        }

        if (nosConfig == null) {
            throw new RuntimeException("NosConfig Not Set");
        }
    }

    public List getAndSendData(NodeTransaction transaction) {

        if (transaction == null) {
            throw new RuntimeException("Null transaction");
        }

        if (transaction.getFlow() == null) {
            throw new RuntimeException("Null flow");
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

            info.add(new ActivityEntry("Getting subscribing user emails..."));
            List subscribers = notificationDao.getByFlowIdAndType(transaction
                    .getFlow().getId(), NotificationType.OnSchedule);

            info.add(new ActivityEntry("Adding email: "
                    + nosConfig.getNodeAdminEmail()));
            subscribers.add(nosConfig.getNodeAdminEmail());

            for (int f = 0; f < docs.size(); f++) {

                Document doc = (Document) docs.get(f);
                info
                        .add(new ActivityEntry("Document: "
                                + doc.getDocumentName()));

                logger.debug("Doc: " + doc);

                info.add(new ActivityEntry("Validating..."));
                schematronService.validate(doc,
                        transaction.getFlow().getName(), subscribers);

                info.add(new ActivityEntry("Validation request submitted."));
                logger.debug("Document sent");

            }

            return info;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while sending to Schematron: "
                    + ex.getMessage(), ex);
        }
    }

    public void setSchematronService(SchematronService schematronService) {
        this.schematronService = schematronService;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setNotificationDao(NotificationDao notificationDao) {
        this.notificationDao = notificationDao;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

}

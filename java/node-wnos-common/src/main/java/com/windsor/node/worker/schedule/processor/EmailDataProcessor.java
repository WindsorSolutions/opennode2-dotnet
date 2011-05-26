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

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.NotificationHelper;

public class EmailDataProcessor implements InitializingBean {

    public final Logger logger = LoggerFactory.getLogger(this.getClass());

    private CompressionService compressionService;
    private NotificationHelper notificationHelper;
    private TransactionDao transactionDao;
    private NOSConfig nosConfig;
    private IdGenerator idGenerator;

    public void afterPropertiesSet() {

        if (transactionDao == null) {
            throw new RuntimeException("TransactionDao Not Set");
        }

        if (compressionService == null) {
            throw new RuntimeException("CompressionService Not Set");
        }

        if (notificationHelper == null) {
            throw new RuntimeException("NotificationHelper Not Set");
        }

        if (nosConfig == null) {
            throw new RuntimeException("NosConfig Not Set");
        }

        if (idGenerator == null) {
            throw new RuntimeException("idGenerator Not Set");
        }

    }

    public List getAndSendData(String transactionId, ScheduledItem schedule) {

        if (StringUtils.isBlank(transactionId)) {
            throw new RuntimeException("Null transactionId");
        }

        if (schedule == null) {
            throw new RuntimeException("Null schedule");
        }

        try {

            List info = new ArrayList();

            info.add(new ActivityEntry("Getting documents..."));
            logger.debug("Getting documents for transaction: " + transactionId);
            List docs = transactionDao.getDocuments(transactionId, false, true);

            if (docs == null || docs.size() < 1) {
                throw new RuntimeException(
                        "No documents to send. At least one required.");
            }
            logger.debug("Documents: " + docs.size());
            info.add(new ActivityEntry("Found: " + docs.size()));

            String targetDirPath = FilenameUtils.concat(nosConfig.getTempDir()
                    .toString(), "ArchivedFiles-" + idGenerator.createId());
            info.add(new ActivityEntry("Target dir: " + targetDirPath));
            File targetDir = new File(targetDirPath);
            FileUtils.forceMkdir(targetDir);

            File finalFile = null;

            if (!targetDir.exists()) {
                throw new IOException("Unable to create dir: " + targetDirPath);
            }

            if (docs.size() == 1) {

                Document singleDoc = (Document) docs.get(0);

                logger.debug("Doc: " + singleDoc);
                info.add(new ActivityEntry("Document: "
                        + singleDoc.getDocumentName()));

                String targetFilePath = FilenameUtils.concat(targetDir
                        .toString(), singleDoc.getDocumentName());

                logger.debug("Target file path: " + targetFilePath);
                info.add(new ActivityEntry("Final file: " + targetFilePath));

                finalFile = new File(targetFilePath);
                FileUtils.writeByteArrayToFile(finalFile, singleDoc
                        .getContent());

            } else {

                for (int i = 0; i < docs.size(); i++) {

                    Document doc = (Document) docs.get(i);

                    logger.debug("Doc: " + doc);
                    info.add(new ActivityEntry("Document: "
                            + doc.getDocumentName()));

                    String targetFilePath = FilenameUtils.concat(targetDir
                            .toString(), doc.getDocumentName());

                    logger.debug("Target file path: " + targetFilePath);
                    info
                            .add(new ActivityEntry("Target file: "
                                    + targetFilePath));

                    File targetFile = new File(targetFilePath);
                    FileUtils
                            .writeByteArrayToFile(targetFile, doc.getContent());

                    logger.debug("Document written");
                    info.add(new ActivityEntry("Document saved"));

                }

                String finalTargetPath = FilenameUtils.concat(nosConfig
                        .getTempDir().toString(), idGenerator.createId()
                        + ".zip");
                logger.debug("Compressing target File: " + finalTargetPath);

                info.add(new ActivityEntry("Compressing all files..."));
                compressionService.zip(finalTargetPath, targetDirPath);
                finalFile = new File(finalTargetPath);
                logger.debug("Compressed target file: "
                        + finalFile.getAbsolutePath());

            }

            logger.debug("Sending: " + finalFile);
            info.add(new ActivityEntry("Sending..."));
            notificationHelper.sendScheduleResults(finalFile, transactionId,
                    schedule);

            info.add(new ActivityEntry("Attachment sent."));

            return info;

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            throw new RuntimeException("Error while retrieving source data: "
                    + ex.getMessage(), ex);
        }
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public void setCompressionService(CompressionService compressionService) {
        this.compressionService = compressionService;
    }

    public void setNotificationHelper(NotificationHelper notificationHelper) {
        this.notificationHelper = notificationHelper;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

}

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

package com.windsor.node.worker.schedule;

import java.sql.Timestamp;
import java.util.Date;
import org.springframework.beans.factory.InitializingBean;
import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ScheduleExecuteStatus;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.ScheduledItemSourceType;
import com.windsor.node.common.domain.ScheduledItemTargetType;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.ScheduleDao;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.service.helper.NotificationHelper;
import com.windsor.node.worker.NodeWorker;
import com.windsor.node.worker.schedule.processor.EmailDataProcessor;
import com.windsor.node.worker.schedule.processor.FileSystemDataProcessor;
import com.windsor.node.worker.schedule.processor.LocalServiceDataProcessor;
import com.windsor.node.worker.schedule.processor.PartnerDataProcessor;
import com.windsor.node.worker.schedule.processor.SchematronDataProcessor;
import com.windsor.node.worker.util.ScheduleUtil;

public class ScheduleExecutionWorker extends NodeWorker implements ScheduleItemExecutionService, InitializingBean
{
    private static final String NL = "\n";

    private ScheduleDao scheduleDao;
    private TransactionDao transactionDao;
    private NotificationHelper notificationHelper;
    private AccountDao accountDao;

    private SchematronDataProcessor schematronDataProcessor;
    private LocalServiceDataProcessor localServiceDataProcessor;
    private PartnerDataProcessor partnerDataProcessor;
    private FileSystemDataProcessor fileSystemDataProcessor;
    private EmailDataProcessor emailDataProcessor;

    private String executionMachineName;

    public ScheduleExecutionWorker() {
        super();
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (accountDao == null) {
            throw new RuntimeException("accountDao Not Set");
        }

        if (scheduleDao == null) {
            throw new RuntimeException("scheduleDao Not Set");
        }

        if (transactionDao == null) {
            throw new RuntimeException("transactionDao Not Set");
        }

        if (schematronDataProcessor == null) {
            throw new RuntimeException("schematronDataProcessor Not Set");
        }

        if (localServiceDataProcessor == null) {
            throw new RuntimeException("localServiceDataProcessor Not Set");
        }

        if (partnerDataProcessor == null) {
            throw new RuntimeException("partnerDataProcessor Not Set");
        }

        if (fileSystemDataProcessor == null) {
            throw new RuntimeException("fileSystemDataProcessor Not Set");
        }

        if (emailDataProcessor == null) {
            throw new RuntimeException("emailDataProcessor Not Set");
        }
    }

    /**
     * Run implementation from the timer
     */
    public void run() {

        if (!ScheduleExecutionHelper.shouldWeRunHere(getMachineId(),
                getExecutionMachineName())) {

            logger.warn("Configured executionMachineName does not match machineId, schedule will not run.");

        } else {

            try {

                logger.debug("Getting next schedule for execution");
                ScheduledItem schedule = scheduleDao.getForNextExec();
                logger.debug("Next one to execute: " + schedule);

                if (schedule != null) {

                    Timestamp next = null;

                    if (schedule.getNextRunOn() != null) {

                        logger.debug("Calculating next run");
                        next = ScheduleUtil.calculateNextRun(schedule);
                    }

                    logger.debug("Processing");
                    processSchedule(schedule);

                    logger.debug("Updating next run: " + next);
                    //scheduleDao.setRun(schedule.getId(), next);
                    schedule.setRunNow(false);
                    schedule.setNextRunOn(next);
                    scheduleDao.save(schedule);
                }

            } catch (Exception ex) {
                // Do not throw exception.
                // Processing method took care of the logging
                logger.error("Run Error: " + ex.getMessage(), ex);
            }
        } // end if shouldWeRunHere
    }

    public void run(ScheduledItem schedule)
    {
        if(schedule == null)
        {
            throw new IllegalArgumentException("ScheduleExecutionWorker run method's parameter ScheduledItem schedule cannot be null.");
        }
        if(!ScheduleExecutionHelper.shouldWeRunHere(getMachineId(), getExecutionMachineName()))
        {
            logger.debug("Configured executionMachineName does not match machineId, schedule will not run.");
            return;
        }
        if(ScheduleExecuteStatus.Running.equals(schedule.getExecuteStatus()))
        {
            logger.info("ScheduledItem.id " + schedule.getId() + " and ScheduledItem.name " + schedule.getName() + " is currently in " 
                        + ScheduleExecuteStatus.Running.name() + " status and will not be run.");
            return;
        }
        logger.debug("Processing ScheduledItem.id " + schedule.getId());
        processSchedule(schedule);

        //should not need a next run set as this is an "ad hoc" run
    }

    @SuppressWarnings("unchecked")
    private void processSchedule(ScheduledItem schedule) {

        logger.debug("processing: " + schedule);

        if (schedule == null) {
            throw new IllegalArgumentException("Schedule object not set");
        }

        NodeTransaction tran = null;

        Activity logEntry = new Activity();
        logEntry.setModifiedById(schedule.getModifiedById());
        logEntry.setIp(getNosConfig().getLocalhostIp());
        logEntry.setType(ActivityType.Info);
        logEntry.addEntry("Machine Id: " + getMachineId());

        try {

            logEntry.addEntry("Schedule: " + schedule.getName());

            // TRAN
            logger.debug("Getting transaction for: " + schedule.getFlowId());

            tran = transactionDao.make(schedule, NodeMethodType.Schedule,
                    CommonTransactionStatusCode.Processing);

            tran.setCreator(accountDao.get(schedule.getModifiedById()));

            logEntry.setTransactionId(tran.getId());
            logEntry.addEntry("Transaction Id: " + tran.getNetworkId());

            /*
             * SOURCE
             */
            logger.debug("Parsing schedule type: " + schedule.getSourceType());

            // Check if this is request or generate
            if(schedule.getSourceType().equals(ScheduledItemSourceType.WebServiceQuery)
                            || schedule.getSourceType().equals(ScheduledItemSourceType.WebServiceSolicit))
            {
                // WEBSERVICE
                logEntry.addEntryAll(partnerDataProcessor.getAndSaveData(tran, schedule.getSourceId(), schedule
                                .getSourceOperation(), schedule.getSourceType(), schedule.getSourceArgs(), tran
                                .getFlow().getName()));

            }
            else if(schedule.getSourceType().equals(ScheduledItemSourceType.File))
            {
                // FILE
                logEntry.addEntryAll(fileSystemDataProcessor.getAndSaveData(tran.getId(), schedule.getSourceId()));

            }
            else if(schedule.getSourceType().equals(ScheduledItemSourceType.LocalService))
            {
                // LOCALSERVICE
                logEntry.addEntryAll(localServiceDataProcessor.getAndSaveData(tran, schedule.getSourceId(),
                                                                              schedule.getModifiedById(),
                                                                              schedule.getSourceArgs()));
            }
            else
            {
                throw new RuntimeException("Invalid data source: " + schedule.getSourceType());
            }

            /*
             * 
             * 
             * Target
             */
            if(schedule.getTargetType().equals(ScheduledItemTargetType.Partner))
            {
                // PARTNER
                logEntry.addEntryAll(partnerDataProcessor.getAndSendData(tran, schedule.getTargetId(), tran.getFlow()
                                .getName()));

            }
            else if(schedule.getTargetType().equals(ScheduledItemTargetType.Schematron))
            {
                // SCHEMATRON
                logEntry.addEntryAll(schematronDataProcessor.getAndSendData(tran));

            }
            else if(schedule.getTargetType().equals(ScheduledItemTargetType.Email))
            {
                // EMAIL
                logEntry.addEntryAll(emailDataProcessor.getAndSendData(tran.getId(), schedule));

            }
            else if(schedule.getTargetType().equals(ScheduledItemTargetType.File))
            {
                logEntry.addEntryAll(fileSystemDataProcessor.getAndSendData(tran.getId(), schedule.getTargetId()));

            }
            else
            {
                logEntry.addEntry("No target defined");
            }

            /*
             * 
             * 
             * POST PROCESS
             */

            logger.debug("Updating status to processed for: " + tran.getId());
            transactionDao.updateStatus(tran.getId(),
                    CommonTransactionStatusCode.Processed);

            logger.debug("Sending notifications for: " + schedule);
            notificationHelper.sendSchedule(schedule, tran.getId());

            if(!schedule.getTargetType().equals(ScheduledItemTargetType.None))
            {
                logEntry.addEntry("Notification Sent");
            }
            /*scheduleDao.setRunInfo(schedule.getId(), getScheduleInfo(logEntry,
                    true), ScheduleExecuteStatus.Success);*/
            schedule.setLastExecutionInfo(getScheduleInfo(logEntry, true));
            schedule.setExecuteStatus(ScheduleExecuteStatus.Success);

        } catch (Exception ex) {

            logger.error("Error while processing schedule: " + ex.getMessage(),
                    ex);

            logEntry.setType(ActivityType.Error);
            logEntry.addEntry("Error:{0}", new Object[] { ex.getMessage() });

            if (tran != null) {
                transactionDao.updateStatus(tran.getId(),
                        CommonTransactionStatusCode.Failed);
            }

            /*scheduleDao.setRunInfo(schedule.getId(), getScheduleInfo(logEntry,
                    false), ScheduleExecuteStatus.Failure);*/
            schedule.setLastExecutionInfo(getScheduleInfo(logEntry, false));
            schedule.setExecuteStatus(ScheduleExecuteStatus.Failure);

        } finally {
            getActivityService().insert(logEntry);
            schedule.setLastExecutionActivity(logEntry);
            schedule.setLastExecutedOn(new Timestamp(new Date().getTime()));
            scheduleDao.save(schedule);
        }
    }

    private String getScheduleInfo(Activity logEntry, boolean success) {

        StringBuffer sb = new StringBuffer();

        if (logEntry != null) {

            sb.append("Success: " + (success ? "Yes" : "No") + NL);
            sb.append(NL);

            if (logEntry.getEntries() != null) {

                for (int i = 0; i < logEntry.getEntries().size(); i++) {
                    ActivityEntry entry = (ActivityEntry) logEntry.getEntries()
                            .get(i);
                    sb.append(entry.getMessage() + NL);
                }

            }

        } else {
            sb.append("Error, please see the activity log");
        }

        return sb.toString();

    }

    public ScheduleDao getScheduleDao() {
        return scheduleDao;
    }

    public void setScheduleDao(ScheduleDao scheduleDao) {
        this.scheduleDao = scheduleDao;
    }

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public NotificationHelper getNotificationHelper() {
        return notificationHelper;
    }

    public void setNotificationHelper(NotificationHelper notificationHelper) {
        this.notificationHelper = notificationHelper;
    }

    public SchematronDataProcessor getSchematronDataProcessor() {
        return schematronDataProcessor;
    }

    public void setSchematronDataProcessor(
            SchematronDataProcessor schematronDataProcessor) {
        this.schematronDataProcessor = schematronDataProcessor;
    }

    public LocalServiceDataProcessor getLocalServiceDataProcessor() {
        return localServiceDataProcessor;
    }

    public void setLocalServiceDataProcessor(
            LocalServiceDataProcessor localServiceDataProcessor) {
        this.localServiceDataProcessor = localServiceDataProcessor;
    }

    public PartnerDataProcessor getPartnerDataProcessor() {
        return partnerDataProcessor;
    }

    public void setPartnerDataProcessor(
            PartnerDataProcessor partnerDataProcessor) {
        this.partnerDataProcessor = partnerDataProcessor;
    }

    public FileSystemDataProcessor getFileSystemDataProcessor() {
        return fileSystemDataProcessor;
    }

    public void setFileSystemDataProcessor(
            FileSystemDataProcessor fileSystemDataProcessor) {
        this.fileSystemDataProcessor = fileSystemDataProcessor;
    }

    public EmailDataProcessor getEmailDataProcessor() {
        return emailDataProcessor;
    }

    public void setEmailDataProcessor(EmailDataProcessor emailDataProcessor) {
        this.emailDataProcessor = emailDataProcessor;
    }

    public void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

    public String getExecutionMachineName() {
        return executionMachineName;
    }

    public void setExecutionMachineName(String executionMachineName) {
        this.executionMachineName = executionMachineName;
    }
}

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

package com.windsor.node.service.helper.email;

import java.io.File;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NotificationType;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.NotificationDao;
import com.windsor.node.service.helper.NotificationHelper;
import com.windsor.node.service.helper.SimpleEmailService;

public class EmailNotificationHelper implements InitializingBean,
        NotificationHelper, SimpleEmailService {

    /**
     * Logger for this class and subclasses
     */
    private final Logger logger = LoggerFactory
            .getLogger(EmailNotificationHelper.class);

    private static String ARG_STATUS = "STATUS";
    private static String ARG_USERNAME = "USERNAME";
    private static String ARG_PASSWORD = "PASSWORD";
    private static String ARG_ADMINURL = "ADMINURL";
    private static String ARG_NODEID = "NODEID";
    private static String ARG_TRANID = "TRANID";
    private static String ARG_FLOWID = "FLOWID";
    private static String ARG_DATE = "DATE";
    private static String ARG_SERVICENAME = "SERVICENAME";
    private static String ARG_SERVICEROWID = "SERVICEROWID";
    private static String ARG_SERVICEMAXROWS = "SERVICEMAXROWS";
    private static String ARG_SERVICEARGS = "SERVICEARGS";
    private static String ARG_SCHEDULENAME = "SCHEDULENAME";
    private static String ARG_SCHEDULEID = "SCHEDULEID";
    private static String ARG_SCHEDULEDOC = "DOC";

    private NAASConfig naasConfig;
    private NOSConfig nosConfig;
    private NotificationDao notificationDao;

    private JavaMailSender sender;
    private EmailMessagePreparator newLocalUserPreparator;
    private EmailMessagePreparator newNAASUserPreparator;
    private EmailMessagePreparator notifPreparator;
    private EmailMessagePreparator queryPreparator;
    private EmailMessagePreparator schedulePreparator;
    private EmailMessagePreparator errorPreparator;
    private EmailMessagePreparator solicitPreparator;
    private EmailMessagePreparator processedSolicitPreparator;
    private EmailMessagePreparator submitPreparator;
    private EmailMessagePreparator processedSubmitPreparator;
    private EmailMessagePreparator scheduleResultPreparator;
    private EmailMessagePreparator newPasswordPreparator;
    private EmailMessagePreparator transactionStatusPreparator;

    @Override
    public void afterPropertiesSet() {

        if (transactionStatusPreparator == null) {
            throw new RuntimeException("Transaction Status Preparator Not Set");
        }

        if (newPasswordPreparator == null) {
            throw new RuntimeException("Schedule Result Preparator Not Set");
        }

        if (scheduleResultPreparator == null) {
            throw new RuntimeException("Schedule Result Preparator Not Set");
        }

        if (processedSubmitPreparator == null) {
            throw new RuntimeException("Processed Submit Preparator Not Set");
        }

        if (notificationDao == null) {
            throw new RuntimeException("Notification Dao Not Set");
        }

        if (naasConfig == null) {
            throw new RuntimeException("NAAS Config Not Set");
        }

        if (nosConfig == null) {
            throw new RuntimeException("NOS Config Not Set");
        }

        if (sender == null) {
            throw new RuntimeException("Java Mail Sender Not Set");
        }

        if (newLocalUserPreparator == null) {
            throw new RuntimeException("New Local User Preparator Not Set");
        }

        if (newNAASUserPreparator == null) {
            throw new RuntimeException("New NAAS User Preparator Not Set");
        }

        if (notifPreparator == null) {
            throw new RuntimeException("Query Preparator Not Set");
        }

        if (queryPreparator == null) {
            throw new RuntimeException("Schedule Preparator Not Set");
        }

        if (schedulePreparator == null) {
            throw new RuntimeException("Schedule Preparator Not Set");
        }

        if (solicitPreparator == null) {
            throw new RuntimeException("Solicit Preparator Not Set");
        }

        if (submitPreparator == null) {
            throw new RuntimeException("Submit Preparator Not Set");
        }

        if (processedSolicitPreparator == null) {
            throw new RuntimeException("Processed Solicit Preparator Not Set");
        }

        if (errorPreparator == null) {
            throw new RuntimeException("Error Preparator Not Set");
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendScheduleResults(java.
     * io.File, java.lang.String, com.windsor.node.common.domain.ScheduledItem)
     */
    @Override
    public void sendScheduleResults(File file, String transactionID,
                                    ScheduledItem schedule) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_SCHEDULENAME, schedule.getName());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_TRANID, transactionID);
        data.put(ARG_SCHEDULEID, schedule.getId());
        data.put(ARG_SCHEDULEDOC, file.getName());

        logData(data);

        String[] tos = StringUtils.split(schedule.getTargetId(), ';');

        for (int i = 0; i < tos.length; i++) {

            scheduleResultPreparator.configure(tos[i].trim(), data, file);

            try {
                sender.send(scheduleResultPreparator);
            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendCustom(java.lang.String
     * [], java.lang.String)
     */
    @Override
    public void sendCustom(String[] toEmailList, String body) {

        SimpleMailMessage msg = new SimpleMailMessage();
        msg.setFrom(nosConfig.getNodeAdminEmail());
        msg.setText(body);

        for (int i = 0; i < toEmailList.length; i++) {
            msg.setTo(toEmailList[i]);
            try {
                sender.send(msg);
            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendNewPassword(com.windsor
     * .node.common.domain.UserAccount, java.lang.String)
     */
    @Override
    public void sendNewPassword(UserAccount account, String password) {

        Map data = new HashMap();

        data.put(ARG_NODEID, naasConfig.getNodeId());
        data.put(ARG_USERNAME, account.getNaasUserName());
        data.put(ARG_PASSWORD, password);
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());

        logData(data);

        newPasswordPreparator.configure(account.getNaasUserName(), data);

        try {
            sender.send(newPasswordPreparator);
        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(ex);
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendNewLocalUser(com.windsor
     * .node.common.domain.UserAccount, java.lang.String)
     */
    @Override
    public void sendNewLocalUser(UserAccount account, String password) {

        Map data = new HashMap();

        data.put(ARG_NODEID, naasConfig.getNodeId());
        data.put(ARG_USERNAME, account.getNaasUserName());
        data.put(ARG_PASSWORD, password);
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());

        logData(data);

        newLocalUserPreparator.configure(account.getNaasUserName(), data);

        logger.debug("newLocalUserPreparator configured");

        try {
            sender.send(newLocalUserPreparator);

            logger.debug("newLocalUserPreparator sent");
        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(ex);
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendNewNAASUser(com.windsor
     * .node.common.domain.UserAccount, java.lang.String)
     */
    @Override
    public void sendNewNAASUser(UserAccount account, String password) {

        Map data = new HashMap();

        data.put(ARG_NODEID, naasConfig.getNodeId());
        data.put(ARG_USERNAME, account.getNaasUserName());
        data.put(ARG_PASSWORD, password);
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());

        logData(data);

        newNAASUserPreparator.configure(account.getNaasUserName(), data);

        try {
            sender.send(newNAASUserPreparator);
        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(ex);
        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendNotifs(com.windsor.node
     * .common.domain.NodeTransaction, java.lang.String)
     */
    @Override
    public void sendNotifs(NodeTransaction tran) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, tran.getCreator().getNaasUserName());
        data.put(ARG_FLOWID, tran.getFlow().getName());
        data.put(ARG_TRANID, tran.getId());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_NODEID, naasConfig.getNodeId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                tran.getFlow().getId(), NotificationType.OnNotify).iterator(); it
                     .hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            notifPreparator.configure(to, data);

            try {
                sender.send(notifPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }
            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendQueries(com.windsor.node
     * .common.domain.DataRequest)
     */
    @Override
    public void sendQueries(DataRequest request) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, request.getRequestor().getNaasUserName());
        data.put(ARG_SERVICENAME, request.getService().getName());
        data.put(ARG_SERVICEARGS, request.getParameters().toString());
        data.put(ARG_SERVICEROWID, new Integer(request.getPaging().getStart()));
        data.put(ARG_SERVICEMAXROWS,
                new Integer(request.getPaging().getCount()));

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                request.getService().getFlowId(), NotificationType.OnQuery)
                .iterator(); it.hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            queryPreparator.configure(to, data);

            try {
                sender.send(queryPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendSchedule(com.windsor.
     * node.common.domain.ScheduledItem, java.lang.String)
     */
    @Override
    public void sendSchedule(ScheduledItem schedule, String transactionID) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_SCHEDULENAME, schedule.getName());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_TRANID, transactionID);
        data.put(ARG_SCHEDULEID, schedule.getId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                schedule.getFlowId(), NotificationType.OnSchedule).iterator(); it
                     .hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            schedulePreparator.configure(to, data);

            try {
                sender.send(schedulePreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendProcessedSolicits(com
     * .windsor.node.common.domain.DataRequest)
     */
    @Override
    public void sendProcessedSolicits(DataRequest request) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, request.getRequestor().getNaasUserName());
        data.put(ARG_SERVICENAME, request.getService().getName());
        data.put(ARG_SERVICEARGS, request.getParameters().toString());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_TRANID, request.getTransactionId());
        data.put(ARG_NODEID, naasConfig.getNodeId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                request.getService().getFlowId(), NotificationType.OnSolicit)
                .iterator(); it.hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            processedSolicitPreparator.configure(to, data);

            try {
                sender.send(processedSolicitPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }
            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendSolicits(com.windsor.
     * node.common.domain.DataRequest)
     */
    @Override
    public void sendSolicits(DataRequest request) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, request.getRequestor().getNaasUserName());
        data.put(ARG_SERVICENAME, request.getService().getName());
        data.put(ARG_SERVICEARGS, request.getParameters().toString());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_TRANID, request.getTransactionId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                request.getService().getFlowId(), NotificationType.OnSolicit)
                .iterator(); it.hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            solicitPreparator.configure(to, data);

            try {
                sender.send(solicitPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    /*
 * (non-Javadoc)
 *
 * @see
 * com.windsor.node.service.helper.email.EHelp#sendError(com.windsor.
 * node.common.domain.ScheduledItem, java.lang.String)
 */
    @Override
    public void sendError(ScheduledItem schedule, String transactionID) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_SCHEDULENAME, schedule.getName());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_TRANID, transactionID);
        data.put(ARG_SCHEDULEID, schedule.getId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                schedule.getFlowId(), NotificationType.OnError).iterator(); it
                     .hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            errorPreparator.configure(to, data);

            try {
                sender.send(errorPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendProcessedSubmits(com.
     * windsor.node.common.domain.NodeTransaction, java.lang.String)
     */
    @Override
    public void sendProcessedSubmits(NodeTransaction tran) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, tran.getCreator().getNaasUserName());
        data.put(ARG_FLOWID, tran.getFlow().getName());
        data.put(ARG_TRANID, tran.getId());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());
        data.put(ARG_NODEID, naasConfig.getNodeId());

        logData(data);

        for (Iterator it = notificationDao.getByFlowIdAndType(
                tran.getFlow().getId(), NotificationType.OnSubmit).iterator(); it
                     .hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            submitPreparator.configure(to, data);

            try {
                sender.send(submitPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    @Override
    public void sendTransactionStatusUpdate(NodeTransaction transaction,
                                            String emailAddress, String dataFlowName) {
        sendTransactionStatusUpdate(transaction, emailAddress, dataFlowName, null);
    }

    /**
     * sendTransactionStatusUpdate
     *
     * @param tran
     */
    //TODO fix to include actual DataFlow object rather than name
    @Override
    public void sendTransactionStatusUpdate(NodeTransaction transaction,
                                            String emailAddress, String dataFlowName, List<Document> attachments) {

        Map data = new HashMap();

        data.put(ARG_TRANID, transaction.getNetworkId());
        data.put(ARG_STATUS, transaction.getStatus().getStatus().name());
        data.put(ARG_FLOWID, dataFlowName);

        logData(data);

        logger.debug("to: " + emailAddress);

        transactionStatusPreparator.configure(emailAddress, data, attachments);

        try {
            sender.send(transactionStatusPreparator);

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException(ex);
        }

        logger.debug("sent: " + emailAddress);

    }

    /**
     * Avoid logging passwords in clear text! Doh!
     * <p>
     * Just a quick fix, doens't guarantee we don't do it somewhere else.
     *
     * @param data
     */
    private void logData(Map data) {
        StringBuffer buf = new StringBuffer();
        buf.append("data: {");
        Iterator iter = data.keySet().iterator();
        String delim = ", ";
        while (iter.hasNext()) {
            String key = (String) iter.next();
            buf.append(key + "=");
            if (key.equals("PASSWORD")) {
                buf.append("********");
            } else {
                buf.append(data.get(key));
            }
            if (iter.hasNext()) {
                buf.append(delim);
            }
        }
        buf.append("}");
        logger.debug(buf.toString());
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#sendSubmits(com.windsor.node
     * .common.domain.NodeTransaction, java.lang.String)
     */
    @Override
    public void sendSubmits(NodeTransaction tran) {

        Map data = new HashMap();

        data.put(ARG_DATE, new Date());
        data.put(ARG_USERNAME, tran.getCreator().getNaasUserName());
        data.put(ARG_FLOWID, tran.getFlow().getName());
        data.put(ARG_TRANID, tran.getId());
        data.put(ARG_ADMINURL, nosConfig.getAdminUrl());

        logData(data);

        List notifs = notificationDao.getByFlowIdAndType(
                tran.getFlow().getId(), NotificationType.OnSubmit);

        for (Iterator it = notifs.iterator(); it.hasNext(); ) {

            String to = (String) it.next();

            logger.debug("to: " + to);

            submitPreparator.configure(to, data);

            try {
                sender.send(submitPreparator);

            } catch (Exception ex) {
                logger.error(ex.getMessage(), ex);
                throw new RuntimeException(ex);
            }

            logger.debug("sent: " + to);

        }

    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setSender(org.springframework
     * .mail.javamail.JavaMailSender)
     */
    public void setSender(JavaMailSender sender) {
        this.sender = sender;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNewLocalUserPreparator
     * (com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setNewLocalUserPreparator(
            EmailMessagePreparator newLocalUserPreparator) {
        this.newLocalUserPreparator = newLocalUserPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNewNAASUserPreparator(
     * com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setNewNAASUserPreparator(
            EmailMessagePreparator newNAASUserPreparator) {
        this.newNAASUserPreparator = newNAASUserPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNotifPreparator(com.windsor
     * .node.service.helper.email.EmailMessagePreparator)
     */
    public void setNotifPreparator(EmailMessagePreparator notifPreparator) {
        this.notifPreparator = notifPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setQueryPreparator(com.windsor
     * .node.service.helper.email.EmailMessagePreparator)
     */
    public void setQueryPreparator(EmailMessagePreparator queryPreparator) {
        this.queryPreparator = queryPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setSchedulePreparator(com
     * .windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setSchedulePreparator(EmailMessagePreparator schedulePreparator) {
        this.schedulePreparator = schedulePreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setSolicitPreparator(com.
     * windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setSolicitPreparator(EmailMessagePreparator solicitPreparator) {
        this.solicitPreparator = solicitPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setSubmitPreparator(com.windsor
     * .node.service.helper.email.EmailMessagePreparator)
     */
    public void setSubmitPreparator(EmailMessagePreparator submitPreparator) {
        this.submitPreparator = submitPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNaasConfig(com.windsor
     * .node.conf.NAASConfig)
     */
    public void setNaasConfig(NAASConfig naasConfig) {
        this.naasConfig = naasConfig;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNosConfig(com.windsor.
     * node.conf.NOSConfig)
     */
    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNotificationDao(com.windsor
     * .node.data.dao.NotificationDao)
     */
    public void setNotificationDao(NotificationDao notificationDao) {
        this.notificationDao = notificationDao;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setProcessedSolicitPreparator
     * (com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setProcessedSolicitPreparator(
            EmailMessagePreparator processedSolicitPreparator) {
        this.processedSolicitPreparator = processedSolicitPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setProcessedSubmitPreparator
     * (com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setProcessedSubmitPreparator(
            EmailMessagePreparator processedSubmitPreparator) {
        this.processedSubmitPreparator = processedSubmitPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setScheduleResultPreparator
     * (com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setScheduleResultPreparator(
            EmailMessagePreparator scheduleResultPreparator) {
        this.scheduleResultPreparator = scheduleResultPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setNewPasswordPreparator(
     * com.windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setNewPasswordPreparator(
            EmailMessagePreparator newPasswordPreparator) {
        this.newPasswordPreparator = newPasswordPreparator;
    }

    public void setTransactionStatusPreparator(
            EmailMessagePreparator transactionStatusPreparator) {
        this.transactionStatusPreparator = transactionStatusPreparator;
    }

    /*
     * (non-Javadoc)
     *
     * @see
     * com.windsor.node.service.helper.email.EHelp#setSchedulePreparator(com
     * .windsor.node.service.helper.email.EmailMessagePreparator)
     */
    public void setErrorPreparator(EmailMessagePreparator errorPreparator) {
        this.errorPreparator = errorPreparator;
    }

}

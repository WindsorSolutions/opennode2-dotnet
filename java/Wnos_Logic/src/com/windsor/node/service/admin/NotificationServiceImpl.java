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

import java.util.List;

import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.NotificationService;
import com.windsor.node.data.dao.NotificationDao;
import com.windsor.node.service.BaseService;

public class NotificationServiceImpl extends BaseService implements
        NotificationService, InitializingBean {

    private NotificationDao notificationDao;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (notificationDao == null) {
            throw new RuntimeException("NotificationDao Not Set");
        }

    }

    /**
     * @see com.windsor.node.common.service.admin.NotificationService#getByAccountIdLight(java.lang.String,
     *      com.windsor.node.common.domain.NodeVisit)
     */
    public List getByAccountIdLight(String accountId, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        logger.debug("Getting notifications for account: " + accountId);

        return notificationDao.getByAccountId(accountId);

    }

    /**
     * getByAccount
     */
    public List getByAccount(String accountId, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        logger.debug("Getting notifications for account: " + accountId);

        return notificationDao.getByAccountId(accountId);

    }

    /**
     * getByFlow
     */
    public List getByFlow(String flowId, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        logger.debug("Getting notifications for flow: " + flowId);

        return notificationDao.getByFlowId(flowId);
    }

    /**
     * save
     */
    public void save(String accountId, List instances, NodeVisit visit) {

        if (instances == null) {
            throw new RuntimeException("Notification List argument not set.");
        }

        // Make sure the user performing that action has PROGRAM rights
        validateByRole(visit, SystemRoleType.Program);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            if ((accountId != visit.getUserAccount().getId())
                    && (visit.getUserAccount().getRole()
                            .equals(SystemRoleType.Admin))) {
                throw new IllegalArgumentException(
                        "Only admins can edit other users' notifications.");
            }

            notificationDao.save(accountId, instances);

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while saving notification in DB: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public void setNotificationDao(NotificationDao notificationDao) {
        this.notificationDao = notificationDao;
    }

}
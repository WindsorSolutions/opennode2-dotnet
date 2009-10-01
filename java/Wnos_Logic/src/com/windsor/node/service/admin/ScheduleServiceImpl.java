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

import java.sql.Timestamp;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.ScheduleService;
import com.windsor.node.data.dao.ScheduleDao;
import com.windsor.node.service.BaseService;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.ScheduleUtil;

public class ScheduleServiceImpl extends BaseService implements
        ScheduleService, InitializingBean {

    private ScheduleDao scheduleDao;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (scheduleDao == null) {
            throw new RuntimeException("ScheduleDao Not Set");
        }

    }

    public void delete(String scheduleId, NodeVisit visit) {

        if (StringUtils.isBlank(scheduleId)) {
            throw new RuntimeException("scheduleId not set.");
        }

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        ScheduledItem schedule = scheduleDao.get(scheduleId);

        if (schedule == null) {
            throw new RuntimeException(
                    "Schedule item not present in local database.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to delete schedule {1}.",
                    new Object[] { visit.getName(), schedule.getName() });

            // NAAS
            logger.debug("Attempting to delete schedule: " + schedule);
            scheduleDao.delete(schedule.getId());
            logEntry.addEntry("Schedule deleted from DB.");

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while deleting schedule: "
                    + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * get
     */
    public ScheduledItem get(String scheduleId, NodeVisit visit) {

        return scheduleDao.get(scheduleId);

    }

    /**
     * get
     */
    @SuppressWarnings("unchecked")
    public List<ScheduledItem> get(NodeVisit visit) {

        return (List<ScheduledItem>) scheduleDao.get();
    }

    /**
     * get
     * 
     * @return
     */
    public List<?> get() {

        return scheduleDao.get();
    }

    /**
     * runNow
     */
    public void saveAndRunNow(ScheduledItem instance, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        save(instance, visit);

        scheduleDao.setRun(instance.getId(), DateUtil.getTimestamp());

    }

    public ScheduledItem save(ScheduledItem instance, NodeVisit visit) {

        if (instance == null) {
            throw new RuntimeException("ScheduledItem argument not set.");
        }

        ScheduledItem savedSchedule = null;

        instance.setNextRunOn(ScheduleUtil.calculateNextRun(instance));
        logger.debug("Attempting to save:" + instance);

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Program);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to save schedule {1}.",
                    new Object[] { visit.getName(), instance.getName() });

            instance.setModifiedById(visit.getUserAccount().getId());

            if (instance.getNextRunOn() == null
                    || instance.getNextRunOn().equals(
                            new Timestamp(Integer.MIN_VALUE))) {
                instance.setNextRunOn(instance.getStartOn());
            }

            logger.debug("Next run:" + instance.getNextRunOn());

            if (instance.getSourceType() == null
                    || StringUtils.isBlank(instance.getSourceId())) {
                throw new RuntimeException(
                        "Required data element not set: Source Command Id");
            }

            logger.debug("Attempting to save schedule in DB");
            savedSchedule = scheduleDao.save(instance);
            logEntry.addEntry("Schedule saved in DB.");

        } catch (Exception ex) {

            logger.error(ex);

            logEntry.addEntry("Error while saving schedule in DB: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

        return savedSchedule;

    }

    public void setScheduleDao(ScheduleDao scheduleDao) {
        this.scheduleDao = scheduleDao;
    }

}
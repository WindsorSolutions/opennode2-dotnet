/*
 * Copyright (c) 2009, Windsor Solutions, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the Windsor Solutions, Inc., the Environmental 
 *       Council of States (ECOS), nor the names of its contributors may be 
 *       used to endorse or promote products derived from this software 
 *       without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY Windsor Solutions, Inc. "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL Windsor Solutions, Inc. or ECOS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

/**
 * 
 */
package com.windsor.node.worker.util;

import com.windsor.node.common.domain.ScheduleFrequencyType;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.util.DateUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.Timestamp;

public final class ScheduleUtil {

    private static Logger logger = LoggerFactory.getLogger(ScheduleUtil.class);

    private ScheduleUtil() {

    }

    /**
     * Given a populated Schedule, determine the next execution time.
     * <p>
     * <p>
     * Called when saving, and just prior to running, a Schedule.
     * </p>
     * <p>
     * <p>
     * We assume that the Schedule's start date is less than the end date - the
     * ScheduleValidator enforces this in the Node Admin UI.
     * </p>
     *
     * @param schedule
     * @return Timestamp for the next run, possibly null
     */
    public static Timestamp calculateNextRun(ScheduledItem schedule) {

        //short cut, if the schedule is set to execute Never it will never run, enhancement, 2013-04-26
        if (schedule.getFrequencyType() == ScheduleFrequencyType.Never) {
            return null;
        }

        Timestamp next = null;

        Timestamp now = new Timestamp(System.currentTimeMillis() / (60 * 1000));
        Timestamp start = schedule.getStartOn();
        Timestamp end = schedule.getEndOn();
        Timestamp last = schedule.getLastExecutedOn();
        Timestamp savedNextRun = schedule.getNextRunOn();
        int frequency = schedule.getFrequency();

        logger.debug("Now  : " + now);
        logger.debug("Start: " + start);
        logger.debug("End  : " + end);
        logger.debug("Last : " + last);
        logger.debug("Next run: " + savedNextRun);

        if (last == null || start.after(last)) {
            last = start;
        }

        /* If current time is after end time, we'll return null */
        if (now.after(end)) {

            logger.debug("End date has passed.");

        } else if (now.before(start)) {
            /* no need to set next if we haven't started */
            logger.debug("Start date is in the future.");
            next = start;
            return next;
        } else if (schedule.getFrequencyType().equals(
                ScheduleFrequencyType.Once)) {

            logger.debug("Run-once schedule, next run is: " + next);

        } else {
            /* it's time for either the first or a subsequent run */
            next = add(last, schedule.getFrequencyType(), frequency);
            if (next != null && next.before(now)) {
                next = add(now, schedule.getFrequencyType(), frequency);
            }
        }

        if (null != next && next.after(end)) {

            logger.debug("Next run " + next
                    + " would be after the schedule's end time " + end
                    + ", returning null");
            next = null;
        }

        return next;

    }

    private static Timestamp add(Timestamp last, ScheduleFrequencyType type, int frequency) {
        Timestamp next = null;
        switch (type) {
            case Minutes:
                next = new Timestamp(DateUtil.getNextNMinute(last, frequency).getTime());

                logger.debug("Added " + frequency + " minute(s), next run is: " + next);
                break;

            case Hours:
                next = new Timestamp(DateUtil.getNextNHour(last, frequency).getTime());

                logger.debug("Added " + frequency + " hour(s), next run is: " + next);
                break;
            case Days:
                next = new Timestamp(DateUtil.getNextNDay(last, frequency).getTime());

                logger.debug("Added " + frequency + " day(s), next run is: " + next);
                break;

            case Weeks:
                next = new Timestamp(DateUtil.getNextNWeek(last, frequency).getTime());

                logger.debug("Added " + frequency + " day(s), next run is: " + next);
                break;

            case Months:
                next = new Timestamp(DateUtil.getNextNMonth(last, frequency).getTime());

                logger.debug("Added " + frequency + " month(s), next run is: " + next);
                break;
            case Weekdays:
                next = DateUtil.getNextWeekday(last);

                logger.debug("Added " + frequency + " weekdays, next run is: " + next);
                break;
            default:

        }
        return next;
    }

}

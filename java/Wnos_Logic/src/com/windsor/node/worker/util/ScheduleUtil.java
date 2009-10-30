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

import java.sql.Timestamp;

import org.apache.log4j.Logger;

import com.windsor.node.common.domain.ScheduleFrequencyType;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.util.DateUtil;

/**
 *
 */
public final class ScheduleUtil {

    private static Logger logger = Logger.getLogger(ScheduleUtil.class);

    private ScheduleUtil() {

    }

    /**
     * Given a populated Schedule, determine the next execution time.
     * 
     * @param schedule
     * @return Timestamp for the next run, possibly null
     */
    public static Timestamp calculateNextRun(ScheduledItem schedule) {

        Timestamp next = null;

        Timestamp now = DateUtil.getTimestamp();
        Timestamp start = schedule.getStartOn();
        Timestamp end = schedule.getEndOn();
        Timestamp last = schedule.getLastExecutedOn();
        Timestamp savedNextRun = schedule.getNextRunOn();
        int frequency = schedule.getFrequency();

        logger.debug("Now  : " + now);
        logger.debug("Start: " + start);
        logger.debug("End  : " + end);
        logger.debug("Last : " + last);
        logger.debug("Next : " + savedNextRun);

        if (now.before(start) || now.after(end)) {

            logger
                    .debug("Current time is outside of the start/end window, next run is: "
                            + next);

        } else if (schedule.getFrequencyType().equals(
                ScheduleFrequencyType.ONCE)) {

            logger.debug("Run-once schedule, next run is: " + next);

        } else {

            if (last == null || now.after(savedNextRun)) {
                last = now;
            }

            if (schedule.getFrequencyType()
                    .equals(ScheduleFrequencyType.MINUTE)) {

                next = new Timestamp(DateUtil.getNextNMinute(last, frequency)
                        .getTime());

                logger.debug("Added " + frequency + " minute(s), next run is: "
                        + next);

            } else if (schedule.getFrequencyType().equals(
                    ScheduleFrequencyType.HOUR)) {

                next = new Timestamp(DateUtil.getNextNHour(last, frequency)
                        .getTime());

                logger.debug("Added " + frequency + " hour(s), next run is: "
                        + next);

            } else if (schedule.getFrequencyType().equals(
                    ScheduleFrequencyType.DAY)) {

                next = new Timestamp(DateUtil.getNextNDay(last, frequency)
                        .getTime());

                logger.debug("Added " + frequency + " day(s), next run is: "
                        + next);

            } else if (schedule.getFrequencyType().equals(
                    ScheduleFrequencyType.WEEK)) {

                next = new Timestamp(DateUtil.getNextNDay(last,
                        frequency * DateUtil.DAYS_PER_WEEK).getTime());

                logger.debug("Added " + frequency + " week(s), next run is: "
                        + next);

            } else if (schedule.getFrequencyType().equals(
                    ScheduleFrequencyType.MONTH)) {

                next = new Timestamp(DateUtil.getNextNMonth(last, frequency)
                        .getTime());

                logger.debug("Added " + frequency + " month(s), next run is: "
                        + next);

            }
        }

        if (null != next && next.after(end)) {

            next = null;
            logger.debug("Next run " + next
                    + " would be after the schedule's end time " + end);
        }

        return next;

    }

}

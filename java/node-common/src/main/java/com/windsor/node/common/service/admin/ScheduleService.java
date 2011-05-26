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

package com.windsor.node.common.service.admin;

import java.util.List;

import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduledItem;

/**
 * 
 * @author mchmarny
 * 
 */
public interface ScheduleService {
    /**
     * Save a Schedule to the database.
     * 
     * @param instance
     *            the ScheduledItem to save
     * @param visit
     *            authenticated NodeVisit
     * @return the saved ScheduledItem
     */
    ScheduledItem save(ScheduledItem instance, NodeVisit visit);

    /**
     * Get a Schedule from the database by id.
     * 
     * @param scheduleId
     * @param visit
     *            authenticated NodeVisit
     * @return the saved ScheduledItem
     */
    ScheduledItem get(String scheduleId, NodeVisit visit);

    /**
     * Delete a Schedule from the database by id.
     * 
     * @param scheduleId
     * @param visit
     *            authenticated NodeVisit
     */
    void delete(String scheduleId, NodeVisit visit);

    /**
     * Get the list of all Schedules in the database.
     * 
     * @param visit
     *            authenticated NodeVisit
     * @return a List of ScheduledItems
     */
    List<ScheduledItem> get(NodeVisit visit);

    /**
     * Save a Schedule and flag it for running the next time the scheduler polls
     * the database.
     * 
     * @param instance
     *            the ScheduledItem to save
     * @param visit
     *            authenticated NodeVisit
     */
    void saveAndRunNow(ScheduledItem instance, NodeVisit visit);

}
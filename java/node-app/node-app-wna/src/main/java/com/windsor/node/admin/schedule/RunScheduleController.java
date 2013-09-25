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
package com.windsor.node.admin.schedule;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import net.sf.json.JSONObject;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import com.windsor.node.admin.ajax.JsonAjaxController;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.service.admin.ScheduleService;
import com.windsor.node.worker.schedule.ScheduleItemExecutionService;

/**
 * Allows an AJAX call to run a schedule immediately.
 * @author tmurdock
 */
public class RunScheduleController extends JsonAjaxController
{
    protected Logger logger = LoggerFactory.getLogger(RunScheduleController.class);
    private ScheduleItemExecutionService executionService;
    private ScheduleService scheduleService;

    @Override
    protected Object getOutput(HttpServletRequest request, HttpServletResponse response)
    {
        String scheduleId = request.getParameter("id");
        String run = request.getParameter("run");
        ScheduledItem schedule = null;
        NodeVisit visit = VisitUtils.getVisit(request);
        if(StringUtils.isNotBlank(scheduleId))
        {
            schedule = getScheduleService().get(scheduleId, visit);
            if("true".equalsIgnoreCase(run))
            {//only run if the extra run=param is passed, otherwise just return the schedule executeStatus
                getExecutionService().run(schedule);
            }
            schedule = getScheduleService().get(scheduleId, visit);
        }
        if(schedule == null)
        {
            logger.warn("Could not lookup ScheduledItem for id " + scheduleId + ".  Schedule cannot be run.");
            JSONObject error = new JSONObject();
            error.put("error", "Schedule does not exist.");
            return error;
        }
        JSONObject json = new JSONObject();
        json.put("status", schedule.getExecuteStatus().name());
        json.put("lastRunInfo", schedule.getLastExecutionInfo());
        if(schedule.getLastExecutedOn() != null)
        {
            json.put("lastExecutedOn", schedule.getLastExecutedOn().toString());
        }
        else
        {
            json.put("lastExecutedOn", "");
        }
        if(schedule.getLastExecutionActivity() != null && schedule.getLastExecutionActivity().getTransactionId() != null)
        {
            json.put("lastExecutionTransactionId", schedule.getLastExecutionActivity().getTransactionId());
        }
        else
        {
            json.put("lastExecutionTransactionId", "");
        }
        return json;
    }

    public ScheduleItemExecutionService getExecutionService()
    {
        return executionService;
    }

    public void setExecutionService(ScheduleItemExecutionService executionService)
    {
        this.executionService = executionService;
    }

    public ScheduleService getScheduleService()
    {
        return scheduleService;
    }

    public void setScheduleService(ScheduleService scheduleService)
    {
        this.scheduleService = scheduleService;
    }
}

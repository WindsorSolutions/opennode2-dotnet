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

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.common.service.admin.ScheduleService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class ArgumentsByServiceController extends AbstractController implements InitializingBean
{
    private FlowService flowService;
    private ScheduleService scheduleService;

    @Override
    protected ModelAndView handleRequestInternal(HttpServletRequest request, HttpServletResponse response)
                    throws Exception
    {
        Map<String, Object> model = new HashMap<String, Object>();
        NodeVisit visit = VisitUtils.getVisit(request);
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SCHEDULE);

        String flowId = ServletRequestUtils.getStringParameter(request, "flowId");
        String serviceId = ServletRequestUtils.getStringParameter(request, "serviceId");
        String scheduleId = ServletRequestUtils.getStringParameter(request, "scheduleId");
        if(StringUtils.isNotBlank(flowId) && StringUtils.isNotBlank(serviceId))
        {
            ScheduledItem schedule = null;
            if(StringUtils.isNotBlank(scheduleId))
            {
                schedule = scheduleService.get(scheduleId, visit);
            }
    
            DataFlow dataFlow = getFlowService().getDataFlow(flowId, visit);
            DataService service = null;
            for(int i = 0; i < dataFlow.getServices().size(); i++)
            {
                if(serviceId.equals(dataFlow.getServices().get(i).getId()))
                {
                    service = dataFlow.getServices().get(i);
                }
            }
            if(service != null)
            {
                @SuppressWarnings("unchecked")
                List<PluginServiceParameterDescriptor> params = (List<PluginServiceParameterDescriptor>)getFlowService().getPluginParameterDescriptors(dataFlow, service);
                if(schedule != null)
                {
                    model.put("parameterValues", schedule.getScheduleArguments());
                }
                if(params != null)
                {
                    model.put("parameterDescriptors", params);
                }
                else
                {
                    //default to legacy
                    return new ModelAndView("arg-list-legacy", AdminConstants.MODEL_KEY, model);
                }
            }
        }
        return new ModelAndView("arg-list", AdminConstants.MODEL_KEY, model);
    }

    public void afterPropertiesSet() throws Exception
    {
        if(getFlowService() == null)
        {
            throw new Exception("ArgumentsByServiceController: flowService not set");
        }
    }

    public FlowService getFlowService()
    {
        return flowService;
    }

    public void setFlowService(FlowService flowService)
    {
        this.flowService = flowService;
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

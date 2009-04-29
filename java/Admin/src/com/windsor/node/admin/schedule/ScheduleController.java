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
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

import com.windsor.node.admin.editor.CustomTimestampEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.QueryStringUtils;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ScheduleService;

/**
 * 
 * @author Mark Chmarny
 * 
 *         TODO: need better javadocs
 */
public class ScheduleController extends AbstractController implements
        InitializingBean {

    protected Logger logger = Logger
            .getLogger(ScheduleController.class);

    private ScheduleService scheduleService;
    private String listView;

    public ScheduleController() {
        setListView("schedule");
    }

    public void afterPropertiesSet() throws Exception {

        if (scheduleService == null) {
            throw new Exception("scheduleService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        CustomTimestampEditor timestampEditor = new CustomTimestampEditor(
                getMessageSourceAccessor().getMessage(AdminConstants.SCHEDULE_DATETIME_FORMAT_KEY,
                        AdminConstants.DATETIME_FORMAT));

        binder.registerCustomEditor(java.sql.Timestamp.class, timestampEditor);

    }

    /**
     * Sets some values into the model and view
     */
    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_CONFIG);
            return VisitUtils.getUnauthedView(request);
        }

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SCHEDULE);

        Integer viewIndex = QueryStringUtils.getBarIndex(request);

        // Defaults page view to 0
        model.put(AdminConstants.VIEW_INDEX_KEY, viewIndex);

        model.put("schedules", getScheduleService().get(visit));

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getScheduleBars(request, 0));

        return new ModelAndView(getListView(), AdminConstants.MODEL_KEY,
                model);

    }

    public ScheduleService getScheduleService() {
        return scheduleService;
    }

    public void setScheduleService(ScheduleService scheduleService) {
        this.scheduleService = scheduleService;
    }

    public String getListView() {
        return listView;
    }

    public void setListView(String listView) {
        this.listView = listView;
    }

}
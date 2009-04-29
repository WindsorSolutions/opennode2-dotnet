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

package com.windsor.node.admin;

import java.util.Hashtable;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

import com.windsor.node.admin.editor.CustomTimestampEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ActivityService;

public class DataQueryController extends AbstractController implements
        InitializingBean {

    protected Logger logger = Logger
            .getLogger(DataQueryController.class);

    private ActivityService activityService;

    public void afterPropertiesSet() throws Exception {

        if (activityService == null) {
            throw new Exception("activityService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        CustomTimestampEditor timestampEditor = new CustomTimestampEditor(
                getMessageSourceAccessor().getMessage(AdminConstants.SCHEDULE_DATETIME_FORMAT_KEY,
                        AdminConstants.DATETIME_FORMAT));

        binder.registerCustomEditor(java.sql.Timestamp.class, timestampEditor);

    }

    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_CONFIG);
            return VisitUtils.getUnauthedView(request);
        }

        String cmd = ServletRequestUtils.getRequiredStringParameter(request,
                "cmd");
        String id = ServletRequestUtils.getRequiredStringParameter(request,
                "id");

        if (StringUtils.isBlank(cmd) || StringUtils.isBlank(id)) {
            logger.error("cmd: " + cmd);
            logger.error("id: " + cmd);
            throw new IllegalArgumentException(
                    "Required arguments not provided.");
        }

        Map model = new Hashtable();

        model.put("activityList", activityService.getActivityDetail(id, visit)
                .getEntries());

        model.put("cmd", cmd);

        return new ModelAndView("data", AdminConstants.MODEL_KEY, model);

    }

    public void setActivityService(ActivityService activityService) {
        this.activityService = activityService;
    }

}
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

package com.windsor.node.admin.config;

import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.QueryStringUtils;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ConfigService;
import com.windsor.node.common.service.admin.PartnerService;

public class ConfigController extends AbstractController implements
        InitializingBean {

    protected Logger logger = LoggerFactory
            .getLogger(ConfigController.class);

    private ConfigService configService;
    private PartnerService partnerService;

    public void afterPropertiesSet() throws Exception {

        if (configService == null) {
            throw new Exception("configService not set");
        }

        if (partnerService == null) {
            throw new Exception("partnerService not set");
        }

    }

    @SuppressWarnings({"rawtypes", "unchecked"})
    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        logger.debug("ConfigController.handleRequestInternal:");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug("Redirecting unauthed request");
            return VisitUtils.getUnauthedView(request);
        }

        logger.debug("Handling authorized request.");
        logger.debug("Visit: " + visit);

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_CONFIG);

        Integer viewIndex = QueryStringUtils.getBarIndex(request);
        logger.debug("viewIndex: " + viewIndex);

        // Defaults page view to 0
        model.put(AdminConstants.VIEW_INDEX_KEY, viewIndex);

        if (viewIndex.intValue() == 1) {
            // Data sources
            model.put("conns", configService.getDataProviders(visit));
        } else if (viewIndex.intValue() == 2) {
            // Partners
            model.put("partners", partnerService.get(visit));
        } else {
            // Config
            model.put("args", configService.getList(visit));
        }

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getConfigBars(request, 0));

        return new ModelAndView("config", AdminConstants.MODEL_KEY, model);

    }

    public void setConfigService(ConfigService configService) {
        this.configService = configService;
    }

    public void setPartnerService(PartnerService partnerService) {
        this.partnerService = partnerService;
    }

}

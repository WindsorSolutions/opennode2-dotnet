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

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.slf4j.LoggerFactory;

import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.ConfigItem;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ConfigService;

public class ConfigArgController extends BaseSimpleFormController implements
        Controller, InitializingBean {

    private static final String UNAUTHED_CONFIG = AdminConstants.UNAUTHED_CONFIG;
    private ConfigService configService;

    public ConfigArgController() {
        super();
        logger = LoggerFactory.getLogger(ConfigArgController.class);
        setCommandClass(ConfigItem.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (configService == null) {
            throw new Exception("ConfigArgController: configService not set");
        }

    }

    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        logger.debug(AdminConstants.SUBMITTING + command);

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED + " config arg "
                    + AdminConstants.ACCESS_REQUEST);
            return VisitUtils.getUnauthedView(request);
        }

        ConfigItem config = (ConfigItem) command;

        ModelAndView view = null;

        try {

            logger.debug("Config item: " + config);

            if (StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(
                    request, "delete"))) {

                logger.debug("Deleting: " + config);
                configService.delete(config.getId(), visit);

            } else {

                logger.debug(AdminConstants.SAVING + config.getId());

                configService.save(config, visit);
            }

            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);

            view = new ModelAndView(new RedirectView(getSuccessView()));

        } catch (Exception ex) {

            logger.error(ex.toString(), ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            config.setId(null);

            request.setAttribute(AdminConstants.COMMAND_KEY, config);

            view = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY,
                    getReferenceData(request, visit));

        }

        return view;

    }

    @SuppressWarnings({"rawtypes", "unchecked"})
    protected Map getReferenceData(HttpServletRequest request, NodeVisit visit) {

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_CONFIG);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getConfigBars(request,
                0));

        return model;

    }

    @SuppressWarnings({"rawtypes", "unchecked"})
    protected Map referenceData(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        Map modelHolder = null;

        if (visit == null) {
            logger.debug(UNAUTHED_CONFIG);
        } else {

            modelHolder = new HashMap();
            modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request,
                    visit));
        }

        return modelHolder;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {

        NodeVisit visit = VisitUtils.getVisit(request);

        Object o;

        if (visit == null) {
            logger.debug(UNAUTHED_CONFIG);
            o = VisitUtils.getUnauthedView(request);

        } else {

            String id = ServletRequestUtils.getStringParameter(request, "id");
            logger.debug("formBackingObject id: " + id);

            if (StringUtils.isNotBlank(id)) {
                logger.debug("Getting item: " + id);
                o = configService.get(id, visit);
            } else {
                logger.debug("Getting new item");
                o = new ConfigItem();
            }
        }
        return o;
    }

    public void setConfigService(ConfigService configService) {
        this.configService = configService;
    }

}

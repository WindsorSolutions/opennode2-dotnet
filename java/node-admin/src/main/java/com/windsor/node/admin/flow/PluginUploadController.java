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

package com.windsor.node.admin.flow;

import java.util.HashMap;
import java.util.Map;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.multipart.MultipartHttpServletRequest;
import org.springframework.web.multipart.commons.CommonsMultipartFile;
import org.springframework.web.multipart.support.ByteArrayMultipartFileEditor;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.domain.PluginUploadRequest;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.common.service.admin.PluginAdminService;

public class PluginUploadController extends BaseSimpleFormController implements
        Controller, InitializingBean {

    private FlowService flowService;
    private PluginAdminService pluginAdminService;

    public PluginUploadController() {
        super();
        logger = LoggerFactory.getLogger(PluginUploadController.class);
        setCommandClass(PluginUploadRequest.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (flowService == null) {
            throw new Exception("PluginUploadController: flowService not set");
        }

        if (pluginAdminService == null) {
            throw new Exception(
                    "PluginUploadController: pluginAdminService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(byte[].class,
                new ByteArrayMultipartFileEditor());

    }

    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        logger.debug("HandleRequestInternal");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED + AdminConstants.FLOW + AdminConstants.ACCESS_REQUEST);
            return VisitUtils.getUnauthedView(request);
        }

        Map model = getReferenceData(request, visit);
        ModelAndView mav;

        if (!isFormSubmission(request)) {

            logger.debug("Displaying form");
            model = getReferenceData(request, visit);
            mav = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY, model);

        } else {

            logger.debug("Submitting form");

            try {

                logger
                        .debug("Checking if the request is MultipartHttpServletRequest");

                if (!(request instanceof MultipartHttpServletRequest)) {
                    throw new IllegalArgumentException("No upload");
                }

                logger
                        .debug("casting request into MultipartHttpServletRequest");

                MultipartHttpServletRequest multiRequest = (MultipartHttpServletRequest) request;

                logger.debug("getting hold of CommonsMultipartFile");

                CommonsMultipartFile file = (CommonsMultipartFile) multiRequest
                        .getFile("file");

                if (StringUtils.isBlank(file.getOriginalFilename())) {
                    throw new IllegalArgumentException(
                            "Please select a file for uploading.");
                }

                logger.debug("file: " + file.getOriginalFilename());

                if (file.isEmpty()) {
                    throw new IllegalArgumentException(
                            "The file appears to be empty.");
                }

                if (!FilenameUtils.getExtension(file.getOriginalFilename())
                        .equalsIgnoreCase("zip")) {

                    throw new RuntimeException(
                            "Please compress (zip) the plugin prior to uploading.");
                }

                String flowId = ServletRequestUtils.getStringParameter(request,
                        "flowId");

                if (StringUtils.isBlank(flowId)) {
                    throw new IllegalArgumentException(
                            "Please select an Exchange.");
                }

                pluginAdminService.upload(flowId, file.getBytes(), visit);

                logger.debug("File uploaded successfully");

                mav = new ModelAndView(getSuccessView());

            } catch (Exception ex) {

                logger.error(ex.getMessage(), ex);

                request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

                logger.debug("Form view: " + getFormView());

                mav = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY, model);
            }
        }

        logger.debug("returning ModelAndView: " + mav);
        return mav;

    }

    protected Map getReferenceData(HttpServletRequest request, NodeVisit visit) {

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_EXCHANGE);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getExchangeBars(request, 1));

        // set flows
        model.put("flows", flowService.getFlows(visit, false));

        return model;

    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map modelHolder = new HashMap();
        modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request, visit));
        return modelHolder;

    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

    public void setPluginAdminService(PluginAdminService pluginManagerService) {
        this.pluginAdminService = pluginManagerService;
    }

}

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

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.view.RedirectView;
import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.domain.DataServiceForm;
import com.windsor.node.admin.editor.ServiceRequestAuthorizationTypeEditor;
import com.windsor.node.admin.editor.ServiceTypeEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.service.admin.ConfigService;
import com.windsor.node.common.service.admin.FlowService;

public class EditServiceController extends BaseSimpleFormController implements
        Controller, InitializingBean {

    private FlowService flowService;
    private ConfigService configService;

    public EditServiceController() {
        super();
        logger = LoggerFactory.getLogger(EditServiceController.class);
        setCommandClass(DataServiceForm.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (flowService == null) {
            throw new Exception("EditServiceController: flowService not set");
        }

        if (configService == null) {
            throw new Exception("EditServiceController: configService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(ServiceType.class, new ServiceTypeEditor());

        binder.registerCustomEditor(ServiceRequestAuthorizationType.class,
                new ServiceRequestAuthorizationTypeEditor());

    }

    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        logger.debug("Submitting with command object: " + command);

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        DataServiceForm serviceForm = (DataServiceForm) command;
        logger.debug("ServiceForm: " + serviceForm);

        ModelAndView view = null;

        try {
            // DELETE BUTTON
            if (StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(
                    request, "delete"))) {

                logger.debug("Deleting: " + serviceForm);
                flowService.deleteDataService(serviceForm.getService().getId(),
                        visit);
                view = new ModelAndView(new RedirectView("flow.htm"));

            } else {

                logger.debug("Saving service with id: "
                        + serviceForm.getService().getId());
                serviceForm.setService(flowService.saveDataService(serviceForm
                        .getService(), visit));

                // NEXT BUTTON
                if (StringUtils.isNotBlank(ServletRequestUtils
                        .getStringParameter(request, "next"))) {

                    view = new ModelAndView(new RedirectView(
                            "service-edit.htm?new=true&id="
                                    + serviceForm.getService().getId()));
                    logger.debug("Returning service-edit view: " + view);

                } else {
                    // SAVE BUTTON
                    view = new ModelAndView(new RedirectView(getSuccessView()));
                    logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);
                }

            }

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            request.setAttribute(AdminConstants.COMMAND_KEY, serviceForm);

            view = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY, getReferenceData(
                    request, visit));
            logger.debug("Returning form view: " + view);

        }

        return view;

    }

    protected Map getReferenceData(HttpServletRequest request, NodeVisit visit)
    {
        Map<String, Object> model = new HashMap<String, Object>();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_EXCHANGE);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getExchangeBars(request, 0));

        // set service types
        model.put("authLevels", new ArrayList<ServiceRequestAuthorizationType>(Arrays.asList(ServiceRequestAuthorizationType.values())));

        // set service types
        model.put("sysConnections", configService.getDataProviders(visit));

        // set service types
        model.put("globalArgs", configService.getList(visit));

        return model;
    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        logger.debug("referenceData()");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map modelHolder = new HashMap();
        modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request, visit));
        String serviceId = request.getParameter("id");
        String flowId = request.getParameter("fid");
        if(StringUtils.isBlank(flowId) && StringUtils.isNotBlank(serviceId))
        {
            DataService service = flowService.getService(serviceId, visit);
            flowId = service.getFlowId();
        }
        if(StringUtils.isNotBlank(flowId))
        {
            DataFlow dataFlow = flowService.getDataFlow(flowId, visit);
            modelHolder.put("pluginServiceImplementorDescriptors", getPluginServiceImplementorDescriptors(dataFlow));
        }
        return modelHolder;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {

        logger.debug("formBackingObject()");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        // the ui sends EITHER the serviceId OR the flowId in the query string
        String serviceId = ServletRequestUtils
                .getStringParameter(request, "id");
        logger.debug("serviceId from request: " + serviceId);

        String flowId = ServletRequestUtils.getStringParameter(request, "fid");
        logger.debug("flowId from request: " + flowId);
        

        if (StringUtils.isBlank(flowId) && StringUtils.isBlank(serviceId))
        {
            throw new IllegalArgumentException("Either flowId or serviceId must be present in request");
        }

        DataServiceForm serviceForm = new DataServiceForm();
        DataService service = null;
        DataFlow dataFlow = null;

        try {
            if (StringUtils.isNotBlank(serviceId)) {

                logger.debug("Getting DataService with id " + serviceId
                        + " from request");
                service = flowService.getService(serviceId, visit);
                dataFlow = flowService.getDataFlow(service.getFlowId(), visit);

                if (ServletRequestUtils.getStringParameter(request, "new") != null) {
                    logger.debug("New service, defaulting to isActive=true");
                    service.setActive(true);
                }

            } else {
                dataFlow = flowService.getDataFlow(flowId, visit);
                logger.debug("creating new DataService");
                service = new DataService();
                service.setFlowId(flowId);
            }

            logger.debug("adding DataService to DataServiceForm");
            serviceForm.setService(service);

            logger.debug("adding Implementer list to DataServiceForm");
            serviceForm.setImplementers(getImplementers(dataFlow, visit));

            logger.debug("adding Flow/Exchange Name list to DataServiceForm");
            serviceForm.setFlowName(dataFlow.getName());

            logger.debug("serviceForm: " + serviceForm);

        }
        catch (Exception ex)
        {
            logger.error(ex.getMessage(), ex);
            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());
        }
        return serviceForm;
    }

    private List<String> getImplementers(DataFlow dataFlow, NodeVisit visit) {

        logger.debug("Getting implementers for: " + dataFlow.getId());

        List<String> implementers = flowService.getFlowPluginImplementors(dataFlow.getId(), visit);

        logger.debug(AdminConstants.FOUND + implementers.size());
        logger.debug("Implementer list: " + implementers);

        return implementers;
    }

    private List<PluginServiceImplementorDescriptor> getPluginServiceImplementorDescriptors(DataFlow dataFlow)
    {
        List<PluginServiceImplementorDescriptor> descriptors = flowService.getPluginServiceImplementorDescriptors(dataFlow);
        return descriptors;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

    public void setConfigService(ConfigService configService) {
        this.configService = configService;
    }

}

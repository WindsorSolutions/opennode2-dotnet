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

import java.util.EnumSet;
import java.util.HashMap;
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
import com.windsor.node.admin.editor.EndpointVersionTypeEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.service.admin.PartnerService;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.client.NodeClientFactory;

/**
 * Controller for the Partner (Endpoint) configuration screen in the admin tool.
 */
public class ConfigPartnerController extends BaseSimpleFormController implements Controller, InitializingBean
{

    private PartnerService partnerService;
    private NodeClientFactory nodeClientFactory;

    public ConfigPartnerController()
    {
        super();
        logger = LoggerFactory.getLogger(ConfigPartnerController.class);
        setCommandClass(PartnerIdentity.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception
    {
        if(partnerService == null)
        {
            throw new Exception("ConfigPartnerController: partnerService not set");
        }
    }

    protected void initBinder(HttpServletRequest request, ServletRequestDataBinder binder) throws Exception
    {
        binder.registerCustomEditor(EndpointVersionType.class, new EndpointVersionTypeEditor());
    }

    protected ModelAndView onSubmit(HttpServletRequest request, HttpServletResponse response, Object command,
                    BindException errors) throws Exception
    {
        logger.debug(AdminConstants.SUBMITTING + command);
        NodeVisit visit = VisitUtils.getVisit(request);
        if(visit == null)
        {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }
        PartnerIdentity partner = (PartnerIdentity)command;
        ModelAndView view = null;
        try
        {
            logger.debug("Config item: " + partner);
            if(StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(request, "delete")))
            {
                logger.debug("Deleting: " + partner);
                partnerService.delete(partner.getId(), visit);
            }
            else if(StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(request, "check")))
            {
                logger.debug("Checking the connection: " + partner);
                //EN11 or EN2.0
                NodeClientService nodeClientService = nodeClientFactory.makeAndConfigure(partner);
                String result = "No Result";
                try
                {
                    result = nodeClientService.nodePing("Ping");
                }
                catch(Exception e)
                {
                    //whatever the exception we want a nice message indicating that the node could not be contacted
                    result = "error";
                    logger.info("NodePing failed with:  " + e.getMessage());
                }
                logger.debug("Node Ping result was \"" + result + "\".");
                ModelAndView formView = showForm(request, response, errors);
                if("error".equalsIgnoreCase(result))
                {
                    formView.addObject("error", "There was an error contacting the node endpoint, please check the configuration.");
                }
                else
                {
                    formView.addObject("pingResult", "Node Ping result was \"" + result + "\".");
                }
                return formView;
            }
            else
            {
                logger.debug(AdminConstants.SAVING + partner);
                partnerService.save(partner, visit);
            }
            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);
            view = new ModelAndView(new RedirectView(getSuccessView()));

        }
        catch(Exception ex)
        {
            logger.error(ex.toString(), ex);
            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());
            request.setAttribute(AdminConstants.COMMAND_KEY, partner);
            view = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY, getReferenceData(request, visit));
        }
        return view;
    }

    protected Map<String, Object> getReferenceData(HttpServletRequest request, NodeVisit visit)
    {
        Map<String, Object> model = new HashMap<String, Object>();
        model.put(AdminConstants.VISIT_KEY, visit);
        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_CONFIG);
        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getConfigBars(request, 2));
        // set endpointVersions
        model.put("endpointVersions", EnumSet.allOf(EndpointVersionType.class));
        return model;
    }

    protected Map<String, Object> referenceData(HttpServletRequest request) throws Exception
    {
        NodeVisit visit = VisitUtils.getVisit(request);
        if(visit == null)
        {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map<String, Object> modelHolder = new HashMap<String, Object>();
        modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request, visit));
        return modelHolder;
    }

    protected Object formBackingObject(HttpServletRequest request) throws ServletException
    {
        NodeVisit visit = VisitUtils.getVisit(request);
        Object o;
        if(visit == null)
        {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            o = VisitUtils.getUnauthedView(request);
        }
        else
        {
            String id = ServletRequestUtils.getStringParameter(request, "id");
            logger.debug("formBackingObject id: " + id);
            if(StringUtils.isNotBlank(id))
            {
                logger.debug("Getting item: " + id);
                o = partnerService.get(id, visit);
            }
            else
            {
                logger.debug("Getting new item");
                o = new PartnerIdentity();
            }
        }
        return o;
    }

    public void setPartnerService(PartnerService partnerService)
    {
        this.partnerService = partnerService;
    }

    public PartnerService getPartnerService()
    {
        return partnerService;
    }

    public NodeClientFactory getNodeClientFactory()
    {
        return nodeClientFactory;
    }

    public void setNodeClientFactory(NodeClientFactory nodeClientFactory)
    {
        this.nodeClientFactory = nodeClientFactory;
    }
}

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

import java.sql.Connection;
import java.sql.DriverManager;
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
import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ConfigService;

public class ConfigConnController extends BaseSimpleFormController implements Controller, InitializingBean
{

    private ConfigService configService;

    public ConfigConnController()
    {
        super();
        logger = LoggerFactory.getLogger(ConfigConnController.class);
        setCommandClass(DataProviderInfo.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception
    {
        if(configService == null)
        {
            throw new Exception("ConfigConnController: PluginManagerService not set");
        }
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

        DataProviderInfo conn = (DataProviderInfo)command;
        ModelAndView view = null;

        try
        {
            logger.debug("Config item: " + conn);
            conn.setModifiedById(visit.getUserAccount().getId());

            if(StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(request, "delete")))
            {
                logger.debug("Deleting data source with id: " + conn.getId());
                configService.deleteDataProvider(conn.getId(), visit);
            }
            else if(StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(request, "check")))
            {
                Connection connection = null;
                boolean success = false;
                try
                {
                    logger.debug("Checking connection id: " + conn.getId());
                    Class.forName(conn.getProviderType());
                    connection = DriverManager.getConnection(conn.getConnectionString());
                    success = true;
                }
                catch(Exception e)
                {
                    //on any error consider it a failure
                    logger.info("Connection creation failed during the check JDBC connection test for \"" 
                                + ((conn != null ) ? conn.getConnectionString(): "") + "\".", e);
                    //success is already false
                }
                finally
                {
                    if(connection != null)
                    {
                        try
                        {
                            connection.close();
                        }
                        catch (Exception e)
                        {
                            //Only log, we should have logged an error by this point if the connection is invalid
                            logger.warn("Failure closing the connection during the check JDBC connection test.", e);
                        }
                    }
                }
                ModelAndView formView = showForm(request, response, errors);
                if(success)
                {
                    formView.addObject("connectionMessage", "JDBC connection succeeded.");
                }
                else
                {
                    formView.addObject("error", "There was an error making the JDBC connection, please check the configuration.");
                }
                return formView;
            }
            else
            {
                logger.debug("Saving data source: " + conn);
                configService.saveDataProvider(conn, visit);
            }
            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);
            view = new ModelAndView(new RedirectView(getSuccessView()));
        }
        catch(Exception ex)
        {
            logger.error(ex.toString(), ex);
            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());
            conn.setId(null);
            request.setAttribute(AdminConstants.COMMAND_KEY, conn);
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
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getConfigBars(request, 1));
        return model;
    }

    protected Map<String, Object> referenceData(HttpServletRequest request) throws Exception
    {
        NodeVisit visit = VisitUtils.getVisit(request);
        Map<String, Object> modelHolder = null;
        if(visit == null)
        {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
        }
        else
        {
            modelHolder = new HashMap<String, Object>();
            modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request, visit));
        }
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
                o = configService.getDataProvider(id, visit);
            }
            else
            {
                logger.debug("Getting new item");
                o = new DataProviderInfo();
            }
        }
        return o;
    }

    public void setConfigService(ConfigService configService)
    {
        this.configService = configService;
    }
}
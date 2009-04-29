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

import java.util.Enumeration;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.mvc.SimpleFormController;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.AuthenticationRequest;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.AccountService;

public class AuthController extends SimpleFormController implements Controller,
        InitializingBean {

    private static final String HTTP_HEADER_FORWARD_FOR = "X-Forward-For";
    
    protected Logger logger = Logger.getLogger(AuthController.class);

    private AccountService accountService;
    private String headerIpKey;

    public AuthController() {
        setSessionForm(true);
        setCommandClass(AuthenticationRequest.class);
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("AuthController: accountService not set");
        }

    }

    private String getClientHost(HttpServletRequest request) {

        String clientHost = null;

        if (StringUtils.isBlank(headerIpKey)) {

            clientHost = request.getRemoteAddr();
            logger.debug("RemoteAddr: " + clientHost);

            Enumeration hdEnum = request.getHeaderNames();

            while (hdEnum.hasMoreElements()) {

                String hdKey = (String) hdEnum.nextElement();
                if (StringUtils.isNotBlank(hdKey)
                        && hdKey.equalsIgnoreCase(HTTP_HEADER_FORWARD_FOR)) {
                    clientHost = request.getHeader(hdKey);
                    logger.debug(HTTP_HEADER_FORWARD_FOR + AdminConstants.COLON + clientHost);
                }
            }

        } else {
            clientHost = request.getHeader(headerIpKey);
            logger.debug(headerIpKey + AdminConstants.COLON + clientHost);
        }

        logger.debug("[host]: " + clientHost);

        return clientHost;
    }

    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        logger.debug("AuthenticationRequest: " + command);

        AuthenticationRequest credential = (AuthenticationRequest) command;
        credential.setIp(getClientHost(request));

        ModelAndView view = null;

        try {

            NodeVisit visit = accountService.adminAuthenticate(credential);

            logger.debug("Auth response: " + visit);

            VisitUtils.setVisit(request, visit);

            String returnUrl = ServletRequestUtils.getStringParameter(request,
                    "ru");
            logger.debug("Auth returnUrl: " + returnUrl);

            if (StringUtils.isBlank(returnUrl)) {
                logger.debug("redirecting to successView: " + getSuccessView());
                view = new ModelAndView(new RedirectView(getSuccessView()));
            } else {
                view = new ModelAndView(new RedirectView(returnUrl));
            }

        } catch (Exception ex) {

            view = new ModelAndView(getFormView());

            logger.error(ex);

            request.setAttribute(AdminConstants.COMMAND_KEY, command);
            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());
        }

        return view;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {
        return new AuthenticationRequest();
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public void setHeaderIpKey(String headerIpKey) {
        this.headerIpKey = headerIpKey;
    }

}
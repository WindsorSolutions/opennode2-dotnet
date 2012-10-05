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

package com.windsor.node.admin.security;

import java.sql.Timestamp;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.admin.editor.CustomTimestampEditor;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowSecurityService;

/**
 * Handles submissions from authrequest-manage.jsp.
 * 
 */
public class AuthRequestFormController extends BaseSecurityFormController
        implements InitializingBean {

    private AccountService accountService;
    private FlowSecurityService flowSecurityService;

    public AuthRequestFormController() {

        super();
        logger = LoggerFactory.getLogger(EditAccountController.class);
        setCommandClass(AuthorizationRequest.class);
        setSessionForm(false);
    }

    @Override
    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(Timestamp.class, new CustomTimestampEditor(
                "yyyy-mm-dd hh:mm:ss.SSS"));

    }

    @Override
    protected Object formBackingObject(HttpServletRequest request)
            throws Exception {

        /*
         * The submission form is generated by AuthRequestController. Because
         * the AuthorizationRequest contains a list, binding will fail unless we
         * have a command bean with the right size list. So, we get the id from
         * the HTTP request and fetch the right AuthorizationRequest from the db
         * before binding the submitted values.
         */
        AuthorizationRequest authRequest = null;

        String authRequestId = request.getParameter("id");

        logger
                .debug("Initializing formBackingObject AuthorizationRequest with id = "
                        + authRequestId);

        authRequest = flowSecurityService
                .getAuthorizationRequest(authRequestId);

        return authRequest;
    }

    @Override
    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        AuthorizationRequest authReq = (AuthorizationRequest) command;

        NodeVisit visit = VisitUtils.getVisit(request);

        if (null != request.getParameter("accept")) {

            logger.debug("Accepting AuthorizationRequest: " + authReq);

            flowSecurityService.acceptRequest(authReq, visit);

        } else if (null != request.getParameter("reject")) {

            logger.debug("Rejecting AuthorizationRequest: " + authReq);

            flowSecurityService.rejectRequest(authReq, visit);

        } else {

            throw new IllegalArgumentException(
                    "Missing request parameter: either \"accept\" or \"reject\" required.");
        }

        return new ModelAndView(new RedirectView(getSuccessView()));
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("AuthRequestController: accountService not set");
        }

        if (flowSecurityService == null) {
            throw new Exception("AuthRequestController: flowService not set");
        }
    }

    public AccountService getAccountService() {
        return accountService;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public FlowSecurityService getFlowSecurityService() {
        return flowSecurityService;
    }

    public void setFlowSecurityService(FlowSecurityService flowSecurityService) {
        this.flowSecurityService = flowSecurityService;
    }

}

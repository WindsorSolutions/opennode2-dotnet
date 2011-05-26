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

import java.util.HashMap;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.admin.editor.SystemRoleTypeEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.admin.AccountService;

public class NewAccountController extends BaseSecurityFormController implements
        Controller, InitializingBean {

    private AccountService accountService;

    public NewAccountController() {
        super();
        logger = LoggerFactory.getLogger(NewAccountController.class);
        setCommandClass(UserAccount.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("NewAccountController: accountService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(SystemRoleType.class,
                new SystemRoleTypeEditor());

    }

    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        logger.debug(AdminConstants.SUBMITTING + command);

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        UserAccount accountRequest = (UserAccount) command;

        ModelAndView view = null;

        try {

            logger.debug("Account request item: " + accountRequest);

            UserAccount account = accountService.save(accountRequest, visit);

            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);

            if (StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(
                    request, "savepol"))) {
                logger.debug("Returning policy view");
                view = new ModelAndView(new RedirectView("policy-edit.htm?id="
                        + account.getNaasUserName()));
            } else {
                view = new ModelAndView(new RedirectView(getSuccessView()));
            }

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            request.setAttribute(AdminConstants.COMMAND_KEY, accountRequest);

            view = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY,
                    getRreferenceData(request, visit));

        }

        return view;

    }

    protected Map getRreferenceData(HttpServletRequest request, NodeVisit visit) {

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SECURITY);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getSecurityBars(
                request, 0, showManageUserRequests));

        // sys roles
        model.put("sysRoles", SystemRoleType.values());

        return model;

    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map modelHolder = new HashMap();
        modelHolder.put(AdminConstants.MODEL_KEY, getRreferenceData(request,
                visit));
        return modelHolder;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        UserAccount accountRequest = new UserAccount();
        accountRequest.setRole(SystemRoleType.Authed);
        return accountRequest;

    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

}

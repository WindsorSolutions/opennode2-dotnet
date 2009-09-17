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
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;
import org.springframework.web.servlet.mvc.Controller;

import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.QueryStringUtils;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowSecurityService;

public class AuthRequestController extends AbstractController implements
        Controller, InitializingBean {

    private AccountService accountService;
    private FlowSecurityService flowSecurityService;
    private Logger logger = Logger.getLogger(AuthRequestController.class);

    public AuthRequestController() {
        super();
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("AuthRequestController: accountService not set");
        }

        if (flowSecurityService == null) {
            throw new Exception(
                    "AuthRequestController: flowSecurityService not set");
        }
    }

    @Override
    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        response.setHeader("Cache-Control", "must-revalidate");
        response.setHeader("Pragma", "no-cache");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED + " security access "
                    + AdminConstants.ACCESS_REQUEST);
            return VisitUtils.getUnauthedView(request);
        }

        Map<String, Object> model = new HashMap<String, Object>();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SECURITY);

        // defaults to 0
        Integer viewIndex = QueryStringUtils.getBarIndex(request);

        // Defaults page view to 0
        model.put(AdminConstants.VIEW_INDEX_KEY, viewIndex);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getSecurityBars(
                request, 2, true));

        logger.debug("Fetching list of pending Authorization Requests...");

        List<AuthorizationRequest> authRequests = flowSecurityService
                .listPendingRequests();

        if (null == authRequests || authRequests.size() == 0) {

            model.put("noRequestsPending", true);

        } else {

            model
                    .put("authRequests", flowSecurityService
                            .listPendingRequests());
        }

        return new ModelAndView("authrequest-manage", AdminConstants.MODEL_KEY,
                model);
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public void setFlowSecurityService(FlowSecurityService flowSecService) {
        this.flowSecurityService = flowSecService;
    }

}
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

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.admin.domain.NAASFlowPolicyInfo;
import com.windsor.node.admin.domain.NAASPolicyEditRequest;
import com.windsor.node.admin.editor.SystemRoleTypeEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowService;

public class EditPolicyController extends BaseSecurityFormController implements
        Controller, InitializingBean {

    private AccountService accountService;
    private FlowService flowService;

    public EditPolicyController() {
        super();
        logger = Logger.getLogger(EditPolicyController.class);
        setCommandClass(NAASPolicyEditRequest.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("EditPolicyController: accountService not set");
        }

        if (flowService == null) {
            throw new Exception("EditPolicyController: flowService not set");
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

        NAASPolicyEditRequest editRequest = (NAASPolicyEditRequest) command;

        ModelAndView view = null;

        try {

            logger.debug("getting username");
            if (editRequest == null || editRequest.getAccount() == null) {
                throw new IllegalArgumentException(
                        "User Account not in command.");
            }

            String username = editRequest.getAccount().getNaasUserName();
            logger.debug("username: " + username);

            UserAccount naasAccount = accountService.getByUserName(username,
                    visit);

            logger.debug("getting flow assignments");
            String[] selectedFlow = ServletRequestUtils.getStringParameters(
                    request, "selectedFlow");

            List<UserAccessPolicy> assignedPolicies = new ArrayList<UserAccessPolicy>(
                    selectedFlow.length);

            if (selectedFlow != null) {
                logger.debug("assignments: " + selectedFlow.length);

                for (int i = 0; i < selectedFlow.length; i++) {

                    UserAccessPolicy policy = new UserAccessPolicy();

                    policy.setAccountId(naasAccount.getId());
                    policy.setAllowed(true);
                    policy.setPolicyType(ServiceRequestAuthorizationType.FLOW);
                    policy.setTypeQualifier(selectedFlow[i]);
                    policy.setModifiedById(visit.getUserAccount().getId());

                    assignedPolicies.add(policy);

                }
            }

            logger.debug("Policies after parsing: " + assignedPolicies);

            naasAccount.setPolicies(assignedPolicies);

            accountService.update(naasAccount, visit);

            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);

            view = new ModelAndView(new RedirectView(getSuccessView()));

        } catch (Exception ex) {

            logger.error(ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            request.setAttribute(AdminConstants.COMMAND_KEY, editRequest);

            view = new ModelAndView(getFormView(), AdminConstants.MODEL_KEY,
                    getReferenceData(request, visit));

        }

        return view;

    }

    protected Map<String, Object> getReferenceData(HttpServletRequest request,
            NodeVisit visit) {

        Map<String, Object> model = new HashMap<String, Object>();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SECURITY);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getSecurityBars(
                request, 1, showManageUserRequests));

        return model;

    }

    protected Map<String, Object> referenceData(HttpServletRequest request)
            throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map<String, Object> modelHolder = new HashMap<String, Object>();
        modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(request,
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

        String naasUsername = ServletRequestUtils.getStringParameter(request,
                "id");

        logger.debug("policy edit for: " + naasUsername);

        UserAccount dbAccount = accountService.getOrCreateAccount(naasUsername,
                visit);
        logger.debug("Db Account: " + dbAccount);

        NAASPolicyEditRequest editRequest = new NAASPolicyEditRequest();

        if (StringUtils.isNotBlank(naasUsername)) {

            editRequest.setAccount(accountService.getByUserName(naasUsername,
                    visit));

            // get all flows
            logger.debug("Getting list of flows...");
            List<DataFlow> flowList = flowService.getFlows(visit, false);

            for (int f = 0; f < flowList.size(); f++) {

                NAASFlowPolicyInfo info = new NAASFlowPolicyInfo();

                DataFlow flow = (DataFlow) flowList.get(f);

                info.setFlowId(flow.getId());
                info.setFlowProtected(flow.isSecured());
                info.setLabel(flow.getName());

                for (int p = 0; p < dbAccount.getPolicies().size(); p++) {

                    UserAccessPolicy policy = (UserAccessPolicy) dbAccount
                            .getPolicies().get(p);

                    logger.debug("User Db policy: " + policy);

                    // TODO: For now, only flow policies are managed. In the
                    // future would be nice to implement other
                    // types (e.g. services-level policy?)
                    if (policy.getPolicyType().getName().equalsIgnoreCase(
                            ServiceRequestAuthorizationType.FLOW.getName())
                            && flow.getId().equalsIgnoreCase(
                                    policy.getTypeQualifier())) {
                        info.setAssigned(true);
                        break;
                    }

                }

                editRequest.getFlowAssignemnts().add(info);

                logger.debug("account flow policy: "
                        + editRequest.getFlowAssignemnts().get(f));

            }

        }

        logger.debug("EditRequest Detail: " + editRequest);

        return editRequest;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

}

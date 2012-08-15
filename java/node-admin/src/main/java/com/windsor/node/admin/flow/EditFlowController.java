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
import com.windsor.node.admin.editor.SystemAccountEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowService;

public class EditFlowController extends BaseSimpleFormController implements
        Controller, InitializingBean {

    private FlowService flowService;
    private AccountService accountService;

    public EditFlowController() {
        super();
        logger = LoggerFactory.getLogger(EditFlowController.class);
        setCommandClass(DataFlow.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (flowService == null) {
            throw new Exception("EditFlowController: flowService not set");
        }

        if (accountService == null) {
            throw new Exception("EditFlowController: accountService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.error(AdminConstants.UNAUTHED_ACCESS);
            throw new Exception("initBinder could not find Visit.");
        }

        binder.registerCustomEditor(UserAccount.class, new SystemAccountEditor(
                accountService.getLocalUsers(false, visit)));

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

        DataFlow flow = (DataFlow) command;

        ModelAndView view = null;

        try {

            logger.debug("Flow item: " + flow);
            logger.debug("Flow Protected: " + flow.isSecured());

            if (StringUtils.isNotBlank(ServletRequestUtils.getStringParameter(
                    request, "delete"))) {

                logger.debug("Deleting: " + flow);
                flowService.deleteDataFlow(flow.getId(), visit);

            } else {
                flowService.saveDataFlow(flow, visit);
            }

            logger.debug(AdminConstants.RETURNING_SUCCESS_VIEW);

            view = new ModelAndView(new RedirectView(getSuccessView()));

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            flow.setId(null);

            request.setAttribute(AdminConstants.COMMAND_KEY, flow);

            view = new ModelAndView(getFormView(),
                    AdminConstants.MODEL_KEY, getReferenceData(request,
                            visit));

        }

        return view;

    }

    protected Map getReferenceData(HttpServletRequest request, NodeVisit visit) {

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_EXCHANGE);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getExchangeBars(request, 0));

        // set the side bar
        model.put("contacts", accountService.getLocalUsers(false, visit));

        return model;

    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map modelHolder = new HashMap();
        modelHolder.put(AdminConstants.MODEL_KEY, getReferenceData(
                request, visit));
        return modelHolder;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        String flowId = ServletRequestUtils.getStringParameter(request, "id");

        DataFlow flow = new DataFlow();

        if (StringUtils.isNotBlank(flowId)) {
            flow = flowService.getDataFlow(flowId, visit);
        }

        logger.debug("Flow Detail: " + flow);

        return flow;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

}

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

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import org.apache.commons.lang.StringUtils;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.beans.propertyeditors.CustomDateEditor;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;
import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.domain.ActivitySearchForm;
import com.windsor.node.admin.editor.CustomTimestampEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.ActivitySearchCriteria;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.ActivityService;
import com.windsor.node.common.service.admin.FlowService;

public class ActivitySearchController extends BaseSimpleFormController
        implements InitializingBean {

    private static final String HAS_SESSION = "has session";
    private static final String FORMAT = "yyyy-MM-dd";
    private static final String SESSION_LAST_SEARCH_CRITERIA = "LAST_SEARCH";
    private static final SimpleDateFormat DATE_FORMAT = new SimpleDateFormat(
            FORMAT);

    private ActivityService activityService;
    private AccountService accountService;
    private FlowService flowService;
    private String resultView;

    public ActivitySearchController() {
        super();
        logger = LoggerFactory.getLogger(ActivitySearchController.class);
        setCommandClass(ActivitySearchForm.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (activityService == null) {
            throw new Exception("activityService not set");
        }

        if (accountService == null) {
            throw new Exception("accountService not set");
        }

        if (flowService == null) {
            throw new Exception("flowService not set");
        }
    }

    protected ModelAndView handleRequestInternal(HttpServletRequest request, HttpServletResponse response) throws Exception
    {
        if("reset".equalsIgnoreCase(request.getParameter("reset")))//if they ask for a reset blank out the criteria object
        {
            request.getSession().removeAttribute(SESSION_LAST_SEARCH_CRITERIA);
        }
        return super.handleRequestInternal(request, response);
    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(Date.class, new CustomDateEditor(
                new SimpleDateFormat(FORMAT), false));

        CustomTimestampEditor timestampEditor = new CustomTimestampEditor(
                getMessageSourceAccessor().getMessage(AdminConstants.SCHEDULE_DATETIME_FORMAT_KEY,
                        AdminConstants.DATETIME_FORMAT));

        binder.registerCustomEditor(java.sql.Timestamp.class, timestampEditor);

    }

    private ActivitySearchCriteria getSearchCriteria(HttpServletRequest request) {

        ActivitySearchCriteria criteria = null;
        HttpSession session = request.getSession(false);

        if (session != null
                && session.getAttribute(SESSION_LAST_SEARCH_CRITERIA) != null) {

            logger.debug(HAS_SESSION);

            criteria = (ActivitySearchCriteria) session
                    .getAttribute(SESSION_LAST_SEARCH_CRITERIA);

            logger.debug("Criteria: " + criteria);

        }

        return criteria;

    }

    private void setSearchCriteria(HttpServletRequest request,
            ActivitySearchCriteria criteria) {

        HttpSession session = request.getSession(false);

        if (session != null) {

            logger.debug(HAS_SESSION);

            if (session.getAttribute(SESSION_LAST_SEARCH_CRITERIA) != null) {
                session.removeAttribute(SESSION_LAST_SEARCH_CRITERIA);
            }

            session.setAttribute(SESSION_LAST_SEARCH_CRITERIA, criteria);

        }

    }

    private String makeReadable(ActivitySearchCriteria criteria,
            String createdByName, NodeVisit visit) {

        StringBuffer sb = new StringBuffer();

        if (StringUtils.isNotBlank(criteria.getFlowId())) {
            DataFlow flow = flowService
                    .getDataFlow(criteria.getFlowId(), visit);
            sb.append("<b>Exchange</b> = " + flow.getName() + AdminConstants.SEMICOLON);
        }

        if (StringUtils.isNotBlank(criteria.getIp())) {
            sb.append("<b>IP</b> = " + criteria.getIp() + AdminConstants.SEMICOLON);
        }

        if (StringUtils.isNotBlank(criteria.getTransactionId())) {
            sb.append("<b>Transaction Id</b> like "
                    + criteria.getTransactionId() + AdminConstants.SEMICOLON);
        }

        if (StringUtils.isNotBlank(criteria.getCreatedById())) {
            sb.append("<b>Creator</b> = " + criteria.getCreatedById()
                    + AdminConstants.SEMICOLON);
        }

        if (StringUtils.isNotBlank(criteria.getType())) {
            sb.append("<b>Type</b> = " + criteria.getType() + AdminConstants.SEMICOLON);
        }

        sb.append("<b>Max. Records</b> = " + criteria.getMaxRecords()
                + AdminConstants.SEMICOLON);

        sb.append("<b>Between</b> "
                + DATE_FORMAT.format(criteria.getCreatedFrom())
                + " <b>and</b> " + DATE_FORMAT.format(criteria.getCreatedTo())
                + "");

        return sb.toString();
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

        request.setAttribute(AdminConstants.COMMAND_KEY, command);

        String viewToReturn;

        try {

            ActivitySearchCriteria criteria = ((ActivitySearchForm) command)
                    .getCriteria();

            /*
             * the form contains only NAASUserNames, so we swap it for the
             * accountId before submitting. TODO: Change the User list to be a
             * map and than this will not be required
             */
            String createdByName = criteria.getCreatedById();

            if (StringUtils.isNotBlank(createdByName)) {
                UserAccount account = accountService.getByUserName(
                        createdByName, visit);
                criteria.setCreatedById(account.getId());
            }

            logger.debug("Search criteria: " + criteria);

            List results = activityService.search(criteria, visit);

            logger.debug("Found " + results.size() + " results.");
            logger.debug("Search results: " + results);

            request.setAttribute("result", results);

            if (StringUtils.isNotBlank(createdByName)) {
                criteria.setCreatedById(createdByName);
            }

            // Save it for later
            request.setAttribute("criteria", makeReadable(criteria,
                    createdByName, visit));
            setSearchCriteria(request, criteria);

            viewToReturn = getResultView();

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());

            viewToReturn = getFormView();

        }

        return new ModelAndView(viewToReturn, AdminConstants.MODEL_KEY, getModel(request));

    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        Map modelHolder = new Hashtable();

        modelHolder.put(AdminConstants.MODEL_KEY, getModel(request));

        return modelHolder;

    }

    private Map getModel(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_ACTIVITY);
        model.put("lookup", activityService.getLookups(visit));

        return model;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {
        NodeVisit visit = VisitUtils.getVisit(request);

        ActivitySearchForm form = new ActivitySearchForm();

        ActivitySearchCriteria criteria = getSearchCriteria(request);

        if (criteria != null) {
            form.setCriteria(criteria);
        }

        form.setLookups(activityService.getLookups(visit));
        form.setExchanges(flowService.getFlows(visit, false));

        return form;
    }

    public void setActivityService(ActivityService activityService) {
        this.activityService = activityService;
    }

    public String getResultView() {
        return resultView;
    }

    public void setResultView(String resultView) {
        this.resultView = resultView;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

}
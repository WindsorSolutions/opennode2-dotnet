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

package com.windsor.node.admin.schedule;

import java.util.HashMap;
import java.util.Map;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.lang.StringUtils;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;
import org.springframework.web.servlet.view.RedirectView;
import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.editor.ByIndexOrNameMapEditor;
import com.windsor.node.admin.editor.CustomTimestampEditor;
import com.windsor.node.admin.editor.ScheduleFrequencyTypeEditor;
import com.windsor.node.admin.editor.ScheduledItemSourceTypeEditor;
import com.windsor.node.admin.editor.ScheduledItemTargetTypeEditor;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduleArgument;
import com.windsor.node.common.domain.ScheduleFrequencyType;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.ScheduledItemSourceType;
import com.windsor.node.common.domain.ScheduledItemTargetType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.common.service.admin.PartnerService;
import com.windsor.node.common.service.admin.ScheduleService;
import com.windsor.node.common.util.ByIndexOrNameMap;

public class EditScheduleController extends BaseSimpleFormController implements
        Controller, InitializingBean {

    private FlowService flowService;
    private ScheduleService scheduleService;
    private PartnerService partnerService;
    private AccountService accountService;

    public EditScheduleController() {
        super();
        logger = LoggerFactory.getLogger(EditScheduleController.class);
        setCommandClass(ScheduledItem.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (flowService == null) {
            throw new Exception("EditScheduleController: flowService not set");
        }

        if (scheduleService == null) {
            throw new Exception(
                    "EditScheduleController: scheduleService not set");
        }

        if (partnerService == null) {
            throw new Exception(
                    "EditScheduleController: partnerService not set");
        }

        if (accountService == null) {
            throw new Exception(
                    "EditScheduleController: accountService not set");
        }

    }

    protected void initBinder(HttpServletRequest request,
            ServletRequestDataBinder binder) throws Exception {

        binder.registerCustomEditor(ScheduleFrequencyType.class,
                new ScheduleFrequencyTypeEditor());

        binder.registerCustomEditor(ScheduledItemSourceType.class,
                new ScheduledItemSourceTypeEditor());

        binder.registerCustomEditor(ScheduledItemTargetType.class,
                new ScheduledItemTargetTypeEditor());

        binder.registerCustomEditor(ByIndexOrNameMap.class, "sourceArgs",
                new ByIndexOrNameMapEditor());

        CustomTimestampEditor timestampEditor = new CustomTimestampEditor(
                getMessageSourceAccessor().getMessage("scheduleDatetimeFormat",
                        AdminConstants.DATETIME_FORMAT));

        binder.registerCustomEditor(java.sql.Timestamp.class, timestampEditor);

    }

    /**
     * onSubmit
     */
    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        ModelAndView view = null;

        if (errors != null && errors.hasErrors()) {

            logger.error(errors.getMessage());
            view = VisitUtils.getUnauthedView(request);

        } else {

            logger.debug(AdminConstants.SUBMITTING + command);

            // get user visit
            NodeVisit visit = VisitUtils.getVisit(request);

            if (visit == null) {
                logger.error(AdminConstants.UNAUTHED_ACCESS);
                view = VisitUtils.getUnauthedView(request);
            } else {

                ScheduledItem schedule = (ScheduledItem) command;

                try {

                    logger.debug("Schedule item: " + schedule);

                    if (StringUtils.isNotBlank(ServletRequestUtils
                            .getStringParameter(request, "delete"))) {

                        logger.debug("Deleting: " + schedule);
                        scheduleService.delete(schedule.getId(), visit);

                    } else {

                        logger.debug(AdminConstants.SAVING + schedule.getId());
                        if (StringUtils.isBlank(schedule.getId())) {
                            schedule.setId(null);
                        }
                        schedule = scheduleService.save(schedule, visit);
                    }

                    view = new ModelAndView(new RedirectView(getSuccessView()));

                } catch (Exception ex) {

                    logger.error(ex.getMessage(), ex);

                    request.setAttribute(AdminConstants.ERROR_KEY, ex
                            .getMessage());

                    request.setAttribute(AdminConstants.COMMAND_KEY, schedule);

                    view = new ModelAndView(getFormView(),
                            AdminConstants.MODEL_KEY, getReferenceData(request,
                                    visit));

                }
            }
        }

        return view;

    }

    protected Map<String, Object> getReferenceData(HttpServletRequest request,
            NodeVisit visit) {

        Map<String, Object> model = new HashMap<String, Object>();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_SCHEDULE);

        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getScheduleBars(
                request, 0));

        // set flows/exchanges
        model.put("flows", flowService.getFlows(visit, false));

        // set frequency types
        model.put("frequencyTypes", ScheduleFrequencyType.values());

        // set partner types
        model.put("partners", partnerService.get(visit));

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

        logger.debug("formBackingObject()");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        String scheduleId = ServletRequestUtils.getStringParameter(request,
                "id");

        ScheduledItem schedule = null;

        if (StringUtils.isNotBlank(scheduleId)) {

            schedule = scheduleService.get(scheduleId, visit);

            if (schedule != null) {

                boolean runNow = ServletRequestUtils.getBooleanParameter(
                        request, "rn", false);

                if (runNow) {
                    scheduleService.saveAndRunNow(schedule, visit);
                }

                UserAccount modifiedBy = accountService.getByAccountId(schedule
                        .getModifiedById(), visit);

                if (modifiedBy != null) {
                    schedule.setModifiedById(modifiedBy.getNaasUserName());
                }

            }
        }

        logger.debug("Schedule Detail: " + schedule);

        if (schedule == null) {
            schedule = new ScheduledItem();
            //add some empty args to bind to
            /*for(int i = 0; i < 30; i++)
            {
                ScheduleArgument newArg = new ScheduleArgument();
                String newKey = "" + (i);
                while(newKey.length() < 3)
                {
                    newKey = "0" + newKey;
                }
                newArg.setArgumentKey(newKey);
                schedule.getScheduleArguments().add(newArg);
            }*/
        } else {
            Map<String, String> services = flowService
                    .getActiveServiceMapByFlowId(schedule.getFlowId());
            schedule.setServices(services);
        }

        //testing putting empty bind args here, should solve some issues elsewhere
        int initialSize = schedule.getScheduleArguments().size();
        for(int i = initialSize; i < initialSize+30; i++)
        {
            ScheduleArgument newArg = new ScheduleArgument();
            String newKey = "" + (i);
            while(newKey.length() < 3)
            {
                newKey = "0" + newKey;
            }
            newArg.setArgumentKey(newKey);
            schedule.getScheduleArguments().add(newArg);
        }

        return schedule;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

    public void setScheduleService(ScheduleService scheduleService) {
        this.scheduleService = scheduleService;
    }

    public void setPartnerService(PartnerService partnerService) {
        this.partnerService = partnerService;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }
}

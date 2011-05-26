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

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestBindingException;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;

import com.windsor.node.BaseSimpleFormController;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.QueryStringUtils;
import com.windsor.node.admin.util.SideBarUtils;
import com.windsor.node.admin.util.SiteTabUtils;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.NotificationType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.UserFlowNotification;
import com.windsor.node.common.service.admin.AccountService;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.common.service.admin.NotificationService;

public class ProfileController extends BaseSimpleFormController implements
        InitializingBean {

    public static final String FLOW_ID_NOTIF_TYPE_DELIMIN = "_";

    private static final String VIEW_INDEX_KEY = AdminConstants.VIEW_INDEX_KEY;
    private static final String SIDEBAR_KEY = AdminConstants.BARS_KEY;

    private AccountService accountService;
    private NotificationService notificationService;
    private FlowService flowService;

    public ProfileController() {
        super();
        logger = LoggerFactory.getLogger(ProfileController.class);
        setCommandClass(NodeVisit.class);
        setSessionForm(true);
    }

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("accountService not set");
        }

        if (notificationService == null) {
            throw new Exception("notificationService not set");
        }

        if (flowService == null) {
            throw new Exception("flowService not set");
        }

    }

    protected ModelAndView onSubmit(HttpServletRequest request,
            HttpServletResponse response, Object command, BindException errors)
            throws Exception {

        logger.debug("init processFormSubmission ...");

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.error(AdminConstants.UNAUTHED_ACCESS);
            return VisitUtils.getUnauthedView(request);
        }

        ModelAndView view = null;
        int cmdId = 0;

        try {

            // This screen is only for editing one's own info
            String userId = visit.getUserAccount().getId();
            cmdId = ServletRequestUtils.getIntParameter(request, "cmd", -1);

            logger.debug("userId: " + userId);
            logger.debug("cmdId: " + cmdId);

            if (StringUtils.isNotBlank(userId) && cmdId > -1 && cmdId <= 2) {

                UserAccount reqAccount = accountService.getByAccountId(userId,
                        visit);

                if (reqAccount == null) {
                    throw new IllegalArgumentException("Invalid account id");
                }

                switch (cmdId) {

                case 1: // Password
                    String passCurrent = ServletRequestUtils
                            .getStringParameter(request, "p1");
                    String passNew1 = ServletRequestUtils.getStringParameter(
                            request, "p2");
                    String passNew2 = ServletRequestUtils.getStringParameter(
                            request, "p3");

                    if (StringUtils.isBlank(passNew1)
                            || StringUtils.isBlank(passNew2)
                            || (!passNew1.equals(passNew2))) {
                        throw new IllegalArgumentException(
                                "New password cannot be null and must be the same as in confirmation.");
                    }

                    if (!userId.equals(visit.getUserAccount().getId())) {
                        throw new IllegalArgumentException(
                                "You can reset only your own password using this utility");
                    }

                    accountService.resetPassword(passCurrent, passNew1, visit);

                    break;

                case 2: // Notifications

                    String[] notifs = ServletRequestUtils.getStringParameters(
                            request, "notifReq");

                    Map flowNotifs = new HashMap();

                    for (int i = 0; i < notifs.length; i++) {

                        logger.debug("notifs[" + i + "] = " + notifs[i]);

                        int lastDeliminatorIndex = notifs[i]
                                .lastIndexOf(FLOW_ID_NOTIF_TYPE_DELIMIN);
                        String flowId = notifs[i].substring(0,
                                lastDeliminatorIndex);
                        String notifType = notifs[i]
                                .substring(lastDeliminatorIndex + 1);

                        logger.debug("flowId: " + flowId);
                        logger.debug("notifType: " + notifType);

                        UserFlowNotification flowNotif;

                        if (flowNotifs.containsKey(flowId)) {
                            logger.debug("adding " + notifType
                                    + " to notification");

                            flowNotif = (UserFlowNotification) flowNotifs
                                    .get(flowId);
                            flowNotif
                                    .setByNotificationType((NotificationType) NotificationType
                                            .getEnumMap().get(notifType));
                            logger.debug("flowNotif = " + flowNotif);

                        } else {
                            logger.debug("Creating notification with "
                                    + notifType);

                            flowNotif = new UserFlowNotification();
                            flowNotif.setFlow(new DataFlow(flowId));
                            flowNotif.setModifiedById(userId);
                            flowNotif
                                    .setByNotificationType((NotificationType) NotificationType
                                            .getEnumMap().get(notifType));
                            flowNotifs.put(flowId, flowNotif);
                            logger.debug("flowNotif = " + flowNotif);
                        }

                    }

                    List allNotifList = new ArrayList();
                    allNotifList.addAll(flowNotifs.values());
                    logger
                            .debug("saving " + allNotifList.size()
                                    + " notifications for userid "
                                    + reqAccount.getId());

                    notificationService.save(userId, allNotifList, visit);

                    break;

                default:
                    logger.error("cmdId " + cmdId);
                    break;

                }

            }

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);
            request.setAttribute(AdminConstants.ERROR_KEY, ex.getMessage());
        } finally {

            Map model = getModel(request, visit);
            logger.debug("returning view with viewIndex: " + cmdId);
            model.put(VIEW_INDEX_KEY, new Integer(cmdId));
            model.put(SIDEBAR_KEY, SideBarUtils.getProfileBars(request, cmdId));
            view = new ModelAndView("profile", AdminConstants.MODEL_KEY,
                    model);
        }
        logger.debug("ProfileController.submit: ModelAndView = " + view);

        return view;

    }

    protected Map referenceData(HttpServletRequest request) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_ACCESS);
            return null;
        }

        Map modelHolder = new HashMap();
        modelHolder
                .put(AdminConstants.MODEL_KEY, getModel(request, visit));
        modelHolder.put("deliminator", FLOW_ID_NOTIF_TYPE_DELIMIN);
        return modelHolder;

    }

    protected Object formBackingObject(HttpServletRequest request)
            throws ServletException {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED + " profile " + AdminConstants.ACCESS_REQUEST);
            return new NodeVisit();
        } else {
            logger.debug("Valid profile reqested");
            return VisitUtils.getVisit(request);
        }

    }

    private Map getModel(HttpServletRequest request, NodeVisit visit)
            throws ServletRequestBindingException {

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);

        // Set the selected tab
        model.put(AdminConstants.TAB_KEY, SiteTabUtils.TAB_PROFILE);

        Integer viewIndex = QueryStringUtils.getBarIndex(request);
        logger.debug("getModel: viewIndex = " + viewIndex);

        // Defaults page view to 0
        model.put(VIEW_INDEX_KEY, viewIndex);

        String accountId = ServletRequestUtils
                .getStringParameter(request, "id");

        if (StringUtils.isBlank(accountId)) {
            accountId = visit.getUserAccount().getId();
        }

        UserAccount viewAccount = accountService.getByAccountId(accountId,
                visit);

        if (viewAccount == null) {
            throw new IllegalArgumentException("Invalid Id argument.");
        }

        UserAccount modifiedBy = accountService.getByAccountId(viewAccount
                .getModifiedById(), visit);

        viewAccount.setModifiedById(modifiedBy.getNaasUserName());

        model.put("account", viewAccount);

        /* Notifications sidebar */
        if (viewIndex.intValue() == 2) {

            logger
                    .debug("Get list of flow/notifications already assigned to the user...");
            List notifs = notificationService.getByAccountIdLight(accountId,
                    visit);
            logger.debug(AdminConstants.FOUND + notifs.size());

            logger.debug("Get all the possible flows...");
            List flows = flowService.getFlows(visit, false);
            logger.debug(AdminConstants.FOUND + flows.size());

            List assignments = new ArrayList();
            // for each flow
            for (int f = 0; f < flows.size(); f++) {

                DataFlow dataFlow = (DataFlow) flows.get(f);
                logger.debug("Flow: " + dataFlow);

                // check whether one of the notifications matches this flow
                UserFlowNotification assignedUserFlow = null;

                for (int n = 0; n < notifs.size(); n++) {

                    UserFlowNotification userAssignment = (UserFlowNotification) notifs
                            .get(n);
                    logger.debug("User Assignment: " + userAssignment);

                    // if user has a notif for this flow, use it
                    if (userAssignment.getFlow().getName().equalsIgnoreCase(
                            dataFlow.getName())) {
                        logger.debug("user has a notification for this flow");
                        assignedUserFlow = userAssignment;
                    }
                }

                // If we have not found one already assigned to the user, just
                // give them
                // the empty one from the flow
                if (assignedUserFlow == null) {
                    logger
                            .debug("user does NOT have a notification for this flow");
                    assignedUserFlow = new UserFlowNotification(dataFlow);
                }

                // lastly, add the flow and its user assignemnts to the list
                assignments.add(assignedUserFlow);

            }

            // Set notifications to the view
            model.put("notifs", assignments);

        }
        // TODO: display appropriately if no notifications found.
        // set the side bar
        model.put(AdminConstants.BARS_KEY, SideBarUtils.getProfileBars(request, 0));

        return model;

    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    public void setNotificationService(NotificationService notificationService) {
        this.notificationService = notificationService;
    }

    public void setFlowService(FlowService flowService) {
        this.flowService = flowService;
    }

}

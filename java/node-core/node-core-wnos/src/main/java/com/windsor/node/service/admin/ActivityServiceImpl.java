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

package com.windsor.node.service.admin;

import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivitySearchCriteria;
import com.windsor.node.common.domain.ActivitySearchLookups;
import com.windsor.node.common.domain.DashboardContent;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.service.admin.ActivityService;
import com.windsor.node.service.BaseService;

public class ActivityServiceImpl extends BaseService implements
        ActivityService, InitializingBean {

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

    }

    /**
     * getDashboardContent
     */
    public DashboardContent getDashboardContent(NodeVisit visit) {
        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        return getActivityDao().getDashboardContent();
    }

    /**
     * getLookups
     */
    public ActivitySearchLookups getLookups(NodeVisit visit) {

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        return getActivityDao().getLookups();
    }

    /**
     * getActivityDetail
     */
    public Activity getActivityDetail(String activityId, NodeVisit visit) {

        if (StringUtils.isBlank(activityId)) {
            throw new IllegalArgumentException(
                    "Activity Id argument not provided.");
        }

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        return getActivityDao().get(activityId);
    }

    /**
     * search
     */
    public List search(ActivitySearchCriteria instance, NodeVisit visit) {

        if (instance == null) {
            throw new IllegalArgumentException(
                    "ActivitySearchCriteria argument not provided.");
        }

        if (instance.getCreatedFrom() == null
                || instance.getCreatedTo() == null) {
            throw new IllegalArgumentException(
                    "ActivitySearchCriteria From and To arguments not provided.");
        }

        // Make sure the user performing that action has program rights
        validateByRole(visit, SystemRoleType.Program);

        return getActivityDao().search(instance);
    }

    /**
     * create
     */
    public void insert(Activity instance) {

        if (instance.getModifiedById() == null) {
            throw new IllegalArgumentException("ModifiedBy cannot be null.");
        }

        if (instance.getIp() == null) {
            throw new IllegalArgumentException("Ip cannot be null.");
        }

        getActivityDao().make(instance);

    }

}
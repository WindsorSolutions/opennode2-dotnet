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

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.PluginAdminService;
import com.windsor.node.data.dao.ConnectionDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.plugin.PluginHelper;
import com.windsor.node.service.BaseService;

public class PluginServiceImpl extends BaseService implements
        PluginAdminService, InitializingBean {

    private FlowDao flowDao;
    private PluginHelper pluginHelper;
    private ConnectionDao connectionDao;

    /**
     * check
     */
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (pluginHelper == null) {
            throw new RuntimeException("PluginHelper Not Set");
        }

        if (flowDao == null) {
            throw new RuntimeException("FlowDao Not Set");
        }

        if (connectionDao == null) {
            throw new RuntimeException("ConnectionDao Not Set");
        }

    }

    /**
     * upload
     */
    public void upload(String flowId, byte[] content, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.ADMIN);

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException("flowId not set.");
        }

        if (content == null) {
            throw new RuntimeException("content not set.");
        }

        Activity logEntry = makeNewActivity(ActivityType.AUDIT, visit);

        // The idea is that both of them need to work independently
        try {

            DataFlow flow = flowDao.get(flowId);

            if (flow == null) {
                throw new RuntimeException("Null flow");
            }

            logEntry.addEntry("{0} attempted to upload a plugin {1}.",
                    new Object[] { visit.getName(), flow.getName() });

            pluginHelper.savePluginContent(flow, visit, content);

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while uploading plugin: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public void setPluginHelper(PluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setConnectionDao(ConnectionDao connectionDao) {
        this.connectionDao = connectionDao;
    }

}
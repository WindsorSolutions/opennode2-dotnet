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

package com.windsor.node.worker;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.TimerTask;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.conf.NOSConfig;
import com.windsor.node.service.admin.ActivityServiceImpl;

public class NodeWorker extends TimerTask implements InitializingBean {
    
    public static final Logger STATIC_LOGGER = Logger
            .getLogger(NodeWorker.class);
    
    private static String machineId;

    protected final Logger logger = Logger.getLogger(this.getClass());

    private ActivityServiceImpl activityService;
    private NOSConfig nosConfig;

    static {
        try {

            STATIC_LOGGER.debug("Getting local machine Id...");
            InetAddress address = InetAddress.getLocalHost();
            STATIC_LOGGER.debug("Local host: " + address);

            if (address != null) {
                STATIC_LOGGER.debug("Using hostname...");
                machineId = InetAddress.getLocalHost().getHostName();
            } else {
                STATIC_LOGGER.debug("Using native interfaces...");
                machineId = org.safehaus.uuid.NativeInterfaces
                        .getPrimaryInterface().toString();
            }

            STATIC_LOGGER.debug("MACHINE_ID: " + machineId);

        } catch (UnknownHostException ex) {
            STATIC_LOGGER.error(ex.getMessage(), ex);
        }
    }

    public NodeWorker() {

    }

    public void afterPropertiesSet() {
        if (activityService == null) {
            throw new RuntimeException("ActivityService Not Set");
        }

        if (nosConfig == null) {
            throw new RuntimeException("NOSConfig Not Set");
        }
    }

    public void run() {
        throw new RuntimeException("This is a base worker, make your own!");
    }

    public ActivityServiceImpl getActivityService() {
        return activityService;
    }

    public void setActivityService(ActivityServiceImpl activityService) {
        this.activityService = activityService;
    }

    public NOSConfig getNosConfig() {
        return nosConfig;
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    protected static String getMachineId() {
        return machineId;
    }

}
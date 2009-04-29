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

package com.windsor.node.common.service.admin;

import java.util.List;
import java.util.Map;

import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NodeVisit;

public interface FlowService {

    /*
     * 
     * 
     * SERVICES
     */

    List getFlowPluginImplementors(String flowId, NodeVisit visit);

    /**
     * getActiveServiceMap
     * 
     * @return map of id, name
     */
    Map getActiveServiceMap();

    /**
     * getActiveServiceMapByFlowId
     * 
     * @return map of id, name
     */
    Map getActiveServiceMapByFlowId(String flowId);

    /**
     * saveDataService
     * 
     * @param instance
     * @param visit
     * @return
     */
    DataService saveDataService(DataService instance, NodeVisit visit);

    /**
     * deleteDataService
     * 
     * @param instance
     * @param visit
     */
    void deleteDataService(String id, NodeVisit visit);

    /**
     * getService
     * 
     * @param serviceId
     * @param visit
     * @return
     */
    DataService getService(String serviceId, NodeVisit visit);

    /*
     * 
     * 
     * FLOW
     */

    /**
     * saveDataFlow
     * 
     * @param instance
     * @param visit
     * @return
     */
    DataFlow saveDataFlow(DataFlow instance, NodeVisit visit);

    /**
     * deleteDataFlow
     * 
     * @param instance
     * @param visit
     */
    void deleteDataFlow(String id, NodeVisit visit);

    /**
     * getDataFlow
     * 
     * @param flowId
     * @param visit
     * @return
     */
    DataFlow getDataFlow(String flowId, NodeVisit visit);

    /**
     * getFlows
     * 
     * @param visit
     * @param loadDataServices
     * @return
     */
    List getFlows(NodeVisit visit, boolean loadDataServices);

    /**
     * getDataFlowNames
     * 
     * @return a List of <Object>
     */
    List getDataFlowNames();

}
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

/**
 * Endpoint2Service.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:24:30 EDT)
 */
package com.windsor.node.ws2.service;

import net.exchangenetwork.www.schema.node._2.Authenticate;
import net.exchangenetwork.www.schema.node._2.AuthenticateResponse;
import net.exchangenetwork.www.schema.node._2.Download;
import net.exchangenetwork.www.schema.node._2.DownloadResponse;
import net.exchangenetwork.www.schema.node._2.Execute;
import net.exchangenetwork.www.schema.node._2.ExecuteResponse;
import net.exchangenetwork.www.schema.node._2.GetServices;
import net.exchangenetwork.www.schema.node._2.GetServicesResponse;
import net.exchangenetwork.www.schema.node._2.GetStatus;
import net.exchangenetwork.www.schema.node._2.GetStatusResponse;
import net.exchangenetwork.www.schema.node._2.NodePing;
import net.exchangenetwork.www.schema.node._2.NodePingResponse;
import net.exchangenetwork.www.schema.node._2.Notify;
import net.exchangenetwork.www.schema.node._2.NotifyResponse;
import net.exchangenetwork.www.schema.node._2.Query;
import net.exchangenetwork.www.schema.node._2.QueryResponse;
import net.exchangenetwork.www.schema.node._2.Solicit;
import net.exchangenetwork.www.schema.node._2.SolicitResponse;
import net.exchangenetwork.www.schema.node._2.Submit;
import net.exchangenetwork.www.schema.node._2.SubmitResponse;

import com.windsor.node.ws2.Endpoint2FaultMessage;

/**
 * Endpoint2Service java skeleton interface for the axisService
 */
public interface Endpoint2Service {

    /**
     * Auto generated method signature Request the node to invoke a specified
     * web services.
     * 
     * @param execute
     * @throws Endpoint2FaultMessage :
     */

    public ExecuteResponse Execute(Execute execute)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature User authentication method, must be
     * called initially.
     * 
     * @param authenticate
     * @throws Endpoint2FaultMessage :
     */

    public AuthenticateResponse Authenticate(Authenticate authenticate)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Download one or more documents from the
     * node
     * 
     * @param download
     * @throws Endpoint2FaultMessage :
     */

    public DownloadResponse Download(Download download)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Check the status of a transaction
     * 
     * @param getStatus
     * @throws Endpoint2FaultMessage :
     */

    public GetStatusResponse GetStatus(GetStatus getStatus)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Check the status of the service
     * 
     * @param nodePing
     * @throws Endpoint2FaultMessage :
     */

    public NodePingResponse NodePing(NodePing nodePing)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Query services offered by the node
     * 
     * @param getServices
     * @throws Endpoint2FaultMessage :
     */

    public GetServicesResponse GetServices(GetServices getServices)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Submit one or more documents to the node.
     * 
     * @param submit
     * @throws Endpoint2FaultMessage :
     */

    public SubmitResponse Submit(Submit submit) throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Notify document availability, network
     * events, submission statuses
     * 
     * @param notify
     * @throws Endpoint2FaultMessage :
     */

    public NotifyResponse Notify(Notify notify) throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Solicit a lengthy database operation.
     * 
     * @param solicit
     * @throws Endpoint2FaultMessage :
     */

    public SolicitResponse Solicit(Solicit solicit)
            throws Endpoint2FaultMessage;

    /**
     * Auto generated method signature Execute a database query
     * 
     * @param query
     * @throws Endpoint2FaultMessage :
     */

    public QueryResponse Query(Query query) throws Endpoint2FaultMessage;

}
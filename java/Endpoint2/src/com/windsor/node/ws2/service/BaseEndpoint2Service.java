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

public abstract class BaseEndpoint2Service implements Endpoint2Service {

    protected static final String DEFAULT_AUTH_DOMAIN = "default";
    protected static final String DEFAULT_AUTH_METHOD = "password";
    protected static final String UNKNOWN_DOMAIN = "Authentication domain not recognized.";

    protected static final String NULL_AUTH_REQUEST = "Null authRequest";
    protected static final String NULL_REQUEST = "Null request";
    protected static final String NULL_MESSAGES = "Null messages";
    protected static final String NULL_DOCUMENTS = "Null documents";
    protected static final String ZERO_DOCUMENTS = "Zero documents";
    protected static final String MORE_THAN_ONE_DOCUMENT = "More than one document";
    protected static final String NULL_DATA_FLOW = "Null data flow";
    protected static final String NULL_TRANSACTION_ID = "Null transaction Id";
    protected static final String NULL_DOWNLOAD_REQUEST = "Null download request";
    protected static final String NULL_TOKEN = "Null token";
    protected static final String NULL_PASSWORD = "Null Password";
    protected static final String NULL_USER_ID = "Null User id";
    protected static final String NULL_SUBMIT_REQUEST = "Null submit request";

    public abstract AuthenticateResponse Authenticate(Authenticate authenticate)
            throws Endpoint2FaultMessage;

    public abstract DownloadResponse Download(Download download)
            throws Endpoint2FaultMessage;

    public abstract ExecuteResponse Execute(Execute execute)
            throws Endpoint2FaultMessage;

    public abstract GetServicesResponse GetServices(GetServices getServices)
            throws Endpoint2FaultMessage;

    public abstract GetStatusResponse GetStatus(GetStatus getStatus)
            throws Endpoint2FaultMessage;

    public abstract NodePingResponse NodePing(NodePing nodePing)
            throws Endpoint2FaultMessage;

    public abstract NotifyResponse Notify(Notify notify)
            throws Endpoint2FaultMessage;

    public abstract QueryResponse Query(Query query)
            throws Endpoint2FaultMessage;

    public abstract SolicitResponse Solicit(Solicit solicit)
            throws Endpoint2FaultMessage;

    public abstract SubmitResponse Submit(Submit submit)
            throws Endpoint2FaultMessage;

}
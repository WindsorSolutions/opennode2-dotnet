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

package com.windsor.node.common.domain;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import org.apache.commons.lang3.builder.ReflectionToStringBuilder;
import com.windsor.node.common.util.ByIndexOrNameMap;

public class DataRequest extends AuditableIdentity {

    private static final long serialVersionUID = 1;
    private ByIndexOrNameMap parameters;
    private DataService service;
    private String transactionId;
    private RequestType type;
    private UserAccount requestor;
    private List<String> recipients;
    private Map<String, Object> notifications;//FIXME this map seems to be used for <String, String> either <Object, WnosTransactionNotificationType> or <String, WnosTransactionNotificationType>
    private PaginationIndicator paging;
    private String flowName;

    public DataRequest() {
        parameters = new ByIndexOrNameMap();
        recipients = new ArrayList<String>();
        notifications = new HashMap<String, Object>();
        paging = new PaginationIndicator(0, -1, true);
    }

    public DataRequest(String serviceName, ByIndexOrNameMap serviceArgs) {
        this();
        service = new DataService(serviceName);
        parameters = serviceArgs;
    }

    public String[] getParameterValues() {
        return parameters.toValueStringArray();
    }

    //FIXME really the ByIndexOrName object has to go, good workaround for now, ScheduleArgument doesn't belong here, but works
    public List<ScheduleArgument> getParametersArray() {
        if(parameters != null && parameters.values() != null)
        {
            List<ScheduleArgument> params = new ArrayList<ScheduleArgument>();
            Map<String, Object> values = parameters.getMap();
            Iterator<String> it = values.keySet().iterator();
            while(it.hasNext())
            {
                ScheduleArgument arg = new ScheduleArgument();
                arg.setArgumentKey(it.next());
                arg.setArgumentValue((String)values.get(arg.getArgumentKey()));
                params.add(arg);
            }
            return params;
        }
        return null;
    }

    public String getFlowName() {
        return flowName;
    }

    public void setFlowName(String flowName) {
        this.flowName = flowName;
    }

    public ByIndexOrNameMap getParameters() {
        return parameters;
    }

    public void setParameters(ByIndexOrNameMap parameters) {
        this.parameters = parameters;
    }

    public DataService getService() {
        return service;
    }

    public void setService(DataService service) {
        this.service = service;
    }

    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public RequestType getType() {
        return type;
    }

    public void setType(RequestType type) {
        this.type = type;
    }

    public UserAccount getRequestor() {
        return requestor;
    }

    public void setRequestor(UserAccount requestor) {
        this.requestor = requestor;
    }

    public List<String> getRecipients() {
        return recipients;
    }

    public void setRecipients(List<String> recipients) {
        this.recipients = recipients;
    }

    public Map<String, Object> getNotifications() {
        return notifications;
    }

    public void setNotifications(Map<String, Object> notifications) {
        this.notifications = notifications;
    }

    public PaginationIndicator getPaging() {
        return paging;
    }

    public void setPaging(PaginationIndicator paging) {
        this.paging = paging;
    }

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

}
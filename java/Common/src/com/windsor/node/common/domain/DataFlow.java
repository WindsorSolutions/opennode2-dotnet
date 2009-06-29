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
import java.util.List;
import java.util.Random;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ReflectionToStringBuilder;

/**
 * Represents a DataFlow, also called an &quot;Exchange&quot; in the NodeAdmin
 * web application.
 * 
 * <p>
 * A DataFlow is implemented by a Node plugin, and includes one or more
 * {@link com.windsor.node.common.domain.DataService DataServices}, operations
 * that can be invoked via SOAP or scheduled by NodeAdmin. This class manages
 * plugin configuration parameters, which are set via NodeAdmin and stored in
 * the Node metadata database.
 * </p>
 */
public class DataFlow extends AuditableIdentity {

    private static final long serialVersionUID = 2;

    /** The URL for information about this Flow. */
    private String infoUrl;

    /** Contact information for this Flow. */
    private String contactUserId;

    /** The Flow name. */
    private String name;

    /** A brief description of this Flow */
    private String description;

    /** A list of the DataServices provided by this Flow's plugin. */
    private List<DataService> services;

    /** A flag indicating whether access to this Flow is restricted. */
    private boolean secured;

    /** Default constructor. */
    public DataFlow() {
        services = new ArrayList<DataService>();
    }

    /**
     * Constructor.
     * 
     * <p>
     * Flow ids are assigned by the Node metadata database.
     * </p>
     * 
     * @param flowId
     */
    public DataFlow(String flowId) {
        this();
        this.setId(flowId);
    }

    /**
     * 
     * @return the URL for information about this Flow
     */
    public String getInfoUrl() {
        return infoUrl;
    }

    /**
     * Sets the URL for information about this Flow.
     * 
     * @param infoUrl
     */
    public void setInfoUrl(String infoUrl) {
        this.infoUrl = infoUrl;
    }

    /**
     * @return contact information for this Flow, typically an email address
     */
    public String getContactUserId() {
        return contactUserId;
    }

    /**
     * Sets contact information for this Flow, typically an email address.
     * 
     * @param contactUserId
     */
    public void setContactUserId(String contactUserId) {
        this.contactUserId = contactUserId;
    }

    /**
     * @return the name of this Flow
     */
    public String getName() {
        return name;
    }

    /**
     * Sets the Flow name (e.g., &quot;FRS&quot;, &quot;WQX&quot;,
     * &quot;SDWIS&quot;, etc.).
     * 
     * @param name
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return a brief description of this Flow
     */
    public String getDescription() {
        return description;
    }

    /**
     * Sets a brief description of this Flow.
     * 
     * @param description
     */
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     * @return a java.util.List of DataServices implemented by this Flow's
     *         plugin
     */
    public List<DataService> getServices() {
        return services;
    }

    /**
     * Sets the java.util.List of DataServices implemented by this Flow's
     * plugin.
     * 
     * @param services
     */
    public void setServices(List<DataService> services) {
        this.services = services;
    }

    /**
     * @return <b>true</b> if access to this Flow is restricted, otherwise
     *         <b>false</b>
     */
    public boolean isSecured() {
        return secured;
    }

    /**
     * Sets whether access to this Flow is restricted.
     * 
     * @param secured
     */
    public void setSecured(boolean secured) {
        this.secured = secured;
    }

    /**
     * @see java.lang.Object#toString()
     */
    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    /**
     * @see java.lang.Object#hashCode()
     */
    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).appendSuper(super.hashCode())
                .append(infoUrl).append(contactUserId).append(name).append(
                        description).append(services).append(secured)
                .toHashCode();
    }

    /**
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj == this) {
            return true;
        }
        if (obj.getClass() != getClass()) {
            return false;
        }
        DataFlow flow = (DataFlow) obj;
        return new EqualsBuilder().appendSuper(super.equals(obj)).append(
                infoUrl, flow.infoUrl)
                .append(contactUserId, flow.contactUserId).append(name,
                        flow.name).append(description, flow.description)
                .append(services, flow.services).append(secured, flow.secured)
                .isEquals();
    }
}

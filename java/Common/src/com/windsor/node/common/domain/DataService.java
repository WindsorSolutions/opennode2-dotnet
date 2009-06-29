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

import org.apache.commons.lang.builder.ReflectionToStringBuilder;

/**
 * A DataService is a discrete operation that can be invoked via SOAP or
 * scheduled by NodeAdmin.
 * 
 * <p>
 * A DataService is associated with a
 * {@link com.windsor.node.common.domain.DataFlow DataFlow}, and is implemented
 * by a class within a Node plugin. This class manages DataService configuration
 * parameters, which are set via the NodeAdmin web application and stored in the
 * Node metadata database. It also includes request/query parameters, which are
 * sent with a SOAP call or in a schedule.
 * </p>
 * <p>
 * At a minimum, a DataService is configured with the name of the implementing
 * class. It may also be associated with a data source and arguments specific to
 * the implementing class.
 * </p>
 * <p>
 * An Node plugin's implementing class may be capable of responding to several
 * types of Exchange Network Node service call (e.g., Query, Solicit, Submit,
 * Download, etc.); a DataService typically is configured to handle only one
 * type of call.
 * </p>
 * 
 */
public class DataService extends AuditableIdentity {

    /**
     * The default name for a DataService.
     */
    public static final String DEFAULTSERVICENAME = "*";

    private static final long serialVersionUID = 2;

    /**
     * A name for this service, set and displayed in NodeAdmin.
     */
    private String name;

    /**
     * The DataFlow that this DataService is associated with.
     */
    private String flowId;

    /**
     * The name of the DataFlow that this DataService is associated with.
     * 
     * @since OpenNode2 v1.1.4
     */
    private String flowName;

    /**
     * Whether this DataService can be invoked.
     */
    private boolean active;

    /**
     * The type of Exchange Network Node service call (e.g., Query, Solicit,
     * Submit, Download, etc.) that this DataService is configured to respond
     * to.
     */
    private ServiceType type;

    /**
     * The types of Exchange Network Node service call (e.g., Query, Solicit,
     * Submit, Download, etc.) that this DataService's implementing class is
     * capable of responding to.
     */
    private List<ServiceType> supportedTypes;

    /**
     * The arguments for this DataService, a java.util.List of type
     * com.windsor.node.common.domain.NamedSystemConfigItem
     */
    private List<NamedSystemConfigItem> args;

    /**
     * The java.util.List of data sources (if any) associated with this
     * DataService.
     * 
     * <p>
     * The list must be of type com.windsor.node.common.domain.DataProviderInfo.
     * </p>
     */
    private List<DataProviderInfo> dataSources;

    /**
     * The fully qualified name of the plugin class for this DataService.
     */
    private String implementingClassName;

    /**
     * Parameters passed by a SOAP call or Schedule.
     * 
     * <p>
     * This is usually populated by the plugin implementation class in response
     * to a ENDS v20 GetServices call, but could also be fed by the Node
     * metadata db if and when we decide to modify its schema.
     * </p>
     * 
     * @since OpenNode2 v1.1.4
     */
    private List<DataServiceRequestParameter> requestParams;

    /**
     * Default Constructor.
     */
    public DataService() {
        type = ServiceType.NONE;
        args = new ArrayList<NamedSystemConfigItem>();
        dataSources = new ArrayList<DataProviderInfo>();
        supportedTypes = new ArrayList<ServiceType>();
        requestParams = new ArrayList<DataServiceRequestParameter>();
    }

    /**
     * Constructor.
     * 
     * <p>
     * The service name is set in NodeAdmin.
     * </p>
     * 
     * @param serviceName
     */
    public DataService(String serviceName) {
        this();
        this.name = serviceName;
    }

    /**
     * Constructor.
     * 
     * @param serviceName
     * @param implementingClassName
     *            the fully qualified name of the plugin class for this
     *            DataService
     */
    public DataService(String serviceName, String implementingClassName) {
        this();
        this.name = serviceName;
        this.implementingClassName = implementingClassName;
    }

    /**
     * @return the name of this DataService
     */
    public String getName() {
        return name;
    }

    /**
     * Sets the name of this DataService.
     * 
     * @param name
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the database-generated id of the DataFlow that this DataService
     *         is associated with
     */
    public String getFlowId() {
        return flowId;
    }

    /**
     * Sets the the database-generated id of the DataFlow that this DataService
     * is associated with.
     * 
     * @param flowId
     */
    public void setFlowId(String flowId) {
        this.flowId = flowId;
    }

    /**
     * @return whether this DataService is active, i.e., whether it can be
     *         invoked
     */
    public boolean isActive() {
        return active;
    }

    /**
     * Sets whether this DataService is active, i.e., whether it can be invoked
     * via SOAP or a schedule.
     * 
     * @param active
     */
    public void setActive(boolean active) {
        this.active = active;
    }

    /**
     * @return the type of Exchange Network Node service call (e.g., Query,
     *         Solicit, Submit, Download, etc.) that this DataService is
     *         configured to respond to
     */
    public ServiceType getType() {
        return type;
    }

    /**
     * Sets the type of Exchange Network Node service call (e.g., Query,
     * Solicit, Submit, Download, etc.) that this DataService is configured to
     * respond to.
     * 
     * @param type
     */
    public void setType(ServiceType type) {
        this.type = type;
    }

    /**
     * @return a java.util.List containing the arguments for this DataService
     */
    public List<NamedSystemConfigItem> getArgs() {
        return args;
    }

    /**
     * Sets the arguments for this DataService.
     * 
     * @param args
     *            a java.util.List of type
     *            com.windsor.node.common.domain.NamedSystemConfigItem
     */
    public void setArgs(List<NamedSystemConfigItem> args) {
        this.args = args;
    }

    /**
     * @return the fully qualified name of the plugin class for this DataService
     */
    public String getImplementingClassName() {
        return implementingClassName;
    }

    /**
     * Sets the fully qualified name of the plugin class for this DataService
     * 
     * @param implementingClassName
     */
    public void setImplementingClassName(String implementingClassName) {
        this.implementingClassName = implementingClassName;
    }

    /**
     * @return a java.util.List of data sources (if any) associated with this
     *         DataService
     */
    public List<DataProviderInfo> getDataSources() {
        return dataSources;
    }

    /**
     * Sets the java.util.List of data sources (if any) associated with this
     * DataService.
     * 
     * 
     * @param dataSources
     */
    public void setDataSources(List<DataProviderInfo> dataSources) {
        this.dataSources = dataSources;
    }

    /**
     * @return a List of the {@link com.windsor.node.common.domain.ServiceType
     *         ServiceTypes} supported by this DataService's implementing class
     */
    public List<ServiceType> getSupportedTypes() {
        return supportedTypes;
    }

    /**
     * @param supportedTypes
     */
    public void setSupportedTypes(List<ServiceType> supportedTypes) {
        this.supportedTypes = supportedTypes;
    }

    /**
     * 
     * @see java.lang.Object#toString()
     */
    @Override
    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    /**
     * @return the name of the DataFlow associated with this DataService.
     * @since OpenNode2 v1.1.4
     */
    public String getFlowName() {
        return flowName;
    }

    /**
     * Sets the name of the DataFlow associated with this DataService.
     * 
     * @param flowName
     * @since OpenNode2 v1.1.4
     */
    public void setFlowName(String flowName) {
        this.flowName = flowName;
    }

    public List<DataServiceRequestParameter> getRequestParams() {
        return requestParams;
    }

    public void setRequestParams(List<DataServiceRequestParameter> requestParams) {
        this.requestParams = requestParams;
    }

}

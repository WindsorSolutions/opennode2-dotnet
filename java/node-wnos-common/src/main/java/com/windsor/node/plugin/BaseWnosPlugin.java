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

package com.windsor.node.plugin;

import java.io.File;
import java.text.FieldPosition;
import java.text.MessageFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import javax.sql.DataSource;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.NodePartnerProvider;
import com.windsor.node.service.helper.ServiceFactory;
import com.windsor.node.service.helper.client.DualEndpointNodeClientFactory;

/**
 * Base class for Node plugins.
 * 
 * <p>
 * Contains essential attributes for getting plugin configuration from the Node
 * at runtime, access to internal services, and utility methods for getting
 * Node-wide environment data.
 * </p>
 * 
 */
public abstract class BaseWnosPlugin implements InitializingBean {

    public static final String ARG_ADD_HEADER = "Add Header";

    public static final String ARG_DS_SOURCE = "Source Data Provider";
    public static final String ARG_DS_TARGET = "Target Data Provider";

    public static final String ARG_HEADER_AUTHOR = "Author";
    public static final String ARG_HEADER_CONTACT_INFO = "Contact Info";
    public static final String ARG_HEADER_ORG_NAME = "Organization";
    public static final String ARG_HEADER_NOTIFS = "Notifications";
    public static final String ARG_HEADER_PAYLOAD_OP = "Payload Operation";
    public static final String ARG_HEADER_SENSITIVITY = "Sensitivity";
    public static final String ARG_HEADER_TITLE = "Title";

    public static final String ARG_LAST_EXEC_STATE_KEY = "Name of app key to manage state";

    public static final String ARG_SOURCE_SYS_NAME = "Source System Name";

    private static final String NULL_REQUEST = "Null request";
    private static final String NULL_TRANSACTION = "Null transaction";

    protected Logger logger = LoggerFactory.getLogger(getClass());

    private Map<String, String> configurationArguments;
    private Map<String, DataSource> dataSources;
    private ServiceFactory serviceFactory;
    private List<ServiceType> supportedPluginTypes;
    private DualEndpointNodeClientFactory nodeClientFactory;
    private NodePartnerProvider partnerProvider;
    private File pluginSourceDir;

    /* for ENDS getServices() */
    private Boolean publishForEN11 = true;
    private Boolean publishForEN20 = true;

    /**
     * BaseWnosPlugin
     */
    public BaseWnosPlugin() {
        // initialize the local variables
        configurationArguments = new TreeMap<String, String>();
        dataSources = new TreeMap<String, DataSource>();
        supportedPluginTypes = new ArrayList<ServiceType>();

    }

    /**
     * @see org.springframework.beans.factory.InitializingBean#afterPropertiesSet()
     */
    public void afterPropertiesSet() {

        if (serviceFactory == null) {
            throw new RuntimeException("serviceFactory not set");
        }

        if (nodeClientFactory == null) {
            throw new RuntimeException("dualEndpointNodeClientFactory not set");
        }

        if (partnerProvider == null) {
            throw new RuntimeException("nodePartnerProvider not set");
        }

    }

    /**
     * Core processing call invoked by the Node.
     * 
     * @param transaction
     *            typically created by the Node from an incoming SOAP call
     * @return
     */
    public abstract ProcessContentResult process(NodeTransaction transaction);

    /**
     * Provides runtime request parameter specifications for the Exchange
     * Network Discovery Service, v20.
     * 
     * <p>
     * A plugin that returns <code>true</code> to {@link #isPublishForEN11()} or
     * {@link #isPublishForEN20()} should return accurate data if it accepts
     * request/schedule parameters for the given endpoint version, and return
     * <code>null</code> otherwise. Unpublished plugins should return
     * <code>null</code>.
     * </p>
     * 
     * <p>
     * NOTE: This method is called by the Ends2 plugin, after creating an
     * instance of the called class via reflection. Therefore, the
     * implementation cannot depend on plugin or Node state.
     * 
     * @param serviceName
     *            in case a singe plugin implementation class implements more
     *            than one service
     * @return a List of request parameter specs, or <code>null</code>
     * @see {@link com.windsor.node.plugin.frs23.FrsQueryProcessor#processContentResult
     *      FrsQueryProcessor.processContentResult()} for an example
     *      implementation.
     */
    public abstract List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName);

    /**
     * Gets a map of service configuration arguments set via the Node Admin
     * application.
     * 
     * @return
     */
    public Map<String, String> getConfigurationArguments() {
        return configurationArguments;
    }

    /**
     * Gets a map of data soruces where the Key is uneditable and the value must
     * be set by the plugin exe
     * 
     * @return
     */
    public Map<String, DataSource> getDataSources() {
        return dataSources;
    }

    /**
     * Used to obtain a service provider
     * 
     * @return
     */
    public ServiceFactory getServiceFactory() {
        return serviceFactory;
    }

    /**
     * Injected by the plugin Exe
     * 
     * @param serviceFactory
     */
    public void setServiceFactory(ServiceFactory serviceFactory) {
        this.serviceFactory = serviceFactory;
    }

    /**
     * List of provided plugin types
     * 
     * @return
     */
    public List<ServiceType> getSupportedPluginTypes() {
        return supportedPluginTypes;
    }

    public String getOptionalConfigValueAsString(String key) {
        return getConfigValueAsString(key, false);
    }

    public String getRequiredConfigValueAsString(String key) {
        return getConfigValueAsString(key, true);
    }

    public String getConfigValueAsString(String key, boolean throwOnError) {

        if (StringUtils.isBlank(key)) {
            throw new RuntimeException("Null Key");
        }

        logger.debug("Looking for: " + key);

        if (!getConfigurationArguments().containsKey(key)) {
            throw new RuntimeException("No such key: " + key);
        }

        String value = (String) getConfigurationArguments().get(key);

        if (StringUtils.isBlank(value) && throwOnError) {
            throw new RuntimeException("Required information not provided: "
                    + key);
        }

        return value;

    }

    public String getRequiredValueFromTransactionArgs(
            NodeTransaction transaction, int index) {

        String s = getOptionalValueFromTransactionArgs(transaction, index);

        if (StringUtils.isBlank(s)) {

            throw new RuntimeException("Required value not provided");

        } else {

            return s;
        }

    }

    public String getOptionalValueFromTransactionArgs(
            NodeTransaction transaction, int index) {

        logger.debug("getOptionalValueFromTransactionArgs called with index: "
                + index);

        if (transaction == null) {
            throw new RuntimeException(NULL_TRANSACTION);
        }

        if (transaction.getRequest() == null) {
            throw new RuntimeException(NULL_REQUEST);
        }

        if (transaction.getRequest().getParameters() == null) {
            throw new RuntimeException("Null request params");
        }

        String[] args = transaction.getRequest().getParameters()
                .toValueStringArray();

        logger.debug("args[].length = " + args.length);

        if (args == null || args.length == 0 || args.length < index
                || index > args.length) {

            logger.debug("returning null");
            return null;

        } else {

            logger.debug("Trimming args[" + index + "]");
            return StringUtils.trimToEmpty(args[index]);
        }
    }

    /**
     * makeAndConfigure
     * 
     * @param endpointUrl
     * @return
     */
    public NodeClientService makeAndConfigureNodeClientService(
            String endpointUrl) {

        logger.debug("Getting partner for: " + endpointUrl);
        PartnerIdentity partner = partnerProvider.getByUrl(endpointUrl);

        if (partner == null) {
            throw new RuntimeException("Invalid Partner Uri:" + endpointUrl);
        }

        return nodeClientFactory.makeAndConfigure(partner);

    }

    /**
     * makeEntry creates a new entry to the activity log and debug log
     * 
     * @param result
     * @param message
     * @return
     */
    public ActivityEntry makeEntry(String message) {
        logger.debug(message);
        return new ActivityEntry(message);
    }

    private void write(String pattern, Object[] arguments, boolean info) {
        MessageFormat mf = new MessageFormat(pattern);
        StringBuffer sb = new StringBuffer();
        FieldPosition fp = new FieldPosition(NumberFormat.INTEGER_FIELD);
        if (info) {
            info(mf.format(arguments, sb, fp).toString());
        } else {
            debug(mf.format(arguments, sb, fp).toString());
        }
    }

    protected void validateTransaction(NodeTransaction transaction) {
        if (transaction == null) {
            throw new RuntimeException(NULL_TRANSACTION);
        }

        if (transaction.getCreator() == null
                || StringUtils.isBlank(transaction.getCreator()
                        .getNaasUserName())) {
            throw new RuntimeException(NULL_TRANSACTION + " creator");
        }

        if (StringUtils.isBlank(transaction.getNetworkId())) {
            throw new RuntimeException(NULL_TRANSACTION + " network Id");
        }

        if (transaction.getRequest() == null) {
            throw new RuntimeException(NULL_REQUEST);
        }

        if (transaction.getRequest().getService() == null
                || StringUtils.isBlank(transaction.getRequest().getService()
                        .getName())) {
            throw new RuntimeException("Null service");
        }
    }

    /*
     * 
     * Logging helpers
     */

    public void fatal(String message) {
        logger.error(message);
    }

    public void fatal(Throwable t) {
        logger.error(t.getMessage(), t);
    }

    public void fatal(String message, Throwable t) {
        logger.error(t.getMessage(), t);
    }

    public void error(String message) {
        logger.error(message);
    }

    public void error(Throwable t) {
        logger.error(t.getMessage(), t);
    }

    public void error(String message, Throwable t) {
        logger.error(message, t);
    }

    public void debug(String pattern, Object[] arguments) {
        write(pattern, arguments, false);
    }

    public void info(String message) {
        logger.info(message);
    }

    public void info(String pattern, Object[] arguments) {
        write(pattern, arguments, true);
    }

    public void debug(String message) {
        logger.debug(message);
    }

    public void trace(String message) {
        logger.trace(message);
    }

    public void setNodeClientFactory(
            DualEndpointNodeClientFactory nodeClientFactory) {
        this.nodeClientFactory = nodeClientFactory;
    }

    public void setPartnerProvider(NodePartnerProvider partnerProvider) {
        this.partnerProvider = partnerProvider;
    }

    public Logger getLogger() {
        return logger;
    }

    public void setLogger(Logger logger) {
        this.logger = logger;
    }

    public File getPluginSourceDir() {
        return pluginSourceDir;
    }

    public void setPluginSourceDir(File pluginSourceDir) {
        this.pluginSourceDir = pluginSourceDir;
    }

    /**
     * Should this service be published to ENDS for Node v1.1?
     * 
     * @return
     */
    public Boolean isPublishForEN11() {
        return publishForEN11;
    }

    /**
     * Sets whether this service should be published to ENDS for Node v1.1.
     * 
     * @param publishServices
     */
    public void setPublishForEN11(Boolean publishForNode11) {
        this.publishForEN11 = publishForNode11;
    }

    /**
     * Should this service be published to ENDS for Node v2.0?
     * 
     * @return
     */
    public Boolean isPublishForEN20() {
        return publishForEN20;
    }

    /**
     * Sets whether this service should be published to ENDS for Node v2.0.
     * 
     * @param publishServices
     */
    public void setPublishForEN20(Boolean publishForNode20) {
        this.publishForEN20 = publishForNode20;
    }

}

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

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.NodePartnerProvider;
import com.windsor.node.service.helper.ServiceFactory;
import com.windsor.node.service.helper.client.DualEndpointNodeClientFactory;

/**
 * Base class for Node plugins.
 * 
 * <p>
 * Contains essential attributes for getting plugin configuration from the Node
 * at runtime.
 * </p>
 * 
 * <p>
 * Logs to a plugin-specific log in <nodehome>/log if running within a Node;
 * otherwise relies on the runtime Log4j settings.
 * </p>
 * 
 */
public abstract class BaseWnosPlugin implements InitializingBean {

    /* STRING CONSTANTS */

    public static final String DS_SOURCE = "sourceDs";
    public static final String ARG_HD_DO = "makeHeader";
    public static final String ARG_HD_ORN_NAME = "organizationName";
    public static final String ARG_HD_TITLE = "title";
    public static final String ARG_HD_CONTACT = "contactInfo";
    public static final String ARG_HD_NOTIFS = "notifications";
    public static final String ARG_HD_PAYLOAD_OP = "payloadOperation";

    private static final String NULL_REQUEST = "Null request";
    private static final String NULL_TRANSACTION = "Null transaction";

    protected Logger logger = Logger.getLogger(getClass());

    private Map configurationArguments;
    private Map dataSources;
    private ServiceFactory serviceFactory;
    private List supportedPluginTypes;
    private DualEndpointNodeClientFactory nodeClientFactory;
    private NodePartnerProvider partnerProvider;
    private File pluginSourceDir;

    /**
     * BaseWnosPlugin
     */
    public BaseWnosPlugin() {
        // initialize the local variables
        configurationArguments = new TreeMap();
        dataSources = new TreeMap();
        supportedPluginTypes = new ArrayList();

    }

    /**
     * afterPropertiesSet
     */
    public void afterPropertiesSet() {

        if (serviceFactory == null) {
            throw new RuntimeException("ServiceFactory Not Set");
        }

        if (nodeClientFactory == null) {
            throw new RuntimeException("DualEndpointNodeClientFactory Not Set");
        }

        if (partnerProvider == null) {
            throw new RuntimeException("NodePartnerProvider Not Set");
        }

    }

    /**
     * process must be overidden by the implementing service
     * 
     * @param transaction
     * @return
     */
    public abstract ProcessContentResult process(NodeTransaction transaction);

    /*
     * 
     * Properties
     */

    /**
     * Gets a map of config arguments where the Key is uneditable and the value
     * will be set by the plugin exe
     */
    public Map getConfigurationArguments() {
        return configurationArguments;
    }

    /**
     * Gets a map of data soruces where the Key is uneditable and the value must
     * be set by the plugin exe
     * 
     * @return
     */
    public Map getDataSources() {
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
    public List getSupportedPluginTypes() {
        return supportedPluginTypes;
    }

    /*
     * ElementUtil
     */
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
        logger.fatal(message);
    }

    public void fatal(Throwable t) {
        logger.fatal(t);
    }

    public void fatal(String message, Throwable t) {
        logger.fatal(message, t);
    }

    public void error(String message) {
        logger.error(message);
    }

    public void error(Throwable t) {
        logger.error(t);
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

}
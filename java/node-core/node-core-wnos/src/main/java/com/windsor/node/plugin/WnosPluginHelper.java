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

import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NamedSystemConfigItem;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.ConfigDao;
import com.windsor.node.data.dao.PluginDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.NodePartnerProvider;
import com.windsor.node.service.helper.NotificationHelper;
import com.windsor.node.service.helper.ServiceFactory;
import com.windsor.node.service.helper.client.DualEndpointNodeClientFactory;
import com.windsor.node.util.DataSourceUtil;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.InitializingBean;

import java.io.File;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class WnosPluginHelper implements PluginHelper, InitializingBean {

    /** Logger for this class and subclasses */
    private final Logger logger = LoggerFactory.getLogger(WnosPluginHelper.class);

    private NOSConfig nosConfig;
    private WnosClassLoader classLoader;
    private CompressionService compressionHelper;
    private ConfigDao configDao;
    private PluginDao pluginDao;
    private ServiceFactory serviceFactory;
    private DualEndpointNodeClientFactory nodeClientFactory;
    private NodePartnerProvider partnerProvider;
    private NotificationHelper notificationHelper;

    /**
     * afterPropertiesSet
     */
    public void afterPropertiesSet() {

        if (nosConfig == null) {
            throw new RuntimeException("NosConfig not set");
        }

        if (classLoader == null) {
            throw new RuntimeException("ClassLoader not set");
        }

        if (compressionHelper == null) {
            throw new RuntimeException("CompressionHelper not set");
        }

        if (configDao == null) {
            throw new RuntimeException("ConfigDao not set");
        }

        if (pluginDao == null) {
            throw new RuntimeException("PluginDao not set");
        }

        if (serviceFactory == null) {
            throw new RuntimeException("ServiceFactory not set");
        }

        if (nodeClientFactory == null) {
            throw new RuntimeException("DualEndpointNodeClientFactory not set");
        }

        if (partnerProvider == null) {
            throw new RuntimeException("PartnerProvider Not Set");
        }

    }

    /**
     * savePluginContent
     */
    public void savePluginContent(DataFlow flow, NodeVisit visit, byte[] content) {

        if (flow == null || StringUtils.isBlank(flow.getName())) {
            throw new RuntimeException("Null flow name");
        }

        if (visit == null || visit.getUserAccount() == null
                || StringUtils.isBlank(visit.getUserAccount().getId())) {
            throw new RuntimeException("Null flow name");
        }

        try {

            String flowDirPath = FilenameUtils.concat(nosConfig.getPluginDir()
                    .getAbsolutePath(), flow.getName());

            logger.debug("Testing flow directory: " + flowDirPath);

            File flowPlugDir = new File(flowDirPath);

            if (!flowPlugDir.exists()) {
                FileUtils.forceMkdir(flowPlugDir);
            }

            // Save plugin
            String pluginId = pluginDao.save(flow.getId(), visit
                    .getUserAccount().getId(), content);

            logger.debug("Plugin Id: " + pluginId);

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while uploading plugn: "
                    + ex.getMessage(), ex);
        }

    }

    public File getPluginContentDir(DataFlow flow) {

        if (flow == null || StringUtils.isBlank(flow.getName())) {
            throw new RuntimeException("Null flow name");
        }

        try {

            // FLOW
            String flowDirPath = FilenameUtils.concat(nosConfig.getPluginDir()
                    .getAbsolutePath(), flow.getName());

            logger.debug("Testing flow directory: " + flowDirPath);

            File flowPlugDir = new File(flowDirPath);

            if (!flowPlugDir.exists()) {
                FileUtils.forceMkdir(flowPlugDir);
                logger.debug("Flow dir created: " + flowPlugDir);
            }

            // VERSION
            // Save plugin
            String latestId = pluginDao.getLatestId(flow.getId());
            logger.debug("Latest plugin Id: " + latestId);

            if (StringUtils.isBlank(latestId)) {
                throw new RuntimeException(
                        "No plugins for: "
                                + flow.getName()
                                + ". Upload a plugin before creating services for that flow.");
            }

            String versionPath = FilenameUtils.concat(flowPlugDir
                    .getAbsolutePath(), latestId);
            logger.debug("Version dir: " + versionPath);

            File pluginVersionDir = new File(versionPath);

            if (!pluginVersionDir.exists()) {

                FileUtils.forceMkdir(pluginVersionDir);
                logger.debug("Version dir created: " + pluginVersionDir);

                if (!pluginVersionDir.exists()) {
                    throw new RuntimeException(
                            "Unable to create plugin version dir");
                }

                compressionHelper.unzip(pluginDao.get(latestId),
                        pluginVersionDir.getAbsolutePath());

                logger.debug("Plugin deployed from Db to Fs");

            }

            return pluginVersionDir;

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while getting plugin: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * ProcessContentResult
     */
    public ProcessContentResult processTransaction(NodeTransaction transaction)
    {
        logger.info("Processing transaction: " + transaction);

        if(transaction == null)
        {
            throw new IllegalArgumentException("Transaction not set");
        }

        DataFlow flow = transaction.getFlow();
        logger.info("Flow: " + flow);

        if(transaction.getRequest() == null || transaction.getRequest().getService() == null)
        {
            throw new WinNodeException("This transaction should have never been tagged for processing!");
        }

        DataService service = transaction.getRequest().getService();
        logger.info("Service: " + service);
        logger.info("Executable: " + service.getImplementingClassName());

        // use reflection to get an instance of the base plugin
        // implementation
        BaseWnosPlugin processor = getWnosPlugin(flow, service.getImplementingClassName());
        logger.info("processor: " + processor);

        // Connections
        logger.info("Setting data sources");
        if(transaction.getRequest().getService().getDataSources() != null)
        {
            for(Iterator<?> it = transaction.getRequest().getService().getDataSources().iterator(); it.hasNext();)
            {
                DataProviderInfo provider = (DataProviderInfo)it.next();
                logger.debug("DataProviderInfo: " + provider);

                if(processor.getDataSources().containsKey(provider.getCode()))
                {
                    logger.debug("Setting");

                    processor.getDataSources().remove(provider.getCode());
                    processor.getDataSources().put(provider.getCode(), DataSourceUtil.makeBasicDataSource(provider));
                }
                else
                {
                    logger.debug("Not found");
                }
            }
        }

        // Get list of all args
        logger.info("Getting all sys config args");
        Map<String, String> globalSystemArgs = configDao.getKeyValueMap(true);
        logger.info("Global Args: " + globalSystemArgs);

        // Args
        logger.info("Looping through service args");
        if(transaction.getRequest().getService().getArgs() != null)
        {
            for(Iterator<?> it = transaction.getRequest().getService().getArgs().iterator(); it.hasNext();)
            {
                NamedSystemConfigItem arg = (NamedSystemConfigItem)it.next();

                logger.debug("Checking plugin for argument: " + arg.getKey());

                if(processor.getConfigurationArguments().containsKey(arg.getKey()))
                {
                    String pluginArgKey = arg.getKey();
                    String pluginArgVal = null;
                    String configArgValue = (String)arg.getValue();

                    logger.debug("Found, removing: " + pluginArgKey);
                    processor.getConfigurationArguments().remove(pluginArgKey);

                    logger.debug("Is the service arg a global value");
                    if(arg.isGlobal())
                    {
                        logger.debug("Setting from globals using key: " + configArgValue);
                        if(globalSystemArgs.containsKey(configArgValue))
                        {
                            pluginArgVal = (String)globalSystemArgs.get(configArgValue);
                            logger.debug("Found global val: " + pluginArgVal);
                        }
                        else
                        {
                            logger.error("Global variable no longer exists: " + configArgValue);
                            logger.error("Sign of invalid database constraints: Service_Args FK");
                            throw new IllegalArgumentException("Service is configured with an invalid global variable.");
                        }
                    }
                    else
                    {
                        logger.debug("Setting raw");
                        pluginArgVal = configArgValue;
                    }
                    logger.debug("Setting: [" + pluginArgKey + "] = " + pluginArgVal);
                    processor.getConfigurationArguments().put(pluginArgKey, pluginArgVal);
                }
            }
        }

        logger.info("Setting service factory: " + serviceFactory);
        processor.setServiceFactory(serviceFactory);

        logger.info("Setting node client factory: " + nodeClientFactory);
        processor.setNodeClientFactory(nodeClientFactory);

        logger.info("Setting partner dao: " + nodeClientFactory);
        processor.setPartnerProvider(partnerProvider);

        logger.info("Setting notificationHelper: " + notificationHelper);
        processor.setNotificationHelper(notificationHelper);

        // This will throw an exception if not all the required args are set
        try {
            processor.afterPropertiesSet();
        } catch(Exception exception) {
            logger.warn("Exception thrown after setting plugin properties: " + exception.getMessage(), exception);
            throw new RuntimeException(exception.getMessage(), exception);
        }

        logger.info("Plugin configured. Processing transaction: " + transaction);
        ProcessContentResult result = processor.process(transaction);

        if (processor instanceof DisposableBean) {
            DisposableBean disposableBean = (DisposableBean) processor;
            try {
                logger.info("Starting to clean up plugin");
                disposableBean.destroy();
                logger.info("Finished cleaning up plugin");
            } catch (Exception e) {
                logger.error("Error cleaning up plugin", e);
            }
        } else {
            logger.warn("No clean up defined for plugin: " + processor.getClass().getSimpleName());
        }
        
        //So plugins no longer have to set this
        if(result != null && result.getPaginatedContentIndicator() == null)
        {
            result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction.getRequest()
                                                                                                                                    .getPaging()
                                                                                                                                    .getCount(), true));
        }
        return result;

    }

    /**
     * getWnosPlugin
     */
    public BaseWnosPlugin getWnosPlugin(DataFlow flow, String implementingClassName)
    {
        //2014-04-07 Hopefully this class won't need rewriting, changing classloader to cache plugin by version
        logger.debug("Implementor: " + implementingClassName);
        logger.debug("Flow: " + flow);

        if(flow == null || StringUtils.isBlank(flow.getName()))
        {
            throw new RuntimeException("Null flow name");
        }

        if(StringUtils.isBlank(implementingClassName))
        {
            throw new IllegalArgumentException("Null implementingClassName");
        }

        File pluginVersionDir = getPluginContentDir(flow);
        logger.debug("pluginVersionDir: " + pluginVersionDir);

        BaseWnosPlugin result = (BaseWnosPlugin) classLoader.getPluginInstance(pluginVersionDir, implementingClassName);

        result.setPluginSourceDir(pluginVersionDir);

        return result;
    }

    /**
     * getWnosPluginImplementors
     */
    public List<String> getWnosPluginImplementors(DataFlow flow) {

        logger.debug("Flow: " + flow);

        if (flow == null || StringUtils.isBlank(flow.getName()))
        {
            throw new IllegalArgumentException("Parameter DataFlow flow cannot be null or have an empty name.");
        }

        File pluginVersionDir = getPluginContentDir(flow);
        logger.debug("pluginVersionDir: " + pluginVersionDir);

        return classLoader.getBasePluginImplementors(pluginVersionDir);

    }

    public PluginMetaData getPluginMetaData(DataFlow flow)
    {
        logger.debug("Flow: " + flow);
        if (flow == null || StringUtils.isBlank(flow.getName()))
        {
            throw new IllegalArgumentException("Parameter DataFlow flow cannot be null or have an empty name.");
        }
        File pluginVersionDir = getPluginContentDir(flow);
        logger.debug("pluginVersionDir: " + pluginVersionDir);

        return classLoader.getPluginMetaData(pluginVersionDir);
    }

    @Override
    public List<PluginServiceImplementorDescriptor> getPluginServiceImplementorDescriptors(DataFlow flow)
    {
        logger.debug("Flow: " + flow);
        if (flow == null || StringUtils.isBlank(flow.getName()))
        {
            throw new IllegalArgumentException("Parameter DataFlow flow cannot be null or have an empty name.");
        }
        File pluginVersionDir = getPluginContentDir(flow);
        logger.debug("pluginVersionDir: " + pluginVersionDir);

        return classLoader.getPluginServiceImplementorDescriptors(pluginVersionDir);
    }

    public void setNosConfig(NOSConfig nosConfig) {
        this.nosConfig = nosConfig;
    }

    public void setClassLoader(WnosClassLoader classLoader) {
        this.classLoader = classLoader;
    }

    public void setCompressionHelper(CompressionService compressionHelper) {
        this.compressionHelper = compressionHelper;
    }

    public void setConfigDao(ConfigDao configDao) {
        this.configDao = configDao;
    }

    public void setPluginDao(PluginDao pluginDao) {
        this.pluginDao = pluginDao;
    }

    public void setServiceFactory(ServiceFactory serviceFactory) {
        this.serviceFactory = serviceFactory;
    }

    public void setNodeClientFactory(
            DualEndpointNodeClientFactory nodeClientFactory) {
        this.nodeClientFactory = nodeClientFactory;
    }

    public void setPartnerProvider(NodePartnerProvider partnerProvider) {
        this.partnerProvider = partnerProvider;
    }

    public WnosClassLoader getClassLoader() {
        return classLoader;
    }

    public void setNotificationHelper(NotificationHelper notificationHelper)
    {
        this.notificationHelper = notificationHelper;
    }

    public NotificationHelper getNotificationHelper()
    {
        return notificationHelper;
    }

}

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
 * 
 */
package com.windsor.node.plugin.ends2;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.SimpleContent;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.data.dao.jdbc.JdbcFlowDao;
import com.windsor.node.data.dao.jdbc.JdbcServiceDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.WnosPluginHelper;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.VelocityHelperImpl;
import com.windsor.node.service.Ends2Service;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * Implements v.20 of the Exchange Network Discovery Services specification for
 * the &quot;GetServices&quot; method.
 * 
 * @since OpenNode2 v1.1.4
 * 
 */
public class Ends2GetServicesQueryProcessor extends BaseWnosPlugin implements
        InitializingBean, Ends2Service {

    public static final String FLOW_NAME = "ENDS_v20";

    public static final String SERVICE_NAME = "GetServices";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_ID = "nodeId";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_NAME = "nodeName";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_ADDRESS = "nodeAddress";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_ORG_ID = "orgIdentifier";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_CONTACT = "nodeContact";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_VERSION = "nodeVersion";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_DEPLOYMENT_TYPE = "deploymentType";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NODE_STATUS = "nodeStatus";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_BOUNDING_EAST = "boundingCoordinateEast";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_BOUNDING_NORTH = "boundingCoordinateNorth";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_BOUNDING_SOUTH = "boundingCoordinateSouth";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_BOUNDING_WEST = "boundingCoordinateWest";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_SERVICE_LIST = "serviceList";

    /** Velocity template name. */
    protected static final String TEMPLATE_NAME = "NetworkNodeDetails.vm";

    private static final String OUTFILE_BASE = "NetworkNodeDetails_";
    private static final String XML_EXT = ".xml";
    private static final String DELIM = ": ";

    /* helpers */
    private WnosPluginHelper pluginHelper;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;

    private String endpointUrl;
    private String tempFilePath;
    private String tempFileName;

    public Ends2GetServicesQueryProcessor() {

        super();
        getSupportedPluginTypes().add(ServiceType.QUERY);

        debug("Ends2GetServicesQueryProcessor instantiated.");
    }

    public void afterPropertiesSet() {

        pluginHelper = (WnosPluginHelper) getServiceFactory().makeService(
                WnosPluginHelper.class);

        if (pluginHelper == null) {
            throw new RuntimeException("Unable to obtain WnosPluginHelper");
        }

        settingService = (SettingServiceProvider) getServiceFactory()
                .makeService(SettingServiceProvider.class);

        if (settingService == null) {
            throw new RuntimeException(
                    "Unable to obtain SettingServiceProvider");
        }

        idGenerator = (IdGenerator) getServiceFactory().makeService(
                IdGenerator.class);

        if (idGenerator == null) {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#process(com.windsor.node.common
     * .domain.NodeTransaction)
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

            /* set up template parameters from the Node's runtime environment. */
            result.getAuditEntries().add(
                    makeEntry("Getting Node and Service info for ENDS2..."));

            NOSConfig nosConfig = (NOSConfig) getServiceFactory().makeService(
                    NOSConfig.class);
            NAASConfig naasConfig = (NAASConfig) getServiceFactory()
                    .makeService(NAASConfig.class);

            ServiceDao serviceDao = (ServiceDao) getServiceFactory()
                    .makeService(JdbcServiceDao.class);

            FlowDao flowDao = (FlowDao) getServiceFactory().makeService(
                    JdbcFlowDao.class);

            SimpleContent content = getServices(naasConfig, nosConfig,
                    serviceDao, flowDao, pluginHelper, getPluginSourceDir(),
                    settingService.getTempDir());

            result.getAuditEntries().add(makeEntry("Complete"));

            /* return as byte array */
            Document doc = new Document();

            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(getTempFilePath()));
            doc.setContent(content.getContent());

            /* MARKER */
            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        return result;
    }

    public SimpleContent getServices(NAASConfig naasConfig,
            NOSConfig nosConfig, ServiceDao serviceDao, FlowDao flowDao,
            WnosPluginHelper pluginHelper, File pluginSourceDir, File tempDir) {

        SimpleContent content = new SimpleContent();

        VelocityHelper velocityHelper = new VelocityHelperImpl();
        velocityHelper.configure(pluginSourceDir.getAbsolutePath());

        logger.debug("Getting Node info for ENDS2...");
        Map<String, Object> templateArgs = makeTemplateArgs(nosConfig,
                naasConfig);

        List<DataService> services;

        try {

            services = getActivePublishedServiceData(pluginHelper, serviceDao,
                    flowDao);

            logger.debug("Getting service metadata for ENDS2...");
            templateArgs.put(TEMPLATE_SERVICE_LIST, services);

            velocityHelper.setTemplateArgs(templateArgs);

            /* set up output file */
            String outFileName = OUTFILE_BASE
                    + templateArgs.get(TEMPLATE_NODE_ID) + XML_EXT;

            setTempFilePath(FilenameUtils.concat(tempDir.getAbsolutePath(),
                    outFileName));

            /* create output file by merging service data with template */
            logger.debug("Generating " + outFileName + " in "
                    + tempDir.getAbsolutePath() + "...");

            velocityHelper.merge(TEMPLATE_NAME, getTempFilePath());

            content.setContent(FileUtils.readFileToByteArray(new File(
                    getTempFilePath())));

        } catch (InstantiationException e) {

            throw new RuntimeException(e);

        } catch (IllegalAccessException e) {

            throw new RuntimeException(e);

        } catch (ClassNotFoundException e) {

            throw new RuntimeException(e);

        } catch (IOException e) {

            throw new RuntimeException(e);
        }

        return content;
    }

    protected List<DataService> getActivePublishedServiceData(
            WnosPluginHelper pHelper, ServiceDao serviceDao, FlowDao flowDao)
            throws InstantiationException, IllegalAccessException,
            ClassNotFoundException {

        List<DataService> services = new ArrayList<DataService>();

        /* get active services from Node metadata db */
        for (DataService service : serviceDao.getServicesForEnds2()) {

            DataFlow flow = flowDao.get(service.getFlowId());

            BaseWnosPlugin plugin = pHelper.getWnosPlugin(flow, service
                    .getImplementingClassName());

            if (plugin.isPublishForEN11() || plugin.isPublishForEN20()) {

                List<DataServiceRequestParameter> params = plugin
                        .getServiceRequestParamSpecs(service.getName());
                /*
                 * for some service types, we need to break them into individual
                 * instances for each EN type.
                 */
                if (service.getType().equals(ServiceType.QUERY_OR_SOLICIT)
                        || service.getType().equals(
                                ServiceType.QUERY_OR_SOLICIT_OR_EXECUTE)) {

                    if (null != params) {
                        service.setRequestParams(params);
                    }

                    /* don't change the original! */
                    DataService qService = copyDataService(service);
                    qService.setType(ServiceType.QUERY);
                    services.add(qService);

                    DataService sService = copyDataService(service);
                    sService.setType(ServiceType.SOLICIT);

                    services.add(sService);

                    if (service.getType().equals(
                            ServiceType.QUERY_OR_SOLICIT_OR_EXECUTE)) {

                        DataService eService = copyDataService(service);
                        eService.setType(ServiceType.EXECUTE);
                        services.add(eService);
                    }

                } else {

                    /*
                     * get parameters for each service from the implementor and
                     * set them in the service
                     */
                    if (null != params) {
                        service.setRequestParams(params);
                    }

                    services.add(service);
                }
            }
        }

        return services;
    }

    protected Map<String, Object> makeTemplateArgs(NOSConfig nosConfig,
            NAASConfig naasConfig) {

        logger.debug("Assembling template args (other than service data)...");
        Map<String, Object> templateArgs = new HashMap<String, Object>();

        logger.debug(TEMPLATE_NODE_ID + DELIM + naasConfig.getNodeId());
        templateArgs.put(TEMPLATE_NODE_ID, naasConfig.getNodeId());

        logger.debug(TEMPLATE_NODE_NAME + DELIM + nosConfig.getNodeName());
        templateArgs.put(TEMPLATE_NODE_NAME, nosConfig.getNodeName());

        logger.debug(TEMPLATE_ORG_ID + DELIM + nosConfig.getOrgIdentifier());
        templateArgs.put(TEMPLATE_ORG_ID, nosConfig.getOrgIdentifier());

        logger.debug(TEMPLATE_NODE_CONTACT + DELIM
                + nosConfig.getNodeAdminEmail());
        templateArgs.put(TEMPLATE_NODE_CONTACT, nosConfig.getNodeAdminEmail());

        /* This is hard-wired to the Node's v2 enpoint */
        templateArgs.put(TEMPLATE_NODE_VERSION, "2.0");

        logger.debug(TEMPLATE_DEPLOYMENT_TYPE + DELIM
                + nosConfig.getDeploymentType());
        templateArgs.put(TEMPLATE_DEPLOYMENT_TYPE, nosConfig
                .getDeploymentType());
        templateArgs.put(TEMPLATE_NODE_ADDRESS, nosConfig
                .getPublicV2endpointUrl());

        /* ENDS xsd specifies different values than the EN20 xsd */
        templateArgs.put(TEMPLATE_NODE_STATUS, "Operational");

        logger.debug(TEMPLATE_BOUNDING_EAST + DELIM
                + nosConfig.getBoundingCoordinateEast());
        templateArgs.put(TEMPLATE_BOUNDING_EAST, nosConfig
                .getBoundingCoordinateEast());

        logger.debug(TEMPLATE_BOUNDING_NORTH + DELIM
                + nosConfig.getBoundingCoordinateNorth());
        templateArgs.put(TEMPLATE_BOUNDING_NORTH, nosConfig
                .getBoundingCoordinateNorth());

        logger.debug(TEMPLATE_BOUNDING_SOUTH + DELIM
                + nosConfig.getBoundingCoordinateSouth());
        templateArgs.put(TEMPLATE_BOUNDING_SOUTH, nosConfig
                .getBoundingCoordinateSouth());

        logger.debug(TEMPLATE_BOUNDING_WEST + DELIM
                + nosConfig.getBoundingCoordinateWest());
        templateArgs.put(TEMPLATE_BOUNDING_WEST, nosConfig
                .getBoundingCoordinateWest());

        return templateArgs;
    }

    private DataService copyDataService(DataService source) {
        DataService copy = new DataService();

        copy.setActive(source.isActive());
        copy.setArgs(source.getArgs());
        copy.setDataSources(source.getDataSources());
        copy.setFlowId(source.getFlowId());
        copy.setFlowName(source.getFlowName());
        /* skip Id, as it's irrelevant in this context and should be unique */
        copy.setImplementingClassName(source.getImplementingClassName());
        /*
         * skip ModifiedById and ModifiedOn, as they're irrelevant in this
         * context
         */
        copy.setName(source.getName());
        copy.setRequestParams(source.getRequestParams());
        copy.setSupportedTypes(source.getSupportedTypes());
        copy.setType(source.getType());

        return copy;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(com
     * .windsor.node.common.domain.EndpointVersionType)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    public String getEndpointUrl() {
        return endpointUrl;
    }

    public void setEndpointUrl(String endpointUrl) {
        this.endpointUrl = endpointUrl;
    }

    public IdGenerator getIdGenerator() {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public String getTempFilePath() {
        return tempFilePath;
    }

    public void setTempFilePath(String tempFilePath) {
        this.tempFilePath = tempFilePath;
    }

    public String getTempFileName() {
        return tempFileName;
    }

    public void setTempFileName(String tempFileName) {
        this.tempFileName = tempFileName;
    }
}

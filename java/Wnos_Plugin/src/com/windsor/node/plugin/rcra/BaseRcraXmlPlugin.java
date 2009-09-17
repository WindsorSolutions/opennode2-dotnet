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

package com.windsor.node.plugin.rcra;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseRcraXmlPlugin extends BaseWnosPlugin {

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_RCRA_INFO_USER_ID = "RCRAInfoUserID";

    /**
     * Index position for schedule argument (number of handler ids in top-level
     * query - for dev and testing convenience).
     */
    public static final int HANDLER_LIMIT_ARG_INDEX = 0;

    /** Velocity template variable name. */
    public static final String TEMPLATE_AUTHOR = "author";

    /** Velocity template variable name. */
    public static final String TEMPLATE_CONTACT_INFO = "contactInfo";

    /** Velocity template variable name. */
    public static final String TEMPLATE_MAKE_HEADER = "makeHeader";

    /** Velocity template variable name. */
    public static final String TEMPLATE_NOTIFICATION = "notification";

    /** Velocity template variable name. */
    public static final String TEMPLATE_PAYLOAD_OPERATION = "payloadOperation";

    /** Velocity template variable name. */
    public static final String TEMPLATE_PROVIDING_ORG = "providingOrg";

    /** Velocity template variable name. */
    public static final String TEMPLATE_RCRA_INFO_STATE_CODE = "rcraInfoStateCode";

    /** Velocity template variable name. */
    public static final String TEMPLATE_RCRA_INFO_USER_ID = "rcraInfoUserId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_TITLE = "title";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_HANDLER_LIMIT = "handlerLimit";

    private static final String XML_EXT = ".xml";

    /*
     * Helpers
     */
    private VelocityHelper velocityHelper = new JdbcVelocityHelper();
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private String tempFilePath;
    private String tempFileName;
    private DataSource pluginDataSource;

    /* VTL template variables */
    private String author;
    private String contactInfo;
    private String makeHeader;
    private String notification;
    private String payloadOperation;
    private String providingOrg;
    private String rcraInfoStateCode;
    private String rcraInfoUserId;
    private String title;

    /* is one is private, for testing only, not published. */
    private String handlerLimit;

    public BaseRcraXmlPlugin() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_ADD_HEADER, "");
        getConfigurationArguments().put(ARG_HEADER_NOTIFS, "");
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_STATE_CODE, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_USER_ID, "");
        getConfigurationArguments().put(ARG_HEADER_TITLE, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("BaseRcraXmlPlugin instantiated.");

    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        // make sure the run time args are set
        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the data sources are set
        if (null == pluginDataSource) {
            if (null == getDataSources().get(ARG_DS_SOURCE)) {

                throw new RuntimeException("Source data source not set");

            } else {
                pluginDataSource = (DataSource) getDataSources().get(
                        ARG_DS_SOURCE);
            }
        }

        debug("Validating helpers");

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

        compressionService = (CompressionService) getServiceFactory()
                .makeService(CompressionService.class);

        if (compressionService == null) {
            throw new RuntimeException("Unable to obtain CompressionService");
        }

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_ADD_HEADER)) {
            throw new RuntimeException(ARG_ADD_HEADER + " not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_RCRA_INFO_STATE_CODE)) {
            throw new RuntimeException(ARG_RCRA_INFO_STATE_CODE + " not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_RCRA_INFO_USER_ID)) {
            throw new RuntimeException(ARG_RCRA_INFO_USER_ID + " not set");
        }

        debug("Plugin validated");

    }

    protected ProcessContentResult generateXmlFile(NodeTransaction transaction,
            String templateName, String outfileBaseName) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {
            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

            setServiceArgs();

            String docId = idGenerator.createId();

            handlerLimit = getOptionalValueFromTransactionArgs(transaction,
                    HANDLER_LIMIT_ARG_INDEX);
            debug("handlerLimit: " + handlerLimit);

            setTemplateArgs(docId);

            result.getAuditEntries().add(makeEntry("Executing request..."));

            setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                    .getAbsolutePath(), outfileBaseName + docId + XML_EXT));

            velocityHelper.merge(templateName, getTempFilePath());

            result.getAuditEntries().add(makeEntry("Xml file generated"));

            result.getAuditEntries().add(makeEntry("Compressing results..."));

            Document doc = compressOutput(transaction);

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

    protected File getResultFile() throws IOException {

        File resultFile = new File(getTempFileName());

        if (!resultFile.exists()) {
            throw new IOException("Result file not found: " + getTempFileName());
        }

        return resultFile;

    }

    private void setServiceArgs() {

        /* required args */
        if (null == makeHeader) {
            makeHeader = (String) getRequiredConfigValueAsString(ARG_ADD_HEADER);
            debug("add header: " + makeHeader);
        }

        boolean doHeader = makeHeader.equalsIgnoreCase("true");

        if (null == rcraInfoStateCode) {
            rcraInfoStateCode = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_STATE_CODE);
            debug("rcraInfoStateCode: " + rcraInfoStateCode);
        }

        if (null == rcraInfoUserId) {
            rcraInfoUserId = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_USER_ID);
            debug("rcraInfoUserId: " + rcraInfoUserId);
        }
        /* optional - header elements */
        contactInfo = (String) getConfigValueAsString(ARG_HEADER_CONTACT_INFO,
                doHeader);
        debug("contactInfo: " + contactInfo);

        author = contactInfo;

        notification = (String) getConfigValueAsString(ARG_HEADER_NOTIFS,
                doHeader);
        debug("notification: " + notification);

        payloadOperation = (String) getConfigValueAsString(
                ARG_HEADER_PAYLOAD_OP, doHeader);
        debug("payloadOperation: " + payloadOperation);

        providingOrg = (String) getConfigValueAsString(ARG_HEADER_ORG_NAME,
                doHeader);
        debug("providingOrg: " + providingOrg);

        title = (String) getConfigValueAsString(ARG_HEADER_TITLE, doHeader);
        debug("title: " + title);

        velocityHelper.configure(pluginDataSource, getPluginSourceDir()
                .getAbsolutePath());

        debug("Finished setting service configuration arguments");
    }

    private void setTemplateArgs(String docId) {

        velocityHelper.setTemplateArg(TEMPLATE_HANDLER_LIMIT, handlerLimit);

        velocityHelper.setTemplateArg(TEMPLATE_AUTHOR, contactInfo);

        velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, contactInfo);

        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, makeHeader);

        velocityHelper.setTemplateArg(TEMPLATE_NOTIFICATION, notification);

        velocityHelper.setTemplateArg(TEMPLATE_PAYLOAD_OPERATION,
                payloadOperation);

        velocityHelper.setTemplateArg(TEMPLATE_PROVIDING_ORG, providingOrg);

        velocityHelper.setTemplateArg(TEMPLATE_RCRA_INFO_STATE_CODE,
                rcraInfoStateCode);

        velocityHelper.setTemplateArg(TEMPLATE_RCRA_INFO_USER_ID,
                rcraInfoUserId);

        velocityHelper.setTemplateArg(TEMPLATE_TITLE, title);

        velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

        debug("Finished setting Velocity template arguments");
    }

    private Document compressOutput(NodeTransaction transaction)
            throws IOException {

        Document doc = new Document();

        if (transaction.getRequest().getType() != RequestType.QUERY) {

            String zippedFilePath = getCompressionService().zip(
                    getTempFilePath());
            debug("Zipped result: " + zippedFilePath);
            doc.setType(CommonContentType.ZIP);

            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));

            doc.setContent(FileUtils.readFileToByteArray(new File(
                    zippedFilePath)));

        } else {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(getTempFilePath()));
            doc.setContent(FileUtils.readFileToByteArray(new File(
                    getTempFilePath())));
        }

        return doc;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public IdGenerator getIdGenerator() {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

    public CompressionService getCompressionService() {
        return compressionService;
    }

    public void setCompressionService(CompressionService compressionService) {
        this.compressionService = compressionService;
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

    public String getContactInfo() {
        return contactInfo;
    }

    public void setContactInfo(String contactInfo) {
        this.contactInfo = contactInfo;
    }

    public String getMakeHeader() {
        return makeHeader;
    }

    public void setMakeHeader(String makeHeader) {
        this.makeHeader = makeHeader;
    }

    public String getNotification() {
        return notification;
    }

    public void setNotification(String notification) {
        this.notification = notification;
    }

    public String getPayloadOperation() {
        return payloadOperation;
    }

    public void setPayloadOperation(String payloadOperation) {
        this.payloadOperation = payloadOperation;
    }

    public String getProvidingOrg() {
        return providingOrg;
    }

    public void setProvidingOrg(String providingOrg) {
        this.providingOrg = providingOrg;
    }

    public String getRcraInfoStateCode() {
        return rcraInfoStateCode;
    }

    public void setRcraInfoStateCode(String rcraInfoStateCode) {
        this.rcraInfoStateCode = rcraInfoStateCode;
    }

    public String getRcraInfoUserId() {
        return rcraInfoUserId;
    }

    public void setRcraInfoUserId(String rcraInfoUserId) {
        this.rcraInfoUserId = rcraInfoUserId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    protected VelocityHelper getVelocityHelper() {
        return velocityHelper;
    }

    protected void setVelocityHelper(VelocityHelper velocityHelper) {
        this.velocityHelper = velocityHelper;
    }

    public DataSource getPluginDataSource() {
        return pluginDataSource;
    }

    public void setPluginDataSource(DataSource pluginDataSource) {
        this.pluginDataSource = pluginDataSource;
    }

}

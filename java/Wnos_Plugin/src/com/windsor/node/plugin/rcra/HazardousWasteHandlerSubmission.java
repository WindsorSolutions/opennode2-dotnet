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

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
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

public class HazardousWasteHandlerSubmission extends BaseWnosPlugin {

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_CONTACT_INFO = "Contact Info";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_MAKE_HEADER = "MakeHeader";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_NOTIFICATION = "Notification";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_PAYLOAD_OPERATION = "PayloadOperation";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_PROVIDING_ORG = "ProvidingOrg";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_RCRA_INFO_USER_ID = "RCRAInfoUserID";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_SCHEMA_REFERENCE = "SchemaReference";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_TITLE = "Title";

    /**
     * Index position for schedule argument (number of handler ids in top-level
     * query - for dev and testing convenience).
     */
    public static final int HANDLER_LIMIT_ARG_INDEX = 0;

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
    public static final String TEMPLATE_SCHEMA_REFERENCE = "schemaReference";

    /** Velocity template variable name. */
    public static final String TEMPLATE_TITLE = "title";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_HANDLER_LIMIT = "handlerLimit";

    /** Velocity template name. */
    public static final String TEMPLATE_NAME = "RCRA_Handler.vm";

    private static final String OUTFILE = "RCRA_Handler_";
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

    /* VTL template variables */
    private String contactInfo;
    private String makeHeader;
    private String notification;
    private String payloadOperation;
    private String providingOrg;
    private String rcraInfoStateCode;
    private String rcraInfoUserId;
    private String schemaReference;
    private String title;
    private String handlerLimit;

    public HazardousWasteHandlerSubmission() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_MAKE_HEADER, "");
        getConfigurationArguments().put(ARG_NOTIFICATION, "");
        getConfigurationArguments().put(ARG_PAYLOAD_OPERATION, "");
        getConfigurationArguments().put(ARG_PROVIDING_ORG, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_STATE_CODE, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_USER_ID, "");
        getConfigurationArguments().put(ARG_SCHEMA_REFERENCE, "");
        getConfigurationArguments().put(ARG_TITLE, "");

        debug("Setting internal data source list");
        getDataSources().put(DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("HazardousWasteHandlerSubmission instantiated.");

    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        // make sure the run time args are set
        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the data sources are set
        if (!getDataSources().containsKey(DS_SOURCE)) {
            throw new RuntimeException("Source data source not set");
        }

        contactInfo = (String) getRequiredConfigValueAsString(ARG_CONTACT_INFO);
        debug("contactInfo: " + contactInfo);

        makeHeader = (String) getRequiredConfigValueAsString(ARG_MAKE_HEADER);
        debug("makeHeader: " + makeHeader);

        notification = (String) getRequiredConfigValueAsString(ARG_NOTIFICATION);
        debug("notification: " + notification);

        payloadOperation = (String) getRequiredConfigValueAsString(ARG_PAYLOAD_OPERATION);
        debug("payloadOperation: " + payloadOperation);

        providingOrg = (String) getRequiredConfigValueAsString(ARG_PROVIDING_ORG);
        debug("providingOrg: " + providingOrg);

        rcraInfoStateCode = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_STATE_CODE);
        debug("rcraInfoStateCode: " + rcraInfoStateCode);

        rcraInfoUserId = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_USER_ID);
        debug("rcraInfoUserId: " + rcraInfoUserId);

        schemaReference = (String) getRequiredConfigValueAsString(ARG_SCHEMA_REFERENCE);
        debug("schemaReference: " + schemaReference);

        title = (String) getRequiredConfigValueAsString(ARG_TITLE);
        debug("title: " + title);

        velocityHelper.configure((DataSource) getDataSources().get(DS_SOURCE),
                getPluginSourceDir().getAbsolutePath());

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

        debug("Finished validating property set");

    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            /*
             * 
             * ARGUMENTS
             */
            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

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

            velocityHelper.setTemplateArg(TEMPLATE_SCHEMA_REFERENCE,
                    schemaReference);

            velocityHelper.setTemplateArg(TEMPLATE_TITLE, title);

            handlerLimit = getOptionalValueFromTransactionArgs(transaction,
                    HANDLER_LIMIT_ARG_INDEX);
            debug("handlerLimit: " + handlerLimit);

            if (null != handlerLimit) {
                velocityHelper.setTemplateArg(TEMPLATE_HANDLER_LIMIT,
                        handlerLimit);
            }

            String docId = idGenerator.createId();

            velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

            /*
             * 
             * EXECUTE
             */
            result.getAuditEntries().add(makeEntry("Executing request..."));

            setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                    .getAbsolutePath(), OUTFILE + docId + XML_EXT));

            velocityHelper.merge(TEMPLATE_NAME, getTempFilePath());

            result.getAuditEntries().add(makeEntry("Complete"));

            /*
             * 
             * COMPRESSION
             */

            Document doc = new Document();

            if (transaction.getRequest().getType() != RequestType.QUERY) {

                result.getAuditEntries().add(
                        makeEntry("Compressing results..."));
                String zippedFilePath = getCompressionService().zip(
                        getTempFilePath());
                result.getAuditEntries().add(
                        makeEntry("Result: " + zippedFilePath));
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

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            /*
             * 
             * SAVE RESULTS
             */
            result.getAuditEntries().add(
                    makeEntry("Recorded document submission."));

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

    public String getSchemaReference() {
        return schemaReference;
    }

    public void setSchemaReference(String schemaReference) {
        this.schemaReference = schemaReference;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getHandlerLimit() {
        return handlerLimit;
    }

    public void setHandlerLimit(String handlerLimit) {
        this.handlerLimit = handlerLimit;
    }

}
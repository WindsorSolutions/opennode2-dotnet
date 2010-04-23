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

package com.windsor.node.plugin.uic10;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.joda.time.DateTime;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class UICGetDeleteInsertSubmission extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "UICGetDeleteInsertSubmission";
    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_AUTHOR = "Author";

    /**
     * Optional runtime argument, set in service configuration.
     */
    public static final String ARG_CONTACT_INFO = "Contact Info";

    /**
     * Index for schedule parameter
     */
    public static final int PARAM_ORG_ID = 0;

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_ORG_ID = "orgId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_AUTHOR = "author";

    /** Velocity template variable name. */
    public static final String TEMPLATE_CONTACT_INFO = "contactInfo";

    /**
     * Velocity template variable name - this one hard-coded in
     * setTemplateArgs()
     */
    public static final String TEMPLATE_MAKE_HEADER = "makeHeader";

    private static final String TEMPLATE_NAME = "UIC_Delete-Insert.vm";
    private static final String OUTFILE_BASE_NAME = "UIC_";
    private static final String XML_EXT = ".xml";
    private static final String NOT_SET = " not set";

    /*
     * Helpers
     */
    private VelocityHelper velocityHelper;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private String tempFilePath;
    private String tempFileName;
    private DataSource pluginDataSource;

    /* VTL template variables */
    private String author;
    private String makeHeader = "true";
    private String contactInfo;
    private String orgId;

    public UICGetDeleteInsertSubmission() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_AUTHOR, "");
        getConfigurationArguments().put(ARG_CONTACT_INFO, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        velocityHelper = new JdbcVelocityHelper();

        debug("BaseEisXmlPlugin instantiated.");

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

        if (!getConfigurationArguments().containsKey(ARG_AUTHOR)) {
            throw new RuntimeException(ARG_AUTHOR + NOT_SET);
        }

        if (!getConfigurationArguments().containsKey(ARG_CONTACT_INFO)) {
            throw new RuntimeException(ARG_CONTACT_INFO + NOT_SET);
        }

        debug("Plugin validated");
    }

    protected void validateTransaction(NodeTransaction transaction) {

        super.validateTransaction(transaction);

        if (transaction.getRequest().getParameters().size() != 1) {

            throw new RuntimeException(
                    "Only 1 request/schedule parameter expected, "
                            + transaction.getRequest().getParameters().size()
                            + " found.");
        }
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        result.getAuditEntries().add(makeEntry("Validating transaction..."));
        validateTransaction(transaction);

        debug("Processing transaction...");

        try {
            
            setOrgId((String) transaction.getRequest().getParameters().get(0));

            setServiceArgs();

            String docId = idGenerator.createId();

            velocityHelper.configure(pluginDataSource, getPluginSourceDir()
                    .getAbsolutePath());

            setTemplateArgs(docId);

            result.getAuditEntries().add(makeEntry("Executing request..."));

            setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                    .getAbsolutePath(), createOutFileName()));

            result.getAuditEntries().add(
                    makeEntry("generating " + getTempFilePath()));
            
            velocityHelper.merge(TEMPLATE_NAME, getTempFilePath());

            result.getAuditEntries().add(makeEntry("generated Xml file "));

            result.getAuditEntries().add(makeEntry("Compressing results..."));

            Document doc = compressOutput(getTempFilePath());

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    private String createOutFileName() {

        DateTime dt = new DateTime();
        int year = dt.getYear();
        int month = dt.getMonthOfYear();
        int quarter;

        float f = month / 4;

        if (f <= 3) {
            quarter = 1;
        } else if (f <= 6) {
            quarter = 2;
        } else if (f <= 9) {
            quarter = 3;
        } else {
            quarter = 4;
        }

        String s = OUTFILE_BASE_NAME + getOrgId() + "_Q" + quarter + "_" + year
                + XML_EXT;

        return s;
    }

    private void setServiceArgs() {

        /* required header elements */
        if (StringUtils.isBlank(author)) {
            author = (String) getRequiredConfigValueAsString(ARG_AUTHOR);
        }
        debug("authorName: " + author);

        /* optional element */
        if (StringUtils.isBlank(contactInfo)) {
            contactInfo = (String) getOptionalConfigValueAsString(ARG_CONTACT_INFO);
        }
        debug("contactInfo: " + contactInfo);

        debug("Finished setting service configuration arguments");
    }

    private void setTemplateArgs(String docId) {

        velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

        velocityHelper.setTemplateArg(TEMPLATE_ORG_ID, getOrgId());

        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, getMakeHeader());

        velocityHelper.setTemplateArg(TEMPLATE_AUTHOR, getAuthor());

        velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, getcontactInfo());

        debug("Finished setting Velocity template arguments");
    }

    private Document compressOutput(String fileNameToZip) throws IOException {

        Document doc = new Document();

        String zippedFilePath = getCompressionService().zip(fileNameToZip);

        debug("Zipped result: " + zippedFilePath);
        doc.setType(CommonContentType.ZIP);

        doc.setDocumentName(FilenameUtils.getName(zippedFilePath));

        doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));

        return doc;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {

        List<DataServiceRequestParameter> list = null;

        if (serviceName.equalsIgnoreCase(SERVICE_NAME)) {

            list = new ArrayList<DataServiceRequestParameter>();

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(TEMPLATE_ORG_ID);
            list.add(param);
        }

        return list;
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

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getcontactInfo() {
        return contactInfo;
    }

    public void setcontactInfo(String contactInfo) {
        this.contactInfo = contactInfo;
    }

    public String getMakeHeader() {
        return makeHeader;
    }

    public void setOrgId(String orgId) {
        this.orgId = orgId;
    }

    public String getOrgId() {
        return orgId;
    }

}

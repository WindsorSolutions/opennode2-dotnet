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

package com.windsor.node.plugin.eis12;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.eis12.dao.AttachmentDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseEisXmlPlugin extends BaseWnosPlugin {
    /**
     * Optional runtime argument, set in service configuration.
     */
    public static final String ARG_ATTACHMENT_PATH = "Attachment Folder Path";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_AUTHOR_NAME = "Author Name";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_ORGANIZATION_NAME = "Organization Name";

    /**
     * Optional runtime argument, set in service configuration.
     */
    public static final String ARG_SENDER_CONTACT_INFO = "Sender Contact Info";

    /**
     * Index for schedule parameter
     */
    public static final int PARAM_INDEX_EMISSION_YEAR = 0;

    /**
     * Index for schedule parameter
     */
    public static final int PARAM_INDEX_SUBMISSION_TYPE = 1;

    /** Velocity template variable name. */
    public static final String TEMPLATE_AUTHOR_NAME = "authorName";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DATA_CATEGORY = "dataCategory";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_EMISSION_YEAR = "emissionYear";

    /** Velocity template variable name. */
    public static final String TEMPLATE_ORGANIZATION_NAME = "organizationName";

    /** Velocity template variable name. */
    public static final String TEMPLATE_SENDER_INFO = "senderContactInfo";

    /** Velocity template variable name. */
    public static final String TEMPLATE_SUBMISSION_TYPE = "submissionType";

    /** Velocity template variable name. */
    public static final String TEMPLATE_NDC_DATA_FILE = "ndcDataFileName";

    /**
     * Velocity template variable name - this one hard-coded in
     * setTemplateArgs()
     */
    public static final String TEMPLATE_MAKE_HEADER = "makeHeader";

    private static final String XML_EXT = ".xml";

    private static final String NOT_SET = " not set";

    public static final PluginServiceParameterDescriptor AUTHOR_NAME = new PluginServiceParameterDescriptor(
                    "Author Name",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.TRUE,
                    "Used to provide the originator of the document, typically the individual responsible for preparing the NEI for the organization. This value is inserted into the submission's  XML header \"AuthorName\" element.");
    public static final PluginServiceParameterDescriptor ORGANIZATION_NAME = new PluginServiceParameterDescriptor(
                    "Organization Name",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.TRUE,
                    "The organization to which the author belongs. This value is inserted into the submission’s XML header \"OrganizationName\" element.");
    public static final PluginServiceParameterDescriptor ATTACHMENT_FOLDER_PATH = new PluginServiceParameterDescriptor(
                    "Attachment Folder Path",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The relative file path to the location of attachments for onroad/nonroad NCD files and supporting files for event emissions.");
    public static final PluginServiceParameterDescriptor SENDER_CONTACT_INFO = new PluginServiceParameterDescriptor(
                    "Sender Contact Info",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The sender’s additional contact information, typically an  email address. This value is inserted into the submission’s XML header \"SenderContact\" element.");
    public static final PluginServiceParameterDescriptor EMISSIONS_YEAR = new PluginServiceParameterDescriptor(
                    "Emissions Year",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.TRUE,
                    "Used to provide the year for which the emissions data is being submitted. Format YYYY. This will be used, along with the relevant data category for the data service, to filter data to be extracted from the staging database.");
    public static final PluginServiceParameterDescriptor SUBMISSION_TYPE = new PluginServiceParameterDescriptor(
                    "Submission Type",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.TRUE,
                    "Allows the user to specify whether the XML file resulting from the data service execution should be submitted to the EIS Production or Quality Assurance environment. Accepted values: Production or QA.");
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
    private String attachmentFolderPath;
    private String authorName;
    private String emissionYear;
    private String makeHeader = "true";
    private String ndcDataFileName;
    private String organizationName;
    private String senderContactInfo;
    private String serviceName;
    private String submissionType;
    private DataCategory dataCategory;

    public BaseEisXmlPlugin() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_ATTACHMENT_PATH, "");
        getConfigurationArguments().put(ARG_AUTHOR_NAME, "");
        getConfigurationArguments().put(ARG_ORGANIZATION_NAME, "");
        getConfigurationArguments().put(ARG_SENDER_CONTACT_INFO, "");

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

        if (!getConfigurationArguments().containsKey(ARG_ATTACHMENT_PATH)) {
            throw new RuntimeException(ARG_ATTACHMENT_PATH + NOT_SET);
        }

        if (!getConfigurationArguments().containsKey(ARG_AUTHOR_NAME)) {
            throw new RuntimeException(ARG_AUTHOR_NAME + NOT_SET);
        }

        if (!getConfigurationArguments().containsKey(ARG_ORGANIZATION_NAME)) {
            throw new RuntimeException(ARG_ORGANIZATION_NAME + NOT_SET);
        }

        if (!getConfigurationArguments().containsKey(ARG_SENDER_CONTACT_INFO)) {
            throw new RuntimeException(ARG_SENDER_CONTACT_INFO + NOT_SET);
        }

        debug("Plugin validated");

    }

    protected void validateTransaction(NodeTransaction transaction) {

        super.validateTransaction(transaction);

        if (transaction.getRequest().getParameters().size() < 2) {

            throw new RuntimeException(
                    "Missing request/schedule parameters; 2 expected, "
                            + transaction.getRequest().getParameters().size()
                            + " found.");
        }

    }

    protected ProcessContentResult generateXmlFile(NodeTransaction transaction,
            String templateName, String outfileBaseName) {

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        result.getAuditEntries().add(makeEntry("Validating transaction..."));
        validateTransaction(transaction);

        debug("Processing transaction...");
        result.getAuditEntries().add(
                makeEntry("dataCategory: " + getDataCategory()));

        try {

            setEmissionYear((String) transaction.getRequest().getParameters()
                    .get(PARAM_INDEX_EMISSION_YEAR));
            result.getAuditEntries().add(
                    makeEntry("emission year: " + getEmissionYear()));

            setSubmissionType((String) transaction.getRequest().getParameters()
                    .get(PARAM_INDEX_SUBMISSION_TYPE));
            result.getAuditEntries().add(
                    makeEntry("submission type: " + getSubmissionType()));

            setServiceArgs();

            String docId = idGenerator.createId();

            velocityHelper.configure(pluginDataSource, getPluginSourceDir()
                    .getAbsolutePath());

            setTemplateArgs(docId);

            result.getAuditEntries().add(makeEntry("Executing request..."));

            String baseFilename = outfileBaseName + docId;

            File outputDir = createOutputDir(baseFilename);

            setTempFilePath(FilenameUtils.concat(outputDir.getAbsolutePath(),
                    baseFilename + XML_EXT));

            handleAttachments(outputDir);

            velocityHelper.merge(templateName, getTempFilePath());

            result.getAuditEntries().add(makeEntry("Xml file generated"));

            result.getAuditEntries().add(makeEntry("Compressing results..."));

            Document doc = compressOutput(baseFilename, outputDir);

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

    /**
     * @param string
     */
    private File createOutputDir(String dirName) {

        File outputDir = null;

        String outputDirName = FilenameUtils.concat(settingService.getTempDir()
                .getAbsolutePath(), dirName);

        outputDir = new File(outputDirName);

        if (!outputDir.mkdir()) {

            throw new RuntimeException("Couldn't create output directory "
                    + outputDirName);
        }

        return outputDir;

    }

    /**
     * If dataCategory is Event or OnAndNonRoad:
     * <ol>
     * <li>look for an attachment name in the appropriate table</li>
     * <li>copy filename from getAttachmentFolderPath() to
     * settingService.getTempDir()</li>
     * </ol>
     * 
     * @param outputDir
     * @throws IOException
     */
    private void handleAttachments(File outputDir) throws IOException {

        if ((getDataCategory().equals(DataCategory.Event) || getDataCategory()
                .equals(DataCategory.OnAndNonRoad))
                && StringUtils.isNotBlank(getAttachmentFolderPath())) {

            File attachDir = new File(getAttachmentFolderPath());

            if (attachDir.canRead() && attachDir.isDirectory()) {

                AttachmentDao dao = new AttachmentDao(getPluginDataSource());
                String fileName = dao.getFilename(getDataCategory(),
                        getEmissionYear());

                if (StringUtils.isNotBlank(fileName)) {

                    File attachment = new File(FilenameUtils.concat(attachDir
                            .getAbsolutePath(), fileName));
                    FileUtils.copyFileToDirectory(attachment, outputDir, true);

                    if (getDataCategory().equals(DataCategory.OnAndNonRoad)) {
                        setNdcDataFileName(fileName);
                    }
                }
            }
        }

    }

    protected File getResultFile() throws IOException {

        File resultFile = new File(getTempFileName());

        if (!resultFile.exists()) {
            throw new IOException("Result file not found: " + getTempFileName());
        }

        return resultFile;

    }

    private void setServiceArgs() {

        /* required header elements */
        if (StringUtils.isBlank(authorName)) {
            authorName = (String) getRequiredConfigValueAsString(ARG_AUTHOR_NAME);
        }
        debug("authorName: " + authorName);

        if (StringUtils.isBlank(organizationName)) {
            organizationName = (String) getRequiredConfigValueAsString(ARG_ORGANIZATION_NAME);
        }
        debug("organizationName: " + organizationName);

        /* optional element */
        if (StringUtils.isBlank(senderContactInfo)) {
            senderContactInfo = (String) getOptionalConfigValueAsString(ARG_SENDER_CONTACT_INFO);
        }
        debug("senderContactInfo: " + senderContactInfo);

        /* optional for when attachments are required */
        if (StringUtils.isBlank(attachmentFolderPath)) {
            attachmentFolderPath = (String) getOptionalConfigValueAsString(ARG_ATTACHMENT_PATH);
        }
        debug("attachmentFolderPath: " + attachmentFolderPath);

        debug("Finished setting service configuration arguments");
    }

    private void setTemplateArgs(String docId) {

        /* required for all services */
        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, getMakeHeader());

        velocityHelper.setTemplateArg(TEMPLATE_DATA_CATEGORY, dataCategory
                .toString());

        velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

        velocityHelper
                .setTemplateArg(TEMPLATE_EMISSION_YEAR, getEmissionYear());

        velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_NAME, getAuthorName());

        velocityHelper.setTemplateArg(TEMPLATE_ORGANIZATION_NAME,
                getOrganizationName());

        velocityHelper.setTemplateArg(TEMPLATE_SUBMISSION_TYPE,
                getSubmissionType());

        /* optional for all services */
        velocityHelper.setTemplateArg(TEMPLATE_SENDER_INFO,
                getSenderContactInfo());

        /* used only for OnAndOffRoad service */
        if (StringUtils.isNotBlank(getNdcDataFileName())) {
            velocityHelper.setTemplateArg(TEMPLATE_NDC_DATA_FILE,
                    getNdcDataFileName());
        }

        debug("Finished setting Velocity template arguments");
    }

    private Document compressOutput(String baseFilename, File outputDir)
            throws IOException {

        Document doc = new Document();

        String zippedFilename = baseFilename + ".zip";
        String zippedFilePath = FilenameUtils.concat(getSettingService()
                .getTempDir().getAbsolutePath(), zippedFilename);

        getCompressionService()
                .zip(zippedFilePath, outputDir.getAbsolutePath());

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

        if (serviceName.equalsIgnoreCase(getServiceName())) {

            list = new ArrayList<DataServiceRequestParameter>();

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(TEMPLATE_EMISSION_YEAR);

            DataServiceRequestParameter param2 = new DataServiceRequestParameter();
            param.setName(TEMPLATE_SUBMISSION_TYPE);

            list.add(param);
            list.add(param2);
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

    public String getAttachmentFolderPath() {
        return attachmentFolderPath;
    }

    public void setAttachmentFolderPath(String attachmentFolderPath) {
        this.attachmentFolderPath = attachmentFolderPath;
    }

    public String getAuthorName() {
        return authorName;
    }

    public void setAuthorName(String authorName) {
        this.authorName = authorName;
    }

    public String getSubmissionType() {
        return submissionType;
    }

    public void setSubmissionType(String submissionType) {
        this.submissionType = submissionType;
    }

    public String getOrganizationName() {
        return organizationName;
    }

    public void setOrganizationName(String organizationName) {
        this.organizationName = organizationName;
    }

    public String getSenderContactInfo() {
        return senderContactInfo;
    }

    public void setSenderContactInfo(String senderContactInfo) {
        this.senderContactInfo = senderContactInfo;
    }

    public String getNdcDataFileName() {
        return ndcDataFileName;
    }

    public void setNdcDataFileName(String ndcDataFileName) {
        this.ndcDataFileName = ndcDataFileName;
    }

    public String getEmissionYear() {
        return emissionYear;
    }

    public void setEmissionYear(String emissionYear) {
        this.emissionYear = emissionYear;
    }

    public String getServiceName() {
        return serviceName;
    }

    public void setServiceName(String serviceName) {
        this.serviceName = serviceName;
    }

    /**
     * @param dataCategory
     *            the dataCategory to set
     */
    public void setDataCategory(DataCategory dataCategory) {
        this.dataCategory = dataCategory;
    }

    /**
     * @return the dataCategory
     */
    public DataCategory getDataCategory() {
        return dataCategory;
    }

    public String getMakeHeader() {
        return makeHeader;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParamters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(EMISSIONS_YEAR);
        params.add(SUBMISSION_TYPE);
        return params;
    }

}

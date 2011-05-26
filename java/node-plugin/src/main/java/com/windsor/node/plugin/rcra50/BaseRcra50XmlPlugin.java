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

package com.windsor.node.plugin.rcra50;

import java.io.File;
import java.io.IOException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
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
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.rcra50.dao.RcraCountDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseRcra50XmlPlugin extends BaseRcra50Plugin {

    private static final String EQ = " = ";

    /**
     * Required runtime argument, set in service configuration.
     */
    protected static final String ARG_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";

    /**
     * Required runtime argument, set in service configuration.
     */
    protected static final String ARG_RCRA_INFO_USER_ID = "RCRAInfoUserID";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_AUTHOR = "author";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_CONTACT_INFO = "contactInfo";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_MAKE_HEADER = "makeHeader";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_NOTIFICATION = "notification";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_PAYLOAD_OPERATION = "payloadOperation";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_PROVIDING_ORG = "providingOrg";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_RCRA_INFO_STATE_CODE = "rcraInfoStateCode";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_RCRA_INFO_USER_ID = "rcraInfoUserId";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_UPDATE_DATE = "updateDate";

    /** Velocity template variable name. */
    protected static final String TEMPLATE_HANDLER_LIMIT = "handlerLimit";

    /**
     * Index position for schedule argument (whether to use the
     * RCRA_SUBMISSIONHISTORY table).
     */
    protected static final int PARAM_INDEX_USE_HISTORY = 0;

    /**
     * Index position for schedule argument (the date for skimming data).
     */
    protected static final int PARAM_INDEX_UPDATE_DATE = 1;

    /**
     * Index position for schedule argument (number of handler ids in top-level
     * query - for dev and testing convenience).
     */
    public static final int HANDLER_LIMIT_ARG_INDEX = 2;

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
    private String authorName;
    private String contactInfo;
    private String notification;
    private String payloadOperation;
    private String providingOrg;
    private String rcraInfoStateCode;
    private String rcraInfoUserId;

    /* request, i.e., schedule, parameters */
    private boolean useSubmissionHistory = true;
    private Timestamp updateDate;

    /* addition to allow erroring out on empty submits */
    private boolean errorOnEmptySubmissions = false;
    private RcraCountDao countDao;

    /* is one is private, for testing only, not published. */
    private String handlerLimit;

    private RcraOperationType operationType;

    public BaseRcra50XmlPlugin() {
        super();

        setPublishForEN11(true);
        setPublishForEN20(true);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_NOTIFS, "");
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_STATE_CODE, "");
        getConfigurationArguments().put(ARG_RCRA_INFO_USER_ID, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("BaseRcra50XmlPlugin instantiated.");

    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        if (pluginDataSource == null) {
            if (null == getDataSources().get(ARG_DS_SOURCE)) {

                throw new RuntimeException("Source data source not set");

            } else {
                pluginDataSource = (DataSource) getDataSources().get(
                        ARG_DS_SOURCE);
            }
        }

        countDao = new RcraCountDao((DataSource)getDataSources().get(ARG_DS_SOURCE));
        if(countDao == null)
        {
            throw new RuntimeException("Unable to obtain countDao");
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
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");

        } else if (!getConfigurationArguments().containsKey(ARG_HEADER_AUTHOR)) {
            throw new RuntimeException(ARG_HEADER_AUTHOR + NOT_SET);

        } else if (!getConfigurationArguments().containsKey(
                ARG_HEADER_CONTACT_INFO)) {
            throw new RuntimeException(ARG_HEADER_CONTACT_INFO + NOT_SET);

        } else if (!getConfigurationArguments().containsKey(ARG_HEADER_NOTIFS)) {
            throw new RuntimeException(ARG_HEADER_NOTIFS + NOT_SET);

        } else if (!getConfigurationArguments()
                .containsKey(ARG_HEADER_ORG_NAME)) {
            throw new RuntimeException(ARG_HEADER_ORG_NAME + NOT_SET);

        } else if (!getConfigurationArguments().containsKey(
                ARG_HEADER_PAYLOAD_OP)) {
            throw new RuntimeException(ARG_HEADER_PAYLOAD_OP + NOT_SET);

        } else if (!getConfigurationArguments().containsKey(
                ARG_RCRA_INFO_STATE_CODE)) {
            throw new RuntimeException(ARG_RCRA_INFO_STATE_CODE + NOT_SET);

        } else if (!getConfigurationArguments().containsKey(
                ARG_RCRA_INFO_USER_ID)) {
            throw new RuntimeException(ARG_RCRA_INFO_USER_ID + NOT_SET);
        }

        debug("Plugin validated");

    }

    protected ProcessContentResult generateAndSubmitFile(NodeTransaction aTran,
            String templateName, String outfileBaseName) {

        debug("Validating transaction...");
        validateTransaction(aTran);

        NodeTransaction transaction = aTran;
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            setOptionsFromTransactionParams(transaction);
            setServiceArgs();
            String docId = idGenerator.createId();
            setTemplateArgs(docId);

            if (useSubmissionHistory) {

                checkForPendingSubmissions(operationType);
                result.getAuditEntries().add(
                        makeEntry("No pending submissions"));

            } else {
                result.getAuditEntries().add(
                        makeEntry("Ignoring submission history."));
            }
            if(getErrorOnEmptySubmissions())
            {
                if(StringUtils.isNotBlank(getSubmissionCountSql()))
                {
                    if(getCountDao().countSubmissions() < 1)
                    {
                        //Error condition, we asked for this to error
                        throw new UnsupportedOperationException("Plugin found no submissions for operation \""
                                + operationType.toString()
                                + "\".");
                    }
                }
                else
                {
                    throw new UnsupportedOperationException("Plugin set to error on empty submissions for operation \""
                            + operationType.toString()
                            + "\" but no valid counting method was specified.");
                }
            }

            /* CREATE THE DOCUMENT TO SUBMIT */
            result.getAuditEntries().add(makeEntry("Generating xml file..."));

            setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                    .getAbsolutePath(), outfileBaseName + docId + XML_EXT));

            velocityHelper.merge(templateName, getTempFilePath());

            result.getAuditEntries().add(makeEntry("Xml file generated"));

            result.getAuditEntries().add(makeEntry("Compressing results..."));

            Document doc = compressOutput(transaction.getRequest().getType());

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            /* SUBMIT FILE TO PARTNER */

            debug("Saving document " + doc.getDocumentName()
                    + " with transaction");
            transaction.getDocuments().add(doc);

            debug("Submitting...");
            submitTransaction(transaction, result);

            /* SAVE RESULTS */
            if (useSubmissionHistory) {
                saveSubmissionHistory(transaction, operationType);
                result.getAuditEntries().add(
                        makeEntry("Recorded document submission."));
            }

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
     * @param transaction
     * @param result
     */
    private void submitTransaction(NodeTransaction transaction,
            ProcessContentResult result) {

        debug("pre-submit transaction.getId(): " + transaction.getId());
        debug("pre-submit transaction.getNetworkId(): "
                + transaction.getNetworkId());

        PartnerIdentity partner = makePartner();

        NodeClientService client = makeNodeClient(partner);

        result.getAuditEntries().add(
                makeEntry("submitting to partner URL " + partner.getUrl()));

        transaction = client.submit(transaction);
        debug("submission returned with network transaction id "
                + transaction.getNetworkId());

        getTransactionDao().updateNetworkId(transaction.getId(),
                transaction.getNetworkId());

        result.getAuditEntries().add(
                makeEntry("resultTran.getId(): " + transaction.getId()));
        result.getAuditEntries().add(
                makeEntry("resultTran.getNetworkId(): "
                        + transaction.getNetworkId()));
    }

    /**
     * @param opType
     */
    private void checkForPendingSubmissions(RcraOperationType opType) {

        logger.debug("Checking for pending submissions...");

        if (getStatusDao().getPendingTransactionId(opType) != null) {
            throw new UnsupportedOperationException("Can't submit when a \""
                    + operationType.toString()
                    + "\" transaction is Pending or Processing");
        }

    }

    private void setOptionsFromTransactionParams(NodeTransaction transaction)
            throws ParseException {

        int argCount = transaction.getRequest().getParameters().size();

        if (argCount >= 1) {
            /* useSubmissionHistory defaults to true */
            String useHistory = getOptionalValueFromTransactionArgs(
                    transaction, PARAM_INDEX_USE_HISTORY);

            if (StringUtils.isNotBlank(useHistory)) {
                useSubmissionHistory = Boolean.parseBoolean(useHistory);
                debug("useSubmissionHistory = " + useSubmissionHistory);
            }
        }

        if (argCount >= 2) {
            String updateStr = getOptionalValueFromTransactionArgs(transaction,
                    PARAM_INDEX_UPDATE_DATE);
            debug("updateStr = " + updateStr);

            if (StringUtils.isNotBlank(updateStr)) {
                updateDate = makeTimestamp(updateStr);
            }
            debug("updateDate = " + updateDate);
        }

        if (argCount >= 3) {
            String limit = getOptionalValueFromTransactionArgs(transaction,
                    HANDLER_LIMIT_ARG_INDEX);

            if (Integer.parseInt(limit) > 0) {
                handlerLimit = limit;
            }
            debug("handlerLimit: " + handlerLimit);
        }

    }

    private Timestamp makeTimestamp(String s) throws ParseException {

        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        Date date = sdf.parse(s);

        return new Timestamp(date.getTime());
    }

    private void saveSubmissionHistory(NodeTransaction transaction,
            RcraOperationType operationType) {

        if (StringUtils.isBlank(transaction.getId())) {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }

        debug("Saving transaction status to RCRA_SubmissionHistory table...");
        getStatusDao().createStatus(getIdGenerator().createId(), operationType,
                transaction.getId(), CommonTransactionStatusCode.Pending);
    }

    protected File getResultFile() throws IOException {

        File resultFile = new File(getTempFileName());

        if (!resultFile.exists()) {
            throw new IOException("Result file not found: " + getTempFileName());
        }

        return resultFile;
    }

    private void setServiceArgs() {

        /*
         * required args - conditionals to facilitate testing via Spring wire-up
         * of plugin
         */

        if (StringUtils.isBlank(authorName)) {
            authorName = (String) getRequiredConfigValueAsString(ARG_HEADER_AUTHOR);
        }
        debug("authorName: " + authorName);

        if (StringUtils.isBlank(rcraInfoStateCode)) {
            rcraInfoStateCode = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_STATE_CODE);
        }
        debug("rcraInfoStateCode: " + rcraInfoStateCode);

        if (StringUtils.isBlank(rcraInfoUserId)) {
            rcraInfoUserId = (String) getRequiredConfigValueAsString(ARG_RCRA_INFO_USER_ID);
        }
        debug("rcraInfoUserId: " + rcraInfoUserId);

        /* optional - header elements */
        if (StringUtils.isBlank(contactInfo)) {
            contactInfo = (String) getRequiredConfigValueAsString(ARG_HEADER_CONTACT_INFO);
        }
        debug("contactInfo: " + contactInfo);

        if (StringUtils.isBlank(notification)) {
            notification = (String) getRequiredConfigValueAsString(ARG_HEADER_NOTIFS);
        }
        debug("notification: " + notification);

        if (StringUtils.isBlank(payloadOperation)) {
            payloadOperation = (String) getRequiredConfigValueAsString(ARG_HEADER_PAYLOAD_OP);
        }
        debug("payloadOperation: " + payloadOperation);

        operationType = RcraOperationType.fromString(payloadOperation);
        debug("operationType: " + operationType.name());

        if (StringUtils.isBlank(providingOrg)) {
            providingOrg = (String) getRequiredConfigValueAsString(ARG_HEADER_ORG_NAME);
        }
        debug("providingOrg: " + providingOrg);

        velocityHelper.configure(pluginDataSource, getPluginSourceDir()
                .getAbsolutePath());

        debug("Finished setting service configuration arguments");
    }

    private void setTemplateArgs(String docId) {

        debug("Setting Velocity template arguments...");

        if (handlerLimit != null) {
            velocityHelper.setTemplateArg(TEMPLATE_HANDLER_LIMIT, handlerLimit);
            debug(TEMPLATE_HANDLER_LIMIT + EQ + handlerLimit);
        }

        if (authorName != null) {
            velocityHelper.setTemplateArg(TEMPLATE_AUTHOR, authorName);
            debug(TEMPLATE_AUTHOR + EQ + authorName);
        }

        if (contactInfo != null) {
            velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, contactInfo);
            debug(TEMPLATE_CONTACT_INFO + EQ + contactInfo);
        }

        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, "true");
        debug(TEMPLATE_MAKE_HEADER + EQ + "true");

        if (notification != null) {
            velocityHelper.setTemplateArg(TEMPLATE_NOTIFICATION, notification);
            debug(TEMPLATE_NOTIFICATION + EQ + notification);
        }

        if (payloadOperation != null) {
            velocityHelper.setTemplateArg(TEMPLATE_PAYLOAD_OPERATION,
                    payloadOperation);
            debug(TEMPLATE_PAYLOAD_OPERATION + EQ + payloadOperation);
        }

        if (providingOrg != null) {
            velocityHelper.setTemplateArg(TEMPLATE_PROVIDING_ORG, providingOrg);
            debug(TEMPLATE_PROVIDING_ORG + EQ + providingOrg);
        }

        if (rcraInfoStateCode != null) {
            velocityHelper.setTemplateArg(TEMPLATE_RCRA_INFO_STATE_CODE,
                    rcraInfoStateCode);
            debug(TEMPLATE_RCRA_INFO_STATE_CODE + EQ + rcraInfoStateCode);
        }

        if (rcraInfoUserId != null) {
            velocityHelper.setTemplateArg(TEMPLATE_RCRA_INFO_USER_ID,
                    rcraInfoUserId);
            debug(TEMPLATE_RCRA_INFO_USER_ID + EQ + rcraInfoUserId);
        }

        if (docId != null) {
            velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);
            debug(TEMPLATE_DOC_ID + EQ + docId);
        }

        if (updateDate != null) {
            velocityHelper.setTemplateArg(TEMPLATE_UPDATE_DATE, updateDate
                    .toString());
            debug(TEMPLATE_UPDATE_DATE + EQ + updateDate);
        }

        debug("Finished setting Velocity template arguments");
    }

    private Document compressOutput(RequestType requestType) throws IOException {

        Document doc = new Document();

        if (requestType != RequestType.QUERY) {

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

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
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

    /**
     * @return the authorName
     */
    public String getAuthorName() {
        return authorName;
    }

    /**
     * @param authorName
     *            the authorName to set
     */
    public void setAuthorName(String authorName) {
        this.authorName = authorName;
    }

    /**
     * @return the useSubmissionHistory
     */
    public boolean isUseSubmissionHistory() {
        return useSubmissionHistory;
    }

    /**
     * @param useSubmissionHistory
     *            the useSubmissionHistory to set
     */
    public void setUseSubmissionHistory(boolean useSubmissionHistory) {
        this.useSubmissionHistory = useSubmissionHistory;
    }

    /**
     * @return the updateDate
     */
    public Timestamp getUpdateDate() {
        return updateDate;
    }

    /**
     * @param updateDate
     *            the updateDate to set
     */
    public void setUpdateDate(Timestamp updateDate) {
        this.updateDate = updateDate;
    }

    public boolean getErrorOnEmptySubmissions()
    {
        return errorOnEmptySubmissions;
    }

    public void setErrorOnEmptySubmissions(boolean errorOnEmptySubmissions)
    {
        this.errorOnEmptySubmissions = errorOnEmptySubmissions;
    }

    public String getSubmissionCountSql()
    {
        return getCountDao().getSubmissionCountSql();
    }

    public void setSubmissionCountSql(String submissionCountSql)
    {
        getCountDao().setSubmissionCountSql(submissionCountSql);
    }

    public RcraCountDao getCountDao()
    {
        return countDao;
    }

    public void setCountDao(RcraCountDao countDao)
    {
        this.countDao = countDao;
    }

}

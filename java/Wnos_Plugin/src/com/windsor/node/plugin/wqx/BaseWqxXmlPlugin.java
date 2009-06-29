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

package com.windsor.node.plugin.wqx;

import java.io.File;
import java.io.IOException;
import java.sql.Timestamp;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.wqx.dao.WqxStatusDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseWqxXmlPlugin extends BaseWqxPlugin implements
        InitializingBean {

    /** 1 January, 1899. */
    public static final String ARBITRARY_START_DATE = "1899-01-01";

    /**
     * Index position for schedule argument (organization id for the data
     * query).
     */
    public static final int ORG_ID_ARG_INDEX = 0;

    /** Velocity template variable name. */
    public static final String TEMPLATE_AUTHOR_NAME = "authorName";

    /** Velocity template variable name. */
    public static final String TEMPLATE_AUTHOR_ORG = "authorOrg";

    /** Velocity template variable name. */
    public static final String TEMPLATE_CONTACT_INFO = "contactInfo";

    /** Velocity template variable name. */
    public static final String TEMPLATE_ORG_ID = "orgId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_LAST_PROCESSED = "lastProcessedTimestamp";

    /** Velocity template variable name. */
    public static final String TEMPLATE_MAKE_HEADER = "makeHeader";

    public static final String XML_EXT = ".xml";

    /* Helpers */
    protected VelocityHelper velocityHelper = new JdbcVelocityHelper();
    protected String tempFilePath;
    protected String tempFileName;

    /* VTL template variables */
    protected String authorName;
    protected String authorOrg;
    protected String contactInfo;

    /* Primary key for base db query, also a VTL variable. */
    protected String orgId;

    public BaseWqxXmlPlugin() {
        super();

        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");

    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        authorName = getRequiredConfigValueAsString(ARG_HEADER_AUTHOR);
        debug("authorName: " + authorName);

        if (StringUtils.isBlank(authorName)) {
            throw new RuntimeException("blank authorName");
        }

        authorOrg = getRequiredConfigValueAsString(ARG_HEADER_ORG_NAME);
        debug("authorOrg: " + authorOrg);

        if (StringUtils.isBlank(authorOrg)) {
            throw new RuntimeException("blank authorOrg");
        }

        contactInfo = getRequiredConfigValueAsString(ARG_HEADER_CONTACT_INFO);
        debug("contactInfo: " + contactInfo);

        if (StringUtils.isBlank(contactInfo)) {
            throw new RuntimeException("blank contactInfo");
        }

        velocityHelper.configure((DataSource) getDataSources().get(
                ARG_DS_SOURCE), getPluginSourceDir().getAbsolutePath());

        compressionService = (CompressionService) getServiceFactory()
                .makeService(CompressionService.class);

        if (compressionService == null) {
            throw new RuntimeException("Unable to obtain CompressionService");
        }

    }

    protected ProcessContentResult generateAndSubmitFile(NodeTransaction aTran,
            String templateName, String outfileBaseName,
            WqxOperationType operationType) {

        debug("Processing transaction...");
        NodeTransaction transaction = aTran;
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            checkForPendingSubmissions(operationType);
            result
                    .getAuditEntries()
                    .add(
                            makeEntry("No pending submissions, validating transaction..."));

            validateTransaction(transaction);

            debug("transaction is valid");

            /* CREATE THE DOCUMENT TO SUBMIT */
            result.getAuditEntries().add(makeEntry("Generating xml file..."));

            generateXmlDoc(transaction, operationType, outfileBaseName,
                    templateName);

            result.getAuditEntries().add(
                    makeEntry("Xml file generated with template "
                            + templateName));

            Document doc = makeDocument(transaction);

            result.getAuditEntries().add(
                    makeEntry("Created document " + doc.getDocumentName()
                            + " in " + getTempFilePath()));

            result.getAuditEntries().add(makeEntry("Setting result..."));
            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));
            result.getDocuments().add(doc);

            /* SUBMIT FILE TO PARTNER */
            transaction.getDocuments().add(doc);

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

            transactionDao.updateNetworkId(transaction.getId(), transaction
                    .getNetworkId());

            debug("resultTran.getId(): " + transaction.getId());
            debug("resultTran.getNetworkId(): " + transaction.getNetworkId());

            /* SAVE RESULTS */
            saveSubmissionHistory(transaction, operationType);
            result.getAuditEntries().add(
                    makeEntry("Recorded document submission."));

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PENDING);
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

    protected void validateTransaction(NodeTransaction transaction) {

        super.validateTransaction(transaction);

        if (transaction.getRequest().getParameters().size() != 1) {
            throw new RuntimeException(
                    "Invalid number of parameters. Expected " + TEMPLATE_ORG_ID);
        }
    }

    private void saveSubmissionHistory(NodeTransaction transaction,
            WqxOperationType operationType) {

        if (StringUtils.isBlank(transaction.getId())) {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }

        debug("Saving transaction status to WQX_SubmissionHistory table...");
        statusDao.createStatus(getIdGenerator().createId(), orgId,
                operationType, transaction.getId(),
                CommonTransactionStatusCode.PENDING);
    }

    private void checkForPendingSubmissions(WqxOperationType operationType) {

        logger.debug("Checking for pending submissions...");

        if (null != statusDao.getPendingTransactionId(orgId, operationType)) {
            throw new UnsupportedOperationException(
                    WqxStatusDao.NO_NEW_STATUS_WHEN_PENDING);
        }
    }

    private void generateXmlDoc(NodeTransaction transaction,
            WqxOperationType operationType, String outfileBaseName,
            String templateName) {

        velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_NAME, authorName);
        velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_ORG, authorOrg);
        velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, contactInfo);

        // we set this template var to "false" in our unit test to simplify
        // schema validation
        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, "true");

        orgId = getRequiredValueFromTransactionArgs(transaction,
                ORG_ID_ARG_INDEX);
        debug("orgId: " + orgId);

        velocityHelper.setTemplateArg(TEMPLATE_ORG_ID, orgId);

        String docId = idGenerator.createId();
        velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

        Timestamp lastPendingTimestamp = statusDao.getLatestProcessedTimestamp(
                orgId, operationType);

        if (null == lastPendingTimestamp) {

            velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                    ARBITRARY_START_DATE);

        } else {

            velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                    lastPendingTimestamp.toString());
        }

        setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                .getAbsolutePath(), outfileBaseName + docId + XML_EXT));

        velocityHelper.merge(templateName, getTempFilePath());

    }

    private Document makeDocument(NodeTransaction transaction)
            throws IOException {

        Document doc = new Document();
        doc.setDocumentId(idGenerator.createId());

        if (transaction.getRequest().getType() != RequestType.QUERY) {

            String zippedFilePath = getCompressionService().zip(
                    getTempFilePath());
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

    /**
     * @return
     */
    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    /**
     * @return
     */
    public IdGenerator getIdGenerator() {
        return idGenerator;
    }

    /**
     * @return
     */
    public CompressionService getCompressionService() {
        return compressionService;
    }

    /**
     * @return the tempFilePath
     */
    public String getTempFilePath() {
        return tempFilePath;
    }

    /**
     * @return
     */
    public File getTempDir() {
        return settingService.getTempDir();
    }

    /**
     * @param tempFilePath
     *            the tempFilePath to set
     */
    public void setTempFilePath(String tempFilePath) {
        this.tempFilePath = tempFilePath;
    }

    /**
     * @return the tempFileName
     */
    public String getTempFileName() {
        return tempFileName;
    }

    /**
     * @param tempFileName
     *            the tempFileName to set
     */
    public void setTempFileName(String tempFileName) {
        this.tempFileName = tempFileName;
    }

    /**
     * @return the orgId
     */
    public String getOrgId() {
        return orgId;
    }

    /**
     * @param orgId
     *            the orgId to set
     */
    public void setOrgId(String orgId) {
        this.orgId = orgId;
    }
}

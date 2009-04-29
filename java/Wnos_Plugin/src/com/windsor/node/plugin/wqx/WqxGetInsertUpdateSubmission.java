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
import com.windsor.node.plugin.wqx.dao.WqxStatusDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class WqxGetInsertUpdateSubmission extends BaseWnosPlugin {

    /** 1 January, 1899. */
    public static final String ARBITRARY_START_DATE = "1899-01-01";
    
    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_AUTHOR_NAME = "Author";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_CONTACT_INFO = "Contact Info";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_PARTNER_NAME = "EPA CDX Network Partner Name";

    /**
     * Required runtime argument, set in service configuration.
     */
    public static final String ARG_AUTHOR_ORG = "Organization";

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
    public static final String TEMPLATE_PARTNER_NAME = "partnerName";

    /** Velocity template variable name. */
    public static final String TEMPLATE_ORG_ID = "orgId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_DOC_ID = "docId";

    /** Velocity template variable name. */
    public static final String TEMPLATE_LAST_PENDING = "lastPendingTimestamp";

    /** Velocity template name. */
    public static final String TEMPLATE_NAME = "WQX_InsertUpdate.vm";

    private static final String OUTFILE = "WQX_2_InsertUpdate_";
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
    private Timestamp lastPendingTimestamp;

    /* VTL template variables */
    private String authorName;
    private String authorOrg;
    private String contactInfo;
    private String partnerName;

    /* Primary key for base db query, also a VTL variable. */
    private String orgId;

    // private String isFacilitySourceIndicator;
    private WqxStatusDao dao;

    public WqxGetInsertUpdateSubmission() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_AUTHOR_NAME, "");
        getConfigurationArguments().put(ARG_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_PARTNER_NAME, "");
        getConfigurationArguments().put(ARG_AUTHOR_ORG, "");

        debug("Setting internal data source list");
        getDataSources().put(DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("WqxUpdateInsertRequestProcessor instantiated.");

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

        authorName = (String) getRequiredConfigValueAsString(ARG_AUTHOR_NAME);
        debug("authorName: " + authorName);

        authorOrg = (String) getRequiredConfigValueAsString(ARG_AUTHOR_ORG);
        debug("authorOrg: " + authorOrg);

        contactInfo = (String) getRequiredConfigValueAsString(ARG_CONTACT_INFO);
        debug("contactInfo: " + contactInfo);

        partnerName = (String) getRequiredConfigValueAsString(ARG_PARTNER_NAME);
        debug("nodeName: " + partnerName);

        velocityHelper.configure((DataSource) getDataSources().get(DS_SOURCE),
                getPluginSourceDir().getAbsolutePath());

        dao = new WqxStatusDao((DataSource) getDataSources().get(DS_SOURCE));

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

            logger.debug("Checking for pending submissions...");
            
            if (dao.getLatestPendingTimestamp() != null) {
                throw new UnsupportedOperationException(WqxStatusDao.NO_NEW_STATUS_WHEN_PENDING);
            }

            /*
             * 
             * ARGUMENTS
             */
            result.getAuditEntries()
                    .add(makeEntry("No pending submissions, validating transaction..."));
            validateTransaction(transaction);

            velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_NAME, authorName);

            velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_ORG, authorOrg);

            velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, contactInfo);

            velocityHelper.setTemplateArg(TEMPLATE_PARTNER_NAME, partnerName);

            orgId = getOptionalValueFromTransactionArgs(transaction,
                    ORG_ID_ARG_INDEX);
            debug("orgId: " + orgId);

            velocityHelper.setTemplateArg(TEMPLATE_ORG_ID, orgId);

            String docId = idGenerator.createId();

            velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

            if (null == dao.getLatestPendingTimestamp()) {

                velocityHelper.setTemplateArg(TEMPLATE_LAST_PENDING,
                        ARBITRARY_START_DATE);

            } else {
                
                velocityHelper.setTemplateArg(TEMPLATE_LAST_PENDING,
                        lastPendingTimestamp.toString());
            }

            /*
             * 
             * EXECUTE
             */
            result.getAuditEntries().add(makeEntry("Executing request..."));

            setTempFilePath(FilenameUtils.concat(settingService.getTempDir()
                    .getAbsolutePath(), OUTFILE + docId + XML_EXT));

            velocityHelper.merge(TEMPLATE_NAME,
                    getTempFilePath());

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
                saveResults(transaction);
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

    protected void saveResults(NodeTransaction transaction) {

        if (StringUtils.isBlank(transaction.getId())) {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }
        
        String orgPk = dao.getPrimaryKeyForOrgId(orgId);

        debug("Saving status...");
        dao.createStatus(getIdGenerator().createId(), orgPk,
                WqxOperationType.UPDATE_INSERT_STR, transaction.getId(),
                CommonTransactionStatusCode.PENDING_STR);

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
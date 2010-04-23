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
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

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
import com.windsor.node.util.IOUtil;

public abstract class BaseWqxXmlPlugin extends BaseWqxPlugin implements
        InitializingBean {

    /** 1 January, 1899. */
    public static final String ARBITRARY_START_DATE = "1899-01-01";

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

    /** Velocity template variable name. */
    public static final String TEMPLATE_START_DATE = "startDate";

    /** Velocity template variable name. */
    public static final String TEMPLATE_END_DATE = "endDate";

    protected static final String XML_EXT = ".xml";

    private static final int MEGA = 1024;

    protected static final int PARAM_INDEX_ORGID = 0;
    protected static final int PARAM_INDEX_ADD_HEADER = 1;
    protected static final int PARAM_INDEX_USE_HISTORY = 2;
    protected static final int PARAM_INDEX_START_DATE = 3;
    protected static final int PARAM_INDEX_END_DATE = 4;

    /* Helpers */
    private VelocityHelper velocityHelper = new JdbcVelocityHelper();
    private String tempFilePath;
    private String tempFileName;

    /* VTL template variables */
    private String authorName;
    private String authorOrg;
    private String contactInfo;

    /* request, i.e., schedule, parameters */
    private String orgId;
    private boolean makeHeader = true;
    private boolean useSubmissionHistory = true;
    private Timestamp startDate;
    private Timestamp endDate;

    // private Timestamp

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

    }

    protected ProcessContentResult generateAndSubmitFile(NodeTransaction aTran,
            String templateName, String outfileBaseName,
            WqxOperationType operationType) {

        debug("Validating transaction...");
        validateTransaction(aTran);

        NodeTransaction transaction = aTran;
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            setOptionsFromTransactionParams(transaction);

            if (useSubmissionHistory) {

                checkForPendingSubmissions(operationType, orgId);
                result.getAuditEntries().add(
                        makeEntry("No pending submissions"));

            } else {
                result.getAuditEntries().add(
                        makeEntry("Ignoring submission history."));
            }

            /* CREATE THE DOCUMENT TO SUBMIT */
            result.getAuditEntries().add(makeEntry("Generating xml file..."));

            String docId = getIdGenerator().createId();

            generateXmlDoc(orgId, operationType, outfileBaseName, templateName,
                    docId);

            result.getAuditEntries().add(
                    makeEntry("Xml file generated with template "
                            + templateName));

            Document doc = makeDocument(transaction, docId);

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

            getTransactionDao().updateNetworkId(transaction.getId(),
                    transaction.getNetworkId());

            result.getAuditEntries().add(
                    makeEntry("resultTran.getId(): " + transaction.getId()));
            result.getAuditEntries().add(
                    makeEntry("resultTran.getNetworkId(): "
                            + transaction.getNetworkId()));

            /* SAVE RESULTS */
            if (useSubmissionHistory) {
                saveSubmissionHistory(transaction, operationType);
                result.getAuditEntries().add(
                        makeEntry("Recorded document submission."));
            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Pending);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }
        debug("Returning result: " + result);
        return result;
    }

    /**
     * @param transaction
     * @throws ParseException
     */
    private void setOptionsFromTransactionParams(NodeTransaction transaction)
            throws ParseException {

        /*
         * orgId is required - validateTransaction() will have already thrown an
         * exception if it's missing
         */
        orgId = getOrgIdFromTransaction(transaction);
        debug("orgId = " + orgId);

        int argCount = transaction.getRequest().getParameters().size();

        if (argCount >= 2) {
            String addHeader = getOptionalValueFromTransactionArgs(transaction,
                    PARAM_INDEX_ADD_HEADER);

            /* makeHeader defaults to true */
            if (StringUtils.isNotBlank(addHeader)) {
                makeHeader = Boolean.parseBoolean(addHeader);
                debug("makeHeader = " + makeHeader);
            }
        }

        if (argCount >= 3) {
            /* useSubmissionHistory defaults to true */
            String useHistory = getOptionalValueFromTransactionArgs(
                    transaction, PARAM_INDEX_USE_HISTORY);

            if (StringUtils.isNotBlank(useHistory)) {
                useSubmissionHistory = Boolean.parseBoolean(useHistory);
                debug("useSubmissionHistory = " + useSubmissionHistory);
            }
        }

        if (argCount >= 4) {
            /* both start & end dates are optional. */
            String startString = getOptionalValueFromTransactionArgs(
                    transaction, PARAM_INDEX_START_DATE);
            debug("startString = " + startString);

            String endString = null;

            if (argCount >= 5) {
                endString = getOptionalValueFromTransactionArgs(transaction,
                        PARAM_INDEX_END_DATE);
                debug("endString = " + endString);
            }

            /* if start is empty, ignore end. */
            if (StringUtils.isNotBlank(startString)) {

                startDate = makeTimestamp(startString);
                debug("startDate = " + startDate);

                /* if start not empty but end is, set end to now */
                if (StringUtils.isNotBlank(endString)) {

                    endDate = makeTimestamp(endString);

                } else {

                    endDate = new Timestamp(System.currentTimeMillis());
                }
                debug("endDate = " + endDate);
            }
        }

    }

    /**
     * @param s
     * @return
     * @throws ParseException
     */
    private Timestamp makeTimestamp(String s) throws ParseException {

        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        Date date = sdf.parse(s);

        return new Timestamp(date.getTime());
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

        if (null == transaction.getRequest().getParameters().get(0)) {
            throw new RuntimeException("Missing parameter: " + TEMPLATE_ORG_ID);
        }
    }

    private void saveSubmissionHistory(NodeTransaction transaction,
            WqxOperationType operationType) {

        if (StringUtils.isBlank(transaction.getId())) {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }

        debug("Saving transaction status to WQX_SubmissionHistory table...");
        getStatusDao().createStatus(getIdGenerator().createId(),
                getOrgIdFromTransaction(transaction), operationType,
                transaction.getId(), CommonTransactionStatusCode.Pending);
    }

    private void checkForPendingSubmissions(WqxOperationType operationType,
            String orgId) {

        logger.debug("Checking for pending submissions...");

        if (null != getStatusDao()
                .getPendingTransactionId(orgId, operationType)) {
            throw new UnsupportedOperationException(
                    WqxStatusDao.NO_NEW_STATUS_WHEN_PENDING);
        }
    }

    private int generateXmlDoc(String orgId, WqxOperationType operationType,
            String outfileBaseName, String templateName, String docId) {

        // we set this template var to "false" in our unit test to simplify
        // schema validation
        velocityHelper.setTemplateArg(TEMPLATE_MAKE_HEADER, makeHeader);

        if (makeHeader) {
            velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_NAME, authorName);
            velocityHelper.setTemplateArg(TEMPLATE_AUTHOR_ORG, authorOrg);
            velocityHelper.setTemplateArg(TEMPLATE_CONTACT_INFO, contactInfo);
        }

        velocityHelper.setTemplateArg(TEMPLATE_ORG_ID, orgId);

        velocityHelper.setTemplateArg(TEMPLATE_DOC_ID, docId);

        /*
         * if startDate isn't null, the template will ignore the
         * lastProcessedTimestamp and instead query for items >= startDate and <
         * endDate
         */
        if (null != startDate) {

            velocityHelper.setTemplateArg(TEMPLATE_START_DATE, startDate
                    .toString());
            velocityHelper
                    .setTemplateArg(TEMPLATE_END_DATE, endDate.toString());
        } else {

            Timestamp lastProcessedTimestamp = getLastProcessedTimestamp(orgId,
                    operationType);

            if (null == lastProcessedTimestamp) {

                velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                        ARBITRARY_START_DATE);

            } else {

                velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                        lastProcessedTimestamp.toString());
            }
        }

        setTempFilePath(FilenameUtils.concat(getSettingService().getTempDir()
                .getAbsolutePath(), outfileBaseName + docId + XML_EXT));

        return velocityHelper.merge(templateName, getTempFilePath());

    }

    private Timestamp getLastProcessedTimestamp(String orgId,
            WqxOperationType operationType) {

        Timestamp lastProcessedTimestamp = getStatusDao()
                .getLatestProcessedTimestamp(orgId, operationType);

        if (null == lastProcessedTimestamp) {

            velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                    ARBITRARY_START_DATE);

        } else {

            velocityHelper.setTemplateArg(TEMPLATE_LAST_PROCESSED,
                    lastProcessedTimestamp.toString());
        }

        return lastProcessedTimestamp;
    }

    private Document makeDocument(NodeTransaction transaction, String docId)
            throws IOException {

        Document doc = new Document();
        doc.setDocumentId(docId);
        doc.setId(docId);

        if (transaction.getRequest().getType() != RequestType.QUERY) {

            String zippedFilePath = zip(getTempFilePath());
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
     * Copied from ZipComressionService in Wnos_Logic, and modified so that the
     * resulting ZIP file has only a .zip extension, rather than .xml.zip.
     * <p>
     * This is required by the mid-tier EPA node for WQX, which fails silently
     * with a NullPointerException if it encounters &quot;foo.xml.zip&quot;
     * </p>
     * 
     * @param sourceFilePath
     * @return
     */
    private String zip(String sourceFilePath) {

        byte[] buf = new byte[MEGA];

        debug("Zipping " + sourceFilePath);

        try {

            File sourceFile = IOUtil.getExistentFile(sourceFilePath);

            String resultPath = FilenameUtils.concat(FilenameUtils
                    .getFullPath(sourceFilePath), FilenameUtils
                    .getBaseName(sourceFilePath)
                    + ".zip");

            debug("Result will be " + resultPath);

            ZipOutputStream out = new ZipOutputStream(new FileOutputStream(
                    resultPath));

            FileInputStream in = new FileInputStream(sourceFile);

            // Add ZIP entry to output stream.
            out.putNextEntry(new ZipEntry(sourceFile.getName()));

            // Transfer bytes from the file to the ZIP file
            int len;
            while ((len = in.read(buf)) > 0) {
                out.write(buf, 0, len);
            }

            // Complete the entry
            out.closeEntry();
            in.close();

            // Complete the ZIP file
            out.close();

            debug("Zip operation succeeded.");
            return resultPath;

        } catch (IOException ioe) {

            logger.error("Unhandled exception: " + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping file: "
                    + sourceFilePath, ioe);
        }

    }

    /**
     * @return the tempFilePath
     */
    public String getTempFilePath() {
        return tempFilePath;
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
}

package com.windsor.node.plugin.icisnpdes20;

import java.io.File;
import java.io.IOException;
import java.sql.Date;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.icisnpdes20.dao.SubmissionHistoryDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class DmrSubmissionGenerator extends BaseWnosPlugin implements
        InitializingBean {

    public static final String SERVICE_NAME = "GenerateDMRSubmission";
    public static final String ARBITRARY_START_DATE = "1970-01-01";

    protected static final String ERR_BAD_DATE_FORMAT = "Bad date format - must be yyy-MM-dd";
    protected static final String ERR_NO_DMR_DATA = "No DMR data found for input criteria.";
    protected static final String ERR_USER_ID_REQUIRED = "UserId required but missing";

    protected static final String TEMPLATE_NAME = "ICIS_NPDES_DMR.vm";
    protected static final String OUTFILE_BASE_NAME = "ICIS-NPDES_DMR";
    protected static final String DATE_FORMAT = "yyyy-MM-dd";
    protected static final String TEMPLATE_ICIS_ID = "icisId";
    protected static final String TEMPLATE_LAST_PAYLOAD_UPDATE = "lastPayloadUpdateDate";

    protected static final int PARAM_INDEX_USERID = 0;
    protected static final int PARAM_INDEX_LAST_UPDATE = 1;
    protected static final int PARAM_INDEX_USE_HISTORY = 2;
    protected static final int PARAM_INDEX_IGNORE_PREVIOUS = 3;

    public static final PluginServiceParameterDescriptor USER_ID = new PluginServiceParameterDescriptor(
                    "UserId",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.TRUE,
                    "The UserId is the ICIS-NPDES User ID for which the submission will be made. This parameter triggers the plugin to filter the data in the staging tables for a single ICIS-NPDES user. This filter targets the ID field in the ICIS_DOCUMENT table. It is recommended that one permanent record be created in the ICIS_ DOCUMENT table for each ICIS user and that one Schedule be created for each user.");
    public static final PluginServiceParameterDescriptor LAST_PAYLOAD_UPDATE_DATE = new PluginServiceParameterDescriptor(
                    "LastPayloadUpdateDate",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.FALSE,
                    "If supplied, the Schedule will filter the query performed against the ICIS-NPDES staging database to retrieve records that were loaded to the staging environment after this date. The filter targets the LAST_PAYLOAD_UPDATE_DATE in the ICIS_PAYLOAD_DATA table. The LAST_PAYLOAD_UPDATE_DATE should always be the date stamp of the time when the data was loaded to the staging database. If supplied, this parameter must be in YYYY-MM-DD format.");
    public static final PluginServiceParameterDescriptor USE_SUBMISSION_HISTORY_TABLE = new PluginServiceParameterDescriptor(
                    "UseSubmissionHistoryTable",
                    PluginServiceParameterDescriptor.TYPE_BOOLEAN,
                    Boolean.FALSE,
                    "If this parameter is not set or set to “true”, the plugin will always create a record to the submission history table when a submission is performed. If set to “false”, no record of the submission will be logged in this table. Regardless of this setting, OpenNode2 will still log that the transaction occurred and it can still be found using the OpenNode2 Admin Activity search screen.");

    private static final String FALSE = "false";
    private static final String TRUE = "true";

    private VelocityHelper velocityHelper;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;

    private SubmissionHistoryDao submissionHistoryDao;
    private TransactionDao transactionDao;

    private String icisId;
    private boolean useSubmissionHistory = true;
    private boolean ignorePreviousSubmissions = false;
    private Date lastPayloadUpdateDate;
    private DataSource pluginDataSource;

    public DmrSubmissionGenerator() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        getSupportedPluginTypes().add(ServiceType.TASK);

        velocityHelper = new JdbcVelocityHelper();
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(USER_ID);
        params.add(LAST_PAYLOAD_UPDATE_DATE);
        params.add(USE_SUBMISSION_HISTORY_TABLE);
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Validating transaction...");
        validateTransaction(transaction);

        debug("Setting properties from request parameters...");
        setPropertiesFromRequestParams(transaction);

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.getAuditEntries().add(makeEntry("Preparing DMR submission..."));

        try {

            Document doc = null;

            /*
             * if lastPayloadUpdateDate > 1 Jan 1970, we assume it was supplied
             * in request
             */
            if (getLastPayloadUpdateDate().after(
                    Date.valueOf(ARBITRARY_START_DATE))) {

                debug("lastPayloadUpdateDate: " + getLastPayloadUpdateDate());
                doc = generateDocument(result.getAuditEntries());

                if (isUseSubmissionHistory()) {
                    saveSubmissionHistory(transaction.getId());
                }

            } else if (isUseSubmissionHistory()
                    && !isIgnorePreviousSubmissions()) {

                /*
                 * check status of all submissions for icisId with status other
                 * than Processed, Completed, or Failed. If any found, bail out.
                 */

                result.getAuditEntries().add(
                        makeEntry("Checking for pending submissions..."));

                if (hasPendingSubmissions(getIcisId())) {

                    throw new RuntimeException("Icis id " + getIcisId()
                            + " has pending submissions.");
                } else {

                    // ELSE set lastPayloadUpdateDate to latest successful
                    // submission,and generate file, passing in icisId &
                    // lastPayloadUpdateDate

                    setLastPayloadUpdateDate(getLastSubmissionDate(getIcisId()));
                    doc = generateDocument(result.getAuditEntries());

                    saveSubmissionHistory(transaction.getId());
                }

            } else {

                doc = generateDocument(result.getAuditEntries());

                if (isUseSubmissionHistory()) {
                    saveSubmissionHistory(transaction.getId());
                }
            }

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
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

        return result;
    }

    private void saveSubmissionHistory(String transactionId) {

        submissionHistoryDao.insertSubmissionHistory(getIcisId(),
                new Timestamp(System.currentTimeMillis()), new Timestamp(
                        getLastPayloadUpdateDate().getTime()), transactionId);
    }

    /**
     * @param icisId
     * @return
     */
    private Date getLastSubmissionDate(String icisId) {

        Date date = null;

        Timestamp ts = submissionHistoryDao
                .getLastPayloadUpdateByIcisId(getIcisId());

        if (null != ts) {

            date = new Date(ts.getTime());

        } else {

            date = Date.valueOf(ARBITRARY_START_DATE);
        }

        return date;
    }

    /**
     * Check status of all submissions for icisId with status other than
     * Processed, Completed, or Failed; if any found, bail out.
     * 
     * @param icisId
     * @return
     */
    private boolean hasPendingSubmissions(String icisId) {

        boolean hasPending = true;

        /*
         * 1. get last tran for icisId from node db
         */
        String latestTranId = submissionHistoryDao
                .getLatestTranIdForIcisId(icisId);
        debug("latestTranid: " + latestTranId);

        NodeTransaction latestTran = transactionDao.get(latestTranId, false);
        CommonTransactionStatusCode status = latestTran.getStatus().getStatus();

        if (null != latestTran) {

            debug("Found local transaction.");
            /*
             * 2. if status not(completed|failed), return false, else return
             * true
             */
            hasPending = isPending(status);
            debug("hasPending: " + hasPending);

        }

        return hasPending;
    }

    private boolean isPending(CommonTransactionStatusCode status) {

        boolean hasPending = false;

        if (!status.equals(CommonTransactionStatusCode.Completed)
                && !status.equals(CommonTransactionStatusCode.Failed)) {

            hasPending = true;
        }

        return hasPending;
    }

    /**
     * @param auditEntries
     * @return
     * @throws IOException
     */
    protected Document generateDocument(List<ActivityEntry> auditEntries)
            throws IOException {

        String docId = idGenerator.createId();

        String tempFilePath = FilenameUtils.concat(settingService.getTempDir()
                .getAbsolutePath(), OUTFILE_BASE_NAME + docId + ".xml");

        auditEntries.add(makeEntry("Generating xml file " + tempFilePath));

        auditEntries.add(makeEntry("Setting icisId to " + getIcisId()));
        velocityHelper.setTemplateArg(TEMPLATE_ICIS_ID, getIcisId());

        auditEntries.add(makeEntry("Setting lastPayloadUpdateDate to "
                + getLastPayloadUpdateDate()));
        velocityHelper.setTemplateArg(TEMPLATE_LAST_PAYLOAD_UPDATE,
                getLastPayloadUpdateDate());

        int dmrCount = velocityHelper.merge(TEMPLATE_NAME, tempFilePath);

        if (dmrCount == 0) {
            throw new RuntimeException(ERR_NO_DMR_DATA);
        }

        auditEntries.add(makeEntry("Xml file generated."));
        auditEntries.add(makeEntry("Compressing results..."));

        Document doc = new Document();

        String zippedFilePath = getCompressionService().zip(tempFilePath);
        debug("Zipped result: " + zippedFilePath);
        doc.setType(CommonContentType.ZIP);

        doc.setDocumentName(FilenameUtils.getName(zippedFilePath));

        doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        return doc;
    }

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (getDataSources() == null
                && !getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source datasource not set");
        }

        if (null == pluginDataSource) {
            pluginDataSource = getDataSources().get(ARG_DS_SOURCE);
        }

        submissionHistoryDao = new SubmissionHistoryDao(pluginDataSource);

        velocityHelper.configure(pluginDataSource, getPluginSourceDir()
                .getAbsolutePath());

        compressionService = (CompressionService) getServiceFactory()
                .makeService(ZipCompressionService.class);

        if (compressionService == null) {
            throw new RuntimeException("Unable to obtain CompressionService");
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

        transactionDao = (JdbcTransactionDao) getServiceFactory().makeService(
                JdbcTransactionDao.class);

        if (transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }
    }

    /**
     * Sets plugin props from Request parameters (typically set in a schedule).
     * <ol>
     * <li>Gets REQUIRED UserId param from transaction</li>
     * <li>Gets OPTIONAL LastPayloadUpdateDate from transaction (default to Jan
     * 1, 1900 if nothing supplied)</li>
     * <li>Gets OPTIONAL UseSubmissionHistoryTable param from transaction
     * (default true)</li>
     * <li>Gets OPTIONAL (undocumented) IgnorePreviousSubmissions param from
     * transaction (default false)</li>
     * </ol>
     * 
     * 
     * @param transaction
     */
    protected void setPropertiesFromRequestParams(NodeTransaction transaction) {

        setIcisId(getRequiredValueFromTransactionArgs(transaction,
                PARAM_INDEX_USERID));

        String lastUpdateStr = getOptionalValueFromTransactionArgs(transaction,
                PARAM_INDEX_LAST_UPDATE);

        SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);

        try {

            if (StringUtils.isNotBlank(lastUpdateStr)) {

                setLastPayloadUpdateDate(new Date(sdf.parse(lastUpdateStr)
                        .getTime()));

            } else {

                setLastPayloadUpdateDate(new Date(sdf.parse(
                        ARBITRARY_START_DATE).getTime()));
            }

        } catch (ParseException e) {

            logger.error(ERR_BAD_DATE_FORMAT);
            throw new RuntimeException(ERR_BAD_DATE_FORMAT);
        }

        String useHistoryStr = getOptionalValueFromTransactionArgs(transaction,
                PARAM_INDEX_USE_HISTORY);

        if (StringUtils.isBlank(useHistoryStr)
                || useHistoryStr.equalsIgnoreCase(TRUE)) {

            setUseSubmissionHistory(true);

        } else if (useHistoryStr.equalsIgnoreCase(FALSE)) {

            setUseSubmissionHistory(false);
        }

        String ignorePreviousStr = getOptionalValueFromTransactionArgs(
                transaction, PARAM_INDEX_IGNORE_PREVIOUS);

        if (StringUtils.isBlank(ignorePreviousStr)
                || ignorePreviousStr.equalsIgnoreCase(FALSE)) {

            setIgnorePreviousSubmissions(false);

        } else if (ignorePreviousStr.equalsIgnoreCase(TRUE)) {

            setIgnorePreviousSubmissions(true);
        }
    }

    @Override
    protected void validateTransaction(NodeTransaction transaction) {

        super.validateTransaction(transaction);

        if (StringUtils.isBlank(getRequiredValueFromTransactionArgs(
                transaction, PARAM_INDEX_USERID))) {

            logger.error(ERR_USER_ID_REQUIRED);
            throw new RuntimeException(ERR_USER_ID_REQUIRED);
        }
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {

        return null;
    }

    public VelocityHelper getVelocityHelper() {
        return velocityHelper;
    }

    public void setVelocityHelper(VelocityHelper velocityHelper) {
        this.velocityHelper = velocityHelper;
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

    public TransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public boolean isUseSubmissionHistory() {
        return useSubmissionHistory;
    }

    public void setUseSubmissionHistory(boolean useSubmissionHistory) {
        this.useSubmissionHistory = useSubmissionHistory;
    }

    public boolean isIgnorePreviousSubmissions() {
        return ignorePreviousSubmissions;
    }

    public void setIgnorePreviousSubmissions(boolean ignorePreviousSubmissions) {
        this.ignorePreviousSubmissions = ignorePreviousSubmissions;
    }

    public Date getLastPayloadUpdateDate() {
        return lastPayloadUpdateDate;
    }

    public void setLastPayloadUpdateDate(Date lastPayloadUpdateDate) {
        this.lastPayloadUpdateDate = lastPayloadUpdateDate;
    }

    public String getIcisId() {
        return icisId;
    }

    public void setIcisId(String icisId) {
        this.icisId = icisId;
    }

    public DataSource getPluginDataSource() {
        return pluginDataSource;
    }

    public void setPluginDataSource(DataSource pluginDataSource) {
        this.pluginDataSource = pluginDataSource;
    }

    public SubmissionHistoryDao getSubmissionHistoryDao() {
        return submissionHistoryDao;
    }

    public void setSubmissionHistoryDao(
            SubmissionHistoryDao submissionHistoryDao) {
        this.submissionHistoryDao = submissionHistoryDao;
    }

}

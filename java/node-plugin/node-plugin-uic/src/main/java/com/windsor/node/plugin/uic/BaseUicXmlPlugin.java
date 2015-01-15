package com.windsor.node.plugin.uic;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.uic.dao.UicStatusDao;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.util.IOUtil;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;
import javax.sql.DataSource;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.springframework.beans.factory.InitializingBean;

public abstract class BaseUicXmlPlugin extends BaseUicPlugin implements InitializingBean
{
    public static final String ARBITRARY_START_DATE = "1899-01-01";
    public static final String TEMPLATE_AUTHOR_NAME = "authorName";
    public static final String TEMPLATE_AUTHOR_ORG = "authorOrg";
    public static final String TEMPLATE_CONTACT_INFO = "contactInfo";
    public static final String TEMPLATE_ORG_ID = "orgId";
    public static final String TEMPLATE_DOC_ID = "docId";
    public static final String TEMPLATE_LAST_PROCESSED = "lastProcessedTimestamp";
    public static final String TEMPLATE_MAKE_HEADER = "makeHeader";
    public static final String TEMPLATE_START_DATE = "startDate";
    public static final String TEMPLATE_END_DATE = "endDate";
    protected static final String XML_EXT = ".xml";
    private static final int MEGA = 1024;
    protected static final int PARAM_INDEX_ORGID = 0;
    protected static final int PARAM_INDEX_ADD_HEADER = 1;
    protected static final int PARAM_INDEX_USE_HISTORY = 2;
    protected static final int PARAM_INDEX_START_DATE = 3;
    protected static final int PARAM_INDEX_END_DATE = 4;
    private VelocityHelper velocityHelper = new JdbcVelocityHelper();
    private String tempFilePath;
    private String tempFileName;
    private String authorName;
    private String authorOrg;
    private String contactInfo;
    private String orgId;
    private boolean makeHeader = true;
    private boolean useSubmissionHistory = true;
    private Timestamp startDate;
    private Timestamp endDate;

    public BaseUicXmlPlugin()
    {
        getConfigurationArguments().put("Author", "");
        getConfigurationArguments().put("Contact Info", "");
        getConfigurationArguments().put("Organization", "");
    }

    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();

        this.authorName = getRequiredConfigValueAsString("Author");
        debug("authorName: " + this.authorName);

        if(StringUtils.isBlank(this.authorName))
        {
            throw new RuntimeException("blank authorName");
        }

        this.authorOrg = getRequiredConfigValueAsString("Organization");
        debug("authorOrg: " + this.authorOrg);

        if(StringUtils.isBlank(this.authorOrg))
        {
            throw new RuntimeException("blank authorOrg");
        }

        this.contactInfo = getRequiredConfigValueAsString("Contact Info");
        debug("contactInfo: " + this.contactInfo);

        if(StringUtils.isBlank(this.contactInfo))
        {
            throw new RuntimeException("blank contactInfo");
        }

        this.velocityHelper.configure((DataSource) getDataSources().get("Source Data Provider"), getPluginSourceDir().getAbsolutePath());
    }

    protected ProcessContentResult generateAndSubmitFile(NodeTransaction aTran, String templateName, String outfileBaseName, UicOperationType deleteInsert)
    {
        NodeTransaction transaction = aTran;
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        try
        {
            setOptionsFromTransactionParams(transaction);

            if(this.useSubmissionHistory)
            {
                checkForPendingSubmissions(deleteInsert, this.orgId);
                result.getAuditEntries().add(makeEntry("No pending submissions"));
            }
            else
            {
                result.getAuditEntries().add(makeEntry("Ignoring submission history."));
            }

            result.getAuditEntries().add(makeEntry("Generating xml file..."));

            String docId = getIdGenerator().createId();

            generateXmlDoc(this.orgId, deleteInsert, outfileBaseName, templateName, docId);

            result.getAuditEntries().add(makeEntry("Xml file generated"));

            Document doc = makeDocument(transaction, docId);

            result.getAuditEntries().add(makeEntry("Created document " + doc.getDocumentName() + " in " + getTempFilePath()));

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction.getRequest().getPaging()
                            .getCount(), true));

            result.getDocuments().add(doc);

            transaction.getDocuments().add(doc);

            debug("pre-submit transaction.getId(): " + transaction.getId());
            debug("pre-submit transaction.getNetworkId(): " + transaction.getNetworkId());

            PartnerIdentity partner = makePartner();

            NodeClientService client = makeNodeClient(partner);

            result.getAuditEntries().add(makeEntry("submitting to partner URL " + partner.getUrl()));

            transaction = client.submit(transaction);
            debug("submission returned with network transaction id " + transaction.getNetworkId());

            getTransactionDao().updateNetworkId(transaction.getId(), transaction.getNetworkId());

            result.getAuditEntries().add(makeEntry("resultTran.getId(): " + transaction.getId()));

            result.getAuditEntries().add(makeEntry("resultTran.getNetworkId(): " + transaction.getNetworkId()));

            if(this.useSubmissionHistory)
            {
                saveSubmissionHistory(transaction, deleteInsert);
                result.getAuditEntries().add(makeEntry("Recorded document submission."));
            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Pending);
            result.getAuditEntries().add(makeEntry("Done: OK"));
        }
        catch(Exception ex)
        {
            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(makeEntry("Error while executing: " + getClass().getName() + " Message: " + ex.getMessage()));
        }

        debug("Returning result: " + result);
        return result;
    }

    private void setOptionsFromTransactionParams(NodeTransaction transaction) throws ParseException
    {
        this.orgId = getOrgIdFromTransaction(transaction);
        debug("orgId = " + this.orgId);

        int argCount = transaction.getRequest().getParameters().size();

        if(argCount >= 2)
        {
            String addHeader = getOptionalValueFromTransactionArgs(transaction, 1);

            if(StringUtils.isNotBlank(addHeader))
            {
                this.makeHeader = Boolean.parseBoolean(addHeader);
                debug("makeHeader = " + this.makeHeader);
            }
        }

        if(argCount >= 3)
        {
            String useHistory = getOptionalValueFromTransactionArgs(transaction, 2);

            if(StringUtils.isNotBlank(useHistory))
            {
                this.useSubmissionHistory = Boolean.parseBoolean(useHistory);
                debug("useSubmissionHistory = " + this.useSubmissionHistory);
            }
        }

        if(argCount >= 4)
        {
            String startString = getOptionalValueFromTransactionArgs(transaction, 3);

            debug("startString = " + startString);

            String endString = null;

            if(argCount >= 5)
            {
                endString = getOptionalValueFromTransactionArgs(transaction, 4);

                debug("endString = " + endString);
            }

            if(StringUtils.isNotBlank(startString))
            {
                this.startDate = makeTimestamp(startString);
                debug("startDate = " + this.startDate);

                if(StringUtils.isNotBlank(endString))
                {
                    this.endDate = makeTimestamp(endString);
                }
                else
                {
                    this.endDate = new Timestamp(System.currentTimeMillis());
                }
                debug("endDate = " + this.endDate);
            }
        }
    }

    private Timestamp makeTimestamp(String s) throws ParseException
    {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        Date date = sdf.parse(s);

        return new Timestamp(date.getTime());
    }

    protected File getResultFile() throws IOException
    {
        File resultFile = new File(getTempFileName());

        if(!resultFile.exists())
        {
            throw new IOException("Result file not found: " + getTempFileName());
        }

        return resultFile;
    }

    protected void validateTransaction(NodeTransaction transaction)
    {
        super.validateTransaction(transaction);

        if(null == transaction.getRequest().getParameters().get(0))
            throw new RuntimeException("Missing parameter: orgId");
    }

    private void saveSubmissionHistory(NodeTransaction transaction, UicOperationType operationType)
    {
        if(StringUtils.isBlank(transaction.getId()))
        {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }

        debug("Saving transaction status to UIC_SubmissionHistory table...");
        getStatusDao().createStatus(getIdGenerator().createId(), getOrgIdFromTransaction(transaction), operationType, transaction.getId(),
                        CommonTransactionStatusCode.Pending);
    }

    private void checkForPendingSubmissions(UicOperationType operationType, String orgId)
    {
        this.logger.debug("Checking for pending submissions...");

        if(null != getStatusDao().getPendingTransactionId(orgId, operationType))
        {
            throw new UnsupportedOperationException(
                            "Can't create \"Pending\"  or \"Processing\" status when a transaction for that Organization and Operation type is already Pending or Processing.");
        }
    }

    private int generateXmlDoc(String orgId, UicOperationType operationType, String outfileBaseName, String templateName, String docId)
    {
        this.velocityHelper.setTemplateArg("makeHeader", Boolean.valueOf(this.makeHeader));

        if(this.makeHeader)
        {
            this.velocityHelper.setTemplateArg("authorName", this.authorName);
            this.velocityHelper.setTemplateArg("authorOrg", this.authorOrg);
            this.velocityHelper.setTemplateArg("contactInfo", this.contactInfo);
        }

        this.velocityHelper.setTemplateArg("orgId", orgId);

        this.velocityHelper.setTemplateArg("docId", docId);

        if(null != this.startDate)
        {
            this.velocityHelper.setTemplateArg("startDate", this.startDate.toString());

            this.velocityHelper.setTemplateArg("endDate", this.endDate.toString());
        }
        else
        {
            Timestamp lastProcessedTimestamp = getLastProcessedTimestamp(orgId, operationType);

            if(null == lastProcessedTimestamp)
            {
                this.velocityHelper.setTemplateArg("lastProcessedTimestamp", "1899-01-01");
            }
            else
            {
                this.velocityHelper.setTemplateArg("lastProcessedTimestamp", lastProcessedTimestamp.toString());
            }

        }

        setTempFilePath(FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), outfileBaseName + docId + ".xml"));

        return this.velocityHelper.merge(templateName, getTempFilePath());
    }

    private Timestamp getLastProcessedTimestamp(String orgId, UicOperationType operationType)
    {
        Timestamp lastProcessedTimestamp = getStatusDao().getLatestProcessedTimestamp(orgId, operationType);

        if(null == lastProcessedTimestamp)
        {
            this.velocityHelper.setTemplateArg("lastProcessedTimestamp", "1899-01-01");
        }
        else
        {
            this.velocityHelper.setTemplateArg("lastProcessedTimestamp", lastProcessedTimestamp.toString());
        }

        return lastProcessedTimestamp;
    }

    private Document makeDocument(NodeTransaction transaction, String docId) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(docId);
        doc.setId(docId);

        if(transaction.getRequest().getType() != RequestType.Query)
        {
            String zippedFilePath = zip(getTempFilePath());
            doc.setType(CommonContentType.ZIP);

            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));

            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        }
        else
        {
            doc.setType(CommonContentType.XML);

            doc.setDocumentName(FilenameUtils.getName(getTempFilePath()));

            doc.setContent(FileUtils.readFileToByteArray(new File(getTempFilePath())));
        }

        return doc;
    }

    private String zip(String sourceFilePath)
    {
        byte[] buf = new byte[1024];

        debug("Zipping " + sourceFilePath);
        try
        {
            File sourceFile = IOUtil.getExistentFile(sourceFilePath);

            String resultPath = FilenameUtils.concat(FilenameUtils.getFullPath(sourceFilePath), FilenameUtils.getBaseName(sourceFilePath) + ".zip");

            debug("Result will be " + resultPath);

            ZipOutputStream out = new ZipOutputStream(new FileOutputStream(resultPath));

            FileInputStream in = new FileInputStream(sourceFile);

            out.putNextEntry(new ZipEntry(sourceFile.getName()));
            int len;
            while ((len = in.read(buf)) > 0)
            {
                out.write(buf, 0, len);
            }

            out.closeEntry();
            in.close();

            out.close();

            debug("Zip operation succeeded.");
            return resultPath;
        }
        catch(IOException ioe)
        {
            this.logger.error("Unhandled exception: " + ioe.getMessage());

            ioe.printStackTrace();

            throw new RuntimeException("Error while zipping file: " + sourceFilePath, ioe);
        }
    }

    public String getTempFilePath()
    {
        return this.tempFilePath;
    }

    public void setTempFilePath(String tempFilePath)
    {
        this.tempFilePath = tempFilePath;
    }

    public String getTempFileName()
    {
        return this.tempFileName;
    }

    public void setTempFileName(String tempFileName)
    {
        this.tempFileName = tempFileName;
    }
}
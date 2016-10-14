package com.windsor.node.plugin.aqs;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.RemoteFileResourceHelper;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang3.StringUtils;

import javax.net.ssl.HttpsURLConnection;
import java.io.*;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * Provides a plugin for extracting data from AirVision.
 */
public class AirVisionProxyService extends BaseWnosJaxbPlugin {

    public static final String ARG_SERVICE_DAEMON_SERVICE_URL = "Service Base Url";
    public static final String ARG_SERVICE_PARTNER_ENDPOINT = "Partner Endpoint";
    public static final String ARG_HEADER_APPLICATION_IDENTIFIER = "Application Identifier";
    public static final String ARG_HEADER_AQS_SCREENING_GROUP = "AQS.ScreeningGroup";
    public static final String ARG_HEADER_AQS_FINAL_PROCESSING_STEP = "AQS.FinalProcessingStep";
    public static final String ARG_HEADER_AQS_STOP_ON_ERROR = "AQS.StopOnError";
    public static final PluginServiceParameterDescriptor START_TIME =
            new PluginServiceParameterDescriptor("StartTime", "java.lang.String", Boolean.TRUE,
                    "The earliest date for which to return data in YYYY-MM-DD format.");
    public static final PluginServiceParameterDescriptor END_TIME =
            new PluginServiceParameterDescriptor("EndTime", "java.lang.String", Boolean.TRUE,
                    "The latest date for which to return data in YYYY-MM-DD format.");
    public static final PluginServiceParameterDescriptor SEND_RD_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendRdTransactions", "java.lang.String", Boolean.FALSE,
                    "Flag indicating whether to include RD transactions in the query result.");
    public static final PluginServiceParameterDescriptor SEND_RB_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendRbTransactions", "java.lang.String", Boolean.FALSE,
                    "Flag indicating whether to include RB transactions in the query result.");
    public static final PluginServiceParameterDescriptor SEND_MONITORING_ASSURANCE_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendMonitoringAssuranceTransactions", "java.lang.String",
                    Boolean.FALSE,
                    "Flag indicating whether to include Mointoring Assurance Transactions in the query result.");
    public static final PluginServiceParameterDescriptor AGENCY_CODE =
            new PluginServiceParameterDescriptor("AgencyCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Agency Code.");
    public static final PluginServiceParameterDescriptor SITE_CODE =
            new PluginServiceParameterDescriptor("SiteCode", "java.lang.String", Boolean.FALSE, "AirVision Site Code.");
    public static final PluginServiceParameterDescriptor PARAMETER_CODE =
            new PluginServiceParameterDescriptor("ParameterCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Parameter Code.");

    private static final String FILE_PREFIX = "AQS_";
    private static final String FILE_EXTENSION_XML = "xml";

    private JdbcTransactionDao transactionDao;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("AirVisionProxyService");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR
                .setDescription("AirVision proxy service, will submit AQS files created by AirVision to CDX.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(AirVisionProxyService.class.getCanonicalName());
    }


    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }


    public AirVisionProxyService() {

        getConfigurationArguments().put("Service Base Url", "");
        getConfigurationArguments().put("Author", "");
        getConfigurationArguments().put("Contact Info", "");
        getConfigurationArguments().put("Organization", "");
        getConfigurationArguments().put("Document Title", "");
        getConfigurationArguments().put("Application Identifier", "");
        getConfigurationArguments().put("AQS.ScreeningGroup", "");
        getConfigurationArguments().put("AQS.FinalProcessingStep", "");
        getConfigurationArguments().put("AQS.StopOnError", "");
        getSupportedPluginTypes().add(ServiceType.QUERY);
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
    }


    public List<PluginServiceParameterDescriptor> getParameters() {

        List<PluginServiceParameterDescriptor> params = new ArrayList();
        params.add(START_TIME);
        params.add(END_TIME);
        params.add(SEND_RD_TRANSACTIONS);
        params.add(SEND_RB_TRANSACTIONS);
        params.add(SEND_MONITORING_ASSURANCE_TRANSACTIONS);
        params.add(AGENCY_CODE);
        params.add(SITE_CODE);
        params.add(PARAMETER_CODE);
        return params;
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getConfigurationArguments() == null) {
            throw new RuntimeException("ConfigurationArguments were empty.");
        }

        setTransactionDao((JdbcTransactionDao) getServiceFactory().makeService(JdbcTransactionDao.class));
        if (this.transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        setSettingService((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));
        setIdGenerator((IdGenerator) getServiceFactory().makeService(IdGenerator.class));
        setZipService((CompressionService) getServiceFactory().makeService(ZipCompressionService.class));
    }

    public ProcessContentResult process(NodeTransaction transaction) {
        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {
            RemoteFileResourceHelper restCaller = (RemoteFileResourceHelper) getServiceFactory().makeService(RemoteFileResourceHelper.class);
            String restUrl = constructAddress(transaction);
            result.getAuditEntries().add(makeEntry("Calling REST Url:  \"" + restUrl + "\""));

            byte[] response = null;
            if (restUrl.startsWith("http:")) {
                response = restCaller.getBytesFromURL(restUrl);
            } else if (restUrl.startsWith("https:")) {
                response = getBytesFromHttpsUrl(restUrl);
            } else {
                throw new WinNodeException("Not a valid URL scheme, must be http: or https:");
            }

            List<String> lines = null;
            String responseString = new String(response, "UTF-8");
            if (responseString.indexOf("ERROR") == -1) {
                File file = new File(responseString);
                result.getAuditEntries().add(makeEntry("Successfully completed call, response file name was:  " + file.getName()));
                FileInputStream in = new FileInputStream(file);

                List<String> fileLines = IOUtils.readLines(in);

                if ((fileLines != null) && (fileLines.size() > 0)) {
                    if (((String) fileLines.get(0)).startsWith("<?xml")) {
                        fileLines.remove(0);
                    }
                }
                lines = fileLines;

                result.getAuditEntries().add(makeEntry("Loaded response file into memory."));
            } else {
                result.getAuditEntries().add(makeEntry("REST service call caused remote error:  " + responseString));
            }

            result.getAuditEntries().add(makeEntry("Creating document..."));

            if (lines != null) {

                String docId = getIdGenerator().createId();
                String tempFilePath = makeTemporaryFilename(docId);
                result.getAuditEntries().add(makeEntry("Adding EN Header."));
                addHeader(lines, docId, transaction);
                result.getAuditEntries().add(makeEntry("EN Header added."));
                OutputStream output = new FileOutputStream(tempFilePath);
                IOUtils.writeLines(lines, null, output, "UTF-8");

                Document doc = makeDocument(transaction.getRequest().getType(), docId, tempFilePath);

                result.getAuditEntries().add(makeEntry("Setting result..."));
                result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction.getRequest().getPaging().getCount(), true));
                result.getDocuments().add(doc);
                result.setSuccess(true);
                result.setStatus(CommonTransactionStatusCode.Processed);
                result.getAuditEntries().add(makeEntry("Done: OK"));
            } else {
                result.setSuccess(false);
                result.setStatus(CommonTransactionStatusCode.Failed);
                result.getAuditEntries().add(makeEntry("Response file was not loaded into memory for some reason, unknown failure."));
            }

            getTransactionDao().save(transaction);
        } catch (Throwable e) {

            error(e.getMessage(), e);
            error(e.getMessage());
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.getAuditEntries().add(makeEntry("Error while executing: " + getClass().getName() + " Message: " + e.getMessage()));
        }

        return result;
    }

    private void addHeader(List<String> lines, String docId, NodeTransaction transaction) {

        String authorName = getConfigValueAsStringNoFail("Author");
        String contactInfo = getConfigValueAsStringNoFail("Contact Info");
        String orgName = getConfigValueAsStringNoFail("Organization");
        String aqsScreeningGroup = getConfigValueAsStringNoFail("AQS.ScreeningGroup");
        String aqsFinalProcessingStep = getConfigValueAsStringNoFail("AQS.FinalProcessingStep");
        String aqsStopOnError = getConfigValueAsStringNoFail("AQS.StopOnError");
        String documentTitle = getConfigValueAsStringNoFail("Document Title");
        String applicationIdentifier = getConfigValueAsStringNoFail("Application Identifier");
        StringBuffer header = new StringBuffer();
        StringBuffer footer = new StringBuffer();

        header.append("<hdr:Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ").append("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ").append("xmlns:hdr=\"http://www.exchangenetwork.net/schema/header/2\" ").append(" id=\"").append(docId).append("\">");
        header.append("\n").append("<hdr:Header>");
        header.append("\n").append("    ").append("<hdr:AuthorName>").append(authorName).append("</hdr:AuthorName>");
        header.append("\n").append("    ").append("<hdr:OrganizationName>").append(orgName).append("</hdr:OrganizationName>");
        header.append("\n").append("    ").append("<hdr:DocumentTitle>").append(documentTitle).append("</hdr:DocumentTitle>");
        header.append("\n").append("    ").append("<hdr:CreationDateTime>").append(getDocumentCreationDateTime()).append("</hdr:CreationDateTime>");
        header.append("\n").append("    ").append("<hdr:DataFlowName>").append(transaction.getRequest().getFlowName()).append("</hdr:DataFlowName>");
        header.append("\n").append("    ").append("<hdr:DataServiceName>").append(transaction.getRequest().getService().getName()).append("</hdr:DataServiceName>");
        header.append("\n").append("    ").append("<hdr:ApplicationUserIdentifier>").append(applicationIdentifier).append("</hdr:ApplicationUserIdentifier>");
        header.append("\n").append("    ").append("<hdr:SenderAddress>").append(contactInfo).append("</hdr:SenderAddress>");
        header.append("\n").append("    ").append("<hdr:Property>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.ScreeningGroup</hdr:PropertyName>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsScreeningGroup).append("</hdr:PropertyValue>");
        header.append("\n").append("    ").append("</hdr:Property>");
        header.append("\n").append("    ").append("<hdr:Property>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.FinalProcessingStep</hdr:PropertyName>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsFinalProcessingStep).append("</hdr:PropertyValue>");
        header.append("\n").append("    ").append("</hdr:Property>");
        header.append("\n").append("    ").append("<hdr:Property>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.StopOnError</hdr:PropertyName>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsStopOnError).append("</hdr:PropertyValue>");
        header.append("\n").append("    ").append("</hdr:Property>");
        header.append("\n").append("    ").append("<hdr:Property>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.SchemaVersion</hdr:PropertyName>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">2.2</hdr:PropertyValue>");
        header.append("\n").append("    ").append("</hdr:Property>");
        header.append("\n").append("    ").append("<hdr:Property>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.PayloadType</hdr:PropertyName>");
        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">XML</hdr:PropertyValue>");
        header.append("\n").append("    ").append("</hdr:Property>");
        header.append("\n").append("</hdr:Header>");
        header.append("\n").append("    ").append("<hdr:Payload id=\"").append(transaction.getId()).append("\">");

        footer.append("\n").append("    ").append("</hdr:Payload>");
        footer.append("\n").append("</hdr:Document>");

        lines.add(0, header.toString());
        lines.add(footer.toString());
    }


    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath)
            throws IOException {

        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if (!RequestType.Query.equals(requestType)) {

            String zippedFilePath = getZipService().zip(absolutefilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        } else {

            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
        }

        return doc;
    }

    private String makeTemporaryFilename(String docId) {
        return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "AQS_" +
                getClass().getSimpleName() + docId + "." + "xml");
    }


    public byte[] getBytesFromHttpsUrl(String address) {

        try {

            URL url = new URL(address);
            HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
            InputStream fis = conn.getInputStream();
            ByteArrayOutputStream byteArrOut = new ByteArrayOutputStream();

            byte[] buf = new byte['　'];
            int ln;
            while ((ln = fis.read(buf)) != -1) {
                byteArrOut.write(buf, 0, ln);
            }

            return byteArrOut.toByteArray();
        } catch (Exception ex) {

            this.logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while getting content from Url: " + address, ex);
        }
    }

    protected String constructAddress(NodeTransaction transaction) {

        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        String startDate = (String) namedParams.get(START_TIME.getName());
        String endDate = (String) namedParams.get(END_TIME.getName());
        String daemonServiceUrl = getConfigValueAsString("Service Base Url", false);

        StringBuffer url = new StringBuffer();
        url.append(daemonServiceUrl).append("/aqs/").append(startDate).append("/").append(endDate);

        String sendRd = (String) namedParams.get(SEND_RD_TRANSACTIONS.getName());
        if (StringUtils.isNotBlank(sendRd)) {
            url.append("/").append(sendRd);
        } else {
            url.append("/").append("false");
        }

        String sendRb = (String) namedParams.get(SEND_RB_TRANSACTIONS.getName());
        if (StringUtils.isNotBlank(sendRb)) {
            url.append("/").append(sendRb);
        } else {
            url.append("/").append("false");
        }

        String sendRp = (String) namedParams.get(SEND_MONITORING_ASSURANCE_TRANSACTIONS.getName());
        if (StringUtils.isNotBlank(sendRp)) {
            url.append("/").append(sendRp);
        } else {
            url.append("/").append("false");
        }

        String agencyCode = (String) namedParams.get(AGENCY_CODE.getName());
        if (StringUtils.isNotBlank(agencyCode)) {
            url.append("/").append(agencyCode);
        } else {
            url.append("/").append("none");
        }

        String siteCode = (String) namedParams.get(SITE_CODE.getName());
        if (StringUtils.isNotBlank(siteCode)) {
            url.append("/").append(siteCode);
        } else {
            url.append("/").append("none");
        }

        String parameterCode = (String) namedParams.get(PARAMETER_CODE.getName());
        if (StringUtils.isNotBlank(parameterCode)) {
            url.append("/").append(parameterCode);
        } else {
            url.append("/").append("none");
        }

        return url.toString();
    }


    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    public JdbcTransactionDao getTransactionDao() {
        return this.transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public IdGenerator getIdGenerator() {
        return this.idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

    public SettingServiceProvider getSettingService() {
        return this.settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public CompressionService getZipService() {
        return this.zipService;
    }

    public void setZipService(CompressionService zipService) {
        this.zipService = zipService;
    }
}
package com.windsor.node.plugin.aqs;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.cxf.endpoint.Client;
import org.apache.cxf.frontend.ClientProxy;
import org.apache.cxf.transport.http.HTTPConduit;
import org.apache.cxf.transports.http.configuration.HTTPClientPolicy;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.*;
import org.tempuri.*;

import javax.xml.bind.JAXBElement;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import javax.xml.namespace.QName;

import javax.net.ssl.HttpsURLConnection;
import javax.xml.ws.BindingProvider;
import javax.xml.ws.Service;
import javax.xml.ws.soap.SOAPFaultException;
import java.io.*;
import java.net.MalformedURLException;
import java.net.URL;
import java.sql.*;
import java.util.*;
import java.util.Date;

/**
 * Provides a plugin for extracting data from AirVision.
 */
public class AirVisionProxyService extends BaseWnosJaxbPlugin {

    public static final String ARG_SERVICE_DAEMON_SERVICE_URL = "Service Base Url";
    public static final String ARG_HEADER_APPLICATION_IDENTIFIER = "AQS User Info";
    public static final String ARG_HEADER_AQS_SCREENING_GROUP = "AQS.ScreeningGroup";
    public static final String ARG_HEADER_AQS_FINAL_PROCESSING_STEP = "AQS.FinalProcessingStep";
    public static final String ARG_HEADER_AQS_STOP_ON_ERROR = "AQS.StopOnError";
    public static final String ARG_AIRVISION_URL = "AirVision URL";
    public static final String ARG_AUTHOR = "Author";
    public static final String ARG_CONTACT_INFO = "Contact Info";
    public static final String ARG_ORGANIZATION = "Organization";
    public static final String ARG_DOCUMENT_TITLE = "Document Title";

    public static final PluginServiceParameterDescriptor START_TIME =
            new PluginServiceParameterDescriptor("StartTime", "java.lang.String", Boolean.TRUE,
                    "The earliest date for which to return data in YYYY-MM-DD hh:mm format.");
    public static final PluginServiceParameterDescriptor END_TIME =
            new PluginServiceParameterDescriptor("EndTime", "java.lang.String", Boolean.TRUE,
                    "The latest date for which to return data in YYYY-MM-DD hh:mm format.");
    public static final PluginServiceParameterDescriptor SEND_RD_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendRdTransactions", "java.lang.String", Boolean.FALSE,
                    "Flag indicating whether to include RD transactions in the query result (\"true\" or \"false\").");
    public static final PluginServiceParameterDescriptor SEND_RB_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendRbTransactions", "java.lang.String", Boolean.FALSE,
                    "Flag indicating whether to include RB transactions in the query result (\"true\" or \"false\").");
    public static final PluginServiceParameterDescriptor SEND_MONITORING_ASSURANCE_TRANSACTIONS =
            new PluginServiceParameterDescriptor("SendMonitoringAssuranceTransactions", "java.lang.String",
                    Boolean.FALSE,
                    "Flag indicating whether to include Mointoring Assurance Transactions in the query result (\"true\" or \"false\").");
    public static final PluginServiceParameterDescriptor AGENCY_CODE =
            new PluginServiceParameterDescriptor("AgencyCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Agency Code, you may use \"|\" to delimit multiple values.");
    public static final PluginServiceParameterDescriptor SITE_CODE =
            new PluginServiceParameterDescriptor("SiteCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Site Code, you may use \"|\4" +
                            " to delimit multiple values.");
    public static final PluginServiceParameterDescriptor PARAMETER_CODE =
            new PluginServiceParameterDescriptor("ParameterCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Parameter Code you may use \"|\" to delimit multiple values.");
    public static final PluginServiceParameterDescriptor DURATION_CODE =
            new PluginServiceParameterDescriptor("DurationCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Duration Code.");
    public static final PluginServiceParameterDescriptor OCCURRENCE_CODE =
            new PluginServiceParameterDescriptor("OccurrenceCode", "java.lang.String", Boolean.FALSE,
                    "AirVision Occurrence Code.");
    public static final PluginServiceParameterDescriptor STATE_CODE =
            new PluginServiceParameterDescriptor("StateCode", "java.lang.String", Boolean.FALSE,
                    "AirVision State Code you may use \"|\" to delimit multiple values.");
    public static final PluginServiceParameterDescriptor COUNTY_TRIBAL_CODE =
            new PluginServiceParameterDescriptor("CountyTribalCode", "java.lang.String", Boolean.FALSE,
                    "AirVision County Tribal Code.");
    public static final PluginServiceParameterDescriptor SEND_ONLY_QA_DATA =
            new PluginServiceParameterDescriptor("SendOnlyQAData", "java.lang.String", Boolean.FALSE,
                    "Flag indicating that AirVision should only send QA data (\"true\" or \"false\")/");

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

        getConfigurationArguments().put(ARG_AIRVISION_URL, "");
        getConfigurationArguments().put(ARG_AUTHOR, "");
        getConfigurationArguments().put(ARG_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_ORGANIZATION, "");
        getConfigurationArguments().put(ARG_DOCUMENT_TITLE, "");
        getConfigurationArguments().put(ARG_HEADER_APPLICATION_IDENTIFIER, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_SCREENING_GROUP, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_FINAL_PROCESSING_STEP, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_STOP_ON_ERROR, "");
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
        params.add(SEND_ONLY_QA_DATA);
        params.add(AGENCY_CODE);
        params.add(SITE_CODE);
        params.add(PARAMETER_CODE);
        params.add(DURATION_CODE);
        params.add(OCCURRENCE_CODE);
        params.add(STATE_CODE);
        params.add(COUNTY_TRIBAL_CODE);
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

        // dump all traffic
        System.setProperty("com.sun.xml.ws.transport.http.HttpAdapter.dump", "true");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        // get a handle on our parameters
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();

        // accumulate a list of documents
        List<Document> documents = new ArrayList<>();
        result.setDocuments(documents);

        // setup a temporary output directory for our results
        File tempOutput = new File(System.getProperty("java.io.tmpdir"));

        /*
         * Get the AQS data from AirVision
         */

        // setup our parameters
        Map<AqsParams, Object> aqsParamsMap = new HashMap();
        aqsParamsMap.put(AqsParams.StartTime, parseSQLDate((String) namedParams.get(START_TIME.getName())));
        aqsParamsMap.put(AqsParams.EndTime, parseSQLDate((String) namedParams.get(END_TIME.getName())));
        aqsParamsMap.put(AqsParams.SendRdTransactions, namedParams.get(SEND_RD_TRANSACTIONS.getName()));
        aqsParamsMap.put(AqsParams.SendRbTransactions, namedParams.get(SEND_RB_TRANSACTIONS.getName()));
        aqsParamsMap.put(AqsParams.SendMonitorAssuranceTransactions,
                namedParams.get(SEND_MONITORING_ASSURANCE_TRANSACTIONS.getName()));
        aqsParamsMap.put(AqsParams.SendOnlyQAData,
                namedParams.get(SEND_ONLY_QA_DATA.getName()));
        aqsParamsMap.put(AqsParams.AgencyCode, namedParams.get(AGENCY_CODE.getName()));
        aqsParamsMap.put(AqsParams.SiteCode, namedParams.get(SITE_CODE.getName()));
        aqsParamsMap.put(AqsParams.ParameterCode, namedParams.get(PARAMETER_CODE.getName()));
        aqsParamsMap.put(AqsParams.DurationCode, namedParams.get(DURATION_CODE.getName()));
        aqsParamsMap.put(AqsParams.OccurrenceCode, namedParams.get(OCCURRENCE_CODE.getName()));
        aqsParamsMap.put(AqsParams.StateCode, namedParams.get(STATE_CODE.getName()));
        aqsParamsMap.put(AqsParams.CountyTribalCode, namedParams.get(COUNTY_TRIBAL_CODE.getName()));

        File aqsResultFile = null;
        String aqsResult = null;
        try {

            AQS3WebServiceArgument aqs3WebServiceArgument = getAQS3WebServiceArguments(aqsParamsMap);
            String paramOutString = "\n\nWill request data from Agile Air with the following parameters: \n" +
                    "Schema version: " + aqs3WebServiceArgument.getAQSXMLSchemaVersion() + "\n" +
                    "Start time: " + aqs3WebServiceArgument.getStartTime() + "\n" +
                    "End time: " + aqs3WebServiceArgument.getEndTime() + "\n" +
                    "Compress payload: " + aqs3WebServiceArgument.isCompressPayload() + "\n" +
                    "Send monitor assurance transaction: " +
                    aqs3WebServiceArgument.isSendMonitorAssuranceTransactions() + "\n" +
                    "Send only QA data: " + aqs3WebServiceArgument.isSendOnlyQAData() + "\n" +
                    "Send RB transactions: " + aqs3WebServiceArgument.isSendRBTransactions() + "\n" +
                    "Send RD transactions: " + aqs3WebServiceArgument.isSendRDTransactions() + "\n";

            if(aqs3WebServiceArgument.getTags() != null) {
                paramOutString += "Tags:\n";
                for (AQSParameterTag tag : aqs3WebServiceArgument.getTags().getAQSParameterTag()) {
                    paramOutString += "\n  Tag:";
                    paramOutString += "    Agency Code: " + tag.getAgencyCode() + "\n";
                    paramOutString += "    State Code: " + tag.getStateCode() + "\n";
                    paramOutString += "    Parameter Code: " + tag.getParameterCode() + "\n";
                    paramOutString += "    Site Code: " + tag.getSiteCode() + "\n";
                    paramOutString += "    County Tribal Code: " + tag.getCountyTribalCode() + "\n";
                    paramOutString += "    Duration Code: " + tag.getDurationCode() + "\n";
                    paramOutString += "    Parameter Occurrence Code: " + tag.getParameterOccurrenceCode() + "\n";
                }
            } else {
                paramOutString += "Tags: No tags sent in request parameters\n";
            }
            result.getAuditEntries().add(makeEntry(paramOutString));

            AQSXmlService aqsXmlService = getAQSDataService(getConfigValueAsStringNoFail(ARG_AIRVISION_URL));
            AQSXmlResultData aqsXmlResultData = aqsXmlService.getAQS3XmlData(aqs3WebServiceArgument);
            AqsResultHandler aqsResultHandler = new AqsResultHandlerImpl(tempOutput.getAbsolutePath());
            aqsResultFile = aqsResultHandler.handle(aqsXmlResultData);
            aqsResult = FileUtils.readFileToString(aqsResultFile, "UTF-8");
        } catch(SOAPFaultException exception) {
            error(exception.getMessage(), exception);
            error(exception.getMessage());
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.getAuditEntries().add(
                    makeEntry(
                            "\n\nI submitted my request to the AirVision server but I can't understand the response. " +
                            "This is a problem with your AirVision server, you will need to contact Agile Air in " +
                            "order to diagnose this issue. " +
                            "The complete error was: \"" +
                            exception.getMessage() + "\""));
            return result;
        } catch(DatatypeConfigurationException exception) {
            error(exception.getMessage(), exception);
            error(exception.getMessage());
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.getAuditEntries().add(
                    makeEntry(
                        "\n\nThe configuration settings submitted to AirVision were not valid, so I couldn't request " +
                        "any data from the AirVision server. Please review the settings in the exchange as well " +
                        "as the settings in this specific schedule. The complete error from AirVision was: \"" +
                        exception.getMessage() + "\""));
            return result;
        } catch(MalformedURLException exception) {
            error(exception.getMessage(), exception);
            error(exception.getMessage());
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.getAuditEntries().add(
                    makeEntry(
                            "\n\nThe URL for the AirVision server was not valid. This is particularly troublesome " +
                            "because the URL is hard-coded into this plugin. I am very sorry! " +
                            "The complete error was: \"" +
                            exception.getMessage() + "\""));
            return result;
        } catch(IOException exception) {
            error(exception.getMessage(), exception);
            error(exception.getMessage());
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);
            result.getAuditEntries().add(
                    makeEntry(
                            "\n\nI was unable to write the result file from the AirVision system to disk. This is most " +
                            "often caused by a mis-configuration of your Tomcat server. Please have your system " +
                            "administrator for your OpenNode2 instance verify that the Tomcat temporary directory " +
                            "is readable and writeable by the account that is running Tomcat. " +
                            "The complete error was: \"" +
                            exception.getMessage() + "\""));
            return result;
        }

        /*
         * Process the AQS result file
         */

        try {

            List<String> lines = null;
            if (aqsResult.indexOf("ERROR") == -1) {
                result.getAuditEntries().add(makeEntry("Successfully completed call, response file name was:  "
                        + aqsResultFile.getName()));
                FileInputStream in = new FileInputStream(aqsResultFile);

                List<String> fileLines = IOUtils.readLines(in);

                if ((fileLines != null) && (fileLines.size() > 0)) {
                    if (((String) fileLines.get(0)).startsWith("<?xml")) {
                        fileLines.remove(0);
                    }
                }
                lines = fileLines;

                result.getAuditEntries().add(makeEntry("Loaded response file into memory."));
            } else {
                result.getAuditEntries().add(makeEntry("REST service call caused remote error:  " + aqsResult));
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
                documents.add(doc);
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
            result.getAuditEntries().add(makeEntry(
                    "Error while executing: " + getClass().getName() + " Message: " + e.getMessage()));
        }

        return result;
    }

    private void addHeader(List<String> lines, String docId, NodeTransaction transaction) {

        String authorName = getConfigValueAsStringNoFail(ARG_AUTHOR);
        String contactInfo = getConfigValueAsStringNoFail(ARG_CONTACT_INFO);
        String orgName = getConfigValueAsStringNoFail(ARG_ORGANIZATION);
        String aqsScreeningGroup = getConfigValueAsStringNoFail(ARG_HEADER_AQS_SCREENING_GROUP);
        String aqsFinalProcessingStep = getConfigValueAsStringNoFail(ARG_HEADER_AQS_FINAL_PROCESSING_STEP);
        String aqsStopOnError = getConfigValueAsStringNoFail(ARG_HEADER_AQS_STOP_ON_ERROR);
        String documentTitle = getConfigValueAsStringNoFail(ARG_DOCUMENT_TITLE);
        String applicationIdentifier = getConfigValueAsStringNoFail(ARG_HEADER_APPLICATION_IDENTIFIER);
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
//        header.append("\n").append("    ").append("<hdr:Property>");
//        header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.SchemaVersion</hdr:PropertyName>");
//        header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">2.2</hdr:PropertyValue>");
//        header.append("\n").append("    ").append("</hdr:Property>");
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
        String daemonServiceUrl = getConfigValueAsString(ARG_SERVICE_DAEMON_SERVICE_URL, false);

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

    /**
     * Returns a GregorianCalendar instance initialized to date represented by the provided String.
     *
     * @param sqlDate String with valid SQL date
     * @return GregorianCalendar instance
     */
    private GregorianCalendar parseSQLDate(String sqlDate) {
        Date date = null;

        if(sqlDate.length() > 10 && sqlDate.length()  < 17) {
            date = Timestamp.valueOf(sqlDate + ":00");
        } else if(sqlDate.length() > 16) {
            date = Timestamp.valueOf(sqlDate);
        } else {
            date = java.sql.Date.valueOf(sqlDate);
        }

        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        return calendar;
    }

    /**
     * Returns an XMLGregorianCalendar instance initialized to the date represented by the provided Java date.
     *
     * @param date Java Date
     * @return XMLGregorianCalendar instance
     * @throws DatatypeConfigurationException
     */
    private XMLGregorianCalendar convertToXmlGregorianCalendar(Date date) throws DatatypeConfigurationException {
     DatatypeFactory df = DatatypeFactory.newInstance();
     GregorianCalendar gc = new GregorianCalendar();
     gc.setTime(date);
     XMLGregorianCalendar cal = df.newXMLGregorianCalendar(gc);
     return cal;
   }

    /**
     * Returns an AQS XML Service implementation.
     *
     * @return AQS XML Service implementation
     * @throws MalformedURLException
     */
    private AQSXmlService getAQSDataService(String urlAirVision) throws MalformedURLException {

        String qnameNamespaceUri = "http://tempuri.org/";
        String qnameLocalPart = "AQSXmlService";

        QName serviceName = new QName(qnameNamespaceUri, qnameLocalPart);
        Service service = Service.create(new URL(urlAirVision), serviceName);
        AQSXmlService aqsXmlService = service.getPort(AQSXmlService.class);

        // add our logger to the handler chain
        BindingProvider bindingProvider = (BindingProvider) aqsXmlService;
        bindingProvider.getBinding().getHandlerChain().add(new SOAPLoggingHandler());

        Client client = ClientProxy.getClient(aqsXmlService);
        HTTPConduit http = (HTTPConduit)client.getConduit();
        HTTPClientPolicy httpClientPolicy = new HTTPClientPolicy();
        httpClientPolicy.setConnectionTimeout(30000L);
        httpClientPolicy.setReceiveTimeout(10800000L);
        http.setClient(httpClientPolicy);

        return aqsXmlService;
    }

    /**
     * Returns an AQS3WebServiceArgument instance initialized with the values from the provided service parameters
     * map.
     *
     * @param serviceParams Map of AqsParams instances and their values
     * @return AQS3WebServiceArgument initialized with the provided values
     * @throws DatatypeConfigurationException On any problem converting the dates
     */
    private AQS3WebServiceArgument getAQS3WebServiceArguments(Map<AqsParams, Object> serviceParams)
            throws DatatypeConfigurationException {

        Date start = null;
        if ((serviceParams != null) && (serviceParams.get(AqsParams.StartTime) != null)) {
            start = ((Calendar) serviceParams.get(AqsParams.StartTime)).getTime();
        }

        Date end = null;
        if ((serviceParams != null) && (serviceParams.get(AqsParams.EndTime) != null)) {
            end = ((Calendar) serviceParams.get(AqsParams.EndTime)).getTime();
        }

        ObjectFactory factory = new ObjectFactory();

        AQS3WebServiceArgument args = new AQS3WebServiceArgument();

        args.setAQSXMLSchemaVersion("3.0");
        args.setCompressPayload(Boolean.FALSE.booleanValue());
        args.setStartTime(convertToXmlGregorianCalendar(start));
        args.setEndTime(convertToXmlGregorianCalendar(end));

        if ((serviceParams != null) && (serviceParams.get(AqsParams.SendRdTransactions) != null)) {
            args.setSendRDTransactions(
                    Boolean.valueOf((String) serviceParams.get(AqsParams.SendRdTransactions)).booleanValue());
        } else {
            args.setSendRDTransactions(Boolean.FALSE.booleanValue());
        }

        if ((serviceParams != null) && (serviceParams.get(AqsParams.SendRbTransactions) != null)) {
            args.setSendRBTransactions(
                    Boolean.valueOf((String) serviceParams.get(AqsParams.SendRbTransactions)).booleanValue());
        } else {
            args.setSendRDTransactions(Boolean.FALSE.booleanValue());
        }

        if ((serviceParams != null) && (serviceParams.get(AqsParams.SendMonitorAssuranceTransactions) != null)) {
            args.setSendMonitorAssuranceTransactions(
                    Boolean.valueOf((String) serviceParams.get(AqsParams.SendMonitorAssuranceTransactions)).booleanValue());
        } else {
            args.setSendMonitorAssuranceTransactions(Boolean.FALSE.booleanValue());
        }

        if ((serviceParams != null) && (serviceParams.get(AqsParams.SendOnlyQAData) != null)) {
            args.setSendMonitorAssuranceTransactions(
                    Boolean.valueOf((String) serviceParams.get(AqsParams.SendOnlyQAData)).booleanValue());
        } else {
            args.setSendMonitorAssuranceTransactions(Boolean.FALSE.booleanValue());
        }

        String[] durationCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.DurationCode));
        String[] occurrenceCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.OccurrenceCode));
        String[] stateCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.StateCode));
        String[] countyTribalCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.CountyTribalCode));
        String[] agencyCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.AgencyCode));
        String[] siteCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.SiteCode));
        String[] parameterCodes = splitParameterOnPipe((String) serviceParams.get(AqsParams.ParameterCode));

        int maxTags = 0;

        if(durationCodes != null && durationCodes.length > maxTags) {
            maxTags = durationCodes.length;
        }
        if(occurrenceCodes != null && occurrenceCodes.length > maxTags) {
            maxTags = occurrenceCodes.length;
        }
        if(stateCodes != null && stateCodes.length > maxTags) {
            maxTags = stateCodes.length;
        }
        if(countyTribalCodes != null && countyTribalCodes.length > maxTags) {
            maxTags = countyTribalCodes.length;
        }
        if(agencyCodes != null && agencyCodes.length > maxTags) {
            maxTags = agencyCodes.length;
        }
        if(siteCodes != null && siteCodes.length > maxTags) {
            maxTags = siteCodes.length;
        }
        if(parameterCodes != null && parameterCodes.length > maxTags) {
            maxTags = parameterCodes.length;
        }

        if(maxTags > 0) {
            args.setTags(new ArrayOfAQSParameterTag());

            for (int index = 0; index < maxTags; index++) {
                AQSParameterTag tag = new AQSParameterTag();

                if (agencyCodes != null && agencyCodes.length > index) {
                    tag.setAgencyCode(agencyCodes[index]);
                }
                if (countyTribalCodes != null && countyTribalCodes.length > index) {
                    JAXBElement<String> value =
                            factory.createAQSParameterTagCountyTribalCode(countyTribalCodes[index]);
                    tag.setCountyTribalCode(value);
                }
                if (durationCodes != null && durationCodes.length > index) {
                    JAXBElement<String> value =
                            factory.createAQSParameterTagDurationCode(durationCodes[index]);
                    tag.setDurationCode(value);
                }
                if (parameterCodes != null && parameterCodes.length > index) {
                    tag.setParameterCode(parameterCodes[index]);
                }
                if (occurrenceCodes != null && occurrenceCodes.length > index) {
                    JAXBElement<Integer> value =
                            factory.createAQSParameterTagParameterOccurrenceCode(Integer.parseInt(occurrenceCodes[index]));
                    tag.setParameterOccurrenceCode(value);
                }
                if (siteCodes != null && siteCodes.length > index) {
                    tag.setSiteCode(siteCodes[index]);
                }
                if (stateCodes != null && stateCodes.length > index) {
                    JAXBElement<String> value =
                            factory.createAQSParameterTagStateCode(stateCodes[index]);
                    tag.setStateCode(value);
                }

                args.getTags().getAQSParameterTag().add(tag);
            }
        }

        return args;
    }

    private String[] splitParameterOnPipe(String parameter) {
        if(parameter != null) {
            return parameter.split("\\|");
        } else {
            return null;
        }
    }
}
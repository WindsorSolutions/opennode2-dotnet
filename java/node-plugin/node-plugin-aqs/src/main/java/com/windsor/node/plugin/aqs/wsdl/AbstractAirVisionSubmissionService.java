package com.windsor.node.plugin.aqs.wsdl;

import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.aqs.AirVisionSubmissionHelper;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

import java.util.List;

/**
 * Provides the base class from which all AirVision submission services will
 * inherit. Handle common parameters, etc.
 */
public abstract class AbstractAirVisionSubmissionService extends BaseWnosJaxbPlugin {

    public static final String ARG_AUTHOR = "Author";
    public static final String ARG_ORGANIZATION = "Organization";
    public static final String ARG_DOCUMENT_TITLE = "Document Title";
    public static final String ARG_HEADER_APPLICATION_IDENTIFIER = "AQS User Info";
    public static final String ARG_CONTACT_INFO = "Contact Info";
    public static final String ARG_HEADER_AQS_SCREENING_GROUP = "AQS.ScreeningGroup";
    public static final String ARG_HEADER_AQS_FINAL_PROCESSING_STEP = "AQS.FinalProcessingStep";
    public static final String ARG_HEADER_AQS_STOP_ON_ERROR = "AQS.StopOnError";

    protected AirVisionSubmissionHelper submissionHelper = new AirVisionSubmissionHelper();
    protected JdbcTransactionDao transactionDao;
    protected SettingServiceProvider settingService;
    protected IdGenerator idGenerator;
    protected CompressionService zipService;

    public AbstractAirVisionSubmissionService() {

        getConfigurationArguments().put(ARG_AUTHOR, "");
        getConfigurationArguments().put(ARG_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_ORGANIZATION, "");
        getConfigurationArguments().put(ARG_DOCUMENT_TITLE, "");
        getConfigurationArguments().put(ARG_HEADER_APPLICATION_IDENTIFIER, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_SCREENING_GROUP, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_FINAL_PROCESSING_STEP, "");
        getConfigurationArguments().put(ARG_HEADER_AQS_STOP_ON_ERROR, "");
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

    protected void addHeader(List<String> lines, String docId, NodeTransaction transaction) {

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
}

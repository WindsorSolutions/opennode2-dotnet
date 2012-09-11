package com.windsor.node.plugin.facid3;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.facid3.dao.AffiliateDataTypeDao;
import com.windsor.node.plugin.facid3.dao.AffiliationListDataTypeDao;
import com.windsor.node.plugin.facid3.dao.EnvironmentalInterestDataTypeDao;
import com.windsor.node.plugin.facid3.dao.FacilityDataTypeDao;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public abstract class BaseFacIdPlugin extends BaseWnosJaxbPlugin
{
    public static final PluginServiceParameterDescriptor FACILITY_SITE_IDENTIFIER = new PluginServiceParameterDescriptor(
                    "Facility Site Identifier", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "The unique identifier allocated to the facility by the originating partner within the source database system.");
    public static final PluginServiceParameterDescriptor CHANGE_DATE = new PluginServiceParameterDescriptor(
                    "Change Date",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.TRUE,
                    "Date since when any data element of a facility has been modified. Response will include all facilities that have changed on or after this date.");
    public static final PluginServiceParameterDescriptor ORIGINATING_PARTNER_NAME = new PluginServiceParameterDescriptor(
                    "Originating Partner Name", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "The name of the partner that originally provided the exchanged facility site or environmental interest data.");
    public static final PluginServiceParameterDescriptor INFO_SYSTEM_ACORNYM_NAME = new PluginServiceParameterDescriptor(
                    "Information System Acronym Name", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "The abbreviated name that represents the name of an information management system for an environmental program.");

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;
    private FacilityDataTypeDao facilityDataTypeDao;
    private AffiliationListDataTypeDao affiliationListDataTypeDao;
    private AffiliateDataTypeDao affiliateDataTypeDao;
    private JdbcTransactionDao transactionDao;

    public BaseFacIdPlugin()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
        getConfigurationArguments().put(ARG_ADD_HEADER, "");
        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, "");
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        transaction.setOperation("ProcessFRSDoc");
        ProcessContentResult result = new ProcessContentResult();
        return result;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
        DataSource dataSource = (DataSource)getDataSources().get(ARG_DS_SOURCE);
        setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
        setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
        setZipService((CompressionService)getServiceFactory().makeService(ZipCompressionService.class));

        // This AffiliationListDataTypeDao needs to keep track of a special list of affiliation ids so they can be used
        // later to produce their
        // counterpart objects in the document
        AffiliationListDataTypeDao affiliationListDataTypeDao = new AffiliationListDataTypeDao();
        affiliationListDataTypeDao.setDataSource(dataSource);
        setAffiliationListDataTypeDao(affiliationListDataTypeDao);// keep track of dao in order to look up list more
                                                                  // easily
        EnvironmentalInterestDataTypeDao environmentalInterestDao = new EnvironmentalInterestDataTypeDao(affiliationListDataTypeDao);
        environmentalInterestDao.setDataSource(dataSource);
        setFacilityDataTypeDao(new FacilityDataTypeDao(environmentalInterestDao));
        getFacilityDataTypeDao().setDataSource(dataSource);

        setAffiliateDataTypeDao(new AffiliateDataTypeDao());
        getAffiliateDataTypeDao().setDataSource(dataSource);

        setTransactionDao((JdbcTransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        if(transactionDao == null)
        {
            throw new RuntimeException("Unable to obtain transactionDao");
        }
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String arg0)
    {
        return null;
    }

    protected Document makeDocument(NodeTransaction transaction, String docId, String tempFilePath) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(docId);
        doc.setId(docId);

        if(transaction.getRequest().getType() != RequestType.Query)
        {
            String zippedFilePath = getZipService().zip(tempFilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        }
        else
        {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(tempFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(tempFilePath)));
        }
        return doc;
    }

    protected void handleTransactionLifecycle(JAXBElement<?> jaxbElement, NodeTransaction transaction, ProcessContentResult result, String docId, String tempFilePath, ObjectFactory fact)
    {
        try
        {
            jaxbElement = processHeaderDirectives(jaxbElement, docId, transaction.getOperation(), transaction);
            // write the doc
            writeDocument(jaxbElement, tempFilePath);

            Document doc = makeDocument(transaction, docId, tempFilePath);
            transaction.getDocuments().add(doc);
            result.getDocuments().add(doc);
    
            result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction
                            .getRequest().getPaging().getCount(), true));
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.setSuccess(true);
            getTransactionDao().save(transaction);
        }
        catch(IOException e)
        {
            logger.error("Unhandled exception: " + e.getMessage());
            throw new RuntimeException("Error while creating or zipping file: " + tempFilePath, e);
        }
        catch(JAXBException e)
        {
            logger.error("Unhandled exception: " + e.getMessage());
            throw new RuntimeException("Error while creating file: " + tempFilePath, e);
        }
    }

    public SettingServiceProvider getSettingService()
    {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService)
    {
        this.settingService = settingService;
    }

    public IdGenerator getIdGenerator()
    {
        return idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator)
    {
        this.idGenerator = idGenerator;
    }

    public CompressionService getZipService()
    {
        return zipService;
    }

    public void setZipService(CompressionService zipService)
    {
        this.zipService = zipService;
    }

    public FacilityDataTypeDao getFacilityDataTypeDao()
    {
        return facilityDataTypeDao;
    }

    public void setFacilityDataTypeDao(FacilityDataTypeDao facilityDataTypeDao)
    {
        this.facilityDataTypeDao = facilityDataTypeDao;
    }

    public AffiliationListDataTypeDao getAffiliationListDataTypeDao()
    {
        return affiliationListDataTypeDao;
    }

    public void setAffiliationListDataTypeDao(AffiliationListDataTypeDao affiliationListDataTypeDao)
    {
        this.affiliationListDataTypeDao = affiliationListDataTypeDao;
    }

    public AffiliateDataTypeDao getAffiliateDataTypeDao()
    {
        return affiliateDataTypeDao;
    }

    public void setAffiliateDataTypeDao(AffiliateDataTypeDao affiliateDataTypeDao)
    {
        this.affiliateDataTypeDao = affiliateDataTypeDao;
    }

    public JdbcTransactionDao getTransactionDao()
    {
        return transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }
}

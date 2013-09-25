package com.windsor.node.plugin.attains;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.attains.dao.AttainsEntityManagerFactory;
import com.windsor.node.plugin.attains.dao.AttainsValidationDao;
import com.windsor.node.plugin.attains.dao.jdbc.JdbcAttainsValidationDao;
import com.windsor.node.plugin.attains.fixeddomain.ObjectFactory;
import com.windsor.node.plugin.attains.fixeddomain.StateAssessmentDetailsDataType;
import com.windsor.node.plugin.attains.fixeddomain.StateAssessmentsDataType;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class OwirAttV2Submit extends BaseWnosJaxbPlugin
{
    private static final String FILE_PREFIX = "ATTAINS_";
    private static final String FILE_EXTENSION_XML = "xml";

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;
    private TransactionDao transactionDao;
    private PartnerDao partnerDao;
    private EntityManagerFactory emf;
    private AttainsValidationDao attainsValidationDao;

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("OwirAttV2Submit");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Submit Integrated Report (IR) Water Quality Assessment and Impaired Water data to EPA for placement on EPA review sites where states can see EPA’s interpretation of their submitted data.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(OwirAttV2Submit.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public OwirAttV2Submit()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, "");
        getConfigurationArguments().put(ARG_HEADER_DOCUMENT_TITLE, "");
        getConfigurationArguments().put(ARG_HEADER_KEYWORDS, "");
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
        DataSource dataSource = getDataSources().get(ARG_DS_SOURCE);

        setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
        setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
        setZipService((CompressionService) getServiceFactory().makeService(ZipCompressionService.class));
        setTransactionDao((TransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
        setPartnerDao((PartnerDao)getServiceFactory().makeService(JdbcPartnerDao.class));

        JdbcAttainsValidationDao attainsValidationDao = new JdbcAttainsValidationDao();
        attainsValidationDao.setDataSource(dataSource);
        setAttainsValidationDao(attainsValidationDao);

        setEmf(AttainsEntityManagerFactory.initEntityManagerFactory(dataSource));
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        transaction.setOperation("ProcessOWIRATTDoc");
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.getAuditEntries().add(new ActivityEntry("Starting ATTAINS processing."));

        try
        {
            validateFlowState(transaction, result);
            List<StateAssessmentDetailsDataType> details = createPayload(transaction);
            ObjectFactory fact = new ObjectFactory();
            StateAssessmentsDataType stateAssessmentsDataType = fact.createStateAssessmentsDataType();
            stateAssessmentsDataType.setStateAssessmentDetails(details);

            JAXBElement<?> jaxbElement = fact.createStateAssessments(stateAssessmentsDataType);

            String docId = getIdGenerator().createId();
            String tempFilePath = makeTemporaryFilename(docId);
            jaxbElement = processHeaderDirectives(jaxbElement, docId, transaction.getOperation(), transaction, Boolean.TRUE);
            writeDocument(jaxbElement, tempFilePath);
            Document doc = makeDocument(transaction.getRequest().getType(), docId, tempFilePath);
            transaction.getDocuments().add(doc);
        }
        catch(Exception e)
        {
            StringWriter sw = new StringWriter();
            PrintWriter pw = new PrintWriter(sw);
            e.printStackTrace(pw);
            result.getAuditEntries().add(new ActivityEntry("Error during ATTAINS processing: \n" + sw.toString()));
            return result;
        }
        finally
        {
            if(getEmf() != null)
            {
                getEmf().close();
            }
            getTransactionDao().save(transaction);
        }

        result.getAuditEntries().add(new ActivityEntry("Successfully completed ATTAINS processing. Exiting."));
        result.setSuccess(true);
        result.setStatus(CommonTransactionStatusCode.Completed);

        return result;
    }

    private void validateFlowState(NodeTransaction transaction, ProcessContentResult result)
    {
        List<String> errors = getAttainsValidationDao().validateDataState();
        for(int i = 0; errors != null && i < errors.size(); i++)
        {
            result.getAuditEntries().add(new ActivityEntry(errors.get(i)));
        }
        if(errors != null && errors.size() > 0)
        {
            throw new IllegalStateException("Errors occured while validating state of ATTAINS data.");
        }
    }

    private String makeTemporaryFilename(String docId)
    {
        return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), FILE_PREFIX + this.getClass().getSimpleName()
                        + docId + "." + FILE_EXTENSION_XML);
    }

    private List<StateAssessmentDetailsDataType> createPayload(NodeTransaction transaction)
    {
        EntityManager em = getEmf().createEntityManager();
        @SuppressWarnings("unchecked")
        List<StateAssessmentDetailsDataType> results = em.createQuery("FROM " + StateAssessmentDetailsDataType.class.getSimpleName()).getResultList();
        return results;
    }

    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if(!RequestType.Query.equals(requestType))
        {
            String zippedFilePath = getZipService().zip(absolutefilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        }
        else
        {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
        }
        return doc;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }

    public TransactionDao getTransactionDao()
    {
        return transactionDao;
    }

    public void setTransactionDao(TransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    public PartnerDao getPartnerDao()
    {
        return partnerDao;
    }

    public void setPartnerDao(PartnerDao partnerDao)
    {
        this.partnerDao = partnerDao;
    }

    public EntityManagerFactory getEmf()
    {
        return emf;
    }

    public void setEmf(EntityManagerFactory emf)
    {
        this.emf = emf;
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

    public AttainsValidationDao getAttainsValidationDao()
    {
        return attainsValidationDao;
    }

    public void setAttainsValidationDao(AttainsValidationDao attainsValidationDao)
    {
        this.attainsValidationDao = attainsValidationDao;
    }
}

package com.windsor.node.plugin.icisnpdes40.submission;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Properties;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.namespace.QName;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.hibernate.cfg.Environment;
import org.hibernate.ejb.HibernatePersistence;
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
import com.windsor.node.plugin.icisnpdes40.generated.HeaderData;
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.OperationType;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.plugin.icisnpdes40.hibernate.IcisNpdesStagingPersistenceUnitInfo;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public abstract class AbstractIcisNpdesSubmission extends BaseWnosJaxbPlugin {

    public static final PluginServiceParameterDescriptor HEADER_DATA_AUTHOR = new PluginServiceParameterDescriptor(
            "Author",
            PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE,
            "Author description");

   public static final PluginServiceParameterDescriptor HEADER_DATA_ORGANIZATION = new PluginServiceParameterDescriptor(
            "Organization",
            PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE,
            "Organization description");
     
   public static final PluginServiceParameterDescriptor HEADER_DATA_TITLE = new PluginServiceParameterDescriptor(
           "Title",
           PluginServiceParameterDescriptor.TYPE_STRING,
           Boolean.FALSE,
           "Title description");
   
   public static final PluginServiceParameterDescriptor HEADER_DATA_COMMENT = new PluginServiceParameterDescriptor(
           "Comment",
           PluginServiceParameterDescriptor.TYPE_STRING,
           Boolean.FALSE,
           "Comment description");
   
   public static final PluginServiceParameterDescriptor HEADER_DATA_DATA_SERVICE = new PluginServiceParameterDescriptor(
           "Data Service",
           PluginServiceParameterDescriptor.TYPE_STRING,
           Boolean.FALSE,
           "Data Service description");
   
   public static final PluginServiceParameterDescriptor HEADER_DATA_CONTACT_INFO = new PluginServiceParameterDescriptor(
           "Contact Info",
           PluginServiceParameterDescriptor.TYPE_STRING,
           Boolean.FALSE,
           "Contact Info description");
   
   private DataSource dataSource;
   
   private EntityManagerFactory emf;
   
   private SettingServiceProvider settingService;
   
   private IdGenerator idGenerator;
   
   private CompressionService zipService;
   
   private JdbcTransactionDao transactionDao;
   
   public AbstractIcisNpdesSubmission() {
              
       /**
        * This service will be published for the following end points?
        */
       setPublishForEN11(true);
       setPublishForEN20(true);

       
       getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
               
       /**
        * Data source
        */
       getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
       
       /**
        * Service Configuration arguments
        */
       getConfigurationArguments().put(HEADER_DATA_AUTHOR.getName(), "");
       getConfigurationArguments().put(HEADER_DATA_ORGANIZATION.getName(), "");
       getConfigurationArguments().put(HEADER_DATA_TITLE.getName(), "");
       getConfigurationArguments().put(HEADER_DATA_COMMENT.getName(), "");
       getConfigurationArguments().put(HEADER_DATA_DATA_SERVICE.getName(), "");
       getConfigurationArguments().put(HEADER_DATA_CONTACT_INFO.getName(), "");
   }

   /**
    * All inheritors must create a List<PayloadData> of one or more PayloadData document elements, it is intended
    * that only the complete and total ICIS Submission Service implementer will return more than one.
    * @param em
    * @return
    */
   public abstract List<PayloadData> createAllPayloads(EntityManager em);
   
   /**
    * Generates a temporary file name based on the class name and docid.
    * 
    * @param docId the document guid
    * @return file name
    */
    private String makeTemporaryFilename(String docId) {
       
        String submissionType =  StringUtils.substringAfterLast(this.getClass().getName(),"."); 
       
        return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "ICIS-NPDES_" + submissionType + docId + ".xml");
    }
   
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
       
        ProcessContentResult result = new ProcessContentResult();

        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        EntityManager em = emf.createEntityManager();

        // always use an ObjectFactory to create JAXB created objects
        ObjectFactory fact = new ObjectFactory();

        String docId = getIdGenerator().createId();
        
        //Create and populate com.windsor.node.plugin.icisnpdes40.generated.Document and Header
        //NOTE ICIS DOES NOT IMPLEMENT NORMAL EN HEADER, IT USESS ITS OWN
        com.windsor.node.plugin.icisnpdes40.generated.Document document = fact.createDocument();
        HeaderData header = fact.createHeaderData();
        document.setHeader(header);

        header.setId(docId.substring(1, 31));
        header.setAuthor(getConfigValueAsString(HEADER_DATA_AUTHOR.getName(), false));
        header.setComment(getConfigValueAsString(HEADER_DATA_COMMENT.getName(), false));
        header.setContactInfo(getConfigValueAsString(HEADER_DATA_CONTACT_INFO.getName(), false));
        header.setCreationTime(new Date());
        header.setDataService(getConfigValueAsString(HEADER_DATA_DATA_SERVICE.getName(), false));
        header.setOrganization(getConfigValueAsString(HEADER_DATA_ORGANIZATION.getName(), false));
        header.setTitle(getConfigValueAsString(HEADER_DATA_TITLE.getName(), false));

        //create all the Payloads that will be included with this submission
        List<PayloadData> payloadDataList = new ArrayList<PayloadData>();
        document.setPayload(payloadDataList);

        //key function call, where inheritors perform their individual "magic"
        payloadDataList.addAll(createAllPayloads(em));

        //OpenNode2 Document creation
        String tempFilePath = makeTemporaryFilename(docId);

        //TODO Consider pushing OpenNode2 Document creation and writing up one more class level, this is pretty identical functionality
        try
        {
            // com.windsor.node.plugin.icisnpdes40.generated.Document is defined in the XSD in a funny manner, causing ObjectFactory
            // to not create all utility methods for it so manually create the JAXBElement for it
            writeDocument(new JAXBElement<com.windsor.node.plugin.icisnpdes40.generated.Document>(new QName(
                            "http://www.exchangenetwork.net/schema/icis/4", "Document"),
                            com.windsor.node.plugin.icisnpdes40.generated.Document.class, null, document), tempFilePath);

            Document doc = makeDocument(transaction, docId, tempFilePath);
            transaction.getDocuments().add(doc);
            result.getDocuments().add(doc);

            result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction
                            .getRequest().getPaging().getCount(), true));
            result.setStatus(CommonTransactionStatusCode.Pending);
            result.setSuccess(Boolean.TRUE);
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

        return result;
    }
   
   @Override
   public List<PluginServiceParameterDescriptor> getParameters() {
       return new ArrayList<PluginServiceParameterDescriptor>();
   }

   @Override
   public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
       return null;
   }
   
   @Override
   public void afterPropertiesSet() {
       
       initEntityManagerFactory();

       setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
       setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
       setZipService((CompressionService)getServiceFactory().makeService(ZipCompressionService.class));
       
       setTransactionDao((JdbcTransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
       
       if (transactionDao == null) {
           throw new RuntimeException("Unable to obtain transactionDao");
       }
   }   

   /**
    * Initialize the local {@link EntityManagerFactory}.
    */
   private void initEntityManagerFactory() {
       
       /***
        * Get a reference to the configured DataSource, we'll get the connection info from it
        */
       this.dataSource = (DataSource)getDataSources().get(ARG_DS_SOURCE);
       
       try {

           Properties jpaProperties = new Properties();
           
           jpaProperties.put(Environment.DATASOURCE, dataSource);
           
           // jpaProperties.put(Environment.SHOW_SQL, Boolean.TRUE);
           // jpaProperties.put(Environment.FORMAT_SQL, Boolean.TRUE);
           
           PersistenceProvider provider = new HibernatePersistence();
           
           emf = provider.createContainerEntityManagerFactory(new IcisNpdesStagingPersistenceUnitInfo(jpaProperties), jpaProperties);
           
       } catch (Exception e) {
           e.printStackTrace();
       }
   }

    protected Document makeDocument(NodeTransaction transaction, String docId,
            String tempFilePath) throws IOException {
        Document doc = new Document();
        doc.setDocumentId(docId);
        doc.setId(docId);

        if (transaction.getRequest().getType() != RequestType.Query) {
            String zippedFilePath = getZipService().zip(tempFilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(
                    zippedFilePath)));
        } else {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(tempFilePath));
            doc.setContent(FileUtils
                    .readFileToByteArray(new File(tempFilePath)));
        }
        return doc;
    }
   
   public SettingServiceProvider getSettingService() {
       return settingService;
   }

   public IdGenerator getIdGenerator() {
       return idGenerator;
   }

   public CompressionService getZipService() {
       return zipService;
   }

   public void setSettingService(SettingServiceProvider settingService) {
       this.settingService = settingService;
   }

   public void setIdGenerator(IdGenerator idGenerator) {
       this.idGenerator = idGenerator;
   }

   public void setZipService(CompressionService zipService) {
       this.zipService = zipService;
   }
       
   public JdbcTransactionDao getTransactionDao() {
       return transactionDao;
   }

   public void setTransactionDao(JdbcTransactionDao transactionDao) {
       this.transactionDao = transactionDao;
   }

   public DataSource getDataSource() {
       return dataSource;
   }
}

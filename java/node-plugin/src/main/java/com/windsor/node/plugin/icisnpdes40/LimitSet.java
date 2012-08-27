package com.windsor.node.plugin.icisnpdes40;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Properties;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.hibernate.cfg.Environment;
import org.hibernate.ejb.HibernatePersistence;

import com.windsor.node.common.domain.ActivityEntry;
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
import com.windsor.node.plugin.icisnpdes40.generated.LimitSetData;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class LimitSet extends BaseWnosJaxbPlugin {

	public static final PluginServiceParameterDescriptor FEDERAL_FACILITY = new PluginServiceParameterDescriptor(
			"Federal Facility",
			PluginServiceParameterDescriptor.TYPE_STRING,
			Boolean.FALSE,
			"Code indicating whether or not the facility is the property of the Federal Government. Allowable Values: Y, N.");


	private EntityManagerFactory emf;
	
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService zipService;
    private JdbcTransactionDao transactionDao;
    
	public JdbcTransactionDao getTransactionDao() {
		return transactionDao;
	}

	public void setTransactionDao(JdbcTransactionDao transactionDao) {
		this.transactionDao = transactionDao;
	}

	public LimitSet() {
		setPublishForEN11(true);
		setPublishForEN20(true);

        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
		getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
		
	}

	/**
	 * Initialize the local {@link EntityManagerFactory}.
	 * 
	 * TODO Work on better logging
	 * TODO Remove sysout statements
	 */
	private void initEntityManagerFactory() {
		
		/***
		 * Get a reference to the configured DataSource, we'll get the connection info from it
		 */
        final DataSource dataSource = (DataSource)getDataSources().get(ARG_DS_SOURCE);
		
		try {

			Properties jpaProperties = new Properties();
			
			jpaProperties.put(Environment.DATASOURCE, dataSource);
			
			PersistenceProvider provider = new HibernatePersistence();
			
			emf = provider.createContainerEntityManagerFactory(new IcisNpdesStagingPersistenceUnitInfo(jpaProperties), jpaProperties);
			
		} catch (SecurityException e) {
			e.printStackTrace();
		} catch (IllegalArgumentException e) {
			e.printStackTrace();
		}
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

	@Override
	public List<PluginServiceParameterDescriptor> getParameters() {
		
		List<PluginServiceParameterDescriptor> parameters = new ArrayList<PluginServiceParameterDescriptor>();
		
		/*parameters.add(new PluginServiceParameterDescriptor(ORIGINATING_PARTNER_NAME.getName(), ORIGINATING_PARTNER_NAME.getType(),
                Boolean.TRUE, ORIGINATING_PARTNER_NAME.getDescription(), ORIGINATING_PARTNER_NAME.getDefaultValue()));
		*/
		return parameters;
	}
	
	@Override
	public ProcessContentResult process(NodeTransaction transaction) {
		
		ProcessContentResult result = new ProcessContentResult();

		result.setStatus(CommonTransactionStatusCode.Failed);
		result.setSuccess(Boolean.FALSE);
		
		result.getAuditEntries().add(new ActivityEntry("Hellz yah!!"));

	    EntityManager em = emf.createEntityManager();
	    	    
		final List<LimitSetData> list = em.createQuery("select ls from LimitSetData ls").getResultList();
		
		/**
		 * <Document>
		 */
		com.windsor.node.plugin.icisnpdes40.generated.Document document = new com.windsor.node.plugin.icisnpdes40.generated.Document();
		
		HeaderData header = new HeaderData();
		header.setAuthor("Russell Pitre");
		header.setComment("!!!! Hard-coded comment !!!!");
		header.setContactInfo("russell_pitre@windsorsolutions.com");
		header.setCreationTime(new Date());
		header.setDataService("ICIS-NPDES");
		header.setOrganization("Windsor Solutions");
		header.setTitle("Test LimitSet batch");
		
		// getConfigValueAsString();
		
		
		/**
		 * 		<Header>
		 */
		document.setHeader(header);
		
		/**
		 * 		<Payload>
		 */
		List<PayloadData> payload = new ArrayList<PayloadData>();
		PayloadData data = new PayloadData();
		
		List<LimitSetData> limitSetData = new ArrayList<LimitSetData>();

		for(LimitSetData lsd : list) {
			limitSetData.add(lsd);
		}
		
		data.setLimitSetData(limitSetData);
		
		payload.add(data);
		
		document.setPayload(payload);
		document.setPayload(payload);
		
        String docId = getIdGenerator().createId();
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "ICIS-NPDES_LimitSet" + docId + ".xml");
        
		try {

	        JAXBContext context = JAXBContext.newInstance(
	        		com.windsor.node.plugin.icisnpdes40.generated.Document.class.getPackage().getName(), 
	        		getClass().getClassLoader());
	        
	        Marshaller m = context.createMarshaller();
	        m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
	        m.marshal(document, new FileOutputStream(tempFilePath));
	        
		} catch (IOException e) {
			logger.error("Unhandled exception: " + e.getMessage());
			throw new RuntimeException("Error while creating or zipping file: " + tempFilePath, e);
		} catch (JAXBException e) {
			logger.error("Unhandled exception: " + e.getMessage());
			throw new RuntimeException("Error while creating file: " + tempFilePath, e);
		}

        Document doc;
        
		try {
			
			doc = makeDocument(transaction, docId, tempFilePath);

	        transaction.getDocuments().add(doc);
	        result.getDocuments().add(doc);
	
	        result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction
	                        .getRequest().getPaging().getCount(), true));
	        
	        result.setStatus(CommonTransactionStatusCode.Completed);
	        result.setSuccess(true);
	        
	        getTransactionDao().save(transaction);
        
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		result.setStatus(CommonTransactionStatusCode.Pending);
		result.setSuccess(Boolean.TRUE);

		return result;
	}

	@Override
	public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
			String serviceName) {
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
}
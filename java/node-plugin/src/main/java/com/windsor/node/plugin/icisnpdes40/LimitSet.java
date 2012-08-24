package com.windsor.node.plugin.icisnpdes40;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLClassLoader;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Properties;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.sql.DataSource;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.namespace.QName;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;

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
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class LimitSet extends BaseWnosJaxbPlugin {

	
	private Properties jpaProperties = new Properties();
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
	 * TODO javax.persistence.jdbc.driver property should be derived from the ARG_DS_SOURCE 
	 */
	private void initEntityManagerFactory() {
		
		/***
		 * Get a reference to the configured DataSource, we'll get the connection info from it
		 */
        DataSource dataSource = (DataSource)getDataSources().get(ARG_DS_SOURCE);
		
        /**
         * Get the db connection url from the configured the ARG_DS_SOURCE
         */
        String dsUrl = null;
        
        try {
        	dsUrl = dataSource.getConnection().getMetaData().getURL();
		} catch (SQLException e) {
			e.printStackTrace();
		}
        
        
        /**
         * Determine the .jar file path and it to the parent ClassLoader so Hibernate can load our entities.
         */
		URL url = getClass().getClassLoader().getResource("META-INF/persistence.xml");

		String jarFile = url.getFile();
		
		jarFile = StringUtils.substringBetween(jarFile, "file:/", "!");
		
		try {
			
			File jar = new File(jarFile);
			
			Method method = URLClassLoader.class.getDeclaredMethod("addURL", new Class[]{URL.class}); // addURL is a protected method, use reflection to call it
			method.setAccessible(true);
			method.invoke(getClass().getClassLoader().getParent(), new Object[]{jar.toURI().toURL()}); // How will a security manager affect this call?
			
		} catch (SecurityException e) {
			e.printStackTrace();
		} catch (NoSuchMethodException e) {
			e.printStackTrace();
		} catch (IllegalArgumentException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (InvocationTargetException e) {
			e.printStackTrace();
		} catch (MalformedURLException e) {
			e.printStackTrace();
		}
	    		
		jpaProperties.put("javax.persistence.jdbc.driver", "oracle.jdbc.OracleDriver");
		jpaProperties.put("javax.persistence.jdbc.url", dsUrl);
		
		/**
		 * Initialize the entity manager factory
		 */
		emf = Persistence.createEntityManagerFactory("pu", jpaProperties);
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

	@Override
	public List<PluginServiceParameterDescriptor> getParameters() {
		return new ArrayList<PluginServiceParameterDescriptor>();
	}

	/**
	 * - Create datasource parameter in exchange
	 * - fix objectfactory
	 * - Run xml marshalling test
	 * - comment manual xml gen
	 * - get hibernate configuration setup based on datasource.
	 * - load limit set data from WA db
	 * - marshall it
	 */
	
	
	@Override
	public ProcessContentResult process(NodeTransaction transaction) {
		
		ProcessContentResult result = new ProcessContentResult();

		result.setStatus(CommonTransactionStatusCode.Failed);
		result.setSuccess(Boolean.FALSE);
		
		result.getAuditEntries().add(new ActivityEntry("Hellz yah!!"));

        ObjectFactory objFactory = new ObjectFactory();
      
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
			
	        JAXBContext context = JAXBContext.newInstance(com.windsor.node.plugin.icisnpdes40.generated.Document.class.getPackage().getName(), getClass().getClassLoader());
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
}
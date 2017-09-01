package com.windsor.node.plugin.uic2;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Properties;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import javax.xml.bind.JAXBElement;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;
import org.hibernate.cfg.Environment;
import org.springframework.util.Assert;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceUnitInfo;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.windsor.node.plugin.uic2.domain.ObjectFactory;
import com.windsor.node.plugin.uic2.domain.UICDataType;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class AbstractUicPlugin<T> extends BaseWnosJaxbPlugin {

    private static final List<String> HEADERS = Arrays.asList(
            ARG_ADD_HEADER,
            ARG_HEADER_AUTHOR,
            ARG_HEADER_CONTACT_INFO,
            ARG_HEADER_NOTIFS,
            ARG_HEADER_ORG_NAME,
            ARG_HEADER_PAYLOAD_OP,
            ARG_HEADER_TITLE,
            ARG_HEADER_COMMENT
    );

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private JdbcTransactionDao transactionDao;
    private EntityManager entityManager;
    private UicDao uicDao;

    private TransactionParameters transactionParameters;
    private OperationType operationType;

    public AbstractUicPlugin(OperationType operationType) {
        super();
        this.operationType = operationType;
        debug("Setting internal runtime argument list");
        for (String config : HEADERS) {
            getConfigurationArguments().put(config, "");
        }
        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);
        debug("Setting service type");
        getSupportedPluginTypes().add(operationType.getServiceType());
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, operationType.getPayloadOperation());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return operationType.getPluginDescriptor();
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    @Override
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        Assert.notNull(getDataSources(), "Data sources not set");

        /**
         * SettingServiceProvider setup.
         */
        setSettingService((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));
        Assert.notNull(getSettingService(), "Settings Service Provider could be located.");

        /**
         * IdGenerator setup.
         */
        setIdGenerator((IdGenerator) getServiceFactory().makeService(IdGenerator.class));
        Assert.notNull(getIdGenerator(), "ID Generator could be located.");

        /**
         * TransactionDAO setup.
         */
        setTransactionDao((JdbcTransactionDao) getServiceFactory().makeService(JdbcTransactionDao.class));
        Assert.notNull(getTransactionDao(), "TransactionDAO could not be located.");

        /**
         * CompressionService setup.
         */
        setCompressionService((CompressionService) getServiceFactory().makeService(CompressionService.class));
        Assert.notNull(getTransactionDao(), "CompressionService could not be located.");

        /**
         * Data Access Objects setup
         */
        HibernatePersistenceProvider provider = new HibernatePersistenceProvider();
        EntityManagerFactory emf = provider.createEntityManagerFactory(getDataSources().get(ARG_DS_SOURCE),
                new PluginPersistenceConfig()
                        .classLoader(UICDataType.class.getClassLoader())
                        .debugSql(Boolean.TRUE)
                        .rootEntityPackage("com.windsor.node.plugin.uic2.domain")
                        .setBatchFetchSize(1000));

        setEntityManager(emf.createEntityManager());

        /**
         * UicDao setup
         */
        setUicDao(new UicDaoImpl(getEntityManager()));
        Assert.notNull(getUicDao(), "UicDao could not be located.");
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> params = new ArrayList<>();
        for (PluginParameters p : PluginParameters.values()) {
            params.add(p.getParameterDescriptor());
        }
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);
        recordActivity(result, "UIC \"%s\" process starting.", operationType);
        validateTransaction(transaction);
        recordActivity(result, "Creating process parameters from transaction.");
        transactionParameters = new TransactionParameters(transaction);
        recordActivity(result,
                String.format("Service is configured for UIC organization \"%s\".", transactionParameters.getOrgId()));

        try {
            final String documentId = getIdGenerator().createId();
            final String documentName = "UIC_" + operationType.name() + documentId + ".xml";
            final String directory = settingService.getTempDir().getAbsolutePath();

            recordActivity(result, "Preparing XML file creator with file name %s", documentName);

            Document doc = generateNodeDocument(result, transaction, documentId, directory + "/" + documentName);

            result.getDocuments().add(doc);
            transaction.getDocuments().add(doc);
            recordActivity(result, "Preparing exchange for delivery. Completed.");

            recordActivity(result, "Saving exchange network transaction.");
            getTransactionDao().save(transaction);
            recordActivity(result, "Saving exchange network transaction. Completed.");

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Pending);
            recordActivity(result, "UIC \"%s\" process completed successfully.", operationType);

        } catch (Exception e) {
            result.setSuccess(Boolean.FALSE);
            result.setStatus(CommonTransactionStatusCode.Failed);
            recordActivity(result, e.getLocalizedMessage() + ", root cause: " + ExceptionUtils.getRootCauseMessage(e));
        }
        return result;
    }

    private Document generateNodeDocument(ProcessContentResult result, NodeTransaction nodeTransaction, String docId,
            String tempFilePath) {

        String orgId = transactionParameters.getOrgId();
        UICDataType org = uicDao.findByOrgId(orgId);
        if (org == null) {
            throw new RuntimeException("No Data");
        }

        try {
            ObjectFactory objectFactory = new ObjectFactory();
            JAXBElement<UICDataType> uic = objectFactory.createUIC(org);
            JAXBElement<?> header = processV1HeaderDirectives(uic, docId, nodeTransaction.getOperation(), nodeTransaction, true);
            writeDocument(header, tempFilePath);
            Document doc = makeDocument(nodeTransaction.getRequest().getType(), docId, tempFilePath);
            nodeTransaction.getDocuments().add(doc);
            return doc;
        } catch (Exception e) {
            throw new RuntimeException("Error while generating document: " + tempFilePath, e);
        }
    }

    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if(!RequestType.Submit.equals(requestType)) {
            String zippedFilePath = getCompressionService().zip(absolutefilePath);
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

    public JdbcTransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public EntityManager getEntityManager() {
        return entityManager;
    }

    public void setEntityManager(EntityManager entityManager) {
        this.entityManager = entityManager;
    }

    public UicDao getUicDao() {
        return uicDao;
    }

    public void setUicDao(UicDao uicDao) {
        this.uicDao = uicDao;
    }

    protected final void recordActivity(ProcessContentResult result, String msg) {
        result.getAuditEntries().add(makeEntry(msg));
    }

    protected final void recordActivity(ProcessContentResult result, String msgFormat, Object... args) {
        result.getAuditEntries().add(makeEntry(String.format(msgFormat, args)));
    }

    public class HibernatePersistenceProvider {

        private final PersistenceProvider provider = new org.hibernate.jpa.HibernatePersistenceProvider();

        public EntityManagerFactory createEntityManagerFactory(DataSource dataSource, PluginPersistenceConfig config) {

            Properties jpaProperties = new Properties();

            jpaProperties.put(Environment.DATASOURCE, dataSource);

            if (config.isDebugSql()) {
                jpaProperties.put(Environment.SHOW_SQL, Boolean.TRUE);
                jpaProperties.put(Environment.FORMAT_SQL, Boolean.TRUE);
            }

            if (config.getBatchFetchSize() != null) {
                jpaProperties.put(Environment.DEFAULT_BATCH_FETCH_SIZE, config.getBatchFetchSize());
            }

            if (StringUtils.isNotBlank(config.getHibernateDialect())) {
                jpaProperties.put(Environment.DIALECT, config.getHibernateDialect());
            }

            return provider.createContainerEntityManagerFactory(
                    new HibernatePersistenceUnitInfo(jpaProperties, config),
                    jpaProperties);
        }
    }

}

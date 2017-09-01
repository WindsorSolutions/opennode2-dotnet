package com.windsor.node.plugin.rcra54.service;

import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceUnitInfo;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.windsor.node.plugin.rcra54.dao.RcraDao;
import com.windsor.node.plugin.rcra54.dao.RcraDaoJpaImpl;
import com.windsor.node.plugin.rcra54.domain.HandlerDataType;
import com.windsor.node.plugin.rcra54.domain.OperationType;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import org.apache.commons.lang3.StringUtils;
import org.hibernate.cfg.Environment;
import org.springframework.beans.factory.DisposableBean;
import org.springframework.util.Assert;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import java.util.Collections;
import java.util.List;
import java.util.Properties;

public abstract class AbstractRcraService extends BaseWnosJaxbPlugin implements DisposableBean {

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private JdbcTransactionDao transactionDao;
    private EntityManagerFactory emf;
    private EntityManager entityManager;
    private RcraDao rcraDao;
    
    private OperationType operationType;

    public AbstractRcraService(OperationType operationType) {
        super();
        this.operationType = operationType;
        
        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);
        
        debug("Setting service type");
        getSupportedPluginTypes().add(operationType.getServiceType());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return operationType.getPluginDescriptor();
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }

    protected OperationType getOperationType() {
		return operationType;
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
        emf = provider.createEntityManagerFactory(getDataSources().get(ARG_DS_SOURCE),
                new PluginPersistenceConfig()
                        .classLoader(HandlerDataType.class.getClassLoader())
                        .debugSql(Boolean.TRUE)
                        .rootEntityPackage("com.windsor.node.plugin.rcra54.domain")
                        .setBatchFetchSize(1000));

        setEntityManager(emf.createEntityManager());

        /**
         * RcraDao setup
         */
        setRcraDao(new RcraDaoJpaImpl(getEntityManager(), transactionDao));
        Assert.notNull(getRcraDao(), "RcraDao could not be located.");
    }

    protected final NodeClientService getNodeClientService(NodeTransaction transaction) {
        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);
        PartnerIdentity partner = new PartnerIdentity();
        partner.setUrl(transaction.getNetworkEndpointUrl());
        partner.setVersion(transaction.getNetworkEndpointVersion());
        return clientFactory.makeAndConfigure(partner);
    }
	
    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        return Collections.emptyList();
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

    public RcraDao getRcraDao() {
        return rcraDao;
    }

    public void setRcraDao(RcraDao rcraDao) {
        this.rcraDao = rcraDao;
    }

    protected final void recordActivity(ProcessContentResult result, String msg) {
        result.getAuditEntries().add(makeEntry(msg));
    }

    protected final void recordActivity(ProcessContentResult result, String msgFormat, Object... args) {
        result.getAuditEntries().add(makeEntry(String.format(msgFormat, args)));
    }

    public static class HibernatePersistenceProvider {

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

    @Override
    public void destroy() throws Exception {
        debug("------------------->Starting destroy()");
        if (entityManager != null && entityManager.isOpen()) {
            debug("------------------->Closing em");
            entityManager.close();
            entityManager = null;
        }
        if (emf != null && emf.isOpen()) {
            debug("------------------->Closing emf");
            emf.close();
            emf = null;
        }
        debug("------------------->Finished destroy()");
    }
}

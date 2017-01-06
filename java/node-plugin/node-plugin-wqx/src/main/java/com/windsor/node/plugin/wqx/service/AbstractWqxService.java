package com.windsor.node.plugin.wqx.service;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;

import org.springframework.beans.factory.InitializingBean;
import org.springframework.util.Assert;

import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.windsor.node.plugin.wqx.dao.SubmissionHistoryDao;
import com.windsor.node.plugin.wqx.dao.SubmissionHistoryDaoJpaImpl;
import com.windsor.node.plugin.wqx.dao.WqxDao;
import com.windsor.node.plugin.wqx.dao.WqxDaoJpaImpl;
import com.windsor.node.plugin.wqx.domain.OrganizationDataType;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 *
 *
 */
public abstract class AbstractWqxService extends BaseWnosPlugin implements InitializingBean {

    /**
     * Plugin service parameters.
     */
    public static final PluginServiceParameterDescriptor ORG_ID = new PluginServiceParameterDescriptor("Org ID",
            PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
            "The Org ID to be used in the submission Header. Also governs SELECT logic on WQX_ORGANIZATION table.");

    public static final PluginServiceParameterDescriptor ADD_HEADER = new PluginServiceParameterDescriptor("Add Header?",
            PluginServiceParameterDescriptor.TYPE_BOOLEAN, Boolean.FALSE,
            "Indicates whether or not to add a Header to the submission.  Defaults to true if not supplied.");

    public static final PluginServiceParameterDescriptor USE_SUBMISSION_HISTORY = new PluginServiceParameterDescriptor(
            "Use Submission History?",
            PluginServiceParameterDescriptor.TYPE_BOOLEAN,
            Boolean.FALSE,
            "Indicates whether the submission will be recorded in the Submission History table.  Defaults to true if not supplied.");

    public static final PluginServiceParameterDescriptor START_DATE = new PluginServiceParameterDescriptor(
            "Start Date",
            PluginServiceParameterDescriptor.TYPE_DATE,
            Boolean.FALSE,
            "Applies a date filter on the WQXUPDATEDATE field greater than or equal to the date supplied. Used to send only a subset of activity data.");

    public static final PluginServiceParameterDescriptor END_DATE = new PluginServiceParameterDescriptor(
            "End Date",
            PluginServiceParameterDescriptor.TYPE_DATE,
            Boolean.FALSE,
            "Applies a date filter on the WQXUPDATEDATE field less than to the date supplied. Used to send only a subset of activity data.");

    public static final PluginServiceParameterDescriptor SUBMISSION_PARTNER_NAME = new PluginServiceParameterDescriptor(
            "Submission Partner Name",
            PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE,
            "The name of the Exchange Network Partner defined in the configuration section to submit data to.");

    public static final PluginServiceParameterDescriptor EXTRACT_STORED_PROCEDURE_NAME = new PluginServiceParameterDescriptor(
            "Extract Stored Procedure Name",
            PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.FALSE,
            "The name of the extract stored procedure.");

    /**
     * Submission Partner Name: Required runtime argument, set in service configuration.
     */
    protected static final String ARG_PARTNER_NAME = "Submission Partner Name";

    /**
     * Settings service.
     */
    private SettingServiceProvider settingService;

    /**
     * ID Generator.
     */
    private IdGenerator idGenerator;

    /**
     * Compression service.
     */
    private CompressionService compressionService;

    /**
     * Node transaction DAO.
     */
    private JdbcTransactionDao transactionDao;

    /**
     * Partner DAO.
     */
    private JdbcPartnerDao partnerDao;

    /**
     * EntityManager.
     */
    private EntityManager entityManager;

    /**
     * Submission History DAO
     */
    private SubmissionHistoryDao submissionHistoryDao;

    /**
     * WQX Dao
     */
    private WqxDao wqxDao;

    public AbstractWqxService() {

        super();

        debug("Setting internal runtime argument list");

        for (String config : configurationArguments()) {
            getConfigurationArguments().put(config, "");
        }

        debug("Setting internal data source list");

        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");

        getSupportedPluginTypes().add(supportsServiceType());
    }

    /**
     * The {@link ServiceType} this service supports.
     *
     * @return The {@link ServiceType} this service supports.
     */
    protected abstract ServiceType supportsServiceType();

    /**
     * Override to setup the available configuration arguments for the service
     * configuration.
     *
     * @return List of strings
     */
    protected List<String> configurationArguments() {
        List<String> args = new ArrayList<String>();
        return args;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        List<DataServiceRequestParameter> list = new ArrayList<DataServiceRequestParameter>();
        return list;
    }

    protected final void recordAtivity(ProcessContentResult result, String msg) {
        result.getAuditEntries().add(makeEntry(msg));
    }

    protected final void recordAtivity(ProcessContentResult result, String msgFormat, Object...args) {
        result.getAuditEntries().add(makeEntry(String.format(msgFormat, args)));
    }

    private PartnerIdentity makePartner(ScheduleParameters scheduleParameters) {

        String partnerName = scheduleParameters.getSubmissionPartnerName();

        debug("Looking for exchange partner named " + partnerName);

        List<?> partners = partnerDao.get();

        for (int i = 0; i < partners.size(); i++) {

            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);

            if (testPartner.getName().equalsIgnoreCase(partnerName)) {

                debug("Found partner match");

                return testPartner;
            }
        }
        throw new RuntimeException(String.format("Unable to find Exchange Partner by the name of \"%s\"", partnerName));
    }

    protected final NodeClientService getNodeClientService(ScheduleParameters scheduleParameters, NodeTransaction transaction) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        PartnerIdentity partner = makePartner(scheduleParameters);

        transaction.updateWithPartnerDetails(partner);

        return clientFactory.makeAndConfigure(partner);
    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
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
         * PartnerDAO setup.
         */
        setPartnerDao((JdbcPartnerDao) getServiceFactory().makeService(JdbcPartnerDao.class));
        Assert.notNull(getTransactionDao(), "PartnerDao could not be located.");

        /**
         * CompressionService setup.
         */
        setCompressionService((CompressionService) getServiceFactory().makeService(CompressionService.class));
        Assert.notNull(getTransactionDao(), "CompressionService could not be located.");

        /**
         * Data Access Objects setup
         */
        HibernatePersistenceProvider provider = new HibernatePersistenceProvider();
        EntityManagerFactory emf = provider.createEntityManagerFactory(
                getDataSources().get(ARG_DS_SOURCE),
                new PluginPersistenceConfig()
                        .classLoader(OrganizationDataType.class.getClassLoader())
                        .debugSql(Boolean.FALSE)
                        .rootEntityPackage("com.windsor.node.plugin.wqx.domain")
                        .setBatchFetchSize(1000));

        setEntityManager(emf.createEntityManager());

        /**
         * SubmissionHistoryDao setup
         */
        setSubmissionHistoryDao(new SubmissionHistoryDaoJpaImpl(getEntityManager()));

        /**
         * WqxDao setup
         */
        setWqxDao(new WqxDaoJpaImpl(getEntityManager()));
        Assert.notNull(getWqxDao(), "WqxDao could not be located.");
    }

    /**
     * Service parameter accessors.
     */
    public String getSubmissionPartnerName(ScheduleParameters scheduleParameters) {
        return scheduleParameters.getSubmissionPartnerName();
    }

    public String getContactInfo() {
        return getRequiredConfigValueAsString(ARG_HEADER_CONTACT_INFO);
    }

    public String getDocumentTitle() {
        return getRequiredConfigValueAsString(ARG_HEADER_TITLE);
    }

    public String getOrganization() {
        return getRequiredConfigValueAsString(ARG_HEADER_ORG_NAME);
    }

    public String getAuthor() {
        return getRequiredConfigValueAsString(ARG_HEADER_AUTHOR);
    }

    /**
     * DAO accessors
     */
    protected final SubmissionHistoryDao getSubmissionHistoryDao() {
        return submissionHistoryDao;
    }

    private void setSubmissionHistoryDao(SubmissionHistoryDao submissionHistoryDao) {
        this.submissionHistoryDao = submissionHistoryDao;
    }

    protected final JdbcTransactionDao getTransactionDao() {
        return transactionDao;
    }

    protected final void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    protected final JdbcPartnerDao getPartnerDao() {
        return partnerDao;
    }

    protected final void setPartnerDao(JdbcPartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

    protected final EntityManager getEntityManager() {
        return entityManager;
    }

    private void setEntityManager(EntityManager entityManager) {
        this.entityManager = entityManager;
    }

    protected final WqxDao getWqxDao() {
        return wqxDao;
    }

    private void setWqxDao(WqxDao wqxDao) {
        this.wqxDao = wqxDao;
    }

    /**
     * Service accessors.
     */
    protected final SettingServiceProvider getSettingService() {
        return settingService;
    }

    protected final void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    protected final IdGenerator getIdGenerator() {
        return idGenerator;
    }

    protected final void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

    protected final CompressionService getCompressionService() {
        return compressionService;
    }

    protected final void setCompressionService(CompressionService compressionService) {
        this.compressionService = compressionService;
    }

    /**
     * Helpers
     */
    public File getPluginTempDirectory() {
        return settingService.getTempDir();
    }
}

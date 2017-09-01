package com.windsor.node.plugin.rcra54.outbound;

import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.windsor.node.plugin.rcra54.domain.generated.HandlerDataType;
import com.windsor.node.service.helper.client.NodeClientFactory;
import org.springframework.beans.factory.DisposableBean;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import java.util.List;

/**
 * Provides the common functionality for the RCRA v5.2 plugin.
 */
public abstract class BaseRcra54Plugin extends BaseWnosJaxbPlugin implements DisposableBean {

    /**
     * Parameter for the Handler ID.
     */
    public final static PluginServiceParameterDescriptor PARAM_HANDLER_ID = new PluginServiceParameterDescriptor(
            "Handler ID", PluginServiceParameterDescriptor.TYPE_STRING, false,
            "The unique identifier of the RCRA handler");
    public final static PluginServiceParameterDescriptor PARAM_HANDLER_ID_REQ = new PluginServiceParameterDescriptor(
            "Handler ID", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The unique identifier of the RCRA handler");

    /**
     * Parameter for the state.
     */
    public final static PluginServiceParameterDescriptor PARAM_STATE = new PluginServiceParameterDescriptor(
            "State", PluginServiceParameterDescriptor.TYPE_STRING, false,
            "The state for which RCRA data will be fetched");
    public final static PluginServiceParameterDescriptor PARAM_STATE_REQ = new PluginServiceParameterDescriptor(
            "State", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The state for which RCRA data will be fetched");

    /**
     * Parameter for the agency.
     */
    public final static PluginServiceParameterDescriptor PARAM_AGENCY = new PluginServiceParameterDescriptor(
            "Agency", PluginServiceParameterDescriptor.TYPE_STRING, false,
            "The agency for which RCRA data will be fetched");
    public final static PluginServiceParameterDescriptor PARAM_AGENCY_REQ = new PluginServiceParameterDescriptor(
            "Agency", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The agency for which RCRA data will be fetched");

    /**
     * Parameter for the owner.
     */
    public final static PluginServiceParameterDescriptor PARAM_OWNER = new PluginServiceParameterDescriptor(
            "Owner", PluginServiceParameterDescriptor.TYPE_STRING, false,
            "The owner for which RCRA data will be fetched");
    public final static PluginServiceParameterDescriptor PARAM_OWNER_REQ = new PluginServiceParameterDescriptor(
            "Owner", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The owner for which RCRA data will be fetched");

    /**
     * Parameter for the source type.
     */
    public final static PluginServiceParameterDescriptor PARAM_SOURCE_TYPE = new PluginServiceParameterDescriptor(
            "Source Type", PluginServiceParameterDescriptor.TYPE_STRING, false,
            "The source type of data to retrieve");
    public final static PluginServiceParameterDescriptor PARAM_SOURCE_TYPE_REQ = new PluginServiceParameterDescriptor(
            "Source Type", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The source type of data to retrieve");

    /**
     * Parameter for the sequence number.
     */
    public final static PluginServiceParameterDescriptor PARAM_SEQUENCE_NUMBER = new PluginServiceParameterDescriptor(
            "Sequence Number", PluginServiceParameterDescriptor.TYPE_LONG, false,
            "The sequence number used when fetching data");
    public final static PluginServiceParameterDescriptor PARAM_SEQUENCE_NUMBER_REQ = new PluginServiceParameterDescriptor(
            "Sequence Number", PluginServiceParameterDescriptor.TYPE_LONG, true,
            "The sequence number used when fetching data");

    /**
     * Parameter for the change date.
     */
    public final static PluginServiceParameterDescriptor PARAM_CHANGE_DATE = new PluginServiceParameterDescriptor(
            "Change Date", PluginServiceParameterDescriptor.TYPE_DATE, false,
            "The starting data for which changed or updated data will be retrieved");
    public final static PluginServiceParameterDescriptor PARAM_CHANGE_DATE_REQ = new PluginServiceParameterDescriptor(
            "Change Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The starting data for which changed or updated data will be retrieved");

    /**
     * Parameter for the from date.
     */
    public final static PluginServiceParameterDescriptor PARAM_FROM_DATE = new PluginServiceParameterDescriptor(
            "From Date", PluginServiceParameterDescriptor.TYPE_DATE, false,
            "The starting date in which to retrieve RCRA data");
    public final static PluginServiceParameterDescriptor PARAM_FROM_DATE_REQ = new PluginServiceParameterDescriptor(
            "From Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The starting date in which to retrieve RCRA data");

    /**
     * Parameter for the to date.
     */
    public final static PluginServiceParameterDescriptor PARAM_TO_DATE = new PluginServiceParameterDescriptor(
            "To Date", PluginServiceParameterDescriptor.TYPE_DATE, false,
            "The ending date in which to retrieve RCRA data");
    public final static PluginServiceParameterDescriptor PARAM_TO_DATE_REQ = new PluginServiceParameterDescriptor(
            "To Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The ending date in which to retrieve RCRA data");

    /**
     * Parameter for the solicity history flag.
     */
    public final static PluginServiceParameterDescriptor PARAM_USE_SOLICIT_HISTORY = new PluginServiceParameterDescriptor(
            "Use Solicit History", PluginServiceParameterDescriptor.TYPE_BOOLEAN, false,
            "If true, track the successful transactions and used the most recent as the \"Change Date\" for subsequent fetches");
    public final static PluginServiceParameterDescriptor PARAM_USE_SOLICIT_HISTORY_REQ = new PluginServiceParameterDescriptor(
            "Use Solicit History", PluginServiceParameterDescriptor.TYPE_BOOLEAN, true,
            "If true, track the successful transactions and used the most recent as the \"Change Date\" for subsequent fetches");

    /**
     * Required, name of partner to solicit.
     */
    protected static final String ARG_PARTNER_NAME = "Solicit Partner Name";

    /**
     * Stored procedure to call when the data has been downlaoded.
     */
    protected static final String ARG_STORED_PROCEDURE = "Stored Procedure";

    private JdbcPartnerDao partnerDao;
    private JdbcTransactionDao transactionDao;
    private EntityManager targetEntityManager;
    private ClassLoader classLoader;

    public BaseRcra54Plugin() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        // we only need a datatarget data source
        //getDataSources().put(ARG_DS_SOURCE, (DataSource) null);
        getDataSources().put(ARG_DS_TARGET, (DataSource) null);

        getConfigurationArguments().put(ARG_PARTNER_NAME, "");
        getConfigurationArguments().put(ARG_STORED_PROCEDURE, "");

        debug("BaseRcra54Plugin instantiated.");
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        return null;
    }

    protected NodeClientService makeNodeClient(PartnerIdentity partner) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        return clientFactory.makeAndConfigure(partner);
    }

    @Override
	public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        partnerDao = (JdbcPartnerDao) getServiceFactory().makeService(
                JdbcPartnerDao.class);

        if (partnerDao == null) {
            throw new RuntimeException("Unable to obtain partnerDao");
        }

        transactionDao = (JdbcTransactionDao) getServiceFactory().makeService(
                JdbcTransactionDao.class);

        if (transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        if (!getConfigurationArguments().containsKey(ARG_PARTNER_NAME)) {
            throw new RuntimeException(ARG_PARTNER_NAME + " not set!");
        }

        if(getDataSources().get(ARG_DS_TARGET) == null) {
            throw new RuntimeException("No data source was provided for this operation!");
        }

        RcraHibernatePersistenceProvider provider = new RcraHibernatePersistenceProvider();
        EntityManagerFactory emf = provider.createEntityManagerFactory(
                getDataSources().get(ARG_DS_TARGET),
                new PluginPersistenceConfig()
                        .classLoader(HandlerDataType.class.getClassLoader())
                        .debugSql(Boolean.TRUE)
                        .rootEntityPackage("com.windsor.node.plugin.rcra54.domain.generated")
                        .additionalEntityPackages("net.opengis.gml", "org.georss.georss._10")
                        .setBatchFetchSize(1000));

        EntityManager entityManager = null;

        try {
            entityManager = emf.createEntityManager();
        } catch(Exception exception) {
            throw new RuntimeException("The data source is not configured correctly! I received the following error " +
                    "when I tried to setup the data source: " + exception.getMessage(), exception);
        }

        setTargetEntityManager(entityManager);
    }

    public JdbcPartnerDao getPartnerDao() {
        return partnerDao;
    }

    public void setPartnerDao(JdbcPartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

    public JdbcTransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public EntityManager getTargetEntityManager() {
        return targetEntityManager;
    }

    public void setTargetEntityManager(EntityManager targetEntityManager) {
        this.targetEntityManager = targetEntityManager;
    }

    public ClassLoader getClassLoader() {

        if(classLoader == null) {
            classLoader = this.getClass().getClassLoader();
        }

        return classLoader;
    }

    @Override
    public void destroy() throws Exception {
        if (targetEntityManager != null && targetEntityManager.isOpen()) {
            EntityManagerFactory emf = targetEntityManager.getEntityManagerFactory();
            targetEntityManager.close();
            emf.close();
            targetEntityManager = null;
            info("Finished cleaning up the plugin");
        }
    }
}

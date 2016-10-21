package com.windsor.node.plugin.rcra52;

import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.windsor.node.service.helper.client.NodeClientFactory;
import org.apache.commons.lang3.StringUtils;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import java.util.List;

/**
 * Provides the common functionality for the RCRA v5.2 plugin.
 */
public abstract class BaseRcra52Plugin extends BaseWnosJaxbPlugin {

    /**
     * Parameter for the Handler ID.
     */
    public final static PluginServiceParameterDescriptor PARAM_HANDLER_ID = new PluginServiceParameterDescriptor(
            "Handler ID", PluginServiceParameterDescriptor.TYPE_STRING,
            "The unique identifier of the RCRA handler");

    /**
     * Parameter for the state.
     */
    public final static PluginServiceParameterDescriptor PARAM_STATE = new PluginServiceParameterDescriptor(
            "State", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The state for which RCRA data will be fetched");

    /**
     * Parameter for the agency.
     */
    public final static PluginServiceParameterDescriptor PARAM_AGENCY = new PluginServiceParameterDescriptor(
            "Agency", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The agency for which RCRA data will be fetched");

    /**
     * Parameter for the owner.
     */
    public final static PluginServiceParameterDescriptor PARAM_OWNER = new PluginServiceParameterDescriptor(
            "Owner", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The owner for which RCRA data will be fetched");

    /**
     * Parameter for the source type.
     */
    public final static PluginServiceParameterDescriptor PARAM_SOURCE_TYPE = new PluginServiceParameterDescriptor(
            "Source Type", PluginServiceParameterDescriptor.TYPE_STRING, true,
            "The source type of data to retrieve");

    /**
     * Parameter for the sequence number.
     */
    public final static PluginServiceParameterDescriptor PARAM_SEQUENCE_NUMBER = new PluginServiceParameterDescriptor(
            "Sequence Number", PluginServiceParameterDescriptor.TYPE_LONG, true,
            "The sequence number used when fetching data");

    /**
     * Parameter for the change date.
     */
    public final static PluginServiceParameterDescriptor PARAM_CHANGE_DATE = new PluginServiceParameterDescriptor(
            "Change Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The starting data for which changed or updated data will be retrieved");

    /**
     * Parameter for the from date.
     */
    public final static PluginServiceParameterDescriptor PARAM_FROM_DATE = new PluginServiceParameterDescriptor(
            "From Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The starting date in which to retrieve RCRA data");

    /**
     * Parameter for the to date.
     */
    public final static PluginServiceParameterDescriptor PARAM_TO_DATE = new PluginServiceParameterDescriptor(
            "To Date", PluginServiceParameterDescriptor.TYPE_DATE, true,
            "The ending date in which to retrieve RCRA data");

    /**
     * Parameter for the solicity history flag.
     */
    public final static PluginServiceParameterDescriptor PARAM_USE_SOLICIT_HISTORY = new PluginServiceParameterDescriptor(
            "Use Solicit History", PluginServiceParameterDescriptor.TYPE_BOOLEAN, true,
            "If true, track the successful transactions and used the most recent as the \"Change Date\" for subsequent fetches");

    /**
     * Indicates how often we'll check with the EPA for solicit completion.
     */
    public final static long POLLING_INTERVAL = 30000;


    /**
     * Required, name of partner to solicit.
     */
    protected static final String ARG_PARTNER_NAME = "Solicit Partner Name";

    /**
     * Stored procedure to call when the data has been downlaoded.
     */
    protected static final String ARG_STORED_PROCEDURE = "Stored Procedure";

    private String partnerName;
    private JdbcPartnerDao partnerDao;
    private JdbcTransactionDao transactionDao;
    private EntityManager targetEntityManager;
    private ClassLoader classLoader;

    public BaseRcra52Plugin() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        // we only need a target data source
        //getDataSources().put(ARG_DS_SOURCE, (DataSource) null);
        getDataSources().put(ARG_DS_TARGET, (DataSource) null);

        getConfigurationArguments().put(ARG_PARTNER_NAME, "");
        getConfigurationArguments().put(ARG_STORED_PROCEDURE, "");

        debug("BaseRcra52Plugin instantiated.");
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        return null;
    }

    protected PartnerIdentity getPartner() {

        logger.debug("Looking for partner named " + partnerName);

        List<?> partners = partnerDao.get();

        PartnerIdentity partner = null;

        for (int i = 0; i < partners.size(); i++) {

            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);
            logger.debug("Found partner named " + testPartner.getName());

            if (testPartner.getName().equals(partnerName)) {

                logger.debug("Found partner match");
                partner = testPartner;
                break;
            }
        }

        if (null == partner) {
            throw new RuntimeException("No partner named " + partnerName
                    + " exists in partner configuration.");
        }

        return partner;

    }

    protected NodeClientService makeNodeClient(PartnerIdentity partner) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        return clientFactory.makeAndConfigure(partner);
    }

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

        if (StringUtils.isBlank(partnerName)) {
            partnerName = (String) getRequiredConfigValueAsString(ARG_PARTNER_NAME);
        }
        debug("partnerName: " + partnerName);

        if (!getConfigurationArguments().containsKey(ARG_PARTNER_NAME)) {
            throw new RuntimeException(ARG_PARTNER_NAME + " not set!");
        }
        
        info("Using data source " + getDataSources().get(ARG_DS_TARGET));
        RcraHibernatePersistenceProvider provider = new RcraHibernatePersistenceProvider();
        EntityManagerFactory emf = provider.createEntityManagerFactory(
                getDataSources().get(ARG_DS_TARGET),
                new PluginPersistenceConfig()
                        .classLoader(getClassLoader())
                        .debugSql(Boolean.TRUE)
                        .rootEntityPackage("com.windsor.node.plugin.rcra52.domain.generated")
                        .additionalEntityPackages("net.opengis.gml", "org.georss.georss._10")
                        .setBatchFetchSize(1000));

        setTargetEntityManager(emf.createEntityManager());
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

    public String getPartnerName() {
        return partnerName;
    }

    public void setPartnerName(String partnerName) {
        this.partnerName = partnerName;
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
}
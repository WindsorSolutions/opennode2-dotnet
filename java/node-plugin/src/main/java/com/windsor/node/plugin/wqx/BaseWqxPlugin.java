package com.windsor.node.plugin.wqx;

import java.io.File;
import java.util.List;
import javax.sql.DataSource;
import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.wqx.dao.WqxStatusDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseWqxPlugin extends BaseWnosPlugin implements
        InitializingBean {

    /**
     * Index position for schedule argument (organization id for the data
     * query).
     */
    protected static final int PARAM_INDEX_ORGID = 0;

    /**
     * Required runtime argument, set in service configuration.
     */
    protected static final String ARG_PARTNER_NAME = "Submission Partner Name";
    /* Helpers */
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private WqxStatusDao statusDao;
    private JdbcTransactionDao transactionDao;
    private JdbcPartnerDao partnerDao;
    private String partnerName;

    public BaseWqxPlugin() {
        super();

        debug("Setting internal runtime argument list");

        getConfigurationArguments().put(ARG_PARTNER_NAME, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
    }

    /**
     * Will be called by the plugin executor after properties are set; an
     * opportunity to validate all settings.
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source datasource not set");
        }

        partnerName = (String) getRequiredConfigValueAsString(ARG_PARTNER_NAME);
        debug("Submission Partner Name: " + partnerName);

        if (StringUtils.isBlank(partnerName)) {
            throw new RuntimeException("blank partnerName");
        }

        statusDao = new WqxStatusDao((DataSource) getDataSources().get(
                ARG_DS_SOURCE));

        if (statusDao == null) {
            throw new RuntimeException("Unable to obtain statusDao");
        }

        settingService = (SettingServiceProvider) getServiceFactory()
                .makeService(SettingServiceProvider.class);

        if (settingService == null) {
            throw new RuntimeException(
                    "Unable to obtain SettingServiceProvider");
        }

        idGenerator = (IdGenerator) getServiceFactory().makeService(
                IdGenerator.class);

        if (idGenerator == null) {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }

        transactionDao = (JdbcTransactionDao) getServiceFactory().makeService(
                JdbcTransactionDao.class);

        if (transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        partnerDao = (JdbcPartnerDao) getServiceFactory().makeService(
                JdbcPartnerDao.class);

        if (partnerDao == null) {
            throw new RuntimeException("Unable to obtain partnerDao");
        }

        compressionService = (CompressionService) getServiceFactory()
                .makeService(CompressionService.class);

        if (compressionService == null) {
            throw new RuntimeException("Unable to obtain CompressionService");
        }

    }

    protected PartnerIdentity makePartner() {

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

        /*if (null == partner) {
            throw new RuntimeException("No partner named " + partnerName
                    + " exists in partner configuration.");
        }*/

        return partner;

    }

    protected NodeClientService makeNodeClient(PartnerIdentity partner) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        return clientFactory.makeAndConfigure(partner);
    }

    protected String getOrgIdFromTransaction(NodeTransaction tran) {

        String orgId = getRequiredValueFromTransactionArgs(tran,
                PARAM_INDEX_ORGID);
        debug("orgId: " + orgId);
        return orgId;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    /**
     * @return
     */
    public File getTempDir() {
        return settingService.getTempDir();
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

    public WqxStatusDao getStatusDao() {
        return statusDao;
    }

    public void setStatusDao(WqxStatusDao statusDao) {
        this.statusDao = statusDao;
    }

    public JdbcTransactionDao getTransactionDao() {
        return transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    public JdbcPartnerDao getPartnerDao() {
        return partnerDao;
    }

    public void setPartnerDao(JdbcPartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

    public String getPartnerName() {
        return partnerName;
    }

    public void setPartnerName(String partnerName) {
        this.partnerName = partnerName;
    }

}

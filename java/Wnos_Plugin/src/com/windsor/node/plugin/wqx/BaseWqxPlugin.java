package com.windsor.node.plugin.wqx;

import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

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
     * Required runtime argument, set in service configuration.
     */
    protected static final String ARG_PARTNER_NAME = "Submission Partner Name";

    /* Helpers */
    protected SettingServiceProvider settingService;
    protected IdGenerator idGenerator;
    protected CompressionService compressionService;
    protected WqxStatusDao statusDao;
    protected JdbcTransactionDao transactionDao;
    protected JdbcPartnerDao partnerDao;
    protected String partnerName;

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

    }

    protected PartnerIdentity makePartner() {

        logger.debug("Looking for partner named " + partnerName);

        List partners = partnerDao.get();

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

}

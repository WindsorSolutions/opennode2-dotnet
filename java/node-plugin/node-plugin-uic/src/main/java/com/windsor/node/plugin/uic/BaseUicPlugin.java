package com.windsor.node.plugin.uic;

import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.uic.dao.UicStatusDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.ServiceFactory;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import java.io.File;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.springframework.beans.factory.InitializingBean;

public abstract class BaseUicPlugin extends BaseWnosPlugin implements InitializingBean
{
    protected static final int PARAM_INDEX_ORGID = 0;
    protected static final String ARG_PARTNER_NAME = "Submission Partner Name";
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private UicStatusDao statusDao;
    private JdbcTransactionDao transactionDao;
    private JdbcPartnerDao partnerDao;
    private String partnerName;

    public BaseUicPlugin()
    {
        debug("Setting internal runtime argument list");

        getConfigurationArguments().put("Submission Partner Name", "");

        debug("Setting internal data source list");
        getDataSources().put("Source Data Provider", null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
    }

    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();

        if(getDataSources() == null)
        {
            throw new RuntimeException("Data sources not set");
        }

        if(!getDataSources().containsKey("Source Data Provider"))
        {
            throw new RuntimeException("Source datasource not set");
        }

        this.partnerName = getRequiredConfigValueAsString("Submission Partner Name");
        debug("Submission Partner Name: " + this.partnerName);

        if(StringUtils.isBlank(this.partnerName))
        {
            throw new RuntimeException("blank partnerName");
        }

        this.statusDao = new UicStatusDao((DataSource) getDataSources().get("Source Data Provider"));

        if(this.statusDao == null)
        {
            throw new RuntimeException("Unable to obtain statusDao");
        }

        this.settingService = ((SettingServiceProvider) getServiceFactory().makeService(SettingServiceProvider.class));

        if(this.settingService == null)
        {
            throw new RuntimeException("Unable to obtain SettingServiceProvider");
        }

        this.idGenerator = ((IdGenerator) getServiceFactory().makeService(IdGenerator.class));

        if(this.idGenerator == null)
        {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }

        this.transactionDao = ((JdbcTransactionDao) getServiceFactory().makeService(JdbcTransactionDao.class));

        if(this.transactionDao == null)
        {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        this.partnerDao = ((JdbcPartnerDao) getServiceFactory().makeService(JdbcPartnerDao.class));

        if(this.partnerDao == null)
        {
            throw new RuntimeException("Unable to obtain partnerDao");
        }

        this.compressionService = ((CompressionService) getServiceFactory().makeService(CompressionService.class));

        if(this.compressionService == null)
            throw new RuntimeException("Unable to obtain CompressionService");
    }

    protected PartnerIdentity makePartner()
    {
        this.logger.debug("Looking for partner named " + this.partnerName);

        List partners = this.partnerDao.get();

        PartnerIdentity partner = null;

        for (int i = 0; i < partners.size(); i++)
        {
            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);
            this.logger.debug("Found partner named " + testPartner.getName());

            if(testPartner.getName().equals(this.partnerName))
            {
                this.logger.debug("Found partner match");
                partner = testPartner;
                break;
            }
        }

        if(null == partner)
        {
            throw new RuntimeException("No partner named " + this.partnerName + " exists in partner configuration.");
        }

        return partner;
    }

    protected NodeClientService makeNodeClient(PartnerIdentity partner)
    {
        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory().makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        return clientFactory.makeAndConfigure(partner);
    }

    protected String getOrgIdFromTransaction(NodeTransaction tran)
    {
        String orgId = getRequiredValueFromTransactionArgs(tran, 0);

        debug("orgId: " + orgId);
        return orgId;
    }

    public SettingServiceProvider getSettingService()
    {
        return this.settingService;
    }

    public void setSettingService(SettingServiceProvider settingService)
    {
        this.settingService = settingService;
    }

    public File getTempDir()
    {
        return this.settingService.getTempDir();
    }

    public IdGenerator getIdGenerator()
    {
        return this.idGenerator;
    }

    public void setIdGenerator(IdGenerator idGenerator)
    {
        this.idGenerator = idGenerator;
    }

    public CompressionService getCompressionService()
    {
        return this.compressionService;
    }

    public void setCompressionService(CompressionService compressionService)
    {
        this.compressionService = compressionService;
    }

    public UicStatusDao getStatusDao()
    {
        return this.statusDao;
    }

    public void setStatusDao(UicStatusDao statusDao)
    {
        this.statusDao = statusDao;
    }

    public JdbcTransactionDao getTransactionDao()
    {
        return this.transactionDao;
    }

    public void setTransactionDao(JdbcTransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    public JdbcPartnerDao getPartnerDao()
    {
        return this.partnerDao;
    }

    public void setPartnerDao(JdbcPartnerDao partnerDao)
    {
        this.partnerDao = partnerDao;
    }

    public String getPartnerName()
    {
        return this.partnerName;
    }

    public void setPartnerName(String partnerName)
    {
        this.partnerName = partnerName;
    }
}
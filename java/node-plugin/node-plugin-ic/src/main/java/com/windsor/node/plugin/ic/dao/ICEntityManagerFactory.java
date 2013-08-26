package com.windsor.node.plugin.ic.dao;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;

public class ICEntityManagerFactory
{
    /**
     * Initialize the local {@link EntityManagerFactory}.
     */
    public static EntityManagerFactory initEntityManagerFactory(DataSource dataSource)
    {
        HibernatePersistenceProvider provider = new HibernatePersistenceProvider();
        return provider.createEntityManagerFactory(dataSource,
                                                   new PluginPersistenceConfig().rootEntityPackage("com.windsor.node.plugin.ic.fixeddomain")
                                                                                .debugSql(Boolean.TRUE));
    }
}

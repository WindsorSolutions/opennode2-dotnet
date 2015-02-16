package com.windsor.node.plugin.icisnpdes.dao;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;

import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;

public class IcisEntityManagerFactory
{

    /**
     * Initialize the local {@link EntityManagerFactory}.
     */
    public static EntityManagerFactory initEntityManagerFactory(DataSource dataSource)
    {

        HibernatePersistenceProvider provider = new HibernatePersistenceProvider();

        /*
         * return provider.createEntityManagerFactory( dataSource, new
         * PluginPersistenceConfig().rootEntityPackage(
         * "com.windsor.node.plugin.icisnpdes.generated")
         * .debugSql(Boolean.TRUE));
         */
        return provider.createEntityManagerFactory(
                        dataSource,
                        new PluginPersistenceConfig().rootEntityPackage("com.windsor.node.plugin.icisnpdes.generated")
                                        .classLoader(IcisEntityManagerFactory.class.getClassLoader())
                                        .debugSql(Boolean.FALSE));
    }
}

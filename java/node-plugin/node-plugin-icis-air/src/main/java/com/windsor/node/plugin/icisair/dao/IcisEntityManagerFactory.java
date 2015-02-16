package com.windsor.node.plugin.icisair.dao;

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

        return provider.createEntityManagerFactory(dataSource, new PluginPersistenceConfig().rootEntityPackage("com.windsor.node.plugin.icisair.domain.generated")
                        .classLoader(IcisEntityManagerFactory.class.getClassLoader())//.hibernateDialect("org.hibernate.dialect.Oracle10gDialect")
                        //Don't use this, work around for Oracle 12c when running against OpenNode2 2.08
                        .debugSql(Boolean.FALSE));
    }
}

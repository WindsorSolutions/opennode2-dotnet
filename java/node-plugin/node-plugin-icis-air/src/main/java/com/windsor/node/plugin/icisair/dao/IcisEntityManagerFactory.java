package com.windsor.node.plugin.icisair.dao;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;

import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;
import com.zaxxer.hikari.HikariDataSource;

public class IcisEntityManagerFactory
{

    /**
     * Initialize the local {@link EntityManagerFactory}.
     */
    public static EntityManagerFactory initEntityManagerFactory(DataSource dataSource)
    {
        HibernatePersistenceProvider provider = new HibernatePersistenceProvider();

        EntityManagerFactory emf = null;
        if(dataSource != null && HikariDataSource.class.isAssignableFrom(dataSource.getClass()))
        {
            HikariDataSource hkds = (HikariDataSource)dataSource;
            if(hkds.getDataSourceClassName().contains("Oracle") || hkds.getDataSourceClassName().contains("oracle"))
            {
                //Oracle work around for Oracle version 13 and later
                emf = provider.createEntityManagerFactory(dataSource, new PluginPersistenceConfig().rootEntityPackage("com.windsor.node.plugin.icisair.domain.generated")
                                .classLoader(IcisEntityManagerFactory.class.getClassLoader())
                                .hibernateDialect("org.hibernate.dialect.Oracle10gDialect")
                                .debugSql(Boolean.FALSE));
            }
            else
            {
                emf = provider.createEntityManagerFactory(dataSource, new PluginPersistenceConfig().rootEntityPackage("com.windsor.node.plugin.icisair.domain.generated")
                                .classLoader(IcisEntityManagerFactory.class.getClassLoader())
                                .debugSql(Boolean.FALSE));
            }
        }
        else
        {
            //error condition
        }

        return emf;
    }
}

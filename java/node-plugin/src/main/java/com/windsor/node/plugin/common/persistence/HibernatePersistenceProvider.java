package com.windsor.node.plugin.common.persistence;

import java.util.Properties;

import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;

import org.hibernate.cfg.Environment;
import org.hibernate.ejb.HibernatePersistence;

public class HibernatePersistenceProvider {

    private final PersistenceProvider provider = new HibernatePersistence();

    public EntityManagerFactory createEntityManagerFactory(DataSource dataSource, PluginPersistenceConfig config) {

        Properties jpaProperties = new Properties();

        jpaProperties.put(Environment.DATASOURCE, dataSource);

        if (config.isDebugSql()) {
            jpaProperties.put(Environment.SHOW_SQL, Boolean.TRUE);
            jpaProperties.put(Environment.FORMAT_SQL, Boolean.TRUE);
        }

        return provider.createContainerEntityManagerFactory(
                new HibernatePersistenceUnitInfo(jpaProperties, config),
                jpaProperties);
    }
}
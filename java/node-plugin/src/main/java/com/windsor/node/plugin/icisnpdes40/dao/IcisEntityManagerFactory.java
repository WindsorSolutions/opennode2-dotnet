package com.windsor.node.plugin.icisnpdes40.dao;

import java.util.Properties;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import javax.sql.DataSource;
import org.hibernate.cfg.Environment;
import org.hibernate.ejb.HibernatePersistence;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.plugin.common.persistence.HibernatePersistenceUnitInfo;

public class IcisEntityManagerFactory
{
    /**
     * Initialize the local {@link EntityManagerFactory}.
     */
    public static EntityManagerFactory initEntityManagerFactory(DataSource dataSource) {

        /***
         * Get a reference to the configured DataSource, we'll get the
         * connection info from it
         */
        try {

            Properties jpaProperties = new Properties();

            jpaProperties.put(Environment.DATASOURCE, dataSource);

            PersistenceProvider provider = new HibernatePersistence();

            return provider.createContainerEntityManagerFactory(
                    new HibernatePersistenceUnitInfo(jpaProperties, "com.windsor.node.plugin.icisnpdes40.generated"),
                    jpaProperties);

        } catch (Exception e) {
            throw new WinNodeException("Unable to initialize an EntityManagerFactory", e);
        }
    }
}

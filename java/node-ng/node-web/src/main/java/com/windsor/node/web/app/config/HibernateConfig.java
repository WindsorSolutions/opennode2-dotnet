package com.windsor.node.web.app.config;

import org.hibernate.event.service.spi.EventListenerRegistry;
import org.hibernate.internal.SessionFactoryImpl;
import org.hibernate.jpa.HibernateEntityManagerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;

/**
 * Provides the Hibernate configuration for the application.
 */
public class HibernateConfig {

    @Autowired
    private HibernateEntityManagerFactory entityManagerFactory;

    @Bean
    public EventListenerRegistry eventListenerRegistry() {
        SessionFactoryImpl sessionFactory = (SessionFactoryImpl) entityManagerFactory.getSessionFactory();
        return sessionFactory.getServiceRegistry().getService(EventListenerRegistry.class);
    }
}

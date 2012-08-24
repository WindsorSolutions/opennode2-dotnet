package com.windsor.node.plugin.icisnpdes40;

import java.util.Properties;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.AnnotationConfiguration;
import org.hibernate.cfg.Configuration;
import org.hibernate.cfg.Environment;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class TestCreateEntityManager {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		Configuration config = new AnnotationConfiguration();
		
		config.addPackage("com.windsor.node.plugin.icisnpdes40.generated");
		
		config.setProperty(Environment.DIALECT, "com.windsor.node.plugin.icisnpdes40.NodeOracle10gDialect");
		config.setProperty(Environment.HBM2DDL_AUTO, "validate");
		config.setProperty(Environment.DRIVER, "oracle.jdbc.OracleDriver");
		config.setProperty(Environment.URL, "jdbc:oracle:thin:ICS_FLOW_LOCAL_WA/zRitE6giwvtO87r6mv2P@//ORA11G:1521/ORCL");
		config.setProperty(Environment.CURRENT_SESSION_CONTEXT_CLASS, "jdbc:oracle:thin:ICS_FLOW_LOCAL_WA/zRitE6giwvtO87r6mv2P@//ORA11G:1521/ORCL");
		
		//config.configure();
		
		ServiceRegistryBuilder builder = new ServiceRegistryBuilder().applySettings(config.getProperties());
		ServiceRegistry registry = builder.buildServiceRegistry();
		
		
		SessionFactory sessionFactory = config.buildSessionFactory(registry);
		// sessionFactory.openStatelessSession(ARG_DS) // Do we want a connection from the configure datasource?
		sessionFactory.openSession();
		
		Session session = sessionFactory.getCurrentSession();
		
/*		Properties props = new Properties();
		
		props.put("javax.persistence.jdbc.driver", "oracle.jdbc.OracleDriver");
		//props.put("javax.persistence.jdbc.user", "ICS_FLOW_LOCAL_WA");
		//props.put("javax.persistence.jdbc.password", "zRitE6giwvtO87r6mv2P");
		props.put("javax.persistence.jdbc.url", "jdbc:oracle:thin:ICS_FLOW_LOCAL_WA/zRitE6giwvtO87r6mv2P@//ORA11G:1521/ORCL");

		EntityManagerFactory emf = Persistence.createEntityManagerFactory("pu", props);
	    EntityManager em = emf.createEntityManager();
	    
		final List<LimitSetData> list = em.createQuery("select ls from LimitSetData ls").getResultList();
		
		
		
		System.out.println("size=" + list.size());*/
	}

}

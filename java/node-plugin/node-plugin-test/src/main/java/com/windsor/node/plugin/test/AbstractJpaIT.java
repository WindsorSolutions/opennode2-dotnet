package com.windsor.node.plugin.test;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.plugin.common.persistence.HibernatePersistenceProvider;
import com.windsor.node.plugin.common.persistence.PluginPersistenceConfig;

/**
 * Convenience base integration test class for working with JPA tests. Provides
 * access to an {@link EntityManager}.
 */
public abstract class AbstractJpaIT {

	/**
	 * Directory with DDL files, relative to the class path.
	 */
	public static final String DDL_DIR = "ddl";

	/**
	 * Directory with DML files, relative to the class path.
	 */
	public static final String DML_DIR = "test_dml";

	/**
	 * Directory with XML schema files, relative to the class path.
	 */
	public static final String SCHEMA_DIR = "xsd";

	/**
	 * Directory with XML test files, relative to the class path.
	 */
	public static final String TEST_XML = "test_xml";

	/**
	 * Class logger.
	 */
	protected static final Logger LOGGER = LoggerFactory.getLogger(AbstractJpaIT.class);

	/**
	 * JPA entity manager.
	 */
	private EntityManager entityManager;

	/**
	 * Returns the {@link DataSource} for the database.
	 *
	 * @return the {@link DataSource} for the database
	 */
	protected abstract DataSource getDataSource();

	/**
	 * Returns the name of the package containing the JPA annotated entity
	 * classes.
	 *
	 * @return the name of the package containing the JPA annotated entity
	 *         classes
	 */
	protected abstract String getRootEntityPackage();

	/**
	 * Returns the {@link EntityManager}.
	 *
	 * @return the {@link EntityManager}
	 */
	public EntityManager getEntityManager() {
		if (entityManager == null) {
			final HibernatePersistenceProvider provider = new HibernatePersistenceProvider();
			final PluginPersistenceConfig config = new PluginPersistenceConfig() //
					.debugSql(true) //
					.rootEntityPackage(getRootEntityPackage());
			final EntityManagerFactory emf = provider.createEntityManagerFactory(getDataSource(),
					config);
			entityManager = emf.createEntityManager();
		}
		return entityManager;
	}

}

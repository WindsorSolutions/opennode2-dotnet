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
	 * Name of the test group that uses an existing database. These tests will
	 * not be executed by Maven.
	 */
	public static final String EXISTING_DB_TEST_GROUP_NAME = "existing_db_test";

	/**
	 * Name of the test group that uses a temporary, in-memory database. These
	 * tests will be executed by Maven.
	 */
	public static final String TEMP_DB_TEST_GROUP_NAME = "temp_db_test";

	/**
	 * Directory with DDL files, relative to the class path.
	 */
	public static final String DDL_DIR = "assembly/outer/ddl";

	/**
	 * Directory with DML files, relative to the class path.
	 */
	public static final String DML_DIR = "dml";

	/**
	 * Directory with XML schema files, relative to the class path.
	 */
	public static final String SCHEMA_DIR = "xsd";

	/**
	 * Directory with XML test files, relative to the class path.
	 */
	public static final String TEST_XML = "xml";

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
					.debugSql(showSql()) //
					.setBatchFetchSize(getBatchFetchSize()) //
					.rootEntityPackage(getRootEntityPackage());
			final EntityManagerFactory emf = provider.createEntityManagerFactory(getDataSource(),
					config);
			entityManager = emf.createEntityManager();
		}
		return entityManager;
	}

	/**
	 * Returns whether to show the SQL Hibernate is using.
	 *
	 * @return whether to show the SQL Hibernate is using
	 */
	protected boolean showSql() {
		return true;
	}

	/**
	 * Returns the Hibernate batch fetch size.
	 *
	 * @return the Hibernate batch fetch size
	 */
	protected int getBatchFetchSize() {
		return 1000;
	}

}

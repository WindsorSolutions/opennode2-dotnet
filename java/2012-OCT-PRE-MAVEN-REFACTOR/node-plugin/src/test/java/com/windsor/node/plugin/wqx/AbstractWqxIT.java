package com.windsor.node.plugin.wqx;

import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.collections.iterators.IteratorChain;
import org.testng.annotations.AfterGroups;
import org.testng.annotations.BeforeGroups;
import org.testng.annotations.Test;

import com.windsor.node.plugin.AbstractJpaIT;
import com.windsor.node.plugin.HsqldbOracleStatementIteratorFactory;
import com.windsor.node.plugin.db.HsqlOracleModelDatabaseManager;
import com.windsor.node.plugin.db.IDatabaseManager;

/**
 * Base class which WQX-related tests should extend because it sets up the
 * in-memory DB.
 *
 */
@Test(groups = AbstractWqxIT.WQX_TEST_GROUP_NAME)
public abstract class AbstractWqxIT extends AbstractJpaIT {

	/**
	 * Path to DDL SQL file, relative to the classpath.
	 */
	private static final String DDL_PATH = "/" + DDL_DIR + "/WQX-ORA-DDL.sql";

	/**
	 * Filename prefix for the DDL scripts.
	 */
	private static final String FILENAME_PREFIX = "wqx_";

	/**
	 * Filename suffix for the DDL scripts.
	 */
	private static final String FILENAME_SUFFIX = ".sql";

	/**
	 * Name of the package containing the WQX entity classes.
	 */
	private static final String JAVA_PACKAGE_NAME = "com.windsor.node.plugin.wqx.domain.generated";

	/**
	 * Group name for the WQX tests.
	 */
	protected static final String WQX_TEST_GROUP_NAME = "wqx";

	/**
	 * List of DML files.
	 */
	private static final String[] DML_FILES = { "organization", "project", "monitoringlocation",
			"activity", "projectactivity", "result" };

	/**
	 * Manager for manipulating the in-memory DB.
	 */
	private final IDatabaseManager databaseManager;

	public AbstractWqxIT() {
		databaseManager = new HsqlOracleModelDatabaseManager() {

			@SuppressWarnings("unchecked")
			@Override
			protected Iterator<String> getInitSqlStatements() {
				final List<Iterator<String>> readers = new ArrayList<Iterator<String>>();
				/*
				 * Add the init statements from super class.
				 */
				readers.add(super.getInitSqlStatements());
				try {

					/*
					 * Add the DDL statements.
					 */
					readers.add(HsqldbOracleStatementIteratorFactory.instance().create(
							new InputStreamReader(getClass().getResourceAsStream(DDL_PATH))));

					/*
					 * Add the DML statements.
					 */
					for (final String filename : DML_FILES) {
						final String path = "/" + DML_DIR + "/" + FILENAME_PREFIX + filename
								+ FILENAME_SUFFIX;
						LOGGER.debug("Processing DML path: " + path);
						readers.add(HsqldbOracleStatementIteratorFactory.instance().create(
								new InputStreamReader(getClass().getResourceAsStream(path))));
					}
				} catch (final IOException e) {
					throw new RuntimeException(e);
				}
				return new IteratorChain(readers);
			}

		};
	}

	/**
	 * Sets up the DB before the IT tests are run.
	 *
	 * @throws IOException
	 * @throws SQLException
	 */
	@BeforeGroups(groups = WQX_TEST_GROUP_NAME)
	public void startup() throws IOException, SQLException {
		LOGGER.debug("Starting and initializing database...");
		databaseManager.startAndinitializeDatabase();
		LOGGER.debug("Database started and initialized");
	}

	/**
	 * Cleans up the DB after the IT tests have been run.
	 *
	 * @throws IOException
	 * @throws SQLException
	 */
	@AfterGroups(groups = WQX_TEST_GROUP_NAME)
	public void shutdown() throws IOException, SQLException {
		LOGGER.debug("Shutting down and cleaning up database...");
		databaseManager.stopAndCleanupDatabase();
		LOGGER.debug("Database shut down and cleaned up");
	}

	@Override
	protected String getRootEntityPackage() {
		return JAVA_PACKAGE_NAME;
	}

	@Override
	protected DataSource getDataSource() {
		return databaseManager.getDataSource();
	}

}

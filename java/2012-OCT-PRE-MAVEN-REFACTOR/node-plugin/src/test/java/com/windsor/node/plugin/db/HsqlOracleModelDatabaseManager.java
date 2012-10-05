package com.windsor.node.plugin.db;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import javax.sql.DataSource;

import org.hsqldb.jdbc.JDBCDataSource;

/**
 * Convenience class for managing an in-memory HSQLDB DB.
 *
 */
public class HsqlOracleModelDatabaseManager extends AbstractDatabaseManager {

	/**
	 * Statement for shutting down the in-memory HSQLDB.
	 */
	private static final String SHUTDOWN_STATEMENT = "SHUTDOWN";

	/**
	 * Statement for putting the HSQLDB into Oracle compatibility mode.
	 */
	private static final String USE_ORACLE_MODE_STATEMENT = "SET DATABASE SQL SYNTAX ORA TRUE";

	/**
	 * JDB URL to the in-memory HSQLDB.
	 */
	private static final String JDBC_URL = "jdbc:hsqldb:mem:plugindb";

	/**
	 * Username for the in-memory HSQLDB.
	 */
	private static final String USERNAME = "SA";

	/**
	 * Password fro the in-memory HSQLDB.
	 */
	private static final String PASSWORD = "";

	/**
	 * {@link Datasource} of the in-memory HSQLDB.
	 */
	private DataSource dataSource;

	@Override
	protected Iterator<String> getInitSqlStatements() {
		final List<String> readers = new ArrayList<String>();
		readers.add(USE_ORACLE_MODE_STATEMENT);
		return readers.iterator();
	}

	@Override
	public Iterator<String> getStopSqlStatements() {
		final List<String> statements = new ArrayList<String>();
		statements.add(SHUTDOWN_STATEMENT);
		return statements.iterator();
	}

	@Override
	public DataSource getDataSource() {
		if (dataSource == null) {
			final JDBCDataSource ds = new JDBCDataSource();
			ds.setUrl(JDBC_URL);
			ds.setUser(USERNAME);
			ds.setPassword(PASSWORD);
			dataSource = ds;
		}
		return dataSource;
	}

}

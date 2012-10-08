package com.windsor.node.plugin.test.db;

import java.sql.SQLException;
import java.sql.Statement;
import java.util.Collections;
import java.util.Iterator;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Convenience implementation of {@link IDatabaseManager} which defines methods
 * for getting the SQL statements necessary for starting/initializing and
 * stopping/cleaning up the test database.
 *
 */
public abstract class AbstractDatabaseManager implements IDatabaseManager {

	/**
	 * Class logger.
	 */
	protected static final Logger LOGGER = LoggerFactory.getLogger(AbstractDatabaseManager.class);

	@Override
	public void startAndinitializeDatabase() throws SQLException {
		executeSqlStatements(getInitSqlStatements());
	}

	@Override
	public void stopAndCleanupDatabase() throws SQLException {
		executeSqlStatements(getStopSqlStatements());
	}

	/**
	 * Returns the statements necessary to start and initialize the DB.
	 *
	 * @return the statements necessary to start and initialize the DB
	 */
	@SuppressWarnings("unchecked")
	protected Iterator<String> getInitSqlStatements() {
		return Collections.EMPTY_LIST.iterator();
	}

	/**
	 * Returns the statements necessary to stop and clean up the DB.
	 *
	 * @return the statements necessary to stop and clean up the DB
	 */
	@SuppressWarnings("unchecked")
	protected Iterator<String> getStopSqlStatements() {
		return Collections.EMPTY_LIST.iterator();
	}

	/**
	 * Executes the SQL statements in the DB.
	 *
	 * @param sqlStatements
	 *            SQL statements to execute
	 * @throws SQLException
	 *             thrown if an error occurs executing a SQL statement
	 */
	private void executeSqlStatements(final Iterator<String> sqlStatements) throws SQLException {
		final Statement statement = getDataSource().getConnection().createStatement();
		while (sqlStatements.hasNext()) {
			final String sql = sqlStatements.next();
			LOGGER.debug("Next statement to execute: {}", sql);
			statement.execute(sql);
		}
	}
}

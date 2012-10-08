package com.windsor.node.plugin.test.db;

import java.io.IOException;
import java.sql.SQLException;

import javax.sql.DataSource;

/**
 * Defines how a database may be managed. Provides for starting and initializing
 * and stopping and cleaning up the database.
 *
 */
public interface IDatabaseManager {

	/**
	 * Returns a {@link DataSource} object to the DB.
	 *
	 * @return {@link DataSource} to the DB
	 */
	DataSource getDataSource();

	/**
	 * Starts and initializes the database.
	 *
	 * @throws SQLException
	 *             thrown if a SQL error occurs starting or initializing the
	 *             database
	 * @throws IOException
	 *             thrown if an IO error occurs reading the SQL scripts
	 */
	void startAndinitializeDatabase() throws SQLException;

	/**
	 * Stops and cleans up the database.
	 *
	 * @throws SQLException
	 *             thrown if a SQL error occurs stopping the database
	 * @throws IOException
	 *             thrown if an IO error occurs reading the SQL scripts
	 */
	void stopAndCleanupDatabase() throws SQLException;

}
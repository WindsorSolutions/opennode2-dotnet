package com.windsor.node.plugin.test;

import static com.windsor.node.plugin.test.AbstractJpaIT.EXISTING_DB_TEST_GROUP_NAME;

import javax.sql.DataSource;

//import org.apache.commons.dbcp.BasicDataSource;
import org.testng.annotations.Test;

/**
 * Provides {@link DataSource} based on environment properties. Tests that
 * extend this class are not by Maven. Rather they are meant to be run in an ad
 * hoc manner.
 * <p/>
 * The environment properties for creating a DB connection are:
 * <ul>
 * <li>DB_USERNAME</li>
 * <li>DB_PASSWORD</li>
 * <li>DB_URL</li>
 * <li>DB_DRIVER</li>
 * </ul>
 */
@Test(groups = EXISTING_DB_TEST_GROUP_NAME)
public abstract class AbstractExistingDbIT extends AbstractJpaIT {

	/**
	 * Name of the environment property which contains the DB username.
	 */
	private static final String USERNAME_ENV_NAME = "DB_USERNAME";

	/**
	 * Name of the environment property which contains the DB password.
	 */
	private static final String PASSWORD_ENV_NAME = "DB_PASSWORD";

	/**
	 * Name of the environment property which contains the DB URL.
	 */
	private static final String URL_ENV_NAME = "DB_URL";

	/**
	 * JDBC driver class.
	 */
	private static final String DRIVER_CLASS_NAME = "DB_DRIVER";

	/**
	 * Datasource for connecting to the DB.
	 */
	//private final BasicDataSource dataSource;

	/**
	 * No-arg constructor.
	 */
	public AbstractExistingDbIT() {
		this(System.getenv(USERNAME_ENV_NAME), System.getenv(PASSWORD_ENV_NAME), System
				.getenv(URL_ENV_NAME), System.getenv(DRIVER_CLASS_NAME));
	}

	/**
	 * Constructor.
	 *
	 * @param username
	 *            Username to use to connect to the DB
	 * @param password
	 *            Password to use to connect to the DB
	 * @param url
	 *            URL to use to connect to the DB
	 */
	public AbstractExistingDbIT(final String username, final String password, final String url,
			final String driverClassName) {
		super();
		/*dataSource = new BasicDataSource();
		dataSource.setUsername(username);
		dataSource.setPassword(password);
		dataSource.setUrl(url);
		dataSource.setDriverClassName(driverClassName);*/
	}

	@Override
	public DataSource getDataSource() {
		//return dataSource;
	    return null;
	}

}

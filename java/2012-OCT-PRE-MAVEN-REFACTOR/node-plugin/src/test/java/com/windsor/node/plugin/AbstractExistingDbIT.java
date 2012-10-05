package com.windsor.node.plugin;

public abstract class AbstractExistingDbIT extends AbstractJpaIT {

	private static final String USERNAME_ENV_NAME = "DB_USERNAME";

	private static final String PASSWORD_ENV_NAME = "DB_PASSWORD";

	private static final String URL_ENV_NAME = "DB_URL";

	private String username;

	private String password;

	private String url;

	public AbstractExistingDbIT() {
		this(System.getenv(USERNAME_ENV_NAME), System.getenv(PASSWORD_ENV_NAME), System.getenv(URL_ENV_NAME));
	}

	public AbstractExistingDbIT(final String username, final String password, final String url) {
		super();
		this.username = username;
		this.password = password;
		this.url = url;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(final String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(final String password) {
		this.password = password;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(final String url) {
		this.url = url;
	}

}

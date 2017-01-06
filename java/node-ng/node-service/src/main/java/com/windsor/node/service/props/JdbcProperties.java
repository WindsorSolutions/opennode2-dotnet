package com.windsor.node.service.props;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;

/**
 * Provides the JDBC configuration for the application.
 */
@ConfigurationProperties(locations = "classpath:jdbc.properties", prefix = "jdbc", merge = false)
@Configuration
public class JdbcProperties {

    private String url;
    private String username;
    private String password;
    private String connectionTestQuery;

    public JdbcProperties() {
        super();
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getConnectionTestQuery() {
        return connectionTestQuery;
    }

    public void setConnectionTestQuery(String connectionTestQuery) {
        this.connectionTestQuery = connectionTestQuery;
    }

}

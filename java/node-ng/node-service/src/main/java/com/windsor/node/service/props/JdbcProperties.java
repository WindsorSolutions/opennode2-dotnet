package com.windsor.node.service.props;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

/**
 * Provides the JDBC configuration for the application.
 */
@Configuration
@PropertySource(value = {"classpath:jdbc.properties", "file:/var/opennode2_home/conf/jdbc.properties"}, ignoreResourceNotFound = true)
public class JdbcProperties {

    @Value("${jdbc.url}")
    private String url;

    @Value("${jdbc.username}")
    private String username;

    @Value("${jdbc.password}")
    private String password;

    @Value("${jdbc.connectionTestQuery:}")
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

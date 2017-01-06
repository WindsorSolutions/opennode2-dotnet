package com.windsor.node.web.app;

import java.util.Arrays;
import java.util.EnumSet;
import java.util.Properties;

import javax.servlet.DispatcherType;
import javax.servlet.Filter;
import javax.servlet.http.HttpSessionListener;
import javax.sql.DataSource;

import org.apache.wicket.RuntimeConfigurationType;
import org.apache.wicket.protocol.http.WebApplication;
import org.apache.wicket.protocol.http.WicketFilter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;
import org.springframework.boot.autoconfigure.jdbc.DataSourceBuilder;
import org.springframework.boot.context.embedded.FilterRegistrationBean;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.ImportResource;
import org.springframework.context.support.PropertySourcesPlaceholderConfigurer;
import org.springframework.core.Ordered;
import org.springframework.core.annotation.Order;
import org.springframework.data.domain.AuditorAware;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.JavaMailSenderImpl;
import org.springframework.orm.jpa.support.OpenEntityManagerInViewFilter;
import org.springframework.web.context.request.RequestContextListener;
import org.springframework.web.servlet.view.freemarker.FreeMarkerConfigurer;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.SpringSecurityAuditorAware;
import com.windsor.node.service.props.JdbcProperties;
import com.windsor.node.service.props.NosProperties;
import com.windsor.node.web.app.config.SecurityConfig;
import com.zaxxer.hikari.HikariDataSource;

import net.bull.javamelody.MonitoringFilter;
import net.bull.javamelody.Parameter;
import net.bull.javamelody.SessionListener;

/**
 * Bootstraps the Node Administration web application.
 */
@EnableJpaAuditing
@EnableAutoConfiguration(exclude = DataSourceAutoConfiguration.class)
@Configuration
@EntityScan(basePackages = {"com.windsor.stack.domain", "com.windsor.node.domain"})
@EnableJpaRepositories(basePackages = {"com.windsor.stack", "com.windsor.node.repo"})
@ComponentScan(basePackages = {"com.windsor.stack", "com.windsor.node.web", "com.windsor.node.service"})
@ImportResource({"classpath:net/bull/javamelody/monitoring-spring.xml"})
public class NodeApp {

    @Autowired
    @Qualifier("springSecurityFilterChain")
    private Filter springSecurityFilter;

    @Value("${wicket.configuration:DEVELOPMENT}")
    private String config;

    public static void main(String[] args) throws Exception {
        SpringApplication.run(NodeApp.class, args);
    }

    @Bean
    public AuditorAware<Account> auditorProvider() {
        return new SpringSecurityAuditorAware();
    }

    @Order(Ordered.HIGHEST_PRECEDENCE)
    @Bean
    public FilterRegistrationBean getSpringSecurityFilter() {
        FilterRegistrationBean registration = new FilterRegistrationBean(springSecurityFilter);
        registration.setOrder(Ordered.HIGHEST_PRECEDENCE);
        return registration;
    }

    @Order(Ordered.HIGHEST_PRECEDENCE + 2)
    @Bean
    public FilterRegistrationBean newUsernameLoggingFilter() {
        FilterRegistrationBean registration = new FilterRegistrationBean(new Slf4jSpringUsernameFilter());
        registration.setUrlPatterns(Arrays.asList("/*"));
        registration.setOrder(Ordered.HIGHEST_PRECEDENCE + 2);
        return registration;
    }

    @Order(Ordered.HIGHEST_PRECEDENCE + 5)
    @Bean
    public FilterRegistrationBean newMonitoringFilter() {
        FilterRegistrationBean registration = new FilterRegistrationBean(new MonitoringFilter());
        registration.setUrlPatterns(Arrays.asList("/*"));
        registration.addInitParameter(Parameter.MONITORING_PATH.getCode(), SecurityConfig.PATH_MONITORING);
        registration.setOrder(Ordered.HIGHEST_PRECEDENCE + 5);
        return registration;
    }

    @Order(Ordered.HIGHEST_PRECEDENCE + 10)
    @Bean
    public FilterRegistrationBean getOpenEntityManagerInViewFilter() {
        FilterRegistrationBean registration = new FilterRegistrationBean(new OpenEntityManagerInViewFilter());
        registration.setOrder(Ordered.HIGHEST_PRECEDENCE + 10);
        return registration;
    }

    @Order(Ordered.HIGHEST_PRECEDENCE + 15)
    @Bean
    public FilterRegistrationBean getWicketFiler() {
        FilterRegistrationBean registration = new FilterRegistrationBean();
        WebApplication application = new NodeWebApp();
        WicketFilter wicketFilter = new WicketFilter(application);
        application.setConfigurationType(RuntimeConfigurationType.valueOf(config));
        wicketFilter.setFilterPath("/");
        registration.setFilter(wicketFilter);
        registration.setDispatcherTypes(EnumSet.allOf(DispatcherType.class));
        registration.setOrder(Ordered.HIGHEST_PRECEDENCE + 15);
        return registration;
    }

    @Bean
    public HttpSessionListener newJavaMelodySessionListener() {
        return new SessionListener();
    }

    @Bean
    public HttpSessionListener newNodeSessionListener() {
        return new NodeSessionListener();
    }

    @Bean
    public RequestContextListener requestContextListener() {
        return new RequestContextListener();
    }

    @Bean
    public DataSource newDataSource(JdbcProperties config) {
        HikariDataSource ds = (HikariDataSource) DataSourceBuilder.create()
                .type(HikariDataSource.class)
                .username(config.getUsername())
                .password(config.getPassword())
                .url(config.getUrl())
                .build();
        ds.setConnectionTestQuery(config.getConnectionTestQuery());
        return ds;
    }

    @Bean
    public JavaMailSender newJavaMailSender(NosProperties nosProperties) {
    	JavaMailSenderImpl javaMailSender = new JavaMailSenderImpl();
    	javaMailSender.setHost(nosProperties.getSmtpGateway());
    	javaMailSender.setPort(nosProperties.getSmtpGatewayPort());
    	javaMailSender.setUsername(nosProperties.getSmtpUsername());
    	javaMailSender.setPassword(nosProperties.getSmtpPassword());
    	
    	Properties mailProps = new Properties();
    	mailProps.put("mail.smtp.auth", nosProperties.isSmtpAuthorization());
    	mailProps.put("mail.smtp.starttls.enable", nosProperties.isSmptStartTLSEnabled());
    	mailProps.put("mail.smtp.starttls.required", nosProperties.isSmtpStartTLSRequired());
    	javaMailSender.setJavaMailProperties(mailProps);
    	return javaMailSender;
    }
	
	@Bean
	public FreeMarkerConfigurer freeMarkerConfigurer() {
	    FreeMarkerConfigurer configurer = new FreeMarkerConfigurer();
	    configurer.setTemplateLoaderPaths("classpath:/templates/");
	    configurer.setPreferFileSystemAccess(false);
	    return configurer;
	}

	 @Bean
	 public static PropertySourcesPlaceholderConfigurer placeHolderConfigurer() {
		return new PropertySourcesPlaceholderConfigurer();
	 }	
	
}

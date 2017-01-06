package com.windsor.node.web.app.config;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.core.userdetails.UserDetailsService;

import com.windsor.node.domain.NodeConstants;
import com.windsor.node.service.NAASAuthenticationService;
import com.windsor.node.service.UserDetailsServiceImpl;
import com.windsor.node.web.app.config.security.NodeAuthenticationProvider;

/**
 * Provides the security configuration for the application.
 */
@EnableWebSecurity
@Configuration
public class SecurityConfig extends WebSecurityConfigurerAdapter{

    // notable paths
    public static final String PATH_HOME = "/";
    public static final String PATH_APP_ERROR = "/error";
    public static final String PATH_404_ERROR = "/404";
    public static final String PATH_401_ERROR = "/401";
    public static final String PATH_500_ERROR = "/500";
    public static final String PATH_EXPIRED_ERROR = "/expired";
    public static final String PATH_LOGIN = "/login";
    public static final String PATH_LOGOUT = "/logout";
    public static final String PATH_ABOUT = "/about";
    public static final String PATH_HELP = "/help";
    public static final String PATH_MONITORING = "/monitoring";

    @Value("${envLocation")
    private String envLocation;

    @Autowired
    private NAASAuthenticationService authenticationService;

    @Override
    public void configure(final WebSecurity web) throws Exception {
        web.ignoring().antMatchers(
                "/favicon.ico", "/404", "/500", "/expired",
                "/**/*.png", "/**/*.svg", "/**/*.ttf", "/**/*.woff",
                "/**/*.eot", "/**/*.jpg", "/**/*.gif", "/**/*.css",
                "/**/*.less", "/**/*.js", "/**/*.map");
    }

    @Bean(name = "authenticationManager")
    @Override
    public AuthenticationManager authenticationManagerBean() throws Exception {
        return super.authenticationManagerBean();
    }

    @Override
    protected void configure(final HttpSecurity http) throws Exception {

        http.formLogin()
                .loginPage("/login")
                .defaultSuccessUrl("/");

        http.logout()
                .logoutUrl("/logout")
                .logoutSuccessUrl("/")
                .deleteCookies("JSESSIONID")
                .invalidateHttpSession(true);

        http.authorizeRequests()
                .antMatchers(
                        PATH_401_ERROR,
                        PATH_404_ERROR,
                        PATH_500_ERROR,
                        PATH_EXPIRED_ERROR,
                        PATH_LOGIN,
                        PATH_LOGOUT)
                .permitAll()
                .antMatchers(PATH_MONITORING)
                .hasAuthority(NodeConstants.PERM_NAME_MONITOR_APPLICATION)
                .anyRequest()
                .authenticated();

        http.headers().frameOptions().disable();
        http.csrf().disable();

        /*
         * Redirect to HTTPS in non-development envs.
         */
//        if ((!NodeConstants.DEV_ENV_NAME.equalsIgnoreCase(envLocation))
//                && (!NodeConstants.DOCKER_ENV_NAME.equalsIgnoreCase(envLocation))) {
//            http.requiresChannel().anyRequest().requiresSecure();
//        }
    }

    @Override
    @Bean
    public UserDetailsService userDetailsService() {
        return new UserDetailsServiceImpl();
    }

    @Override
    protected void configure(final AuthenticationManagerBuilder auth) throws Exception {
        auth.authenticationProvider(new NodeAuthenticationProvider(userDetailsService(), authenticationService))
                .eraseCredentials(false);
    }
}

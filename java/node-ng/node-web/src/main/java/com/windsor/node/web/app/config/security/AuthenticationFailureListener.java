package com.windsor.node.web.app.config.security;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationListener;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.authentication.event.AbstractAuthenticationFailureEvent;
import org.springframework.security.web.authentication.WebAuthenticationDetails;
import org.springframework.stereotype.Component;

import com.windsor.node.service.ActivityService;

/**
 * Provides a listener that looks for authentication failures.
 */
@Component
public class AuthenticationFailureListener implements ApplicationListener<AbstractAuthenticationFailureEvent> {

    private final static Logger logger = LoggerFactory.getLogger(AuthenticationFailureListener.class);

    @Autowired
    private ActivityService service;

	@Override
	public void onApplicationEvent(AbstractAuthenticationFailureEvent event) {
        logger.debug("Login failure for account \"" + event.getAuthentication().getPrincipal() + "\"");
        UsernamePasswordAuthenticationToken token = (UsernamePasswordAuthenticationToken) event.getSource();
        WebAuthenticationDetails details = (WebAuthenticationDetails) token.getDetails();
    	String ipAddress = details.getRemoteAddress();
    	String email = event.getAuthentication().getPrincipal().toString();
    	service.loginFailed(email, ipAddress);
	}
    
}

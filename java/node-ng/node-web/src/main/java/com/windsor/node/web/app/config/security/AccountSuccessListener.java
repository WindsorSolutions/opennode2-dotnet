package com.windsor.node.web.app.config.security;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationListener;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.authentication.event.InteractiveAuthenticationSuccessEvent;
import org.springframework.security.web.authentication.WebAuthenticationDetails;
import org.springframework.stereotype.Component;

import com.windsor.node.service.ActivityService;
import com.windsor.node.service.NodeUser;

/**
 * Provides a listener that looks for authentication successes.
 */
@Component
public class AccountSuccessListener implements ApplicationListener<InteractiveAuthenticationSuccessEvent> {

    private final static Logger logger = LoggerFactory.getLogger(AccountSuccessListener.class);

    @Autowired
    private ActivityService service;
    
    @Override
    public void onApplicationEvent(InteractiveAuthenticationSuccessEvent event) {
    	UsernamePasswordAuthenticationToken token = (UsernamePasswordAuthenticationToken) event.getSource();
    	@SuppressWarnings("rawtypes")
		NodeUser nodeUser = (NodeUser) token.getPrincipal();
    	WebAuthenticationDetails details = (WebAuthenticationDetails) token.getDetails();
    	String ipAddress = details.getRemoteAddress();
    	String email = nodeUser.getUsername();
    	service.loginSuccessful(email, ipAddress);
        logger.debug(("Successful login for account \"" + email + "\""));
    }
}

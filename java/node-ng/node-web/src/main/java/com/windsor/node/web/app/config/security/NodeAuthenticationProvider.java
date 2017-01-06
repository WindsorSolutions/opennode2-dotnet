package com.windsor.node.web.app.config.security;

import java.net.MalformedURLException;
import java.rmi.RemoteException;

import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.InternalAuthenticationServiceException;
import org.springframework.security.authentication.LockedException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import com.windsor.node.service.NAASAuthenticationService;
import com.windsor.node.service.NodeUser;

/**
 * Provides the authentication mechanism for the application.
 */
public class NodeAuthenticationProvider implements AuthenticationProvider {

    private final static Logger logger = LoggerFactory.getLogger(NodeAuthenticationProvider.class);

    private final UserDetailsService service;

    private NAASAuthenticationService authenticationService;

    public NodeAuthenticationProvider(final UserDetailsService service, NAASAuthenticationService authenticationService) {
        super();
        this.service = service;
        this.authenticationService = authenticationService;
    }

    @Override
    public Authentication authenticate(Authentication authentication) throws AuthenticationException {

        final String name = authentication.getName();
        logger.info("Logging in \"" + name + "\"");
        final UserDetails userDetails = service.loadUserByUsername(name);
        UsernamePasswordAuthenticationToken result = null;

        if(userDetails != null) {

            if (!userDetails.isAccountNonLocked()) {
                throw new LockedException("Account locked.");
            }

            if (!userDetails.isEnabled()) {
                throw new DisabledException("Account has not yet been verified.");
            }

            try {

                HttpServletRequest request =
                        ((ServletRequestAttributes) RequestContextHolder.currentRequestAttributes()).getRequest();

                String naasToken =
                        authenticationService.validateAccount(name, authentication.getCredentials().toString(),
                                request.getRemoteAddr());
                NodeUser<?> nodeUser = (NodeUser<?>) userDetails;
                nodeUser.setNaasToken(naasToken);

                if(naasToken != null) {
                    result = new UsernamePasswordAuthenticationToken(userDetails, authentication.getCredentials(),
                            nodeUser.getAuthorities());
                } else {
                    throw new BadCredentialsException("Incorrect password");
                }
            } catch(RemoteException exception) {
                throw new InternalAuthenticationServiceException("NAAS authentication failed: "
                        + exception.getMessage());
            } catch(MalformedURLException exception) {
                throw new InternalAuthenticationServiceException("The NAAS endpoint is invalid or incorrect: "
                        + exception.getMessage());
            }
        } else {
            throw new UsernameNotFoundException("Username not found");
        }

        return result;
    }

    @Override
    public boolean supports(final Class<? extends Object> authentication) {
        return UsernamePasswordAuthenticationToken.class
                .isAssignableFrom(authentication);
    }
}

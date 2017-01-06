package com.windsor.node.web.app;

import com.windsor.stack.security.userdetails.SecurityUser;
import org.slf4j.MDC;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;

import javax.servlet.*;
import java.io.IOException;

/**
 * Provides a filter that logs the logged-in account name.
 */
public class Slf4jSpringUsernameFilter implements Filter {

    private static final String KEY_ACCOUNT = "account";
    private static final String CONF_NOT_LOGGED_IN = "notLoggedIn";

    private String notLoggedIn;

    @Override
    public void init(final FilterConfig filterConfig) throws ServletException {
        notLoggedIn = filterConfig.getInitParameter(CONF_NOT_LOGGED_IN);
    }

    @Override
    public void doFilter(final ServletRequest request, final ServletResponse response, final FilterChain chain)
            throws IOException, ServletException {

        String user = null;
        SecurityContext context = SecurityContextHolder.getContext();

        if (context != null
                && context.getAuthentication() != null
                && context.getAuthentication().getPrincipal() != null) {
            final Object principal = context.getAuthentication().getPrincipal();
            if (principal instanceof SecurityUser) {
                final SecurityUser securityUser = (SecurityUser) principal;
                user = securityUser.getUsername();
            } else {
                user = principal.toString();
            }
        } else {
            user = notLoggedIn;
        }

        MDC.put(KEY_ACCOUNT, user);
        try {
            chain.doFilter(request, response);
        } finally {
            MDC.remove(KEY_ACCOUNT);
        }
    }

    @Override
    public void destroy() {
    }
}

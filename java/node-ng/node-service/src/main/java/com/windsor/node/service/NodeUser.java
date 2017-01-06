package com.windsor.node.service;

import com.windsor.stack.domain.security.SecurityUser;
import org.springframework.security.core.GrantedAuthority;

import java.util.Collection;

/**
 * Provides a custom user details object for the application.
 */
public class NodeUser<U> extends SecurityUser<U> {

    /**
     * NAAS authentication token.
     */
    private String naasToken;

    public NodeUser(U user, String username, String password, boolean enabled, boolean accountNonExpired,
                    boolean credentialsNonExpired, boolean accountNonLocked,
                    Collection<? extends GrantedAuthority> authorities) {
        super(user, username, password, enabled, accountNonExpired, credentialsNonExpired, accountNonLocked, authorities);
    }

    public String getNaasToken() {
        return naasToken;
    }

    public void setNaasToken(String naasToken) {
        this.naasToken = naasToken;
    }
}

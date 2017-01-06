package com.windsor.node.service;

import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.Account;

/**
 * Provides a service for fetching User details.
 *
 * This class mediates between the Spring security concept of a user and this application's Account objects.
 */
@Transactional(readOnly = true)
public class UserDetailsServiceImpl implements UserDetailsService {

    @Autowired
    private AccountService service;

    @Override
    public UserDetails loadUserByUsername(String name) throws UsernameNotFoundException {
        Optional<Account> optionalAccount = service.findByName(name);
        NodeUser<?> securityUser = null;
        if(optionalAccount.isPresent()) {
            Account account = optionalAccount.get();
            securityUser = new NodeUser<>(account,
                    account.getNaasAccount(),
                    account.getNaasAccount(),
                    account.isActive(),
                    true,
                    true,
                    true,
                    getPermissionAuthorities(account).collect(Collectors.toList()));
        }

        return securityUser;
    }

    private Stream<GrantedAuthority> getPermissionAuthorities(Account account) {
        return account.getSystemRoleType().getPermissions().stream()
                .map(p -> p.getId())
                .map(SimpleGrantedAuthority::new);
    }
}

package com.windsor.node.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.AuditorAware;
import org.springframework.security.authentication.AnonymousAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.repo.AccountRepository;
import com.windsor.node.service.props.NaasProperties;

/**
 * Provides the auditor for the current session.
 */
public class SpringSecurityAuditorAware implements AuditorAware<Account> {

    @Autowired
    private NaasProperties naasProperties;
    
    @Autowired
    private AccountRepository accountRepo;
    
    public SpringSecurityAuditorAware() {
        super();
    }

    @SuppressWarnings("rawtypes")
    @Override
    public Account getCurrentAuditor() {
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        Account account = null;
        if ((authentication == null) 
        		|| (!authentication.isAuthenticated()) 
        		|| (authentication instanceof AnonymousAuthenticationToken)) 
        {
        	/*
        	 * If there is no authenticated user (e.g., in the case of login failure), 
        	 * use the node admin account as the auditor.
        	 */
        	account = accountRepo.findByEmail(naasProperties.getNaasAdminUsername());
        } else {
        	/*
        	 * Otherwise, use the account assoicated with the logged in user.
        	 */
	        account = (Account) ((com.windsor.stack.domain.security.SecurityUser) authentication
	                .getPrincipal()).getUser();
        }
        return account;
    }
}

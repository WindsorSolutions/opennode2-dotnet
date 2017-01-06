package com.windsor.node.web.model;

import com.windsor.node.domain.entity.Account;
import com.windsor.stack.web.wicket.security.SpringAuthenticatedWebSession;
import org.apache.wicket.model.LoadableDetachableModel;
import org.springframework.security.authentication.AnonymousAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;

/**
 * Provides a model over the currently logged-in account.
 */
public class LoggedInAccountModel extends LoadableDetachableModel<Account> {

    @Override
    protected Account load() {

        Account account = null;
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();

        if(authentication != null && !(authentication instanceof AnonymousAuthenticationToken)) {
            SpringAuthenticatedWebSession<Account> session = SpringAuthenticatedWebSession.getCurrent();
            account = session.getSecurityUser().get().getUser();
        }

        return account;
    }
}

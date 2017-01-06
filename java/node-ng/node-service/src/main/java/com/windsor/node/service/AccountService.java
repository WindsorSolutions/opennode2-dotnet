package com.windsor.node.service;

import java.util.Optional;

import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Account instances.
 */
public interface AccountService extends ICrudService<Account, String, AccountSearchCriteria, AccountSort> {

    Optional<Account> findByName(String name);

    Account add(String email, String password, Account adminAccount) throws NaasException;

    Account logicalDelete(Account account);

}

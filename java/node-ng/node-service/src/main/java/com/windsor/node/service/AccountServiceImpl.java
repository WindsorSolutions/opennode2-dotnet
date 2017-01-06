package com.windsor.node.service;

import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSort;
import com.windsor.node.domain.search.AccountSorts;
import com.windsor.node.repo.AccountRepository;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Account Service.
 */
@Service
@Transactional(readOnly = true)
public class AccountServiceImpl extends AbstractCrudService<Account, String, AccountSearchCriteria, AccountSort>
        implements AccountService {

    @Autowired
    private AccountRepository repository;

    @Autowired
    private NAASAuthenticationService naasService;

    @Autowired
    private NaasProperties naasProperties;

    @Override
    protected ICrudRepository<Account, String, AccountSearchCriteria, AccountSort> getRepo() {
        return repository;
    }

    @Override
    public Optional<Account> findByName(String name) {
        AccountSearchCriteria criteria = new AccountSearchCriteria();
        criteria.setName(name);
        return repository.find(criteria, AccountSorts.ID, 0L, 1L).findFirst();
    }

    @Transactional(readOnly = false)
    @Override
    public Account add(String emailAddress, String password, Account adminAccount) throws NaasException {
        Account account = new Account();
        account.setNaasAccount(emailAddress);
        account.setActive(true);
        account.setDeleted(false);
        account.setSystemRoleType(SystemRoleType.Authed);
        account.setAffiliation(naasProperties.getNodeId());
        Account savedAccount = repository.save(account);
        naasService.addUser(emailAddress, password, adminAccount);
        return savedAccount;
    }

    @Transactional(readOnly = false)
    @Override
    public Account logicalDelete(Account account) {
        account.setDeleted(true);
        account.setActive(false);
        account.setSystemRoleType(SystemRoleType.Authed);
        return repository.save(account);
    }

}

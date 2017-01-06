package com.windsor.node.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.search.AccountPolicySearchCriteria;
import com.windsor.node.domain.search.AccountPolicySort;
import com.windsor.node.repo.AccountPolicyRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Account Service.
 */
@Service
@Transactional(readOnly = true)
public class AccountPolicyServiceImpl extends AbstractCrudService<AccountPolicy, String, AccountPolicySearchCriteria, AccountPolicySort>
        implements AccountPolicyService {

    @Autowired
    private AccountPolicyRepository repository;

    @Override
    protected ICrudRepository<AccountPolicy, String, AccountPolicySearchCriteria, AccountPolicySort> getRepo() {
        return repository;
    }

}

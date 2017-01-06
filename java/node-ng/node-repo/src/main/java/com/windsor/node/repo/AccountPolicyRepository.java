package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.search.AccountPolicySearchCriteria;
import com.windsor.node.domain.search.AccountPolicySort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Account instances.
 */
public interface AccountPolicyRepository extends JpaRepository<AccountPolicy, String>,
        ICrudRepository<AccountPolicy, String, AccountPolicySearchCriteria, AccountPolicySort> {

}

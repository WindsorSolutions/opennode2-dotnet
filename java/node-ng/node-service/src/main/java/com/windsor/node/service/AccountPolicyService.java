package com.windsor.node.service;

import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.search.AccountPolicySearchCriteria;
import com.windsor.node.domain.search.AccountPolicySort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing AccountPolicy instances.
 */
public interface AccountPolicyService extends ICrudService<AccountPolicy, String, AccountPolicySearchCriteria, AccountPolicySort> {

}

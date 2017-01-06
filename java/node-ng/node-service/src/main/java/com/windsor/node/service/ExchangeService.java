package com.windsor.node.service;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Exchange instances.
 */
public interface ExchangeService extends ICrudService<Exchange, String, ExchangeSearchCriteria, ExchangeSort> {

    boolean isNameUnique(String name, String excludeId);

}

package com.windsor.node.service;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing ExchangeService instances.
 */
public interface ExchangeServiceService extends ICrudService<ExchangeService, String, ExchangeServiceSearchCriteria, ExchangeServiceSort> {
    
}

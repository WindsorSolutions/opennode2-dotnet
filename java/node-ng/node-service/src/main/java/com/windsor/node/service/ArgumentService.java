package com.windsor.node.service;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Argument instances.
 */
public interface ArgumentService extends ICrudService<Argument, String, ArgumentSearchCriteria, ArgumentSort> {

}

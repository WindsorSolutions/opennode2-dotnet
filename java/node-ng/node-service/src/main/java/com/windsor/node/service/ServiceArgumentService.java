package com.windsor.node.service;

import com.windsor.node.domain.entity.ServiceArgument;
import com.windsor.node.domain.search.ServiceArgumentSearchCriteria;
import com.windsor.node.domain.search.ServiceArgumentSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing ServiceArgument instances.
 */
public interface ServiceArgumentService extends ICrudService<ServiceArgument, String, ServiceArgumentSearchCriteria, ServiceArgumentSort> {

}

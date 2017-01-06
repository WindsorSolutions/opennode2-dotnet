package com.windsor.node.service;

import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.domain.search.ServiceConnectionSearchCriteria;
import com.windsor.node.domain.search.ServiceConnectionSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing ServiceConnection instances.
 */
public interface ServiceConnectionService extends ICrudService<ServiceConnection, String, ServiceConnectionSearchCriteria, ServiceConnectionSort> {

}

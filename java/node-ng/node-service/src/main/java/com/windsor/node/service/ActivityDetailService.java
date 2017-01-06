package com.windsor.node.service;

import com.windsor.node.domain.entity.ActivityDetail;
import com.windsor.node.domain.search.ActivityDetailSearchCriteria;
import com.windsor.node.domain.search.ActivityDetailSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Activity Detail instances.
 */
public interface ActivityDetailService extends ICrudService<ActivityDetail, String, ActivityDetailSearchCriteria, ActivityDetailSort> {

}

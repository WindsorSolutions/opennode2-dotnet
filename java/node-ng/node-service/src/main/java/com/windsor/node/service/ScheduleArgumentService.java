package com.windsor.node.service;

import com.windsor.node.domain.entity.ScheduleArgument;
import com.windsor.node.domain.search.ScheduleArgumentSearchCriteria;
import com.windsor.node.domain.search.ScheduleArgumentSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing ScheduleArgument instances.
 */
public interface ScheduleArgumentService extends ICrudService<ScheduleArgument, String, ScheduleArgumentSearchCriteria, ScheduleArgumentSort> {

}

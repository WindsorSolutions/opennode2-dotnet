package com.windsor.node.service;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.domain.search.ScheduleSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Schedule instances.
 */
public interface ScheduleService extends ICrudService<Schedule, String, ScheduleSearchCriteria, ScheduleSort> {

    ExchangeService getExchangeService(Schedule schedule);
    
    Schedule runNow(String scheduleId);
    
}

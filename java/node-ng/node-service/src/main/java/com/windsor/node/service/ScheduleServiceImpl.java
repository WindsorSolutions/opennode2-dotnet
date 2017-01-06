package com.windsor.node.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleSourceType;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.domain.search.ScheduleSort;
import com.windsor.node.repo.ExchangeServiceRepository;
import com.windsor.node.repo.ScheduleRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Schedule service.
 */
@Service
@Transactional(readOnly = true)
public class ScheduleServiceImpl extends AbstractCrudService<Schedule, String, ScheduleSearchCriteria, ScheduleSort>
        implements ScheduleService {

    private final static Logger logger = LoggerFactory.getLogger(ScheduleServiceImpl.class);

    @Autowired
    private ScheduleRepository repository;

    @Autowired
    private ExchangeServiceRepository exchangeServiceRepository;

    @Override
    protected ICrudRepository<Schedule, String, ScheduleSearchCriteria, ScheduleSort> getRepo() {
        return repository;
    }

    @Override
    public ExchangeService getExchangeService(Schedule schedule) {
        com.windsor.node.domain.entity.ExchangeService exchangeService = null;

        if(schedule.getSourceType() == ScheduleSourceType.LOCAL_SERVICE && schedule.getDataSource() != null) {
            try {
                exchangeService = exchangeServiceRepository.getOne(schedule.getDataSource());
            } catch(Exception exception) {
                logger.warn("Couldn't load the exchange service " + schedule.getDataSource());
            }
        }

        return exchangeService;
    }

    @Transactional(readOnly = false)
	@Override
	public Schedule runNow(String scheduleId) {
		Schedule schedule = repository.findOne(scheduleId);
		schedule.setRunNow(true);
		return repository.save(schedule);
	}
    
}

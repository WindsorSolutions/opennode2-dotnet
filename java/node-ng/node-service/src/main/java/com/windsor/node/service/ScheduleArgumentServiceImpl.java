package com.windsor.node.service;

import com.windsor.node.domain.entity.ScheduleArgument;
import com.windsor.node.domain.search.ScheduleArgumentSearchCriteria;
import com.windsor.node.domain.search.ScheduleArgumentSort;
import com.windsor.node.repo.ScheduleArgumentRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * Provides an implementation fo the ScheduleArgument service.
 */
@Service
@Transactional(readOnly = true)
public class ScheduleArgumentServiceImpl extends AbstractCrudService<ScheduleArgument, String, ScheduleArgumentSearchCriteria, ScheduleArgumentSort>
        implements ScheduleArgumentService {

    @Autowired
    private ScheduleArgumentRepository repository;

    @Override
    protected ICrudRepository<ScheduleArgument, String, ScheduleArgumentSearchCriteria, ScheduleArgumentSort> getRepo() {
        return repository;
    }
}

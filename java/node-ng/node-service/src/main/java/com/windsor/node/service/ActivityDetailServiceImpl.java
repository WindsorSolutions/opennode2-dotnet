package com.windsor.node.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.ActivityDetail;
import com.windsor.node.domain.search.ActivityDetailSearchCriteria;
import com.windsor.node.domain.search.ActivityDetailSort;
import com.windsor.node.repo.ActivityDetailRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Activity Detail Service.
 */
@Service
@Transactional(readOnly = true)
public class ActivityDetailServiceImpl extends AbstractCrudService<ActivityDetail, String, ActivityDetailSearchCriteria, ActivityDetailSort>
        implements ActivityDetailService {

    @Autowired
    private ActivityDetailRepository repository;

    @Override
    protected ICrudRepository<ActivityDetail, String, ActivityDetailSearchCriteria, ActivityDetailSort> getRepo() {
        return repository;
    }

}

package com.windsor.node.service;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSort;
import com.windsor.node.repo.ArgumentRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * Provides an implementation of the Argument service.
 */
@Service
@Transactional(readOnly = true)
public class ArgumentServiceImpl extends AbstractCrudService<Argument, String, ArgumentSearchCriteria, ArgumentSort>
        implements ArgumentService {

    @Autowired
    private ArgumentRepository repository;

    @Override
    protected ICrudRepository<Argument, String, ArgumentSearchCriteria, ArgumentSort> getRepo() {
        return repository;
    }
}

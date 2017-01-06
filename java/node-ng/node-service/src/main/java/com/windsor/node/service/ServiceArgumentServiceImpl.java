package com.windsor.node.service;

import com.windsor.node.domain.entity.ServiceArgument;
import com.windsor.node.domain.search.ServiceArgumentSearchCriteria;
import com.windsor.node.domain.search.ServiceArgumentSort;
import com.windsor.node.repo.ServiceArgumentRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * Provides an implementation of the ServiceArgument service.
 */
@Service
@Transactional(readOnly = true)
public class ServiceArgumentServiceImpl extends AbstractCrudService<ServiceArgument, String, ServiceArgumentSearchCriteria, ServiceArgumentSort>
        implements ServiceArgumentService {

    @Autowired
    private ServiceArgumentRepository repository;

    @Override
    protected ICrudRepository<ServiceArgument, String, ServiceArgumentSearchCriteria, ServiceArgumentSort> getRepo() {
        return repository;
    }
}

package com.windsor.node.service;

import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.domain.search.ServiceConnectionSearchCriteria;
import com.windsor.node.domain.search.ServiceConnectionSort;
import com.windsor.node.repo.ServiceConnectionRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * Provides an implementation of the ServiceConnectionService.
 */
@Service
@Transactional(readOnly = true)
public class ServiceConnectionServiceImpl extends AbstractCrudService<ServiceConnection, String, ServiceConnectionSearchCriteria, ServiceConnectionSort>
        implements ServiceConnectionService {

    @Autowired
    private ServiceConnectionRepository repository;

    @Override
    protected ICrudRepository<ServiceConnection, String, ServiceConnectionSearchCriteria, ServiceConnectionSort> getRepo() {
        return repository;
    }
}

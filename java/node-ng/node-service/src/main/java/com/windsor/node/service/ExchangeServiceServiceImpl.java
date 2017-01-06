package com.windsor.node.service;

import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSort;
import com.windsor.node.repo.ExchangeServiceRepository;
import com.windsor.node.repo.ServiceConnectionRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;
import com.windsor.node.domain.entity.ExchangeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

/**
 * Provides an implementation of the ExchangeService service.
 */
@Service
@Transactional(readOnly = true)
public class ExchangeServiceServiceImpl extends AbstractCrudService<ExchangeService, String, ExchangeServiceSearchCriteria, ExchangeServiceSort>
        implements ExchangeServiceService {

    @Autowired
    private ExchangeServiceRepository repository;

    @Autowired
    private ServiceConnectionRepository serviceConnectionRepository;

    @Override
    protected ICrudRepository<ExchangeService, String, ExchangeServiceSearchCriteria, ExchangeServiceSort> getRepo() {
        return repository;
    }

    @Override
    @Transactional(readOnly = false)
    public ExchangeService save(ExchangeService service) {

        ExchangeService serviceSaved = repository.save(service);

        if(service.getConnections() != null) {
            for(ServiceConnection connection : service.getConnections()) {
                connection.setService(service);
                serviceConnectionRepository.save(connection);
            }
        }

        return serviceSaved;
    }
}

package com.windsor.node.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSort;
import com.windsor.node.repo.ExchangeRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Exchange Service.
 */
@Service
@Transactional(readOnly = true)
public class ExchangeServiceImpl extends AbstractCrudService<Exchange, String, ExchangeSearchCriteria, ExchangeSort>
        implements ExchangeService {

    @Autowired
    private ExchangeRepository repository;

    @Override
    protected ICrudRepository<Exchange, String, ExchangeSearchCriteria, ExchangeSort> getRepo() {
        return repository;
    }

    @Override
    public boolean isNameUnique(String name, String excludedId) {
        Exchange exchange = repository.findByName(name);
        return exchange == null || exchange.getId().equals(excludedId);
    }

}

package com.windsor.node.repo;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSort;
import com.windsor.stack.domain.repo.ICrudRepository;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Provides a repository for managing ExchangeService instances.
 */
public interface ExchangeServiceRepository extends JpaRepository<ExchangeService, String>,
        ICrudRepository<ExchangeService, String, ExchangeServiceSearchCriteria, ExchangeServiceSort> {

}

package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Exchange instances.
 */
public interface ExchangeRepository extends JpaRepository<Exchange, String>,
        ICrudRepository<Exchange, String, ExchangeSearchCriteria, ExchangeSort> {

    @Query("select e from Exchange e where e.name = ?1")
    Exchange findByName(String name);

}

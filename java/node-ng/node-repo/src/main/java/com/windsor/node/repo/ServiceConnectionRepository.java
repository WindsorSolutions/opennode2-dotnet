package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.domain.search.ServiceConnectionSearchCriteria;
import com.windsor.node.domain.search.ServiceConnectionSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing ServiceConnection instances.
 */
public interface ServiceConnectionRepository extends JpaRepository<ServiceConnection, String>,
        ICrudRepository<ServiceConnection, String, ServiceConnectionSearchCriteria, ServiceConnectionSort> {

}

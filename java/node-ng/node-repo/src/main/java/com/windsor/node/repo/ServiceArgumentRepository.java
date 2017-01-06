package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.ServiceArgument;
import com.windsor.node.domain.search.ServiceArgumentSearchCriteria;
import com.windsor.node.domain.search.ServiceArgumentSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing ServiceArgument instances.
 */
public interface ServiceArgumentRepository extends JpaRepository<ServiceArgument, String>,
        ICrudRepository<ServiceArgument, String, ServiceArgumentSearchCriteria, ServiceArgumentSort> {

}

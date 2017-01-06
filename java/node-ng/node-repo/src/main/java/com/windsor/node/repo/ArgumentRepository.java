package com.windsor.node.repo;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSort;
import com.windsor.stack.domain.repo.ICrudRepository;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Provides a repository for managing global Argument instances.
 */
public interface ArgumentRepository extends JpaRepository<Argument, String>,
        ICrudRepository<Argument, String, ArgumentSearchCriteria, ArgumentSort> {
}

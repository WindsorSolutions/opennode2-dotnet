package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.domain.search.ActivitySort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Activity instances.
 */
public interface ActivityRepository extends JpaRepository<Activity, String>,
        ICrudRepository<Activity, String, ActivitySearchCriteria, ActivitySort>,
        ActivityRepositoryCustom {
	
}

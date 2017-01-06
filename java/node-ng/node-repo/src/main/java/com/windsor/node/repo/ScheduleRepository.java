package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.domain.search.ScheduleSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Schedule instances.
 */
public interface ScheduleRepository extends JpaRepository<Schedule, String>,
        ICrudRepository<Schedule, String, ScheduleSearchCriteria, ScheduleSort> {

}

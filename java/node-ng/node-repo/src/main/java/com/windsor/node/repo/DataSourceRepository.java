package com.windsor.node.repo;

import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSort;
import com.windsor.stack.domain.repo.ICrudRepository;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Provides a repository for managing DataSource instances.
 */
public interface DataSourceRepository extends JpaRepository<DataSource, String>,
        ICrudRepository<DataSource, String, DataSourceSearchCriteria, DataSourceSort> {

}

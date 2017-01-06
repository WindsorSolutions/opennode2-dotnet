package com.windsor.node.service;

import com.windsor.node.domain.DataSourceTestResult;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing DataSource instances.
 */
public interface DataSourceService extends ICrudService<DataSource, String, DataSourceSearchCriteria, DataSourceSort> {

    DataSourceTestResult test(DataSource dataSource);

}

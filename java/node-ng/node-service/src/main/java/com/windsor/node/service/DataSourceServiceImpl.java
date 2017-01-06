package com.windsor.node.service;

import java.sql.DriverManager;
import java.sql.SQLException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.DataSourceTestResult;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSort;
import com.windsor.node.repo.DataSourceRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the DataSource service.
 */
@Service
@Transactional(readOnly = true)
public class DataSourceServiceImpl extends AbstractCrudService<DataSource, String, DataSourceSearchCriteria, DataSourceSort>
        implements DataSourceService {

    private static final Logger LOGGER = LoggerFactory.getLogger(DataSourceServiceImpl.class);

    @Autowired
    private DataSourceRepository repository;

    @Override
    protected ICrudRepository<DataSource, String, DataSourceSearchCriteria, DataSourceSort> getRepo() {
        return repository;
    }

    @Override
    public DataSourceTestResult test(DataSource dataSource) {
        boolean success = false;
        String message = null;
        try {
            Class.forName(dataSource.getProvider().getId());
            DriverManager.getConnection(dataSource.getConnection());
            message = "The data source \"" + dataSource.getName() + "\" was tested succesfully!";
            success = true;
        } catch(ClassNotFoundException exception) {
            message = "The data source \"" + dataSource.getName() + "\" failed, I couldn't find the "
                    + "driver for this data source. The error was \"" + exception.getMessage() + "\"";
        } catch(SQLException exception) {
            message = "The data source \"" + dataSource.getName() + "\" failed, the error was \""
                    + exception.getMessage() + "\"";
        }
        LOGGER.info(message);
        return new DataSourceTestResult(success, message);
    }

}

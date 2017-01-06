package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.DataSourceProvider;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides a data object encapsulating DataSource search criteria.
 */
public class DataSourceSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String PROVIDER = "provider";
    public static final String CONNECTION = "connection";

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = PROVIDER)
    private DataSourceProvider provider;

    @Criteria(name = CONNECTION, operator = CriteriaOperator.CONTAINS_CI)
    private String connection;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public DataSourceSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public DataSourceProvider getProvider() {
        return provider;
    }

    public void setProvider(DataSourceProvider provider) {
        this.provider = provider;
    }

    public String getConnection() {
        return connection;
    }

    public void setConnection(String connection) {
        this.connection = connection;
    }

    public void reset() {
        setName(null);
        setProvider(null);
        setConnection(null);
    }
}

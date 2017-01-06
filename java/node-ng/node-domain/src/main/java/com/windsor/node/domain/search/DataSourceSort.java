package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of DataSource fields that may be sorted.
 */
public enum DataSourceSort implements IEntityRelated {

    ID(EntityAlias.DATA_SOURCE),
    NAME(EntityAlias.DATA_SOURCE),
    PROVIDER(EntityAlias.DATA_SOURCE),
    CONNECTION(EntityAlias.DATA_SOURCE);

    private Object entityAlias;

    DataSourceSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

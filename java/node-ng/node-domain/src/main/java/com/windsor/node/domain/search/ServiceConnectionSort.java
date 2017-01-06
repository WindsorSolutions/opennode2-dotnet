package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of ServiceConnection fields that may be sorted.
 */
public enum ServiceConnectionSort implements IEntityRelated {

    SERVICE(EntityAlias.SERVICE_CONNECTION),
    KEY(EntityAlias.SERVICE_CONNECTION);

    private Object entityAlias;

    ServiceConnectionSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

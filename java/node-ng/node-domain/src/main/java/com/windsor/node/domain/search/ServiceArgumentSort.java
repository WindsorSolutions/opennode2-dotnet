package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of ServiceArgument fields that may be sorted.
 */
public enum ServiceArgumentSort implements IEntityRelated {

    ID(EntityAlias.SERVICE_ARGUMENTS),
    SERVICE(EntityAlias.SERVICE_ARGUMENTS),
    KEY(EntityAlias.SERVICE_ARGUMENTS),
    VALUE(EntityAlias.SERVICE_ARGUMENTS);

    private Object entityAlias;

    ServiceArgumentSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

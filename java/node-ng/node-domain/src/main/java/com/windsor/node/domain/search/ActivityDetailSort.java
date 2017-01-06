package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Activity Detail fields that may be sorted.
 */
public enum ActivityDetailSort implements IEntityRelated {

    ID(EntityAlias.ACTIVITY_DETAIL),
    ORDER(EntityAlias.ACTIVITY_DETAIL),
    DETAIL(EntityAlias.ACTIVITY_DETAIL),
    CREATED_DATE(EntityAlias.ACTIVITY_DETAIL);

    private Object entityAlias;

    ActivityDetailSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

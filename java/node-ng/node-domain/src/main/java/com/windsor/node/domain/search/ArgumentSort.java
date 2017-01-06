package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 *  Provides an enumeration of Argument fields that may be sorted.
 */
public enum ArgumentSort implements IEntityRelated {

    ID(EntityAlias.ARGUMENT),
    NAME(EntityAlias.ARGUMENT),
    VALUE(EntityAlias.ARGUMENT),
    DESCRIPTION(EntityAlias.ARGUMENT),
    EDITABLE(EntityAlias.ARGUMENT);

    private Object entityAlias;

    ArgumentSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

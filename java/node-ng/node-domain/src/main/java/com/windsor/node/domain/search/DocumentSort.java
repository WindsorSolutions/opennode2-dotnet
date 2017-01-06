package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 *  Provides an enumeration of Document fields that may be sorted.
 */
public enum DocumentSort implements IEntityRelated {

    ID(EntityAlias.DOCUMENT),
    NAME(EntityAlias.DOCUMENT);

    private Object entityAlias;

    DocumentSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

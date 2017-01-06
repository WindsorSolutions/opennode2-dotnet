package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Partner fields that may be sorted.
 */
public enum PartnerSort implements IEntityRelated {

    ID(EntityAlias.PARTNER),
    NAME(EntityAlias.PARTNER),
    URL(EntityAlias.PARTNER),
    VERSION(EntityAlias.PARTNER);

    private Object entityAlias;

    PartnerSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Exchange fields that may be sorted.
 */
public enum ExchangeSort implements IEntityRelated {

    ID(EntityAlias.EXCHANGE),
    CONTACT_NAME(EntityAlias.ACCOUNT),
    NAME(EntityAlias.EXCHANGE),
    URL(EntityAlias.EXCHANGE),
    SECURE(EntityAlias.EXCHANGE),
    TARGET_EXCHANGE_NAME(EntityAlias.EXCHANGE),
    DESCRIPTION(EntityAlias.EXCHANGE);

    private Object entityAlias;

    ExchangeSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

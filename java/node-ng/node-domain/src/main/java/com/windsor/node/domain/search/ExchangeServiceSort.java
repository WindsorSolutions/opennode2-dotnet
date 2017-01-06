package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of ExchangeService fields that may be sorted.
 */
public enum ExchangeServiceSort implements IEntityRelated {

    ID(EntityAlias.EXCHANGE_SERVICE),
    NAME(EntityAlias.EXCHANGE_SERVICE),
    EXCHANGE(EntityAlias.EXCHANGE_SERVICE),
    ACTIVE(EntityAlias.EXCHANGE_SERVICE),
    TYPE(EntityAlias.EXCHANGE_SERVICE),
    IMPLEMENTOR(EntityAlias.EXCHANGE_SERVICE),
    SERVICE_AUTHORIZATION_LEVEL(EntityAlias.EXCHANGE_SERVICE),
    SECURE(EntityAlias.EXCHANGE_SERVICE);

    private Object entityAlias;

    ExchangeServiceSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

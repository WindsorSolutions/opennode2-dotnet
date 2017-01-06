package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Account fields that may be sorted.
 */
public enum ActivitySort implements IEntityRelated {

    ID(EntityAlias.ACTIVITY),
    CREATE_DATE(EntityAlias.ACTIVITY),
    IP_ADDRESS(EntityAlias.ACTIVITY),
    TYPE(EntityAlias.ACTIVITY),
    ACCOUNT(EntityAlias.ACCOUNT),
    EXCHANGE(EntityAlias.EXCHANGE),
    OPERATION(EntityAlias.TRANSACTION);

    private Object entityAlias;

    ActivitySort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

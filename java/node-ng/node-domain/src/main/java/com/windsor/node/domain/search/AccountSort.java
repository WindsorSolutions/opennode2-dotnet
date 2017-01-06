package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Account fields that may be sorted.
 */
public enum AccountSort implements IEntityRelated {

    ID(EntityAlias.ACCOUNT),
    NAME(EntityAlias.ACCOUNT),
    ACTIVE(EntityAlias.ACCOUNT),
    SYSTEM_ROLE_TYPE(EntityAlias.ACCOUNT),
    AFFILIATION(EntityAlias.ACCOUNT),
    DELETED(EntityAlias.ACCOUNT),
    DEMO(EntityAlias.ACCOUNT);

    private Object entityAlias;

    AccountSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of AccountPolicy fields that may be sorted.
 */
public enum AccountPolicySort implements IEntityRelated {

    ID(EntityAlias.ACCOUNT_POLICY),
    ACCOUNT_NAME(EntityAlias.ACCOUNT),
    EXCHANGE_NAME(EntityAlias.EXCHANGE);

    private Object entityAlias;

    AccountPolicySort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

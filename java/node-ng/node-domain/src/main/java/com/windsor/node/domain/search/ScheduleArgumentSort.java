package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of ScheduleArgument fields that may be sorted.
 */
public enum ScheduleArgumentSort implements IEntityRelated {

    ID(EntityAlias.SCHEDULE_ARGUMENT),
    SCHEDULE(EntityAlias.SCHEDULE_ARGUMENT),
    KEY(EntityAlias.SCHEDULE_ARGUMENT),
    VALUE(EntityAlias.SCHEDULE_ARGUMENT);

    private Object entityAlias;

    ScheduleArgumentSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

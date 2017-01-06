package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enumeration of Schedule fields that may be sorted.
 */
public enum ScheduleSort implements IEntityRelated {

    ID(EntityAlias.SCHEDULE),
    NAME(EntityAlias.SCHEDULE),
    EXCHANGE(EntityAlias.SCHEDULE),
    SERVICE_SOURCE(EntityAlias.SCHEDULE),
    SERVICE_TARGET(EntityAlias.SCHEDULE),
    START(EntityAlias.SCHEDULE),
    END(EntityAlias.SCHEDULE),
    NEXT_START(EntityAlias.SCHEDULE),
    SOURCE_TYPE(EntityAlias.SCHEDULE),
    TARGET_TYPE(EntityAlias.SCHEDULE),
    LAST_EXECUTION_INFO(EntityAlias.SCHEDULE),
    LAST_EXECUTION(EntityAlias.SCHEDULE),
    SOURCE_OPERATION(EntityAlias.SCHEDULE),
    TARGET_OPERATION(EntityAlias.SCHEDULE),
    FREQUENCY_TYPE(EntityAlias.SCHEDULE),
    FREQUENCY(EntityAlias.SCHEDULE);

    private Object entityAlias;

    ScheduleSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}

package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.Schedule;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides a data object encapsulating ScheduleArgument related search criteria.
 */
public class ScheduleArgumentSearchCriteria implements Serializable {

    public static final String SCHEDULE = "schedule";

    @Criteria(name = SCHEDULE, operator = CriteriaOperator.EQUAL)
    private Schedule schedule;

    public ScheduleArgumentSearchCriteria() {
        super();
        reset();
    }

    public Schedule getSchedule() {
        return schedule;
    }

    public void setSchedule(Schedule schedule) {
        this.schedule = schedule;
    }

    public ScheduleArgumentSearchCriteria schedule(Schedule schedule) {
        setSchedule(schedule);
        return this;
    }

    public void reset() {
        setSchedule(null);
    }
}

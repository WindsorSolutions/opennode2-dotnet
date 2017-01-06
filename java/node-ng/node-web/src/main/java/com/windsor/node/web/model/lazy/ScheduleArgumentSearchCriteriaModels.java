package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleArgument;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for ScheduleArgumentSearchCriteria instances.
 */
public class ScheduleArgumentSearchCriteriaModels {

    public static final LazyModel<Schedule> SCHEDULE = model(from(ScheduleArgument.class).getSchedule());

    private ScheduleArgumentSearchCriteriaModels() {

    }
}

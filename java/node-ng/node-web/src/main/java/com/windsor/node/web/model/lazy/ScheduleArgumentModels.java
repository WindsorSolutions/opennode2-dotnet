package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleArgument;

/**
 * Provides lazy models for the ScheduleArgument object.
 */
public final class ScheduleArgumentModels {

    public static final LazyModel<String> ID = model(from(ScheduleArgument.class).getId());
    public static final LazyModel<Schedule> SCHEDULE = model(from(ScheduleArgument.class).getSchedule());
    public static final LazyModel<String> KEY = model(from(ScheduleArgument.class).getKey());
    public static final LazyModel<String> VALUE = model(from(ScheduleArgument.class).getValue());

    private ScheduleArgumentModels() {

    }

    public static IModel<String> bindId(IModel<ScheduleArgument> model) {
        return ID.bind(model);
    }

    public static IModel<Schedule> bindSchedule(IModel<ScheduleArgument> model) {
        return SCHEDULE.bind(model);
    }

    public static IModel<String> bindKey(IModel<ScheduleArgument> model) {
        return KEY.bind(model);
    }

    public static IModel<String> bindValue(IModel<ScheduleArgument> model) {
        return VALUE.bind(model);
    }

}

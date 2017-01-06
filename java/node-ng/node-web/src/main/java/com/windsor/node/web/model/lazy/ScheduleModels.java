package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;
import java.util.List;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleArgument;
import com.windsor.node.domain.entity.ScheduleExecuteStatus;
import com.windsor.node.domain.entity.ScheduleFrequencyType;
import com.windsor.node.domain.entity.ScheduleSourceType;
import com.windsor.node.domain.entity.ScheduleTargetType;

/**
 * Provides lazy models for the Schedule object.
 */
public final class ScheduleModels {

    public static final LazyModel<String> ID = model(from(Schedule.class).getId());
    public static final LazyModel<String> NAME = model(from(Schedule.class).getName());
    public static final LazyModel<Exchange> EXCHANGE = model(from(Schedule.class).getExchange());
    public static final LazyModel<String> SERVICE_SOURCE = model(from(Schedule.class).getDataSource());
    public static final LazyModel<String> SERVICE_TARGET = model(from(Schedule.class).getDataTarget());
    public static final LazyModel<LocalDateTime> START = model(from(Schedule.class).getStart());
    public static final LazyModel<LocalDateTime> END = model(from(Schedule.class).getEnd());
    public static final LazyModel<LocalDateTime> NEXT_START = model(from(Schedule.class).getNextStart());
    public static final LazyModel<ScheduleSourceType> SOURCE_TYPE = model(from(Schedule.class).getSourceType());
    public static final LazyModel<ScheduleTargetType> TARGET_TYPE = model(from(Schedule.class).getTargetType());
    public static final LazyModel<String> LAST_EXECUTION_INFO = model(from(Schedule.class).getLastExecutionInfo());
    public static final LazyModel<LocalDateTime> LAST_EXECUTION = model(from(Schedule.class).getLastExecution());
    public static final LazyModel<String> SOURCE_OPERATION = model(from(Schedule.class).getSourceOperation());
    public static final LazyModel<String> TARGET_OPERATION = model(from(Schedule.class).getTargetOperation());
    public static final LazyModel<ScheduleFrequencyType> FREQUENCY_TYPE = model(from(Schedule.class).getScheduleFrequencyType());
    public static final LazyModel<Integer> FREQUENCY = model(from(Schedule.class).getFrequency());
    public static final LazyModel<Boolean> ACTIVE = model(from(Schedule.class).getActive());
    public static final LazyModel<Boolean> RUN_NOW = model(from(Schedule.class).getRunNow());
    public static final LazyModel<ScheduleExecuteStatus> EXECUTION_STATUS = model(from(Schedule.class).getScheduleExecuteStatus());
    public static final LazyModel<List<ScheduleArgument>> ARGUMENTS = model(from(Schedule.class).getArguments());
    public static final LazyModel<Activity> ACTIVITY = model(from(Schedule.class).getActivity());
    public static final LazyModel<Boolean> IS_TRANSACTION_ASSOCIATED = model(from(Schedule.class).isTransactionAssociated());

    public ScheduleModels() {

    }

    public static IModel<String> bindId(IModel<Schedule> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindName(IModel<Schedule> model) {
        return NAME.bind(model);
    }

    public static IModel<Exchange> bindExchange(IModel<Schedule> model) {
        return EXCHANGE.bind(model);
    }

    public static IModel<LocalDateTime> bindStart(IModel<Schedule> model) {
        return START.bind(model);
    }

    public static IModel<LocalDateTime> bindEnd(IModel<Schedule> model) {
        return END.bind(model);
    }

    public static IModel<ScheduleSourceType> bindSourceType(IModel<Schedule> model) {
        return SOURCE_TYPE.bind(model);
    }

    public static IModel<String> bindLastExecutionInfo(IModel<Schedule> model) {
        return LAST_EXECUTION_INFO.bind(model);
    }

    public static IModel<LocalDateTime> bindLastExecution(IModel<Schedule> model) {
        return LAST_EXECUTION.bind(model);
    }

    public static IModel<List<ScheduleArgument>> bindArguments(IModel<Schedule> model) {
        return ARGUMENTS.bind(model);
    }

    public static IModel<String> bindServiceSource(IModel<Schedule> model) {
        return SERVICE_SOURCE.bind(model);
    }

    public static IModel<String> bindServiceTarget(IModel<Schedule> model) {
        return SERVICE_TARGET.bind(model);
    }

    public static IModel<LocalDateTime> bindNextStart(IModel<Schedule> model) {
        return NEXT_START.bind(model);
    }

    public static IModel<ScheduleTargetType> bindTargetType(IModel<Schedule> model) {
        return TARGET_TYPE.bind(model);
    }

    public static IModel<String> bindSourceOperation(IModel<Schedule> model) {
        return SOURCE_OPERATION.bind(model);
    }

    public static IModel<String> bindTargetOperation(IModel<Schedule> model) {
        return TARGET_OPERATION.bind(model);
    }

    public static IModel<ScheduleFrequencyType> bindFrequencyType(IModel<Schedule> model) {
        return FREQUENCY_TYPE.bind(model);
    }

    public static IModel<Integer> bindFrequency(IModel<Schedule> model) {
        return FREQUENCY.bind(model);
    }

    public static IModel<Boolean> bindActive(IModel<Schedule> model) {
        return ACTIVE.bind(model);
    }

    public static IModel<Boolean> bindRunNow(IModel<Boolean> model) {
        return RUN_NOW.bind(model);
    }

    public static IModel<ScheduleExecuteStatus> bindExecutionStatus(IModel<ScheduleExecuteStatus> model) {
        return EXECUTION_STATUS.bind(model);
    }

    public static IModel<Activity> bindActivity(IModel<Schedule> model) {
        return ACTIVITY.bind(model);
    }

    public static IModel<Boolean> bindIsTransactionAssociated(IModel<Schedule> model) {
        return IS_TRANSACTION_ASSOCIATED.bind(model);
    }

}

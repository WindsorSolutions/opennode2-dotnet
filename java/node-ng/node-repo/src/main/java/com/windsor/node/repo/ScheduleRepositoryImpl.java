package com.windsor.node.repo;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.domain.search.ScheduleSort;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the Schedule repository.
 */
public class ScheduleRepositoryImpl extends AbstractQuerydslFinderRepository<Schedule, ScheduleSearchCriteria, ScheduleSort>
        implements IFinderRepository<Schedule, ScheduleSearchCriteria, ScheduleSort> {

    public static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.SCHEDULE, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.EXCHANGE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.SCHEDULE.exchange, QueryObjects.EXCHANGE)))
                    .build();

    public static final Map<ScheduleSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ScheduleSort, Path<? extends Comparable<?>>> builder()
                    .put(ScheduleSort.ID, QueryObjects.SCHEDULE.id)
                    .put(ScheduleSort.NAME, QueryObjects.SCHEDULE.name)
                    .put(ScheduleSort.EXCHANGE, QueryObjects.SCHEDULE.exchange.name)
                    .put(ScheduleSort.START, QueryObjects.SCHEDULE.start)
                    .put(ScheduleSort.END, QueryObjects.SCHEDULE.end)
                    .put(ScheduleSort.SOURCE_TYPE, QueryObjects.SCHEDULE.sourceType)
                    .put(ScheduleSort.TARGET_TYPE, QueryObjects.SCHEDULE.targetType)
                    .put(ScheduleSort.LAST_EXECUTION_INFO, QueryObjects.SCHEDULE.lastExecutionInfo)
                    .put(ScheduleSort.LAST_EXECUTION, QueryObjects.SCHEDULE.lastExecution)
                    .put(ScheduleSort.SOURCE_OPERATION, QueryObjects.SCHEDULE.sourceOperation)
                    .put(ScheduleSort.TARGET_OPERATION, QueryObjects.SCHEDULE.targetOperation)
                    .put(ScheduleSort.FREQUENCY_TYPE, QueryObjects.SCHEDULE.scheduleFrequencyType)
                    .put(ScheduleSort.FREQUENCY, QueryObjects.SCHEDULE.frequency)
                    .build();

    public static final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ScheduleSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.SCHEDULE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SCHEDULE.name))))
                    .put(ScheduleSearchCriteria.EXCHANGE, new CriteriaHandler<>(EntityAlias.SCHEDULE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SCHEDULE.exchange))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ScheduleSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Schedule> getFrom() {
        return QueryObjects.SCHEDULE;
    }
}

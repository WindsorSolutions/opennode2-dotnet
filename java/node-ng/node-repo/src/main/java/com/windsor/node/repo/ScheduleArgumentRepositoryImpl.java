package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.ScheduleArgument;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.ScheduleArgumentSearchCriteria;
import com.windsor.node.domain.search.ScheduleArgumentSort;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

/**
 * Provides an implementation of the ScheduleArgument repository.
 */
public class ScheduleArgumentRepositoryImpl extends AbstractQuerydslFinderRepository<ScheduleArgument, ScheduleArgumentSearchCriteria, ScheduleArgumentSort>
        implements IFinderRepository<ScheduleArgument, ScheduleArgumentSearchCriteria, ScheduleArgumentSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.SCHEDULE_ARGUMENT, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.SCHEDULE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.SCHEDULE_ARGUMENT.schedule, QueryObjects.SCHEDULE)))
                    .build();

    public static final Map<ScheduleArgumentSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ScheduleArgumentSort, Path<? extends Comparable<?>>> builder()
                    .put(ScheduleArgumentSort.ID, QueryObjects.SCHEDULE_ARGUMENT.id)
                    .put(ScheduleArgumentSort.SCHEDULE, QueryObjects.SCHEDULE_ARGUMENT.schedule.name)
                    .put(ScheduleArgumentSort.KEY, QueryObjects.SCHEDULE_ARGUMENT.key)
                    .put(ScheduleArgumentSort.VALUE, QueryObjects.SCHEDULE_ARGUMENT.value)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ScheduleArgumentSearchCriteria.SCHEDULE, new CriteriaHandler<>(EntityAlias.SCHEDULE_ARGUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SCHEDULE_ARGUMENT.schedule))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ScheduleArgumentSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<ScheduleArgument> getFrom() {
        return QueryObjects.SCHEDULE_ARGUMENT;
    }
}

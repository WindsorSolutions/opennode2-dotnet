package com.windsor.node.repo;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.ActivityDetail;
import com.windsor.node.domain.search.ActivityDetailSearchCriteria;
import com.windsor.node.domain.search.ActivityDetailSort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the Activity Detail repository.
 */
public class ActivityDetailRepositoryImpl extends AbstractQuerydslFinderRepository<ActivityDetail, ActivityDetailSearchCriteria, ActivityDetailSort>
        implements IFinderRepository<ActivityDetail, ActivityDetailSearchCriteria, ActivityDetailSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                .put(EntityAlias.ACTIVITY_DETAIL, Collections.<QuerydslJoinInfo> emptyList())
                .build();

    public static final Map<ActivityDetailSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ActivityDetailSort, Path<? extends Comparable<?>>> builder()
                    .put(ActivityDetailSort.ID, QueryObjects.ACTIVITY_DETAIL.id)
                    .put(ActivityDetailSort.CREATED_DATE, QueryObjects.ACTIVITY_DETAIL.modifiedOn)
                    .put(ActivityDetailSort.DETAIL, QueryObjects.ACTIVITY_DETAIL.detail)
                    .put(ActivityDetailSort.ORDER, QueryObjects.ACTIVITY_DETAIL.order)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ActivityDetailSearchCriteria.ACTIVITY_ID, new CriteriaHandler<>(EntityAlias.ACTIVITY_DETAIL,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY_DETAIL.activity.id))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ActivityDetailSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<ActivityDetail> getFrom() {
        return QueryObjects.ACTIVITY_DETAIL;
    }

}

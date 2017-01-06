package com.windsor.node.repo;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.ServiceArgument;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.ServiceArgumentSearchCriteria;
import com.windsor.node.domain.search.ServiceArgumentSort;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the ServiceArgument repository.
 */
public class ServiceArgumentRepositoryImpl extends AbstractQuerydslFinderRepository<ServiceArgument, ServiceArgumentSearchCriteria, ServiceArgumentSort>
        implements IFinderRepository<ServiceArgument, ServiceArgumentSearchCriteria, ServiceArgumentSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.SERVICE_ARGUMENTS, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.EXCHANGE_SERVICE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.SERVICE_ARGUMENT.service, QueryObjects.EXCHANGE_SERVICE)))
                    .build();

    public static final Map<ServiceArgumentSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ServiceArgumentSort, Path<? extends Comparable<?>>> builder()
                    .put(ServiceArgumentSort.ID, QueryObjects.SERVICE_ARGUMENT.id)
                    .put(ServiceArgumentSort.SERVICE, QueryObjects.SERVICE_ARGUMENT.service.name)
                    .put(ServiceArgumentSort.KEY, QueryObjects.SERVICE_ARGUMENT.key)
                    .put(ServiceArgumentSort.VALUE, QueryObjects.SERVICE_ARGUMENT.value)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ServiceArgumentSearchCriteria.ID, new CriteriaHandler<>(EntityAlias.SERVICE_ARGUMENTS,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_ARGUMENT.id))))
                    .put(ServiceArgumentSearchCriteria.KEY, new CriteriaHandler<>(EntityAlias.SERVICE_ARGUMENTS,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_ARGUMENT.key))))
                    .put(ServiceArgumentSearchCriteria.VALUE, new CriteriaHandler<>(EntityAlias.SERVICE_ARGUMENTS,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_ARGUMENT.value))))
                    .put(ServiceArgumentSearchCriteria.EXCHANGE_SERVICE, new CriteriaHandler<>(EntityAlias.SERVICE_ARGUMENTS,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_ARGUMENT.service))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ServiceArgumentSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<ServiceArgument> getFrom() {
        return QueryObjects.SERVICE_ARGUMENT;
    }
}

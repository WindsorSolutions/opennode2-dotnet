package com.windsor.node.repo;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.ServiceConnectionSearchCriteria;
import com.windsor.node.domain.search.ServiceConnectionSort;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the ServiceConnection repository.
 */
public class ServiceConnectionRepositoryImpl extends AbstractQuerydslFinderRepository<ServiceConnection, ServiceConnectionSearchCriteria, ServiceConnectionSort>
        implements IFinderRepository<ServiceConnection, ServiceConnectionSearchCriteria, ServiceConnectionSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.SERVICE_CONNECTION, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.DATA_SOURCE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.SERVICE_CONNECTION.dataSource, QueryObjects.DATA_SOURCE)))
                    .put(EntityAlias.EXCHANGE_SERVICE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.SERVICE_CONNECTION.service, QueryObjects.EXCHANGE_SERVICE)))
                    .build();

    public static final Map<ServiceConnectionSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ServiceConnectionSort, Path<? extends Comparable<?>>> builder()
                    .put(ServiceConnectionSort.SERVICE, QueryObjects.SERVICE_CONNECTION.service.name)
                    .put(ServiceConnectionSort.KEY, QueryObjects.SERVICE_CONNECTION.key)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ServiceConnectionSearchCriteria.SERVICE, new CriteriaHandler<>(EntityAlias.SERVICE_CONNECTION,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_CONNECTION.service))))
                    .put(ServiceConnectionSearchCriteria.KEY, new CriteriaHandler<>(EntityAlias.SERVICE_CONNECTION,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.SERVICE_CONNECTION.key))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ServiceConnectionSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<ServiceConnection> getFrom() {
        return QueryObjects.SERVICE_CONNECTION;
    }
}

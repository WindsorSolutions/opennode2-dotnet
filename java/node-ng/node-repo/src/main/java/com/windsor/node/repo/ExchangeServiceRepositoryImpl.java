package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSort;
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
 * Provides an implementation of the ExchangeService repository.
 */
public class ExchangeServiceRepositoryImpl extends AbstractQuerydslFinderRepository<ExchangeService, ExchangeServiceSearchCriteria, ExchangeServiceSort>
        implements IFinderRepository<ExchangeService, ExchangeServiceSearchCriteria, ExchangeServiceSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.EXCHANGE_SERVICE, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.EXCHANGE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.EXCHANGE_SERVICE.exchange, QueryObjects.EXCHANGE)))
                    .put(EntityAlias.SERVICE_ARGUMENTS, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.EXCHANGE_SERVICE.arguments, QueryObjects.SERVICE_ARGUMENT)))
                    .build();

    public static final Map<ExchangeServiceSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ExchangeServiceSort, Path<? extends Comparable<?>>> builder()
                    .put(ExchangeServiceSort.ID, QueryObjects.EXCHANGE_SERVICE.id)
                    .put(ExchangeServiceSort.NAME, QueryObjects.EXCHANGE_SERVICE.name)
                    .put(ExchangeServiceSort.EXCHANGE, QueryObjects.EXCHANGE_SERVICE.exchange.name)
                    .put(ExchangeServiceSort.TYPE, QueryObjects.EXCHANGE_SERVICE.type)
                    .put(ExchangeServiceSort.IMPLEMENTOR, QueryObjects.EXCHANGE_SERVICE.implementor)
                    .put(ExchangeServiceSort.SERVICE_AUTHORIZATION_LEVEL, QueryObjects.EXCHANGE_SERVICE.authorization)
                    .put(ExchangeServiceSort.ACTIVE, QueryObjects.EXCHANGE_SERVICE.active)
                    .put(ExchangeServiceSort.SECURE, QueryObjects.EXCHANGE_SERVICE.secure)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ExchangeServiceSearchCriteria.ACTIVE, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.active))))
                    .put(ExchangeServiceSearchCriteria.AUTHORIZATION, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.authorization))))
                    .put(ExchangeServiceSearchCriteria.EXCHANGE_ID, new CriteriaHandler<>(EntityAlias.EXCHANGE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE.id))))
                    .put(ExchangeServiceSearchCriteria.IMPLEMENTOR, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.implementor))))
                    .put(ExchangeServiceSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.name))))
                    .put(ExchangeServiceSearchCriteria.SECURE, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.secure))))
                    .put(ExchangeServiceSearchCriteria.TYPE, new CriteriaHandler<>(EntityAlias.EXCHANGE_SERVICE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.EXCHANGE_SERVICE.type))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ExchangeServiceSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<ExchangeService> getFrom() {
        return QueryObjects.EXCHANGE_SERVICE;
    }
}

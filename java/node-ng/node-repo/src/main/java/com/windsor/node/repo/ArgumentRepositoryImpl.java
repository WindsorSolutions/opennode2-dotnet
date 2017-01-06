package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

import java.util.Collections;
import java.util.List;
import java.util.Map;

/**
 * Provides an implementation of the Argument repository.
 */
public class ArgumentRepositoryImpl extends AbstractQuerydslFinderRepository<Argument, ArgumentSearchCriteria, ArgumentSort>
        implements IFinderRepository<Argument, ArgumentSearchCriteria, ArgumentSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                .put(EntityAlias.ARGUMENT, Collections.<QuerydslJoinInfo> emptyList()).build();

    public static final Map<ArgumentSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ArgumentSort, Path<? extends Comparable<?>>> builder()
                    .put(ArgumentSort.ID, QueryObjects.ARGUMENT.id)
                    .put(ArgumentSort.NAME, QueryObjects.ARGUMENT.name)
                    .put(ArgumentSort.VALUE, QueryObjects.ARGUMENT.value)
                    .put(ArgumentSort.EDITABLE, QueryObjects.ARGUMENT.editable)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(ArgumentSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.ARGUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ARGUMENT.name))))
                    .put(ArgumentSearchCriteria.VALUE, new CriteriaHandler<>(EntityAlias.ARGUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ARGUMENT.value))))
                    .put(ArgumentSearchCriteria.DESCRIPTION, new CriteriaHandler<>(EntityAlias.ARGUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ARGUMENT.description))))
                    .put(ArgumentSearchCriteria.EDITABLE, new CriteriaHandler<>(EntityAlias.ARGUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ARGUMENT.editable))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ArgumentSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Argument> getFrom() {
        return QueryObjects.ARGUMENT;
    }
}

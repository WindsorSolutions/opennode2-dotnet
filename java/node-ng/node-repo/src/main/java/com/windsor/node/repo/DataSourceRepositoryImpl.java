package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSort;
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
 * Provides an implementation of the DataSource repository.
 */
public class DataSourceRepositoryImpl extends AbstractQuerydslFinderRepository<DataSource, DataSourceSearchCriteria, DataSourceSort>
        implements IFinderRepository<DataSource, DataSourceSearchCriteria, DataSourceSort> {

    public static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.DATA_SOURCE, Collections.<QuerydslJoinInfo> emptyList()).build();

    public static final Map<DataSourceSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<DataSourceSort, Path<? extends Comparable<?>>> builder()
                    .put(DataSourceSort.ID, QueryObjects.DATA_SOURCE.id)
                    .put(DataSourceSort.NAME, QueryObjects.DATA_SOURCE.name)
                    .put(DataSourceSort.PROVIDER, QueryObjects.DATA_SOURCE.provider)
                    .put(DataSourceSort.CONNECTION, QueryObjects.DATA_SOURCE.connection)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(DataSourceSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.DATA_SOURCE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.DATA_SOURCE.name))))
                    .put(DataSourceSearchCriteria.PROVIDER, new CriteriaHandler<>(EntityAlias.DATA_SOURCE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.DATA_SOURCE.provider))))
                    .put(DataSourceSearchCriteria.CONNECTION, new CriteriaHandler<>(EntityAlias.DATA_SOURCE,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.DATA_SOURCE.connection))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<DataSourceSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<DataSource> getFrom() {
        return QueryObjects.DATA_SOURCE;
    }
}

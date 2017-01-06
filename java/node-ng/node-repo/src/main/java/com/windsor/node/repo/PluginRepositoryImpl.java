package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Plugin;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.PluginSearchCriteria;
import com.windsor.node.domain.search.PluginSort;
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
 * Provides an implementation of the Plugin repository.
 */
public class PluginRepositoryImpl extends AbstractQuerydslFinderRepository<Plugin, PluginSearchCriteria, PluginSort>
        implements IFinderRepository<Plugin, PluginSearchCriteria, PluginSort> {

    public static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
        ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                .put(EntityAlias.PLUGIN, Collections.<QuerydslJoinInfo> emptyList()).build();

    public static final Map<PluginSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<PluginSort, Path<? extends Comparable<?>>> builder()
                    .put(PluginSort.ID, QueryObjects.PLUGIN.id)
                    .put(PluginSort.EXCHANGE, QueryObjects.PLUGIN.exchange.name)
                    .put(PluginSort.VERSION, QueryObjects.PLUGIN.version)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(PluginSearchCriteria.EXCHANGE, new CriteriaHandler<>(EntityAlias.PLUGIN,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.PLUGIN.exchange))))
                    .put(PluginSearchCriteria.VERSION, new CriteriaHandler<>(EntityAlias.PLUGIN,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.PLUGIN.version))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<PluginSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Plugin> getFrom() {
        return QueryObjects.PLUGIN;
    }
}

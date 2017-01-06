package com.windsor.node.repo;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSort;
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
 * Provides an implementation of the Partner repository.
 */
public class PartnerRepositoryImpl extends AbstractQuerydslFinderRepository<Partner, PartnerSearchCriteria, PartnerSort>
        implements IFinderRepository<Partner, PartnerSearchCriteria, PartnerSort> {

    public static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.PARTNER, Collections.<QuerydslJoinInfo> emptyList()).build();

    public static final Map<PartnerSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<PartnerSort, Path<? extends Comparable<?>>> builder()
                    .put(PartnerSort.ID, QueryObjects.PARTNER.id)
                    .put(PartnerSort.NAME, QueryObjects.PARTNER.name)
                    .put(PartnerSort.URL, QueryObjects.PARTNER.url)
                    .put(PartnerSort.VERSION, QueryObjects.PARTNER.version)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(PartnerSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.PARTNER,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.PARTNER.name))))
                    .put(PartnerSearchCriteria.URL, new CriteriaHandler<>(EntityAlias.PARTNER,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.PARTNER.url))))
                    .put(PartnerSearchCriteria.VERSION, new CriteriaHandler<>(EntityAlias.PARTNER,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.PARTNER.version))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<PartnerSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Partner> getFrom() {
        return QueryObjects.PARTNER;
    }
}

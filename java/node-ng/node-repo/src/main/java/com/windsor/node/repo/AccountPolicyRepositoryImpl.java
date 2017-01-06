package com.windsor.node.repo;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.search.AccountPolicySearchCriteria;
import com.windsor.node.domain.search.AccountPolicySort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the AccountPolicy Repository.
 */
public class AccountPolicyRepositoryImpl extends AbstractQuerydslFinderRepository<AccountPolicy, AccountPolicySearchCriteria, AccountPolicySort>
        implements IFinderRepository<AccountPolicy, AccountPolicySearchCriteria, AccountPolicySort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.ACCOUNT_POLICY, Collections.<QuerydslJoinInfo> emptyList())
                    .put(EntityAlias.ACCOUNT, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.ACCOUNT_POLICY.account, QueryObjects.ACCOUNT)))
                    .put(EntityAlias.EXCHANGE, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.ACCOUNT_POLICY.exchange, QueryObjects.EXCHANGE)))
                    .build();

    public static final Map<AccountPolicySort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<AccountPolicySort, Path<? extends Comparable<?>>> builder()
                    .put(AccountPolicySort.ID, QueryObjects.ACCOUNT_POLICY.id)
                    .put(AccountPolicySort.ACCOUNT_NAME, QueryObjects.ACCOUNT.naasAccount)
                    .put(AccountPolicySort.EXCHANGE_NAME, QueryObjects.EXCHANGE.name)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(AccountPolicySearchCriteria.ACCOUNT_ID, new CriteriaHandler<>(EntityAlias.ACCOUNT_POLICY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT_POLICY.account.id))))
                    .put(AccountPolicySearchCriteria.EXCHANGE_ID, new CriteriaHandler<>(EntityAlias.ACCOUNT_POLICY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT_POLICY.exchange.id))))
                    .build();

    @Override
    protected EntityPath<AccountPolicy> getFrom() {
        return QueryObjects.ACCOUNT_POLICY;
    }

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<AccountPolicySort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }
}

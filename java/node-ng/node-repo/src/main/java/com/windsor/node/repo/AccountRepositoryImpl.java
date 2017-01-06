package com.windsor.node.repo;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the Account Repository.
 */
public class AccountRepositoryImpl extends AbstractQuerydslFinderRepository<Account, AccountSearchCriteria, AccountSort>
        implements IFinderRepository<Account, AccountSearchCriteria, AccountSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                    .put(EntityAlias.ACCOUNT, Collections.<QuerydslJoinInfo> emptyList()).build();

    public static final Map<AccountSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<AccountSort, Path<? extends Comparable<?>>> builder()
                    .put(AccountSort.ID, QueryObjects.ACCOUNT.id)
                    .put(AccountSort.ACTIVE, QueryObjects.ACCOUNT.active)
                    .put(AccountSort.NAME, QueryObjects.ACCOUNT.naasAccount)
                    .put(AccountSort.SYSTEM_ROLE_TYPE, QueryObjects.ACCOUNT.systemRoleType)
                    .put(AccountSort.AFFILIATION, QueryObjects.ACCOUNT.affiliation)
                    .put(AccountSort.DELETED, QueryObjects.ACCOUNT.deleted)
                    .put(AccountSort.DEMO, QueryObjects.ACCOUNT.demoUser)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(AccountSearchCriteria.ACTIVE, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.active))))
                    .put(AccountSearchCriteria.NAME, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.naasAccount))))
                    .put(AccountSearchCriteria.SYSTEM_ROLE_TYPES, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.systemRoleType))))
                    .put(AccountSearchCriteria.AFFILIATION, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.affiliation))))
                    .put(AccountSearchCriteria.DELETED, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.deleted))))
                    .put(AccountSearchCriteria.DEMO_USER, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.demoUser))))
                    .put(AccountSearchCriteria.LOCAL_ONLY, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QueryObjects.ACCOUNT.systemRoleType.in(SystemRoleType.LOCAL_ROLES))))
                    .put(AccountSearchCriteria.NON_DELETED, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QueryObjects.ACCOUNT.deleted.eq(false)
                                    .or(QueryObjects.ACCOUNT.deleted.isNull()))))
                    .build();

    @Override
    protected EntityPath<Account> getFrom() {
        return QueryObjects.ACCOUNT;
    }

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<AccountSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }
}

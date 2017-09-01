package com.windsor.node.repo;

import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;
import java.util.stream.Stream;

import javax.persistence.TypedQuery;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.jpa.JPASubQuery;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.LoginInfo;
import com.windsor.node.domain.NaasSyncInfo;
import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.domain.search.ActivitySort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaField;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the Activity repository.
 */
public class ActivityRepositoryImpl extends AbstractQuerydslFinderRepository<Activity, ActivitySearchCriteria, ActivitySort>
        implements IFinderRepository<Activity, ActivitySearchCriteria, ActivitySort>, ActivityRepositoryCustom {

    private static final String LAST_NAAS_SYNC_ACTIVITY_QUERY = "select activity.id, activity.modifiedOn, details.id "
            + "from Activity activity "
            + "left join activity.details details with details.detail like 'Adding NAAS users that do not exist in local Db...' "
            + "where activity.id in ( "
            + "select activityDetail.activity.id "
            + "from ActivityDetail activityDetail "
            + "where activityDetail.detail = 'Getting NAAS Users...') "
            + "order by activity.modifiedOn desc";

    private static final String BASE_LOGIN_QUERY =
            "select activity.id, activity.modifiedOn, ad1.detail, ad2.detail "
                    + "from Activity activity "
                    + "inner join activity.details ad1 "
                    + "inner join activity.details ad2 "
                    + "where activity.type in ('AdminAuth', 'Error') ";
    private static final String LOGIN_QUERY_NO_EMAIL = " and ad1.detail like 'Authentication attempt by:%' ";
    private static final String LOGIN_QUERY_WITH_EMAIL = " and ad1.detail = :detail ";
    private static final String SUCCESSFUL_CLAUSE = "ad2.detail like 'Result: %'";
    private static final String UNSUCCESSFUL_CLAUSE = "ad2.detail like 'Error while authenticating:%'";
    private static final String LOGIN_QUERY_ORDER_BY = " order by activity.modifiedOn desc";

    private static String createLoginActivityQuery(String emailAddress, Boolean successful) {
        return BASE_LOGIN_QUERY
                + (emailAddress == null ? LOGIN_QUERY_NO_EMAIL : String.format(LOGIN_QUERY_WITH_EMAIL, emailAddress))
                + " and " + (successful == null ? String.format("(%s or %s) ", SUCCESSFUL_CLAUSE, UNSUCCESSFUL_CLAUSE) : successful ? SUCCESSFUL_CLAUSE : UNSUCCESSFUL_CLAUSE)
                + LOGIN_QUERY_ORDER_BY;
    }

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>>builder()
                    .put(EntityAlias.ACTIVITY, Collections.<QuerydslJoinInfo>emptyList())
                    .put(EntityAlias.ACCOUNT, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.ACTIVITY.modifiedBy, QueryObjects.ACCOUNT)))
                    .put(EntityAlias.TRANSACTION, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.ACTIVITY.transaction, QueryObjects.TRANSACTION)))
                    .put(EntityAlias.ACTIVITY_DETAIL, Arrays.asList(
                            new QuerydslJoinInfo(QueryObjects.ACTIVITY.details, QueryObjects.ACTIVITY_DETAIL)))
                    .build();

    public static final Map<ActivitySort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<ActivitySort, Path<? extends Comparable<?>>>builder()
                    .put(ActivitySort.ID, QueryObjects.ACTIVITY.id)
                    .put(ActivitySort.CREATE_DATE, QueryObjects.ACTIVITY.modifiedOn)
                    .put(ActivitySort.ACCOUNT, QueryObjects.ACCOUNT.naasAccount)
                    .put(ActivitySort.IP_ADDRESS, QueryObjects.ACTIVITY.ipAddress)
                    .put(ActivitySort.TYPE, QueryObjects.ACTIVITY.type)
                    .put(ActivitySort.OPERATION, QueryObjects.TRANSACTION.operation)
                    .build();

    private static BooleanExpression hasDocsHandler(CriteriaField<?> field) {
        return ((CriteriaField<Boolean>) field).getValue() ? QueryObjects.TRANSACTION.id.in(new JPASubQuery()
                .from(QueryObjects.DOCUMENT)
                .list(QueryObjects.DOCUMENT.transaction.id)) :
                QueryObjects.TRANSACTION.id.notIn(new JPASubQuery()
                        .from(QueryObjects.DOCUMENT)
                        .list(QueryObjects.DOCUMENT.transaction.id));
    }

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>>builder()
                    .put(ActivitySearchCriteria.ACCOUNT_EMAIL, new CriteriaHandler<>(EntityAlias.ACCOUNT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACCOUNT.naasAccount))))
                    .put(ActivitySearchCriteria.ID, new CriteriaHandler<>(EntityAlias.ACTIVITY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY.id))))
                    .put(ActivitySearchCriteria.IP_ADDRESS, new CriteriaHandler<>(EntityAlias.ACTIVITY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY.ipAddress))))
                    .put(ActivitySearchCriteria.TYPE, new CriteriaHandler<>(EntityAlias.ACTIVITY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY.type))))
                    .put(ActivitySearchCriteria.CREATE_DATE, new CriteriaHandler<>(EntityAlias.ACTIVITY,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY.modifiedOn))))
                    .put(ActivitySearchCriteria.EXCHANGE, new CriteriaHandler<>(EntityAlias.TRANSACTION,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.TRANSACTION.exchange))))
                    .put(ActivitySearchCriteria.DETAILS, new CriteriaHandler<>(EntityAlias.ACTIVITY_DETAIL,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.ACTIVITY_DETAIL.detail))))
                    .put(ActivitySearchCriteria.OPERATION, new CriteriaHandler<>(EntityAlias.TRANSACTION,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.TRANSACTION.operation))))
                    .put(ActivitySearchCriteria.HAS_EXCHANGE, new CriteriaHandler<>(EntityAlias.TRANSACTION,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.TRANSACTION.exchange))))
                    .put(ActivitySearchCriteria.HAS_DOCS, new CriteriaHandler<>(EntityAlias.TRANSACTION,
                            new QuerydslFieldHandler<>(f -> hasDocsHandler(f))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<ActivitySort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Activity> getFrom() {
        return QueryObjects.ACTIVITY;
    }

    @Override
    public NaasSyncInfo findLastNaasSyncActivity() {
        NaasSyncInfo info = null;
        try {
            Object[] obj = getEntityManager()
                    .createQuery(LAST_NAAS_SYNC_ACTIVITY_QUERY, Object[].class)
                    .setMaxResults(1)
                    .getSingleResult();
            if (obj != null) {
                info = new NaasSyncInfo(obj[0].toString(), (LocalDateTime) obj[1], obj[2] != null);
            }
        } catch (Exception exception) {
            // NAAS has never been synced
            info = new NaasSyncInfo(null, LocalDateTime.now(), false);
        }
        return info;
    }

    @Override
    public Stream<LoginInfo> findLatestLoginInfo(int limit, String emailAddress, Boolean success) {
        TypedQuery<Object[]> query = getEntityManager()
                .createQuery(createLoginActivityQuery(emailAddress, success), Object[].class);
        if (emailAddress != null) {
            query.setParameter("detail", String.format("Authentication attempt by: %s", emailAddress));
        }
        return query
                .setMaxResults(limit)
                .getResultList()
                .stream()
                .map(arr -> new LoginInfo(
                        arr[0].toString(),
                        arr[2].toString().replace("Authentication attempt by: ", ""),
                        (LocalDateTime) arr[1],
                        arr[3].toString().contains("Success")));
    }

}

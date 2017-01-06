package com.windsor.node.repo;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.ImmutableMap;
import com.mysema.query.types.EntityPath;
import com.mysema.query.types.Path;
import com.mysema.query.types.expr.BooleanExpression;
import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.search.DocumentSearchCriteria;
import com.windsor.node.domain.search.DocumentSort;
import com.windsor.node.domain.search.EntityAlias;
import com.windsor.stack.domain.repo.IFinderRepository;
import com.windsor.stack.domain.search.CriteriaHandler;
import com.windsor.stack.domain.search.IField;
import com.windsor.stack.repo.search.querydsl.AbstractQuerydslFinderRepository;
import com.windsor.stack.repo.search.querydsl.QuerydslFieldHandler;
import com.windsor.stack.repo.search.querydsl.QuerydslJoinInfo;
import com.windsor.stack.repo.search.querydsl.QuerydslUtils;

/**
 * Provides an implementation of the Document repository.
 */
public class DocumentRepositoryImpl extends AbstractQuerydslFinderRepository<Document, DocumentSearchCriteria, DocumentSort>
        implements IFinderRepository<Document, DocumentSearchCriteria, DocumentSort> {

    private static final Map<Object, List<QuerydslJoinInfo>> ENTITY_ALIAS_MAP =
            ImmutableMap.<Object, List<QuerydslJoinInfo>> builder()
                .put(EntityAlias.DOCUMENT, Collections.<QuerydslJoinInfo> emptyList())
                .build();

    public static final Map<DocumentSort, Path<? extends Comparable<?>>> SORT_MAP =
            ImmutableMap.<DocumentSort, Path<? extends Comparable<?>>> builder()
                    .put(DocumentSort.ID, QueryObjects.DOCUMENT.id)
                    .put(DocumentSort.NAME, QueryObjects.DOCUMENT.name)
                    .build();

    public final Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> CRITERIA_FIELD_HANDLER =
            ImmutableMap.<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> builder()
                    .put(DocumentSearchCriteria.TRANSACTION_ID, new CriteriaHandler<>(EntityAlias.DOCUMENT,
                            new QuerydslFieldHandler<>(f -> QuerydslUtils.newExpression(f, QueryObjects.DOCUMENT.transaction.id))))
                    .build();

    @Override
    protected Map<Object, List<QuerydslJoinInfo>> getEntityAliasMap() {
        return ENTITY_ALIAS_MAP;
    }

    @Override
    protected Map<DocumentSort, Path<? extends Comparable<?>>> getSortMap() {
        return SORT_MAP;
    }

    @Override
    protected Map<Object, CriteriaHandler<BooleanExpression, ? extends IField<?>, ?>> getCriteriaFieldHandlders() {
        return CRITERIA_FIELD_HANDLER;
    }

    @Override
    protected EntityPath<Document> getFrom() {
        return QueryObjects.DOCUMENT;
    }

}

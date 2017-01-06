package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Transaction;
import com.windsor.node.domain.entity.TransactionStatus;

/**
 * Provides lazy models for the Transaction object.
 */
public class TransactionModels {

    public static final LazyModel<String> ID = model(from(Transaction.class).getId());
    public static final LazyModel<TransactionStatus> STATUS = model(from(Transaction.class).getStatus());
    public static final LazyModel<String> DETAILS = model(from(Transaction.class).getDetail());
    public static final LazyModel<String> METHOD = model(from(Transaction.class).getWebMethod());
    public static final LazyModel<Exchange> EXCHANGE = model(from(Transaction.class).getExchange());
    public static final LazyModel<String> OPERATION = model(from(Transaction.class).getOperation());
    public static final LazyModel<Account> MODIFIED_BY = model(from(Transaction.class).getModifiedBy());
    public static final LazyModel<LocalDateTime> MODIFIED_ON = model(from(Transaction.class).getModifiedOn());
    public static final LazyModel<String> REMOTE_TRANSACTION_ID = model(from(Transaction.class).getRemoteTransactionId());
    public static final LazyModel<String> REMOTE_URL = model(from(Transaction.class).getRemoteUrl());
    public static final LazyModel<String> REMOTE_VERSION = model(from(Transaction.class).getRemoteVersion());
    public static final LazyModel<Boolean> HAS_REMOTE_TRANSACTION = model(from(Transaction.class).hasRemoteTransaction());
    public static final LazyModel<Boolean> HAS_DOCUMENTS = model(from(Transaction.class).hasDocuments());
    public static final LazyModel<Boolean> HAS_QUERYABLE_REMOTE_TRANSACTION = model(from(Transaction.class).hasQueryableRemoteTransaction());
    public static final LazyModel<Boolean> HAS_TARGET_EXCHANGE = model(from(Transaction.class).hasTargetExchange());

    private TransactionModels() {

    }

    public static IModel<String> bindId(IModel<Transaction> model) {
        return ID.bind(model);
    }

    public static IModel<TransactionStatus> bindStatus(IModel<Transaction> model) {
        return STATUS.bind(model);
    }

    public static IModel<String> bindDetails(IModel<Transaction> model) {
        return DETAILS.bind(model);
    }

    public static IModel<String> bindMethod(IModel<Transaction> model) {
        return METHOD.bind(model);
    }

    public static IModel<Exchange> bindExchange(IModel<Transaction> model) {
        return EXCHANGE.bind(model);
    }

    public static IModel<String> bindOperation(IModel<Transaction> model) {
        return OPERATION.bind(model);
    }

    public static IModel<Account> bindModifiedBy(IModel<Transaction> model) {
        return MODIFIED_BY.bind(model);
    }

    public static IModel<LocalDateTime> bindModifiedOn(IModel<Transaction> model) {
        return MODIFIED_ON.bind(model);
    }

    public static IModel<String> bindRemoteTransactionid(IModel<Transaction> model) {
        return REMOTE_TRANSACTION_ID.bind(model);
    }

    public static IModel<String> bindRemoteUrl(IModel<Transaction> model) {
        return REMOTE_URL.bind(model);
    }

    public static IModel<String> bindRemoteVersion(IModel<Transaction> model) {
        return REMOTE_VERSION.bind(model);
    }

    public static IModel<Boolean> bindHasRemoteTransaction(IModel<Transaction> model) {
        return HAS_REMOTE_TRANSACTION.bind(model);
    }

    public static IModel<Boolean> bindHasDocuments(IModel<Transaction> model) {
        return HAS_DOCUMENTS.bind(model);
    }

    public static IModel<Boolean> bindHasQueryableRemoteTransaction(IModel<Transaction> model) {
        return HAS_QUERYABLE_REMOTE_TRANSACTION.bind(model);
    }

    public static IModel<Boolean> bindHasTargetExchange(IModel<Transaction> model) {
        return HAS_TARGET_EXCHANGE.bind(model);
    }

}

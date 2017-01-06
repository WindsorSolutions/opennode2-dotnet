package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Transaction;

/**
 * Provides lazy models for the Activity object.
 */
public final class ActivityModels {

    public static final LazyModel<String> ID = model(from(Activity.class).getId());
    public static final LazyModel<ActivityType> TYPE = model(from(Activity.class).getType());
    public static final LazyModel<String> ACCOUNT_EMAIL = model(from(Activity.class).getModifiedBy().getNaasAccount());
    public static final LazyModel<String> IP_ADDRESS = model(from(Activity.class).getIpAddress());
    public static final LazyModel<LocalDateTime> CREATED_DATE = model(from(Activity.class).getModifiedOn());
    public static final LazyModel<Exchange> EXCHANGE = model(from(Activity.class).getTransaction().getExchange());
    public static final LazyModel<Transaction> TRANSACTION = model(from(Activity.class).getTransaction());
    public static final LazyModel<String> OPERATION = model(from(Activity.class).getTransaction().getOperation());

    private ActivityModels() {

    }

    public static IModel<Transaction> bindTransaction(IModel<Activity> model) {
        return TRANSACTION.bind(model);
    }
    
    public static IModel<LocalDateTime> bindCreated(IModel<Activity> model) {
        return CREATED_DATE.bind(model);
    }

}

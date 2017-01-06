package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.stack.domain.search.LocalDateTimeRange;

/**
 * Provides lazy models for ArgumentSearchCriteria instances.
 */
public final class ActivitySearchCriteriaModels {

    public static final LazyModel<String> ID = model(from(ActivitySearchCriteria.class).getId());
    public static final LazyModel<ActivityType> TYPE = model(from(ActivitySearchCriteria.class).getType());
    public static final LazyModel<String> ACCOUNT_EMAIL = model(from(ActivitySearchCriteria.class).getAccountEmail());
    public static final LazyModel<String> IP_ADDRESS = model(from(ActivitySearchCriteria.class).getIpAddress());
    public static final LazyModel<LocalDateTimeRange> CREATED_RANGE = model(from(ActivitySearchCriteria.class).getCreateDateRange());
    public static final LazyModel<Exchange> EXCHANGE = model(from(ActivitySearchCriteria.class).getExchange());
    public static final LazyModel<String> DETAILS = model(from(ActivitySearchCriteria.class).getDetails());
    public static final LazyModel<String> OPERATION = model(from(ActivitySearchCriteria.class).getOperation());

    private ActivitySearchCriteriaModels() {

    }

    public static LazyModel<String> bindDetails(IModel<ActivitySearchCriteria> model) {
        return DETAILS.bind(model);
    }

    public static LazyModel<String> bindIpAddress(IModel<ActivitySearchCriteria> model) {
        return IP_ADDRESS.bind(model);
    }

}

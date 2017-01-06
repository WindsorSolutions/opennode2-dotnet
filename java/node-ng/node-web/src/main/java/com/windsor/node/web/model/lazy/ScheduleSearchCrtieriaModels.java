package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the ScheduleSearchCriteria instances.
 */
public final class ScheduleSearchCrtieriaModels {

    public static final LazyModel<String> NAME = model(from(ScheduleSearchCriteria.class).getName());
    public static final LazyModel<Exchange> EXCHANGE = model(from(ScheduleSearchCriteria.class).getExchange());

    private ScheduleSearchCrtieriaModels() {

    }
}

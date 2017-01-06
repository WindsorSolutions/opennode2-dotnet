package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.search.ExchangeSearchCriteria;

/**
 * Provides lazy models for ExchangeSearchCriteria instances.
 */
public final class ExchangeSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(ExchangeSearchCriteria.class).getName());
    public static final LazyModel<String> CONTACT_NAME = model(from(ExchangeSearchCriteria.class).getContact());
    public static final LazyModel<String> DESCRIPTION = model(from(ExchangeSearchCriteria.class).getDescription());
    public static final LazyModel<Boolean> SECURE = model(from(ExchangeSearchCriteria.class).getSecure());
    public static final LazyModel<String> TARGET_EXCHANGE_NAME = model(from(ExchangeSearchCriteria.class).getTargetExchangeName());
    public static final LazyModel<String> URL = model(from(ExchangeSearchCriteria.class).getUrl());

    private ExchangeSearchCriteriaModels() {

    }
}

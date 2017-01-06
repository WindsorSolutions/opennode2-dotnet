package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.ServiceAuthorizationLevel;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;

/**
 * Provides lazy models for ExchangeServiceSearchCriteria instances.
 */
public final class ExchangeServiceSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(ExchangeServiceSearchCriteria.class).getName());
    public static final LazyModel<String> EXCHANGE = model(from(ExchangeServiceSearchCriteria.class).getExchangeId());
    public static final LazyModel<Boolean> ACTIVE = model(from(ExchangeServiceSearchCriteria.class).getActive());
    public static final LazyModel<ServiceType> TYPE = model(from(ExchangeServiceSearchCriteria.class).getType());
    public static final LazyModel<String> IMPLEMENTOR = model(from(ExchangeServiceSearchCriteria.class).getImplementor());
    public static final LazyModel<ServiceAuthorizationLevel> AUTHORIZATION = model(from(ExchangeServiceSearchCriteria.class).getAuthorization());
    public static final LazyModel<Boolean> SECURE = model(from(ExchangeServiceSearchCriteria.class).getSecure());

    private ExchangeServiceSearchCriteriaModels() {

    }
}

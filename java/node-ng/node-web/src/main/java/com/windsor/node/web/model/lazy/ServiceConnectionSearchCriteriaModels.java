package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.ServiceConnectionSearchCriteria;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the ServiceConnectionSearchCriteria instances.
 */
public final class ServiceConnectionSearchCriteriaModels {

    public static LazyModel<ExchangeService> SERVICE = model(from(ServiceConnectionSearchCriteria.class).getService());
    public static LazyModel<String> KEY = model(from(ServiceConnectionSearchCriteria.class).getKey());

    private ServiceConnectionSearchCriteriaModels() {

    }
}

package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.ServiceArgumentSearchCriteria;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the ServiceArgumentSearchCriteria instances.
 */
public final class ServiceArgumentSearchCriteriaModels {

    public static final LazyModel<String> ID = model(from(ServiceArgumentSearchCriteria.class).getId());
    public static final LazyModel<ExchangeService> SERVICE = model(from(ServiceArgumentSearchCriteria.class).getService());
    public static final LazyModel<String> KEY = model(from(ServiceArgumentSearchCriteria.class).getKey());
    public static final LazyModel<String> VALUE = model(from(ServiceArgumentSearchCriteria.class).getValue());

    private ServiceArgumentSearchCriteriaModels() {

    }
}

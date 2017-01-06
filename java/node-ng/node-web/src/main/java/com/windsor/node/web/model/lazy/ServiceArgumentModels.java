package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.ServiceArgument;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the ServiceArgument object.
 */
public final class ServiceArgumentModels {

    public static final LazyModel<String> ID = model(from(ServiceArgument.class).getId());
    public static final LazyModel<ExchangeService> SERVICE = model(from(ServiceArgument.class).getService());
    public static final LazyModel<String> KEY = model(from(ServiceArgument.class).getKey());
    public static final LazyModel<String> VALUE = model(from(ServiceArgument.class).getValue());

    private ServiceArgumentModels() {

    }

    public static IModel<String> bindId(IModel<ServiceArgument> model) {
        return ID.bind(model);
    }

    public static IModel<ExchangeService> bindService(IModel<ServiceArgument> model) {
        return SERVICE.bind(model);
    }

    public static IModel<String> bindKey(IModel<ServiceArgument> model) {
        return KEY.bind(model);
    }

    public static IModel<String> bindValue(IModel<ServiceArgument> model) {
        return VALUE.bind(model);
    }
}

package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.ServiceConnection;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 *Provides lazy models for the ServiceConnection object.
 */
public final class ServiceConnectionModels {

    public static final LazyModel<String> ID = model(from(ServiceConnection.class).getId());
    public static final LazyModel<DataSource> DATA_SOURCE = model(from(ServiceConnection.class).getDataSource());
    public static final LazyModel<ExchangeService> SERVICE = model(from(ServiceConnection.class).getService());
    public static final LazyModel<String> KEY = model(from(ServiceConnection.class).getKey());

    private ServiceConnectionModels() {

    }

    public static IModel<String> bindId(IModel<ServiceConnection> model) {
        return ID.bind(model);
    }

    public static IModel<DataSource> bindDataSource(IModel<ServiceConnection> model) {
        return DATA_SOURCE.bind(model);
    }

    public static IModel<ExchangeService> bindService(IModel<ServiceConnection> model) {
        return SERVICE.bind(model);
    }

    public static IModel<String> bindKey(IModel<ServiceConnection> model) {
        return KEY.bind(model);
    }
}

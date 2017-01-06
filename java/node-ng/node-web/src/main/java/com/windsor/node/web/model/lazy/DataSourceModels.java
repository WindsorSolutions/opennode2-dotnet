package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.DataSourceProvider;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the DataSource object.
 */
public class DataSourceModels {

    public static final LazyModel<String> ID = model(from(DataSource.class).getId());
    public static final LazyModel<String> NAME = model(from(DataSource.class).getName());
    public static final LazyModel<DataSourceProvider> PROVIDER = model(from(DataSource.class).getProvider());
    public static final LazyModel<String> CONNECTION = model(from(DataSource.class).getConnection());

    private DataSourceModels() {

    }

    public static IModel<String> bindId(IModel<DataSource> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindName(IModel<DataSource> model) {
        return NAME.bind(model);
    }

    public static IModel<DataSourceProvider> bindProvider(IModel<DataSource> model) {
        return PROVIDER.bind(model);
    }

    public static IModel<String> bindConnection(IModel<DataSource> model) {
        return CONNECTION.bind(model);
    }
}

package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.DataSourceProvider;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for DataSourceSearchCriteria instances.
 */
public class DataSourceSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(DataSourceSearchCriteria.class).getName());
    public static final LazyModel<DataSourceProvider> PROVIDER = model(from(DataSourceSearchCriteria.class).getProvider());
    public static final LazyModel<String> CONNECTION = model(from(DataSourceSearchCriteria.class).getConnection());

    private DataSourceSearchCriteriaModels() {

    }
}

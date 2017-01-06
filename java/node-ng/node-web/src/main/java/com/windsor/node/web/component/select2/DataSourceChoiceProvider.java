package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSorts;
import com.windsor.node.service.DataSourceService;

/**
 * Provides a provider for selecting a DataSource.
 */
public class DataSourceChoiceProvider extends NodeEntityChoiceProvider<DataSource> {

    private static final int PAGE_SIZE = 20;

    public DataSourceChoiceProvider(DataSourceService service) {
        super(PAGE_SIZE, DataSource::getName, (term, page) ->
                service.find(new DataSourceSearchCriteria().name(term), DataSourceSorts.NAME, PAGE_SIZE * page, PAGE_SIZE), service);
    }
}

package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for DataSource instances.
 */
public enum DataSourceSorts implements ISortGroup<DataSourceSort> {

    ID(Arrays.asList(new SortInfo<>(DataSourceSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(DataSourceSort.NAME))),
    CONNECTION(Arrays.asList(new SortInfo<>(DataSourceSort.CONNECTION))),
    PROVIDER(Arrays.asList(new SortInfo<>(DataSourceSort.PROVIDER)));

    private List<SortInfo<DataSourceSort>> sorts;

    DataSourceSorts(List<SortInfo<DataSourceSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<DataSourceSort>> getSorts() {
        return sorts.stream();
    }
}

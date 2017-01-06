package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for ServiceConnection instances.
 */
public enum ServiceConnectionSorts implements ISortGroup<ServiceConnectionSort> {

    SERVICE(Arrays.asList(new SortInfo<>(ServiceConnectionSort.SERVICE))),
    KEY(Arrays.asList(new SortInfo<>(ServiceConnectionSort.KEY)));

    private List<SortInfo<ServiceConnectionSort>> sorts;

    ServiceConnectionSorts(List<SortInfo<ServiceConnectionSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ServiceConnectionSort>> getSorts() {
        return sorts.stream();
    }
}

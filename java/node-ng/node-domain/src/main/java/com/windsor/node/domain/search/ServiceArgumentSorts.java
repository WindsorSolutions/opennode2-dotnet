package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for ServiceArgument instances.
 */
public enum ServiceArgumentSorts implements ISortGroup<ServiceArgumentSort> {

    ID(Arrays.asList(new SortInfo<>(ServiceArgumentSort.ID))),
    SERVICE(Arrays.asList(new SortInfo<>(ServiceArgumentSort.SERVICE),
            new SortInfo<>(ServiceArgumentSort.KEY))),
    KEY(Arrays.asList(new SortInfo<>(ServiceArgumentSort.KEY))),
    VALUE(Arrays.asList(new SortInfo<>(ServiceArgumentSort.VALUE)));

    private List<SortInfo<ServiceArgumentSort>> sorts;

    ServiceArgumentSorts(List<SortInfo<ServiceArgumentSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ServiceArgumentSort>> getSorts() {
        return sorts.stream();
    }
}

package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for Activity Detail instances.
 */
public enum ActivityDetailSorts implements ISortGroup<ActivityDetailSort> {

    CREATE_DATE(Arrays.asList(new SortInfo<>(ActivityDetailSort.CREATED_DATE),
            new SortInfo<>(ActivityDetailSort.ORDER), new SortInfo<>(ActivityDetailSort.ID))),
    DETAIL(Arrays.asList(new SortInfo<>(ActivityDetailSort.DETAIL),
            new SortInfo<>(ActivityDetailSort.ORDER), new SortInfo<>(ActivityDetailSort.ID)));

    private List<SortInfo<ActivityDetailSort>> sorts;

    ActivityDetailSorts(List<SortInfo<ActivityDetailSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ActivityDetailSort>> getSorts() {
        return sorts.stream();
    }
}

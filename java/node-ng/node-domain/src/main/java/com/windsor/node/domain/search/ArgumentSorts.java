package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for Argument instances.
 */
public enum ArgumentSorts implements ISortGroup<ArgumentSort> {

    ID(Arrays.asList(new SortInfo<>(ArgumentSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(ArgumentSort.NAME))),
    VALUE(Arrays.asList(new SortInfo<>(ArgumentSort.VALUE), new SortInfo<>(ArgumentSort.NAME))),
    DESCRIPTION(Arrays.asList(new SortInfo<>(ArgumentSort.DESCRIPTION), new SortInfo<>(ArgumentSort.VALUE),
            new SortInfo<>(ArgumentSort.NAME))),
    EDITABLE(Arrays.asList(new SortInfo<>(ArgumentSort.EDITABLE),
            new SortInfo<>(ArgumentSort.NAME), new SortInfo<>(ArgumentSort.ID)));

    private List<SortInfo<ArgumentSort>> sorts;

    ArgumentSorts(List<SortInfo<ArgumentSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ArgumentSort>> getSorts() {
        return sorts.stream();
    }
}

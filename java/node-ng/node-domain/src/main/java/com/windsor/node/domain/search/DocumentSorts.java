package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for Argument instances.
 */
public enum DocumentSorts implements ISortGroup<DocumentSort> {

    NAME(Arrays.asList(new SortInfo<>(DocumentSort.NAME), new SortInfo<>(DocumentSort.ID)));

    private List<SortInfo<DocumentSort>> sorts;

    DocumentSorts(List<SortInfo<DocumentSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<DocumentSort>> getSorts() {
        return sorts.stream();
    }
}

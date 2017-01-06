package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for the Partner instances.
 */
public enum PartnerSorts implements ISortGroup<PartnerSort> {

    ID(Arrays.asList(new SortInfo<>(PartnerSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(PartnerSort.NAME))),
    URL(Arrays.asList(new SortInfo<>(PartnerSort.URL))),
    VERSION(Arrays.asList(new SortInfo<>(PartnerSort.VERSION)));

    private List<SortInfo<PartnerSort>> sorts;

    PartnerSorts(List<SortInfo<PartnerSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<PartnerSort>> getSorts() {
        return sorts.stream();
    }
}

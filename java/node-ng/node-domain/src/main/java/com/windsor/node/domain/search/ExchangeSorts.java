package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for exchange instances.
 */
public enum ExchangeSorts implements ISortGroup<ExchangeSort> {

    CONTACT_NAME(Arrays.asList(new SortInfo<>(ExchangeSort.CONTACT_NAME), new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID))),
    URL(Arrays.asList(new SortInfo<>(ExchangeSort.URL), new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID))),
    SECURE(Arrays.asList(new SortInfo<>(ExchangeSort.SECURE), new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID))),
    TARGET_EXCHANGE_NAME(Arrays.asList(new SortInfo<>(ExchangeSort.TARGET_EXCHANGE_NAME), new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID))),
    DESCRIPTION(Arrays.asList(new SortInfo<>(ExchangeSort.DESCRIPTION), new SortInfo<>(ExchangeSort.NAME), new SortInfo<>(ExchangeSort.ID)));

    private List<SortInfo<ExchangeSort>> sorts;

    ExchangeSorts(List<SortInfo<ExchangeSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ExchangeSort>> getSorts() {
        return sorts.stream();
    }
}

package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for ExchangeService instances.
 */
public enum ExchangeServiceSorts implements ISortGroup<ExchangeServiceSort> {

    ID(Arrays.asList(new SortInfo<>(ExchangeServiceSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(ExchangeServiceSort.NAME))),
    EXCHANGE(Arrays.asList(new SortInfo<>(ExchangeServiceSort.EXCHANGE), new SortInfo<>(ExchangeServiceSort.NAME))),
    ACTIVE(Arrays.asList(new SortInfo<>(ExchangeServiceSort.ACTIVE), new SortInfo<>(ExchangeServiceSort.NAME))),
    TYPE(Arrays.asList(new SortInfo<>(ExchangeServiceSort.TYPE), new SortInfo<>(ExchangeServiceSort.NAME))),
    IMPLEMENTOR(Arrays.asList(new SortInfo<>(ExchangeServiceSort.IMPLEMENTOR), new SortInfo<>(ExchangeServiceSort.NAME))),
    SERVICE_AUTHORIZATION_LEVEL(Arrays.asList(new SortInfo<>(ExchangeServiceSort.SERVICE_AUTHORIZATION_LEVEL),
            new SortInfo<>(ExchangeServiceSort.NAME))),
    SECURE(Arrays.asList(new SortInfo<>(ExchangeServiceSort.SECURE), new SortInfo<>(ExchangeServiceSort.NAME)));

    private List<SortInfo<ExchangeServiceSort>> sorts;

    ExchangeServiceSorts(List<SortInfo<ExchangeServiceSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ExchangeServiceSort>> getSorts() {
        return sorts.stream();
    }
}

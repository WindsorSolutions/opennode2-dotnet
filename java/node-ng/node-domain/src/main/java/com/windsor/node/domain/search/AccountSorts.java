package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for Account instances.
 */
public enum AccountSorts implements ISortGroup<AccountSort> {

    ID(Arrays.asList(new SortInfo<>(AccountSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(AccountSort.NAME))),
    SYSTEM_ROLE_TYPE(Arrays.asList(new SortInfo<AccountSort>(AccountSort.SYSTEM_ROLE_TYPE),
            new SortInfo<AccountSort>(AccountSort.NAME))),
    AFFILIATION(Arrays.asList(new SortInfo<AccountSort>(AccountSort.AFFILIATION),
            new SortInfo<AccountSort>(AccountSort.NAME))),
    ACTIVE(Arrays.asList(new SortInfo<AccountSort>(AccountSort.ACTIVE),
            new SortInfo<AccountSort>(AccountSort.NAME))),
    DELETED(Arrays.asList(new SortInfo<AccountSort>(AccountSort.DELETED),
            new SortInfo<AccountSort>(AccountSort.NAME))),
    DEMO(Arrays.asList(new SortInfo<AccountSort>(AccountSort.DEMO),
            new SortInfo<AccountSort>(AccountSort.NAME)));

    private List<SortInfo<AccountSort>> sorts;

    AccountSorts(List<SortInfo<AccountSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<AccountSort>> getSorts() {
        return sorts.stream();
    }
}

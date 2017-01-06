package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for AccountPolicy instances.
 */
public enum AccountPolicySorts implements ISortGroup<AccountPolicySort> {

    ACCOUNT_NAME(Arrays.asList(new SortInfo<>(AccountPolicySort.ACCOUNT_NAME), new SortInfo<>(AccountPolicySort.ID))),
    EXCHANGE_NAME(Arrays.asList(new SortInfo<>(AccountPolicySort.EXCHANGE_NAME), new SortInfo<>(AccountPolicySort.ID)));

    private List<SortInfo<AccountPolicySort>> sorts;

    AccountPolicySorts(List<SortInfo<AccountPolicySort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<AccountPolicySort>> getSorts() {
        return sorts.stream();
    }
}

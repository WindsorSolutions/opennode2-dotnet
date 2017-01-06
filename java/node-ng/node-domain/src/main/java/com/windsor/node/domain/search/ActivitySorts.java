package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for Activity instances.
 */
public enum ActivitySorts implements ISortGroup<ActivitySort> {

    CREATE_DATE(Arrays.asList(new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID))),
    ACCOUNT_EMAIL(Arrays.asList(new SortInfo<>(ActivitySort.ACCOUNT), new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID))),
    IP_ADDRESS(Arrays.asList(new SortInfo<>(ActivitySort.IP_ADDRESS), new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID))),
    TYPE(Arrays.asList(new SortInfo<>(ActivitySort.TYPE), new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID))),
    EXCHANGE(Arrays.asList(new SortInfo<>(ActivitySort.EXCHANGE), new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID))),
    OPERATION(Arrays.asList(new SortInfo<>(ActivitySort.OPERATION), new SortInfo<>(ActivitySort.CREATE_DATE), new SortInfo<>(ActivitySort.ID)));

    private List<SortInfo<ActivitySort>> sorts;

    ActivitySorts(List<SortInfo<ActivitySort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ActivitySort>> getSorts() {
        return sorts.stream();
    }
}

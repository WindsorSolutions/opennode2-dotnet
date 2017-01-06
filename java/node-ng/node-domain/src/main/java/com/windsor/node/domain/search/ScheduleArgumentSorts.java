package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides a group of sorting information for ScheduleArgument instances.
 */
public enum ScheduleArgumentSorts implements ISortGroup<ScheduleArgumentSort> {

    ID(Arrays.asList(new SortInfo<>(ScheduleArgumentSort.KEY))),
    SCHEDULE(Arrays.asList(new SortInfo<>(ScheduleArgumentSort.SCHEDULE))),
    KEY(Arrays.asList(new SortInfo<>(ScheduleArgumentSort.KEY))),
    VALUE(Arrays.asList(new SortInfo<>(ScheduleArgumentSort.VALUE)));

    private List<SortInfo<ScheduleArgumentSort>> sorts;

    ScheduleArgumentSorts(List<SortInfo<ScheduleArgumentSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ScheduleArgumentSort>> getSorts() {
        return sorts.stream();
    }
}

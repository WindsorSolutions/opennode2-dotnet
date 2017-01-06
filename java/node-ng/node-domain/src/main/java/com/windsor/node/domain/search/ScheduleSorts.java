package com.windsor.node.domain.search;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

/**
 * Provides groups of sorting information for Schedule instances.
 */
public enum ScheduleSorts implements ISortGroup<ScheduleSort> {

    ID(Arrays.asList(new SortInfo<>(ScheduleSort.ID))),
    NAME(Arrays.asList(new SortInfo<>(ScheduleSort.NAME))),
    EXCHANGE(Arrays.asList(new SortInfo<>(ScheduleSort.EXCHANGE), new SortInfo<>(ScheduleSort.NAME))),
    SERVICE_SOURCE(Arrays.asList(new SortInfo<>(ScheduleSort.SERVICE_SOURCE), new SortInfo<>(ScheduleSort.NAME))),
    SERVICE_TARGET(Arrays.asList(new SortInfo<>(ScheduleSort.SERVICE_TARGET), new SortInfo<>(ScheduleSort.NAME))),
    START(Arrays.asList(new SortInfo<>(ScheduleSort.START), new SortInfo<>(ScheduleSort.NAME))),
    END(Arrays.asList(new SortInfo<>(ScheduleSort.END), new SortInfo<>(ScheduleSort.NAME))),
    NEXT_START(Arrays.asList(new SortInfo<>(ScheduleSort.NEXT_START), new SortInfo<>(ScheduleSort.NAME))),
    SOURCE_TYPE(Arrays.asList(new SortInfo<>(ScheduleSort.SOURCE_TYPE), new SortInfo<>(ScheduleSort.NAME))),
    TARGET_TYPE(Arrays.asList(new SortInfo<>(ScheduleSort.TARGET_TYPE), new SortInfo<>(ScheduleSort.NAME))),
    LAST_EXECUTION_INFO(Arrays.asList(new SortInfo<>(ScheduleSort.LAST_EXECUTION_INFO),
            new SortInfo<>(ScheduleSort.NAME))),
    LAST_EXECUTION(Arrays.asList(new SortInfo<>(ScheduleSort.LAST_EXECUTION), new SortInfo<>(ScheduleSort.NAME))),
    SOURCE_OPERATION(Arrays.asList(new SortInfo<>(ScheduleSort.SOURCE_OPERATION), new SortInfo<>(ScheduleSort.NAME))),
    TARGET_OPERATION(Arrays.asList(new SortInfo<>(ScheduleSort.TARGET_OPERATION), new SortInfo<>(ScheduleSort.NAME))),
    FREQUENCY_TYPE(Arrays.asList(new SortInfo<>(ScheduleSort.FREQUENCY_TYPE), new SortInfo<>(ScheduleSort.NAME))),
    FREQUENCY(Arrays.asList(new SortInfo<>(ScheduleSort.FREQUENCY), new SortInfo<>(ScheduleSort.NAME)));

    private List<SortInfo<ScheduleSort>> sorts;

    ScheduleSorts(List<SortInfo<ScheduleSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<ScheduleSort>> getSorts() {
        return sorts.stream();
    }
}

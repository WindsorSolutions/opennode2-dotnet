package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.ISortGroup;
import com.windsor.stack.domain.search.SortInfo;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides groups of sorting information for Plugin instances.
 */
public enum PluginSorts implements ISortGroup<PluginSort> {

    ID(Arrays.asList(new SortInfo<>(PluginSort.ID))),
    EXCHANGE(Arrays.asList(new SortInfo<>(PluginSort.EXCHANGE))),
    VERSION(Arrays.asList(new SortInfo<>(PluginSort.VERSION)));

    private List<SortInfo<PluginSort>> sorts;

    PluginSorts(List<SortInfo<PluginSort>> sorts) {
        this.sorts = sorts;
    }

    @Override
    public Stream<SortInfo<PluginSort>> getSorts() {
        return sorts.stream();
    }
}

package com.windsor.node.web.component.column;

import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredMultilineLazyColumn;
import org.apache.wicket.Component;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.extensions.markup.html.repeater.data.grid.ICellPopulator;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.repeater.Item;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

/**
 * Provides a text filtered multi-line lazy column that is very aggressive about breaking lines, so much so that it
 * will arbitrarily break the line where it likes. This should be used with String instances that are lengthy and
 * full of gibberish, like a hash of a password or a database connection string.
 */
public class HardBreakingTextFilteredMultilineLazyColumn<T, S, R, F> extends TextFilteredMultilineLazyColumn<T, S, R, F> {

    public HardBreakingTextFilteredMultilineLazyColumn(IModel<String> displayModel, S sortProperty, LazyModel<F> filterModel) {
        super(displayModel, sortProperty, filterModel);
    }

    public HardBreakingTextFilteredMultilineLazyColumn(IModel<String> displayModel, S sortProperty, LazyModel<F> filterModel,
                                                       ISerializableFunction<IModel<T>, IModel<R>> dataModelFunction) {
        super(displayModel, sortProperty, filterModel, dataModelFunction);
    }

    public HardBreakingTextFilteredMultilineLazyColumn(IModel<String> displayModel, LazyModel<R> cellModel, S sortProperty,
                                                       LazyModel<F> filterModel) {
        super(displayModel, cellModel, sortProperty, filterModel);
    }

    @Override
    public void populateItem(Item<ICellPopulator<T>> item, String componentId, IModel<T> rowModel) {
        Component label = new MultiLineLabel(componentId, this.getDataModel(rowModel));
        label.add(new AttributeAppender("style", "word-break: break-all;"));
        item.add(label);
    }
}

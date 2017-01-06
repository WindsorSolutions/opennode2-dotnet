package com.windsor.node.web.component.column;

import org.apache.wicket.extensions.markup.html.repeater.data.grid.ICellPopulator;
import org.apache.wicket.markup.repeater.Item;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.StyledIcon;
import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ExportableLazyColumn;
import com.windsor.stack.web.wicket.model.LDModel;

public class IconInfoColumn<T, S, R> extends ExportableLazyColumn<T, S, R> {

    private ISerializableFunction<R, IconInfo> iconFunction;

    public IconInfoColumn(IModel<String> displayModel, LazyModel<R> rowModel, ISerializableFunction<R, IconInfo> iconFunction) {
        super(displayModel, rowModel);
        this.iconFunction = iconFunction;
    }

    @Override
    public void populateItem(Item<ICellPopulator<T>> item, String componentId, IModel<T> rowModel) {
        item.add(new StyledIcon(componentId, new LDModel<>(() -> iconFunction.apply(getDataModel(rowModel).getObject()))));
    }

}

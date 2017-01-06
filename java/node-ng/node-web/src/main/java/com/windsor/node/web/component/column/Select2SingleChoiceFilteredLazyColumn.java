package com.windsor.node.web.component.column;

import org.apache.wicket.Component;
import org.apache.wicket.extensions.markup.html.repeater.data.table.filter.FilterForm;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;
import org.wicketstuff.select2.ChoiceProvider;

import com.windsor.stack.web.wicket.component.datatable.column.lazy.Select2SingleChoiceFilter;

public class Select2SingleChoiceFilteredLazyColumn<T, S, R, F> extends com.windsor.stack.web.wicket.component.datatable.column.lazy.Select2SingleChoiceFilteredLazyColumn<T, S, R, F> {

    private String cssClass;

    public Select2SingleChoiceFilteredLazyColumn(IModel<String> displayModel, S sortProperty,
            LazyModel<F> filterModel, ChoiceProvider<F> choiceProvider) {
        this(displayModel, sortProperty, null, filterModel, choiceProvider, null);
    }

    public Select2SingleChoiceFilteredLazyColumn(IModel<String> displayModel, S sortProperty, LazyModel<R> dataModel,
            LazyModel<F> filterModel, ChoiceProvider<F> choiceProvider) {
        this(displayModel, sortProperty, dataModel, filterModel, choiceProvider, null);
    }

    public Select2SingleChoiceFilteredLazyColumn(IModel<String> displayModel, S sortProperty, LazyModel<R> dataModel,
            LazyModel<F> filterModel, ChoiceProvider<F> choiceProvider, String cssClass) {
        super(displayModel, sortProperty, dataModel, filterModel, choiceProvider);
        this.cssClass = cssClass;
    }

    @Override
    public String getCssClass() {
        return cssClass;
    }

    @Override
    public Component getFilter(String componentId, FilterForm<?> form) {
            return new Select2SingleChoiceFilter<>(componentId, getFilterModel(form), form, getChoiceProvider(), "100%");
    }

}

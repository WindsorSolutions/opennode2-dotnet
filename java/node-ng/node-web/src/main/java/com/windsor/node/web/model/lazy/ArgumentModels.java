package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.Argument;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the Argument object.
 */
public final class ArgumentModels {

    public static final LazyModel<String> ID = model(from(Argument.class).getId());
    public static final LazyModel<String> NAME = model(from(Argument.class).getName());
    public static final LazyModel<String> VALUE = model(from(Argument.class).getValue());
    public static final LazyModel<String> DESCRIPTION = model(from(Argument.class).getDescription());
    public static final LazyModel<Boolean> EDITABLE = model(from(Argument.class).isEditable());

    private ArgumentModels() {

    }

    public static IModel<String> bindId(IModel<Argument> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindName(IModel<Argument> model) {
        return NAME.bind(model);
    }

    public static IModel<String> bindValue(IModel<Argument> model) {
        return VALUE.bind(model);
    }

    public static IModel<String> bindDescription(IModel<Argument> model) {
        return DESCRIPTION.bind(model);
    }

    public static IModel<Boolean> bindEditable(IModel<Argument> model){
        return EDITABLE.bind(model);
    }
}

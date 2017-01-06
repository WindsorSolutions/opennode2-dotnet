package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditServiceArgumentBean;
import com.windsor.node.domain.entity.Argument;

public class EditServiceArgumentBeanModels {

    public static final LazyModel<String> KEY = model(from(EditServiceArgumentBean.class).getKey());
    public static final LazyModel<String> VALUE = model(from(EditServiceArgumentBean.class).getValue());
    public static final LazyModel<Boolean> GLOBAL = model(from(EditServiceArgumentBean.class).isUseGlobalArgument());
    public static final LazyModel<Argument> ARGUMENT = model(from(EditServiceArgumentBean.class).getArgument());

    private EditServiceArgumentBeanModels() {

    }

    public static LazyModel<String> bindKey(IModel<EditServiceArgumentBean> model) {
        return KEY.bind(model);
    }

    public static LazyModel<String> bindValue(IModel<EditServiceArgumentBean> model) {
        return VALUE.bind(model);
    }

    public static LazyModel<Boolean> bindGlobal(IModel<EditServiceArgumentBean> model) {
        return GLOBAL.bind(model);
    }

    public static LazyModel<Argument> bindArgument(IModel<EditServiceArgumentBean> model) {
        return ARGUMENT.bind(model);
    }

}

package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditScheduleArgumentBean;

public class EditScheduleArgumentBeanModels {

    public static final LazyModel<String> KEY = model(from(EditScheduleArgumentBean.class).getKey());
    public static final LazyModel<String> VALUE = model(from(EditScheduleArgumentBean.class).getValue());
    public static final LazyModel<Boolean> REQUIRED = model(from(EditScheduleArgumentBean.class).isRequired());

    private EditScheduleArgumentBeanModels() {
        super();
    }

    public static IModel<String> bindKey(IModel<EditScheduleArgumentBean> model) {
        return KEY.bind(model);
    }

    public static IModel<String> bindValue(IModel<EditScheduleArgumentBean> model) {
        return VALUE.bind(model);
    }

    public static IModel<Boolean> bindRequired(IModel<EditScheduleArgumentBean> model) {
        return REQUIRED.bind(model);
    }

}

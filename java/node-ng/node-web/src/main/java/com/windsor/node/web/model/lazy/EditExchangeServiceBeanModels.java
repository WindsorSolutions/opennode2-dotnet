package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.util.List;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.edit.EditServiceArgumentBean;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.ServiceType;

public class EditExchangeServiceBeanModels {

    public static final LazyModel<String> NAME = model(from(EditExchangeServiceBean.class).getName());
    public static final LazyModel<Boolean> ACTIVE = model(from(EditExchangeServiceBean.class).isActive());
    public static final LazyModel<ServiceType> TYPE = model(from(EditExchangeServiceBean.class).getType());
    public static final LazyModel<PluginServiceImplementorDescriptor> IMPLEMENTOR_DESCRIPTOR = model(from(EditExchangeServiceBean.class).getImplementorDescriptor());
    public static final LazyModel<String> IMPLEMENTOR_DESCRIPTOR_DESCRIPTION = model(from(EditExchangeServiceBean.class).getImplementorDescriptor().getDescription());
    public static final LazyModel<String> IMPLEMENTOR_DESCRIPTOR_CLASSNAME = model(from(EditExchangeServiceBean.class).getImplementorDescriptor().getClassName());
    public static final LazyModel<DataSource> DATA_SOURCE = model(from(EditExchangeServiceBean.class).getDataSource());
    public static final LazyModel<List<EditServiceArgumentBean>> ARGUMENTS = model(from(EditExchangeServiceBean.class).getArguments());

    private EditExchangeServiceBeanModels() {

    }

    public static LazyModel<String> bindName(IModel<EditExchangeServiceBean> model) {
        return NAME.bind(model);
    }

    public static LazyModel<Boolean> bindActive(IModel<EditExchangeServiceBean> model) {
        return ACTIVE.bind(model);
    }

    public static LazyModel<ServiceType> bindType(IModel<EditExchangeServiceBean> model) {
        return TYPE.bind(model);
    }

    public static LazyModel<PluginServiceImplementorDescriptor> bindImplementorDescriptor(IModel<EditExchangeServiceBean> model) {
        return IMPLEMENTOR_DESCRIPTOR.bind(model);
    }

    public static LazyModel<String> bindImplementorDescriptorDescription(IModel<EditExchangeServiceBean> model) {
        return IMPLEMENTOR_DESCRIPTOR_DESCRIPTION.bind(model);
    }

    public static LazyModel<String> bindImplementorDescriptorClassname(IModel<EditExchangeServiceBean> model) {
        return IMPLEMENTOR_DESCRIPTOR_CLASSNAME.bind(model);
    }

    public static LazyModel<DataSource> bindDataSource(IModel<EditExchangeServiceBean> model) {
        return DATA_SOURCE.bind(model);
    }

    public static LazyModel<List<EditServiceArgumentBean>> bindArguments(IModel<EditExchangeServiceBean> model) {
        return ARGUMENTS.bind(model);
    }

}

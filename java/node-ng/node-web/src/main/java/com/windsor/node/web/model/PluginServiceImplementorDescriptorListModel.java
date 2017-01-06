package com.windsor.node.web.model;

import java.io.IOException;
import java.util.Collections;
import java.util.List;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.service.PluginService;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class PluginServiceImplementorDescriptorListModel extends LoadableDetachableWrappedModel<List<PluginServiceImplementorDescriptor>, Exchange> {

    @SpringBean
    private PluginService service;

    public PluginServiceImplementorDescriptorListModel(IModel<Exchange> wrappedModel) {
        super(wrappedModel);
        Injector.get().inject(this);
    }

    @Override
    protected List<PluginServiceImplementorDescriptor> load() {
        List<PluginServiceImplementorDescriptor> list = null;
        try {
            list = service.getImplementors(getWrappedModel().getObject());
        } catch (IOException e) {
            list = Collections.emptyList();
        }
        return list;
    }

}

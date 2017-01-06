package com.windsor.node.web.model;

import java.io.IOException;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.PluginService;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class PluginModel extends LoadableDetachableWrappedModel<BaseWnosPlugin, String> {

    private static final Logger LOGGER = LoggerFactory.getLogger(PluginModel.class);

    @SpringBean
    private PluginService pluginService;

    private IModel<Exchange> exchangeModel;

    public PluginModel(IModel<String> implementerModel, IModel<Exchange> exchangeModel) {
        super(implementerModel);
        this.exchangeModel = exchangeModel;
        Injector.get().inject(this);
    }

    @Override
    protected BaseWnosPlugin load() {
        Exchange exchange = exchangeModel.getObject();
        String implementer = getWrappedModel().getObject();
        BaseWnosPlugin plugin = null;
        if (exchange != null && implementer != null) {
            try {
                plugin = pluginService.getPlugin(exchange, implementer);
            } catch (IOException e) {
                LOGGER.error("Error getting plugin details: " + exchange.getName() + " - " + implementer, e);
            }
        }
        return plugin;
    }

    @Override
    protected void onDetach() {
        super.onDetach();
        exchangeModel.detach();
    }

}
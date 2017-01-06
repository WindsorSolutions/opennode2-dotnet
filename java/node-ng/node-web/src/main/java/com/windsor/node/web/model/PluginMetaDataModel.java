package com.windsor.node.web.model;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.service.PluginService;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class PluginMetaDataModel extends LoadableDetachableWrappedModel<PluginMetaData, Exchange> {

    private static final Logger LOGGER = LoggerFactory.getLogger(PluginMetaDataModel.class);

    @SpringBean
    private PluginService pluginService;

    public PluginMetaDataModel(IModel<Exchange> wrappedModel) {
        super(wrappedModel);
        Injector.get().inject(this);
    }

    @Override
    protected PluginMetaData load() {
        PluginMetaData pluginMetaData =  new PluginMetaData();
        pluginMetaData.setName("No Plugin Uploaded");
        pluginMetaData.setDescription("");
        pluginMetaData.setFullName("");
        pluginMetaData.setVersion("");
        pluginMetaData.setHelpText("");

        Exchange exchange = getWrappedModel().getObject();
        if(exchange != null) {
            try {
                pluginMetaData = pluginService.getPluginMetadata(exchange);
            } catch (Exception exception) {
                LOGGER.warn("Couldn't load plugin metadata: " + exception.getMessage());
            }
        }

        return pluginMetaData;
    }

}
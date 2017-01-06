package com.windsor.node.web.model.lazy;

import com.windsor.node.common.domain.PluginMetaData;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provided lazymodels for the PluginMetaData object.
 */
public final class PluginMetaDataModels {

    public static final LazyModel<String> NAME = model(from(PluginMetaData.class).getName());
    public static final LazyModel<String> DESCRIPTION = model(from(PluginMetaData.class).getDescription());
    public static final LazyModel<String> VERSION = model(from(PluginMetaData.class).getVersion());
    public static final LazyModel<String> FULL_NAME = model(from(PluginMetaData.class).getFullName());
    public static final LazyModel<String> HELP_TEXT = model(from(PluginMetaData.class).getHelpText());

    private PluginMetaDataModels() {

    }

    public static IModel<String> bindName(IModel<PluginMetaData> model) {
        return NAME.bind(model);
    }

    public static IModel<String> bindDescription(IModel<PluginMetaData> model) {
        return DESCRIPTION.bind(model);
    }

    public static IModel<String> bindVersion(IModel<PluginMetaData> model) {
        return VERSION.bind(model);
    }

    public static IModel<String> bindFullName(IModel<PluginMetaData> model) {
        return FULL_NAME.bind(model);
    }

    public static IModel<String> bindHelpText(IModel<PluginMetaData> model) {
        return HELP_TEXT.bind(model);
    }
}

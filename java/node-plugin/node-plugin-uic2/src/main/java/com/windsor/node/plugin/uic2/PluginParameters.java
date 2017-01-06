package com.windsor.node.plugin.uic2;

import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public enum PluginParameters {

    ORG_ID(new PluginServiceParameterDescriptor("Org ID",
            PluginServiceParameterDescriptor.TYPE_STRING,
            Boolean.TRUE,
            "The Org ID to be used in the submission Header. "
            + "Also governs SELECT logic on UIC_ORG table."));

    private PluginServiceParameterDescriptor parameterDescriptor;

    PluginParameters(PluginServiceParameterDescriptor parameterDescriptor) {
        this.parameterDescriptor = parameterDescriptor;
    }

    public PluginServiceParameterDescriptor getParameterDescriptor() {
        return parameterDescriptor;
    }

}

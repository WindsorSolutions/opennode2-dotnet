package com.windsor.node.plugin.rcra54.domain;

import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public enum PluginParameters {

	USE_SOLICIT_HISTORY(new PluginServiceParameterDescriptor("Use Solicit History", 
			PluginServiceParameterDescriptor.TYPE_BOOLEAN, 
			Boolean.TRUE,
			"Whether the last submission history record should be used as the starting point for the next submission.")),
    VALIDATE_XML(new PluginServiceParameterDescriptor(
            "Validate Xml (true or false)",
            PluginServiceParameterDescriptor.TYPE_BOOLEAN, 
            Boolean.TRUE,
            "Whether to validate the generated XML."));
	
	private PluginServiceParameterDescriptor parameterDescriptor;

	PluginParameters(PluginServiceParameterDescriptor parameterDescriptor) {
		this.parameterDescriptor = parameterDescriptor;
	}

	public PluginServiceParameterDescriptor getParameterDescriptor() {
		return parameterDescriptor;
	}

}

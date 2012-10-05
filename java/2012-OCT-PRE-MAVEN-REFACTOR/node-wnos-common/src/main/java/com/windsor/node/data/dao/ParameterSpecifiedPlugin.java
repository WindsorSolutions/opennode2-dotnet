package com.windsor.node.data.dao;

import java.util.List;

public interface ParameterSpecifiedPlugin
{
    /**
     * Returns a List of parameters, empty List, not null, for if there are none
     * @return
     */
    List<PluginServiceParameterDescriptor> getParameters();
}

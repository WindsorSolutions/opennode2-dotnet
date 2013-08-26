package com.windsor.node.plugin.ic;

import java.util.List;
import javax.sql.DataSource;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;

public class GetICDataByBoundingBox extends BaseWnosJaxbPlugin
{
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(GetICDataByBoundingBox.class.getName());
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Returns all IC data within a bounding box (area) specified by maximum and minimum latitude/longitude coordinate pairs.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetICDataByBoundingBox.class.getCanonicalName());
    }

    public GetICDataByBoundingBox()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return null;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        return null;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }
}

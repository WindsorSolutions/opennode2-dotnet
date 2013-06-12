package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.wqx.service.AbstractWqxService;

public class ExecuteExtract extends AbstractWqxService {

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("ExecuteExtract");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Executes a stored procedure, intended to execute the ETL to flow data into the staging tables.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(ExecuteExtract.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    protected ServiceType supportsServiceType() {
        return ServiceType.TASK;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(EXTRACT_STORED_PROCEDURE_NAME);
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);
        recordAtivity(result, "%s service is not implemented yet.", getClass().getSimpleName());
        return result;
    }
}

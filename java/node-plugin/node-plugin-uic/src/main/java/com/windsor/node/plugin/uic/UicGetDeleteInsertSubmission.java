package com.windsor.node.plugin.uic;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class UicGetDeleteInsertSubmission extends BaseUicXmlPlugin
{
    public static final String SERVICE_NAME = "UICGetDeleteInsertSubmission";
    private static final String TEMPLATE_NAME = "UIC_DeleteInsert.vm";
    private static final String OUTFILE_BASE_NAME = "UIC_2_DeleteInsert";
    public static final PluginServiceParameterDescriptor ORG_ID = new PluginServiceParameterDescriptor("Org ID", "java.lang.String", Boolean.TRUE,
                    "The Org ID to be used in the submission Header. Also governs SELECT logic on UIC_ORGANIZATION table.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("UicGetDeleteInsertSubmission");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Reads data from the UIC staging database and prepares the data in XML format for delivery for Insert/Update/Delete into/from UIC.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(UicGetDeleteInsertSubmission.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public UicGetDeleteInsertSubmission()
    {
        debug("UicGetDeleteInsertSubmission instantiated.");
    }

    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List params = new ArrayList();
        params.add(ORG_ID);
        return params;
    }

    public ProcessContentResult process(NodeTransaction transaction)
    {
        return generateAndSubmitFile(transaction, "UIC_DeleteInsert.vm", "UIC_2_DeleteInsert", UicOperationType.DELETE_INSERT);
    }

    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        List list = null;

        if(serviceName.equalsIgnoreCase("UICGetDeleteInsertSubmission"))
        {
            list = new ArrayList();

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName("orgId");

            list.add(param);
        }

        return list;
    }
}
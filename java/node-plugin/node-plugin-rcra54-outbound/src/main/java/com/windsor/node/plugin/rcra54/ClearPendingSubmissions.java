package com.windsor.node.plugin.rcra54;

import com.windsor.node.common.domain.*;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.rcra54.domain.generated.SolicitHistory;
import com.windsor.node.plugin.rcra54.outbound.BaseRcra54Plugin;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class ClearPendingSubmissions extends BaseRcra54Plugin {

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("ClearPendingSubmissions");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Marks as failed any pending solicits.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(ClearPendingSubmissions.class.getCanonicalName());
    }

    public ClearPendingSubmissions() {
        super();
        getSupportedPluginTypes().add(ServiceType.TASK);
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return Collections.emptyList();
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> parameters = new ArrayList<>();
        return parameters;
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        try {
            getTargetEntityManager().getTransaction().begin();
            getTargetEntityManager()
                    .createNativeQuery("UPDATE RCRA_SOLICITHISTORY SET PROCESSINGSTATUS = :failedStatus WHERE PROCESSINGSTATUS = :pendingStatus")
                    .setParameter("failedStatus", SolicitHistory.Status.FAILED.getName())
                    .setParameter("pendingStatus", SolicitHistory.Status.PENDING.getName())
                    .executeUpdate();
            getTargetEntityManager().getTransaction().commit();
        } catch (Exception e) {

            /**
             * Rollback the transaction when exception is thrown.
             */
            getTargetEntityManager().getTransaction().rollback();

            result.setStatus(CommonTransactionStatusCode.Failed);
            result.setSuccess(Boolean.FALSE);
            result.getAuditEntries().add(new ActivityEntry("Unable to clear pending solicits. Error: " + e.getLocalizedMessage()));
            return result;
        }

        result.setStatus(CommonTransactionStatusCode.Completed);
        result.setSuccess(Boolean.TRUE);
        result.getAuditEntries().add(new ActivityEntry("Successfully marked as failed any pending solicits"));

        return result;
    }
}


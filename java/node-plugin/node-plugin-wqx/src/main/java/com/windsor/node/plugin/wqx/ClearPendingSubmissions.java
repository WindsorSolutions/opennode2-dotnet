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
import com.windsor.node.plugin.wqx.service.ScheduleParameters;

/**
 *
 * Type: TASK
 */
public class ClearPendingSubmissions extends AbstractWqxService {

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("ClearPendingSubmissions");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Resets the CDXPROCESSINGSTATUS column of the WQX_SUBMISSIONHISTORY table, so that the next run can set a status of \"Pending\" if it needs to while leaving the submission history intact");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(ClearPendingSubmissions.class.getCanonicalName());
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
        params.add(ORG_ID);
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        final ScheduleParameters scheduleParameters = new ScheduleParameters(transaction);

        try {
            getEntityManager().getTransaction().begin();
            getSubmissionHistoryDao().resetSubmissionStatusByOrgId(scheduleParameters.getOrgId());
            getEntityManager().getTransaction().commit();
        } catch (Exception e) {

            /**
             * Rollback the transaction when exception is thrown.
             */
            getEntityManager().getTransaction().rollback();

            result.setStatus(CommonTransactionStatusCode.Failed);
            result.setSuccess(Boolean.FALSE);
            recordAtivity(result, "Unable to clear pending submission for Org ID \"" + scheduleParameters.getOrgId() + "\". Error: " + e.getLocalizedMessage());
            return result;
        }

        result.setStatus(CommonTransactionStatusCode.Completed);
        result.setSuccess(Boolean.TRUE);
        recordAtivity(result, "Successfully cleared submission status for Org ID \"" + scheduleParameters.getOrgId() + "\".");

        return result;
    }
}

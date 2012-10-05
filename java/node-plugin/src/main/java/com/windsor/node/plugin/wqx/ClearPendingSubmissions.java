package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
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

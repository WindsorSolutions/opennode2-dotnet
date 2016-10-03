package com.windsor.node.plugin.rcra52.solicit;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestType;

import javax.persistence.Query;
import javax.persistence.criteria.CriteriaQuery;
import java.util.Date;

public class SolicitOpFAByHandler extends SolicitOperation {

    public static final String SERVICE_NAME = "SolicitOpFAByHandler";
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(SERVICE_NAME);
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Solicits FA Data by Handler from the RCRAInfo service.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(SolicitOperation.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public SolicitRequestType getRequestType() {
        return SolicitRequestType.FA_BY_HANDLER;
    }

    @Override
    public SolicitRequest handleGetRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams) {

        String handlerId = namedParams.get(SolicitOperation.PARAM_HANDLER_ID.getName()).toString();
        String changeDate = namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName()).toString();

        if(getUseHistory() != null && getUseHistory()) {
            if(getSolicitHistoryLast() != null) {
                changeDate = getSolicitHistoryLast().getRunDateFormatted();
            }
        }

        return requestFactory.getFADataByHandler(handlerId, changeDate);
    }

    @Override
    public Query getCleanupQuery() {
        return (getTargetEntityManager().createQuery("from FinancialAssuranceFacilitySubmissionDataType where id > 0"));
    }
}
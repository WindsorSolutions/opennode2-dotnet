package com.windsor.node.plugin.rcra52.solicit;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.plugin.rcra52.domain.generated.CMEFacilitySubmissionDataType;
import com.windsor.node.plugin.rcra52.domain.generated.HazardousWasteCMESubmissionDataType;
import com.windsor.node.plugin.rcra52.domain.generated.ViolationDataType;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestType;

import javax.persistence.Query;
import javax.persistence.criteria.CriteriaQuery;
import java.util.Date;
import java.util.List;

public class SolicitOpCEByState extends SolicitOperation {

    public static final String SERVICE_NAME = "SolicitOpCEByState";
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(SERVICE_NAME);
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Solicits CE Data by State from the RCRAInfo service.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(SolicitOperation.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public SolicitRequestType getRequestType() {
        return SolicitRequestType.CE_BY_STATE;
    }

    @Override
    public SolicitRequest handleGetRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams) {

        String state = namedParams.get(SolicitOperation.PARAM_STATE.getName()).toString();
        String changeDate = namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName()).toString();

        if(getUseHistory() != null && getUseHistory()) {
            if(getSolicitHistoryLast() != null) {
                changeDate = getSolicitHistoryLast().getRunDateFormatted();
            }
        }

        return requestFactory.getCEByState(state, changeDate);
    }

    @Override
    public Query getCleanupQuery() {
        return (getTargetEntityManager().createQuery("from HazardousWasteCMESubmissionDataType where id > 0"));
    }
}
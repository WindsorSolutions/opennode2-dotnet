package com.windsor.node.plugin.rcra52.solicit;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.plugin.rcra52.domain.generated.HazardousSecondaryMaterialActivityDataType;
import com.windsor.node.plugin.rcra52.domain.generated.HazardousSecondaryMaterialActivityDataType_;
import com.windsor.node.plugin.rcra52.domain.generated.HazardousWasteHandlerSubmissionDataType;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestType;

import javax.persistence.Query;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import java.util.Date;
import java.util.List;

public class SolicitOpHDByState extends SolicitOperation {

    public static final String SERVICE_NAME = "SolicitOpHDByState";
    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR =
            new PluginServiceImplementorDescriptor();

    static {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(SERVICE_NAME);
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Solicits HD Data by State from the RCRAInfo service.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(SolicitOperation.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription() {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public SolicitRequestType getRequestType() {
        return SolicitRequestType.HD_BY_STATE;
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

        return requestFactory.getHDDataByState(state, changeDate);
    }

    @Override
    public Query getCleanupQuery() {
        return (getTargetEntityManager().createQuery("from HazardousWasteHandlerSubmissionDataType where id > 0"));
    }
}
package com.windsor.node.plugin.rcra54.solicit;

import javax.persistence.Query;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.plugin.rcra54.Rcra54OutboundException;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequestType;

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
    public SolicitRequest handleGetRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams)
            throws Rcra54OutboundException{

        String state = null;
        String changeDate = null;

        if(namedParams.get(SolicitOperation.PARAM_STATE_REQ.getName()) != null) {
            state = namedParams.get(SolicitOperation.PARAM_STATE_REQ.getName()).toString();
        }

        if(state == null) {
            throw new Rcra54OutboundException("The state parameter is required in order to solicit data from the " +
            "network partner!");
        }

        if(namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName()) != null) {
            changeDate = namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName()).toString();
        }

        if(getUseHistory() != null && getUseHistory()) {

            if(getSolicitHistoryLast() != null) {

                changeDate = getSolicitHistoryLast().getRunDateFormatted();
            }
        }

        if(getUseHistory() != null && getUseHistory() && changeDate == null) {
            throw new Rcra54OutboundException("The solicit request cannot be created without a change date! The \"Use " +
                    "solicit history\" flag is set to \"" + getUseHistory() + "\" but there is no solicit history records in " +
                    "the database and the change date is set to \"" + changeDate + "\".");
        }

        return requestFactory.getHDDataByState(state, changeDate);
    }

    @Override
    public Query getCleanupQuery() {
        return (getTargetEntityManager().createQuery("from HazardousWasteHandlerSubmissionDataType where id > 0"));
    }
}
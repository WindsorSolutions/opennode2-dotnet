package com.windsor.node.plugin.uic2;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;

public enum OperationType {

    DELETE_INSERT(new PluginServiceImplementorDescriptor("Delete-Insert",
            "Replace UIC data", "2.0",
            UICGetDeleteInsertSubmission.class.getCanonicalName()),
            RequestType.Solicit, ServiceType.SOLICIT);

    private PluginServiceImplementorDescriptor pluginDescriptor;
    private RequestType requestType;
    private ServiceType serviceType;

    OperationType(PluginServiceImplementorDescriptor pluginDescriptor, RequestType requestType, ServiceType serviceType) {
        this.pluginDescriptor = pluginDescriptor;
        this.requestType = requestType;
        this.serviceType = serviceType;
    }

    public PluginServiceImplementorDescriptor getPluginDescriptor() {
        return pluginDescriptor;
    }

    public RequestType getRequestType() {
        return requestType;
    }

    public ServiceType getServiceType() {
        return serviceType;
    }

}

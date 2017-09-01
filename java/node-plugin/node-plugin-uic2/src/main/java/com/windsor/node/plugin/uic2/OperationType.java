package com.windsor.node.plugin.uic2;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;

public enum OperationType {

    DELETE_INSERT(new PluginServiceImplementorDescriptor("UIC",
            "Replace UIC data", "2.0",
            UICGetDeleteInsertSubmission.class.getCanonicalName()),
            "Delete - Insert",
            RequestType.Submit, ServiceType.SUBMIT);

    private PluginServiceImplementorDescriptor pluginDescriptor;
    private String payloadOperation;
    private RequestType requestType;
    private ServiceType serviceType;

    OperationType(PluginServiceImplementorDescriptor pluginDescriptor, String payloadOperation, RequestType requestType, ServiceType serviceType) {
        this.pluginDescriptor = pluginDescriptor;
        this.payloadOperation = payloadOperation;
        this.requestType = requestType;
        this.serviceType = serviceType;
    }

    public PluginServiceImplementorDescriptor getPluginDescriptor() {
        return pluginDescriptor;
    }

    public String getPayloadOperation() {
        return payloadOperation;
    }

    public RequestType getRequestType() {
        return requestType;
    }

    public ServiceType getServiceType() {
        return serviceType;
    }

}

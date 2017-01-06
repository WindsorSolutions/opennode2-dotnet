package com.windsor.node.plugin.rcra54.domain;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.rcra54.service.RCRACmeExtractAndSubmission;
import com.windsor.node.plugin.rcra54.service.RCRACorrectiveActionExtractAndSubmission;
import com.windsor.node.plugin.rcra54.service.RCRAFinancialAssuranceExtractAndSubmission;
import com.windsor.node.plugin.rcra54.service.RCRAGisExtractAndSubmission;
import com.windsor.node.plugin.rcra54.service.RCRAHandlerExtractAndSubmission;
import com.windsor.node.plugin.rcra54.service.RCRAPermittingExtractAndSubmission;

public enum OperationType {

    CME(new PluginServiceImplementorDescriptor("Submit RCRA CME Data",
            "Flow RCRA CME data", "5.4",
            RCRACmeExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|CE",
    		"CE",
            RequestType.Submit, ServiceType.TASK),
    CORRECTIVE_ACTION(new PluginServiceImplementorDescriptor("Submit RCRA Corrective Action Data",
            "Flow RCRA corrective action data", "5.4",
            RCRACorrectiveActionExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|CA",
    		"CA",
            RequestType.Submit, ServiceType.TASK),
    FINANCIAL_ASSURANCE(new PluginServiceImplementorDescriptor("Submit RCRA Financial Assurance Data",
            "Flow RCRA financial assurance data", "5.4",
            RCRAFinancialAssuranceExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|FA",
    		"FA",
            RequestType.Submit, ServiceType.TASK),
    GIS(new PluginServiceImplementorDescriptor("Submit RCRA GIS Data",
            "Flow RCRA GIS data", "5.4",
            RCRAGisExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|GI",
    		"GI",
            RequestType.Submit, ServiceType.TASK),
    HANDLER(new PluginServiceImplementorDescriptor("Submit RCRA Handler Data",
            "Flow RCRA handler data", "5.4",
            RCRAHandlerExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|HD",
    		"HD",
            RequestType.Submit, ServiceType.TASK),
    PERMITTING(new PluginServiceImplementorDescriptor("Submit RCRA Permitting Data",
            "Flow RCRA permitting data", "5.4",
            RCRAPermittingExtractAndSubmission.class.getCanonicalName()),
    		"RCRA-Transactional|PM",
    		"PM",
            RequestType.Submit, ServiceType.TASK),
    GET_STATUS(new PluginServiceImplementorDescriptor("Get Status",
            "Get status for pending submissions", "5.4",
            RCRAPermittingExtractAndSubmission.class.getCanonicalName()),
    		null,
    		null,
            RequestType.Query, ServiceType.TASK);

    private PluginServiceImplementorDescriptor pluginDescriptor;
    private String payloadOperation;
    private String code;
    private RequestType requestType;
    private ServiceType serviceType;

    OperationType(PluginServiceImplementorDescriptor pluginDescriptor, String payloadOperation, String code, RequestType requestType, ServiceType serviceType) {
        this.pluginDescriptor = pluginDescriptor;
        this.payloadOperation = payloadOperation;
        this.code = code;
        this.requestType = requestType;
        this.serviceType = serviceType;
    }

    public PluginServiceImplementorDescriptor getPluginDescriptor() {
        return pluginDescriptor;
    }

    public String getPayloadOperation() {
		return payloadOperation;
	}

	public String getCode() {
		return code;
	}

	public RequestType getRequestType() {
        return requestType;
    }

    public ServiceType getServiceType() {
        return serviceType;
    }

}
package com.windsor.node.plugin.rcra54.status;

import net.exchangenetwork.schema.node._2.GetStatus;
import net.exchangenetwork.schema.node._2.ObjectFactory;
import net.exchangenetwork.schema.node._2.StatusResponseType;
import net.exchangenetwork.wsdl.node._2.NetworkNode2;
import net.exchangenetwork.wsdl.node._2.NetworkNodePortType2;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;

import javax.xml.ws.BindingProvider;

/**
 * Provides an object that encapsulates a RCRAInfo "get status" request.
 */
public class GetStatusRequest {

    private final static String DATA_FLOW = "RCRA";

    private String endpoint;
    private String securityToken;
    private String transactionId;

    public GetStatusRequest(String endpoint, String securityToken, String transactionId) {
        this.endpoint = endpoint;
        this.securityToken = securityToken;
        this.transactionId = transactionId;
    }

    public String getSecurityToken() {
        return securityToken;
    }

    public void setSecurityToken(String securityToken) {
        this.securityToken = securityToken;
    }

    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public StatusResponseType execute() throws NodeFaultMessage {
        NetworkNode2 service = new NetworkNode2();
        NetworkNodePortType2 port = service.getNetworkNodePort2();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(BindingProvider.ENDPOINT_ADDRESS_PROPERTY, endpoint.toString());
        return port.getStatus(getRequest());
    }

    private GetStatus getRequest() {
        ObjectFactory objectFactory = new ObjectFactory();
        GetStatus request = objectFactory.createGetStatus();
        request.setSecurityToken(securityToken);
        request.setTransactionId(transactionId);
        return request;
    }
}

package com.windsor.node.plugin.rcra52.solicit.request;

import net.exchangenetwork.schema.node._2.ObjectFactory;
import net.exchangenetwork.schema.node._2.ParameterType;
import net.exchangenetwork.schema.node._2.Solicit;
import net.exchangenetwork.schema.node._2.StatusResponseType;
import net.exchangenetwork.wsdl.node._2.NetworkNode2;
import net.exchangenetwork.wsdl.node._2.NetworkNodePortType2;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;

import javax.xml.ws.BindingProvider;
import java.util.List;

/**
 * Provides an object that encapsulates a RCRAInfo solicit request.
 */
public class SolicitRequest {

    private final static String DATA_FLOW = "RCRA";

    private String endpoint;
    private SolicitRequestType type;
    private List<ParameterType> parameters;
    private String securityToken;
    private String recipient;

    public SolicitRequest(String endpoint, SolicitRequestType type, List<ParameterType> parameters) {
        this(endpoint, null, null, type, parameters);
    }

    public SolicitRequest(String endpoint, String securityToken, SolicitRequestType type,
                          List<ParameterType> parameters) {
        this(endpoint, securityToken, null, type, parameters);
    }

    public SolicitRequest(String endpoint, String securityToken, String recipient, SolicitRequestType type,
                          List<ParameterType> parameters) {
        this.endpoint = endpoint;
        this.securityToken = securityToken;
        this.recipient = recipient;
        this.type = type;
        this.parameters = parameters;
    }

    public SolicitRequestType getType() {
        return type;
    }

    public void setType(SolicitRequestType type) {
        this.type = type;
    }

    public List<ParameterType> getParameters() {
        return parameters;
    }

    public void setParameters(List<ParameterType> parameters) {
        this.parameters = parameters;
    }

    public String getSecurityToken() {
        return securityToken;
    }

    public void setSecurityToken(String securityToken) {
        this.securityToken = securityToken;
    }

    public String getRecipient() {
        return recipient;
    }

    public void setRecipient(String recipient) {
        this.recipient = recipient;
    }

    public StatusResponseType execute() throws NodeFaultMessage {
        NetworkNode2 service = new NetworkNode2();
        NetworkNodePortType2 port = service.getNetworkNodePort2();
        BindingProvider bindingProvider = (BindingProvider) port;
        bindingProvider.getRequestContext().put(BindingProvider.ENDPOINT_ADDRESS_PROPERTY, endpoint.toString());
        return port.solicit(getRequest());
    }

    private Solicit getRequest() {
        ObjectFactory objectFactory = new ObjectFactory();
        Solicit request = objectFactory.createSolicit();
        request.setSecurityToken(securityToken);
        request.setRequest(type.toString());
        request.setDataflow(DATA_FLOW);
        request.getParameters().addAll(parameters);
        return request;
    }
}

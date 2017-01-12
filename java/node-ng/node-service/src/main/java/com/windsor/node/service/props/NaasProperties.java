package com.windsor.node.service.props;

import java.io.Serializable;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

import com.windsor.node.domain.NaasType;

@Configuration
@PropertySource(value = {"classpath:naas.properties", "file:/var/opennode2_home/conf/naas.properties"}, ignoreResourceNotFound = true)
public class NaasProperties implements Serializable {
	
	@Value("${id.node}")
	private String nodeId;

	@Value("${url.valid.endpoint}")
	private String validatorEndpointUrl;
	
	@Value("${url.naas.auth}")
	private String naasAuthenticationUrl;
	
	@Value("${url.naas.mgr}")
	private String naasUserManagerUrl;

	@Value("${naas.runtime.username}")
	private String naasRuntimeUsername;
	
	@Value("${naas.runtime.password}")
	private String naasRuntimePassword;
	
	@Value("${naas.runtime.authMeth}")
	private String naasRuntimeAuthenticationMethod;
	
	@Value("${naas.admin.username}")
	private String naasAdminUsername;

	@Value("${naas.admin.password}")
	private String naasAdminPassword;
	
	@Value("${naas.admin.authMeth}")
	private String naasAdminAuthenticationMethod;
	
    private NaasType naasType;
    
    @PostConstruct
    void determineNaasType() {
    	naasType = NaasType.getNaasType(getNaasAuthenticationUrl())
    			.orElseThrow(() -> new RuntimeException("Unable to determine the NAAS type"));
    }

	public String getNodeId() {
		return nodeId;
	}

	public void setNodeId(String nodeId) {
		this.nodeId = nodeId;
	}

	public String getValidatorEndpointUrl() {
		return validatorEndpointUrl;
	}

	public void setValidatorEndpointUrl(String validatorEndpointUrl) {
		this.validatorEndpointUrl = validatorEndpointUrl;
	}

	public String getNaasAuthenticationUrl() {
		return naasAuthenticationUrl;
	}

	public void setNaasAuthenticationUrl(String naasAuthenticationUrl) {
		this.naasAuthenticationUrl = naasAuthenticationUrl;
	}

	public String getNaasUserManagerUrl() {
		return naasUserManagerUrl;
	}

	public void setNaasUserManagerUrl(String naasUserManagerUrl) {
		this.naasUserManagerUrl = naasUserManagerUrl;
	}

	public String getNaasRuntimeUsername() {
		return naasRuntimeUsername;
	}

	public void setNaasRuntimeUsername(String naasRuntimeUsername) {
		this.naasRuntimeUsername = naasRuntimeUsername;
	}

	public String getNaasRuntimePassword() {
		return naasRuntimePassword;
	}

	public void setNaasRuntimePassword(String naasRuntimePassword) {
		this.naasRuntimePassword = naasRuntimePassword;
	}

	public String getNaasRuntimeAuthenticationMethod() {
		return naasRuntimeAuthenticationMethod;
	}

	public void setNaasRuntimeAuthenticationMethod(String naasRuntimeAuthenticationMethod) {
		this.naasRuntimeAuthenticationMethod = naasRuntimeAuthenticationMethod;
	}

	public String getNaasAdminUsername() {
		return naasAdminUsername;
	}

	public void setNaasAdminUsername(String naasAdminUsername) {
		this.naasAdminUsername = naasAdminUsername;
	}

	public String getNaasAdminPassword() {
		return naasAdminPassword;
	}

	public void setNaasAdminPassword(String naasAdminPassword) {
		this.naasAdminPassword = naasAdminPassword;
	}

	public String getNaasAdminAuthenticationMethod() {
		return naasAdminAuthenticationMethod;
	}

	public void setNaasAdminAuthenticationMethod(String naasAdminAuthenticationMethod) {
		this.naasAdminAuthenticationMethod = naasAdminAuthenticationMethod;
	}

	public NaasType getNaasType() {
		return naasType;
	}

	public void setNaasType(NaasType naasType) {
		this.naasType = naasType;
	}
    
}

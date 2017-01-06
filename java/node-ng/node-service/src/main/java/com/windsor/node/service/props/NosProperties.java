package com.windsor.node.service.props;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

@Configuration
@PropertySource("classpath:nos.properties")
public class NosProperties {

	@Value("${path.node.home}")
	private String nodeHome;
	
	@Value("${url.node.base}")
	private String nodeBaseUrl;	
	
	@Value("${url.external.admin}")
	private String externalAdminUrl;
	                                                                                                                                                           
	@Value("${request.ip.header.name}")
	private String ipHeaderName;

	@Value("${node.news.url:'https://www.windsorsolutions.biz/on2rss/Feed.aspx'}")
	private String nodeNewsUrl;
	
	@Value("${node.news.max.items:4}")
	private int maxNewsItems;
	
	@Value("${manage.user.requests}")
	private boolean manageUserRequests;
	
	@Value("${path.plugin.dir}")
	private String pluginDirectory;
	
	@Value("${path.doc.dir}")
	private String documentDirectory;
	
	@Value("${path.temp.dir}")
	private String tempDirectory;
	
	@Value("${path.log.dir}")
	private String logDirectory;

	@Value("${url.node.admin}")
	private String nodeAdminUrl;
	
	@Value("${url.node1}")
	private String node1Url;
	
	@Value("${url.node2}")
	private String node2Url;

	@Value("${url.node.endpoint1Client}")
	private String nodeEndpoint1ClientUrl;
	
	@Value("${url.node.endpoint2Client}")
	private String nodeEndpoint2ClientUrl;
	
	@Value("${url.node.endpoint1}")
	private String nodeEndpoint1;
	
	@Value("${url.node.endpoint2}")
	private String nodeEndpoint2;
	
	@Value("${wnos.endpoint.host}")
	private String wnosHostEndpoint;

	@Value("${smtp.gateway}")
	private String smtpGateway;
	
	@Value("${smtp.gateway.port}")
	private int smtpGatewayPort;
	
	@Value("${smtp.from.email}")
	private String fromEmailAddress;
	
	@Value("${smtp.username}")
	private String smtpUsername;
	
	@Value("${smtp.password}")
	private String smtpPassword;
	
	@Value("${smtp.auth}")
	private boolean smtpAuthorization;
	
	@Value("${smtp.starttls.enable}")
	private boolean smptStartTLSEnabled;
	
	@Value("${smtp.starttls.required}")
	private boolean smtpStartTLSRequired;
	
//	@Value("${ssl.config}")
//	private String sslConfig;

	@Value("${ip.whitelist.subnet}")
	private String ipWhitelistSubnet;

	@Value("${node.name}")
	private String nodeName;

	@Value("${organization.identifier}")
	private String organizationIdentifier;

	@Value("${node.deployment.type}")
	private String deploymentType;

	@Value("${public.v2.endpoint.url}")
	private String urlEndpointV2;
	
	public NosProperties() {
		super();
	}

	public String getNodeHome() {
		return nodeHome;
	}

	public void setNodeHome(String nodeHome) {
		this.nodeHome = nodeHome;
	}

	public String getNodeBaseUrl() {
		return nodeBaseUrl;
	}

	public void setNodeBaseUrl(String nodeBaseUrl) {
		this.nodeBaseUrl = nodeBaseUrl;
	}

	public String getExternalAdminUrl() {
		return externalAdminUrl;
	}

	public void setExternalAdminUrl(String externalAdminUrl) {
		this.externalAdminUrl = externalAdminUrl;
	}

	public String getIpHeaderName() {
		return ipHeaderName;
	}

	public void setIpHeaderName(String ipHeaderName) {
		this.ipHeaderName = ipHeaderName;
	}

	public String getNodeNewsUrl() {
		return nodeNewsUrl;
	}

	public void setNodeNewsUrl(String nodeNewsUrl) {
		this.nodeNewsUrl = nodeNewsUrl;
	}

	public int getMaxNewsItems() {
		return maxNewsItems;
	}

	public void setMaxNewsItems(int maxNewsItems) {
		this.maxNewsItems = maxNewsItems;
	}

	public boolean isManageUserRequests() {
		return manageUserRequests;
	}

	public void setManageUserRequests(boolean manageUserRequests) {
		this.manageUserRequests = manageUserRequests;
	}

	public String getPluginDirectory() {
		return pluginDirectory;
	}

	public void setPluginDirectory(String pluginDirectory) {
		this.pluginDirectory = pluginDirectory;
	}

	public String getDocumentDirectory() {
		return documentDirectory;
	}

	public void setDocumentDirectory(String documentDirectory) {
		this.documentDirectory = documentDirectory;
	}

	public String getTempDirectory() {
		return tempDirectory;
	}

	public void setTempDirectory(String tempDirectory) {
		this.tempDirectory = tempDirectory;
	}

	public String getLogDirectory() {
		return logDirectory;
	}

	public void setLogDirectory(String logDirectory) {
		this.logDirectory = logDirectory;
	}

	public String getNodeAdminUrl() {
		return nodeAdminUrl;
	}

	public void setNodeAdminUrl(String nodeAdminUrl) {
		this.nodeAdminUrl = nodeAdminUrl;
	}

	public String getNode1Url() {
		return node1Url;
	}

	public void setNode1Url(String node1Url) {
		this.node1Url = node1Url;
	}

	public String getNode2Url() {
		return node2Url;
	}

	public void setNode2Url(String node2Url) {
		this.node2Url = node2Url;
	}

	public String getNodeEndpoint1ClientUrl() {
		return nodeEndpoint1ClientUrl;
	}

	public void setNodeEndpoint1ClientUrl(String nodeEndpoint1ClientUrl) {
		this.nodeEndpoint1ClientUrl = nodeEndpoint1ClientUrl;
	}

	public String getNodeEndpoint2ClientUrl() {
		return nodeEndpoint2ClientUrl;
	}

	public void setNodeEndpoint2ClientUrl(String nodeEndpoint2ClientUrl) {
		this.nodeEndpoint2ClientUrl = nodeEndpoint2ClientUrl;
	}

	public String getNodeEndpoint1() {
		return nodeEndpoint1;
	}

	public void setNodeEndpoint1(String nodeEndpoint1) {
		this.nodeEndpoint1 = nodeEndpoint1;
	}

	public String getNodeEndpoint2() {
		return nodeEndpoint2;
	}

	public void setNodeEndpoint2(String nodeEndpoint2) {
		this.nodeEndpoint2 = nodeEndpoint2;
	}

	public String getWnosHostEndpoint() {
		return wnosHostEndpoint;
	}

	public void setWnosHostEndpoint(String wnosHostEndpoint) {
		this.wnosHostEndpoint = wnosHostEndpoint;
	}

	public String getSmtpGateway() {
		return smtpGateway;
	}

	public void setSmtpGateway(String smtpGateway) {
		this.smtpGateway = smtpGateway;
	}

	public int getSmtpGatewayPort() {
		return smtpGatewayPort;
	}

	public void setSmtpGatewayPort(int smtpGatewayPort) {
		this.smtpGatewayPort = smtpGatewayPort;
	}

	public String getFromEmailAddress() {
		return fromEmailAddress;
	}

	public void setFromEmailAddress(String fromEmailAddress) {
		this.fromEmailAddress = fromEmailAddress;
	}

	public String getSmtpUsername() {
		return smtpUsername;
	}

	public void setSmtpUsername(String smtpUsername) {
		this.smtpUsername = smtpUsername;
	}

	public String getSmtpPassword() {
		return smtpPassword;
	}

	public void setSmtpPassword(String smtpPassword) {
		this.smtpPassword = smtpPassword;
	}

	public boolean isSmtpAuthorization() {
		return smtpAuthorization;
	}

	public void setSmtpAuthorization(boolean smtpAuthorization) {
		this.smtpAuthorization = smtpAuthorization;
	}

	public boolean isSmptStartTLSEnabled() {
		return smptStartTLSEnabled;
	}

	public void setSmptStartTLSEnabled(boolean smptStartTLSEnabled) {
		this.smptStartTLSEnabled = smptStartTLSEnabled;
	}

	public boolean isSmtpStartTLSRequired() {
		return smtpStartTLSRequired;
	}

	public void setSmtpStartTLSRequired(boolean smtpStartTLSRequired) {
		this.smtpStartTLSRequired = smtpStartTLSRequired;
	}

//	public String getSslConfig() {
//		return sslConfig;
//	}
//
//	public void setSslConfig(String sslConfig) {
//		this.sslConfig = sslConfig;
//	}

	public String getIpWhitelistSubnet() {
		return ipWhitelistSubnet;
	}

	public void setIpWhitelistSubnet(String ipWhitelistSubnet) {
		this.ipWhitelistSubnet = ipWhitelistSubnet;
	}

	public String getNodeName() {
		return nodeName;
	}

	public void setNodeName(String nodeName) {
		this.nodeName = nodeName;
	}

	public String getOrganizationIdentifier() {
		return organizationIdentifier;
	}

	public void setOrganizationIdentifier(String organizationIdentifier) {
		this.organizationIdentifier = organizationIdentifier;
	}

	public String getDeploymentType() {
		return deploymentType;
	}

	public void setDeploymentType(String deploymentType) {
		this.deploymentType = deploymentType;
	}

	public String getUrlEndpointV2() {
		return urlEndpointV2;
	}

	public void setUrlEndpointV2(String urlEndpointV2) {
		this.urlEndpointV2 = urlEndpointV2;
	}
}

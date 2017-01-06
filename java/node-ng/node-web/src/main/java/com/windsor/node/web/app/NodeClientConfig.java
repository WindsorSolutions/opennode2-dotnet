package com.windsor.node.web.app;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Arrays;
import java.util.List;

import org.apache.axis.AxisFault;
import org.apache.commons.httpclient.HttpClient;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.remoting.httpinvoker.HttpComponentsHttpInvokerRequestExecutor;
import org.springframework.remoting.httpinvoker.HttpInvokerProxyFactoryBean;

import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.conf.NOSConfig;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.naas.auth.NetworkNodePortType;
import com.windsor.node.service.helper.naas.auth.NetworkSecurityBindingStub;
import com.windsor.node.service.helper.naas.usrmgr.UserMgrBindingStub;
import com.windsor.node.service.helper.naas.usrmgr.UserMgrPortType_PortType;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.node.service.props.NosProperties;

@Configuration
public class NodeClientConfig {

    @Bean
    public HttpClient getHttpClient() {
        return new HttpClient();
    }

    @Bean(name = "httpInvoker1")
    public HttpComponentsHttpInvokerRequestExecutor getHttpInvoker1() {
        HttpComponentsHttpInvokerRequestExecutor e = new HttpComponentsHttpInvokerRequestExecutor();
        e.setReadTimeout(0);
        return e;
    }

    @Bean(name = "httpInvoker2")
    public HttpComponentsHttpInvokerRequestExecutor getHttpInvoker2() {
        HttpComponentsHttpInvokerRequestExecutor e = new HttpComponentsHttpInvokerRequestExecutor();
        e.setReadTimeout(0);
        return e;
    }

    @Bean(name = "nodeClient11")
    public HttpInvokerProxyFactoryBean getNodeClient11(NosProperties props) {
        HttpInvokerProxyFactoryBean bean = new HttpInvokerProxyFactoryBean();
        bean.setServiceUrl(props.getNodeEndpoint1ClientUrl());
        bean.setServiceInterface(NodeClientService.class);
        bean.setHttpInvokerRequestExecutor(getHttpInvoker1());
        return bean;
    }

    @Bean(name = "nodeClient21")
    public HttpInvokerProxyFactoryBean getNodeClient21(NosProperties props) {
        HttpInvokerProxyFactoryBean bean = new HttpInvokerProxyFactoryBean();
        bean.setServiceUrl(props.getNodeEndpoint2ClientUrl());
        bean.setServiceInterface(NodeClientService.class);
        bean.setHttpInvokerRequestExecutor(getHttpInvoker2());
        return bean;
    }

    @Bean
    public NAASAccount getAdminAccountInfo(NaasProperties props) {
        NAASAccount account = new NAASAccount();
        account.setUsername(props.getNaasAdminUsername());
        account.setPassword(props.getNaasAdminPassword());
        account.setAuthMethod(props.getNaasAdminAuthenticationMethod());
        account.setDomain("default");
        return account;
    }

    @Bean
    public NAASAccount getRuntimeAccountInfo(NaasProperties props) {
        NAASAccount account = new NAASAccount();
        account.setUsername(props.getNaasRuntimeUsername());
        account.setPassword(props.getNaasRuntimePassword());
        account.setAuthMethod(props.getNaasRuntimeAuthenticationMethod());
        account.setDomain("default");
        return account;
    }

    @Bean
    public NAASConfig getNaasConfig(NaasProperties props) throws MalformedURLException {
        NAASConfig config = new NAASConfig();
        config.setNodeId(props.getNodeId());
        config.setAuthEndpoint(new URL(props.getNaasAuthenticationUrl()));
        config.setMgrEndpoint(new URL(props.getNaasUserManagerUrl()));
        config.setRuntimeAccount(getRuntimeAccountInfo(props));
        config.setAdminAccount(getAdminAccountInfo(props));
        return config;
    }

    @SuppressWarnings("deprecation")
    @Bean
    public NOSConfig getNosConfig(NosProperties nosProps) {
        NOSConfig config = new NOSConfig();
        
        config.setWebServiceEndpoint1(nosProps.getNodeEndpoint1());
        config.setWebServiceEndpoint2(nosProps.getNodeEndpoint2());
        config.setAdminUrl(nosProps.getNodeAdminUrl());
        config.setNodeAdminEmail(nosProps.getFromEmailAddress());
        List<String> whiteList = Arrays.asList("127.0.0.1", "70.102.94.202", "134.179.227.*", "134.179.33.*", "134.179.115.*", nosProps.getIpWhitelistSubnet());
        config.setAdminWhiteList(whiteList);
        config.setPluginDir(new File(nosProps.getPluginDirectory()));
        config.setTempDir(new File(nosProps.getTempDirectory()));
        config.setSkipNaas(false);
        return config;
    }

    @Bean
    public NodeClientFactory getNodeClientFactory(NosProperties nosProps, NaasProperties naasProps) throws MalformedURLException {
        NodeClientFactory factory = new NodeClientFactory();
        factory.setNaasConfig(getNaasConfig(naasProps));
        factory.setNosConfig(getNosConfig(nosProps));
        factory.setClient11((NodeClientService) getNodeClient11(nosProps).getObject());
        factory.setClient21((NodeClientService) getNodeClient21(nosProps).getObject());
        return factory;
    }

    @Bean
    public NetworkNodePortType getNetworkNodePortType(NaasProperties naasProps) throws AxisFault, MalformedURLException {
        return new NetworkSecurityBindingStub(new URL(naasProps.getNaasAuthenticationUrl()), null);
    }

    @Bean
    public UserMgrPortType_PortType getUserMgrPortType(NaasProperties naasProps) throws AxisFault, MalformedURLException {
        return new UserMgrBindingStub(new URL(naasProps.getNaasUserManagerUrl()), null);
    }

}

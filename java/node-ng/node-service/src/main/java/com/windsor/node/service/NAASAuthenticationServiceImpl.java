package com.windsor.node.service;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.nio.file.Files;
import java.nio.file.Path;
import java.rmi.RemoteException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.domain.HeartbeatInfo;
import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.node.service.helper.naas.auth.AuthMethod;
import com.windsor.node.service.helper.naas.auth.NetworkNodePortType;
import com.windsor.node.service.helper.naas.usrmgr.UserMgrPortType_PortType;
import com.windsor.node.service.helper.naas.usrmgr.UserType;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.node.service.props.NosProperties;
import com.windsor.node.ws1.client.NetworkNode11Client;
import com.windsor.node.ws2.client.NetworkNode21Client;

/**
 * Provides an implementation of the NAAS authentication service.
 */
@Service
public class NAASAuthenticationServiceImpl implements NAASAuthenticationService {

    /**
     * NAAS authentication method.
     */
    private static AuthMethod AUTH_METHOD = AuthMethod.password;

    @Autowired
    private NetworkNodePortType networkNode;

    @Autowired
    private UserMgrPortType_PortType userManager;

    @Autowired
    private NaasProperties naasProperties;

    @Autowired
    private NosProperties nosProperties;
    
    @Autowired
    private ActivityService activityService;

    public NAASAuthenticationServiceImpl() {

    }

    @Override
    public String validateAccount(String name, String password, String clientIPAddress)
            throws RemoteException, MalformedURLException {

        return networkNode.centralAuth(name, password, AUTH_METHOD, clientIPAddress, "");
    }

    @Override
    public String validateToken(String token, String clientHostIP) throws RemoteException, MalformedURLException {

        return networkNode.validate(token, clientHostIP, "");
    }

    @Override
    public String changePassword(String userEmail, String oldPassword, String newPassword) throws NaasException {
        try {
            String result = userManager.changePwd(userEmail, oldPassword, newPassword);
            activityService.passwordChanged(userEmail, result);
            return result;
        } catch (RemoteException e) {
            throw new NaasException(e.getMessage(), e);
        }
    }

    @Override
    public String addUser(String userEmail, String userPwd, Account adminAccount) throws NaasException {
        try {
            String result = userManager.addUser(naasProperties.getNaasAdminUsername(),
            		naasProperties.getNaasAdminPassword(), userEmail, UserType.user, userPwd, userPwd,
                    naasProperties.getNodeId());
            activityService.userAdded(userEmail, result, adminAccount);
            return result;
        } catch (RemoteException e) {
            throw new NaasException(e.getMessage(), e);
        }
    }

    @Override
    public String changePassword(String username, String newPassword, Account adminAccount) throws NaasException {
        try {
            String result = userManager.updateUser(naasProperties.getNaasAdminUsername(),
            		naasProperties.getNaasAdminPassword(), username, UserType.user, newPassword,
            		naasProperties.getNaasAdminUsername(), naasProperties.getNodeId());
            activityService.passwordChanged(username, result, adminAccount);
            return result;
        } catch (RemoteException e) {
            throw new NaasException(e.getMessage(), e);
        }
    }

    @Override
    public HeartbeatInfo getHeartbeatInfo(PartnerVersion partnerVersion) {
        return PartnerVersion.REST.equals(partnerVersion) ? restAvailable() : nonRestAvailable(partnerVersion);
    }

    private HeartbeatInfo restAvailable() {
        String url = getEndpointUrl(PartnerVersion.REST);
        boolean validated = getBytesFromURL(getEndpointUrl(PartnerVersion.REST)) != null;
        return new HeartbeatInfo(PartnerVersion.REST, url, validated);
    }

    private HeartbeatInfo nonRestAvailable(PartnerVersion partnerVersion) {
        File fileTemp = null;
        String url = getEndpointUrl(partnerVersion);
        boolean validated = false;
        try {
            NodeClientService client = newNodeClient(partnerVersion);
            Path pathTemp = Files.createTempDirectory("partner-test");
            fileTemp = new File(pathTemp.toFile().getAbsolutePath());

            client.configure(new URL(url), nosProperties.getExternalAdminUrl(),
                    getNaasAccount(), fileTemp);
            validated = client.nodePing("Ping") != null;
        } catch (Exception e) {
            // error
        } finally {
            if (fileTemp != null) {
                fileTemp.delete();
            }
        }
        return new HeartbeatInfo(partnerVersion, url, validated);
    }

    private NAASAccount getNaasAccount() {
        NAASAccount naasAccount = new NAASAccount();
        naasAccount.setAuthMethod(AuthMethod.password.getValue());
        naasAccount.setUsername(naasProperties.getNaasRuntimeUsername());
        naasAccount.setPassword(naasProperties.getNaasRuntimePassword());
        return naasAccount;
    }

    private NodeClientService newNodeClient(PartnerVersion partnerVersion) {
        NodeClientService client = null;
        switch (partnerVersion) {
        case TWO_DOT_ONE:
            client = new NetworkNode21Client();
            break;

        case ONE_DOT_ONE:
            client = new NetworkNode11Client();
            break;
        default:
            throw new RuntimeException("Unsupported partner version: " + partnerVersion);
        }
        return client;
    }

    private String getEndpointUrl(PartnerVersion partnerVersion) {
    	String admin = nosProperties.getExternalAdminUrl();
        int indexOfFinalSlash = admin.lastIndexOf("/");
        String baseUrl = admin.substring(0, indexOfFinalSlash);
        String url = null;
        switch (partnerVersion) {
        case ONE_DOT_ONE:
            url = baseUrl + "/" + "wne/services/v11";
            break;
        case TWO_DOT_ONE:
            url = baseUrl + "/" + "wne2/services/v21";
            break;
        case REST:
            url = baseUrl + "/" + "wnrest/services/NodePing";
            break;
        }
        return url;
    }

    public byte[] getBytesFromURL(String address) {
        try {
            URL url = new URL(address);
            URLConnection conn = url.openConnection();
            try (InputStream fis = conn.getInputStream();) {
                ByteArrayOutputStream byteArrOut = new ByteArrayOutputStream();
                int ln;
                byte[] buf = new byte[1024 * 12];
                while ((ln = fis.read(buf)) != -1) {
                    byteArrOut.write(buf, 0, ln);
                }
                return byteArrOut.toByteArray();
            }
        } catch (IOException e) {
            return null;
        }
    }

}

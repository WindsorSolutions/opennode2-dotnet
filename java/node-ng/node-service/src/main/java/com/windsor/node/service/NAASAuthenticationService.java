package com.windsor.node.service;

import java.net.MalformedURLException;
import java.rmi.RemoteException;

import com.windsor.node.domain.HeartbeatInfo;
import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.PartnerVersion;

/**
 * Provides the interface for the NAAS authentication service.
 */
public interface NAASAuthenticationService {

    /**
     * Validates the NAAS account name and password and returns a security token.
     *
     * @param name NAAS account name
     * @param password NAAS account password
     * @param clientIpAddress Client IP Address
     * @return NAAS Security Token
     * @throws RemoteException On problems communication with NAAS
     * @throws MalformedURLException On a bad NAAS endpoint URL
     */
    String validateAccount(String name, String password, String clientIpAddress)
            throws RemoteException, MalformedURLException;

    /**
     * Validates a NAAS security token and returns a new security token.
     *
     * @param token NAAS security token
     * @param clientHostIP Client IP Address
     * @return NAAS Security Token
     * @throws RemoteException On problems communicating with NAAS
     * @throws MalformedURLException On a bad NAAS enpoint URL
     */
    String validateToken(String token, String clientHostIP)
            throws RemoteException, MalformedURLException;

    String changePassword(String username, String oldPassword, String newPassword) throws NaasException;

    String addUser(String userEmail, String userPwd, Account adminUser) throws NaasException;

    String changePassword(String username, String newPassword, Account adminUser) throws NaasException;

    HeartbeatInfo getHeartbeatInfo(PartnerVersion partnerVersion);

}

/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.worker;

import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.NaasUserInfo;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.service.helper.UserManagerHelper;

public class NaasSyncTaskWorker extends NodeWorker implements InitializingBean {

    private AccountDao accountDao;
    private NAASConfig naasConfig;
    private UserManagerHelper userManager;
    private UserAccount adminAccout;

    /**
     * afterPropertiesSet
     */
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (accountDao == null) {
            throw new RuntimeException("AccountDao Not Set");
        }

        if (naasConfig == null) {
            throw new RuntimeException("NAASConfig Not Set");
        }

        if (userManager == null) {
            throw new RuntimeException("UserManager Not Set");
        }

        // get admin account
        adminAccout = accountDao.getByNAASAccount(naasConfig.getAdminAccount()
                .getUsername());

        if (adminAccout == null) {
            throw new RuntimeException("Null admin account for: "
                    + naasConfig.getAdminAccount().getUsername());
        }

    }

    /**
     * getNaasUsers
     * 
     * @return
     */
    private Map getNaasUsers() {
        Map map = new HashMap();
        List list = userManager.getUsers();
        if (list == null) {
            throw new RuntimeException("Null naas user list");
        }
        for (int i = 0; i < list.size(); i++) {
            NaasUserInfo user = (NaasUserInfo) list.get(i);
            String testName = user.getUserName().trim().toLowerCase();
            if (!map.containsKey(testName)) {
                map.put(testName, user);
            }
        }
        return map;
    }

    /**
     * getLocaActivelUsers
     * 
     * @return
     */
    private Map getLocaActivelUsers() {
        Map map = new HashMap();
        List list = accountDao.get(false, false);
        if (list == null) {
            throw new RuntimeException("Null db user list");
        }
        for (int i = 0; i < list.size(); i++) {
            UserAccount user = (UserAccount) list.get(i);
            String testName = user.getNaasUserName().trim().toLowerCase();
            if (!map.containsKey(testName)) {
                map.put(testName, user);
            }
        }
        return map;
    }

    /**
     * run
     */
    public void run() {

        Activity logEntry = new Activity();
        logEntry.setIp(getNosConfig().getLocalhostIp());
        logEntry.setType(ActivityType.INFO);
        logEntry.addEntry("Machine Id: " + getMachineId());
        logEntry.setModifiedById(adminAccout.getId());

        try {

            if (!getNosConfig().isSkipNaas()) {

                // Get all NAAS users
                logEntry.addEntry("Getting NAAS Users...");
                Map naasMap = getNaasUsers();
                logEntry.addEntry("Found: " + naasMap.size());
                logger.debug("Found: " + naasMap.size());

                // Get all local users
                logEntry.addEntry("Getting Db Users...");
                Map localUsers = getLocaActivelUsers();
                logEntry.addEntry("Found: " + localUsers.size());
                logger.debug("Found: " + localUsers.size() + " active users");

                // NAAS Connectivity Check
                if (naasMap.size() < (localUsers.size() / 2)) {

                    logEntry.addEntry("NAAS appears to have more than 50% "
                            + "less accounts than local Db. This is "
                            + "usually a sign of an error during the "
                            + "NAAS query (most likelly caused by "
                            + "network timeout).");

                    logEntry.addEntry("WNOS-NAAS sync process aborted.");

                } else {

                    // Load new NAAS users
                    int addedUsersCount = 0;
                    logEntry
                            .addEntry("Adding NAAS users that do not exist in local Db...");

                    Iterator naasPairs = naasMap.entrySet().iterator();
                    for (int i = 0; i < naasMap.size(); i++) {

                        Map.Entry naasEntry = (Map.Entry) naasPairs.next();

                        NaasUserInfo naasAccountInfo = (NaasUserInfo) naasEntry
                                .getValue();

                        // check if user exists
                        if (!localUsers.containsKey(naasEntry.getKey())) {
                            // insert with a check for existence
                            if (accountDao.getOrCreateAccount(
                                    naasAccountInfo.getUserName(),
                                    naasAccountInfo.getAffiliate(),
                                    adminAccout.getId()).isActive()) {
                                // increment number of inserts only if saved
                                // otherwise it must have already existed
                                addedUsersCount++;
                            }
                        } else {

                            // if the naas account already exists in local db
                            // check if he has the same node affiliation
                            UserAccount localAccountInfo = (UserAccount) localUsers
                                    .get(naasEntry.getKey());

                            String localNodeAffiliation = localAccountInfo
                                    .getAffiliationCode();

                            // update if the local affiliation is not in sync
                            // with the NAAS one
                            if (!localNodeAffiliation
                                    .equalsIgnoreCase(naasAccountInfo
                                            .getAffiliate())) {

                                logger
                                        .debug("Updating local user node affiliation: "
                                                + localAccountInfo
                                                        .getNaasUserName());
                                logger.debug("from: " + localNodeAffiliation);
                                logger.debug("to:   "
                                        + naasAccountInfo.getAffiliate());

                                localAccountInfo
                                        .setAffiliationCode(naasAccountInfo
                                                .getAffiliate());
                                accountDao.save(localAccountInfo);

                                // This is unusual to happen so make an entry
                                logEntry
                                        .addEntry(
                                                "User {0} Node affiliation updated from {1} to {2}",
                                                new Object[] {
                                                        localAccountInfo
                                                                .getNaasUserName(),
                                                        localNodeAffiliation,
                                                        naasAccountInfo
                                                                .getAffiliate() });
                            }
                        }
                    }
                    logEntry.addEntry("Added: " + addedUsersCount);

                    // Delete local users that no longer exist in NAAS
                    int deletedUsersCount = 0;
                    logEntry
                            .addEntry("Deactivate local Db users that do not exist in NAAS...");
                    Iterator localPairs = localUsers.entrySet().iterator();
                    for (int i = 0; i < localUsers.size(); i++) {
                        Map.Entry dbEntry = (Map.Entry) localPairs.next();
                        // check if user exists
                        if (!naasMap.containsKey(dbEntry.getKey())) {
                            // delete
                            UserAccount accountInfo = (UserAccount) dbEntry
                                    .getValue();
                            logger
                                    .debug("User "
                                            + accountInfo.getNaasUserName()
                                            + " no longer found in NAAS. Deactivating local referance");
                            accountDao.delete(accountInfo.getId());
                            deletedUsersCount++;
                        }
                    }
                    logEntry.addEntry("Deactivated: " + deletedUsersCount);

                }

            } else {
                logEntry.addEntry("Skip NAAS is set! No work perfromed.");
            }

        } catch (Exception ex) {

            logger.error(ex.getMessage());
            logEntry.setType(ActivityType.ERROR);
            logEntry.addEntry("Error: " + ex.getMessage());

        } finally {
            getActivityService().insert(logEntry);
        }

    }

    /*
     * 
     * 
     * 
     * Setters
     */

    public AccountDao getAccountDao() {
        return accountDao;
    }

    public void setAccountDao(AccountDao accountDao) {
        this.accountDao = accountDao;
    }

    public void setNaasConfig(NAASConfig naasConfig) {
        this.naasConfig = naasConfig;
    }

    public void setUserManager(UserManagerHelper userManager) {
        this.userManager = userManager;
    }

}
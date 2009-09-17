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

package com.windsor.node.service.admin;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.ConfigItem;
import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.ConfigService;
import com.windsor.node.data.dao.ConfigDao;
import com.windsor.node.data.dao.ConnectionDao;
import com.windsor.node.service.BaseService;

public class ConfigServiceImpl extends BaseService implements ConfigService,
        InitializingBean {

    private static final Map CONFS = new HashMap();

    private ConfigDao configDao;
    private ConnectionDao connectionDao;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (configDao == null) {
            throw new RuntimeException("ConfigDao Not Set");
        }

        if (connectionDao == null) {
            throw new RuntimeException("ConnectionDao Not Set");
        }

    }

    /**
     * deleteDataSource
     */
    public void deleteDataProvider(String dsId, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        if (StringUtils.isBlank(dsId)) {
            throw new RuntimeException("dsId not set.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to delete data source {1}.",
                    new Object[] { visit.getName(), dsId });

            connectionDao.delete(dsId);

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while deleting data source: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * getDatabases
     */
    public List getDataProviders(NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        return connectionDao.get();

    }

    public DataProviderInfo getDataProvider(String id, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        return connectionDao.get(id);

    }

    public DataProviderInfo saveDataProvider(DataProviderInfo instance,
            NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        if (instance == null) {
            throw new RuntimeException("connection not set.");
        }

        if (StringUtils.isBlank(instance.getCode())) {
            throw new RuntimeException("name not set.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to create data source {1}.",
                    new Object[] { visit.getName(), instance.getCode() });

            instance = connectionDao.save(instance);

            if (instance == null) {
                throw new RuntimeException("connection not set in db.");
            }

            return instance;

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while creating data source: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * delete
     */
    public void delete(String configId, NodeVisit visit) {

        if (StringUtils.isBlank(configId)) {
            throw new RuntimeException("configId not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            ConfigItem config = get(configId);

            if (config == null) {
                throw new WinNodeException(
                        "Config item not present in local database.");
            }

            logEntry.addEntry("{0} attempted to delete config {1}.",
                    new Object[] { visit.getName(), config.getId() });

            // NAAS
            logger.debug("Attempting to delete config: " + config);
            configDao.delete(config.getId());
            logEntry.addEntry("Config deleted from DB.");

            load();

        } catch (Exception ex) {
            logger.error(ex);
            logEntry
                    .addEntry("Error while deleting config: " + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    // // get
    // public Map get(NodeVisit visit) {
    //
    // // Make sure the user performing that action has admin rights
    // validateByRole(visit, SystemRoleType.Admin);
    //
    // return get();
    //
    // }

    public List getList(NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        return configDao.get();

    }

    public Map get() {

        return getLoaded();

    }

    /**
     * Reloads the configuration args @
     */
    private void load() {

        logger.debug("Clearing CONFS");
        CONFS.clear();
        logger.debug("Getting config items from DB");
        List configItems = configDao.get();

        logger.debug("Loading CONFS items");
        for (int i = 0; i < configItems.size(); i++) {
            ConfigItem configItem = (ConfigItem) configItems.get(i);
            CONFS.put(configItem.getId(), configItem);
        }
    }

    /**
     * getLoaded
     */
    private Map getLoaded() {

        if (CONFS.size() < 1) {
            load();
        }

        return CONFS;

    }

    /**
     * get
     */
    public ConfigItem get(String configId, NodeVisit visit) {

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        return get(configId);
    }

    public ConfigItem get(String configId) {

        if (StringUtils.isBlank(configId)) {
            throw new WinNodeException("configId argument not set.");
        }

        return (ConfigItem) getLoaded().get(configId);
    }

    /**
     * save
     */
    public void save(ConfigItem instance, NodeVisit visit) {

        if (instance == null) {
            throw new WinNodeException("ConfigItem argument not set.");
        }

        if (StringUtils.contains(instance.getId(), " ")) {
            throw new WinNodeException("ConfigItem Id cannot contain spaces.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logger.debug("Attempting to save configuration in DB");
            instance.setModifiedById(visit.getUserAccount().getId());

            ConfigItem oldConfig = get(instance.getId());

            if (oldConfig != null) {

                logEntry.addEntry("{0} attempted to update config {1}.",
                        new Object[] { visit.getName(), oldConfig });

                configDao.update(instance);

            } else {

                logEntry.addEntry("{0} attempted to create configuration {1}.",
                        new Object[] { visit.getName(), instance.getId() });

                configDao.insert(instance);

            }

            logEntry.addEntry("Configuration saved in DB.");

            load();

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while saving configuration in DB: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public void setConfigDao(ConfigDao configDao) {
        this.configDao = configDao;
    }

    public void setConnectionDao(ConnectionDao connectionDao) {
        this.connectionDao = connectionDao;
    }

}
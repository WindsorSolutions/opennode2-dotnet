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

import java.util.Iterator;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataProviderInfo;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NamedSystemConfigItem;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduleArgument;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.ParameterSpecifiedPlugin;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.PluginHelper;
import com.windsor.node.service.BaseService;

public class FlowServiceImpl extends BaseService implements FlowService,
        InitializingBean {

    /**
     * 
     */
    private static final String FLOW_ID_NOT_SET = "flowId not set.";
    /**
     * 
     */
    private static final String DATA_SERVICE_NOT_SET = "DataService argument not set";
    private FlowDao flowDao;
    private ServiceDao serviceDao;
    private PluginHelper pluginHelper;

    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (flowDao == null) {
            throw new RuntimeException("ConfigDao Not Set");
        }

        if (serviceDao == null) {
            throw new RuntimeException("ServiceDao Not Set");
        }

    }

    /**
     * getFlowPluginImplementors
     */
    public List<String> getFlowPluginImplementors(String flowId, NodeVisit visit) {

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException(FLOW_ID_NOT_SET);
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        DataFlow flow = flowDao.get(flowId);

        return pluginHelper.getWnosPluginImplementors(flow);

    }

    /**
     * getFlows
     */
    @SuppressWarnings("unchecked")
    public List<DataFlow> getFlows(NodeVisit visit, boolean loadDataServices) {

        List<DataFlow> flows = (List<DataFlow>) flowDao.get();

        if (loadDataServices) {

            for (int i = 0; i < flows.size(); i++) {
                DataFlow flow = (DataFlow) flows.get(i);
                flow.setServices(serviceDao.getByFlowId(flow.getId()));
            }
        }

        return flows;

    }

    /**
     * getDataFlowNames
     */
    public List<String> getDataFlowNames() {
        return flowDao.getFlowNames();
    }

    /**
     * delete
     */
    public void deleteDataFlow(String flowId, NodeVisit visit) {

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException(FLOW_ID_NOT_SET);
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        DataFlow flow = flowDao.get(flowId);

        if (flow == null) {
            throw new RuntimeException(
                    "Flow item not present in local database.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to delete flow {1}.",
                    new Object[] { visit.getName(), flow.getName() });

            // NAAS
            logger.debug("Attempting to delete flow: " + flow);
            flowDao.delete(flowId);
            logEntry.addEntry("Flow deleted from DB.");

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            logEntry.addEntry("Error while deleting flow: " + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * deleteService
     * 
     * @param serviceId
     * @param visit
     */
    public void deleteDataService(String serviceId, NodeVisit visit) {

        if (StringUtils.isBlank(serviceId)) {
            throw new RuntimeException("serviceId not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        DataService service = serviceDao.get(serviceId);

        if (service == null) {
            throw new RuntimeException("Service not present in local database.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to delete service {1}.",
                    new Object[] { visit.getName(), service.getName() });

            logger.debug("Attempting to delete service: " + service);
            serviceDao.delete(service.getId());
            logEntry.addEntry("Services deleted from DB.");

            // TODO: Update all schedules with that service as Data Source to
            // inactive

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
            logEntry.addEntry("Error while deleting service: "
                    + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * get
     */
    public DataFlow getDataFlow(String flowId, NodeVisit visit) {

        if (StringUtils.isBlank(flowId)) {
            throw new RuntimeException("flowId argument not set.");
        }
        return flowDao.get(flowId);
    }

    public Map<String, String> getActiveServiceMap() {
        return serviceDao.getActive();
    }

    public Map<String, String> getActiveServiceMapByFlowId(String flowId) {
        return serviceDao.getActiveByFlowId(flowId);
    }

    /**
     * save
     */
    public DataFlow saveDataFlow(DataFlow instance, NodeVisit visit) {

        if (instance == null) {
            throw new RuntimeException("DataFlow argument not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to save flow {1}.", new Object[] {
                    visit.getName(), instance.getName() });

            instance.setModifiedById(visit.getUserAccount().getId());

            return flowDao.save(instance);

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);
            logEntry.addEntry("Error while saving flow in DB: "
                    + ex.getMessage());

            throw new RuntimeException(ex.getMessage(), ex);

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public DataService getService(String serviceId, NodeVisit visit) {

        if (StringUtils.isBlank(serviceId)) {
            throw new RuntimeException("serviceId argument not set.");
        }

        logger.debug("Getting data service: " + serviceId);

        DataService dataService = serviceDao.get(serviceId);

        logger.debug("Data Service from Dao: " + dataService);

        if (dataService.getType() == null
                || dataService.getType() == ServiceType.NONE) {

            logger.debug("Null service type, populating from plugin");
            dataService = populateFromPlugin(dataService);

        } else {

            BaseWnosPlugin plugin = getServiceFromPlugin(dataService);

            logger.debug("plugin from service: " + plugin);

            // All all plugin Types
            dataService.setSupportedTypes(plugin.getSupportedPluginTypes());

        }

        return dataService;
    }

    public List<PluginServiceParameterDescriptor> getPluginParameterDescriptors(DataFlow flow, DataService dataService)
    {
        if(dataService == null)
        {
            return null;
        }
        BaseWnosPlugin implementor = pluginHelper.getWnosPlugin(flow, dataService.getImplementingClassName());
        List<PluginServiceParameterDescriptor> params = null;
        if(implementor instanceof ParameterSpecifiedPlugin)
        {
            ParameterSpecifiedPlugin plugin = (ParameterSpecifiedPlugin)implementor;
            params = plugin.getParameters();
        }
        return params;
    }

    /**
     * saveDataService
     */
    public DataService saveDataService(DataService instance, NodeVisit visit) {

        if (instance == null) {
            throw new RuntimeException("DataService argument not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to save service {1}.",
                    new Object[] { visit.getName(), instance.getName() });

            DataFlow flow = flowDao.get(instance.getFlowId());

            if (StringUtils.isNotBlank(instance.getId())
                    && instance.getName().equalsIgnoreCase(flow.getName())) {

                logEntry.addEntry("Default processor for: {0}",
                        new Object[] { instance.getType().name() });

                if (!instance.getType().equals(ServiceType.SUBMIT)
                        && !instance.getType().equals(ServiceType.NOTIFY)) {

                    throw new RuntimeException(
                            "Only Submit or Notify type of services can have a name equal "
                                    + "to the flow name. This indicates that they are to process "
                                    + "all submitted documents for that flow, unless a specific "
                                    + "service name equal to the submission operation name is specified");
                }

            }

            if (instance.getType() == null
                    || instance.getType() == ServiceType.NONE) {

                logger
                        .debug("Null service type, clearing the default values so they would not be saved to the db.");
                instance.getArgs().clear();
                instance.getDataSources().clear();
            }

            instance.setModifiedById(visit.getUserAccount().getId());
            logEntry.addEntry("Saving service saved in DB.");
            DataService savedService = serviceDao.save(instance);
            logEntry.addEntry("Service saved in DB.");

            return savedService;

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);
            logEntry.addEntry("Error while saving service: " + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    public BaseWnosPlugin getServiceFromPlugin(DataService instance) {

        if (instance == null) {
            throw new RuntimeException(DATA_SERVICE_NOT_SET);
        }

        DataFlow flow = flowDao.get(instance.getFlowId());

        return pluginHelper.getWnosPlugin(flow, instance
                .getImplementingClassName());

    }

    /**
     * getDataServiceTemplate
     * 
     * @param instance
     * @param visit
     * @return
     */
    public DataService populateFromPlugin(DataService instance) {

        if (instance == null) {
            throw new RuntimeException(DATA_SERVICE_NOT_SET);
        }

        try {

            BaseWnosPlugin plugin = getServiceFromPlugin(instance);

            logger.debug("plugin from service: " + plugin);

            logger.debug("runtime args before: "
                    + plugin.getConfigurationArguments());

            logger.debug("supported types before: "
                    + plugin.getSupportedPluginTypes());

            // All all plugin Types
            instance.setSupportedTypes(plugin.getSupportedPluginTypes());

            // Args
            // On new, clear the service args and load from the plugin
            instance.getArgs().clear();

            for (Iterator<Map.Entry<String, String>> it = plugin
                    .getConfigurationArguments().entrySet().iterator(); it
                    .hasNext();) {

                Map.Entry<String, String> pluginArgEntry = (Map.Entry<String, String>) it
                        .next();

                logger.debug("runtime arg: " + pluginArgEntry);

                instance.getArgs().add(
                        new NamedSystemConfigItem(pluginArgEntry));

            }

            logger.debug("runtime args after: " + instance.getArgs());

            // Connections
            instance.getDataSources().clear();

            logger.debug("connection sources before: "
                    + plugin.getDataSources());
            for (Iterator<Map.Entry<String, DataSource>> it = plugin
                    .getDataSources().entrySet().iterator(); it.hasNext();) {

                Map.Entry<String, DataSource> pluginDsEntry = (Map.Entry<String, DataSource>) it
                        .next();

                instance.getDataSources().add(
                        new DataProviderInfo(pluginDsEntry.getKey()));

            }
            logger.debug("connection sources after: "
                    + instance.getDataSources());

            return instance;

        } catch (Exception ex) {

            logger.error(ex.getMessage(), ex);

            throw new WinNodeException(ex.getMessage());

        }

    }

    /**
     * 
     * setters
     * 
     * 
     */

    public void setFlowDao(FlowDao flowDao) {
        this.flowDao = flowDao;
    }

    public void setServiceDao(ServiceDao serviceDao) {
        this.serviceDao = serviceDao;
    }

    public void setPluginHelper(PluginHelper pluginHelper) {
        this.pluginHelper = pluginHelper;
    }

}

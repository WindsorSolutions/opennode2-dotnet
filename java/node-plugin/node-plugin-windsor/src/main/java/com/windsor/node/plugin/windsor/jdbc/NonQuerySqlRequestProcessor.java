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

/*
 * Created on Aug 20, 2004
 *
 */
package com.windsor.node.plugin.windsor.jdbc;

import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;

/**
 * @author mchmarny
 * 
 */
public class NonQuerySqlRequestProcessor extends BaseWnosPlugin {
    /**
     * runtime argument names
     */
    public static final String ARG_SQL = "Sql Query";

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("NonQuerySqlRequestProcessor");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Windsor utility method to execute a stored procedure (generally an ETL execution), access should be restricted.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(NonQuerySqlRequestProcessor.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public NonQuerySqlRequestProcessor() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_SQL, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, (DataSource) null);

        getSupportedPluginTypes().add(ServiceType.TASK);

        debug("Plugin initialized");
    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        // make sure the run time args are set
        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the source data source is set
        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source data source not set");
        }

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_SQL)) {
            throw new RuntimeException(ARG_SQL + " not set");
        }

        debug("Plugin validated");

    }

    /**
     * processlogger.debug
     */
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            /*
             * 
             * ARGUMENTS
             */
            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

            result.getAuditEntries().add(makeEntry("Acquiring arguments..."));
            DataSource dataSource = (DataSource) getDataSources().get(
                    ARG_DS_SOURCE);
            debug("Data Source: " + dataSource);

            String sql = getRequiredConfigValueAsString(ARG_SQL);
            result.getAuditEntries().add(
                    makeEntry("Sql Query: " + sql));

            /*
             * 
             * EXECUTE
             */
            result.getAuditEntries().add(makeEntry("Executing request..."));
            new SimpleNonQueryExecutor().executeSql(dataSource, sql);

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }
}
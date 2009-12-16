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

package com.windsor.node.plugin.sample;

import java.util.List;

import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.IdGenerator;

/**
 * com.windsor.node.plugin.sample.SimpleWnosPluginImplementation
 * 
 * @author mchmarny
 * 
 */
public class SimpleWnosPluginImplementation extends BaseWnosPlugin {

    /**
     * runtime argument names
     */
    public static final String ARG_URL = "EndpointUri";
    public static final String ARG_BOOL = "IsFacilitySource";
    public static final String ARG_STRING = "SourceSystemName";

    public SimpleWnosPluginImplementation() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_URL,
                "Url to the Web Service weere the results will be downloaded");
        getConfigurationArguments().put(ARG_BOOL, "True or False");
        getConfigurationArguments().put(ARG_STRING,
                "Name of the system where the data came from");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);
        getDataSources().put(ARG_DS_TARGET, null);

        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT_OR_EXECUTE);

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

        // make sure the target data source is set
        if (!getDataSources().containsKey(ARG_DS_TARGET)) {
            throw new RuntimeException("Target data source not set");
        }

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the url arg is set set
        if (!getConfigurationArguments().containsKey(ARG_URL)) {
            throw new RuntimeException("Source data source not set");
        }

        // make sure the bool arg is set
        if (!getConfigurationArguments().containsKey(ARG_BOOL)) {
            throw new RuntimeException("Target data source not set");
        }

        // make sure the string arg is set
        if (!getConfigurationArguments().containsKey(ARG_STRING)) {
            throw new RuntimeException("Target data source not set");
        }

        debug("Plugin validated");

    }

    /**
     * Execute the plugin
     */
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        result.getAuditEntries().add(
                new ActivityEntry("Validating transaction"));

        try {

            // Transaction validation
            if (transaction == null) {
                throw new RuntimeException("Null transaction");
            }

            if (transaction.getCreator() == null
                    || StringUtils.isBlank(transaction.getCreator()
                            .getNaasUserName())) {
                throw new RuntimeException("Null transaction creator");
            }

            if (StringUtils.isBlank(transaction.getNetworkId())) {
                throw new RuntimeException("Null transaction network Id");
            }

            if (transaction.getRequest() == null) {
                throw new RuntimeException("Null request");
            }

            if (transaction.getRequest().getService() == null
                    || StringUtils.isBlank(transaction.getRequest()
                            .getService().getName())) {
                throw new RuntimeException("Null service");
            }

            debug("Testing service factory...");
            IdGenerator idUtil = (IdGenerator) getServiceFactory().makeService(
                    IdGenerator.class);

            // Now that we have all the info we generate a doc
            // This is where the real plugin work would be done

            String xml = "<test><content><value>1</value><value>2</value><value>3</value></content></test>";

            debug("Creating document...");
            Document doc = new Document();
            doc.setDocumentName(idUtil.createId() + ".xml");
            doc.setType(CommonContentType.XML);
            doc.setContent(xml.getBytes("UTF-8"));

            debug("Setting result...");
            result.setSuccess(true);
            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));
            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.getAuditEntries().add(
                    new ActivityEntry("Error while executing: "
                            + this.getClass().getName()));
            result.getAuditEntries().add(new ActivityEntry(ex.getMessage()));

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

        }

        debug("Done");
        return result;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }
}

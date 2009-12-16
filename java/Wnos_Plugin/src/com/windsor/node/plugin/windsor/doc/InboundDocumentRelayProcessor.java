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

/**
 * 
 */
package com.windsor.node.plugin.windsor.doc;

import java.util.List;

import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class InboundDocumentRelayProcessor extends BaseWnosPlugin {

    public static final String ARG_TARGET_ENDPOINT_URL = "targetEndpointUrl";

    public InboundDocumentRelayProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_TARGET_ENDPOINT_URL, "");

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_TARGET_ENDPOINT_URL)) {
            throw new RuntimeException(ARG_TARGET_ENDPOINT_URL + " not set");
        }

        debug("Plugin validated");

    }

    /**
     * process
     */
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));

            /*
             * 
             * Transaction validation
             */
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

            /*
             * 
             * Parsing Test
             */
            if (transaction.getDocuments() == null
                    || transaction.getDocuments().size() != 1) {
                int numOfDocs = (transaction.getDocuments() == null) ? 0
                        : transaction.getDocuments().size();
                throw new RuntimeException("Invalid number of documents: "
                        + numOfDocs
                        + ". This processor requires a single document.");
            }

            /*
             * 
             * HELPERS
             */

            result.getAuditEntries().add(
                    makeEntry("Validating required helpers..."));

            SettingServiceProvider settingService = (SettingServiceProvider) getServiceFactory()
                    .makeService(SettingServiceProvider.class);

            if (settingService == null) {
                throw new RuntimeException(
                        "Unable to obtain SettingServiceProvider");
            }

            TransactionDao tranDao = (TransactionDao) getServiceFactory()
                    .makeService(TransactionDao.class);

            result.getAuditEntries().add(makeEntry("Vaildating arguments..."));
            String endpointUrl = getRequiredConfigValueAsString(ARG_TARGET_ENDPOINT_URL);
            result.getAuditEntries().add(makeEntry("Endpoint: " + endpointUrl));

            result.getAuditEntries().add(makeEntry("Configuring client..."));
            NodeClientService client = makeAndConfigureNodeClientService(endpointUrl);

            if (client == null) {
                throw new RuntimeException(
                        "Client not configured in configuration section: "
                                + endpointUrl);
            }

            result.getAuditEntries()
                    .add(makeEntry("Submitting transaction..."));
            NodeTransaction resultTran = client.submit(transaction);

            if (resultTran == null) {
                throw new RuntimeException("Null transaction");
            }

            // In case the calling class uses that Id
            transaction.setNetworkId(resultTran.getNetworkId());

            result.getAuditEntries().add(
                    makeEntry("Remote Transaction Id: "
                            + resultTran.getNetworkId()));

            tranDao.updateNetworkId(transaction.getId(), resultTran
                    .getNetworkId());

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + "Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

}
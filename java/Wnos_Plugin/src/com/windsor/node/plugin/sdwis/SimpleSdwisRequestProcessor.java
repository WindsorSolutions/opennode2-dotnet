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
package com.windsor.node.plugin.sdwis;

import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class SimpleSdwisRequestProcessor extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "SDWIS";
    public static final String ARG_TARGET_ENDPOINT_URL = "targetEndpointUrl";

    public SimpleSdwisRequestProcessor() {

        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_TARGET_ENDPOINT_URL, "");

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

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
        result.setStatus(CommonTransactionStatusCode.Failed);

        result.getAuditEntries().add(makeEntry("Validating transaction..."));

        validateTransaction(transaction);

        if (!transaction.getWebMethod().equals(NodeMethodType.SUBMIT)) {
            throw new RuntimeException("Invalid method type: "
                    + transaction.getWebMethod());
        }

        int numOfDocs = 0;

        if (transaction.getDocuments() == null
                || transaction.getDocuments().size() != 1) {
            if (transaction.getDocuments() != null) {
                numOfDocs = transaction.getDocuments().size();
            }
            throw new RuntimeException("Invalid number of documents: "
                    + numOfDocs);
        }

        try {

            result.getAuditEntries().add(
                    makeEntry("Validating required helpers..."));
            SettingServiceProvider settingService = (SettingServiceProvider) getServiceFactory()
                    .makeService(SettingServiceProvider.class);

            if (settingService == null) {
                throw new RuntimeException(
                        "Unable to obtain SettingServiceProvider");
            }

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
            client.submit(transaction);

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

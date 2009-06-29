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
package com.windsor.node.plugin.aqs;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.HeaderDocumentHelper;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.RemoteFileResourceHelper;

/**
 * @author mchmarny
 * 
 */
public class DrDasProxyService extends BaseWnosPlugin {

    public static final String SRV_MONITOR = "AQDEMonitorData";
    public static final String SRV_RAW = "AQDERawData";

    public static final String ARG_ENDPOINT_URL = "Reporter Url";
    public static final String ARG_HD_SCHEMA_VERSION = "Schema Version";

    public DrDasProxyService() {

        super();

        debug("Setting internal runtime argument list");

        getConfigurationArguments().put(ARG_ENDPOINT_URL, "");
        getConfigurationArguments().put(ARG_HD_SCHEMA_VERSION, "");

        getSupportedPluginTypes().add(ServiceType.QUERY);
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);

        debug("Plugin initialized");

    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the ARG_ENDPOINT_URL arg is set set
        if (!getConfigurationArguments().containsKey(ARG_ENDPOINT_URL)) {
            throw new RuntimeException(ARG_ENDPOINT_URL + " not set");
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
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            result.getAuditEntries()
                    .add(makeEntry("Vaildating transaction..."));

            validateTransaction(transaction);

            IdGenerator idGenerator = (IdGenerator) getServiceFactory()
                    .makeService(IdGenerator.class);

            if (idGenerator == null) {
                throw new RuntimeException("Unable to obtain IdGenerator");
            }

            HeaderDocumentHelper headerHelper = (HeaderDocumentHelper) getServiceFactory()
                    .makeService(HeaderDocumentHelper.class);

            if (headerHelper == null) {
                throw new RuntimeException(
                        "Unable to obtain HeaderDocumentHelper");
            }

            RemoteFileResourceHelper webHelper = (RemoteFileResourceHelper) getServiceFactory()
                    .makeService(RemoteFileResourceHelper.class);

            if (webHelper == null) {
                throw new RuntimeException(
                        "Unable to obtain RemoteFileResourceHelper");
            }

            /*
             * 
             * ARGS
             */
            result.getAuditEntries().add(makeEntry("Acquiring arguments..."));

            String reporterServiceUrl = getRequiredConfigValueAsString(ARG_ENDPOINT_URL);
            String reporterSchemaVersion = getRequiredConfigValueAsString(ARG_HD_SCHEMA_VERSION);

            Map properties = new HashMap();
            properties.put("schemaVersion", reporterSchemaVersion);

            result.getAuditEntries().add(
                    makeEntry("Configuring reporter client using: "
                            + reporterServiceUrl));

            DrDasServiceHelper srv = new DrDasServiceHelper(reporterServiceUrl,
                    transaction.getRequest().getParameters(),
                    reporterSchemaVersion);

            result.getAuditEntries().add(
                    makeEntry("Getting requested service name..."));

            String methodName = transaction.getRequest().getService().getName();

            result.getAuditEntries()
                    .add(
                            makeEntry("Parsing execution strategy from: "
                                    + methodName));

            byte[] resultsBytes = null;

            if (methodName.equalsIgnoreCase(SRV_MONITOR)) {

                result.getAuditEntries().add(
                        makeEntry("Executing Monitor Data service using: "
                                + transaction.getRequest().getParameters()
                                + " and SchemaVersion: "
                                + reporterSchemaVersion));

                resultsBytes = srv.executeMonitorData();

            } else if (methodName.equalsIgnoreCase(SRV_RAW)) {

                result.getAuditEntries().add(
                        makeEntry("Executing Raw Data service using: "
                                + transaction.getRequest().getParameters()
                                + " and SchemaVersion: "
                                + reporterSchemaVersion));

                String resultFile = srv.executeRawData(idGenerator.createId());

                result.getAuditEntries().add(
                        makeEntry("Reading remote result: " + resultFile));

                resultsBytes = webHelper.getBytesFromURL(resultFile);

                String tempXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
                tempXml += new String(resultsBytes);
                resultsBytes = tempXml.getBytes("UTF-8");

            } else {
                throw new RuntimeException(
                        "Invalid parameter: Method Name is not supported ("
                                + methodName + ").");
            }

            result.getAuditEntries().add(
                    makeEntry("Testing for compression: "
                            + transaction.getRequest().getType()));

            Document doc = new Document();
            result.getAuditEntries().add(makeEntry("Creating document..."));

            if (transaction.getRequest().getType() != RequestType.QUERY) {

                result.getAuditEntries().add(
                        makeEntry("Compressing results..."));

                CompressionService compressionService = (CompressionService) getServiceFactory()
                        .makeService(CompressionService.class);

                doc.setType(CommonContentType.ZIP);
                doc.setDocumentName("AQS-" + methodName + ".zip");
                doc.setContent(compressionService.zip(resultsBytes, "AQS-"
                        + methodName + ".xml"));

            } else {
                doc.setType(CommonContentType.XML);
                doc.setDocumentName("AQS-" + methodName + ".xml");
                doc.setContent(resultsBytes);
            }

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Throwable ex) {

            error(ex.getMessage(), ex);
            error(ex.getMessage());

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {

        List<DataServiceRequestParameter> list = new ArrayList<DataServiceRequestParameter>();

        Integer sortIndex = 0;

        if (serviceName.equalsIgnoreCase(SRV_MONITOR)) {

            for (MonitorDataArgType arg : MonitorDataArgType.values()) {

                DataServiceRequestParameter param = new DataServiceRequestParameter();
                param.setName(arg.toString());
                param.setSortIndex(sortIndex);

                list.add(param);

                sortIndex++;
            }

        } else if (serviceName.equalsIgnoreCase(SRV_RAW)) {

            for (RawDataArgType arg : RawDataArgType.values()) {

                DataServiceRequestParameter param = new DataServiceRequestParameter();
                param.setName(arg.toString());
                param.setSortIndex(sortIndex);

                list.add(param);

                sortIndex++;
            }

        } else {

            list = null;
        }

        return list;
    }

}

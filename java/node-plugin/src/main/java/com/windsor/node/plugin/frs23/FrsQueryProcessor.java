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
package com.windsor.node.plugin.frs23;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;

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
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class FrsQueryProcessor extends BaseWnosPlugin {

    public static final String SERVICE_CHANGEDATE_PARAM_NAME = "FacilityChangeDate";
    public static final String SERVICE_DELETED_PARAM_NAME = "FacilityDeletedDate";
    public static final String SERVICE_NAME_PARAM_NAME = "StateFacilityIdentifier";

    public FrsQueryProcessor() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_ADD_HEADER, "");
        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_NOTIFS, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, "");
        getConfigurationArguments().put(ARG_HEADER_TITLE, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, (DataSource) null);

        getSupportedPluginTypes().add(ServiceType.QUERY);
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);

        debug("FrsQueryProcessor instantiated");
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

        if (!getConfigurationArguments().containsKey(ARG_ADD_HEADER)) {
            throw new RuntimeException(ARG_ADD_HEADER + " not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_HEADER_AUTHOR)) {
            throw new RuntimeException(ARG_HEADER_AUTHOR + " not set");
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

            String doHeaderIndicator = getRequiredConfigValueAsString(ARG_ADD_HEADER);
            boolean doHeader = doHeaderIndicator.equalsIgnoreCase("true");
            result.getAuditEntries().add(
                    makeEntry("Generate Header: " + doHeaderIndicator + " ("
                            + doHeader + ")"));

            String author = getConfigValueAsString(ARG_HEADER_AUTHOR, doHeader);
            String title = getConfigValueAsString(ARG_HEADER_TITLE, doHeader);
            String contactInfo = getConfigValueAsString(
                    ARG_HEADER_CONTACT_INFO, doHeader);
            String organizationName = getConfigValueAsString(
                    ARG_HEADER_ORG_NAME, doHeader);
            String notification = getConfigValueAsString(ARG_HEADER_NOTIFS,
                    doHeader);
            String payloadOperation = getConfigValueAsString(
                    ARG_HEADER_PAYLOAD_OP, doHeader);
            String[] notifications = StringUtils.split(notification, ';');

            Map properties = new HashMap();
            properties.put("ServiceName", transaction.getRequest().getService()
                    .getName());
            properties.put("Arguments", StringUtils.join(transaction
                    .getRequest().getParameterValues()));

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

            CompressionService compressionService = (CompressionService) getServiceFactory()
                    .makeService(CompressionService.class);

            if (compressionService == null) {
                throw new RuntimeException(
                        "Unable to obtain CompressionService");
            }

            /*
             * 
             * EXECUTE
             */

            // Data
            result.getAuditEntries().add(makeEntry("Executing request..."));

            String resultFilePath = FilenameUtils.concat(settingService
                    .getTempDir().getAbsolutePath(), "FRS-"
                    + transaction.getRequest().getService().getName() + "-"
                    + idGenerator.createId() + ".xml");

            new Data(true).getList(dataSource, resultFilePath, transaction
                    .getRequest(), result, doHeader);

            result.getAuditEntries().add(
                    makeEntry("Result file: " + resultFilePath));

            File resultingFile = new File(resultFilePath);

            if (!resultingFile.exists()) {
                throw new RuntimeException("Result file does not exist");
            }

            /*
             * 
             * HEADER
             */

            result.getAuditEntries().add(
                    makeEntry("Testing for header: " + doHeader));

            if (doHeader) {

                result.getAuditEntries().add(makeEntry("Making header..."));
                resultingFile = headerHelper.makeHeader(author, title,
                        transaction.getRequest().getService().getName(),
                        contactInfo, notifications, organizationName,
                        properties, "Unclassified", payloadOperation,
                        resultingFile);

            }

            /*
             * 
             * COMPRESSION
             */

            result.getAuditEntries().add(
                    makeEntry("Testing for compression: "
                            + transaction.getRequest().getType()));

            Document doc = new Document();
            result.getAuditEntries().add(makeEntry("Creating document..."));

            if (transaction.getRequest().getType() != RequestType.QUERY) {

                result.getAuditEntries().add(
                        makeEntry("Compressing results..."));
                resultingFile = compressionService.zip(resultingFile);
                result.getAuditEntries().add(
                        makeEntry("Result: " + resultingFile));

                doc.setType(CommonContentType.ZIP);

            } else {
                doc.setType(CommonContentType.XML);
            }

            doc.setDocumentName(FilenameUtils.getName(resultingFile
                    .getAbsolutePath()));

            doc.setContent(FileUtils.readFileToByteArray(resultingFile));

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

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

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(com
     * .windsor.node.common.domain.EndpointVersionType)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {

        List<DataServiceRequestParameter> list = new ArrayList<DataServiceRequestParameter>();

        if (serviceName.equalsIgnoreCase(Data.SERVICE_CHANGEDATE)) {

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(SERVICE_CHANGEDATE_PARAM_NAME);
            param.setSortIndex(0);

            list.add(param);

        } else if (serviceName.equalsIgnoreCase(Data.SERVICE_DELETED)) {

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(SERVICE_DELETED_PARAM_NAME);
            param.setSortIndex(0);

            list.add(param);

        } else if (serviceName.equalsIgnoreCase(Data.SERVICE_NAME)) {

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(SERVICE_NAME_PARAM_NAME);
            param.setSortIndex(0);

            list.add(param);

        } else {

            list = null;
        }

        return list;
    }
}

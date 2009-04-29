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

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class NewFacilityRequestProcessor extends BaseWnosPlugin {

    /**
     * runtime argument names
     */
    public static final String ARG_SOURCE_SYS_NAME = "Source system name";
    public static final String ARG_LAST_EXEC_STATE_KEY = "Name of app key to manage state";

    public NewFacilityRequestProcessor() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_SOURCE_SYS_NAME, "");
        getConfigurationArguments().put(ARG_LAST_EXEC_STATE_KEY, "");

        debug("Setting internal data source list");
        getDataSources().put(DS_SOURCE, (DataSource) null);

        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("Plugin initiated");
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
        if (!getDataSources().containsKey(DS_SOURCE)) {
            throw new RuntimeException("Source data source not set");
        }

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_SOURCE_SYS_NAME)) {
            throw new RuntimeException(ARG_SOURCE_SYS_NAME + " not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_LAST_EXEC_STATE_KEY)) {
            throw new RuntimeException(ARG_LAST_EXEC_STATE_KEY + " not set");
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

            /*
             * 
             * ARGUMENTS
             */
            result.getAuditEntries()
                    .add(makeEntry("Vaildating transaction..."));
            validateTransaction(transaction);

            result.getAuditEntries().add(makeEntry("Acquiring arguments..."));
            DataSource dataSource = (DataSource) getDataSources()
                    .get(DS_SOURCE);
            debug("Data Source: " + dataSource);

            String sourceSysName = getRequiredConfigValueAsString(ARG_SOURCE_SYS_NAME);
            result.getAuditEntries().add(
                    makeEntry("Source System Name: " + sourceSysName));

            String stateKey = getRequiredConfigValueAsString(ARG_LAST_EXEC_STATE_KEY);
            result.getAuditEntries().add(
                    makeEntry("Last Exec State Key: " + stateKey));

            result.getAuditEntries().add(
                    makeEntry("Getting last execution date..."));
            AppStateDataProvider stateProvider = new AppStateDataProvider(
                    dataSource);
            String lastExecDate = stateProvider.getStateAsString(stateKey);

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

            // Prepare Request
            DataRequest request = transaction.getRequest();
            request.getService().setName(Data.SERVICE_CHANGEDATE);
            request.getParameters().put(0, "XX"); // Not used
            request.getParameters().put(1, lastExecDate);

            new Data(false).getList(dataSource, resultFilePath, request,
                    sourceSysName, result, false);

            result.getAuditEntries().add(
                    makeEntry("Result file: " + resultFilePath));

            File resultingFile = new File(resultFilePath);

            if (!resultingFile.exists()) {
                throw new RuntimeException("Result file does not exist");
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

            result.getAuditEntries().add(makeEntry("Compressing results..."));
            resultingFile = compressionService.zip(resultingFile);
            result.getAuditEntries().add(makeEntry("Result: " + resultingFile));

            doc.setType(CommonContentType.ZIP);

            doc.setDocumentName(FilenameUtils.getName(resultingFile
                    .getAbsolutePath()));

            doc.setContent(FileUtils.readFileToByteArray(resultingFile));

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            // Set the exec date to the current run
            stateProvider.setStateToNowXmlDate(stateKey);

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
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));

        }

        return result;
    }
}
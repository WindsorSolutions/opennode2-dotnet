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
package com.windsor.node.plugin.nei;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
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
 * NOTE: This class has been upgraded from the legacy Node No effort has been
 * taken to obtimize this class do to it anticipated short lifespan (4 more runs
 * kevin J tells me)
 * 
 * @author mchmarny
 * 
 */
public class GetNEIPointDataByYear extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "GetNEIPointDataByYear";

    public static final String SERVICE_PARAM_YEAR = "ReportingYear";

    public static final String SERVICE_PARAM_TRAN_TYPE = "TransactionType";

    public static final String ARG_GEO_COVERAGE = "Geographic Coverage";

    public GetNEIPointDataByYear() {
        super();

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_ADD_HEADER, "");
        getConfigurationArguments().put(ARG_GEO_COVERAGE, "");
        getConfigurationArguments().put(ARG_HEADER_AUTHOR, "");
        getConfigurationArguments().put(ARG_HEADER_CONTACT_INFO, "");
        getConfigurationArguments().put(ARG_HEADER_ORG_NAME, "");
        getConfigurationArguments().put(ARG_HEADER_SENSITIVITY, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, (DataSource) null);

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

        debug("Plugin validated");

    }

    protected void validateTransaction(NodeTransaction transaction) {

        super.validateTransaction(transaction);

        if (transaction.getRequest().getParameters().size() != 2) {
            throw new RuntimeException(
                    "Invalid number of parameters. Expected 2: Year and TransactionType");
        }

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

            /* ARGUMENTS */
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

            String geoCoverage = getConfigValueAsString(ARG_GEO_COVERAGE,
                    doHeader);
            result.getAuditEntries().add(
                    makeEntry(ARG_GEO_COVERAGE + ": " + geoCoverage));

            String author = getConfigValueAsString(ARG_HEADER_AUTHOR, doHeader);
            result.getAuditEntries().add(
                    makeEntry(ARG_HEADER_AUTHOR + ": " + author));

            String contact = getConfigValueAsString(ARG_HEADER_CONTACT_INFO,
                    doHeader);
            result.getAuditEntries().add(
                    makeEntry(ARG_HEADER_CONTACT_INFO + ": " + contact));

            String org = getConfigValueAsString(ARG_HEADER_ORG_NAME, doHeader);
            result.getAuditEntries().add(
                    makeEntry(ARG_HEADER_ORG_NAME + ": " + org));

            String sensitivity = getConfigValueAsString(ARG_HEADER_SENSITIVITY,
                    doHeader);
            result.getAuditEntries().add(
                    makeEntry(ARG_HEADER_SENSITIVITY + ": " + sensitivity));

            /* HELPERS */

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

            /* EXECUTE */

            // Data
            result.getAuditEntries().add(makeEntry("Executing request..."));

            String documentId = idGenerator.createId();

            String resultFilePath = FilenameUtils.concat(settingService
                    .getTempDir().getAbsolutePath(), "NEI-"
                    + transaction.getRequest().getService().getName() + "-"
                    + documentId + ".xml");

            new Data().getList(dataSource, resultFilePath, transaction
                    .getRequest(), org, author, contact, sensitivity,
                    geoCoverage, doHeader, documentId);

            result.getAuditEntries().add(
                    makeEntry("Result file: " + resultFilePath));

            File resultingFile = new File(resultFilePath);

            if (!resultingFile.exists()) {
                throw new RuntimeException("Result file does not exist");
            }

            /* COMPRESSION */

            result.getAuditEntries().add(
                    makeEntry("Creating and compressing document..."));
            Document doc = new Document();
            doc.setType(CommonContentType.ZIP);
            String xmlFileName = FilenameUtils.getName(resultingFile
                    .getAbsolutePath());
            doc.setDocumentName(xmlFileName + ".zip");
            resultingFile = compressionService.zip(resultingFile);
            doc.setContent(FileUtils.readFileToByteArray(resultingFile));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.getDocuments().add(doc);

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

        List<DataServiceRequestParameter> list = null;

        if (serviceName.equalsIgnoreCase(SERVICE_NAME)) {

            list = new ArrayList<DataServiceRequestParameter>();

            DataServiceRequestParameter nameParam = new DataServiceRequestParameter();
            nameParam.setName(SERVICE_PARAM_YEAR);
            nameParam.setSortIndex(0);

            list.add(nameParam);

            DataServiceRequestParameter yearParam = new DataServiceRequestParameter();
            yearParam.setName(SERVICE_PARAM_TRAN_TYPE);
            yearParam.setSortIndex(1);

            list.add(yearParam);
        }

        return list;
    }
}

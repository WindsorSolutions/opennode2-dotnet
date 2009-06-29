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
package com.windsor.node.plugin.frs23.doc;

import java.io.File;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class FrsInboundDocumentProcessor extends BaseWnosPlugin {

    private static final String ARG_PROC_NAME = "procedureName";

    public FrsInboundDocumentProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_PROC_NAME, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, (DataSource) null);

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

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

        // make sure the target data source is set
        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Target data source not set");
        }

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Config args not set");
        }

        if (!getConfigurationArguments().containsKey(ARG_PROC_NAME)) {
            throw new RuntimeException(ARG_PROC_NAME + " not set");
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

            result.getAuditEntries().add(
                    makeEntry("Vaildating transaction and documents..."));
            /*
             * Parsing Test
             */
            if (transaction.getDocuments() == null) {
                throw new RuntimeException(
                        "Invalid number of documents. At least one required");
            }

            result.getAuditEntries().add(
                    makeEntry("Acquiring target datasource..."));
            DataSource dataSource = (DataSource) getDataSources().get(
                    ARG_DS_SOURCE);

            /*
             * HELPERS
             */

            result.getAuditEntries().add(
                    makeEntry("Validating required helpers..."));

            CompressionService compressionService = (CompressionService) getServiceFactory()
                    .makeService(CompressionService.class);

            if (compressionService == null) {
                throw new RuntimeException(
                        "Unable to obtain CompressionService");
            }

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

            /*
             * EXECUTE
             */
            result.getAuditEntries().add(
                    makeEntry("Parsing process arguments..."));

            String procName = getRequiredConfigValueAsString(ARG_PROC_NAME);
            result.getAuditEntries().add(
                    makeEntry("   Procedure name: " + procName));

            result.getAuditEntries().add(
                    makeEntry("Creating procedure executor..."));

            FrsXmlToClobDao dao = new FrsXmlToClobDao(dataSource, procName);

            result.getAuditEntries().add(
                    makeEntry("Creating file extractor..."));

            result.getAuditEntries().add(makeEntry("Processing documents..."));

            for (int i = 0; i < transaction.getDocuments().size(); i++) {

                Document doc = (Document) transaction.getDocuments().get(i);

                result.getAuditEntries()
                        .add(
                                makeEntry("Staging document: "
                                        + doc.getDocumentName()));

                if (!doc.getType().equals(CommonContentType.ZIP)) {
                    throw new RuntimeException("ZIP Content required.");
                }

                File stageFile = new File(settingService.getTempFilePath("zip"));

                FileUtils.writeByteArrayToFile(stageFile, doc.getContent());

                result.getAuditEntries().add(
                        makeEntry("File staged at: " + stageFile));

                File tempFileDir = new File(FilenameUtils
                        .concat(settingService.getTempDir().getAbsolutePath(),
                                idGenerator.createId()));

                FileUtils.forceMkdir(tempFileDir);

                result.getAuditEntries().add(
                        makeEntry("Uncompressing staged file to: "
                                + tempFileDir));

                compressionService.unzip(stageFile.getAbsolutePath(),
                        tempFileDir.getAbsolutePath());

                String[] uncompressedFiles = tempFileDir.list();

                result.getAuditEntries().add(
                        makeEntry("Found documents: "
                                + uncompressedFiles.length));

                for (int d = 0; d < uncompressedFiles.length; d++) {

                    String uncompressedFilePath = FilenameUtils
                            .concat(tempFileDir.getAbsolutePath(),
                                    uncompressedFiles[d]);

                    result.getAuditEntries().add(
                            makeEntry("Loading: " + d + " ("
                                    + uncompressedFilePath + ")"));

                    File fileToProcess = new File(uncompressedFilePath);

                    dao.loadText(fileToProcess);

                    result.getAuditEntries().add(makeEntry("Loaded"));

                }

            }

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
        return null;
    }
}

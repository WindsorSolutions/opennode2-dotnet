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
package com.windsor.node.plugin.windsor.io;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class WindsorContentImportProcessor extends BaseWnosPlugin {

    private static final int ARG_TARGET_DIR_PATH = 0;
    private static final int ARG_SOURCE_URL = 1;

    public WindsorContentImportProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");

        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("Plugin initialized");

    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Plugin validated");

    }

    private File getTargetDir(NodeTransaction transaction) {

        debug("Parsing Root Folder...");

        String targetDirPath = getRequiredValueFromTransactionArgs(transaction,
                ARG_TARGET_DIR_PATH);
        debug("Root Folder Path: " + targetDirPath);

        File targetDir = new File(targetDirPath);

        if (!targetDir.exists()) {
            try {
                debug("Creating Subfolder...");
                FileUtils.forceMkdir(targetDir);
            } catch (IOException ioex) {
                throw new RuntimeException("Error while creating dir: "
                        + targetDir);
            }
        } else if (!targetDir.isDirectory()) {
            throw new RuntimeException("Path is not directory: "
                    + targetDirPath);
        }

        debug("Result: " + targetDir);

        return targetDir;

    }

    /**
     * process
     */
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            debug("Validating Transaction Creator: "
                    + transaction.getCreator().getNaasUserName());

            if (!StringUtils.containsIgnoreCase(transaction.getCreator()
                    .getNaasUserName(), "windsorsolutions")) {
                throw new RuntimeException(
                        "Service can only be executed by Windsor");
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

            CompressionService compressionService = (CompressionService) getServiceFactory()
                    .makeService(CompressionService.class);

            if (compressionService == null) {
                throw new RuntimeException(
                        "Unable to obtain CompressionService");
            }

            IdGenerator idGenerator = (IdGenerator) getServiceFactory()
                    .makeService(IdGenerator.class);

            if (idGenerator == null) {
                throw new RuntimeException("Unable to obtain IdGenerator");
            }

            /*
             * 
             * Parsing Test
             */

            result.getAuditEntries().add(makeEntry("Parsing source URL..."));
            URL sourceUrl = new URL(getRequiredValueFromTransactionArgs(
                    transaction, ARG_SOURCE_URL));
            result.getAuditEntries().add(
                    makeEntry("Source resource: " + sourceUrl));

            result.getAuditEntries().add(makeEntry("Parsing target folder..."));
            File targetDir = getTargetDir(transaction);
            result.getAuditEntries().add(
                    makeEntry("Target folder: " + targetDir));

            File tempStaging = new File(settingService.getTempFilePath("zip"));

            result.getAuditEntries().add(
                    makeEntry("Staging remote file in: " + tempStaging));
            FileUtils.copyURLToFile(sourceUrl, tempStaging);

            if (!tempStaging.exists()) {
                throw new RuntimeException("Downloaded file does not exist");
            }

            result.getAuditEntries().add(
                    makeEntry("Downloaded: " + tempStaging.getName() + " ("
                            + tempStaging.length() + "B)"));

            result.getAuditEntries().add(
                    makeEntry("Unzipping staged file to: " + targetDir));

            compressionService.unzip(tempStaging.getAbsolutePath(), targetDir
                    .getAbsolutePath());

            result.getAuditEntries().add(makeEntry("Creating report..."));

            StringBuffer sb = new StringBuffer();
            sb.append("<xml>");
            sb.append("<report>");
            sb.append("<createdBy>"
                    + transaction.getCreator().getNaasUserName()
                    + "</createdBy>");
            sb.append("<sourceUrl>" + sourceUrl + "</sourceUrl>");
            sb.append("<targetPath>" + targetDir + "</targetPath>");
            sb.append("</report>");
            sb.append("</xml>");

            Document doc = new Document();
            doc.setType(CommonContentType.XML);
            doc.setDocumentName("WindsorUrlResourceProviderReport.xml");
            doc.setContent(sb.toString().getBytes("UTF-8"));

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

    @Override
    public List<PluginServiceParameterDescriptor> getParamters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }
}
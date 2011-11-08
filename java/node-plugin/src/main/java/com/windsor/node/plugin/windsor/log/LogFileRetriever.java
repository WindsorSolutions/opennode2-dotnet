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

package com.windsor.node.plugin.windsor.log;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

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
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class LogFileRetriever extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "RetrieveNodeLogs";
    public static final String ARCHIVE_NAME = "node_logs";
    public static final String TIMESTAMP_FORMAT = "dd-MMM-yyyy_hh.mm.a_z";

    public LogFileRetriever() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        getSupportedPluginTypes().add(ServiceType.QUERY);

        debug("Plugin instantiated");
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        result.getAuditEntries().add(
                makeEntry("Preparing to retrieve log files..."));

        try {
            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

            /* HELPERS */

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

            /* EXECUTE */

            result.getAuditEntries().add(makeEntry("copying log files..."));

            // make a work dir inside <nodehome>/tmp
            String tempDirName = settingService.getTempDir().getAbsolutePath();

            File workDir = new File(FilenameUtils
                    .concat(tempDirName, "log.tmp"));

            if (!workDir.exists()) {
                if (!workDir.mkdir()) {
                    throw new RuntimeException(
                            "Couldn't create work directory "
                                    + workDir.getAbsolutePath());
                }
            }

            // copy log files to work dir
            File logDir = settingService.getLogDir();
            String[] logFiles = logDir.list();

            for (int i = 0; i < logFiles.length; i++) {
                File src = new File(FilenameUtils.concat(logDir
                        .getAbsolutePath(), logFiles[i]));
                FileUtils.copyFileToDirectory(src, workDir);
            }

            result.getAuditEntries().add(makeEntry("Compressing log files..."));

            // setup archive file
            SimpleDateFormat format = new SimpleDateFormat(TIMESTAMP_FORMAT);
            String timeStamp = format.format(new Date());

            String outputFileName = ARCHIVE_NAME + "_" + timeStamp + ".zip";

            String outputFilePath = FilenameUtils.concat(tempDirName,
                    outputFileName);

            result.getAuditEntries().add(
                    makeEntry("Output file: " + outputFilePath));

            compressionService.zip(outputFilePath, workDir.getAbsolutePath());

            File outputFile = new File(outputFilePath);

            if (!outputFile.exists()) {
                throw new RuntimeException("Output file does not exist");
            }

            Document doc = new Document();
            result.getAuditEntries().add(makeEntry("Creating document..."));

            result.getAuditEntries().add(makeEntry("Result: " + outputFile));

            doc.setType(CommonContentType.ZIP);

            doc.setDocumentName(FilenameUtils.getName(outputFile
                    .getAbsolutePath()));

            doc.setContent(FileUtils.readFileToByteArray(outputFile));

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

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

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
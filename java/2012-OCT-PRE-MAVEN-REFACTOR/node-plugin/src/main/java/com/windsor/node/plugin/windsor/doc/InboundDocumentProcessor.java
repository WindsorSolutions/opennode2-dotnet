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

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;

/**
 * @author mchmarny
 * 
 */
public class InboundDocumentProcessor extends BaseWnosPlugin {

    public static final String ARG_TARGET_DIR_PATH = "targetDirPath";
    public static final String ARG_TARGET_DIR_PATH_QUALIFIER = "folderQualifier";

    public static final String PATH_QUALIFIER_NONE = "";
    public static final String PATH_QUALIFIER_TRAN = "TRAN";
    public static final String PATH_QUALIFIER_USER = "USER";

    public InboundDocumentProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_TARGET_DIR_PATH, "");
        getConfigurationArguments().put(ARG_TARGET_DIR_PATH_QUALIFIER, "");

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        getTargetDirPath();

        debug("Plugin validated");

    }

    private File getAndMakeQualifiedTargetDirPath(NodeTransaction transaction) {

        debug("Parsing qualified path from transaction...");

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

        debug("Transaction Creator: "
                + transaction.getCreator().getNaasUserName());

        if (StringUtils.isBlank(transaction.getNetworkId())) {
            throw new RuntimeException("Null transaction network Id");
        }

        debug("Transaction Id: " + transaction.getNetworkId());

        File rootDir = getTargetDirPath();

        debug("Root Dir: " + rootDir);

        String qualifiedDirType = getOptionalConfigValueAsString(ARG_TARGET_DIR_PATH_QUALIFIER);

        debug("Folder Qualification Type: " + qualifiedDirType);

        if (StringUtils.isBlank(qualifiedDirType)) {
            return rootDir;
        }

        String qualifiedDirName = null;

        if (qualifiedDirType.trim().toUpperCase().equals(PATH_QUALIFIER_TRAN)) {
            qualifiedDirName = transaction.getNetworkId();
        } else if (qualifiedDirType.trim().toUpperCase().equals(
                PATH_QUALIFIER_USER)) {
            qualifiedDirName = transaction.getCreator().getNaasUserName();
        } else {
            throw new RuntimeException("Invalid directory qualifier: "
                    + qualifiedDirType + ". Expected: empty string or "
                    + PATH_QUALIFIER_TRAN + " or " + PATH_QUALIFIER_USER);
        }

        debug("Subfolder Name: " + qualifiedDirName);

        String qualifiedDirPath = FilenameUtils.concat(rootDir
                .getAbsolutePath(), qualifiedDirName);

        debug("Subfolder Path: " + qualifiedDirPath);

        File qualifiedDir = new File(qualifiedDirPath);

        try {
            debug("Creating Subfolder...");
            FileUtils.forceMkdir(qualifiedDir);
        } catch (IOException ioex) {
            throw new RuntimeException("Error while creating dir: "
                    + qualifiedDirPath);
        }

        debug("Result: " + qualifiedDir);
        return qualifiedDir;

    }

    private File getTargetDirPath() {

        debug("Parsing Root Folder...");

        String targetDirPath = getRequiredConfigValueAsString(ARG_TARGET_DIR_PATH);

        debug("Root Folder Path: " + targetDirPath);

        if (StringUtils.isBlank(targetDirPath)) {
            throw new RuntimeException(ARG_TARGET_DIR_PATH + " not set");
        }

        File targetDir = new File(targetDirPath);

        if (!targetDir.exists()) {
            throw new RuntimeException("Directory does not exist: "
                    + targetDirPath);
        }

        if (!targetDir.isDirectory()) {
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

            result.getAuditEntries().add(
                    makeEntry("Validating transaction and documents..."));

            validateTransaction(transaction);

            if (transaction.getDocuments() == null) {
                throw new RuntimeException(
                        "Invalid number of documents. At least one required");
            }

            result.getAuditEntries().add(makeEntry("Parsing target folder..."));

            File targetDir = getAndMakeQualifiedTargetDirPath(transaction);

            result.getAuditEntries().add(
                    makeEntry("Target folder: " + targetDir));

            for (int i = 0; i < transaction.getDocuments().size(); i++) {
                Document doc = (Document) transaction.getDocuments().get(i);

                result.getAuditEntries().add(
                        makeEntry("Document Name: " + doc.getDocumentName()));

                String documentTragetPath = FilenameUtils.concat(targetDir
                        .getAbsolutePath(), doc.getDocumentName());

                result.getAuditEntries()
                        .add(
                                makeEntry("Writing Document To: "
                                        + documentTragetPath));

                FileUtils.writeByteArrayToFile(new File(documentTragetPath),
                        doc.getContent());

                result.getAuditEntries().add(makeEntry("Document Saved"));

            }

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
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

}
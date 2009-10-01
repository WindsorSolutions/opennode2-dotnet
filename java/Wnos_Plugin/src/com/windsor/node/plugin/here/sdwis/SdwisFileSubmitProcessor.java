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
package com.windsor.node.plugin.here.sdwis;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipException;
import java.util.zip.ZipFile;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.here.dao.HereDao;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class SdwisFileSubmitProcessor extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "HERE-SDWIS";
    public static final String ARG_ENDPOINT = "EndpointUri";
    public static final String ARG_FAC_INDICATOR = "IsFacilitySourceIndicator";

    public static final String ERR_XML_NO_INVENTORY = "Xml file was submitted, but name doesn't include \"inventory\"";
    public static final String ERR_ZIP_NO_INVENTORY = "Couldn't find a ZipEntry with \"inventory\" in the name";
    public static final String ERR_ZIP_TOO_MANY_ENTRIES = "Found more than one ZipEntry, only one allowed.";

    private static final String INVENTORY = "INVENTORY";
    private static final String FOUND = "Found ";
    private static final int FULL_REPLACE_DAYS = 9999;

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private ZipCompressionService compressionService;
    private HereDao hereDao;
    private String sourceSysName;
    private String endpointUri;
    private String isFacilitySourceIndicator;

    public SdwisFileSubmitProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_ENDPOINT, "");
        getConfigurationArguments().put(ARG_FAC_INDICATOR, "");
        getConfigurationArguments().put(ARG_SOURCE_SYS_NAME, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_TARGET, null);

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the data sources are set
        if (!getDataSources().containsKey(ARG_DS_TARGET)) {
            throw new RuntimeException("Source data source not set");
        }

        hereDao = new HereDao((DataSource) getDataSources().get(ARG_DS_TARGET));

        if (null == sourceSysName) {
            sourceSysName = getRequiredConfigValueAsString(ARG_SOURCE_SYS_NAME);
        }
        debug("sourceSysName: " + sourceSysName);

        if (null == endpointUri) {
            endpointUri = (String) getRequiredConfigValueAsString(ARG_ENDPOINT);
        }
        debug("endpointUri: " + endpointUri);

        if (null == isFacilitySourceIndicator) {
            isFacilitySourceIndicator = (String) getRequiredConfigValueAsString(ARG_FAC_INDICATOR);
        }
        debug("isFacilitySourceIndicator: " + sourceSysName);

        if (null == settingService) {
            settingService = (SettingServiceProvider) getServiceFactory()
                    .makeService(SettingServiceProvider.class);
        }

        if (settingService == null) {
            throw new RuntimeException(
                    "Unable to obtain SettingServiceProvider");
        }

        idGenerator = (IdGenerator) getServiceFactory().makeService(
                IdGenerator.class);

        if (idGenerator == null) {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }

        compressionService = (ZipCompressionService) getServiceFactory()
                .makeService(ZipCompressionService.class);

        if (null == compressionService) {
            throw new RuntimeException(
                    "Couldn't get instance of ZipCompressionService");
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

        result.getAuditEntries().add(makeEntry("Vaildating transaction..."));
        validateTransaction(transaction);

        if (!transaction.getWebMethod().equals(NodeMethodType.SUBMIT)) {

            String mesg = "Invalid method type: " + transaction.getWebMethod();
            result.getAuditEntries().add(makeEntry(mesg));

            throw new RuntimeException(mesg);
        }

        int numOfDocs = 0;

        if (transaction.getDocuments() == null
                || transaction.getDocuments().size() != 1) {

            if (transaction.getDocuments() != null) {
                numOfDocs = transaction.getDocuments().size();
            }

            String mesg = "Invalid number of documents: " + numOfDocs;
            result.getAuditEntries().add(makeEntry(mesg));
            throw new RuntimeException(mesg);
        }

        try {

            Document submission = transaction.getDocuments().get(0);

            verifySubmission(submission);

            saveToManifest(transaction);

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            submission.setDocumentStatus(CommonTransactionStatusCode.PROCESSED);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + "Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    /* protected so we can test it */
    protected boolean verifySubmission(Document submission) {

        boolean result = false;
        String mesg = null;

        String submissionName = submission.getDocumentName();

        /* if it's an xml doc, does the name include "INVENTORY"? */
        if (submission.getType().equals(CommonContentType.XML)) {

            debug("Xml file " + submissionName + " was submitted.");

            if (StringUtils.containsIgnoreCase(submissionName, INVENTORY)) {

                result = true;

            } else {

                mesg = ERR_XML_NO_INVENTORY;
                error(mesg);
                throw new RuntimeException(mesg);
            }
            /*
             * if it's a zip doc, does it have just 1 entry for which the name
             * includes "inventory"?
             */
        } else if (submission.getType().equals(CommonContentType.ZIP)) {

            debug("Zip file "
                    + submissionName
                    + " was submitted, looking for a single Inventory xml document");

            result = checkZippedDocForInventoryXml(submission);
        }

        return result;
    }

    private boolean checkZippedDocForInventoryXml(Document submission) {

        boolean result = false;
        ZipFile submittedZip = null;

        File submittedFile = docToFile(submission);

        debug("Creating Zip file from Document named "
                + submission.getDocumentName());

        try {

            submittedZip = new ZipFile(submittedFile);

        } catch (ZipException e) {

            throw new RuntimeException(
                    "Caught ZipException: " + e.getMessage(), e);

        } catch (IOException e) {

            handleIoException(e);
        }

        debug("Scanning " + submittedFile.getName()
                + " for entries with \"inventory\" in the name");

        ArrayList<? extends ZipEntry> entries = Collections.list(submittedZip
                .entries());

        debug(FOUND + entries.size() + " entry/ies in "
                + submittedFile.getName());

        if (entries.size() > 1) {

            throw new RuntimeException(ERR_ZIP_TOO_MANY_ENTRIES);

        } else if (entries.size() < 1) {

            throw new RuntimeException(ERR_ZIP_NO_INVENTORY);

        } else {

            ZipEntry entry = entries.get(0);

            debug("Found single entry named " + entry.getName());

            if (StringUtils.containsIgnoreCase(entry.getName(), INVENTORY)) {

                result = true;

            } else {

                throw new RuntimeException(ERR_ZIP_NO_INVENTORY);
            }
        }

        return result;
    }

    private File docToFile(Document submission) {

        File submittedFile = null;

        try {
            submittedFile = new File(FilenameUtils.concat(settingService
                    .getTempDir().getAbsolutePath(), submission
                    .getDocumentName()));

            FileUtils.writeByteArrayToFile(submittedFile, submission
                    .getContent());

        } catch (IOException e) {

            handleIoException(e);
        }

        return submittedFile;
    }

    private void saveToManifest(NodeTransaction transaction) {

        debug("Saving results...");
        hereDao.saveResults(transaction.getNetworkId(), transaction.getFlow()
                .getName(), endpointUri, Boolean.valueOf(
                isFacilitySourceIndicator).booleanValue(), sourceSysName,
                FULL_REPLACE_DAYS);

    }

    protected void validateTransaction(NodeTransaction tran) {

        super.validateTransaction(tran);

        if (null == tran.getDocuments() || tran.getDocuments().size() != 1) {
            throw new RuntimeException("Transaction must contain one Document.");
        }
    }

    private void handleIoException(IOException e) {

        throw new RuntimeException("Caught IOException: " + e.getMessage(), e);
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    public String getSourceSysName() {
        return sourceSysName;
    }

    public void setSourceSysName(String sourceSysName) {
        this.sourceSysName = sourceSysName;
    }

    public String getEndpointUri() {
        return endpointUri;
    }

    public void setEndpointUri(String endpointUri) {
        this.endpointUri = endpointUri;
    }

    public String getIsFacilitySourceIndicator() {
        return isFacilitySourceIndicator;
    }

    public void setIsFacilitySourceIndicator(String isFacilitySourceIndicator) {
        this.isFacilitySourceIndicator = isFacilitySourceIndicator;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

}

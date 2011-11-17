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

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
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
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.sdwis.dao.HereDao;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.client.DualEndpointNodeClientFactory;
import com.windsor.node.service.helper.client.NodeClientFactory;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class SdwisSubmissionRelayProcessor extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "SDWIS";
    public static final String ARG_HERE_ENDPOINT_NAME = "HereEndpointUri";
    public static final String ARG_HERE_FAC_INDICATOR = "HereIsFacilitySource";
    public static final String ARG_HERE_SOURCE_SYS_NAME = "HereSourceSystemName";
    public static final String ARG_HERE_DS = "HereDataSource";
    public static final String ARG_HERE_FILENAME_FILTER = "HereFileNameFilter";

    public static final String ARG_SUBMIT_ENDPOINT_URI = "SubmitEndpointUri";
    public static final String ARG_SUBMIT_PASSWORD = "SubmitPassword";
    public static final String ARG_SUBMIT_USERNAME = "SubmitUsername";

    public static final String ERR_XML_NO_INVENTORY = "Xml file was submitted, but name doesn't include \"inventory\"";
    public static final String ERR_ZIP_NO_INVENTORY = "Couldn't find a ZipEntry with \"inventory\" in the name";
    public static final String ERR_ZIP_TOO_MANY_ENTRIES = "Found more than one ZipEntry, only one allowed.";

    private static final String FOUND = "Found ";
    private static final int FULL_REPLACE_DAYS = 9999;

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private HereDao hereDao;
    private String hereSourceSysName;
    private String hereEndpointUriName;
    private String hereIsFacilitySource;
    private String hereFileNameFilter;
    private String submitEndpointUri;
    private String submitPassword;
    private String submitUserName;
    private DualEndpointNodeClientFactory clientFactory;

    public SdwisSubmissionRelayProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_HERE_ENDPOINT_NAME, "");
        getConfigurationArguments().put(ARG_HERE_FAC_INDICATOR, "");
        getConfigurationArguments().put(ARG_HERE_SOURCE_SYS_NAME, "");
        getConfigurationArguments().put(ARG_HERE_FILENAME_FILTER, "");
        getConfigurationArguments().put(ARG_SUBMIT_ENDPOINT_URI, "");
        getConfigurationArguments().put(ARG_SUBMIT_USERNAME, "");
        getConfigurationArguments().put(ARG_SUBMIT_PASSWORD, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_HERE_DS, null);

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        validateDataSources();

        validateHereSettings();

        validateSubmissionSettings();

        validateHelpers();

        debug("Plugin validated");

    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        result.getAuditEntries().add(makeEntry("Validating transaction..."));
        validateTransaction(transaction);

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

            // submit to EPA
            result.getAuditEntries().add(
                    makeEntry("Configuring client for submitting to "
                            + submitEndpointUri));
            NodeClientService client = null;

            if (StringUtils.isBlank(getSubmitUserName())
                    || StringUtils.isBlank(getSubmitPassword())) {

                result.getAuditEntries().add(
                        makeEntry("Using the Node's id & password to submit."));

                NAASConfig naasConfig = (NAASConfig) getServiceFactory()
                        .makeService(NAASConfig.class);

                client = createClientForIdAndPasswd(naasConfig
                        .getRuntimeAccount().getUsername(), naasConfig
                        .getRuntimeAccount().getPassword(),
                        getSubmitEndpointUri());

            } else {

                result.getAuditEntries().add(
                        makeEntry("Submitting for user id "
                                + getSubmitUserName()));

                client = createClientForIdAndPasswd(getSubmitUserName(),
                        getSubmitPassword(), getSubmitEndpointUri());
            }

            if (client == null) {
                throw new RuntimeException(
                        "Couldn't configure Node Client for "
                                + submitEndpointUri);
            }

            result.getAuditEntries()
                    .add(makeEntry("Submitting transaction..."));
            client.submit(transaction);

            result
                    .getAuditEntries()
                    .add(
                            makeEntry("Submission succeeded, recording in HERE Manifest..."));

            saveToManifest(transaction);

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            submission.setDocumentStatus(CommonTransactionStatusCode.Processed);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + "Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    private NodeClientService createClientForIdAndPasswd(String name,
            String passwd, String endpointUri) throws MalformedURLException {
        NodeClientService client;
        NAASAccount credentials = new NAASAccount();
        credentials.setAuthMethod("password");
        credentials.setUsername(name);
        credentials.setPassword(passwd);

        PartnerIdentity partner = new PartnerIdentity();
        partner.setUrl(new URL(endpointUri));

        /*
         * try to guess the endpoint version - PartnerIdentity defaults to EN20
         */
        if (endpointUri.endsWith("ENService11.asmx")
                || endpointUri.endsWith("v11") || endpointUri.endsWith("V10")) {

            partner.setVersion(EndpointVersionType.EN11);
        }

        debug("Submission target endpoint version: " + partner.getVersion());

        client = getClientFactory().makeAndConfigure(partner, credentials);
        return client;
    }

    /* protected so we can test it */
    protected boolean verifySubmission(Document submission) {

        boolean result = false;
        String mesg = null;

        String submissionName = submission.getDocumentName();

        /*
         * if it's an xml doc, does the name include the value of
         * hereFileNameFilter?
         */
        if (submission.getType().equals(CommonContentType.XML)) {

            debug("Xml file " + submissionName + " was submitted.");

            if (StringUtils.containsIgnoreCase(submissionName,
                    hereFileNameFilter)) {

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

            if (StringUtils.containsIgnoreCase(entry.getName(),
                    hereFileNameFilter)) {

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
                .getName(), hereEndpointUriName, Boolean.valueOf(
                hereIsFacilitySource).booleanValue(), hereSourceSysName,
                FULL_REPLACE_DAYS);

    }

    protected void validateTransaction(NodeTransaction tran) {

        super.validateTransaction(tran);

        if (!tran.getWebMethod().equals(NodeMethodType.SUBMIT)) {
            throw new RuntimeException("Invalid method type: "
                    + tran.getWebMethod());
        }

        if (null == tran.getDocuments() || tran.getDocuments().size() != 1) {
            throw new RuntimeException("Transaction must contain one Document.");
        }
    }

    private void handleIoException(IOException e) {

        throw new RuntimeException("Caught IOException: " + e.getMessage(), e);
    }

    private void validateDataSources() {

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the data sources are set
        if (!getDataSources().containsKey(ARG_HERE_DS)) {
            throw new RuntimeException("Source data source not set");
        }

        hereDao = new HereDao((DataSource) getDataSources().get(ARG_HERE_DS));
        debug("HereDao configured.");
    }

    private void validateHereSettings() {

        if (null == hereSourceSysName) {
            hereSourceSysName = getRequiredConfigValueAsString(ARG_HERE_SOURCE_SYS_NAME);
        }
        debug("hereSourceSysName: " + hereSourceSysName);

        if (null == hereEndpointUriName) {
            hereEndpointUriName = (String) getRequiredConfigValueAsString(ARG_HERE_ENDPOINT_NAME);
        }
        debug("hereEndpointUriName: " + hereEndpointUriName);

        if (null == hereIsFacilitySource) {
            hereIsFacilitySource = (String) getRequiredConfigValueAsString(ARG_HERE_FAC_INDICATOR);
        }
        debug("hereIsFacilitySource: " + hereSourceSysName);

        if (null == hereFileNameFilter) {
            hereFileNameFilter = (String) getRequiredConfigValueAsString(ARG_HERE_FILENAME_FILTER);
        }
        debug("hereFileNameFilter: " + hereFileNameFilter);

    }

    private void validateSubmissionSettings() {

        if (null == submitEndpointUri) {
            submitEndpointUri = (String) getRequiredConfigValueAsString(ARG_SUBMIT_ENDPOINT_URI);
        }
        debug("submitEndpointUri: " + submitEndpointUri);

        if (null == submitPassword) {
            submitPassword = (String) getOptionalConfigValueAsString(ARG_SUBMIT_PASSWORD);
        }
        debug("submitPassword: " + submitPassword);

        if (null == submitUserName) {
            submitUserName = (String) getOptionalConfigValueAsString(ARG_SUBMIT_USERNAME);
        }
        debug("submitUserName: " + submitUserName);
    }

    private void validateHelpers() {

        if (null == settingService) {
            setSettingService((SettingServiceProvider) getServiceFactory()
                    .makeService(SettingServiceProvider.class));
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

        clientFactory = (DualEndpointNodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        if (clientFactory == null) {
            throw new RuntimeException("Unable to obtain clientFactory");
        }
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

    public SettingServiceProvider getSettingService() {
        return settingService;
    }

    public void setSettingService(SettingServiceProvider settingService) {
        this.settingService = settingService;
    }

    public String getHereSourceSysName() {
        return hereSourceSysName;
    }

    public void setHereSourceSysName(String hereSourceSysName) {
        this.hereSourceSysName = hereSourceSysName;
    }

    public String getHereEndpointUriName() {
        return hereEndpointUriName;
    }

    public void setHereEndpointUriName(String hereEndpointUriName) {
        this.hereEndpointUriName = hereEndpointUriName;
    }

    public String getHereIsFacilitySource() {
        return hereIsFacilitySource;
    }

    public void setHereIsFacilitySource(String hereIsFacilitySource) {
        this.hereIsFacilitySource = hereIsFacilitySource;
    }

    public String getHereFileNameFilter() {
        return hereFileNameFilter;
    }

    public void setHereFileNameFilter(String hereFileNameFilter) {
        this.hereFileNameFilter = hereFileNameFilter;
    }

    public String getSubmitPassword() {
        return submitPassword;
    }

    public void setSubmitPassword(String submitPassword) {
        this.submitPassword = submitPassword;
    }

    public String getSubmitUserName() {
        return submitUserName;
    }

    public void setSubmitUserName(String submitUserName) {
        this.submitUserName = submitUserName;
    }

    public String getSubmitEndpointUri() {
        return submitEndpointUri;
    }

    public void setSubmitEndpointUri(String submitEndpointUri) {
        this.submitEndpointUri = submitEndpointUri;
    }

    public DualEndpointNodeClientFactory getClientFactory() {
        return clientFactory;
    }

    public void setClientFactory(DualEndpointNodeClientFactory clientFactory) {
        this.clientFactory = clientFactory;
    }

}

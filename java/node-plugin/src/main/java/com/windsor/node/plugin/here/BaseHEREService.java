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

package com.windsor.node.plugin.here;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceRequestAuthorizationType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.UserAccessPolicy;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.jdbc.JdbcAccountDao;
import com.windsor.node.data.dao.jdbc.JdbcFlowDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.plugin.here.dao.HereDao;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public abstract class BaseHEREService extends BaseWnosPlugin {

    /*
     * Runtime argument names.
     */
    public static final String ARG_ENDPOINT = "EndpointUri";
    public static final String ARG_FAC_INDICATOR = "IsFacilitySourceIndicator";

    /*
     * Velocity template names.
     */
    public static final String CAFO_TEMPLATE_NAME = "CAFO.vm";
    public static final String DOMAIN_TEMPLATE_NAME = "HERE-Domain.vm";
    public static final String FACID_TEMPLATE_NAME = "FACID_FacilityDetails.vm";
    public static final String FRS_TEMPLATE_NAME = "FRS23.vm";
    public static final String FRS_DELETED_TEMPLATE_NAME = "DeletedFRS23.vm";
    public static final String MANIFEST_TEMPLATE_NAME = "HERE-Manifest.vm";
    public static final String TANKS_TEMPLATE_NAME = "TANKS.vm";
    public static final String TIER2_TEMPLATE_NAME = "TIER2.vm";

    /*
     * Helpers
     */

    private VelocityHelper velocityHelper;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private String sourceSysName;
    private String endpointUri;
    private String isFacilitySourceIndicator;
    private HereDao hereDao;
    private FlowDao flowDao;
    private AccountDao accountDao;

    public BaseHEREService() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_ENDPOINT, "");
        getConfigurationArguments().put(ARG_FAC_INDICATOR, "");
        getConfigurationArguments().put(ARG_SOURCE_SYS_NAME, "");

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);
        getDataSources().put(ARG_DS_TARGET, null);

        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        velocityHelper = new JdbcVelocityHelper();

    }

    protected File getTempDir() {
        return settingService.getTempDir();
    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the data sources are set
        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source data source not set");
        }

        if (!getDataSources().containsKey(ARG_DS_TARGET)) {
            throw new RuntimeException("Target data source not set");
        }

        sourceSysName = getRequiredConfigValueAsString(ARG_SOURCE_SYS_NAME);
        debug("sourceSysName: " + sourceSysName);

        endpointUri = (String) getRequiredConfigValueAsString(ARG_ENDPOINT);
        debug("endpointUri: " + endpointUri);

        isFacilitySourceIndicator = (String) getRequiredConfigValueAsString(ARG_FAC_INDICATOR);
        debug("isFacilitySourceIndicator: " + isFacilitySourceIndicator);

        // configure the vel helper with the plugin dir and ds
        velocityHelper.configure((DataSource) getDataSources().get(
                ARG_DS_SOURCE), getPluginSourceDir().getAbsolutePath());

        hereDao = new HereDao((DataSource) getDataSources().get(ARG_DS_TARGET));

        flowDao = (JdbcFlowDao) getServiceFactory().makeService(
                JdbcFlowDao.class);

        if (null == flowDao) {
            throw new RuntimeException("Couldn't get instance of JdbcFlowDao");
        }

        accountDao = (JdbcAccountDao) getServiceFactory().makeService(
                JdbcAccountDao.class);

        if (null == accountDao) {
            throw new RuntimeException(
                    "Couldn't get instance of JdbcAccountDao");
        }

        settingService = (SettingServiceProvider) getServiceFactory()
                .makeService(SettingServiceProvider.class);

        if (settingService == null) {
            throw new RuntimeException(
                    "Unable to obtain SettingServiceProvider");
        }

        idGenerator = (IdGenerator) getServiceFactory().makeService(
                IdGenerator.class);

        if (idGenerator == null) {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }

        compressionService = (CompressionService) getServiceFactory()
                .makeService(CompressionService.class);

        if (compressionService == null) {
            throw new RuntimeException("Unable to obtain CompressionService");
        }

        debug("Finished validating property set");

    }

    protected File getResultFile(HEREArgs args) throws IOException {

        File resultFile = new File(args.getTempFileName());
        if (!resultFile.exists()) {
            throw new IOException("Result file not found: "
                    + args.getTempFileName());
        }

        return resultFile;

    }

    protected ProcessContentResult process(NodeTransaction transaction,
            String templateName, boolean argAsDate) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        /*
         * these could throw fatal errors, and we want the real err message to
         * reach the client, so we call outside the try/catch block
         */
        result.getAuditEntries().add(makeEntry("Validating transaction..."));
        validateTransaction(transaction);

        HEREArgs args = new HEREArgs(transaction, getTempDir(), argAsDate);
        logger.debug("Args: " + args);

        try {

            velocityHelper.setTemplateArg("changeDate", args.toXmlDate(args
                    .getChangeDate()));

            velocityHelper.setTemplateArg("changeDateTime", args
                    .getChangeDateTime());

            velocityHelper.setTemplateArg("flowId", args.getFlowId());

            velocityHelper.setTemplateArg("serviceName", args.getServiceName());

            velocityHelper.setTemplateArg("numOfDays", new Integer(args
                    .getNumOfDays()));

            if (templateName.equals(MANIFEST_TEMPLATE_NAME)) {

                velocityHelper.setTemplateArg("userFlowNames",
                        setUpManifestTemplate(transaction));
            }

            /* EXECUTE */
            result.getAuditEntries().add(makeEntry("Executing request..."));

            int mergedRecordCount = velocityHelper.merge(templateName, args
                    .getTempFilePath());

            result.getAuditEntries().add(
                    makeEntry("Result records: " + mergedRecordCount));

            /* COMPRESSION */

            Document doc = new Document();

            if (transaction.getRequest().getType() != RequestType.Query) {

                result.getAuditEntries().add(
                        makeEntry("Compressing results..."));
                String zippedFilePath = getCompressionService().zip(
                        args.getTempFilePath());
                result.getAuditEntries().add(
                        makeEntry("Result: " + zippedFilePath));
                doc.setType(CommonContentType.ZIP);

                doc.setDocumentName(FilenameUtils.getName(zippedFilePath));

                doc.setContent(FileUtils.readFileToByteArray(new File(
                        zippedFilePath)));

            } else {
                doc.setType(CommonContentType.XML);
                doc.setDocumentName(FilenameUtils.getName(args
                        .getTempFilePath()));
                doc.setContent(FileUtils.readFileToByteArray(new File(args
                        .getTempFilePath())));
            }

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

            /* SAVE RESULTS */
            // only if the template processed any records
            if (transaction.getRequest().getType() != RequestType.Query
                    && mergedRecordCount > 0) {
                saveResults(args, transaction);
            }

        } catch (Exception ex) {

            error(ex);

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        return result;

    }

    protected void saveResults(HEREArgs args, NodeTransaction transaction) {

        if (StringUtils.isBlank(transaction.getId())) {
            throw new IllegalArgumentException("CurrentTransactionId not set");
        }

        Boolean isFacilityInd = Boolean.valueOf(isFacilitySourceIndicator);

        if (isFacilityInd == null) {
            throw new IllegalArgumentException("Invalid argument value: "
                    + ARG_FAC_INDICATOR + " = " + isFacilitySourceIndicator);
        }

        logger.debug("Saving results...");
        hereDao.saveResults(transaction.getNetworkId(), transaction.getFlow()
                .getName(), endpointUri, isFacilityInd.booleanValue(),
                sourceSysName, args.getNumOfDays());

    }

    protected SettingServiceProvider getSettingService() {
        return settingService;
    }

    protected IdGenerator getIdGenerator() {
        return idGenerator;
    }

    protected CompressionService getCompressionService() {
        return compressionService;
    }

    protected HereDao getHereDao() {
        return hereDao;
    }

    /**
     * The Manifest needs to exclude flows that the requesting user is not
     * permitted to see.
     * 
     * @param tran
     */
    private List<String> setUpManifestTemplate(NodeTransaction tran) {

        debug("setUpManifestTemplate...");

        List<DataFlow> userFlows = flowDao.getUnsecuredFlows();
        int unsecuredFlowCount = userFlows.size();
        debug("Found " + unsecuredFlowCount + " unsecured Flows on this Node");

        UserAccount user = tran.getRequest().getRequestor();

        if (null == user) {

            debug("No Requestor in transaction, using Node's runtime account.");
            NAASConfig naasConfig = (NAASConfig) getServiceFactory()
                    .makeService(NAASConfig.class);
            NAASAccount runtimeAccount = naasConfig.getRuntimeAccount();
            user = accountDao.getByNAASAccount(runtimeAccount.getUsername());
        }
        debug("Requestor: " + user);

        for (UserAccessPolicy policy : user.getPolicies()) {

            if (policy.getPolicyType().equals(
                    ServiceRequestAuthorizationType.Flow)) {

                debug("Found a flow policy for " + user.getNaasUserName());

                DataFlow flow = flowDao.get(policy.getTypeQualifier());

                debug("Adding flow \"" + flow.getName()
                        + "\" to user's flow list...");

                userFlows.add(flow);
            }
        }

        debug("Found " + (userFlows.size() - unsecuredFlowCount)
                + " secured flow(s) for " + user.getNaasUserName());

        List<String> userFlowNames = new ArrayList<String>();

        for (DataFlow userFlow : userFlows) {

            userFlowNames.add(userFlow.getName());
        }

        return userFlowNames;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }

}

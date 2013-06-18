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

package com.windsor.node.plugin.flowsecurity;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcAccountDao;
import com.windsor.node.data.dao.jdbc.JdbcFlowDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.VelocityHelperImpl;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

/**
 * Generates an XML file specified by GetAuthorizedUsersResponse.xsd.
 */
public class GetAuthorizedUsersRequestProcessor extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "GetAuthorizedUsers";
    public static final String TEMPLATE_NAME = "GetAuthorizedUsersResponse.vm";

    private FlowDao flowDao;
    private AccountDao accountDao;

    private ZipCompressionService compressionService;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private AuthorizedUserListHelper authorizedUserListHelper;
    private VelocityHelper velocityHelper;
    private NAASConfig naasConfig;

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("GetAuthorizedUsersRequestProcessor");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Creates a list of Authorized Users on this OpenNode2 instance.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetAuthorizedUsersRequestProcessor.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public GetAuthorizedUsersRequestProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        getSupportedPluginTypes().add(ServiceType.QUERY);

        velocityHelper = new VelocityHelperImpl();

        debug("Plugin initialized");
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

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

        compressionService = (ZipCompressionService) getServiceFactory()
                .makeService(ZipCompressionService.class);

        if (null == compressionService) {
            throw new RuntimeException(
                    "Couldn't get instance of ZipCompressionService");
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

        naasConfig = (NAASConfig) getServiceFactory().makeService(
                NAASConfig.class);

        if (naasConfig == null) {
            throw new RuntimeException("Unable to obtain NAASConfig");
        }

        authorizedUserListHelper = new AuthorizedUserListHelper();
        authorizedUserListHelper.setAccountDao(accountDao);
        authorizedUserListHelper.setFlowDao(flowDao);

        velocityHelper = new VelocityHelperImpl();

        velocityHelper.configure(getPluginSourceDir().getAbsolutePath());

        debug("Plugin configured");

    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        validateTransaction(transaction);

        try {
            result.getAuditEntries().add(makeEntry("Executing request..."));

            List<AuthorizedUser> authedUsers = authorizedUserListHelper
                    .getAuthorizedUserList(naasConfig.getNodeId());

            result.getAuditEntries().add(
                    makeEntry("Retrieved list of " + authedUsers.size()
                            + " authorized users and their flow names"));

            velocityHelper.setTemplateArg("authorizedUserList", authedUsers);

            String targetFileName = SERVICE_NAME + idGenerator.createId()
                    + ".xml";

            File tempDir = new File(settingService.getTempFilePath());

            FileUtils.forceMkdir(tempDir);

            String targetFilePath = FilenameUtils.concat(tempDir
                    .getAbsolutePath(), targetFileName);

            result.getAuditEntries().add(
                    makeEntry("Generating xml file " + targetFilePath));

            velocityHelper.merge(TEMPLATE_NAME, targetFilePath);

            Document doc = new Document();

            doc.setType(CommonContentType.XML);
            doc.setDocumentName(targetFileName);
            doc.setContent(FileUtils.readFileToByteArray(new File(
                    targetFilePath)));

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
                            + this.getClass().getName() + " Message: "));

            result.getAuditEntries().add(makeEntry(ex.getMessage()));
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

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }
}

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

package com.windsor.node.plugin.beachnotif21;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import javax.sql.DataSource;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.springframework.beans.factory.InitializingBean;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.beachnotif21.dao.BeachNotificationDao;
import com.windsor.node.plugin.common.velocity.VelocityHelper;
import com.windsor.node.plugin.common.velocity.jdbc.JdbcVelocityHelper;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

public class BeachNotificationDocumentGenerator extends BaseWnosPlugin
        implements InitializingBean {

    public static final String SERVICE_NAME = "GetBeachesData_v2.1";

    private static final String OUTFILE_BASE_NAME = "GetBeachesData_v2.1";
    private static final String TEMPLATE_NAME = "BEACH_NOTIF_21.vm";

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private VelocityHelper velocityHelper = new JdbcVelocityHelper();
    private BeachNotificationDao beachNotificationDao;

    public BeachNotificationDocumentGenerator() {
        super();

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, null);

        debug("Setting service type");
        getSupportedPluginTypes().add(ServiceType.TASK);
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Source datasource not set");
        }

        idGenerator = (IdGenerator) getServiceFactory().makeService(
                IdGenerator.class);

        if (idGenerator == null) {
            throw new RuntimeException("Unable to obtain IdGenerator");
        }

        settingService = (SettingServiceProvider) getServiceFactory()
                .makeService(SettingServiceProvider.class);

        if (settingService == null) {
            throw new RuntimeException(
                    "Unable to obtain SettingServiceProvider");
        }

        beachNotificationDao = new BeachNotificationDao((DataSource) getDataSources().get(ARG_DS_SOURCE));
        if(beachNotificationDao == null)
        {
            throw new RuntimeException("Unable to obtain BeachNotificationDao");
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#process(com.windsor.node.common
     * .domain.NodeTransaction)
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");
        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        validateTransaction(transaction);
        debug("transaction is valid");

        try {

            String docId = idGenerator.createId();

            NAASConfig naasConfig = (NAASConfig) getServiceFactory()
                    .makeService(NAASConfig.class);

            String nodeId = naasConfig.getNodeId();

            String tempFilePath = FilenameUtils.concat(settingService
                    .getTempDir().getAbsolutePath(), OUTFILE_BASE_NAME + "_"
                    + nodeId + docId + ".xml");

            velocityHelper.configure((DataSource) getDataSources().get(
                    ARG_DS_SOURCE), getPluginSourceDir().getAbsolutePath());

            velocityHelper.merge(TEMPLATE_NAME, tempFilePath);

            result.getAuditEntries().add(
                    makeEntry("Xml file " + tempFilePath
                            + " generated with template " + TEMPLATE_NAME));

            Document doc = new Document();
            doc.setDocumentId(docId);
            doc.setId(docId);

            doc.setType(CommonContentType.XML);

            doc.setDocumentName(FilenameUtils.getName(tempFilePath));

            doc.setContent(FileUtils
                    .readFileToByteArray(new File(tempFilePath)));

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
            result.getAuditEntries().add(makeEntry("Done: OK"));
            
            beachNotificationDao.updateSentToEPAFlag();

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));
        }

        debug("Returning result: " + result);
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
        // no parameters!
        return null;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

}

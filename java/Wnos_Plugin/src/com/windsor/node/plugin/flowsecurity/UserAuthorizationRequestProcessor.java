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
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.conf.NAASConfig;
import com.windsor.node.data.dao.AccountDao;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.FlowSecurityDao;
import com.windsor.node.data.dao.jdbc.JdbcAccountDao;
import com.windsor.node.data.dao.jdbc.JdbcFlowDao;
import com.windsor.node.data.dao.jdbc.JdbcFlowSecurityDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.flowsecurity.xml.AuthRequestParser;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.windsor.node.service.helper.zip.ZipCompressionService;

/**
 * Receives an xml document, parses it, and loads into the Node metadata db.
 * 
 */
public class UserAuthorizationRequestProcessor extends BaseWnosPlugin {

    public static final String SERVICE_NAME = "AuthorizationRequest";
    public static final String NO_PROTECTED_FLOWS = "This OpenNode installation does not have any protected Flows";
    public static final String USER_HAS_PENDING = ": this user already has a pending Authorization Request";
    public static final String NOT_IN_NAAS_NOT_AFFILITATED = ": this account not found in NAAS and not affiliated with this Node.";

    private FlowSecurityDao flowSecDao;
    private FlowDao flowDao;
    private AccountDao accountDao;

    private ZipCompressionService compressionService;
    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private NAASConfig naasConfig;

    public UserAuthorizationRequestProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        flowSecDao = (JdbcFlowSecurityDao) getServiceFactory().makeService(
                JdbcFlowSecurityDao.class);

        if (null == flowSecDao) {
            throw new RuntimeException(
                    "Couldn't get instance of JdbcFlowSecurityDao");
        }

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
            throw new RuntimeException("Unable to obtain naasConfig");
        }

        debug("Plugin configured");

    }

    /**
     * Save the AuthorizationRequest if:
     * <ol>
     * <li>The Node has protected flows</li>
     * <li>The user requesting access to protected flows has no pending,
     * unprocessed requests</li>
     * <li>The requestor either has a NAAS account (and this Node has synched to
     * NAAS recently enough to have the requestor's NAAS id in the local
     * database), OR is affiliated with this Node</li>
     * </ol>
     * 
     * <p>
     * If any of these tests fail, the NodeTransaction is marked as FAILED,
     * otherwise it is marked as PROCESSED. Its status will be changed by the
     * Node Administrator who reviews the request.
     * </p>
     * 
     * @see com.windsor.node.plugin.BaseWnosPlugin#process(com.windsor.node.common
     *      .domain.NodeTransaction)
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            /* 1: If Node doesn't have protected flows, reject submission */
            if (!nodeHasProtectedFlows()) {
                throw new RuntimeException(NO_PROTECTED_FLOWS);
            }

            result.getAuditEntries().add(
                    makeEntry("Validating transaction and documents..."));

            /* 2: Verify exactly one Document in transaction */
            validateTransaction(transaction);

            /* 3: Get an AuthorizationRequest from the transaction doc */
            result.getAuditEntries().add(makeEntry("Unpacking submission..."));

            Document payload = unpackTransactionDoc(transaction);

            AuthorizationRequest authReq = parseAuthRequest(payload,
                    transaction.getId());

            /* 4: If Naas User has pending submissions, reject */
            if (flowSecDao.hasPending(authReq.getNaasUserName())) {
                throw new RuntimeException(authReq.getNaasUserName()
                        + USER_HAS_PENDING);
            }

            /* 5: Does Naas User in request actually exist in NAAS? */
            /*
             * We assume that our local NAccount table in the Node metadata db
             * is up-to-date w/NAAS
             */
            if (!doesNassUserExist(authReq.getNaasUserName())) {

                /* 6: Is the request affiliated with this Node? */
                if (!authReq.getAffiliatedNodeId().equalsIgnoreCase(
                        naasConfig.getNodeId())) {
                    throw new RuntimeException(authReq.getNaasUserName()
                            + NOT_IN_NAAS_NOT_AFFILITATED);
                }
            } else {

                authReq.setExistsInNaas(true);
            }

            /* 7: Save request for admin review. */
            flowSecDao.saveAuthRequest(authReq);
            result.getAuditEntries().add(
                    makeEntry("Inbound request saved to db."));

            List<Document> docs = new ArrayList<Document>();
            docs.add(payload);
            result.setDocuments(docs);

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

    public void setFlowSecDao(FlowSecurityDao flowSecDao) {
        this.flowSecDao = flowSecDao;
    }

    protected void validateTransaction(NodeTransaction tran) {

        super.validateTransaction(tran);

        if (null == tran.getDocuments() || tran.getDocuments().size() != 1) {
            throw new RuntimeException("Transaction must contain one Document.");
        }
    }

    private Document unpackZipDocument(Document submission) {

        Document doc = new Document();

        try {

            File stageFile = new File(settingService.getTempFilePath("zip"));

            FileUtils.writeByteArrayToFile(stageFile, submission.getContent());

            debug("Zip document staged at: " + stageFile);

            File tempFileDir = new File(FilenameUtils.concat(settingService
                    .getTempDir().getAbsolutePath(), idGenerator.createId()));

            FileUtils.forceMkdir(tempFileDir);

            debug("Uncompressing staged file to: " + tempFileDir);

            compressionService.unzip(stageFile.getAbsolutePath(), tempFileDir
                    .getAbsolutePath());

            String[] uncompressedFileNames = tempFileDir.list();

            if (uncompressedFileNames.length > 1) {

                throw new RuntimeException(
                        "Expected only 1 file in zip archive, found "
                                + uncompressedFileNames.length);
            }

            File uncompressedFile = new File(FilenameUtils.concat(tempFileDir
                    .getAbsolutePath(), uncompressedFileNames[0]));

            debug("Setting document name to " + uncompressedFileNames[0]);
            doc.setDocumentName(uncompressedFileNames[0]);

            debug("Setting content type to XML");
            doc.setType(CommonContentType.XML);

            debug("Setting document content from file...");
            doc.setContent(FileUtils.readFileToByteArray(uncompressedFile));

        } catch (IOException e) {

            throw new RuntimeException("Caught IOException: " + e.getMessage(),
                    e);
        }

        return doc;
    }

    private Document unpackTransactionDoc(NodeTransaction tran) {

        Document processedDoc = null;
        Document docToProcess = tran.getDocuments().get(0);

        debug("Document is of type " + docToProcess.getType().getName());

        if (docToProcess.getType().equals(CommonContentType.ZIP)) {

            processedDoc = unpackZipDocument(docToProcess);

        } else if (docToProcess.getType().equals(CommonContentType.XML)) {

            processedDoc = docToProcess;

        } else {

            throw new RuntimeException("Zip and Xml are only formats supported");
        }

        return processedDoc;
    }

    private AuthorizationRequest parseAuthRequest(Document docToParse,
            String tranId) {

        AuthRequestParser parser = new AuthRequestParser();

        AuthorizationRequest authReq = parser.parseByteArray(docToParse
                .getContent());

        authReq.setTransactionId(tranId);

        return authReq;
    }

    private boolean nodeHasProtectedFlows() {

        boolean hasProtected = false;

        if (null != flowDao.getSecuredFlows()
                && flowDao.getSecuredFlows().size() > 0) {
            hasProtected = true;
        }
        return hasProtected;
    }

    private boolean doesNassUserExist(String naasUserName) {

        boolean b = false;

        UserAccount testForUser = accountDao.getByNAASAccount(naasUserName);

        if (null != testForUser) {
            b = true;
        }

        return b;
    }
}

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
package com.windsor.node.plugin.nct;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;

/**
 * @author mchmarny
 * 
 */
public class SimpleRequestProcessor extends BaseWnosPlugin {

    private static final String QUERY_XML_HEADER = "\n<QueryResult:QueryResult "
            + "\nxmlns:QueryResult=\"http://www.exchangenetwork.net/schema/NCT/1\" "
            + "\nxmlns=\"http://www.exchangenetwork.net/schema/NCT/1\" "
            + "\nxmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";

    private static final String QUERY_XML_FOOTER = "\n</QueryResult:QueryResult>\n";

    private static final String STRING_PARAM = "stringParameter";
    private static final String XML_PARAM = "xmlParameter";

    private static final String ZIPPED = "zipped";
    private static final String UNZIPPED = "unzipped";

    private static final String AUDIT_REPORT_NAME = "Node2.0.Report";

    private static final int MAX_ROWS = 10;

    private SettingServiceProvider settingService;
    private IdGenerator idGenerator;
    private CompressionService compressionService;
    private String resultFilePathBase;

    public SimpleRequestProcessor() {

        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        getSupportedPluginTypes().add(ServiceType.QUERY);
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
        getSupportedPluginTypes().add(ServiceType.EXECUTE);
        getSupportedPluginTypes().add(ServiceType.NOTIFY);
        getSupportedPluginTypes().add(ServiceType.SUBMIT);

        debug("Plugin initialized");

    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

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

        resultFilePathBase = settingService.getTempDir().getAbsolutePath();

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

            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));
            validateTransaction(transaction);

            result.getAuditEntries().add(
                    makeEntry("Parsing test from: "
                            + transaction.getWebMethod().getName()));

            if (transaction.getWebMethod().equals(NodeMethodType.QUERY)) {

                result.setDocuments(processRequest(transaction.getRequest()));

            } else if (transaction.getWebMethod()
                    .equals(NodeMethodType.SOLICIT)
                    || transaction.getWebMethod().equals(
                            NodeMethodType.SCHEDULE)) {

                result.setDocuments(processRequest(transaction.getRequest()));

            }

            /*
             * calculate maxRows and whether this is the last doc of a
             * hypothetical paginated set
             */

            int startRow = transaction.getRequest().getPaging().getStart();
            int rowCount = transaction.getRequest().getPaging().getCount();

            boolean isLast = isLastPage(startRow, rowCount);

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    startRow, getMaxRowsFromPaging(transaction.getRequest()
                            .getPaging()), isLast));

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
     * 
     * Utilities
     */

    private List<Document> processRequest(DataRequest req) {

        if (req == null) {
            throw new RuntimeException("Null request");
        }

        List<Document> resultDocs = new ArrayList<Document>();

        try {

            Document doc = new Document();

            StringBuffer sb = new StringBuffer();

            sb.append(QUERY_XML_HEADER);

            int startRow = req.getPaging().getStart();

            int maxRows = getMaxRowsFromPaging(req.getPaging());

            for (int i = startRow; i < maxRows; i++) {
                sb.append("\n<row>Row " + i + " text</row>");
            }

            sb.append(QUERY_XML_FOOTER);

            logger.debug("Buffered doc content");

            String resultFilePath = FilenameUtils.concat(resultFilePathBase,
                    "NCT-" + req.getService().getName() + "-"
                            + idGenerator.createId() + ".xml");

            File resultFile = new File(resultFilePath);

            FileUtils.writeStringToFile(resultFile, sb.toString(), "UTF-8");

            logger.debug("Wrote buffer to " + resultFilePath);

            if (req.getType().equals(RequestType.SOLICIT)) {

                resultFile = compressionService.zip(resultFile);

                doc.setDocumentName("NCT-SolicitResults.zip");
                doc.setType(CommonContentType.ZIP);

                logger.debug("SOLICIT request, set content type to ZIP");

            } else if (req.getType().equals(RequestType.QUERY)) {

                logger.debug("QUERY request");

                String zipSetting = null;

                if (req.getParameters().containsKey(STRING_PARAM)) {

                    zipSetting = (String) req.getParameters().get(STRING_PARAM);

                } else if (req.getParameters().containsKey(XML_PARAM)) {

                    zipSetting = (String) req.getParameters().get(XML_PARAM);

                }

                logger.debug("zipSetting = " + zipSetting);

                if (StringUtils.isNotBlank(zipSetting)
                        && StringUtils.containsIgnoreCase(zipSetting, UNZIPPED)) {

                    doc.setDocumentName("NCT-QueryResults.xml");
                    doc.setType(CommonContentType.XML);

                } else if (StringUtils.isNotBlank(zipSetting)
                        && StringUtils.containsIgnoreCase(zipSetting, ZIPPED)) {

                    resultFile = compressionService.zip(resultFile);

                    doc.setDocumentName("NCT-QueryResults.zip");
                    doc.setType(CommonContentType.ZIP);
                }

            } else {
                doc.setDocumentName("NCT-QueryResults.xml");
                doc.setType(CommonContentType.XML);
            }

            logger.debug("doc content type set to " + doc.getType().getName());

            doc.setContent(FileUtils.readFileToByteArray(resultFile));
            resultDocs.add(doc);

            return resultDocs;

        } catch (Exception ex) {

            throw new RuntimeException(ex);

        } finally {

            /*
             * create the audit report that the "DownloadAuditReport" test looks
             * for
             */
            String auditFilePath = FilenameUtils.concat(resultFilePathBase,
                    AUDIT_REPORT_NAME);
            File auditFile = new File(auditFilePath);

            try {

                FileUtils
                        .writeStringToFile(
                                auditFile,
                                "Windsor Node 2.0 Audit Report\n\nIs anyone checking this?",
                                "UTF-8");

                Document auditDoc = new Document();
                auditDoc.setDocumentName(AUDIT_REPORT_NAME);
                auditDoc.setContent(FileUtils.readFileToByteArray(auditFile));
                resultDocs.add(auditDoc);

            } catch (IOException ioe) {

                throw new RuntimeException(ioe);
            }
        }

    }

    private int getMaxRowsFromPaging(PaginationIndicator paging) {

        if (paging.getCount() == -1 || paging.getCount() > MAX_ROWS) {

            return MAX_ROWS;

        } else {

            return paging.getCount();
        }
    }

    private boolean isLastPage(int start, int count) {

        boolean b = false;

        if (start == 0 && count == -1) {

            b = true;

        } else if (start > 0 && count == -1) {

            b = false;

        } else if (count - start >= MAX_ROWS) {

            b = true;

        }

        return b;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }
}
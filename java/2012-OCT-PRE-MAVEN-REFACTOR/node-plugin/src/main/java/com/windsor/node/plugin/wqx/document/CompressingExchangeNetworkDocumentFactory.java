package com.windsor.node.plugin.wqx.document;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public class CompressingExchangeNetworkDocumentFactory implements ExchangeNetworkDocumentFactory {

    private final ZipCompressionService zipService;

    private final NodeTransaction nodeTransaction;

    private File folderToZip;

    public CompressingExchangeNetworkDocumentFactory(ZipCompressionService zipService, NodeTransaction nodeTransaction) {
        this.zipService = zipService;
        this.nodeTransaction = nodeTransaction;
    }

    @Override
    public void add(File file) throws IOException {
        prepareZipFolder();
        FileUtils.copyFileToDirectory(file, folderToZip);
    }

    @Override
    public Document make(String documentId) throws IOException {

        Document document = new Document();

        document.setId(documentId);
        document.setDocumentId(documentId);

        File zipFile = zipIt();

        if (folderToZip != null) {
            document.setContent(FileUtils.readFileToByteArray(zipFile));
            document.setType(CommonContentType.ZIP);
            document.setDocumentName(zipFile.getName());
        }

        return document;
    }

    private File zipIt() {
        String zipFileName = zipFileName();
        zipService.zip(zipFileName, folderToZip.getAbsolutePath());
        return new File(zipFileName);
    }

    private void prepareZipFolder() throws IOException {
        if (folderToZip == null) {
            this.folderToZip = new File(zipFolderAbsolutePath());
            FileUtils.forceMkdir(folderToZip);
        }
    }

    private String zipFolderAbsolutePath() {
        return zipService.getTempDir() + File.separator + nodeTransaction.getNetworkId();
    }

    private String zipFileName() {
        return folderToZip.getAbsoluteFile().getParent() + File.separator + folderToZip.getName() + ".zip";
    }
}

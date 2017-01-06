package com.windsor.node.service;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Transaction;
import com.windsor.node.repo.TransactionRepository;
import com.windsor.node.service.helper.client.NodeClientFactory;

/**
 * Provides an implementation of the Transaction service.
 */
@Service
@Transactional(readOnly = true)
public class TransactionServiceImpl implements TransactionService {

    @Autowired
    private TransactionRepository repository;

    @Autowired
    private NodeClientFactory nodeClientFactory;

    @Transactional(readOnly = false)
    @Override
    public Transaction save(Transaction transaction) {
        return repository.save(transaction);
    }

    @Transactional(readOnly = false)
    @Override
    public Transaction updateStatus(Transaction transaction) throws MalformedURLException {
        NodeClientService ncl = newNodeClientService(transaction);
        TransactionStatus status = ncl.getStatus(transaction.getRemoteTransactionId());
        CommonTransactionStatusCode code = status.getStatus();
        transaction.setStatus(com.windsor.node.domain.entity.TransactionStatus.valueOf(code.name()));
        transaction.setRemoteStatus(code.name());
        return repository.save(transaction);
    }

    @Transactional(readOnly = false)
    @Override
    public File downloadFiles(Transaction transaction) throws IOException {
        NodeClientService ncl = newNodeClientService(transaction);
        NodeTransaction nodeTransaction = newNodeTransaction(transaction);
        NodeTransaction downloadTrans = ncl.download(nodeTransaction);
        File zipFile = null;
        if(downloadTrans.getDocuments() != null)
        {
            zipFile = File.createTempFile("transdownload", ".zip");
            if(zipFile.exists())
            {
                zipFile.delete();
            }
            ZipOutputStream zipOut = new ZipOutputStream(new FileOutputStream(zipFile));

            for(int i = 0; i < downloadTrans.getDocuments().size(); i++)
            {
                Document currentDoc = downloadTrans.getDocuments().get(i);
                writeFileToZip(zipOut, currentDoc.getContent(), currentDoc.getDocumentName());
            }
            zipOut.flush();
            zipOut.close();
        }
        return zipFile;
    }

    private NodeClientService newNodeClientService(Transaction transaction) throws MalformedURLException {
        PartnerIdentity oldPartner = new PartnerIdentity();
        oldPartner.setUrl(new URL(transaction.getRemoteUrl()));
        oldPartner.setVersion(EndpointVersionType.fromString(transaction.getRemoteVersion()));
        return nodeClientFactory.makeAndConfigure(oldPartner);
    }

    private void writeFileToZip(ZipOutputStream zipOut, byte[] bytes, String fileName) throws IOException {
        ZipEntry entry = new ZipEntry(fileName);
        zipOut.putNextEntry(entry);
        zipOut.write(bytes, 0, bytes.length);
        zipOut.closeEntry();
    }

    private NodeTransaction newNodeTransaction(Transaction transaction) throws MalformedURLException {
        NodeTransaction nodeTransaction = new NodeTransaction();
        nodeTransaction.setId(transaction.getId());
        nodeTransaction.setNetworkId(transaction.getRemoteTransactionId());
        nodeTransaction.setNetworkEndpointVersion(EndpointVersionType.fromString(transaction.getRemoteVersion()));
        nodeTransaction.setNetworkEndpointUrl(new URL(transaction.getRemoteUrl()));
        nodeTransaction.setDocuments(new ArrayList<>());
        DataFlow flow = new DataFlow();
        Exchange exchange = transaction.getExchange();
        flow.setTargetDataFlowName(exchange.getTargetExchangeName());
        nodeTransaction.setFlow(flow);
        return nodeTransaction;
    }

}

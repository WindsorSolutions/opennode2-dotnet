package com.windsor.node.plugin.wqx.document;

import java.io.File;
import java.io.IOException;

import com.windsor.node.common.domain.Document;

public interface ExchangeNetworkDocumentFactory {

    void add(File file) throws IOException;

    Document make(String documentId) throws IOException;

}

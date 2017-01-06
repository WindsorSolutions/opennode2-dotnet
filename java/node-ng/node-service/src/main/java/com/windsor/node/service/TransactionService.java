package com.windsor.node.service;

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;

import com.windsor.node.domain.entity.Transaction;

/**
 * Provides a service for managing Transaction instances.
 */
public interface TransactionService {

    Transaction save(Transaction transaction);

    Transaction updateStatus(Transaction transaction) throws MalformedURLException;

    File downloadFiles(Transaction transaction) throws IOException;

}

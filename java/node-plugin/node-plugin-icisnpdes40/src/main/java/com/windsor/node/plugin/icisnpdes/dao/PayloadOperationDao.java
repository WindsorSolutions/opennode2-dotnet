package com.windsor.node.plugin.icisnpdes.dao;

import java.util.List;

import com.windsor.node.plugin.icisnpdes.domain.PayloadOperation;

/**
 * Data access object for retrieving {@link PayloadOperation} instances from the
 * staging local database.
 * 
 */
public interface PayloadOperationDao {

    /**
     * Returns a list of enabled payload operations to submit to ICIS.
     * 
     * @return a list of enabled payload operations to submit to ICIS.
     */
    List<PayloadOperation> findPayloadsToSubmit();
}

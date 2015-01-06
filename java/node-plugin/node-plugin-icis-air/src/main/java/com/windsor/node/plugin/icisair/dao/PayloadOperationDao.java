package com.windsor.node.plugin.icisair.dao;

import java.util.List;

import com.windsor.node.plugin.icisair.domain.PayloadOperation;

/**
 * Data access object for retrieving {@link PayloadOperation} instances from the
 * staging local database.
 * 
 */
public interface PayloadOperationDao {

    /**
     * Returns a list of enabled payload operations to submit to ICIS Air.
     * 
     * @return a list of enabled payload operations to submit to ICIS Air.
     */
    List<PayloadOperation> findPayloadsToSubmit();
}

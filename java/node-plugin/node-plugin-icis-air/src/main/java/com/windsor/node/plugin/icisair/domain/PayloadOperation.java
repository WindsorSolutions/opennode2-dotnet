package com.windsor.node.plugin.icisair.domain;

import java.io.Serializable;

import com.windsor.node.plugin.icisair.dao.PayloadOperationDao;
import com.windsor.node.plugin.icisair.dao.jdbc.PayloadOperationDaoJdbc;
import com.windsor.node.plugin.icisair.domain.generated.OperationType;

/**
 * Represents ICA_PAYLOAD record.
 * 
 * @see PayloadOperationDao
 * @see PayloadOperationDaoJdbc
 */
public class PayloadOperation implements Serializable {

    private static final long serialVersionUID = 3189897144657084019L;

    /**
     * The DB id.
     */
    private String payloadId;
    
    /**
     * The type of ICIS payload operation
     */
    private OperationType operationType;
    
    /**
     * Is the operation enabled?
     */
    private boolean enabled;

    /**
     * Convenience constructor.
     * 
     * @param payloadId
     *            the db id.
     * @param operation
     *            the name of ICIS payload operation.
     * @param enabled
     *            is the operation enabled?
     */
    public PayloadOperation(String payloadId, String operation, boolean enabled) {
        setPayloadId(payloadId);
        setOperationType(OperationType.fromValue(operation));
        setEnabled(enabled);
    }
    
    private void setPayloadId(String payloadId) {
        this.payloadId = payloadId;
    }

    private void setOperationType(OperationType operationType) {
        this.operationType = operationType;
    }

    private void setEnabled(boolean enabled) {
        this.enabled = enabled;
    }

    public String getPayloadId() {
        return payloadId;
    }

    public OperationType getOperationType() {
        return operationType;
    }

    public boolean isEnabled() {
        return enabled;
    }
}

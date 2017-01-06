package com.windsor.node.domain.search;

import java.io.Serializable;

import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

public class DocumentSearchCriteria implements Serializable {

    public static final String TRANSACTION_ID = "transactionId";

    @Criteria(name = TRANSACTION_ID, operator = CriteriaOperator.EQUAL)
    private String transactionId;

    public DocumentSearchCriteria() {
        super();
        reset();
    }

    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public DocumentSearchCriteria transactionId(String transactionId) {
        setTransactionId(transactionId);
        return this;
    }

    public void reset() {
        setTransactionId(null);
    }

}

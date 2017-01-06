package com.windsor.node.domain.search;

import java.io.Serializable;

import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

/**
 * Provides a data object encapsulating Account related search criteria.
 */
public class AccountPolicySearchCriteria implements Serializable {

    public static final String ACCOUNT_ID = "accountId";
    public static final String EXCHANGE_ID = "exchangeId";

    @Criteria(name = ACCOUNT_ID, operator = CriteriaOperator.EQUAL)
    private String accountId;

    @Criteria(name = EXCHANGE_ID, operator = CriteriaOperator.EQUAL)
    private String exchangeId;

    public AccountPolicySearchCriteria() {
        super();
        reset();
    }

    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public String getExchangeId() {
        return exchangeId;
    }

    public void setExchangeId(String exchangeId) {
        this.exchangeId = exchangeId;
    }

    public void reset() {
        this.accountId = null;
        this.exchangeId = null;
    }

}

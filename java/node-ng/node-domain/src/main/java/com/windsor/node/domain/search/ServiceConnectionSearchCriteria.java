package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides search criteria for ServiceConnection instances.
 */
public class ServiceConnectionSearchCriteria implements Serializable {

    public static final String SERVICE = "service";
    public static final String KEY = "key";

    @Criteria(name = SERVICE, operator = CriteriaOperator.EQUAL)
    private ExchangeService service;

    @Criteria(name = SERVICE, operator = CriteriaOperator.CONTAINS_CI)
    private String key;

    public ServiceConnectionSearchCriteria() {
        super();
        reset();
    }

    public ExchangeService getService() {
        return service;
    }

    public void setService(ExchangeService service) {
        this.service = service;
    }

    public ServiceConnectionSearchCriteria service(ExchangeService service) {
        setService(service);
        return this;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public void reset() {
        setService(null);
        setKey(null);
    }
}

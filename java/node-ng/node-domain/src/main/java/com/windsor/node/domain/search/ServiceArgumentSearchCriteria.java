package com.windsor.node.domain.search;

import java.io.Serializable;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

/**
 * Provides search criteria for ServiceArgument instances.
 */
public class ServiceArgumentSearchCriteria implements Serializable {

    public static final String ID = "id";
    public static final String EXCHANGE_SERVICE = "service";
    public static final String KEY = "key";
    public static final String VALUE = "value";

    @Criteria(name = ID, operator = CriteriaOperator.CONTAINS_CI)
    private String id;

    @Criteria(name = EXCHANGE_SERVICE, operator = CriteriaOperator.EQUAL)
    private ExchangeService service;

    @Criteria(name = KEY, operator = CriteriaOperator.CONTAINS_CI)
    private String key;

    @Criteria(name = VALUE, operator = CriteriaOperator.CONTAINS_CI)
    private String value;

    public ServiceArgumentSearchCriteria() {
        super();
        reset();
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public ExchangeService getService() {
        return service;
    }

    public void setService(ExchangeService service) {
        this.service = service;
    }

    public ServiceArgumentSearchCriteria service(ExchangeService service) {
        setService(service);
        return this;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public void reset() {
        setId(null);
        setService(null);
        setKey(null);
        setValue(null);
    }
}

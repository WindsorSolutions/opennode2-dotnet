package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ServiceAuthorizationLevel;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides a data object encapsulating ExchangeService related search criteria.
 */
public class ExchangeServiceSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String EXCHANGE_ID = "exchangeId";
    public static final String ACTIVE = "active";
    public static final String TYPE = "type";
    public static final String IMPLEMENTOR = "implementor";
    public static final String AUTHORIZATION = "authorization";
    public static final String SECURE = "secure";

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = EXCHANGE_ID, operator = CriteriaOperator.EQUAL)
    private String exchangeId;

    @Criteria(name = ACTIVE, operator = CriteriaOperator.EQUAL)
    private Boolean active;

    @Criteria(name = TYPE)
    private ServiceType type;

    @Criteria(name = IMPLEMENTOR, operator = CriteriaOperator.CONTAINS_CI)
    private String implementor;

    @Criteria(name = AUTHORIZATION)
    private ServiceAuthorizationLevel authorization;

    @Criteria(name = SECURE, operator = CriteriaOperator.EQUAL)
    private Boolean secure;

    public ExchangeServiceSearchCriteria() {
        super();
        reset();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ExchangeServiceSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public String getExchangeId() {
        return exchangeId;
    }

    public void setExchangeId(String exchangeId) {
        this.exchangeId = exchangeId;
    }

    public ExchangeServiceSearchCriteria exchange(Exchange exchange) {
        setExchangeId(exchange.getId());
        return this;
    }

    public Boolean getActive() {
        return active;
    }

    public void setActive(Boolean active) {
        this.active = active;
    }

    public ServiceType getType() {
        return type;
    }

    public void setType(ServiceType type) {
        this.type = type;
    }

    public String getImplementor() {
        return implementor;
    }

    public void setImplementor(String implementor) {
        this.implementor = implementor;
    }

    public ServiceAuthorizationLevel getAuthorization() {
        return authorization;
    }

    public void setAuthorization(ServiceAuthorizationLevel authorization) {
        this.authorization = authorization;
    }

    public Boolean getSecure() {
        return secure;
    }

    public void setSecure(Boolean secure) {
        this.secure = secure;
    }

    public void reset() {
        setName(null);
        setExchangeId(null);
        setActive(null);
        setType(null);
        setImplementor(null);
        setAuthorization(null);
        setSecure(null);
    }
}

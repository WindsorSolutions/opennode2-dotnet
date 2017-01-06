package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provieds a data object encapsulating ScheduleService related search criteris.
 */
public class ScheduleSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String EXCHANGE = "exchange";

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = EXCHANGE, operator = CriteriaOperator.EQUAL)
    private Exchange exchange;

    public ScheduleSearchCriteria() {
        super();
        reset();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public ScheduleSearchCriteria exchange(Exchange exchange) {
        setExchange(exchange);
        return this;
    }

    public void reset() {
        setName(null);
        setExchange(null);
    }
}

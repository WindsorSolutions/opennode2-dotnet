package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

/**
 * Provides a data object encapsulating Plugin search criteria.
 */
public class PluginSearchCriteria {

    public static final String EXCHANGE = "exchange";
    public static final String VERSION = "version";

    @Criteria(name = EXCHANGE)
    private Exchange exchange;

    @Criteria(name = VERSION, operator = CriteriaOperator.CONTAINS_CI)
    private String version;

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public String getVersion() {
        return version;
    }

    public void setVersion(String version) {
        this.version = version;
    }

    public void reset() {
        setExchange(null);
        setVersion(null);
    }
}

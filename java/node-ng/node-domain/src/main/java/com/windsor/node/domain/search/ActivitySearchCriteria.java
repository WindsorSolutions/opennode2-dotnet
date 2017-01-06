package com.windsor.node.domain.search;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Collection;

import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;
import com.windsor.stack.domain.search.LocalDateTimeRange;

public class ActivitySearchCriteria implements Serializable {

    public static final String ID = "id";
    public static final String TYPE = "type";
    public static final String ACCOUNT_EMAIL = "email";
    public static final String IP_ADDRESS = "address";
    public static final String CREATE_DATE = "createDate";
    public static final String EXCHANGE = "exchange";
    public static final String DETAILS = "details";
    public static final String OPERATION = "operation";
    public static final String HAS_EXCHANGE = "hasExchange";

    @Criteria(name = ID, operator = CriteriaOperator.CONTAINS_CI)
    private String id;

    @Criteria(name = TYPE, operator = CriteriaOperator.IN)
    private Collection<ActivityType> types;

    @Criteria(name = ACCOUNT_EMAIL, operator = CriteriaOperator.CONTAINS_CI)
    private String accountEmail;

    @Criteria(name = IP_ADDRESS, operator = CriteriaOperator.CONTAINS_CI)
    private String ipAddress;

    @Criteria(name = CREATE_DATE, operator = CriteriaOperator.BETWEEN)
    private LocalDateTimeRange createDateRange;

    @Criteria(name = EXCHANGE, operator = CriteriaOperator.EQUAL)
    private Exchange exchange;

    @Criteria(name = DETAILS, operator = CriteriaOperator.CONTAINS_CI)
    private String details;

    @Criteria(name = OPERATION, operator = CriteriaOperator.CONTAINS_CI)
    private String operation;
    
    @Criteria(name = HAS_EXCHANGE, operator = CriteriaOperator.NOT_NULL)
    private Boolean hasExchange;

    public ActivitySearchCriteria() {
        super();
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Collection<ActivityType> getTypes() {
        return types;
    }

    public void setTypes(Collection<ActivityType> types) {
        this.types = types;
    }

    public ActivitySearchCriteria types(Collection<ActivityType> types) {
        setTypes(types);
        return this;
    }

    public ActivityType getType() {
        return types == null || types.isEmpty() ? null : types.iterator().next();
    }

    public void setType(ActivityType type) {
        this.types = type == null ? null : Arrays.asList(type);
    }

    public String getAccountEmail() {
        return accountEmail;
    }

    public void setAccountEmail(String accountEmail) {
        this.accountEmail = accountEmail;
    }

    public String getIpAddress() {
        return ipAddress;
    }

    public void setIpAddress(String ipAddress) {
        this.ipAddress = ipAddress;
    }

    public LocalDateTimeRange getCreateDateRange() {
        return createDateRange;
    }

    public void setCreateDateRange(LocalDateTimeRange createDateRange) {
        this.createDateRange = createDateRange;
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public String getDetails() {
        return details;
    }

    public void setDetails(String details) {
        this.details = details;
    }

    public String getOperation() {
        return operation;
    }

    public void setOperation(String operation) {
        this.operation = operation;
    }

    public Boolean getHasExchange() {
		return hasExchange;
	}

	public void setHasExchange(Boolean hasExchange) {
		this.hasExchange = hasExchange;
	}
	
	public ActivitySearchCriteria hasExchange() {
		setHasExchange(true);
		return this;
	}

	public void reset() {
        setId(null);
        setTypes(null);
        setAccountEmail(null);
        setIpAddress(null);
        setCreateDateRange(new LocalDateTimeRange());
        setExchange(null);
        setDetails(null);
        setOperation(null);
        setHasExchange(null);
    }

}

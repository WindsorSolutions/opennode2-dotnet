package com.windsor.node.domain.search;

import java.io.Serializable;
import java.util.Collection;

import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

/**
 * Provides a data object encapsulating Exchange related search criteria.
 */
public class ExchangeSearchCriteria implements Serializable {

    public static final String NOT_IDS = "notIds";
    public static final String URL = "url";
    public static final String SECURE = "secure";
    public static final String NAME = "name";
    public static final String TARGET_EXCHANGE_NAME = "targetExchangeName";
    public static final String DESCRIPTION = "description";
    public static final String CONTACT = "contact";
    public static final String NOT_SECURE_OR_IDS = "notSecureOrIds";

    @Criteria(name = URL, operator = CriteriaOperator.CONTAINS_CI)
    private String url;

    @Criteria(name = SECURE, operator = CriteriaOperator.EQUAL)
    private Boolean secure;

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = TARGET_EXCHANGE_NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String targetExchangeName;

    @Criteria(name = DESCRIPTION, operator = CriteriaOperator.CONTAINS_CI)
    private String description;

    @Criteria(name = CONTACT, operator = CriteriaOperator.CONTAINS_CI)
    private String contact;

    @Criteria(name = NOT_IDS, operator = CriteriaOperator.NOT_IN)
    private Collection<String> notIds;

    @Criteria(name = NOT_SECURE_OR_IDS, operator = CriteriaOperator.IN)
    private Collection<String> notSecureOrIds;

    public ExchangeSearchCriteria() {
        super();
        reset();
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public Boolean getSecure() {
        return secure;
    }

    public void setSecure(Boolean secure) {
        this.secure = secure;
    }

    public ExchangeSearchCriteria secure(boolean secure) {
        setSecure(secure);
        return this;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ExchangeSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public String getTargetExchangeName() {
        return targetExchangeName;
    }

    public void setTargetExchangeName(String targetExchangeName) {
        this.targetExchangeName = targetExchangeName;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getContact() {
        return contact;
    }

    public void setContact(String contact) {
        this.contact = contact;
    }

    public Collection<String> getNotIds() {
        return notIds;
    }

    public void setNotIds(Collection<String> notIds) {
        this.notIds = notIds;
    }

    public ExchangeSearchCriteria notIds(Collection<String> notIds) {
        setNotIds(notIds);
        return this;
    }

    public Collection<String> getNotSecureOrIds() {
        return notSecureOrIds;
    }

    public void setNotSecureOrIds(Collection<String> notSecureOrIds) {
        this.notSecureOrIds = notSecureOrIds;
    }

    public void reset() {
        this.url = null;
        this.secure = null;
        this.name = null;
        this.targetExchangeName = null;
        this.description = null;
        this.contact = null;
        this.notSecureOrIds = null;
    }

}

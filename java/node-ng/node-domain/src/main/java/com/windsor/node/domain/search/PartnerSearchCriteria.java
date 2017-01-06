package com.windsor.node.domain.search;

import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides a data object encapsulating Partner search criteria.
 */
public class PartnerSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String URL = "url";
    public static final String VERSION = "version";

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = URL, operator = CriteriaOperator.CONTAINS_CI)
    private String url;

    @Criteria(name = VERSION)
    private PartnerVersion version;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public PartnerSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public PartnerVersion getVersion() {
        return version;
    }

    public void setVersion(PartnerVersion version) {
        this.version = version;
    }

    public void reset() {
        setName(null);
        setUrl(null);
        setVersion(null);
    }
}

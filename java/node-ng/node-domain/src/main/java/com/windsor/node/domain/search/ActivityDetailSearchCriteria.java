package com.windsor.node.domain.search;

import java.io.Serializable;

import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

/**
 * Provides a data object encapsulating Activity Detail related search criteria.
 */
public class ActivityDetailSearchCriteria implements Serializable {

    public static final String ACTIVITY_ID = "accountId";

    @Criteria(name = ACTIVITY_ID, operator = CriteriaOperator.EQUAL)
    private String activityId;

    public ActivityDetailSearchCriteria() {
        super();
        reset();
    }

    public String getActivityId() {
        return activityId;
    }

    public void setActivityId(String activityId) {
        this.activityId = activityId;
    }

    public ActivityDetailSearchCriteria activityId(String activityId) {
        setActivityId(activityId);
        return this;
    }

    public void reset() {
        setActivityId(null);
    }

}

package com.windsor.node.domain;

import com.windsor.stack.domain.search.BooleanCriteriaField;

public class TrueCriteria extends BooleanCriteriaField {

    @Override
    public boolean isEmpty() {
        return getValue() == null || (!getValue());
    }

}

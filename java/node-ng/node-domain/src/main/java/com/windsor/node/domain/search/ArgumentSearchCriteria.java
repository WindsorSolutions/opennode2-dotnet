package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.BooleanCriteriaField;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;

import java.io.Serializable;

/**
 * Provides a data object encapsulating Argument related search criteria.
 */
public class ArgumentSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String VALUE = "value";
    public static final String DESCRIPTION = "description";
    public static final String EDITABLE = "editable";

    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = VALUE, operator = CriteriaOperator.CONTAINS_CI)
    private String value;

    @Criteria(name = DESCRIPTION, operator = CriteriaOperator.CONTAINS_CI)
    private String description;

    @Criteria(name = EDITABLE)
    private BooleanCriteriaField editable = new BooleanCriteriaField();

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ArgumentSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public BooleanCriteriaField getEditable() {
        return editable;
    }

    public void setEditable(BooleanCriteriaField editable) {
        this.editable = editable;
    }

    public void reset() {
        setName(null);
        setValue(null);
        setDescription(null);
        setEditable(null);
    }
}

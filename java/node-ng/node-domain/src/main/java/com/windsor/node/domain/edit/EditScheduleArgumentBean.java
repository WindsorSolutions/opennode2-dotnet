package com.windsor.node.domain.edit;

import java.io.Serializable;

import org.apache.commons.lang3.StringUtils;

public class EditScheduleArgumentBean implements Serializable {

    private String key;
    private String value;
    private boolean required;

    public EditScheduleArgumentBean(String key, String value, boolean required) {
        super();
        this.key = key;
        this.value = value;
        this.required = required;
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

    public boolean isRequired() {
        return required;
    }

    public void setRequired(boolean required) {
        this.required = required;
    }

    public EditScheduleArgumentBean required(boolean required) {
        setRequired(required);
        return this;
    }

    public boolean hasValue() {
        return StringUtils.isNotBlank(value);
    }

}

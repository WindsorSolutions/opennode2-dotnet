package com.windsor.node.domain.edit;

import com.windsor.node.domain.entity.Argument;
import org.apache.commons.lang3.StringUtils;

import java.io.Serializable;

public class EditServiceArgumentBean implements Serializable {

    private String key;
    private boolean useGlobalArgument;
    private String value;
    private Argument argument;

    public EditServiceArgumentBean(String key, String value) {
        this(key, value, false, null);
    }

    public EditServiceArgumentBean(String key, String value, boolean useGlobalArgument, Argument argument) {
        this.key = key;
        this.value = value;
        this.useGlobalArgument = useGlobalArgument;
        this.argument = argument;
    }

    public EditServiceArgumentBean() {
        super();
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public boolean isUseGlobalArgument() {
        return useGlobalArgument;
    }

    public void setUseGlobalArgument(boolean useGlobalArgument) {
        this.useGlobalArgument = useGlobalArgument;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public Argument getArgument() {
        return argument;
    }

    public void setArgument(Argument argument) {
        this.argument = argument;
    }

    public boolean hasValue() {
        return StringUtils.isNotBlank(value) || argument != null;
    }

}

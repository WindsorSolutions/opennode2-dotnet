package com.windsor.node.domain;

import java.io.Serializable;

public class DataSourceTestResult implements Serializable {

    private boolean success;

    private String message;

    public DataSourceTestResult(boolean success, String message) {
        this.success = success;
        this.message = message;
    }

    public boolean isSuccess() {
        return success;
    }

    public String getMessage() {
        return message;
    }

}

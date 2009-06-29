package com.windsor.node.common.domain;

public enum RequestParameterEncodingType {

    BASE64("Base64"), ZIP("ZIP"), ENCRYPT("Encrypt"), DIGEST("Digest"), XML(
            "XML"), NONE("None");

    private String description;

    private RequestParameterEncodingType(String type) {
        this.description = type;
    }

    @Override
    public String toString() {
        return this.description;
    }
}

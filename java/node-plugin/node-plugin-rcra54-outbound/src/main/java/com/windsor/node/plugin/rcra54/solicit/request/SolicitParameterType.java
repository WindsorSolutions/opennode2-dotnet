package com.windsor.node.plugin.rcra54.solicit.request;

/**
 * Provides an enumeration of valid RCRAInfo solicit parameter types.
 */
public enum SolicitParameterType {
    HANDLER_ID("handlerId"),
    STATE("state"),
    STATE_ID("stateId"),
    AGENCY("agency"),
    OWNER("owner"),
    SEQUENCE_NUMBER("sequenceNumber"),
    SOURCE_TYPE("sourceType"),
    CHANGE_DATE("changeDate"),
    FROM_DATE("fromDate"),
    TO_DATE("toDate");

    private String type;

    SolicitParameterType(String type) {
        this.type = type;
    }

    @Override
    public String toString() {
        return type;
    }
}

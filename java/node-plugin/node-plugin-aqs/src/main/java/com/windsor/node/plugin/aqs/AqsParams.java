package com.windsor.node.plugin.aqs;

/**
 * An enumeration of valid AQS parameters.
 */
public enum AqsParams {
    StartTime,
    EndTime,
    SendRdTransactions,
    SendRbTransactions,
    SendMonitorAssuranceTransactions,
    AgencyCode,
    SiteCode,
    ParameterCode;

    private AqsParams() {
    }
}
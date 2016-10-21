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
    SendOnlyQAData,
    AgencyCode,
    SiteCode,
    ParameterCode,
    DurationCode,
    OccurrenceCode,
    StateCode,
    CountyTribalCode;

    private AqsParams() {
    }
}
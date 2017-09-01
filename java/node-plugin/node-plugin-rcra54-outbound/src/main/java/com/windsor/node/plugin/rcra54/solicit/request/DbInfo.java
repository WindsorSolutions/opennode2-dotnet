package com.windsor.node.plugin.rcra54.solicit.request;

public enum DbInfo {

    CA("CA", "from HazardousWasteCorrectiveActionDataType where id > 0"),
    CE("CE", "from HazardousWasteCMESubmissionDataType where id > 0"),
    FA("FA", "from FinancialAssuranceFacilitySubmissionDataType where id > 0"),
    GS("GS", "from GeographicInformationSubmissionDataType where id > 0"),
    HD("HD", "from HazardousWasteHandlerSubmissionDataType where id > 0"),
    PM("PM", "from HazardousWastePermitDataType where id > 0");

    private String type;
    private String cleanup;

    DbInfo(String type, String cleanup) {
        this.type = type;
        this.cleanup = cleanup;
    }

    public String getType() {
        return type;
    }

    public String getCleanup() {
        return cleanup;
    }

}

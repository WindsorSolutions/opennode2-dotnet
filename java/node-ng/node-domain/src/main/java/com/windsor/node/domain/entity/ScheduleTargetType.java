package com.windsor.node.domain.entity;

/**
 * Provides an enumeration of valis ScheduleTargetType values.
 */
public enum ScheduleTargetType {

    NONE("None", "None",
            "There is no datatarget data source for the results"),
    PARTNER("Partner", "Exchange Network Partner",
            "Submit the results to an Exchange Network partner"),
    SCHEMATRON("Schematron", "Schematron Service",
            "Submit the results to the Schematron service for validation"),
    FILE("File", "File System",
            "Save the uncompressed results to a network path location"),
    EMAIL("Email", "E-mail",
            "Send the compressed results to someone as an e-mail attachment");

    private String code;
    private String title;
    private String helpText;

    ScheduleTargetType(String code, String title, String helpText) {
        this.code = code;
        this.title = title;
        this.helpText = helpText;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getHelpText() {
        return helpText;
    }

    public void setHelpText(String helpText) {
        this.helpText = helpText;
    }

    public static ScheduleTargetType fromString(String code) {

        ScheduleTargetType scheduleTargetType = null;

        for(ScheduleTargetType typeThis : ScheduleTargetType.values()){
            if(typeThis.getCode().equals(code)) {
                scheduleTargetType = typeThis;
                break;
            }
        }

        return scheduleTargetType;
    }
}

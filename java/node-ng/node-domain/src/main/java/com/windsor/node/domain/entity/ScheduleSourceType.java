package com.windsor.node.domain.entity;

import java.util.Arrays;
import java.util.List;

public enum ScheduleSourceType {

    NONE("None", "None", "There will be no data source"),
    WEB_SERVICE_SOLICIT("WebServiceSolicit", "Partner Solicit",
            "The data source is the result from a parner service solicit (Transaction ID"),
    WEB_SERVICE_QUERY("WebServiceQuery", "Partner Query",
            "The data source is the result of a partner service query (XML)"),
    LOCAL_SERVICE("LocalService", "Local Service",
            "The data source is the result of a local service"),
    FILE("File", "File System",
            "The data source is a file system resouce (network path)");

    private String code;
    private String title;
    private String helpText;

    ScheduleSourceType(String code, String title, String helpText) {
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

    public static List<ScheduleSourceType> validOptions() {
        return Arrays.asList(LOCAL_SERVICE, FILE);
    }

    public static ScheduleSourceType fromString(String code) {

        ScheduleSourceType scheduleSourceType = null;

        for(ScheduleSourceType typeThis : ScheduleSourceType.values()){
            if(typeThis.getCode().equals(code)) {
                scheduleSourceType = typeThis;
                break;
            }
        }

        return scheduleSourceType;
    }
}

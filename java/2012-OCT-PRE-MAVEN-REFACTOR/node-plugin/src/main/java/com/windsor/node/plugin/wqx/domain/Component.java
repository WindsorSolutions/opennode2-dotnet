package com.windsor.node.plugin.wqx.domain;

public enum Component {

    Project("ProjectIdentifier"),
    MonitoringLocation("MonitoringLocationIdentifier"),
    Activity("ActivityIdentifier"),
    ActivityGroup("ActivityGroupIdentifier"),
    BiologicalHabitatIndex("IndexIdentifier");

    private final String xmlElementName;

    Component(String xmlElementName) {
        this.xmlElementName = xmlElementName;
    }

    public String xmlElementName() {
        return this.xmlElementName;
    };

    public String componentName() {
        return this.name();
    }
}

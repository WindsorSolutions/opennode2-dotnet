//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ComplianceMonitoringActivityTypeCodeType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ComplianceMonitoringActivityTypeCodeType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="INF"/>
 *     &lt;enumeration value="INS"/>
 *     &lt;enumeration value="INV"/>
 *     &lt;enumeration value="OSR"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ComplianceMonitoringActivityTypeCodeType")
@XmlEnum
public enum ComplianceMonitoringActivityTypeCodeType {

    INF,
    INS,
    INV,
    OSR;

    public String value() {
        return name();
    }

    public static ComplianceMonitoringActivityTypeCodeType fromValue(String v) {
        return valueOf(v);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for MonthTextType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="MonthTextType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="ALL"/>
 *     &lt;enumeration value="JAN"/>
 *     &lt;enumeration value="FEB"/>
 *     &lt;enumeration value="MAR"/>
 *     &lt;enumeration value="APR"/>
 *     &lt;enumeration value="MAY"/>
 *     &lt;enumeration value="JUN"/>
 *     &lt;enumeration value="JUL"/>
 *     &lt;enumeration value="AUG"/>
 *     &lt;enumeration value="SEP"/>
 *     &lt;enumeration value="OCT"/>
 *     &lt;enumeration value="NOV"/>
 *     &lt;enumeration value="DEC"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "MonthTextType")
@XmlEnum
public enum MonthTextType {

    ALL,
    JAN,
    FEB,
    MAR,
    APR,
    MAY,
    JUN,
    JUL,
    AUG,
    SEP,
    OCT,
    NOV,
    DEC;

    public String value() {
        return name();
    }

    public static MonthTextType fromValue(String v) {
        return valueOf(v);
    }

}

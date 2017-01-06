
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for NotificationTypeCode.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="NotificationTypeCode">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Warning"/>
 *     &lt;enumeration value="Error"/>
 *     &lt;enumeration value="Status"/>
 *     &lt;enumeration value="All"/>
 *     &lt;enumeration value="None"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "NotificationTypeCode")
@XmlEnum
public enum NotificationTypeCode {

    @XmlEnumValue("Warning")
    WARNING("Warning"),
    @XmlEnumValue("Error")
    ERROR("Error"),
    @XmlEnumValue("Status")
    STATUS("Status"),
    @XmlEnumValue("All")
    ALL("All"),
    @XmlEnumValue("None")
    NONE("None");
    private final String value;

    NotificationTypeCode(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static NotificationTypeCode fromValue(String v) {
        for (NotificationTypeCode c: NotificationTypeCode.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}

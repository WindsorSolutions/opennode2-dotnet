
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for NotificationMessageCategoryType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="NotificationMessageCategoryType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Event"/>
 *     &lt;enumeration value="Status"/>
 *     &lt;enumeration value="Document"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "NotificationMessageCategoryType")
@XmlEnum
public enum NotificationMessageCategoryType {

    @XmlEnumValue("Event")
    EVENT("Event"),
    @XmlEnumValue("Status")
    STATUS("Status"),
    @XmlEnumValue("Document")
    DOCUMENT("Document");
    private final String value;

    NotificationMessageCategoryType(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static NotificationMessageCategoryType fromValue(String v) {
        for (NotificationMessageCategoryType c: NotificationMessageCategoryType.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}

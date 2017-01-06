
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for NodeStatusCode.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="NodeStatusCode">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Ready"/>
 *     &lt;enumeration value="Offline"/>
 *     &lt;enumeration value="Busy"/>
 *     &lt;enumeration value="Unknown"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "NodeStatusCode")
@XmlEnum
public enum NodeStatusCode {

    @XmlEnumValue("Ready")
    READY("Ready"),
    @XmlEnumValue("Offline")
    OFFLINE("Offline"),
    @XmlEnumValue("Busy")
    BUSY("Busy"),
    @XmlEnumValue("Unknown")
    UNKNOWN("Unknown");
    private final String value;

    NodeStatusCode(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static NodeStatusCode fromValue(String v) {
        for (NodeStatusCode c: NodeStatusCode.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}

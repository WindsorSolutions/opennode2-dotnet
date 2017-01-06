
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for EncodingType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="EncodingType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Base64"/>
 *     &lt;enumeration value="ZIP"/>
 *     &lt;enumeration value="Encrypt"/>
 *     &lt;enumeration value="Digest"/>
 *     &lt;enumeration value="XML"/>
 *     &lt;enumeration value="None"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "EncodingType")
@XmlEnum
public enum EncodingType {

    @XmlEnumValue("Base64")
    BASE_64("Base64"),
    ZIP("ZIP"),
    @XmlEnumValue("Encrypt")
    ENCRYPT("Encrypt"),
    @XmlEnumValue("Digest")
    DIGEST("Digest"),
    XML("XML"),
    @XmlEnumValue("None")
    NONE("None");
    private final String value;

    EncodingType(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static EncodingType fromValue(String v) {
        for (EncodingType c: EncodingType.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}

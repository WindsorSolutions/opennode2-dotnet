
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for DocumentFormatType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="DocumentFormatType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="XML"/>
 *     &lt;enumeration value="FLAT"/>
 *     &lt;enumeration value="BIN"/>
 *     &lt;enumeration value="ZIP"/>
 *     &lt;enumeration value="ODF"/>
 *     &lt;enumeration value="OTHER"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "DocumentFormatType")
@XmlEnum
public enum DocumentFormatType {

    XML,
    FLAT,
    BIN,
    ZIP,
    ODF,
    OTHER;

    public String value() {
        return name();
    }

    public static DocumentFormatType fromValue(String v) {
        return valueOf(v);
    }

}

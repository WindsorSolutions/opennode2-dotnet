
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for TransactionStatusCode.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="TransactionStatusCode">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Received"/>
 *     &lt;enumeration value="Processing"/>
 *     &lt;enumeration value="Pending"/>
 *     &lt;enumeration value="Failed"/>
 *     &lt;enumeration value="Cancelled"/>
 *     &lt;enumeration value="Approved"/>
 *     &lt;enumeration value="Processed"/>
 *     &lt;enumeration value="Completed"/>
 *     &lt;enumeration value="Unknown"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "TransactionStatusCode")
@XmlEnum
public enum TransactionStatusCode {

    @XmlEnumValue("Received")
    RECEIVED("Received"),
    @XmlEnumValue("Processing")
    PROCESSING("Processing"),
    @XmlEnumValue("Pending")
    PENDING("Pending"),
    @XmlEnumValue("Failed")
    FAILED("Failed"),
    @XmlEnumValue("Cancelled")
    CANCELLED("Cancelled"),
    @XmlEnumValue("Approved")
    APPROVED("Approved"),
    @XmlEnumValue("Processed")
    PROCESSED("Processed"),
    @XmlEnumValue("Completed")
    COMPLETED("Completed"),
    @XmlEnumValue("Unknown")
    UNKNOWN("Unknown");
    private final String value;

    TransactionStatusCode(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static TransactionStatusCode fromValue(String v) {
        for (TransactionStatusCode c: TransactionStatusCode.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for PermitScheduleData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermitScheduleData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}PermitSchedule"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermitScheduleData", propOrder = {
    "transactionHeader",
    "permitSchedule"
})
public class PermitScheduleData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "PermitSchedule", required = true)
    protected PermitSchedule permitSchedule;

    /**
     * Gets the value of the transactionHeader property.
     * 
     * @return
     *     possible object is
     *     {@link TransactionHeader }
     *     
     */
    public TransactionHeader getTransactionHeader() {
        return transactionHeader;
    }

    /**
     * Sets the value of the transactionHeader property.
     * 
     * @param value
     *     allowed object is
     *     {@link TransactionHeader }
     *     
     */
    public void setTransactionHeader(TransactionHeader value) {
        this.transactionHeader = value;
    }

    public boolean isSetTransactionHeader() {
        return (this.transactionHeader!= null);
    }

    /**
     * Gets the value of the permitSchedule property.
     * 
     * @return
     *     possible object is
     *     {@link PermitSchedule }
     *     
     */
    public PermitSchedule getPermitSchedule() {
        return permitSchedule;
    }

    /**
     * Sets the value of the permitSchedule property.
     * 
     * @param value
     *     allowed object is
     *     {@link PermitSchedule }
     *     
     */
    public void setPermitSchedule(PermitSchedule value) {
        this.permitSchedule = value;
    }

    public boolean isSetPermitSchedule() {
        return (this.permitSchedule!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof PermitScheduleData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PermitScheduleData that = ((PermitScheduleData) object);
        {
            TransactionHeader lhsTransactionHeader;
            lhsTransactionHeader = this.getTransactionHeader();
            TransactionHeader rhsTransactionHeader;
            rhsTransactionHeader = that.getTransactionHeader();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "transactionHeader", lhsTransactionHeader), LocatorUtils.property(thatLocator, "transactionHeader", rhsTransactionHeader), lhsTransactionHeader, rhsTransactionHeader)) {
                return false;
            }
        }
        {
            PermitSchedule lhsPermitSchedule;
            lhsPermitSchedule = this.getPermitSchedule();
            PermitSchedule rhsPermitSchedule;
            rhsPermitSchedule = that.getPermitSchedule();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitSchedule", lhsPermitSchedule), LocatorUtils.property(thatLocator, "permitSchedule", rhsPermitSchedule), lhsPermitSchedule, rhsPermitSchedule)) {
                return false;
            }
        }
        return true;
    }

    public boolean equals(Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    public int hashCode(ObjectLocator locator, HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            TransactionHeader theTransactionHeader;
            theTransactionHeader = this.getTransactionHeader();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "transactionHeader", theTransactionHeader), currentHashCode, theTransactionHeader);
        }
        {
            PermitSchedule thePermitSchedule;
            thePermitSchedule = this.getPermitSchedule();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitSchedule", thePermitSchedule), currentHashCode, thePermitSchedule);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
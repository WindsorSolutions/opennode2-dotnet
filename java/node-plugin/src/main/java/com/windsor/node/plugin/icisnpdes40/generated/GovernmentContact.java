//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

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
 * <p>Java class for GovernmentContact complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="GovernmentContact">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ElectronicAddressText"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}AffiliationTypeText"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "GovernmentContact", propOrder = {
    "electronicAddressText",
    "affiliationTypeText"
})
public class GovernmentContact
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ElectronicAddressText", required = true)
    protected String electronicAddressText;
    @XmlElement(name = "AffiliationTypeText", required = true)
    protected String affiliationTypeText;

    /**
     * Gets the value of the electronicAddressText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getElectronicAddressText() {
        return electronicAddressText;
    }

    /**
     * Sets the value of the electronicAddressText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setElectronicAddressText(String value) {
        this.electronicAddressText = value;
    }

    public boolean isSetElectronicAddressText() {
        return (this.electronicAddressText!= null);
    }

    /**
     * Gets the value of the affiliationTypeText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAffiliationTypeText() {
        return affiliationTypeText;
    }

    /**
     * Sets the value of the affiliationTypeText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAffiliationTypeText(String value) {
        this.affiliationTypeText = value;
    }

    public boolean isSetAffiliationTypeText() {
        return (this.affiliationTypeText!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof GovernmentContact)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final GovernmentContact that = ((GovernmentContact) object);
        {
            String lhsElectronicAddressText;
            lhsElectronicAddressText = this.getElectronicAddressText();
            String rhsElectronicAddressText;
            rhsElectronicAddressText = that.getElectronicAddressText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "electronicAddressText", lhsElectronicAddressText), LocatorUtils.property(thatLocator, "electronicAddressText", rhsElectronicAddressText), lhsElectronicAddressText, rhsElectronicAddressText)) {
                return false;
            }
        }
        {
            String lhsAffiliationTypeText;
            lhsAffiliationTypeText = this.getAffiliationTypeText();
            String rhsAffiliationTypeText;
            rhsAffiliationTypeText = that.getAffiliationTypeText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "affiliationTypeText", lhsAffiliationTypeText), LocatorUtils.property(thatLocator, "affiliationTypeText", rhsAffiliationTypeText), lhsAffiliationTypeText, rhsAffiliationTypeText)) {
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
            String theElectronicAddressText;
            theElectronicAddressText = this.getElectronicAddressText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "electronicAddressText", theElectronicAddressText), currentHashCode, theElectronicAddressText);
        }
        {
            String theAffiliationTypeText;
            theAffiliationTypeText = this.getAffiliationTypeText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "affiliationTypeText", theAffiliationTypeText), currentHashCode, theAffiliationTypeText);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

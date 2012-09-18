//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
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
 * <p>Java class for AcceptedReportDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AcceptedReportDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}InformationCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}InformationTypeCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}InformationDescription"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AcceptedReportDataType", propOrder = {
    "informationCode",
    "informationTypeCode",
    "informationDescription"
})
public class AcceptedReportDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "InformationCode", required = true)
    protected String informationCode;
    @XmlElement(name = "InformationTypeCode", required = true)
    protected InformationTypeCodeDataType informationTypeCode;
    @XmlElement(name = "InformationDescription", required = true)
    protected String informationDescription;

    /**
     * Gets the value of the informationCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getInformationCode() {
        return informationCode;
    }

    /**
     * Sets the value of the informationCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setInformationCode(String value) {
        this.informationCode = value;
    }

    public boolean isSetInformationCode() {
        return (this.informationCode!= null);
    }

    /**
     * Gets the value of the informationTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link InformationTypeCodeDataType }
     *     
     */
    public InformationTypeCodeDataType getInformationTypeCode() {
        return informationTypeCode;
    }

    /**
     * Sets the value of the informationTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link InformationTypeCodeDataType }
     *     
     */
    public void setInformationTypeCode(InformationTypeCodeDataType value) {
        this.informationTypeCode = value;
    }

    public boolean isSetInformationTypeCode() {
        return (this.informationTypeCode!= null);
    }

    /**
     * Gets the value of the informationDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getInformationDescription() {
        return informationDescription;
    }

    /**
     * Sets the value of the informationDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setInformationDescription(String value) {
        this.informationDescription = value;
    }

    public boolean isSetInformationDescription() {
        return (this.informationDescription!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof AcceptedReportDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final AcceptedReportDataType that = ((AcceptedReportDataType) object);
        {
            String lhsInformationCode;
            lhsInformationCode = this.getInformationCode();
            String rhsInformationCode;
            rhsInformationCode = that.getInformationCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "informationCode", lhsInformationCode), LocatorUtils.property(thatLocator, "informationCode", rhsInformationCode), lhsInformationCode, rhsInformationCode)) {
                return false;
            }
        }
        {
            InformationTypeCodeDataType lhsInformationTypeCode;
            lhsInformationTypeCode = this.getInformationTypeCode();
            InformationTypeCodeDataType rhsInformationTypeCode;
            rhsInformationTypeCode = that.getInformationTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "informationTypeCode", lhsInformationTypeCode), LocatorUtils.property(thatLocator, "informationTypeCode", rhsInformationTypeCode), lhsInformationTypeCode, rhsInformationTypeCode)) {
                return false;
            }
        }
        {
            String lhsInformationDescription;
            lhsInformationDescription = this.getInformationDescription();
            String rhsInformationDescription;
            rhsInformationDescription = that.getInformationDescription();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "informationDescription", lhsInformationDescription), LocatorUtils.property(thatLocator, "informationDescription", rhsInformationDescription), lhsInformationDescription, rhsInformationDescription)) {
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
            String theInformationCode;
            theInformationCode = this.getInformationCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "informationCode", theInformationCode), currentHashCode, theInformationCode);
        }
        {
            InformationTypeCodeDataType theInformationTypeCode;
            theInformationTypeCode = this.getInformationTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "informationTypeCode", theInformationTypeCode), currentHashCode, theInformationTypeCode);
        }
        {
            String theInformationDescription;
            theInformationDescription = this.getInformationDescription();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "informationDescription", theInformationDescription), currentHashCode, theInformationDescription);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

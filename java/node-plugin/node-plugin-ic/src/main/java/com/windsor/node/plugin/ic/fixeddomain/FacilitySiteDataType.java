//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2013.08.26 at 02:36:56 PM PDT 
//


package com.windsor.node.plugin.ic.fixeddomain;

import java.io.Serializable;
import javax.persistence.AttributeOverride;
import javax.persistence.AttributeOverrides;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.Embedded;
import javax.persistence.Transient;
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
 * <p>Java class for FacilitySiteDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="FacilitySiteDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}FacilitySiteTypeCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}FacilitySiteTypeCodeListIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}FacilitySiteTypeName" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "FacilitySiteDataType", propOrder = {
    "facilitySiteTypeCode",
    "facilitySiteTypeCodeListIdentifier",
    "facilitySiteTypeName"
})
@Embeddable
public class FacilitySiteDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "FacilitySiteTypeCode")
    protected String facilitySiteTypeCode;
    @XmlElement(name = "FacilitySiteTypeCodeListIdentifier")
    protected FacilitySiteTypeCodeListIdentifierDataType facilitySiteTypeCodeListIdentifier;
    @XmlElement(name = "FacilitySiteTypeName")
    protected String facilitySiteTypeName;

    /**
     * Gets the value of the facilitySiteTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FAC_SITE_TYPE_CODE", length = 255)
    public String getFacilitySiteTypeCode() {
        return facilitySiteTypeCode;
    }

    /**
     * Sets the value of the facilitySiteTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilitySiteTypeCode(String value) {
        this.facilitySiteTypeCode = value;
    }

    @Transient
    public boolean isSetFacilitySiteTypeCode() {
        return (this.facilitySiteTypeCode!= null);
    }

    /**
     * Gets the value of the facilitySiteTypeCodeListIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link FacilitySiteTypeCodeListIdentifierDataType }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "value", column = @Column(name = "VALUE", length = 255)),
        @AttributeOverride(name = "codeListVersionIdentifier", column = @Column(name = "CODE_LST_IDEN", length = 255)),
        @AttributeOverride(name = "codeListVersionAgencyIdentifier", column = @Column(name = "CODE_LST_AGENCY_IDEN", length = 255))
    })
    public FacilitySiteTypeCodeListIdentifierDataType getFacilitySiteTypeCodeListIdentifier() {
        return facilitySiteTypeCodeListIdentifier;
    }

    /**
     * Sets the value of the facilitySiteTypeCodeListIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link FacilitySiteTypeCodeListIdentifierDataType }
     *     
     */
    public void setFacilitySiteTypeCodeListIdentifier(FacilitySiteTypeCodeListIdentifierDataType value) {
        this.facilitySiteTypeCodeListIdentifier = value;
    }

    @Transient
    public boolean isSetFacilitySiteTypeCodeListIdentifier() {
        return (this.facilitySiteTypeCodeListIdentifier!= null);
    }

    /**
     * Gets the value of the facilitySiteTypeName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FAC_SITE_TYPE_NAME", length = 255)
    public String getFacilitySiteTypeName() {
        return facilitySiteTypeName;
    }

    /**
     * Sets the value of the facilitySiteTypeName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilitySiteTypeName(String value) {
        this.facilitySiteTypeName = value;
    }

    @Transient
    public boolean isSetFacilitySiteTypeName() {
        return (this.facilitySiteTypeName!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof FacilitySiteDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final FacilitySiteDataType that = ((FacilitySiteDataType) object);
        {
            String lhsFacilitySiteTypeCode;
            lhsFacilitySiteTypeCode = this.getFacilitySiteTypeCode();
            String rhsFacilitySiteTypeCode;
            rhsFacilitySiteTypeCode = that.getFacilitySiteTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilitySiteTypeCode", lhsFacilitySiteTypeCode), LocatorUtils.property(thatLocator, "facilitySiteTypeCode", rhsFacilitySiteTypeCode), lhsFacilitySiteTypeCode, rhsFacilitySiteTypeCode)) {
                return false;
            }
        }
        {
            FacilitySiteTypeCodeListIdentifierDataType lhsFacilitySiteTypeCodeListIdentifier;
            lhsFacilitySiteTypeCodeListIdentifier = this.getFacilitySiteTypeCodeListIdentifier();
            FacilitySiteTypeCodeListIdentifierDataType rhsFacilitySiteTypeCodeListIdentifier;
            rhsFacilitySiteTypeCodeListIdentifier = that.getFacilitySiteTypeCodeListIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilitySiteTypeCodeListIdentifier", lhsFacilitySiteTypeCodeListIdentifier), LocatorUtils.property(thatLocator, "facilitySiteTypeCodeListIdentifier", rhsFacilitySiteTypeCodeListIdentifier), lhsFacilitySiteTypeCodeListIdentifier, rhsFacilitySiteTypeCodeListIdentifier)) {
                return false;
            }
        }
        {
            String lhsFacilitySiteTypeName;
            lhsFacilitySiteTypeName = this.getFacilitySiteTypeName();
            String rhsFacilitySiteTypeName;
            rhsFacilitySiteTypeName = that.getFacilitySiteTypeName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilitySiteTypeName", lhsFacilitySiteTypeName), LocatorUtils.property(thatLocator, "facilitySiteTypeName", rhsFacilitySiteTypeName), lhsFacilitySiteTypeName, rhsFacilitySiteTypeName)) {
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
            String theFacilitySiteTypeCode;
            theFacilitySiteTypeCode = this.getFacilitySiteTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilitySiteTypeCode", theFacilitySiteTypeCode), currentHashCode, theFacilitySiteTypeCode);
        }
        {
            FacilitySiteTypeCodeListIdentifierDataType theFacilitySiteTypeCodeListIdentifier;
            theFacilitySiteTypeCodeListIdentifier = this.getFacilitySiteTypeCodeListIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilitySiteTypeCodeListIdentifier", theFacilitySiteTypeCodeListIdentifier), currentHashCode, theFacilitySiteTypeCodeListIdentifier);
        }
        {
            String theFacilitySiteTypeName;
            theFacilitySiteTypeName = this.getFacilitySiteTypeName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilitySiteTypeName", theFacilitySiteTypeName), currentHashCode, theFacilitySiteTypeName);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

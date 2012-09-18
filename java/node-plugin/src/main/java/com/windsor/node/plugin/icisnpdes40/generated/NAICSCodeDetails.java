//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
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
 * <p>Java class for NAICSCodeDetails complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="NAICSCodeDetails">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NAICSCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NAICSPrimaryIndicatorCode"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "NAICSCodeDetails", propOrder = {
    "naicsCode",
    "naicsPrimaryIndicatorCode"
})
@Entity(name = "NAICSCodeDetails")
@Table(name = "ICS_NAICS_CODE")
@Inheritance(strategy = InheritanceType.JOINED)
public class NAICSCodeDetails
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "NAICSCode", required = true)
    protected String naicsCode;
    @XmlElement(name = "NAICSPrimaryIndicatorCode", required = true)
    protected String naicsPrimaryIndicatorCode;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the naicsCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NAICS_CODE", columnDefinition = "char(6)", length = 6)
    public String getNAICSCode() {
        return naicsCode;
    }

    /**
     * Sets the value of the naicsCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNAICSCode(String value) {
        this.naicsCode = value;
    }

    @Transient
    public boolean isSetNAICSCode() {
        return (this.naicsCode!= null);
    }

    /**
     * Gets the value of the naicsPrimaryIndicatorCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NAICS_PRIMARY_IND_CODE", columnDefinition = "char(1)", length = 1)
    public String getNAICSPrimaryIndicatorCode() {
        return naicsPrimaryIndicatorCode;
    }

    /**
     * Sets the value of the naicsPrimaryIndicatorCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNAICSPrimaryIndicatorCode(String value) {
        this.naicsPrimaryIndicatorCode = value;
    }

    @Transient
    public boolean isSetNAICSPrimaryIndicatorCode() {
        return (this.naicsPrimaryIndicatorCode!= null);
    }

    /**
     * 
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Id
    @Column(name = "ICS_NAICS_CODE_ID")
    public String getDbid() {
        return dbid;
    }

    /**
     * 
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof NAICSCodeDetails)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final NAICSCodeDetails that = ((NAICSCodeDetails) object);
        {
            String lhsNAICSCode;
            lhsNAICSCode = this.getNAICSCode();
            String rhsNAICSCode;
            rhsNAICSCode = that.getNAICSCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "naicsCode", lhsNAICSCode), LocatorUtils.property(thatLocator, "naicsCode", rhsNAICSCode), lhsNAICSCode, rhsNAICSCode)) {
                return false;
            }
        }
        {
            String lhsNAICSPrimaryIndicatorCode;
            lhsNAICSPrimaryIndicatorCode = this.getNAICSPrimaryIndicatorCode();
            String rhsNAICSPrimaryIndicatorCode;
            rhsNAICSPrimaryIndicatorCode = that.getNAICSPrimaryIndicatorCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "naicsPrimaryIndicatorCode", lhsNAICSPrimaryIndicatorCode), LocatorUtils.property(thatLocator, "naicsPrimaryIndicatorCode", rhsNAICSPrimaryIndicatorCode), lhsNAICSPrimaryIndicatorCode, rhsNAICSPrimaryIndicatorCode)) {
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
            String theNAICSCode;
            theNAICSCode = this.getNAICSCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "naicsCode", theNAICSCode), currentHashCode, theNAICSCode);
        }
        {
            String theNAICSPrimaryIndicatorCode;
            theNAICSPrimaryIndicatorCode = this.getNAICSPrimaryIndicatorCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "naicsPrimaryIndicatorCode", theNAICSPrimaryIndicatorCode), currentHashCode, theNAICSPrimaryIndicatorCode);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

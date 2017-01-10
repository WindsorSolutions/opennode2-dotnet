//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
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
 * <p>Java class for AssociatedPermit complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AssociatedPermit">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}AssociatedPermitIdentifier"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}AssociatedPermitReasonCode"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AssociatedPermit", propOrder = {
    "associatedPermitIdentifier",
    "associatedPermitReasonCode"
})
@Entity(name = "AssociatedPermit")
@Table(name = "ICS_ASSC_PRMT")
@Inheritance(strategy = InheritanceType.JOINED)
public class AssociatedPermit
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "AssociatedPermitIdentifier", required = true)
    protected String associatedPermitIdentifier;
    @XmlElement(name = "AssociatedPermitReasonCode", required = true)
    protected String associatedPermitReasonCode;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the associatedPermitIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ASSC_PRMT_IDENT", columnDefinition = "char(9)", length = 9)
    public String getAssociatedPermitIdentifier() {
        return associatedPermitIdentifier;
    }

    /**
     * Sets the value of the associatedPermitIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAssociatedPermitIdentifier(String value) {
        this.associatedPermitIdentifier = value;
    }

    @Transient
    public boolean isSetAssociatedPermitIdentifier() {
        return (this.associatedPermitIdentifier!= null);
    }

    /**
     * Gets the value of the associatedPermitReasonCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ASSC_PRMT_REASON_CODE", length = 3)
    public String getAssociatedPermitReasonCode() {
        return associatedPermitReasonCode;
    }

    /**
     * Sets the value of the associatedPermitReasonCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAssociatedPermitReasonCode(String value) {
        this.associatedPermitReasonCode = value;
    }

    @Transient
    public boolean isSetAssociatedPermitReasonCode() {
        return (this.associatedPermitReasonCode!= null);
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
    @Column(name = "ICS_ASSC_PRMT_ID")
    @GeneratedValue(strategy = GenerationType.AUTO)
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
        if (!(object instanceof AssociatedPermit)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final AssociatedPermit that = ((AssociatedPermit) object);
        {
            String lhsAssociatedPermitIdentifier;
            lhsAssociatedPermitIdentifier = this.getAssociatedPermitIdentifier();
            String rhsAssociatedPermitIdentifier;
            rhsAssociatedPermitIdentifier = that.getAssociatedPermitIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "associatedPermitIdentifier", lhsAssociatedPermitIdentifier), LocatorUtils.property(thatLocator, "associatedPermitIdentifier", rhsAssociatedPermitIdentifier), lhsAssociatedPermitIdentifier, rhsAssociatedPermitIdentifier)) {
                return false;
            }
        }
        {
            String lhsAssociatedPermitReasonCode;
            lhsAssociatedPermitReasonCode = this.getAssociatedPermitReasonCode();
            String rhsAssociatedPermitReasonCode;
            rhsAssociatedPermitReasonCode = that.getAssociatedPermitReasonCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "associatedPermitReasonCode", lhsAssociatedPermitReasonCode), LocatorUtils.property(thatLocator, "associatedPermitReasonCode", rhsAssociatedPermitReasonCode), lhsAssociatedPermitReasonCode, rhsAssociatedPermitReasonCode)) {
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
            String theAssociatedPermitIdentifier;
            theAssociatedPermitIdentifier = this.getAssociatedPermitIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "associatedPermitIdentifier", theAssociatedPermitIdentifier), currentHashCode, theAssociatedPermitIdentifier);
        }
        {
            String theAssociatedPermitReasonCode;
            theAssociatedPermitReasonCode = this.getAssociatedPermitReasonCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "associatedPermitReasonCode", theAssociatedPermitReasonCode), currentHashCode, theAssociatedPermitReasonCode);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
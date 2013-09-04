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
 * <p>Java class for OrganizationIdentityDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="OrganizationIdentityDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}OrganizationIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}OrganizationFormalName" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "OrganizationIdentityDataType", propOrder = {
    "organizationIdentifier",
    "organizationFormalName"
})
@Embeddable
public class OrganizationIdentityDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "OrganizationIdentifier")
    protected OrganizationIdentifierDataType organizationIdentifier;
    @XmlElement(name = "OrganizationFormalName")
    protected String organizationFormalName;

    /**
     * Gets the value of the organizationIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link OrganizationIdentifierDataType }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "value", column = @Column(name = "VALUE", length = 255)),
        @AttributeOverride(name = "organizationIdentifierContext", column = @Column(name = "ORG_IDEN_CNTXT", length = 255))
    })
    public OrganizationIdentifierDataType getOrganizationIdentifier() {
        return organizationIdentifier;
    }

    /**
     * Sets the value of the organizationIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link OrganizationIdentifierDataType }
     *     
     */
    public void setOrganizationIdentifier(OrganizationIdentifierDataType value) {
        this.organizationIdentifier = value;
    }

    @Transient
    public boolean isSetOrganizationIdentifier() {
        return (this.organizationIdentifier!= null);
    }

    /**
     * Gets the value of the organizationFormalName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ORG_FRML_NAME", length = 255)
    public String getOrganizationFormalName() {
        return organizationFormalName;
    }

    /**
     * Sets the value of the organizationFormalName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizationFormalName(String value) {
        this.organizationFormalName = value;
    }

    @Transient
    public boolean isSetOrganizationFormalName() {
        return (this.organizationFormalName!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof OrganizationIdentityDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final OrganizationIdentityDataType that = ((OrganizationIdentityDataType) object);
        {
            OrganizationIdentifierDataType lhsOrganizationIdentifier;
            lhsOrganizationIdentifier = this.getOrganizationIdentifier();
            OrganizationIdentifierDataType rhsOrganizationIdentifier;
            rhsOrganizationIdentifier = that.getOrganizationIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "organizationIdentifier", lhsOrganizationIdentifier), LocatorUtils.property(thatLocator, "organizationIdentifier", rhsOrganizationIdentifier), lhsOrganizationIdentifier, rhsOrganizationIdentifier)) {
                return false;
            }
        }
        {
            String lhsOrganizationFormalName;
            lhsOrganizationFormalName = this.getOrganizationFormalName();
            String rhsOrganizationFormalName;
            rhsOrganizationFormalName = that.getOrganizationFormalName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "organizationFormalName", lhsOrganizationFormalName), LocatorUtils.property(thatLocator, "organizationFormalName", rhsOrganizationFormalName), lhsOrganizationFormalName, rhsOrganizationFormalName)) {
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
            OrganizationIdentifierDataType theOrganizationIdentifier;
            theOrganizationIdentifier = this.getOrganizationIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "organizationIdentifier", theOrganizationIdentifier), currentHashCode, theOrganizationIdentifier);
        }
        {
            String theOrganizationFormalName;
            theOrganizationFormalName = this.getOrganizationFormalName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "organizationFormalName", theOrganizationFormalName), currentHashCode, theOrganizationFormalName);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
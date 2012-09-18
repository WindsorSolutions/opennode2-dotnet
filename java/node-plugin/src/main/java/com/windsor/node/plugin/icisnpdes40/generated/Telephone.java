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
 * <p>Java class for Telephone complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Telephone">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TelephoneNumberTypeCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TelephoneNumber" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TelephoneExtensionNumber" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Telephone", propOrder = {
    "telephoneNumberTypeCode",
    "telephoneNumber",
    "telephoneExtensionNumber"
})
@Entity(name = "Telephone")
@Table(name = "ICS_TELEPH")
@Inheritance(strategy = InheritanceType.JOINED)
public class Telephone
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TelephoneNumberTypeCode", required = true)
    protected String telephoneNumberTypeCode;
    @XmlElement(name = "TelephoneNumber")
    protected String telephoneNumber;
    @XmlElement(name = "TelephoneExtensionNumber")
    protected String telephoneExtensionNumber;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the telephoneNumberTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TELEPH_NUM_TYPE_CODE", length = 3)
    public String getTelephoneNumberTypeCode() {
        return telephoneNumberTypeCode;
    }

    /**
     * Sets the value of the telephoneNumberTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTelephoneNumberTypeCode(String value) {
        this.telephoneNumberTypeCode = value;
    }

    @Transient
    public boolean isSetTelephoneNumberTypeCode() {
        return (this.telephoneNumberTypeCode!= null);
    }

    /**
     * Gets the value of the telephoneNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TELEPH_NUM", length = 10)
    public String getTelephoneNumber() {
        return telephoneNumber;
    }

    /**
     * Sets the value of the telephoneNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTelephoneNumber(String value) {
        this.telephoneNumber = value;
    }

    @Transient
    public boolean isSetTelephoneNumber() {
        return (this.telephoneNumber!= null);
    }

    /**
     * Gets the value of the telephoneExtensionNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TELEPH_EXT_NUM", length = 4)
    public String getTelephoneExtensionNumber() {
        return telephoneExtensionNumber;
    }

    /**
     * Sets the value of the telephoneExtensionNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTelephoneExtensionNumber(String value) {
        this.telephoneExtensionNumber = value;
    }

    @Transient
    public boolean isSetTelephoneExtensionNumber() {
        return (this.telephoneExtensionNumber!= null);
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
    @Column(name = "ICS_TELEPH_ID")
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
        if (!(object instanceof Telephone)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final Telephone that = ((Telephone) object);
        {
            String lhsTelephoneNumberTypeCode;
            lhsTelephoneNumberTypeCode = this.getTelephoneNumberTypeCode();
            String rhsTelephoneNumberTypeCode;
            rhsTelephoneNumberTypeCode = that.getTelephoneNumberTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "telephoneNumberTypeCode", lhsTelephoneNumberTypeCode), LocatorUtils.property(thatLocator, "telephoneNumberTypeCode", rhsTelephoneNumberTypeCode), lhsTelephoneNumberTypeCode, rhsTelephoneNumberTypeCode)) {
                return false;
            }
        }
        {
            String lhsTelephoneNumber;
            lhsTelephoneNumber = this.getTelephoneNumber();
            String rhsTelephoneNumber;
            rhsTelephoneNumber = that.getTelephoneNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "telephoneNumber", lhsTelephoneNumber), LocatorUtils.property(thatLocator, "telephoneNumber", rhsTelephoneNumber), lhsTelephoneNumber, rhsTelephoneNumber)) {
                return false;
            }
        }
        {
            String lhsTelephoneExtensionNumber;
            lhsTelephoneExtensionNumber = this.getTelephoneExtensionNumber();
            String rhsTelephoneExtensionNumber;
            rhsTelephoneExtensionNumber = that.getTelephoneExtensionNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "telephoneExtensionNumber", lhsTelephoneExtensionNumber), LocatorUtils.property(thatLocator, "telephoneExtensionNumber", rhsTelephoneExtensionNumber), lhsTelephoneExtensionNumber, rhsTelephoneExtensionNumber)) {
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
            String theTelephoneNumberTypeCode;
            theTelephoneNumberTypeCode = this.getTelephoneNumberTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "telephoneNumberTypeCode", theTelephoneNumberTypeCode), currentHashCode, theTelephoneNumberTypeCode);
        }
        {
            String theTelephoneNumber;
            theTelephoneNumber = this.getTelephoneNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "telephoneNumber", theTelephoneNumber), currentHashCode, theTelephoneNumber);
        }
        {
            String theTelephoneExtensionNumber;
            theTelephoneExtensionNumber = this.getTelephoneExtensionNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "telephoneExtensionNumber", theTelephoneExtensionNumber), currentHashCode, theTelephoneExtensionNumber);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

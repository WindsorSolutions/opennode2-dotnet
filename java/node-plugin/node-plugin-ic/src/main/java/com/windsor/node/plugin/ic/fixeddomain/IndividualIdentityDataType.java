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
 * <p>Java class for IndividualIdentityDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="IndividualIdentityDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}IndividualIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}IndividualTitleText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}NamePrefixText" minOccurs="0"/>
 *         &lt;choice minOccurs="0">
 *           &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}IndividualFullName" minOccurs="0"/>
 *           &lt;sequence minOccurs="0">
 *             &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}FirstName" minOccurs="0"/>
 *             &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}MiddleName" minOccurs="0"/>
 *             &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}LastName" minOccurs="0"/>
 *           &lt;/sequence>
 *         &lt;/choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}NameSuffixText" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "IndividualIdentityDataType", propOrder = {
    "individualIdentifier",
    "individualTitleText",
    "namePrefixText",
    "individualFullName",
    "firstName",
    "middleName",
    "lastName",
    "nameSuffixText"
})
@Embeddable
public class IndividualIdentityDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "IndividualIdentifier")
    protected IndividualIdentifierDataType individualIdentifier;
    @XmlElement(name = "IndividualTitleText")
    protected String individualTitleText;
    @XmlElement(name = "NamePrefixText")
    protected String namePrefixText;
    @XmlElement(name = "IndividualFullName")
    protected String individualFullName;
    @XmlElement(name = "FirstName")
    protected String firstName;
    @XmlElement(name = "MiddleName")
    protected String middleName;
    @XmlElement(name = "LastName")
    protected String lastName;
    @XmlElement(name = "NameSuffixText")
    protected String nameSuffixText;

    /**
     * Gets the value of the individualIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link IndividualIdentifierDataType }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "value", column = @Column(name = "VALUE", length = 255)),
        @AttributeOverride(name = "individualIdentifierContext", column = @Column(name = "INDVL_IDEN_CNTXT", length = 255))
    })
    public IndividualIdentifierDataType getIndividualIdentifier() {
        return individualIdentifier;
    }

    /**
     * Sets the value of the individualIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link IndividualIdentifierDataType }
     *     
     */
    public void setIndividualIdentifier(IndividualIdentifierDataType value) {
        this.individualIdentifier = value;
    }

    @Transient
    public boolean isSetIndividualIdentifier() {
        return (this.individualIdentifier!= null);
    }

    /**
     * Gets the value of the individualTitleText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "INDVL_TITLE_TXT", length = 255)
    public String getIndividualTitleText() {
        return individualTitleText;
    }

    /**
     * Sets the value of the individualTitleText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setIndividualTitleText(String value) {
        this.individualTitleText = value;
    }

    @Transient
    public boolean isSetIndividualTitleText() {
        return (this.individualTitleText!= null);
    }

    /**
     * Gets the value of the namePrefixText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NAME_PREFIX_TXT", length = 255)
    public String getNamePrefixText() {
        return namePrefixText;
    }

    /**
     * Sets the value of the namePrefixText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNamePrefixText(String value) {
        this.namePrefixText = value;
    }

    @Transient
    public boolean isSetNamePrefixText() {
        return (this.namePrefixText!= null);
    }

    /**
     * Gets the value of the individualFullName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "INDVL_FULL_NAME", length = 255)
    public String getIndividualFullName() {
        return individualFullName;
    }

    /**
     * Sets the value of the individualFullName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setIndividualFullName(String value) {
        this.individualFullName = value;
    }

    @Transient
    public boolean isSetIndividualFullName() {
        return (this.individualFullName!= null);
    }

    /**
     * Gets the value of the firstName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FIRST_NAME", length = 255)
    public String getFirstName() {
        return firstName;
    }

    /**
     * Sets the value of the firstName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFirstName(String value) {
        this.firstName = value;
    }

    @Transient
    public boolean isSetFirstName() {
        return (this.firstName!= null);
    }

    /**
     * Gets the value of the middleName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MIDDLE_NAME", length = 255)
    public String getMiddleName() {
        return middleName;
    }

    /**
     * Sets the value of the middleName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMiddleName(String value) {
        this.middleName = value;
    }

    @Transient
    public boolean isSetMiddleName() {
        return (this.middleName!= null);
    }

    /**
     * Gets the value of the lastName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LAST_NAME", length = 255)
    public String getLastName() {
        return lastName;
    }

    /**
     * Sets the value of the lastName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLastName(String value) {
        this.lastName = value;
    }

    @Transient
    public boolean isSetLastName() {
        return (this.lastName!= null);
    }

    /**
     * Gets the value of the nameSuffixText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NAME_SUFFIX_TXT", length = 255)
    public String getNameSuffixText() {
        return nameSuffixText;
    }

    /**
     * Sets the value of the nameSuffixText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNameSuffixText(String value) {
        this.nameSuffixText = value;
    }

    @Transient
    public boolean isSetNameSuffixText() {
        return (this.nameSuffixText!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof IndividualIdentityDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final IndividualIdentityDataType that = ((IndividualIdentityDataType) object);
        {
            IndividualIdentifierDataType lhsIndividualIdentifier;
            lhsIndividualIdentifier = this.getIndividualIdentifier();
            IndividualIdentifierDataType rhsIndividualIdentifier;
            rhsIndividualIdentifier = that.getIndividualIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "individualIdentifier", lhsIndividualIdentifier), LocatorUtils.property(thatLocator, "individualIdentifier", rhsIndividualIdentifier), lhsIndividualIdentifier, rhsIndividualIdentifier)) {
                return false;
            }
        }
        {
            String lhsIndividualTitleText;
            lhsIndividualTitleText = this.getIndividualTitleText();
            String rhsIndividualTitleText;
            rhsIndividualTitleText = that.getIndividualTitleText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "individualTitleText", lhsIndividualTitleText), LocatorUtils.property(thatLocator, "individualTitleText", rhsIndividualTitleText), lhsIndividualTitleText, rhsIndividualTitleText)) {
                return false;
            }
        }
        {
            String lhsNamePrefixText;
            lhsNamePrefixText = this.getNamePrefixText();
            String rhsNamePrefixText;
            rhsNamePrefixText = that.getNamePrefixText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "namePrefixText", lhsNamePrefixText), LocatorUtils.property(thatLocator, "namePrefixText", rhsNamePrefixText), lhsNamePrefixText, rhsNamePrefixText)) {
                return false;
            }
        }
        {
            String lhsIndividualFullName;
            lhsIndividualFullName = this.getIndividualFullName();
            String rhsIndividualFullName;
            rhsIndividualFullName = that.getIndividualFullName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "individualFullName", lhsIndividualFullName), LocatorUtils.property(thatLocator, "individualFullName", rhsIndividualFullName), lhsIndividualFullName, rhsIndividualFullName)) {
                return false;
            }
        }
        {
            String lhsFirstName;
            lhsFirstName = this.getFirstName();
            String rhsFirstName;
            rhsFirstName = that.getFirstName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "firstName", lhsFirstName), LocatorUtils.property(thatLocator, "firstName", rhsFirstName), lhsFirstName, rhsFirstName)) {
                return false;
            }
        }
        {
            String lhsMiddleName;
            lhsMiddleName = this.getMiddleName();
            String rhsMiddleName;
            rhsMiddleName = that.getMiddleName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "middleName", lhsMiddleName), LocatorUtils.property(thatLocator, "middleName", rhsMiddleName), lhsMiddleName, rhsMiddleName)) {
                return false;
            }
        }
        {
            String lhsLastName;
            lhsLastName = this.getLastName();
            String rhsLastName;
            rhsLastName = that.getLastName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "lastName", lhsLastName), LocatorUtils.property(thatLocator, "lastName", rhsLastName), lhsLastName, rhsLastName)) {
                return false;
            }
        }
        {
            String lhsNameSuffixText;
            lhsNameSuffixText = this.getNameSuffixText();
            String rhsNameSuffixText;
            rhsNameSuffixText = that.getNameSuffixText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "nameSuffixText", lhsNameSuffixText), LocatorUtils.property(thatLocator, "nameSuffixText", rhsNameSuffixText), lhsNameSuffixText, rhsNameSuffixText)) {
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
            IndividualIdentifierDataType theIndividualIdentifier;
            theIndividualIdentifier = this.getIndividualIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "individualIdentifier", theIndividualIdentifier), currentHashCode, theIndividualIdentifier);
        }
        {
            String theIndividualTitleText;
            theIndividualTitleText = this.getIndividualTitleText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "individualTitleText", theIndividualTitleText), currentHashCode, theIndividualTitleText);
        }
        {
            String theNamePrefixText;
            theNamePrefixText = this.getNamePrefixText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "namePrefixText", theNamePrefixText), currentHashCode, theNamePrefixText);
        }
        {
            String theIndividualFullName;
            theIndividualFullName = this.getIndividualFullName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "individualFullName", theIndividualFullName), currentHashCode, theIndividualFullName);
        }
        {
            String theFirstName;
            theFirstName = this.getFirstName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "firstName", theFirstName), currentHashCode, theFirstName);
        }
        {
            String theMiddleName;
            theMiddleName = this.getMiddleName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "middleName", theMiddleName), currentHashCode, theMiddleName);
        }
        {
            String theLastName;
            theLastName = this.getLastName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "lastName", theLastName), currentHashCode, theLastName);
        }
        {
            String theNameSuffixText;
            theNameSuffixText = this.getNameSuffixText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "nameSuffixText", theNameSuffixText), currentHashCode, theNameSuffixText);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

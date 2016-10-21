//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

import java.math.BigInteger;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
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
 * <p>Java class for CitationDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CitationDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}TransactionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CitationNameSequenceNumber"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CitationName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CitationNameOwner" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CitationNameType" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CitationDescription" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}Notes" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CitationDataType", propOrder = {
    "transactionCode",
    "citationNameSequenceNumber",
    "citationName",
    "citationNameOwner",
    "citationNameType",
    "citationDescription",
    "notes"
})
@Entity(name = "CitationDataType")
@Table(name = "RCRA_CITN")
@Inheritance(strategy = InheritanceType.JOINED)
public class CitationDataType
    implements Equals, HashCode
{

    @XmlElement(name = "TransactionCode")
    protected String transactionCode;
    @XmlElement(name = "CitationNameSequenceNumber", required = true)
    protected BigInteger citationNameSequenceNumber;
    @XmlElement(name = "CitationName")
    protected String citationName;
    @XmlElement(name = "CitationNameOwner")
    protected String citationNameOwner;
    @XmlElement(name = "CitationNameType")
    protected String citationNameType;
    @XmlElement(name = "CitationDescription")
    protected String citationDescription;
    @XmlElement(name = "Notes")
    protected String notes;
    @XmlAttribute(name = "Id")
    protected Long id;

    /**
     * Gets the value of the transactionCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TRANSACTIONCODE", length = 1)
    public String getTransactionCode() {
        return transactionCode;
    }

    /**
     * Sets the value of the transactionCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTransactionCode(String value) {
        this.transactionCode = value;
    }

    /**
     * Gets the value of the citationNameSequenceNumber property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    @Basic
    @Column(name = "CITNNAMESEQNUMBER", precision = 6, scale = 0)
    public BigInteger getCitationNameSequenceNumber() {
        return citationNameSequenceNumber;
    }

    /**
     * Sets the value of the citationNameSequenceNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setCitationNameSequenceNumber(BigInteger value) {
        this.citationNameSequenceNumber = value;
    }

    /**
     * Gets the value of the citationName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CITNNAME", length = 35)
    public String getCitationName() {
        return citationName;
    }

    /**
     * Sets the value of the citationName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCitationName(String value) {
        this.citationName = value;
    }

    /**
     * Gets the value of the citationNameOwner property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CITNNAMEOWNR", length = 2)
    public String getCitationNameOwner() {
        return citationNameOwner;
    }

    /**
     * Sets the value of the citationNameOwner property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCitationNameOwner(String value) {
        this.citationNameOwner = value;
    }

    /**
     * Gets the value of the citationNameType property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CITNNAMETYPE", length = 2)
    public String getCitationNameType() {
        return citationNameType;
    }

    /**
     * Sets the value of the citationNameType property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCitationNameType(String value) {
        this.citationNameType = value;
    }

    /**
     * Gets the value of the citationDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CITNDESC", length = 255)
    public String getCitationDescription() {
        return citationDescription;
    }

    /**
     * Sets the value of the citationDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCitationDescription(String value) {
        this.citationDescription = value;
    }

    /**
     * Gets the value of the notes property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NOTES", length = 2000)
    public String getNotes() {
        return notes;
    }

    /**
     * Sets the value of the notes property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNotes(String value) {
        this.notes = value;
    }

    /**
     * Gets the value of the id property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    @Id
    @Column(name = "ID")
    @GeneratedValue(generator = "ColSequence", strategy = GenerationType.AUTO)
    @SequenceGenerator(name = "ColSequence", sequenceName = "COLUMN_ID_SEQUENCE", allocationSize = 1)
    public Long getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setId(Long value) {
        this.id = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof CitationDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final CitationDataType that = ((CitationDataType) object);
        {
            String lhsTransactionCode;
            lhsTransactionCode = this.getTransactionCode();
            String rhsTransactionCode;
            rhsTransactionCode = that.getTransactionCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "transactionCode", lhsTransactionCode), LocatorUtils.property(thatLocator, "transactionCode", rhsTransactionCode), lhsTransactionCode, rhsTransactionCode)) {
                return false;
            }
        }
        {
            BigInteger lhsCitationNameSequenceNumber;
            lhsCitationNameSequenceNumber = this.getCitationNameSequenceNumber();
            BigInteger rhsCitationNameSequenceNumber;
            rhsCitationNameSequenceNumber = that.getCitationNameSequenceNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "citationNameSequenceNumber", lhsCitationNameSequenceNumber), LocatorUtils.property(thatLocator, "citationNameSequenceNumber", rhsCitationNameSequenceNumber), lhsCitationNameSequenceNumber, rhsCitationNameSequenceNumber)) {
                return false;
            }
        }
        {
            String lhsCitationName;
            lhsCitationName = this.getCitationName();
            String rhsCitationName;
            rhsCitationName = that.getCitationName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "citationName", lhsCitationName), LocatorUtils.property(thatLocator, "citationName", rhsCitationName), lhsCitationName, rhsCitationName)) {
                return false;
            }
        }
        {
            String lhsCitationNameOwner;
            lhsCitationNameOwner = this.getCitationNameOwner();
            String rhsCitationNameOwner;
            rhsCitationNameOwner = that.getCitationNameOwner();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "citationNameOwner", lhsCitationNameOwner), LocatorUtils.property(thatLocator, "citationNameOwner", rhsCitationNameOwner), lhsCitationNameOwner, rhsCitationNameOwner)) {
                return false;
            }
        }
        {
            String lhsCitationNameType;
            lhsCitationNameType = this.getCitationNameType();
            String rhsCitationNameType;
            rhsCitationNameType = that.getCitationNameType();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "citationNameType", lhsCitationNameType), LocatorUtils.property(thatLocator, "citationNameType", rhsCitationNameType), lhsCitationNameType, rhsCitationNameType)) {
                return false;
            }
        }
        {
            String lhsCitationDescription;
            lhsCitationDescription = this.getCitationDescription();
            String rhsCitationDescription;
            rhsCitationDescription = that.getCitationDescription();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "citationDescription", lhsCitationDescription), LocatorUtils.property(thatLocator, "citationDescription", rhsCitationDescription), lhsCitationDescription, rhsCitationDescription)) {
                return false;
            }
        }
        {
            String lhsNotes;
            lhsNotes = this.getNotes();
            String rhsNotes;
            rhsNotes = that.getNotes();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "notes", lhsNotes), LocatorUtils.property(thatLocator, "notes", rhsNotes), lhsNotes, rhsNotes)) {
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
            String theTransactionCode;
            theTransactionCode = this.getTransactionCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "transactionCode", theTransactionCode), currentHashCode, theTransactionCode);
        }
        {
            BigInteger theCitationNameSequenceNumber;
            theCitationNameSequenceNumber = this.getCitationNameSequenceNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "citationNameSequenceNumber", theCitationNameSequenceNumber), currentHashCode, theCitationNameSequenceNumber);
        }
        {
            String theCitationName;
            theCitationName = this.getCitationName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "citationName", theCitationName), currentHashCode, theCitationName);
        }
        {
            String theCitationNameOwner;
            theCitationNameOwner = this.getCitationNameOwner();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "citationNameOwner", theCitationNameOwner), currentHashCode, theCitationNameOwner);
        }
        {
            String theCitationNameType;
            theCitationNameType = this.getCitationNameType();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "citationNameType", theCitationNameType), currentHashCode, theCitationNameType);
        }
        {
            String theCitationDescription;
            theCitationDescription = this.getCitationDescription();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "citationDescription", theCitationDescription), currentHashCode, theCitationDescription);
        }
        {
            String theNotes;
            theNotes = this.getNotes();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "notes", theNotes), currentHashCode, theNotes);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
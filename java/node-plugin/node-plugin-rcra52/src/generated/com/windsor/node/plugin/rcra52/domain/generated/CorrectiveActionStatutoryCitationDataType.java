//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

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
 * Details for statutory citation.
 * 
 * <p>Java class for CorrectiveActionStatutoryCitationDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CorrectiveActionStatutoryCitationDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}TransactionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}StatutoryCitationDataOwnerCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}StatutoryCitationIdentifier"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}StatutoryCitationDescription" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CorrectiveActionStatutoryCitationDataType", propOrder = {
    "transactionCode",
    "statutoryCitationDataOwnerCode",
    "statutoryCitationIdentifier",
    "statutoryCitationDescription"
})
@Entity(name = "CorrectiveActionStatutoryCitationDataType")
@Table(name = "RCRA_CORRACTSTATCITN")
@Inheritance(strategy = InheritanceType.JOINED)
public class CorrectiveActionStatutoryCitationDataType
    implements Equals, HashCode
{

    @XmlElement(name = "TransactionCode")
    protected String transactionCode;
    @XmlElement(name = "StatutoryCitationDataOwnerCode", required = true)
    protected String statutoryCitationDataOwnerCode;
    @XmlElement(name = "StatutoryCitationIdentifier", required = true)
    protected String statutoryCitationIdentifier;
    @XmlElement(name = "StatutoryCitationDescription")
    protected String statutoryCitationDescription;
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
     * Gets the value of the statutoryCitationDataOwnerCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "STATCITNDATOWNRCODE", length = 2)
    public String getStatutoryCitationDataOwnerCode() {
        return statutoryCitationDataOwnerCode;
    }

    /**
     * Sets the value of the statutoryCitationDataOwnerCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStatutoryCitationDataOwnerCode(String value) {
        this.statutoryCitationDataOwnerCode = value;
    }

    /**
     * Gets the value of the statutoryCitationIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "STATCITNID", length = 1)
    public String getStatutoryCitationIdentifier() {
        return statutoryCitationIdentifier;
    }

    /**
     * Sets the value of the statutoryCitationIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStatutoryCitationIdentifier(String value) {
        this.statutoryCitationIdentifier = value;
    }

    /**
     * Gets the value of the statutoryCitationDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "STATCITNDESC", length = 255)
    public String getStatutoryCitationDescription() {
        return statutoryCitationDescription;
    }

    /**
     * Sets the value of the statutoryCitationDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStatutoryCitationDescription(String value) {
        this.statutoryCitationDescription = value;
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
        if (!(object instanceof CorrectiveActionStatutoryCitationDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final CorrectiveActionStatutoryCitationDataType that = ((CorrectiveActionStatutoryCitationDataType) object);
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
            String lhsStatutoryCitationDataOwnerCode;
            lhsStatutoryCitationDataOwnerCode = this.getStatutoryCitationDataOwnerCode();
            String rhsStatutoryCitationDataOwnerCode;
            rhsStatutoryCitationDataOwnerCode = that.getStatutoryCitationDataOwnerCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "statutoryCitationDataOwnerCode", lhsStatutoryCitationDataOwnerCode), LocatorUtils.property(thatLocator, "statutoryCitationDataOwnerCode", rhsStatutoryCitationDataOwnerCode), lhsStatutoryCitationDataOwnerCode, rhsStatutoryCitationDataOwnerCode)) {
                return false;
            }
        }
        {
            String lhsStatutoryCitationIdentifier;
            lhsStatutoryCitationIdentifier = this.getStatutoryCitationIdentifier();
            String rhsStatutoryCitationIdentifier;
            rhsStatutoryCitationIdentifier = that.getStatutoryCitationIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "statutoryCitationIdentifier", lhsStatutoryCitationIdentifier), LocatorUtils.property(thatLocator, "statutoryCitationIdentifier", rhsStatutoryCitationIdentifier), lhsStatutoryCitationIdentifier, rhsStatutoryCitationIdentifier)) {
                return false;
            }
        }
        {
            String lhsStatutoryCitationDescription;
            lhsStatutoryCitationDescription = this.getStatutoryCitationDescription();
            String rhsStatutoryCitationDescription;
            rhsStatutoryCitationDescription = that.getStatutoryCitationDescription();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "statutoryCitationDescription", lhsStatutoryCitationDescription), LocatorUtils.property(thatLocator, "statutoryCitationDescription", rhsStatutoryCitationDescription), lhsStatutoryCitationDescription, rhsStatutoryCitationDescription)) {
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
            String theStatutoryCitationDataOwnerCode;
            theStatutoryCitationDataOwnerCode = this.getStatutoryCitationDataOwnerCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "statutoryCitationDataOwnerCode", theStatutoryCitationDataOwnerCode), currentHashCode, theStatutoryCitationDataOwnerCode);
        }
        {
            String theStatutoryCitationIdentifier;
            theStatutoryCitationIdentifier = this.getStatutoryCitationIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "statutoryCitationIdentifier", theStatutoryCitationIdentifier), currentHashCode, theStatutoryCitationIdentifier);
        }
        {
            String theStatutoryCitationDescription;
            theStatutoryCitationDescription = this.getStatutoryCitationDescription();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "statutoryCitationDescription", theStatutoryCitationDescription), currentHashCode, theStatutoryCitationDescription);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

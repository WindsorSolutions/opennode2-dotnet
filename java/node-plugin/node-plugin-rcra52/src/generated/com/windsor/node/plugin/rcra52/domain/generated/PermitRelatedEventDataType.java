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
 * <p>Java class for PermitRelatedEventDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermitRelatedEventDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}TransactionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}ActivityLocationCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}PermitSeriesSequenceNumber"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}PermitEventDataOwnerCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}PermitEventCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}PermitEventText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}EventAgencyCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AgencyText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}EventSequenceNumber"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermitRelatedEventDataType", propOrder = {
    "transactionCode",
    "activityLocationCode",
    "permitSeriesSequenceNumber",
    "permitEventDataOwnerCode",
    "permitEventCode",
    "permitEventText",
    "eventAgencyCode",
    "agencyText",
    "eventSequenceNumber"
})
@Entity(name = "PermitRelatedEventDataType")
@Table(name = "RCRA_PERMITRELEVENT")
@Inheritance(strategy = InheritanceType.JOINED)
public class PermitRelatedEventDataType
    implements Equals, HashCode
{

    @XmlElement(name = "TransactionCode")
    protected String transactionCode;
    @XmlElement(name = "ActivityLocationCode", required = true)
    protected String activityLocationCode;
    @XmlElement(name = "PermitSeriesSequenceNumber", required = true)
    protected BigInteger permitSeriesSequenceNumber;
    @XmlElement(name = "PermitEventDataOwnerCode", required = true)
    protected String permitEventDataOwnerCode;
    @XmlElement(name = "PermitEventCode", required = true)
    protected String permitEventCode;
    @XmlElement(name = "PermitEventText")
    protected String permitEventText;
    @XmlElement(name = "EventAgencyCode", required = true)
    protected String eventAgencyCode;
    @XmlElement(name = "AgencyText")
    protected String agencyText;
    @XmlElement(name = "EventSequenceNumber", required = true)
    protected BigInteger eventSequenceNumber;
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
     * Gets the value of the activityLocationCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ACTLOCCODE", length = 255)
    public String getActivityLocationCode() {
        return activityLocationCode;
    }

    /**
     * Sets the value of the activityLocationCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setActivityLocationCode(String value) {
        this.activityLocationCode = value;
    }

    /**
     * Gets the value of the permitSeriesSequenceNumber property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    @Basic
    @Column(name = "PERMITSERIESSEQNUMBER", precision = 4, scale = 0)
    public BigInteger getPermitSeriesSequenceNumber() {
        return permitSeriesSequenceNumber;
    }

    /**
     * Sets the value of the permitSeriesSequenceNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setPermitSeriesSequenceNumber(BigInteger value) {
        this.permitSeriesSequenceNumber = value;
    }

    /**
     * Gets the value of the permitEventDataOwnerCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PERMITEVENTDATOWNRCODE", length = 2)
    public String getPermitEventDataOwnerCode() {
        return permitEventDataOwnerCode;
    }

    /**
     * Sets the value of the permitEventDataOwnerCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitEventDataOwnerCode(String value) {
        this.permitEventDataOwnerCode = value;
    }

    /**
     * Gets the value of the permitEventCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PERMITEVENTCODE", length = 7)
    public String getPermitEventCode() {
        return permitEventCode;
    }

    /**
     * Sets the value of the permitEventCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitEventCode(String value) {
        this.permitEventCode = value;
    }

    /**
     * Gets the value of the permitEventText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PERMITEVENTTXT", length = 255)
    public String getPermitEventText() {
        return permitEventText;
    }

    /**
     * Sets the value of the permitEventText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitEventText(String value) {
        this.permitEventText = value;
    }

    /**
     * Gets the value of the eventAgencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "EVENTAGENCYCODE", length = 1)
    public String getEventAgencyCode() {
        return eventAgencyCode;
    }

    /**
     * Sets the value of the eventAgencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEventAgencyCode(String value) {
        this.eventAgencyCode = value;
    }

    /**
     * Gets the value of the agencyText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AGENCYTXT", length = 255)
    public String getAgencyText() {
        return agencyText;
    }

    /**
     * Sets the value of the agencyText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAgencyText(String value) {
        this.agencyText = value;
    }

    /**
     * Gets the value of the eventSequenceNumber property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    @Basic
    @Column(name = "EVENTSEQNUMBER", precision = 3, scale = 0)
    public BigInteger getEventSequenceNumber() {
        return eventSequenceNumber;
    }

    /**
     * Sets the value of the eventSequenceNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setEventSequenceNumber(BigInteger value) {
        this.eventSequenceNumber = value;
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
        if (!(object instanceof PermitRelatedEventDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PermitRelatedEventDataType that = ((PermitRelatedEventDataType) object);
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
            String lhsActivityLocationCode;
            lhsActivityLocationCode = this.getActivityLocationCode();
            String rhsActivityLocationCode;
            rhsActivityLocationCode = that.getActivityLocationCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "activityLocationCode", lhsActivityLocationCode), LocatorUtils.property(thatLocator, "activityLocationCode", rhsActivityLocationCode), lhsActivityLocationCode, rhsActivityLocationCode)) {
                return false;
            }
        }
        {
            BigInteger lhsPermitSeriesSequenceNumber;
            lhsPermitSeriesSequenceNumber = this.getPermitSeriesSequenceNumber();
            BigInteger rhsPermitSeriesSequenceNumber;
            rhsPermitSeriesSequenceNumber = that.getPermitSeriesSequenceNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitSeriesSequenceNumber", lhsPermitSeriesSequenceNumber), LocatorUtils.property(thatLocator, "permitSeriesSequenceNumber", rhsPermitSeriesSequenceNumber), lhsPermitSeriesSequenceNumber, rhsPermitSeriesSequenceNumber)) {
                return false;
            }
        }
        {
            String lhsPermitEventDataOwnerCode;
            lhsPermitEventDataOwnerCode = this.getPermitEventDataOwnerCode();
            String rhsPermitEventDataOwnerCode;
            rhsPermitEventDataOwnerCode = that.getPermitEventDataOwnerCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitEventDataOwnerCode", lhsPermitEventDataOwnerCode), LocatorUtils.property(thatLocator, "permitEventDataOwnerCode", rhsPermitEventDataOwnerCode), lhsPermitEventDataOwnerCode, rhsPermitEventDataOwnerCode)) {
                return false;
            }
        }
        {
            String lhsPermitEventCode;
            lhsPermitEventCode = this.getPermitEventCode();
            String rhsPermitEventCode;
            rhsPermitEventCode = that.getPermitEventCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitEventCode", lhsPermitEventCode), LocatorUtils.property(thatLocator, "permitEventCode", rhsPermitEventCode), lhsPermitEventCode, rhsPermitEventCode)) {
                return false;
            }
        }
        {
            String lhsPermitEventText;
            lhsPermitEventText = this.getPermitEventText();
            String rhsPermitEventText;
            rhsPermitEventText = that.getPermitEventText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitEventText", lhsPermitEventText), LocatorUtils.property(thatLocator, "permitEventText", rhsPermitEventText), lhsPermitEventText, rhsPermitEventText)) {
                return false;
            }
        }
        {
            String lhsEventAgencyCode;
            lhsEventAgencyCode = this.getEventAgencyCode();
            String rhsEventAgencyCode;
            rhsEventAgencyCode = that.getEventAgencyCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "eventAgencyCode", lhsEventAgencyCode), LocatorUtils.property(thatLocator, "eventAgencyCode", rhsEventAgencyCode), lhsEventAgencyCode, rhsEventAgencyCode)) {
                return false;
            }
        }
        {
            String lhsAgencyText;
            lhsAgencyText = this.getAgencyText();
            String rhsAgencyText;
            rhsAgencyText = that.getAgencyText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "agencyText", lhsAgencyText), LocatorUtils.property(thatLocator, "agencyText", rhsAgencyText), lhsAgencyText, rhsAgencyText)) {
                return false;
            }
        }
        {
            BigInteger lhsEventSequenceNumber;
            lhsEventSequenceNumber = this.getEventSequenceNumber();
            BigInteger rhsEventSequenceNumber;
            rhsEventSequenceNumber = that.getEventSequenceNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "eventSequenceNumber", lhsEventSequenceNumber), LocatorUtils.property(thatLocator, "eventSequenceNumber", rhsEventSequenceNumber), lhsEventSequenceNumber, rhsEventSequenceNumber)) {
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
            String theActivityLocationCode;
            theActivityLocationCode = this.getActivityLocationCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "activityLocationCode", theActivityLocationCode), currentHashCode, theActivityLocationCode);
        }
        {
            BigInteger thePermitSeriesSequenceNumber;
            thePermitSeriesSequenceNumber = this.getPermitSeriesSequenceNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitSeriesSequenceNumber", thePermitSeriesSequenceNumber), currentHashCode, thePermitSeriesSequenceNumber);
        }
        {
            String thePermitEventDataOwnerCode;
            thePermitEventDataOwnerCode = this.getPermitEventDataOwnerCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitEventDataOwnerCode", thePermitEventDataOwnerCode), currentHashCode, thePermitEventDataOwnerCode);
        }
        {
            String thePermitEventCode;
            thePermitEventCode = this.getPermitEventCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitEventCode", thePermitEventCode), currentHashCode, thePermitEventCode);
        }
        {
            String thePermitEventText;
            thePermitEventText = this.getPermitEventText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitEventText", thePermitEventText), currentHashCode, thePermitEventText);
        }
        {
            String theEventAgencyCode;
            theEventAgencyCode = this.getEventAgencyCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "eventAgencyCode", theEventAgencyCode), currentHashCode, theEventAgencyCode);
        }
        {
            String theAgencyText;
            theAgencyText = this.getAgencyText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "agencyText", theAgencyText), currentHashCode, theAgencyText);
        }
        {
            BigInteger theEventSequenceNumber;
            theEventSequenceNumber = this.getEventSequenceNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "eventSequenceNumber", theEventSequenceNumber), currentHashCode, theEventSequenceNumber);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

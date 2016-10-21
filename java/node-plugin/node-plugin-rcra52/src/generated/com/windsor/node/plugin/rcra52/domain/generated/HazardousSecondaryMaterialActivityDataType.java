//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
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
 * Hazardous Secondary Material activity of the Handler
 * 
 * <p>Java class for HazardousSecondaryMaterialActivityDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="HazardousSecondaryMaterialActivityDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}TransactionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}HSMSequenceNumber"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}FacilityCodeOwnerName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}FacilityTypeCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}FacilityTypeText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}EstimatedShortTonsQuantity" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}ActualShortTonsQuantity" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}LandBasedUnitIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}LandBasedUnitIndicatorText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}HandlerWasteCodeDetails" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "HazardousSecondaryMaterialActivityDataType", propOrder = {
    "transactionCode",
    "hsmSequenceNumber",
    "facilityCodeOwnerName",
    "facilityTypeCode",
    "facilityTypeText",
    "estimatedShortTonsQuantity",
    "actualShortTonsQuantity",
    "landBasedUnitIndicator",
    "landBasedUnitIndicatorText",
    "handlerWasteCodeDetails"
})
@Entity(name = "HazardousSecondaryMaterialActivityDataType")
@Table(name = "RCRA_HZRDSECONDARYMTRLACT")
@Inheritance(strategy = InheritanceType.JOINED)
public class HazardousSecondaryMaterialActivityDataType
    implements Equals, HashCode
{

    @XmlElement(name = "TransactionCode")
    protected String transactionCode;
    @XmlElement(name = "HSMSequenceNumber", required = true)
    protected String hsmSequenceNumber;
    @XmlElement(name = "FacilityCodeOwnerName")
    protected String facilityCodeOwnerName;
    @XmlElement(name = "FacilityTypeCode")
    protected String facilityTypeCode;
    @XmlElement(name = "FacilityTypeText")
    protected String facilityTypeText;
    @XmlElement(name = "EstimatedShortTonsQuantity")
    protected BigDecimal estimatedShortTonsQuantity;
    @XmlElement(name = "ActualShortTonsQuantity")
    protected BigDecimal actualShortTonsQuantity;
    @XmlElement(name = "LandBasedUnitIndicator")
    protected String landBasedUnitIndicator;
    @XmlElement(name = "LandBasedUnitIndicatorText")
    protected String landBasedUnitIndicatorText;
    @XmlElement(name = "HandlerWasteCodeDetails")
    protected List<HandlerWasteCodeDataType> handlerWasteCodeDetails;
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
     * Gets the value of the hsmSequenceNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "HSMSEQNUMBER", length = 4)
    public String getHSMSequenceNumber() {
        return hsmSequenceNumber;
    }

    /**
     * Sets the value of the hsmSequenceNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setHSMSequenceNumber(String value) {
        this.hsmSequenceNumber = value;
    }

    /**
     * Gets the value of the facilityCodeOwnerName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FACCODEOWNRNAME", length = 2)
    public String getFacilityCodeOwnerName() {
        return facilityCodeOwnerName;
    }

    /**
     * Sets the value of the facilityCodeOwnerName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilityCodeOwnerName(String value) {
        this.facilityCodeOwnerName = value;
    }

    /**
     * Gets the value of the facilityTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FACTYPECODE", length = 2)
    public String getFacilityTypeCode() {
        return facilityTypeCode;
    }

    /**
     * Sets the value of the facilityTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilityTypeCode(String value) {
        this.facilityTypeCode = value;
    }

    /**
     * Gets the value of the facilityTypeText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FACTYPETXT", length = 255)
    public String getFacilityTypeText() {
        return facilityTypeText;
    }

    /**
     * Sets the value of the facilityTypeText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilityTypeText(String value) {
        this.facilityTypeText = value;
    }

    /**
     * Gets the value of the estimatedShortTonsQuantity property.
     * 
     * @return
     *     possible object is
     *     {@link BigDecimal }
     *     
     */
    @Basic
    @Column(name = "ESTIMATEDSHORTTONSQUANT", precision = 20, scale = 10)
    public BigDecimal getEstimatedShortTonsQuantity() {
        return estimatedShortTonsQuantity;
    }

    /**
     * Sets the value of the estimatedShortTonsQuantity property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigDecimal }
     *     
     */
    public void setEstimatedShortTonsQuantity(BigDecimal value) {
        this.estimatedShortTonsQuantity = value;
    }

    /**
     * Gets the value of the actualShortTonsQuantity property.
     * 
     * @return
     *     possible object is
     *     {@link BigDecimal }
     *     
     */
    @Basic
    @Column(name = "ACTUALSHORTTONSQUANT", precision = 20, scale = 10)
    public BigDecimal getActualShortTonsQuantity() {
        return actualShortTonsQuantity;
    }

    /**
     * Sets the value of the actualShortTonsQuantity property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigDecimal }
     *     
     */
    public void setActualShortTonsQuantity(BigDecimal value) {
        this.actualShortTonsQuantity = value;
    }

    /**
     * Gets the value of the landBasedUnitIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LANDBASEDUNITIND", length = 2)
    public String getLandBasedUnitIndicator() {
        return landBasedUnitIndicator;
    }

    /**
     * Sets the value of the landBasedUnitIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLandBasedUnitIndicator(String value) {
        this.landBasedUnitIndicator = value;
    }

    /**
     * Gets the value of the landBasedUnitIndicatorText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LANDBASEDUNITINDTXT", length = 255)
    public String getLandBasedUnitIndicatorText() {
        return landBasedUnitIndicatorText;
    }

    /**
     * Sets the value of the landBasedUnitIndicatorText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLandBasedUnitIndicatorText(String value) {
        this.landBasedUnitIndicatorText = value;
    }

    /**
     * Gets the value of the handlerWasteCodeDetails property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the handlerWasteCodeDetails property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getHandlerWasteCodeDetails().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link HandlerWasteCodeDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = HandlerWasteCodeDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "HZRDSECONDARYMTRLACTID")
    public List<HandlerWasteCodeDataType> getHandlerWasteCodeDetails() {
        if (handlerWasteCodeDetails == null) {
            handlerWasteCodeDetails = new ArrayList<HandlerWasteCodeDataType>();
        }
        return this.handlerWasteCodeDetails;
    }

    /**
     * 
     * 
     */
    public void setHandlerWasteCodeDetails(List<HandlerWasteCodeDataType> handlerWasteCodeDetails) {
        this.handlerWasteCodeDetails = handlerWasteCodeDetails;
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
        if (!(object instanceof HazardousSecondaryMaterialActivityDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final HazardousSecondaryMaterialActivityDataType that = ((HazardousSecondaryMaterialActivityDataType) object);
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
            String lhsHSMSequenceNumber;
            lhsHSMSequenceNumber = this.getHSMSequenceNumber();
            String rhsHSMSequenceNumber;
            rhsHSMSequenceNumber = that.getHSMSequenceNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "hsmSequenceNumber", lhsHSMSequenceNumber), LocatorUtils.property(thatLocator, "hsmSequenceNumber", rhsHSMSequenceNumber), lhsHSMSequenceNumber, rhsHSMSequenceNumber)) {
                return false;
            }
        }
        {
            String lhsFacilityCodeOwnerName;
            lhsFacilityCodeOwnerName = this.getFacilityCodeOwnerName();
            String rhsFacilityCodeOwnerName;
            rhsFacilityCodeOwnerName = that.getFacilityCodeOwnerName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilityCodeOwnerName", lhsFacilityCodeOwnerName), LocatorUtils.property(thatLocator, "facilityCodeOwnerName", rhsFacilityCodeOwnerName), lhsFacilityCodeOwnerName, rhsFacilityCodeOwnerName)) {
                return false;
            }
        }
        {
            String lhsFacilityTypeCode;
            lhsFacilityTypeCode = this.getFacilityTypeCode();
            String rhsFacilityTypeCode;
            rhsFacilityTypeCode = that.getFacilityTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilityTypeCode", lhsFacilityTypeCode), LocatorUtils.property(thatLocator, "facilityTypeCode", rhsFacilityTypeCode), lhsFacilityTypeCode, rhsFacilityTypeCode)) {
                return false;
            }
        }
        {
            String lhsFacilityTypeText;
            lhsFacilityTypeText = this.getFacilityTypeText();
            String rhsFacilityTypeText;
            rhsFacilityTypeText = that.getFacilityTypeText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilityTypeText", lhsFacilityTypeText), LocatorUtils.property(thatLocator, "facilityTypeText", rhsFacilityTypeText), lhsFacilityTypeText, rhsFacilityTypeText)) {
                return false;
            }
        }
        {
            BigDecimal lhsEstimatedShortTonsQuantity;
            lhsEstimatedShortTonsQuantity = this.getEstimatedShortTonsQuantity();
            BigDecimal rhsEstimatedShortTonsQuantity;
            rhsEstimatedShortTonsQuantity = that.getEstimatedShortTonsQuantity();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "estimatedShortTonsQuantity", lhsEstimatedShortTonsQuantity), LocatorUtils.property(thatLocator, "estimatedShortTonsQuantity", rhsEstimatedShortTonsQuantity), lhsEstimatedShortTonsQuantity, rhsEstimatedShortTonsQuantity)) {
                return false;
            }
        }
        {
            BigDecimal lhsActualShortTonsQuantity;
            lhsActualShortTonsQuantity = this.getActualShortTonsQuantity();
            BigDecimal rhsActualShortTonsQuantity;
            rhsActualShortTonsQuantity = that.getActualShortTonsQuantity();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "actualShortTonsQuantity", lhsActualShortTonsQuantity), LocatorUtils.property(thatLocator, "actualShortTonsQuantity", rhsActualShortTonsQuantity), lhsActualShortTonsQuantity, rhsActualShortTonsQuantity)) {
                return false;
            }
        }
        {
            String lhsLandBasedUnitIndicator;
            lhsLandBasedUnitIndicator = this.getLandBasedUnitIndicator();
            String rhsLandBasedUnitIndicator;
            rhsLandBasedUnitIndicator = that.getLandBasedUnitIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "landBasedUnitIndicator", lhsLandBasedUnitIndicator), LocatorUtils.property(thatLocator, "landBasedUnitIndicator", rhsLandBasedUnitIndicator), lhsLandBasedUnitIndicator, rhsLandBasedUnitIndicator)) {
                return false;
            }
        }
        {
            String lhsLandBasedUnitIndicatorText;
            lhsLandBasedUnitIndicatorText = this.getLandBasedUnitIndicatorText();
            String rhsLandBasedUnitIndicatorText;
            rhsLandBasedUnitIndicatorText = that.getLandBasedUnitIndicatorText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "landBasedUnitIndicatorText", lhsLandBasedUnitIndicatorText), LocatorUtils.property(thatLocator, "landBasedUnitIndicatorText", rhsLandBasedUnitIndicatorText), lhsLandBasedUnitIndicatorText, rhsLandBasedUnitIndicatorText)) {
                return false;
            }
        }
        {
            List<HandlerWasteCodeDataType> lhsHandlerWasteCodeDetails;
            lhsHandlerWasteCodeDetails = (((this.handlerWasteCodeDetails!= null)&&(!this.handlerWasteCodeDetails.isEmpty()))?this.getHandlerWasteCodeDetails():null);
            List<HandlerWasteCodeDataType> rhsHandlerWasteCodeDetails;
            rhsHandlerWasteCodeDetails = (((that.handlerWasteCodeDetails!= null)&&(!that.handlerWasteCodeDetails.isEmpty()))?that.getHandlerWasteCodeDetails():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "handlerWasteCodeDetails", lhsHandlerWasteCodeDetails), LocatorUtils.property(thatLocator, "handlerWasteCodeDetails", rhsHandlerWasteCodeDetails), lhsHandlerWasteCodeDetails, rhsHandlerWasteCodeDetails)) {
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
            String theHSMSequenceNumber;
            theHSMSequenceNumber = this.getHSMSequenceNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "hsmSequenceNumber", theHSMSequenceNumber), currentHashCode, theHSMSequenceNumber);
        }
        {
            String theFacilityCodeOwnerName;
            theFacilityCodeOwnerName = this.getFacilityCodeOwnerName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilityCodeOwnerName", theFacilityCodeOwnerName), currentHashCode, theFacilityCodeOwnerName);
        }
        {
            String theFacilityTypeCode;
            theFacilityTypeCode = this.getFacilityTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilityTypeCode", theFacilityTypeCode), currentHashCode, theFacilityTypeCode);
        }
        {
            String theFacilityTypeText;
            theFacilityTypeText = this.getFacilityTypeText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilityTypeText", theFacilityTypeText), currentHashCode, theFacilityTypeText);
        }
        {
            BigDecimal theEstimatedShortTonsQuantity;
            theEstimatedShortTonsQuantity = this.getEstimatedShortTonsQuantity();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "estimatedShortTonsQuantity", theEstimatedShortTonsQuantity), currentHashCode, theEstimatedShortTonsQuantity);
        }
        {
            BigDecimal theActualShortTonsQuantity;
            theActualShortTonsQuantity = this.getActualShortTonsQuantity();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "actualShortTonsQuantity", theActualShortTonsQuantity), currentHashCode, theActualShortTonsQuantity);
        }
        {
            String theLandBasedUnitIndicator;
            theLandBasedUnitIndicator = this.getLandBasedUnitIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "landBasedUnitIndicator", theLandBasedUnitIndicator), currentHashCode, theLandBasedUnitIndicator);
        }
        {
            String theLandBasedUnitIndicatorText;
            theLandBasedUnitIndicatorText = this.getLandBasedUnitIndicatorText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "landBasedUnitIndicatorText", theLandBasedUnitIndicatorText), currentHashCode, theLandBasedUnitIndicatorText);
        }
        {
            List<HandlerWasteCodeDataType> theHandlerWasteCodeDetails;
            theHandlerWasteCodeDetails = (((this.handlerWasteCodeDetails!= null)&&(!this.handlerWasteCodeDetails.isEmpty()))?this.getHandlerWasteCodeDetails():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "handlerWasteCodeDetails", theHandlerWasteCodeDetails), currentHashCode, theHandlerWasteCodeDetails);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
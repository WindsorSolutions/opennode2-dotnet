//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CollectionTable;
import javax.persistence.Column;
import javax.persistence.ElementCollection;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.DateAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.IntegerAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.TwoDigitPrecisionAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for FinalOrder complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="FinalOrder">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FinalOrderIdentifier"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FinalOrderTypeCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FinalOrderPermitIdentifier" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FinalOrderIssuedEnteredDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NPDESClosedDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FinalOrderQNCRComments" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}CashCivilPenaltyRequiredAmount" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}OtherComments" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "FinalOrder", propOrder = {
    "finalOrderIdentifier",
    "finalOrderTypeCode",
    "finalOrderPermitIdentifier",
    "finalOrderIssuedEnteredDate",
    "npdesClosedDate",
    "finalOrderQNCRComments",
    "cashCivilPenaltyRequiredAmount",
    "otherComments"
})
@Entity(name = "FinalOrder")
@Table(name = "ICS_FINAL_ORDER")
@Inheritance(strategy = InheritanceType.JOINED)
public class FinalOrder
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "FinalOrderIdentifier", required = true, type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer finalOrderIdentifier;
    @XmlElement(name = "FinalOrderTypeCode")
    protected String finalOrderTypeCode;
    @XmlElement(name = "FinalOrderPermitIdentifier")
    protected List<String> finalOrderPermitIdentifier;
    @XmlElement(name = "FinalOrderIssuedEnteredDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date finalOrderIssuedEnteredDate;
    @XmlElement(name = "NPDESClosedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date npdesClosedDate;
    @XmlElement(name = "FinalOrderQNCRComments")
    protected String finalOrderQNCRComments;
    @XmlElement(name = "CashCivilPenaltyRequiredAmount", type = String.class)
    @XmlJavaTypeAdapter(TwoDigitPrecisionAdapter.class)
    protected BigDecimal cashCivilPenaltyRequiredAmount;
    @XmlElement(name = "OtherComments")
    protected String otherComments;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the finalOrderIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FINAL_ORDER_IDENT", scale = 0)
    public Integer getFinalOrderIdentifier() {
        return finalOrderIdentifier;
    }

    /**
     * Sets the value of the finalOrderIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFinalOrderIdentifier(Integer value) {
        this.finalOrderIdentifier = value;
    }

    @Transient
    public boolean isSetFinalOrderIdentifier() {
        return (this.finalOrderIdentifier!= null);
    }

    /**
     * Gets the value of the finalOrderTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FINAL_ORDER_TYPE_CODE", length = 3)
    public String getFinalOrderTypeCode() {
        return finalOrderTypeCode;
    }

    /**
     * Sets the value of the finalOrderTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFinalOrderTypeCode(String value) {
        this.finalOrderTypeCode = value;
    }

    @Transient
    public boolean isSetFinalOrderTypeCode() {
        return (this.finalOrderTypeCode!= null);
    }

    /**
     * Gets the value of the finalOrderPermitIdentifier property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the finalOrderPermitIdentifier property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getFinalOrderPermitIdentifier().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    @ElementCollection
    @Column(name = "FINAL_ORDER_PRMT_IDENT", length = 9)
    @CollectionTable(name = "ICS_FINAL_ORDER_PRMT_IDENT", joinColumns = {
        @JoinColumn(name = "ICS_FINAL_ORDER_ID")
    })
    public List<String> getFinalOrderPermitIdentifier() {
        if (finalOrderPermitIdentifier == null) {
            finalOrderPermitIdentifier = new ArrayList<String>();
        }
        return this.finalOrderPermitIdentifier;
    }

    /**
     * 
     * 
     */
    public void setFinalOrderPermitIdentifier(List<String> finalOrderPermitIdentifier) {
        this.finalOrderPermitIdentifier = finalOrderPermitIdentifier;
    }

    @Transient
    public boolean isSetFinalOrderPermitIdentifier() {
        return ((this.finalOrderPermitIdentifier!= null)&&(!this.finalOrderPermitIdentifier.isEmpty()));
    }

    public void unsetFinalOrderPermitIdentifier() {
        this.finalOrderPermitIdentifier = null;
    }

    /**
     * Gets the value of the finalOrderIssuedEnteredDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FINAL_ORDER_ISSUED_ENTERD_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getFinalOrderIssuedEnteredDate() {
        return finalOrderIssuedEnteredDate;
    }

    /**
     * Sets the value of the finalOrderIssuedEnteredDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFinalOrderIssuedEnteredDate(Date value) {
        this.finalOrderIssuedEnteredDate = value;
    }

    @Transient
    public boolean isSetFinalOrderIssuedEnteredDate() {
        return (this.finalOrderIssuedEnteredDate!= null);
    }

    /**
     * Gets the value of the npdesClosedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NPDES_CLOSED_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getNPDESClosedDate() {
        return npdesClosedDate;
    }

    /**
     * Sets the value of the npdesClosedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNPDESClosedDate(Date value) {
        this.npdesClosedDate = value;
    }

    @Transient
    public boolean isSetNPDESClosedDate() {
        return (this.npdesClosedDate!= null);
    }

    /**
     * Gets the value of the finalOrderQNCRComments property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "FINAL_ORDER_QNCR_CMNTS", length = 2000)
    public String getFinalOrderQNCRComments() {
        return finalOrderQNCRComments;
    }

    /**
     * Sets the value of the finalOrderQNCRComments property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFinalOrderQNCRComments(String value) {
        this.finalOrderQNCRComments = value;
    }

    @Transient
    public boolean isSetFinalOrderQNCRComments() {
        return (this.finalOrderQNCRComments!= null);
    }

    /**
     * Gets the value of the cashCivilPenaltyRequiredAmount property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CASH_CIVIL_PNLTY_REQD_AMT", scale = 2)
    public BigDecimal getCashCivilPenaltyRequiredAmount() {
        return cashCivilPenaltyRequiredAmount;
    }

    /**
     * Sets the value of the cashCivilPenaltyRequiredAmount property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCashCivilPenaltyRequiredAmount(BigDecimal value) {
        this.cashCivilPenaltyRequiredAmount = value;
    }

    @Transient
    public boolean isSetCashCivilPenaltyRequiredAmount() {
        return (this.cashCivilPenaltyRequiredAmount!= null);
    }

    /**
     * Gets the value of the otherComments property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHR_CMNTS", length = 4000)
    public String getOtherComments() {
        return otherComments;
    }

    /**
     * Sets the value of the otherComments property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherComments(String value) {
        this.otherComments = value;
    }

    @Transient
    public boolean isSetOtherComments() {
        return (this.otherComments!= null);
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
    @Column(name = "ICS_FINAL_ORDER_ID")
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
        if (!(object instanceof FinalOrder)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final FinalOrder that = ((FinalOrder) object);
        {
            Integer lhsFinalOrderIdentifier;
            lhsFinalOrderIdentifier = this.getFinalOrderIdentifier();
            Integer rhsFinalOrderIdentifier;
            rhsFinalOrderIdentifier = that.getFinalOrderIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "finalOrderIdentifier", lhsFinalOrderIdentifier), LocatorUtils.property(thatLocator, "finalOrderIdentifier", rhsFinalOrderIdentifier), lhsFinalOrderIdentifier, rhsFinalOrderIdentifier)) {
                return false;
            }
        }
        {
            String lhsFinalOrderTypeCode;
            lhsFinalOrderTypeCode = this.getFinalOrderTypeCode();
            String rhsFinalOrderTypeCode;
            rhsFinalOrderTypeCode = that.getFinalOrderTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "finalOrderTypeCode", lhsFinalOrderTypeCode), LocatorUtils.property(thatLocator, "finalOrderTypeCode", rhsFinalOrderTypeCode), lhsFinalOrderTypeCode, rhsFinalOrderTypeCode)) {
                return false;
            }
        }
        {
            List<String> lhsFinalOrderPermitIdentifier;
            lhsFinalOrderPermitIdentifier = (this.isSetFinalOrderPermitIdentifier()?this.getFinalOrderPermitIdentifier():null);
            List<String> rhsFinalOrderPermitIdentifier;
            rhsFinalOrderPermitIdentifier = (that.isSetFinalOrderPermitIdentifier()?that.getFinalOrderPermitIdentifier():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "finalOrderPermitIdentifier", lhsFinalOrderPermitIdentifier), LocatorUtils.property(thatLocator, "finalOrderPermitIdentifier", rhsFinalOrderPermitIdentifier), lhsFinalOrderPermitIdentifier, rhsFinalOrderPermitIdentifier)) {
                return false;
            }
        }
        {
            Date lhsFinalOrderIssuedEnteredDate;
            lhsFinalOrderIssuedEnteredDate = this.getFinalOrderIssuedEnteredDate();
            Date rhsFinalOrderIssuedEnteredDate;
            rhsFinalOrderIssuedEnteredDate = that.getFinalOrderIssuedEnteredDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "finalOrderIssuedEnteredDate", lhsFinalOrderIssuedEnteredDate), LocatorUtils.property(thatLocator, "finalOrderIssuedEnteredDate", rhsFinalOrderIssuedEnteredDate), lhsFinalOrderIssuedEnteredDate, rhsFinalOrderIssuedEnteredDate)) {
                return false;
            }
        }
        {
            Date lhsNPDESClosedDate;
            lhsNPDESClosedDate = this.getNPDESClosedDate();
            Date rhsNPDESClosedDate;
            rhsNPDESClosedDate = that.getNPDESClosedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "npdesClosedDate", lhsNPDESClosedDate), LocatorUtils.property(thatLocator, "npdesClosedDate", rhsNPDESClosedDate), lhsNPDESClosedDate, rhsNPDESClosedDate)) {
                return false;
            }
        }
        {
            String lhsFinalOrderQNCRComments;
            lhsFinalOrderQNCRComments = this.getFinalOrderQNCRComments();
            String rhsFinalOrderQNCRComments;
            rhsFinalOrderQNCRComments = that.getFinalOrderQNCRComments();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "finalOrderQNCRComments", lhsFinalOrderQNCRComments), LocatorUtils.property(thatLocator, "finalOrderQNCRComments", rhsFinalOrderQNCRComments), lhsFinalOrderQNCRComments, rhsFinalOrderQNCRComments)) {
                return false;
            }
        }
        {
            BigDecimal lhsCashCivilPenaltyRequiredAmount;
            lhsCashCivilPenaltyRequiredAmount = this.getCashCivilPenaltyRequiredAmount();
            BigDecimal rhsCashCivilPenaltyRequiredAmount;
            rhsCashCivilPenaltyRequiredAmount = that.getCashCivilPenaltyRequiredAmount();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "cashCivilPenaltyRequiredAmount", lhsCashCivilPenaltyRequiredAmount), LocatorUtils.property(thatLocator, "cashCivilPenaltyRequiredAmount", rhsCashCivilPenaltyRequiredAmount), lhsCashCivilPenaltyRequiredAmount, rhsCashCivilPenaltyRequiredAmount)) {
                return false;
            }
        }
        {
            String lhsOtherComments;
            lhsOtherComments = this.getOtherComments();
            String rhsOtherComments;
            rhsOtherComments = that.getOtherComments();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherComments", lhsOtherComments), LocatorUtils.property(thatLocator, "otherComments", rhsOtherComments), lhsOtherComments, rhsOtherComments)) {
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
            Integer theFinalOrderIdentifier;
            theFinalOrderIdentifier = this.getFinalOrderIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "finalOrderIdentifier", theFinalOrderIdentifier), currentHashCode, theFinalOrderIdentifier);
        }
        {
            String theFinalOrderTypeCode;
            theFinalOrderTypeCode = this.getFinalOrderTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "finalOrderTypeCode", theFinalOrderTypeCode), currentHashCode, theFinalOrderTypeCode);
        }
        {
            List<String> theFinalOrderPermitIdentifier;
            theFinalOrderPermitIdentifier = (this.isSetFinalOrderPermitIdentifier()?this.getFinalOrderPermitIdentifier():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "finalOrderPermitIdentifier", theFinalOrderPermitIdentifier), currentHashCode, theFinalOrderPermitIdentifier);
        }
        {
            Date theFinalOrderIssuedEnteredDate;
            theFinalOrderIssuedEnteredDate = this.getFinalOrderIssuedEnteredDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "finalOrderIssuedEnteredDate", theFinalOrderIssuedEnteredDate), currentHashCode, theFinalOrderIssuedEnteredDate);
        }
        {
            Date theNPDESClosedDate;
            theNPDESClosedDate = this.getNPDESClosedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "npdesClosedDate", theNPDESClosedDate), currentHashCode, theNPDESClosedDate);
        }
        {
            String theFinalOrderQNCRComments;
            theFinalOrderQNCRComments = this.getFinalOrderQNCRComments();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "finalOrderQNCRComments", theFinalOrderQNCRComments), currentHashCode, theFinalOrderQNCRComments);
        }
        {
            BigDecimal theCashCivilPenaltyRequiredAmount;
            theCashCivilPenaltyRequiredAmount = this.getCashCivilPenaltyRequiredAmount();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "cashCivilPenaltyRequiredAmount", theCashCivilPenaltyRequiredAmount), currentHashCode, theCashCivilPenaltyRequiredAmount);
        }
        {
            String theOtherComments;
            theOtherComments = this.getOtherComments();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherComments", theOtherComments), currentHashCode, theOtherComments);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

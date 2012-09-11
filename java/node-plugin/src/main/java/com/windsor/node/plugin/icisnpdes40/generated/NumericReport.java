//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
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
import com.windsor.node.plugin.icisnpdes40.adapter.DateAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.StringAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for NumericReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="NumericReport">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericReportCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericReportReceivedDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericReportNoDischargeIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericConditionQuantity" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericConditionAdjustedQuantity" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericConditionQualifier" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "NumericReport", propOrder = {
    "numericReportCode",
    "numericReportReceivedDate",
    "numericReportNoDischargeIndicator",
    "numericConditionQuantity",
    "numericConditionAdjustedQuantity",
    "numericConditionQualifier"
})
@Entity(name = "NumericReport")
@Table(name = "ICS_NUM_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class NumericReport
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "NumericReportCode", required = true)
    @XmlJavaTypeAdapter(StringAdapter.class)
    protected String numericReportCode;
    @XmlElement(name = "NumericReportReceivedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date numericReportReceivedDate;
    @XmlElement(name = "NumericReportNoDischargeIndicator")
    protected String numericReportNoDischargeIndicator;
    @XmlElement(name = "NumericConditionQuantity")
    @XmlJavaTypeAdapter(StringAdapter.class)
    protected String numericConditionQuantity;
    @XmlElement(name = "NumericConditionAdjustedQuantity")
    @XmlJavaTypeAdapter(StringAdapter.class)
    protected String numericConditionAdjustedQuantity;
    @XmlElement(name = "NumericConditionQualifier")
    protected String numericConditionQualifier;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the numericReportCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_REP_CODE", length = 255)
    public String getNumericReportCode() {
        return numericReportCode;
    }

    /**
     * Sets the value of the numericReportCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericReportCode(String value) {
        this.numericReportCode = value;
    }

    @Transient
    public boolean isSetNumericReportCode() {
        return (this.numericReportCode!= null);
    }

    /**
     * Gets the value of the numericReportReceivedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_REP_RCVD_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getNumericReportReceivedDate() {
        return numericReportReceivedDate;
    }

    /**
     * Sets the value of the numericReportReceivedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericReportReceivedDate(Date value) {
        this.numericReportReceivedDate = value;
    }

    @Transient
    public boolean isSetNumericReportReceivedDate() {
        return (this.numericReportReceivedDate!= null);
    }

    /**
     * Gets the value of the numericReportNoDischargeIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_REP_NO_DSCH_IND", length = 3)
    public String getNumericReportNoDischargeIndicator() {
        return numericReportNoDischargeIndicator;
    }

    /**
     * Sets the value of the numericReportNoDischargeIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericReportNoDischargeIndicator(String value) {
        this.numericReportNoDischargeIndicator = value;
    }

    @Transient
    public boolean isSetNumericReportNoDischargeIndicator() {
        return (this.numericReportNoDischargeIndicator!= null);
    }

    /**
     * Gets the value of the numericConditionQuantity property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_COND_QTY", precision = 8, scale = 8)
    public String getNumericConditionQuantity() {
        return numericConditionQuantity;
    }

    /**
     * Sets the value of the numericConditionQuantity property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericConditionQuantity(String value) {
        this.numericConditionQuantity = value;
    }

    @Transient
    public boolean isSetNumericConditionQuantity() {
        return (this.numericConditionQuantity!= null);
    }

    /**
     * Gets the value of the numericConditionAdjustedQuantity property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_COND_ADJUSTED_QTY", precision = 8, scale = 8)
    public String getNumericConditionAdjustedQuantity() {
        return numericConditionAdjustedQuantity;
    }

    /**
     * Sets the value of the numericConditionAdjustedQuantity property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericConditionAdjustedQuantity(String value) {
        this.numericConditionAdjustedQuantity = value;
    }

    @Transient
    public boolean isSetNumericConditionAdjustedQuantity() {
        return (this.numericConditionAdjustedQuantity!= null);
    }

    /**
     * Gets the value of the numericConditionQualifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_COND_QUALIFIER", length = 3)
    public String getNumericConditionQualifier() {
        return numericConditionQualifier;
    }

    /**
     * Sets the value of the numericConditionQualifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumericConditionQualifier(String value) {
        this.numericConditionQualifier = value;
    }

    @Transient
    public boolean isSetNumericConditionQualifier() {
        return (this.numericConditionQualifier!= null);
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
    @Column(name = "ICS_NUM_REP_ID")
    public String getdbid() {
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
    public void setdbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof NumericReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final NumericReport that = ((NumericReport) object);
        {
            String lhsNumericReportCode;
            lhsNumericReportCode = this.getNumericReportCode();
            String rhsNumericReportCode;
            rhsNumericReportCode = that.getNumericReportCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericReportCode", lhsNumericReportCode), LocatorUtils.property(thatLocator, "numericReportCode", rhsNumericReportCode), lhsNumericReportCode, rhsNumericReportCode)) {
                return false;
            }
        }
        {
            Date lhsNumericReportReceivedDate;
            lhsNumericReportReceivedDate = this.getNumericReportReceivedDate();
            Date rhsNumericReportReceivedDate;
            rhsNumericReportReceivedDate = that.getNumericReportReceivedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericReportReceivedDate", lhsNumericReportReceivedDate), LocatorUtils.property(thatLocator, "numericReportReceivedDate", rhsNumericReportReceivedDate), lhsNumericReportReceivedDate, rhsNumericReportReceivedDate)) {
                return false;
            }
        }
        {
            String lhsNumericReportNoDischargeIndicator;
            lhsNumericReportNoDischargeIndicator = this.getNumericReportNoDischargeIndicator();
            String rhsNumericReportNoDischargeIndicator;
            rhsNumericReportNoDischargeIndicator = that.getNumericReportNoDischargeIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericReportNoDischargeIndicator", lhsNumericReportNoDischargeIndicator), LocatorUtils.property(thatLocator, "numericReportNoDischargeIndicator", rhsNumericReportNoDischargeIndicator), lhsNumericReportNoDischargeIndicator, rhsNumericReportNoDischargeIndicator)) {
                return false;
            }
        }
        {
            String lhsNumericConditionQuantity;
            lhsNumericConditionQuantity = this.getNumericConditionQuantity();
            String rhsNumericConditionQuantity;
            rhsNumericConditionQuantity = that.getNumericConditionQuantity();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericConditionQuantity", lhsNumericConditionQuantity), LocatorUtils.property(thatLocator, "numericConditionQuantity", rhsNumericConditionQuantity), lhsNumericConditionQuantity, rhsNumericConditionQuantity)) {
                return false;
            }
        }
        {
            String lhsNumericConditionAdjustedQuantity;
            lhsNumericConditionAdjustedQuantity = this.getNumericConditionAdjustedQuantity();
            String rhsNumericConditionAdjustedQuantity;
            rhsNumericConditionAdjustedQuantity = that.getNumericConditionAdjustedQuantity();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericConditionAdjustedQuantity", lhsNumericConditionAdjustedQuantity), LocatorUtils.property(thatLocator, "numericConditionAdjustedQuantity", rhsNumericConditionAdjustedQuantity), lhsNumericConditionAdjustedQuantity, rhsNumericConditionAdjustedQuantity)) {
                return false;
            }
        }
        {
            String lhsNumericConditionQualifier;
            lhsNumericConditionQualifier = this.getNumericConditionQualifier();
            String rhsNumericConditionQualifier;
            rhsNumericConditionQualifier = that.getNumericConditionQualifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericConditionQualifier", lhsNumericConditionQualifier), LocatorUtils.property(thatLocator, "numericConditionQualifier", rhsNumericConditionQualifier), lhsNumericConditionQualifier, rhsNumericConditionQualifier)) {
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
            String theNumericReportCode;
            theNumericReportCode = this.getNumericReportCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericReportCode", theNumericReportCode), currentHashCode, theNumericReportCode);
        }
        {
            Date theNumericReportReceivedDate;
            theNumericReportReceivedDate = this.getNumericReportReceivedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericReportReceivedDate", theNumericReportReceivedDate), currentHashCode, theNumericReportReceivedDate);
        }
        {
            String theNumericReportNoDischargeIndicator;
            theNumericReportNoDischargeIndicator = this.getNumericReportNoDischargeIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericReportNoDischargeIndicator", theNumericReportNoDischargeIndicator), currentHashCode, theNumericReportNoDischargeIndicator);
        }
        {
            String theNumericConditionQuantity;
            theNumericConditionQuantity = this.getNumericConditionQuantity();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericConditionQuantity", theNumericConditionQuantity), currentHashCode, theNumericConditionQuantity);
        }
        {
            String theNumericConditionAdjustedQuantity;
            theNumericConditionAdjustedQuantity = this.getNumericConditionAdjustedQuantity();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericConditionAdjustedQuantity", theNumericConditionAdjustedQuantity), currentHashCode, theNumericConditionAdjustedQuantity);
        }
        {
            String theNumericConditionQualifier;
            theNumericConditionQualifier = this.getNumericConditionQualifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericConditionQualifier", theNumericConditionQualifier), currentHashCode, theNumericConditionQualifier);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

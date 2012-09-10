//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.DateAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for EffluentTradePartnerKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="EffluentTradePartnerKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}EffluentTradePartnerKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "EffluentTradePartnerKeyElements", propOrder = {
    "permitIdentifier",
    "permittedFeatureIdentifier",
    "limitSetDesignator",
    "parameterCode",
    "monitoringSiteDescriptionCode",
    "limitSeasonNumber",
    "limitStartDate",
    "limitEndDate",
    "limitModificationEffectiveDate",
    "tradeID"
})
@XmlSeeAlso({
    EffluentTradePartner.class
})
@MappedSuperclass
public class EffluentTradePartnerKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "PermittedFeatureIdentifier", required = true)
    protected String permittedFeatureIdentifier;
    @XmlElement(name = "LimitSetDesignator", required = true)
    protected String limitSetDesignator;
    @XmlElement(name = "ParameterCode", required = true)
    protected String parameterCode;
    @XmlElement(name = "MonitoringSiteDescriptionCode", required = true)
    protected String monitoringSiteDescriptionCode;
    @XmlElement(name = "LimitSeasonNumber")
    protected int limitSeasonNumber;
    @XmlElement(name = "LimitStartDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date limitStartDate;
    @XmlElement(name = "LimitEndDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date limitEndDate;
    @XmlElement(name = "LimitModificationEffectiveDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date limitModificationEffectiveDate;
    @XmlElement(name = "TradeID", required = true)
    protected String tradeID;

    /**
     * Gets the value of the permitIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRMT_IDENT", columnDefinition = "char(9)", length = 9)
    public String getPermitIdentifier() {
        return permitIdentifier;
    }

    /**
     * Sets the value of the permitIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitIdentifier(String value) {
        this.permitIdentifier = value;
    }

    @Transient
    public boolean isSetPermitIdentifier() {
        return (this.permitIdentifier!= null);
    }

    /**
     * Gets the value of the permittedFeatureIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRMT_FEATR_IDENT", length = 4)
    public String getPermittedFeatureIdentifier() {
        return permittedFeatureIdentifier;
    }

    /**
     * Sets the value of the permittedFeatureIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermittedFeatureIdentifier(String value) {
        this.permittedFeatureIdentifier = value;
    }

    @Transient
    public boolean isSetPermittedFeatureIdentifier() {
        return (this.permittedFeatureIdentifier!= null);
    }

    /**
     * Gets the value of the limitSetDesignator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LMT_SET_DESIGNATOR", length = 2)
    public String getLimitSetDesignator() {
        return limitSetDesignator;
    }

    /**
     * Sets the value of the limitSetDesignator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLimitSetDesignator(String value) {
        this.limitSetDesignator = value;
    }

    @Transient
    public boolean isSetLimitSetDesignator() {
        return (this.limitSetDesignator!= null);
    }

    /**
     * Gets the value of the parameterCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PARAM_CODE", length = 5)
    public String getParameterCode() {
        return parameterCode;
    }

    /**
     * Sets the value of the parameterCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setParameterCode(String value) {
        this.parameterCode = value;
    }

    @Transient
    public boolean isSetParameterCode() {
        return (this.parameterCode!= null);
    }

    /**
     * Gets the value of the monitoringSiteDescriptionCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MON_SITE_DESC_CODE", length = 3)
    public String getMonitoringSiteDescriptionCode() {
        return monitoringSiteDescriptionCode;
    }

    /**
     * Sets the value of the monitoringSiteDescriptionCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMonitoringSiteDescriptionCode(String value) {
        this.monitoringSiteDescriptionCode = value;
    }

    @Transient
    public boolean isSetMonitoringSiteDescriptionCode() {
        return (this.monitoringSiteDescriptionCode!= null);
    }

    /**
     * Gets the value of the limitSeasonNumber property.
     * 
     */
    @Basic
    @Column(name = "LMT_SEASON_NUM", precision = 20, scale = 0)
    public int getLimitSeasonNumber() {
        return limitSeasonNumber;
    }

    /**
     * Sets the value of the limitSeasonNumber property.
     * 
     */
    public void setLimitSeasonNumber(int value) {
        this.limitSeasonNumber = value;
    }

    @Transient
    public boolean isSetLimitSeasonNumber() {
        return true;
    }

    /**
     * Gets the value of the limitStartDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LMT_START_DATE")
    @Temporal(TemporalType.DATE)
    public Date getLimitStartDate() {
        return limitStartDate;
    }

    /**
     * Sets the value of the limitStartDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLimitStartDate(Date value) {
        this.limitStartDate = value;
    }

    @Transient
    public boolean isSetLimitStartDate() {
        return (this.limitStartDate!= null);
    }

    /**
     * Gets the value of the limitEndDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LMT_END_DATE")
    @Temporal(TemporalType.DATE)
    public Date getLimitEndDate() {
        return limitEndDate;
    }

    /**
     * Sets the value of the limitEndDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLimitEndDate(Date value) {
        this.limitEndDate = value;
    }

    @Transient
    public boolean isSetLimitEndDate() {
        return (this.limitEndDate!= null);
    }

    /**
     * Gets the value of the limitModificationEffectiveDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LMT_MOD_EFFECTIVE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getLimitModificationEffectiveDate() {
        return limitModificationEffectiveDate;
    }

    /**
     * Sets the value of the limitModificationEffectiveDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLimitModificationEffectiveDate(Date value) {
        this.limitModificationEffectiveDate = value;
    }

    @Transient
    public boolean isSetLimitModificationEffectiveDate() {
        return (this.limitModificationEffectiveDate!= null);
    }

    /**
     * Gets the value of the tradeID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TRADE_ID", length = 30)
    public String getTradeID() {
        return tradeID;
    }

    /**
     * Sets the value of the tradeID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTradeID(String value) {
        this.tradeID = value;
    }

    @Transient
    public boolean isSetTradeID() {
        return (this.tradeID!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof EffluentTradePartnerKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final EffluentTradePartnerKeyElements that = ((EffluentTradePartnerKeyElements) object);
        {
            String lhsPermitIdentifier;
            lhsPermitIdentifier = this.getPermitIdentifier();
            String rhsPermitIdentifier;
            rhsPermitIdentifier = that.getPermitIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitIdentifier", lhsPermitIdentifier), LocatorUtils.property(thatLocator, "permitIdentifier", rhsPermitIdentifier), lhsPermitIdentifier, rhsPermitIdentifier)) {
                return false;
            }
        }
        {
            String lhsPermittedFeatureIdentifier;
            lhsPermittedFeatureIdentifier = this.getPermittedFeatureIdentifier();
            String rhsPermittedFeatureIdentifier;
            rhsPermittedFeatureIdentifier = that.getPermittedFeatureIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permittedFeatureIdentifier", lhsPermittedFeatureIdentifier), LocatorUtils.property(thatLocator, "permittedFeatureIdentifier", rhsPermittedFeatureIdentifier), lhsPermittedFeatureIdentifier, rhsPermittedFeatureIdentifier)) {
                return false;
            }
        }
        {
            String lhsLimitSetDesignator;
            lhsLimitSetDesignator = this.getLimitSetDesignator();
            String rhsLimitSetDesignator;
            rhsLimitSetDesignator = that.getLimitSetDesignator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetDesignator", lhsLimitSetDesignator), LocatorUtils.property(thatLocator, "limitSetDesignator", rhsLimitSetDesignator), lhsLimitSetDesignator, rhsLimitSetDesignator)) {
                return false;
            }
        }
        {
            String lhsParameterCode;
            lhsParameterCode = this.getParameterCode();
            String rhsParameterCode;
            rhsParameterCode = that.getParameterCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "parameterCode", lhsParameterCode), LocatorUtils.property(thatLocator, "parameterCode", rhsParameterCode), lhsParameterCode, rhsParameterCode)) {
                return false;
            }
        }
        {
            String lhsMonitoringSiteDescriptionCode;
            lhsMonitoringSiteDescriptionCode = this.getMonitoringSiteDescriptionCode();
            String rhsMonitoringSiteDescriptionCode;
            rhsMonitoringSiteDescriptionCode = that.getMonitoringSiteDescriptionCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "monitoringSiteDescriptionCode", lhsMonitoringSiteDescriptionCode), LocatorUtils.property(thatLocator, "monitoringSiteDescriptionCode", rhsMonitoringSiteDescriptionCode), lhsMonitoringSiteDescriptionCode, rhsMonitoringSiteDescriptionCode)) {
                return false;
            }
        }
        {
            int lhsLimitSeasonNumber;
            lhsLimitSeasonNumber = (this.isSetLimitSeasonNumber()?this.getLimitSeasonNumber(): 0);
            int rhsLimitSeasonNumber;
            rhsLimitSeasonNumber = (that.isSetLimitSeasonNumber()?that.getLimitSeasonNumber(): 0);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSeasonNumber", lhsLimitSeasonNumber), LocatorUtils.property(thatLocator, "limitSeasonNumber", rhsLimitSeasonNumber), lhsLimitSeasonNumber, rhsLimitSeasonNumber)) {
                return false;
            }
        }
        {
            Date lhsLimitStartDate;
            lhsLimitStartDate = this.getLimitStartDate();
            Date rhsLimitStartDate;
            rhsLimitStartDate = that.getLimitStartDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitStartDate", lhsLimitStartDate), LocatorUtils.property(thatLocator, "limitStartDate", rhsLimitStartDate), lhsLimitStartDate, rhsLimitStartDate)) {
                return false;
            }
        }
        {
            Date lhsLimitEndDate;
            lhsLimitEndDate = this.getLimitEndDate();
            Date rhsLimitEndDate;
            rhsLimitEndDate = that.getLimitEndDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitEndDate", lhsLimitEndDate), LocatorUtils.property(thatLocator, "limitEndDate", rhsLimitEndDate), lhsLimitEndDate, rhsLimitEndDate)) {
                return false;
            }
        }
        {
            Date lhsLimitModificationEffectiveDate;
            lhsLimitModificationEffectiveDate = this.getLimitModificationEffectiveDate();
            Date rhsLimitModificationEffectiveDate;
            rhsLimitModificationEffectiveDate = that.getLimitModificationEffectiveDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitModificationEffectiveDate", lhsLimitModificationEffectiveDate), LocatorUtils.property(thatLocator, "limitModificationEffectiveDate", rhsLimitModificationEffectiveDate), lhsLimitModificationEffectiveDate, rhsLimitModificationEffectiveDate)) {
                return false;
            }
        }
        {
            String lhsTradeID;
            lhsTradeID = this.getTradeID();
            String rhsTradeID;
            rhsTradeID = that.getTradeID();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tradeID", lhsTradeID), LocatorUtils.property(thatLocator, "tradeID", rhsTradeID), lhsTradeID, rhsTradeID)) {
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
            String thePermitIdentifier;
            thePermitIdentifier = this.getPermitIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitIdentifier", thePermitIdentifier), currentHashCode, thePermitIdentifier);
        }
        {
            String thePermittedFeatureIdentifier;
            thePermittedFeatureIdentifier = this.getPermittedFeatureIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permittedFeatureIdentifier", thePermittedFeatureIdentifier), currentHashCode, thePermittedFeatureIdentifier);
        }
        {
            String theLimitSetDesignator;
            theLimitSetDesignator = this.getLimitSetDesignator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetDesignator", theLimitSetDesignator), currentHashCode, theLimitSetDesignator);
        }
        {
            String theParameterCode;
            theParameterCode = this.getParameterCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "parameterCode", theParameterCode), currentHashCode, theParameterCode);
        }
        {
            String theMonitoringSiteDescriptionCode;
            theMonitoringSiteDescriptionCode = this.getMonitoringSiteDescriptionCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "monitoringSiteDescriptionCode", theMonitoringSiteDescriptionCode), currentHashCode, theMonitoringSiteDescriptionCode);
        }
        {
            int theLimitSeasonNumber;
            theLimitSeasonNumber = (this.isSetLimitSeasonNumber()?this.getLimitSeasonNumber(): 0);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSeasonNumber", theLimitSeasonNumber), currentHashCode, theLimitSeasonNumber);
        }
        {
            Date theLimitStartDate;
            theLimitStartDate = this.getLimitStartDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitStartDate", theLimitStartDate), currentHashCode, theLimitStartDate);
        }
        {
            Date theLimitEndDate;
            theLimitEndDate = this.getLimitEndDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitEndDate", theLimitEndDate), currentHashCode, theLimitEndDate);
        }
        {
            Date theLimitModificationEffectiveDate;
            theLimitModificationEffectiveDate = this.getLimitModificationEffectiveDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitModificationEffectiveDate", theLimitModificationEffectiveDate), currentHashCode, theLimitModificationEffectiveDate);
        }
        {
            String theTradeID;
            theTradeID = this.getTradeID();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tradeID", theTradeID), currentHashCode, theTradeID);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

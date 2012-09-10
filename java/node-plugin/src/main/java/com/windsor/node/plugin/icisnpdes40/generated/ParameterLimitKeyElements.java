//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSeeAlso;
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
 * <p>Java class for ParameterLimitKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ParameterLimitKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}ParameterLimitKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ParameterLimitKeyElements", propOrder = {
    "permitIdentifier",
    "permittedFeatureIdentifier",
    "limitSetDesignator",
    "parameterCode",
    "monitoringSiteDescriptionCode",
    "limitSeasonNumber"
})
@XmlSeeAlso({
    ParameterLimits.class
})
@MappedSuperclass
public class ParameterLimitKeyElements
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

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof ParameterLimitKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ParameterLimitKeyElements that = ((ParameterLimitKeyElements) object);
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
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

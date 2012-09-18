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
import javax.persistence.Embeddable;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SSOMonthlyEventReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SSOMonthlyEventReport">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}SSOMonthlyEventReportKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SSOMonthlyEventMonth" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SSOMonthlyEventYear" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumberSSOEventsReachUSWatersPerMonth" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}VolumeSSOEventsReachUSWatersPerMonth" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SSOMonthlyEventReport", propOrder = {
    "ssoMonthlyEventMonth",
    "ssoMonthlyEventYear",
    "numberSSOEventsReachUSWatersPerMonth",
    "volumeSSOEventsReachUSWatersPerMonth"
})
@Embeddable
public class SSOMonthlyEventReport
    extends SSOMonthlyEventReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SSOMonthlyEventMonth", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer ssoMonthlyEventMonth;
    @XmlElement(name = "SSOMonthlyEventYear", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer ssoMonthlyEventYear;
    @XmlElement(name = "NumberSSOEventsReachUSWatersPerMonth", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer numberSSOEventsReachUSWatersPerMonth;
    @XmlElement(name = "VolumeSSOEventsReachUSWatersPerMonth", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer volumeSSOEventsReachUSWatersPerMonth;

    /**
     * Gets the value of the ssoMonthlyEventMonth property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SSO_MONTHLY_EVT_MN", scale = 0)
    public Integer getSSOMonthlyEventMonth() {
        return ssoMonthlyEventMonth;
    }

    /**
     * Sets the value of the ssoMonthlyEventMonth property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSSOMonthlyEventMonth(Integer value) {
        this.ssoMonthlyEventMonth = value;
    }

    @Transient
    public boolean isSetSSOMonthlyEventMonth() {
        return (this.ssoMonthlyEventMonth!= null);
    }

    /**
     * Gets the value of the ssoMonthlyEventYear property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SSO_MONTHLY_EVT_YEAR", scale = 0)
    public Integer getSSOMonthlyEventYear() {
        return ssoMonthlyEventYear;
    }

    /**
     * Sets the value of the ssoMonthlyEventYear property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSSOMonthlyEventYear(Integer value) {
        this.ssoMonthlyEventYear = value;
    }

    @Transient
    public boolean isSetSSOMonthlyEventYear() {
        return (this.ssoMonthlyEventYear!= null);
    }

    /**
     * Gets the value of the numberSSOEventsReachUSWatersPerMonth property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_SSO_EVTS_REC_US_WTR_PER_MN", scale = 0)
    public Integer getNumberSSOEventsReachUSWatersPerMonth() {
        return numberSSOEventsReachUSWatersPerMonth;
    }

    /**
     * Sets the value of the numberSSOEventsReachUSWatersPerMonth property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumberSSOEventsReachUSWatersPerMonth(Integer value) {
        this.numberSSOEventsReachUSWatersPerMonth = value;
    }

    @Transient
    public boolean isSetNumberSSOEventsReachUSWatersPerMonth() {
        return (this.numberSSOEventsReachUSWatersPerMonth!= null);
    }

    /**
     * Gets the value of the volumeSSOEventsReachUSWatersPerMonth property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "VOL_SSO_EVTS_REC_US_WTR_PER_MN", scale = 0)
    public Integer getVolumeSSOEventsReachUSWatersPerMonth() {
        return volumeSSOEventsReachUSWatersPerMonth;
    }

    /**
     * Sets the value of the volumeSSOEventsReachUSWatersPerMonth property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVolumeSSOEventsReachUSWatersPerMonth(Integer value) {
        this.volumeSSOEventsReachUSWatersPerMonth = value;
    }

    @Transient
    public boolean isSetVolumeSSOEventsReachUSWatersPerMonth() {
        return (this.volumeSSOEventsReachUSWatersPerMonth!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SSOMonthlyEventReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final SSOMonthlyEventReport that = ((SSOMonthlyEventReport) object);
        {
            Integer lhsSSOMonthlyEventMonth;
            lhsSSOMonthlyEventMonth = this.getSSOMonthlyEventMonth();
            Integer rhsSSOMonthlyEventMonth;
            rhsSSOMonthlyEventMonth = that.getSSOMonthlyEventMonth();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoMonthlyEventMonth", lhsSSOMonthlyEventMonth), LocatorUtils.property(thatLocator, "ssoMonthlyEventMonth", rhsSSOMonthlyEventMonth), lhsSSOMonthlyEventMonth, rhsSSOMonthlyEventMonth)) {
                return false;
            }
        }
        {
            Integer lhsSSOMonthlyEventYear;
            lhsSSOMonthlyEventYear = this.getSSOMonthlyEventYear();
            Integer rhsSSOMonthlyEventYear;
            rhsSSOMonthlyEventYear = that.getSSOMonthlyEventYear();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoMonthlyEventYear", lhsSSOMonthlyEventYear), LocatorUtils.property(thatLocator, "ssoMonthlyEventYear", rhsSSOMonthlyEventYear), lhsSSOMonthlyEventYear, rhsSSOMonthlyEventYear)) {
                return false;
            }
        }
        {
            Integer lhsNumberSSOEventsReachUSWatersPerMonth;
            lhsNumberSSOEventsReachUSWatersPerMonth = this.getNumberSSOEventsReachUSWatersPerMonth();
            Integer rhsNumberSSOEventsReachUSWatersPerMonth;
            rhsNumberSSOEventsReachUSWatersPerMonth = that.getNumberSSOEventsReachUSWatersPerMonth();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numberSSOEventsReachUSWatersPerMonth", lhsNumberSSOEventsReachUSWatersPerMonth), LocatorUtils.property(thatLocator, "numberSSOEventsReachUSWatersPerMonth", rhsNumberSSOEventsReachUSWatersPerMonth), lhsNumberSSOEventsReachUSWatersPerMonth, rhsNumberSSOEventsReachUSWatersPerMonth)) {
                return false;
            }
        }
        {
            Integer lhsVolumeSSOEventsReachUSWatersPerMonth;
            lhsVolumeSSOEventsReachUSWatersPerMonth = this.getVolumeSSOEventsReachUSWatersPerMonth();
            Integer rhsVolumeSSOEventsReachUSWatersPerMonth;
            rhsVolumeSSOEventsReachUSWatersPerMonth = that.getVolumeSSOEventsReachUSWatersPerMonth();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "volumeSSOEventsReachUSWatersPerMonth", lhsVolumeSSOEventsReachUSWatersPerMonth), LocatorUtils.property(thatLocator, "volumeSSOEventsReachUSWatersPerMonth", rhsVolumeSSOEventsReachUSWatersPerMonth), lhsVolumeSSOEventsReachUSWatersPerMonth, rhsVolumeSSOEventsReachUSWatersPerMonth)) {
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
        int currentHashCode = super.hashCode(locator, strategy);
        {
            Integer theSSOMonthlyEventMonth;
            theSSOMonthlyEventMonth = this.getSSOMonthlyEventMonth();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoMonthlyEventMonth", theSSOMonthlyEventMonth), currentHashCode, theSSOMonthlyEventMonth);
        }
        {
            Integer theSSOMonthlyEventYear;
            theSSOMonthlyEventYear = this.getSSOMonthlyEventYear();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoMonthlyEventYear", theSSOMonthlyEventYear), currentHashCode, theSSOMonthlyEventYear);
        }
        {
            Integer theNumberSSOEventsReachUSWatersPerMonth;
            theNumberSSOEventsReachUSWatersPerMonth = this.getNumberSSOEventsReachUSWatersPerMonth();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numberSSOEventsReachUSWatersPerMonth", theNumberSSOEventsReachUSWatersPerMonth), currentHashCode, theNumberSSOEventsReachUSWatersPerMonth);
        }
        {
            Integer theVolumeSSOEventsReachUSWatersPerMonth;
            theVolumeSSOEventsReachUSWatersPerMonth = this.getVolumeSSOEventsReachUSWatersPerMonth();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "volumeSSOEventsReachUSWatersPerMonth", theVolumeSSOEventsReachUSWatersPerMonth), currentHashCode, theVolumeSSOEventsReachUSWatersPerMonth);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

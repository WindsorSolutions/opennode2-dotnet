//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.03 at 08:17:26 AM PDT 
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
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SSOAnnualReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SSOAnnualReport">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}SSOAnnualReportKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SSOAnnualReportYear" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumberSSOEventsPerYear" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}VolumeSSOEventsPerYear" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SSOAnnualReport", propOrder = {
    "ssoAnnualReportYear",
    "numberSSOEventsPerYear",
    "volumeSSOEventsPerYear"
})
@Embeddable
public class SSOAnnualReport
    extends SSOAnnualReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SSOAnnualReportYear", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer ssoAnnualReportYear;
    @XmlElement(name = "NumberSSOEventsPerYear", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer numberSSOEventsPerYear;
    @XmlElement(name = "VolumeSSOEventsPerYear", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer volumeSSOEventsPerYear;

    /**
     * Gets the value of the ssoAnnualReportYear property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SSO_ANNUL_REP_YEAR", scale = 0)
    public Integer getSSOAnnualReportYear() {
        return ssoAnnualReportYear;
    }

    /**
     * Sets the value of the ssoAnnualReportYear property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSSOAnnualReportYear(Integer value) {
        this.ssoAnnualReportYear = value;
    }

    @Transient
    public boolean isSetSSOAnnualReportYear() {
        return (this.ssoAnnualReportYear!= null);
    }

    /**
     * Gets the value of the numberSSOEventsPerYear property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "NUM_SSO_EVTS_PER_YEAR", scale = 0)
    public Integer getNumberSSOEventsPerYear() {
        return numberSSOEventsPerYear;
    }

    /**
     * Sets the value of the numberSSOEventsPerYear property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNumberSSOEventsPerYear(Integer value) {
        this.numberSSOEventsPerYear = value;
    }

    @Transient
    public boolean isSetNumberSSOEventsPerYear() {
        return (this.numberSSOEventsPerYear!= null);
    }

    /**
     * Gets the value of the volumeSSOEventsPerYear property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "VOL_SSO_EVTS_PER_YEAR", scale = 0)
    public Integer getVolumeSSOEventsPerYear() {
        return volumeSSOEventsPerYear;
    }

    /**
     * Sets the value of the volumeSSOEventsPerYear property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVolumeSSOEventsPerYear(Integer value) {
        this.volumeSSOEventsPerYear = value;
    }

    @Transient
    public boolean isSetVolumeSSOEventsPerYear() {
        return (this.volumeSSOEventsPerYear!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SSOAnnualReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final SSOAnnualReport that = ((SSOAnnualReport) object);
        {
            Integer lhsSSOAnnualReportYear;
            lhsSSOAnnualReportYear = this.getSSOAnnualReportYear();
            Integer rhsSSOAnnualReportYear;
            rhsSSOAnnualReportYear = that.getSSOAnnualReportYear();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoAnnualReportYear", lhsSSOAnnualReportYear), LocatorUtils.property(thatLocator, "ssoAnnualReportYear", rhsSSOAnnualReportYear), lhsSSOAnnualReportYear, rhsSSOAnnualReportYear)) {
                return false;
            }
        }
        {
            Integer lhsNumberSSOEventsPerYear;
            lhsNumberSSOEventsPerYear = this.getNumberSSOEventsPerYear();
            Integer rhsNumberSSOEventsPerYear;
            rhsNumberSSOEventsPerYear = that.getNumberSSOEventsPerYear();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numberSSOEventsPerYear", lhsNumberSSOEventsPerYear), LocatorUtils.property(thatLocator, "numberSSOEventsPerYear", rhsNumberSSOEventsPerYear), lhsNumberSSOEventsPerYear, rhsNumberSSOEventsPerYear)) {
                return false;
            }
        }
        {
            Integer lhsVolumeSSOEventsPerYear;
            lhsVolumeSSOEventsPerYear = this.getVolumeSSOEventsPerYear();
            Integer rhsVolumeSSOEventsPerYear;
            rhsVolumeSSOEventsPerYear = that.getVolumeSSOEventsPerYear();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "volumeSSOEventsPerYear", lhsVolumeSSOEventsPerYear), LocatorUtils.property(thatLocator, "volumeSSOEventsPerYear", rhsVolumeSSOEventsPerYear), lhsVolumeSSOEventsPerYear, rhsVolumeSSOEventsPerYear)) {
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
            Integer theSSOAnnualReportYear;
            theSSOAnnualReportYear = this.getSSOAnnualReportYear();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoAnnualReportYear", theSSOAnnualReportYear), currentHashCode, theSSOAnnualReportYear);
        }
        {
            Integer theNumberSSOEventsPerYear;
            theNumberSSOEventsPerYear = this.getNumberSSOEventsPerYear();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numberSSOEventsPerYear", theNumberSSOEventsPerYear), currentHashCode, theNumberSSOEventsPerYear);
        }
        {
            Integer theVolumeSSOEventsPerYear;
            theVolumeSSOEventsPerYear = this.getVolumeSSOEventsPerYear();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "volumeSSOEventsPerYear", theVolumeSSOEventsPerYear), currentHashCode, theVolumeSSOEventsPerYear);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

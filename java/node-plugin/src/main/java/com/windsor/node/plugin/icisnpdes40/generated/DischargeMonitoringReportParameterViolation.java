//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import com.windsor.node.plugin.icisnpdes40.domain.AbstractEnhancedDischargeMonitoringReportKeyElements;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for DischargeMonitoringReportParameterViolation complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="DischargeMonitoringReportParameterViolation">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}DischargeMonitoringReportKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ParameterCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}MonitoringSiteDescriptionCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LimitSeasonNumber"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "DischargeMonitoringReportParameterViolation", propOrder = {
    "parameterCode",
    "monitoringSiteDescriptionCode",
    "limitSeasonNumber"
})
@Entity(name = "DischargeMonitoringReportParameterViolation")
@Table(name = "ICS_DSCH_MON_REP_PARAM_VIOL")
@Inheritance(strategy = InheritanceType.JOINED)
public class DischargeMonitoringReportParameterViolation
    extends AbstractEnhancedDischargeMonitoringReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ParameterCode", required = true)
    protected String parameterCode;
    @XmlElement(name = "MonitoringSiteDescriptionCode", required = true)
    protected String monitoringSiteDescriptionCode;
    @XmlElement(name = "LimitSeasonNumber")
    protected int limitSeasonNumber;
    @XmlTransient
    protected String dbid;

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
     * 
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Id
    @Column(name = "ICS_DSCH_MON_REP_PARAM_VIOL_ID")
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
        if (!(object instanceof DischargeMonitoringReportParameterViolation)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final DischargeMonitoringReportParameterViolation that = ((DischargeMonitoringReportParameterViolation) object);
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
        int currentHashCode = super.hashCode(locator, strategy);
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

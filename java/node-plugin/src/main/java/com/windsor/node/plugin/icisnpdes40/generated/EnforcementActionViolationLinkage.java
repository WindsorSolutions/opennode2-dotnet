//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.CascadeType;
import javax.persistence.Embeddable;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
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
 * <p>Java class for EnforcementActionViolationLinkage complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="EnforcementActionViolationLinkage">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}EnforcementActionKeyElements">
 *       &lt;choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleViolation"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ComplianceScheduleViolation"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DischargeMonitoringReportViolation"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DischargeMonitoringReportParameterViolation"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SingleEventsViolation"/>
 *       &lt;/choice>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "EnforcementActionViolationLinkage", propOrder = {
    "permitScheduleViolation",
    "complianceScheduleViolation",
    "dischargeMonitoringReportViolation",
    "dischargeMonitoringReportParameterViolation",
    "singleEventsViolation"
})
@Embeddable
public class EnforcementActionViolationLinkage
    extends EnforcementActionKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitScheduleViolation")
    protected PermitScheduleViolation permitScheduleViolation;
    @XmlElement(name = "ComplianceScheduleViolation")
    protected ComplianceScheduleViolation complianceScheduleViolation;
    @XmlElement(name = "DischargeMonitoringReportViolation")
    protected DischargeMonitoringReportViolation dischargeMonitoringReportViolation;
    @XmlElement(name = "DischargeMonitoringReportParameterViolation")
    protected DischargeMonitoringReportParameterViolation dischargeMonitoringReportParameterViolation;
    @XmlElement(name = "SingleEventsViolation")
    protected SingleEventsViolation singleEventsViolation;

    /**
     * Gets the value of the permitScheduleViolation property.
     * 
     * @return
     *     possible object is
     *     {@link PermitScheduleViolation }
     *     
     */
    @OneToOne(targetEntity = PermitScheduleViolation.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_ENFRC_ACTN_VIOL_LNK_ID")
    public PermitScheduleViolation getPermitScheduleViolation() {
        return permitScheduleViolation;
    }

    /**
     * Sets the value of the permitScheduleViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link PermitScheduleViolation }
     *     
     */
    public void setPermitScheduleViolation(PermitScheduleViolation value) {
        this.permitScheduleViolation = value;
    }

    @Transient
    public boolean isSetPermitScheduleViolation() {
        return (this.permitScheduleViolation!= null);
    }

    /**
     * Gets the value of the complianceScheduleViolation property.
     * 
     * @return
     *     possible object is
     *     {@link ComplianceScheduleViolation }
     *     
     */
    @OneToOne(targetEntity = ComplianceScheduleViolation.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_ENFRC_ACTN_VIOL_LNK_ID")
    public ComplianceScheduleViolation getComplianceScheduleViolation() {
        return complianceScheduleViolation;
    }

    /**
     * Sets the value of the complianceScheduleViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link ComplianceScheduleViolation }
     *     
     */
    public void setComplianceScheduleViolation(ComplianceScheduleViolation value) {
        this.complianceScheduleViolation = value;
    }

    @Transient
    public boolean isSetComplianceScheduleViolation() {
        return (this.complianceScheduleViolation!= null);
    }

    /**
     * Gets the value of the dischargeMonitoringReportViolation property.
     * 
     * @return
     *     possible object is
     *     {@link DischargeMonitoringReportViolation }
     *     
     */
    @OneToOne(targetEntity = DischargeMonitoringReportViolation.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_ENFRC_ACTN_VIOL_LNK_ID")
    public DischargeMonitoringReportViolation getDischargeMonitoringReportViolation() {
        return dischargeMonitoringReportViolation;
    }

    /**
     * Sets the value of the dischargeMonitoringReportViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link DischargeMonitoringReportViolation }
     *     
     */
    public void setDischargeMonitoringReportViolation(DischargeMonitoringReportViolation value) {
        this.dischargeMonitoringReportViolation = value;
    }

    @Transient
    public boolean isSetDischargeMonitoringReportViolation() {
        return (this.dischargeMonitoringReportViolation!= null);
    }

    /**
     * Gets the value of the dischargeMonitoringReportParameterViolation property.
     * 
     * @return
     *     possible object is
     *     {@link DischargeMonitoringReportParameterViolation }
     *     
     */
    @OneToOne(targetEntity = DischargeMonitoringReportParameterViolation.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_ENFRC_ACTN_VIOL_LNK_ID")
    public DischargeMonitoringReportParameterViolation getDischargeMonitoringReportParameterViolation() {
        return dischargeMonitoringReportParameterViolation;
    }

    /**
     * Sets the value of the dischargeMonitoringReportParameterViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link DischargeMonitoringReportParameterViolation }
     *     
     */
    public void setDischargeMonitoringReportParameterViolation(DischargeMonitoringReportParameterViolation value) {
        this.dischargeMonitoringReportParameterViolation = value;
    }

    @Transient
    public boolean isSetDischargeMonitoringReportParameterViolation() {
        return (this.dischargeMonitoringReportParameterViolation!= null);
    }

    /**
     * Gets the value of the singleEventsViolation property.
     * 
     * @return
     *     possible object is
     *     {@link SingleEventsViolation }
     *     
     */
    @OneToOne(targetEntity = SingleEventsViolation.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_ENFRC_ACTN_VIOL_LNK_ID")
    public SingleEventsViolation getSingleEventsViolation() {
        return singleEventsViolation;
    }

    /**
     * Sets the value of the singleEventsViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link SingleEventsViolation }
     *     
     */
    public void setSingleEventsViolation(SingleEventsViolation value) {
        this.singleEventsViolation = value;
    }

    @Transient
    public boolean isSetSingleEventsViolation() {
        return (this.singleEventsViolation!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof EnforcementActionViolationLinkage)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final EnforcementActionViolationLinkage that = ((EnforcementActionViolationLinkage) object);
        {
            PermitScheduleViolation lhsPermitScheduleViolation;
            lhsPermitScheduleViolation = this.getPermitScheduleViolation();
            PermitScheduleViolation rhsPermitScheduleViolation;
            rhsPermitScheduleViolation = that.getPermitScheduleViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitScheduleViolation", lhsPermitScheduleViolation), LocatorUtils.property(thatLocator, "permitScheduleViolation", rhsPermitScheduleViolation), lhsPermitScheduleViolation, rhsPermitScheduleViolation)) {
                return false;
            }
        }
        {
            ComplianceScheduleViolation lhsComplianceScheduleViolation;
            lhsComplianceScheduleViolation = this.getComplianceScheduleViolation();
            ComplianceScheduleViolation rhsComplianceScheduleViolation;
            rhsComplianceScheduleViolation = that.getComplianceScheduleViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "complianceScheduleViolation", lhsComplianceScheduleViolation), LocatorUtils.property(thatLocator, "complianceScheduleViolation", rhsComplianceScheduleViolation), lhsComplianceScheduleViolation, rhsComplianceScheduleViolation)) {
                return false;
            }
        }
        {
            DischargeMonitoringReportViolation lhsDischargeMonitoringReportViolation;
            lhsDischargeMonitoringReportViolation = this.getDischargeMonitoringReportViolation();
            DischargeMonitoringReportViolation rhsDischargeMonitoringReportViolation;
            rhsDischargeMonitoringReportViolation = that.getDischargeMonitoringReportViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dischargeMonitoringReportViolation", lhsDischargeMonitoringReportViolation), LocatorUtils.property(thatLocator, "dischargeMonitoringReportViolation", rhsDischargeMonitoringReportViolation), lhsDischargeMonitoringReportViolation, rhsDischargeMonitoringReportViolation)) {
                return false;
            }
        }
        {
            DischargeMonitoringReportParameterViolation lhsDischargeMonitoringReportParameterViolation;
            lhsDischargeMonitoringReportParameterViolation = this.getDischargeMonitoringReportParameterViolation();
            DischargeMonitoringReportParameterViolation rhsDischargeMonitoringReportParameterViolation;
            rhsDischargeMonitoringReportParameterViolation = that.getDischargeMonitoringReportParameterViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dischargeMonitoringReportParameterViolation", lhsDischargeMonitoringReportParameterViolation), LocatorUtils.property(thatLocator, "dischargeMonitoringReportParameterViolation", rhsDischargeMonitoringReportParameterViolation), lhsDischargeMonitoringReportParameterViolation, rhsDischargeMonitoringReportParameterViolation)) {
                return false;
            }
        }
        {
            SingleEventsViolation lhsSingleEventsViolation;
            lhsSingleEventsViolation = this.getSingleEventsViolation();
            SingleEventsViolation rhsSingleEventsViolation;
            rhsSingleEventsViolation = that.getSingleEventsViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "singleEventsViolation", lhsSingleEventsViolation), LocatorUtils.property(thatLocator, "singleEventsViolation", rhsSingleEventsViolation), lhsSingleEventsViolation, rhsSingleEventsViolation)) {
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
            PermitScheduleViolation thePermitScheduleViolation;
            thePermitScheduleViolation = this.getPermitScheduleViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitScheduleViolation", thePermitScheduleViolation), currentHashCode, thePermitScheduleViolation);
        }
        {
            ComplianceScheduleViolation theComplianceScheduleViolation;
            theComplianceScheduleViolation = this.getComplianceScheduleViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "complianceScheduleViolation", theComplianceScheduleViolation), currentHashCode, theComplianceScheduleViolation);
        }
        {
            DischargeMonitoringReportViolation theDischargeMonitoringReportViolation;
            theDischargeMonitoringReportViolation = this.getDischargeMonitoringReportViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dischargeMonitoringReportViolation", theDischargeMonitoringReportViolation), currentHashCode, theDischargeMonitoringReportViolation);
        }
        {
            DischargeMonitoringReportParameterViolation theDischargeMonitoringReportParameterViolation;
            theDischargeMonitoringReportParameterViolation = this.getDischargeMonitoringReportParameterViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dischargeMonitoringReportParameterViolation", theDischargeMonitoringReportParameterViolation), currentHashCode, theDischargeMonitoringReportParameterViolation);
        }
        {
            SingleEventsViolation theSingleEventsViolation;
            theSingleEventsViolation = this.getSingleEventsViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "singleEventsViolation", theSingleEventsViolation), currentHashCode, theSingleEventsViolation);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

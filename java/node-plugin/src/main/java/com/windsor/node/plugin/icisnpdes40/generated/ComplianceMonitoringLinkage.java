//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.03 at 05:58:07 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.CascadeType;
import javax.persistence.Embeddable;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
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
 * <p>Java class for ComplianceMonitoringLinkage complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ComplianceMonitoringLinkage">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}ComplianceMonitoringKeyElements">
 *       &lt;choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSingleEvent"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageEnforcementAction"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageBiosolidsReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageCAFOAnnualReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageCSOEventReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageLocalLimitsReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkagePretreatmentPerformanceReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSSOAnnualReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSSOEventReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSSOMonthlyEventReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSWEventReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSWMS4Report"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageStateComplianceMonitoring"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageFederalComplianceMonitoring"/>
 *       &lt;/choice>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ComplianceMonitoringLinkage", propOrder = {
    "linkageSingleEvent",
    "linkageEnforcementAction",
    "linkageBiosolidsReport",
    "linkageCAFOAnnualReport",
    "linkageCSOEventReport",
    "linkageLocalLimitsReport",
    "linkagePretreatmentPerformanceReport",
    "linkageSSOAnnualReport",
    "linkageSSOEventReport",
    "linkageSSOMonthlyEventReport",
    "linkageSWEventReport",
    "linkageSWMS4Report",
    "linkageStateComplianceMonitoring",
    "linkageFederalComplianceMonitoring"
})
@Embeddable
public class ComplianceMonitoringLinkage
    extends ComplianceMonitoringKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "LinkageSingleEvent")
    protected LinkageSingleEvent linkageSingleEvent;
    @XmlElement(name = "LinkageEnforcementAction")
    protected LinkageEnforcementAction linkageEnforcementAction;
    @XmlElement(name = "LinkageBiosolidsReport")
    protected LinkageBiosolidsReport linkageBiosolidsReport;
    @XmlElement(name = "LinkageCAFOAnnualReport")
    protected LinkageCAFOAnnualReport linkageCAFOAnnualReport;
    @XmlElement(name = "LinkageCSOEventReport")
    protected LinkageCSOEventReport linkageCSOEventReport;
    @XmlElement(name = "LinkageLocalLimitsReport")
    protected LinkageLocalLimitsReport linkageLocalLimitsReport;
    @XmlElement(name = "LinkagePretreatmentPerformanceReport")
    protected LinkagePretreatmentPerformanceReport linkagePretreatmentPerformanceReport;
    @XmlElement(name = "LinkageSSOAnnualReport")
    protected LinkageSSOAnnualReport linkageSSOAnnualReport;
    @XmlElement(name = "LinkageSSOEventReport")
    protected LinkageSSOEventReport linkageSSOEventReport;
    @XmlElement(name = "LinkageSSOMonthlyEventReport")
    protected LinkageSSOMonthlyEventReport linkageSSOMonthlyEventReport;
    @XmlElement(name = "LinkageSWEventReport")
    protected LinkageSWEventReport linkageSWEventReport;
    @XmlElement(name = "LinkageSWMS4Report")
    protected LinkageSWMS4Report linkageSWMS4Report;
    @XmlElement(name = "LinkageStateComplianceMonitoring")
    protected LinkageStateComplianceMonitoring linkageStateComplianceMonitoring;
    @XmlElement(name = "LinkageFederalComplianceMonitoring")
    protected LinkageFederalComplianceMonitoring linkageFederalComplianceMonitoring;

    /**
     * Gets the value of the linkageSingleEvent property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSingleEvent }
     *     
     */
    @ManyToOne(targetEntity = LinkageSingleEvent.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSingleEvent getLinkageSingleEvent() {
        return linkageSingleEvent;
    }

    /**
     * Sets the value of the linkageSingleEvent property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSingleEvent }
     *     
     */
    public void setLinkageSingleEvent(LinkageSingleEvent value) {
        this.linkageSingleEvent = value;
    }

    @Transient
    public boolean isSetLinkageSingleEvent() {
        return (this.linkageSingleEvent!= null);
    }

    /**
     * Gets the value of the linkageEnforcementAction property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageEnforcementAction }
     *     
     */
    @ManyToOne(targetEntity = LinkageEnforcementAction.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageEnforcementAction getLinkageEnforcementAction() {
        return linkageEnforcementAction;
    }

    /**
     * Sets the value of the linkageEnforcementAction property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageEnforcementAction }
     *     
     */
    public void setLinkageEnforcementAction(LinkageEnforcementAction value) {
        this.linkageEnforcementAction = value;
    }

    @Transient
    public boolean isSetLinkageEnforcementAction() {
        return (this.linkageEnforcementAction!= null);
    }

    /**
     * Gets the value of the linkageBiosolidsReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageBiosolidsReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageBiosolidsReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageBiosolidsReport getLinkageBiosolidsReport() {
        return linkageBiosolidsReport;
    }

    /**
     * Sets the value of the linkageBiosolidsReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageBiosolidsReport }
     *     
     */
    public void setLinkageBiosolidsReport(LinkageBiosolidsReport value) {
        this.linkageBiosolidsReport = value;
    }

    @Transient
    public boolean isSetLinkageBiosolidsReport() {
        return (this.linkageBiosolidsReport!= null);
    }

    /**
     * Gets the value of the linkageCAFOAnnualReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageCAFOAnnualReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageCAFOAnnualReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageCAFOAnnualReport getLinkageCAFOAnnualReport() {
        return linkageCAFOAnnualReport;
    }

    /**
     * Sets the value of the linkageCAFOAnnualReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageCAFOAnnualReport }
     *     
     */
    public void setLinkageCAFOAnnualReport(LinkageCAFOAnnualReport value) {
        this.linkageCAFOAnnualReport = value;
    }

    @Transient
    public boolean isSetLinkageCAFOAnnualReport() {
        return (this.linkageCAFOAnnualReport!= null);
    }

    /**
     * Gets the value of the linkageCSOEventReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageCSOEventReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageCSOEventReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageCSOEventReport getLinkageCSOEventReport() {
        return linkageCSOEventReport;
    }

    /**
     * Sets the value of the linkageCSOEventReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageCSOEventReport }
     *     
     */
    public void setLinkageCSOEventReport(LinkageCSOEventReport value) {
        this.linkageCSOEventReport = value;
    }

    @Transient
    public boolean isSetLinkageCSOEventReport() {
        return (this.linkageCSOEventReport!= null);
    }

    /**
     * Gets the value of the linkageLocalLimitsReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageLocalLimitsReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageLocalLimitsReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageLocalLimitsReport getLinkageLocalLimitsReport() {
        return linkageLocalLimitsReport;
    }

    /**
     * Sets the value of the linkageLocalLimitsReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageLocalLimitsReport }
     *     
     */
    public void setLinkageLocalLimitsReport(LinkageLocalLimitsReport value) {
        this.linkageLocalLimitsReport = value;
    }

    @Transient
    public boolean isSetLinkageLocalLimitsReport() {
        return (this.linkageLocalLimitsReport!= null);
    }

    /**
     * Gets the value of the linkagePretreatmentPerformanceReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkagePretreatmentPerformanceReport }
     *     
     */
    @ManyToOne(targetEntity = LinkagePretreatmentPerformanceReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkagePretreatmentPerformanceReport getLinkagePretreatmentPerformanceReport() {
        return linkagePretreatmentPerformanceReport;
    }

    /**
     * Sets the value of the linkagePretreatmentPerformanceReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkagePretreatmentPerformanceReport }
     *     
     */
    public void setLinkagePretreatmentPerformanceReport(LinkagePretreatmentPerformanceReport value) {
        this.linkagePretreatmentPerformanceReport = value;
    }

    @Transient
    public boolean isSetLinkagePretreatmentPerformanceReport() {
        return (this.linkagePretreatmentPerformanceReport!= null);
    }

    /**
     * Gets the value of the linkageSSOAnnualReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSSOAnnualReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageSSOAnnualReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSSOAnnualReport getLinkageSSOAnnualReport() {
        return linkageSSOAnnualReport;
    }

    /**
     * Sets the value of the linkageSSOAnnualReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSSOAnnualReport }
     *     
     */
    public void setLinkageSSOAnnualReport(LinkageSSOAnnualReport value) {
        this.linkageSSOAnnualReport = value;
    }

    @Transient
    public boolean isSetLinkageSSOAnnualReport() {
        return (this.linkageSSOAnnualReport!= null);
    }

    /**
     * Gets the value of the linkageSSOEventReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSSOEventReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageSSOEventReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSSOEventReport getLinkageSSOEventReport() {
        return linkageSSOEventReport;
    }

    /**
     * Sets the value of the linkageSSOEventReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSSOEventReport }
     *     
     */
    public void setLinkageSSOEventReport(LinkageSSOEventReport value) {
        this.linkageSSOEventReport = value;
    }

    @Transient
    public boolean isSetLinkageSSOEventReport() {
        return (this.linkageSSOEventReport!= null);
    }

    /**
     * Gets the value of the linkageSSOMonthlyEventReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSSOMonthlyEventReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageSSOMonthlyEventReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSSOMonthlyEventReport getLinkageSSOMonthlyEventReport() {
        return linkageSSOMonthlyEventReport;
    }

    /**
     * Sets the value of the linkageSSOMonthlyEventReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSSOMonthlyEventReport }
     *     
     */
    public void setLinkageSSOMonthlyEventReport(LinkageSSOMonthlyEventReport value) {
        this.linkageSSOMonthlyEventReport = value;
    }

    @Transient
    public boolean isSetLinkageSSOMonthlyEventReport() {
        return (this.linkageSSOMonthlyEventReport!= null);
    }

    /**
     * Gets the value of the linkageSWEventReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSWEventReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageSWEventReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSWEventReport getLinkageSWEventReport() {
        return linkageSWEventReport;
    }

    /**
     * Sets the value of the linkageSWEventReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSWEventReport }
     *     
     */
    public void setLinkageSWEventReport(LinkageSWEventReport value) {
        this.linkageSWEventReport = value;
    }

    @Transient
    public boolean isSetLinkageSWEventReport() {
        return (this.linkageSWEventReport!= null);
    }

    /**
     * Gets the value of the linkageSWMS4Report property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSWMS4Report }
     *     
     */
    @ManyToOne(targetEntity = LinkageSWMS4Report.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageSWMS4Report getLinkageSWMS4Report() {
        return linkageSWMS4Report;
    }

    /**
     * Sets the value of the linkageSWMS4Report property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSWMS4Report }
     *     
     */
    public void setLinkageSWMS4Report(LinkageSWMS4Report value) {
        this.linkageSWMS4Report = value;
    }

    @Transient
    public boolean isSetLinkageSWMS4Report() {
        return (this.linkageSWMS4Report!= null);
    }

    /**
     * Gets the value of the linkageStateComplianceMonitoring property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageStateComplianceMonitoring }
     *     
     */
    @ManyToOne(targetEntity = LinkageStateComplianceMonitoring.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageStateComplianceMonitoring getLinkageStateComplianceMonitoring() {
        return linkageStateComplianceMonitoring;
    }

    /**
     * Sets the value of the linkageStateComplianceMonitoring property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageStateComplianceMonitoring }
     *     
     */
    public void setLinkageStateComplianceMonitoring(LinkageStateComplianceMonitoring value) {
        this.linkageStateComplianceMonitoring = value;
    }

    @Transient
    public boolean isSetLinkageStateComplianceMonitoring() {
        return (this.linkageStateComplianceMonitoring!= null);
    }

    /**
     * Gets the value of the linkageFederalComplianceMonitoring property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageFederalComplianceMonitoring }
     *     
     */
    @ManyToOne(targetEntity = LinkageFederalComplianceMonitoring.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_CMPL_MON_LNK_ID", insertable = false, updatable = false)
    public LinkageFederalComplianceMonitoring getLinkageFederalComplianceMonitoring() {
        return linkageFederalComplianceMonitoring;
    }

    /**
     * Sets the value of the linkageFederalComplianceMonitoring property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageFederalComplianceMonitoring }
     *     
     */
    public void setLinkageFederalComplianceMonitoring(LinkageFederalComplianceMonitoring value) {
        this.linkageFederalComplianceMonitoring = value;
    }

    @Transient
    public boolean isSetLinkageFederalComplianceMonitoring() {
        return (this.linkageFederalComplianceMonitoring!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof ComplianceMonitoringLinkage)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final ComplianceMonitoringLinkage that = ((ComplianceMonitoringLinkage) object);
        {
            LinkageSingleEvent lhsLinkageSingleEvent;
            lhsLinkageSingleEvent = this.getLinkageSingleEvent();
            LinkageSingleEvent rhsLinkageSingleEvent;
            rhsLinkageSingleEvent = that.getLinkageSingleEvent();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSingleEvent", lhsLinkageSingleEvent), LocatorUtils.property(thatLocator, "linkageSingleEvent", rhsLinkageSingleEvent), lhsLinkageSingleEvent, rhsLinkageSingleEvent)) {
                return false;
            }
        }
        {
            LinkageEnforcementAction lhsLinkageEnforcementAction;
            lhsLinkageEnforcementAction = this.getLinkageEnforcementAction();
            LinkageEnforcementAction rhsLinkageEnforcementAction;
            rhsLinkageEnforcementAction = that.getLinkageEnforcementAction();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageEnforcementAction", lhsLinkageEnforcementAction), LocatorUtils.property(thatLocator, "linkageEnforcementAction", rhsLinkageEnforcementAction), lhsLinkageEnforcementAction, rhsLinkageEnforcementAction)) {
                return false;
            }
        }
        {
            LinkageBiosolidsReport lhsLinkageBiosolidsReport;
            lhsLinkageBiosolidsReport = this.getLinkageBiosolidsReport();
            LinkageBiosolidsReport rhsLinkageBiosolidsReport;
            rhsLinkageBiosolidsReport = that.getLinkageBiosolidsReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageBiosolidsReport", lhsLinkageBiosolidsReport), LocatorUtils.property(thatLocator, "linkageBiosolidsReport", rhsLinkageBiosolidsReport), lhsLinkageBiosolidsReport, rhsLinkageBiosolidsReport)) {
                return false;
            }
        }
        {
            LinkageCAFOAnnualReport lhsLinkageCAFOAnnualReport;
            lhsLinkageCAFOAnnualReport = this.getLinkageCAFOAnnualReport();
            LinkageCAFOAnnualReport rhsLinkageCAFOAnnualReport;
            rhsLinkageCAFOAnnualReport = that.getLinkageCAFOAnnualReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageCAFOAnnualReport", lhsLinkageCAFOAnnualReport), LocatorUtils.property(thatLocator, "linkageCAFOAnnualReport", rhsLinkageCAFOAnnualReport), lhsLinkageCAFOAnnualReport, rhsLinkageCAFOAnnualReport)) {
                return false;
            }
        }
        {
            LinkageCSOEventReport lhsLinkageCSOEventReport;
            lhsLinkageCSOEventReport = this.getLinkageCSOEventReport();
            LinkageCSOEventReport rhsLinkageCSOEventReport;
            rhsLinkageCSOEventReport = that.getLinkageCSOEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageCSOEventReport", lhsLinkageCSOEventReport), LocatorUtils.property(thatLocator, "linkageCSOEventReport", rhsLinkageCSOEventReport), lhsLinkageCSOEventReport, rhsLinkageCSOEventReport)) {
                return false;
            }
        }
        {
            LinkageLocalLimitsReport lhsLinkageLocalLimitsReport;
            lhsLinkageLocalLimitsReport = this.getLinkageLocalLimitsReport();
            LinkageLocalLimitsReport rhsLinkageLocalLimitsReport;
            rhsLinkageLocalLimitsReport = that.getLinkageLocalLimitsReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageLocalLimitsReport", lhsLinkageLocalLimitsReport), LocatorUtils.property(thatLocator, "linkageLocalLimitsReport", rhsLinkageLocalLimitsReport), lhsLinkageLocalLimitsReport, rhsLinkageLocalLimitsReport)) {
                return false;
            }
        }
        {
            LinkagePretreatmentPerformanceReport lhsLinkagePretreatmentPerformanceReport;
            lhsLinkagePretreatmentPerformanceReport = this.getLinkagePretreatmentPerformanceReport();
            LinkagePretreatmentPerformanceReport rhsLinkagePretreatmentPerformanceReport;
            rhsLinkagePretreatmentPerformanceReport = that.getLinkagePretreatmentPerformanceReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkagePretreatmentPerformanceReport", lhsLinkagePretreatmentPerformanceReport), LocatorUtils.property(thatLocator, "linkagePretreatmentPerformanceReport", rhsLinkagePretreatmentPerformanceReport), lhsLinkagePretreatmentPerformanceReport, rhsLinkagePretreatmentPerformanceReport)) {
                return false;
            }
        }
        {
            LinkageSSOAnnualReport lhsLinkageSSOAnnualReport;
            lhsLinkageSSOAnnualReport = this.getLinkageSSOAnnualReport();
            LinkageSSOAnnualReport rhsLinkageSSOAnnualReport;
            rhsLinkageSSOAnnualReport = that.getLinkageSSOAnnualReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSSOAnnualReport", lhsLinkageSSOAnnualReport), LocatorUtils.property(thatLocator, "linkageSSOAnnualReport", rhsLinkageSSOAnnualReport), lhsLinkageSSOAnnualReport, rhsLinkageSSOAnnualReport)) {
                return false;
            }
        }
        {
            LinkageSSOEventReport lhsLinkageSSOEventReport;
            lhsLinkageSSOEventReport = this.getLinkageSSOEventReport();
            LinkageSSOEventReport rhsLinkageSSOEventReport;
            rhsLinkageSSOEventReport = that.getLinkageSSOEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSSOEventReport", lhsLinkageSSOEventReport), LocatorUtils.property(thatLocator, "linkageSSOEventReport", rhsLinkageSSOEventReport), lhsLinkageSSOEventReport, rhsLinkageSSOEventReport)) {
                return false;
            }
        }
        {
            LinkageSSOMonthlyEventReport lhsLinkageSSOMonthlyEventReport;
            lhsLinkageSSOMonthlyEventReport = this.getLinkageSSOMonthlyEventReport();
            LinkageSSOMonthlyEventReport rhsLinkageSSOMonthlyEventReport;
            rhsLinkageSSOMonthlyEventReport = that.getLinkageSSOMonthlyEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSSOMonthlyEventReport", lhsLinkageSSOMonthlyEventReport), LocatorUtils.property(thatLocator, "linkageSSOMonthlyEventReport", rhsLinkageSSOMonthlyEventReport), lhsLinkageSSOMonthlyEventReport, rhsLinkageSSOMonthlyEventReport)) {
                return false;
            }
        }
        {
            LinkageSWEventReport lhsLinkageSWEventReport;
            lhsLinkageSWEventReport = this.getLinkageSWEventReport();
            LinkageSWEventReport rhsLinkageSWEventReport;
            rhsLinkageSWEventReport = that.getLinkageSWEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSWEventReport", lhsLinkageSWEventReport), LocatorUtils.property(thatLocator, "linkageSWEventReport", rhsLinkageSWEventReport), lhsLinkageSWEventReport, rhsLinkageSWEventReport)) {
                return false;
            }
        }
        {
            LinkageSWMS4Report lhsLinkageSWMS4Report;
            lhsLinkageSWMS4Report = this.getLinkageSWMS4Report();
            LinkageSWMS4Report rhsLinkageSWMS4Report;
            rhsLinkageSWMS4Report = that.getLinkageSWMS4Report();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSWMS4Report", lhsLinkageSWMS4Report), LocatorUtils.property(thatLocator, "linkageSWMS4Report", rhsLinkageSWMS4Report), lhsLinkageSWMS4Report, rhsLinkageSWMS4Report)) {
                return false;
            }
        }
        {
            LinkageStateComplianceMonitoring lhsLinkageStateComplianceMonitoring;
            lhsLinkageStateComplianceMonitoring = this.getLinkageStateComplianceMonitoring();
            LinkageStateComplianceMonitoring rhsLinkageStateComplianceMonitoring;
            rhsLinkageStateComplianceMonitoring = that.getLinkageStateComplianceMonitoring();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageStateComplianceMonitoring", lhsLinkageStateComplianceMonitoring), LocatorUtils.property(thatLocator, "linkageStateComplianceMonitoring", rhsLinkageStateComplianceMonitoring), lhsLinkageStateComplianceMonitoring, rhsLinkageStateComplianceMonitoring)) {
                return false;
            }
        }
        {
            LinkageFederalComplianceMonitoring lhsLinkageFederalComplianceMonitoring;
            lhsLinkageFederalComplianceMonitoring = this.getLinkageFederalComplianceMonitoring();
            LinkageFederalComplianceMonitoring rhsLinkageFederalComplianceMonitoring;
            rhsLinkageFederalComplianceMonitoring = that.getLinkageFederalComplianceMonitoring();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageFederalComplianceMonitoring", lhsLinkageFederalComplianceMonitoring), LocatorUtils.property(thatLocator, "linkageFederalComplianceMonitoring", rhsLinkageFederalComplianceMonitoring), lhsLinkageFederalComplianceMonitoring, rhsLinkageFederalComplianceMonitoring)) {
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
            LinkageSingleEvent theLinkageSingleEvent;
            theLinkageSingleEvent = this.getLinkageSingleEvent();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSingleEvent", theLinkageSingleEvent), currentHashCode, theLinkageSingleEvent);
        }
        {
            LinkageEnforcementAction theLinkageEnforcementAction;
            theLinkageEnforcementAction = this.getLinkageEnforcementAction();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageEnforcementAction", theLinkageEnforcementAction), currentHashCode, theLinkageEnforcementAction);
        }
        {
            LinkageBiosolidsReport theLinkageBiosolidsReport;
            theLinkageBiosolidsReport = this.getLinkageBiosolidsReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageBiosolidsReport", theLinkageBiosolidsReport), currentHashCode, theLinkageBiosolidsReport);
        }
        {
            LinkageCAFOAnnualReport theLinkageCAFOAnnualReport;
            theLinkageCAFOAnnualReport = this.getLinkageCAFOAnnualReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageCAFOAnnualReport", theLinkageCAFOAnnualReport), currentHashCode, theLinkageCAFOAnnualReport);
        }
        {
            LinkageCSOEventReport theLinkageCSOEventReport;
            theLinkageCSOEventReport = this.getLinkageCSOEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageCSOEventReport", theLinkageCSOEventReport), currentHashCode, theLinkageCSOEventReport);
        }
        {
            LinkageLocalLimitsReport theLinkageLocalLimitsReport;
            theLinkageLocalLimitsReport = this.getLinkageLocalLimitsReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageLocalLimitsReport", theLinkageLocalLimitsReport), currentHashCode, theLinkageLocalLimitsReport);
        }
        {
            LinkagePretreatmentPerformanceReport theLinkagePretreatmentPerformanceReport;
            theLinkagePretreatmentPerformanceReport = this.getLinkagePretreatmentPerformanceReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkagePretreatmentPerformanceReport", theLinkagePretreatmentPerformanceReport), currentHashCode, theLinkagePretreatmentPerformanceReport);
        }
        {
            LinkageSSOAnnualReport theLinkageSSOAnnualReport;
            theLinkageSSOAnnualReport = this.getLinkageSSOAnnualReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSSOAnnualReport", theLinkageSSOAnnualReport), currentHashCode, theLinkageSSOAnnualReport);
        }
        {
            LinkageSSOEventReport theLinkageSSOEventReport;
            theLinkageSSOEventReport = this.getLinkageSSOEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSSOEventReport", theLinkageSSOEventReport), currentHashCode, theLinkageSSOEventReport);
        }
        {
            LinkageSSOMonthlyEventReport theLinkageSSOMonthlyEventReport;
            theLinkageSSOMonthlyEventReport = this.getLinkageSSOMonthlyEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSSOMonthlyEventReport", theLinkageSSOMonthlyEventReport), currentHashCode, theLinkageSSOMonthlyEventReport);
        }
        {
            LinkageSWEventReport theLinkageSWEventReport;
            theLinkageSWEventReport = this.getLinkageSWEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSWEventReport", theLinkageSWEventReport), currentHashCode, theLinkageSWEventReport);
        }
        {
            LinkageSWMS4Report theLinkageSWMS4Report;
            theLinkageSWMS4Report = this.getLinkageSWMS4Report();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSWMS4Report", theLinkageSWMS4Report), currentHashCode, theLinkageSWMS4Report);
        }
        {
            LinkageStateComplianceMonitoring theLinkageStateComplianceMonitoring;
            theLinkageStateComplianceMonitoring = this.getLinkageStateComplianceMonitoring();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageStateComplianceMonitoring", theLinkageStateComplianceMonitoring), currentHashCode, theLinkageStateComplianceMonitoring);
        }
        {
            LinkageFederalComplianceMonitoring theLinkageFederalComplianceMonitoring;
            theLinkageFederalComplianceMonitoring = this.getLinkageFederalComplianceMonitoring();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageFederalComplianceMonitoring", theLinkageFederalComplianceMonitoring), currentHashCode, theLinkageFederalComplianceMonitoring);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

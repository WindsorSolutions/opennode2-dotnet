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
import javax.persistence.Embeddable;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
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
 * <p>Java class for ScheduleEventViolation complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ScheduleEventViolation">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}ScheduleEventViolationKeyElements">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}ReportableNonComplianceResolutionDataGroup"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ScheduleEventViolation", propOrder = {
    "reportableNonComplianceResolutionCode",
    "reportableNonComplianceResolutionDate"
})
@Embeddable
public class ScheduleEventViolation
    extends ScheduleEventViolationKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ReportableNonComplianceResolutionCode")
    protected String reportableNonComplianceResolutionCode;
    @XmlElement(name = "ReportableNonComplianceResolutionDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date reportableNonComplianceResolutionDate;

    /**
     * Gets the value of the reportableNonComplianceResolutionCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_NON_CMPL_RESL_CODE", length = 3)
    public String getReportableNonComplianceResolutionCode() {
        return reportableNonComplianceResolutionCode;
    }

    /**
     * Sets the value of the reportableNonComplianceResolutionCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportableNonComplianceResolutionCode(String value) {
        this.reportableNonComplianceResolutionCode = value;
    }

    @Transient
    public boolean isSetReportableNonComplianceResolutionCode() {
        return (this.reportableNonComplianceResolutionCode!= null);
    }

    /**
     * Gets the value of the reportableNonComplianceResolutionDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_NON_CMPL_RESL_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getReportableNonComplianceResolutionDate() {
        return reportableNonComplianceResolutionDate;
    }

    /**
     * Sets the value of the reportableNonComplianceResolutionDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportableNonComplianceResolutionDate(Date value) {
        this.reportableNonComplianceResolutionDate = value;
    }

    @Transient
    public boolean isSetReportableNonComplianceResolutionDate() {
        return (this.reportableNonComplianceResolutionDate!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof ScheduleEventViolation)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final ScheduleEventViolation that = ((ScheduleEventViolation) object);
        {
            String lhsReportableNonComplianceResolutionCode;
            lhsReportableNonComplianceResolutionCode = this.getReportableNonComplianceResolutionCode();
            String rhsReportableNonComplianceResolutionCode;
            rhsReportableNonComplianceResolutionCode = that.getReportableNonComplianceResolutionCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportableNonComplianceResolutionCode", lhsReportableNonComplianceResolutionCode), LocatorUtils.property(thatLocator, "reportableNonComplianceResolutionCode", rhsReportableNonComplianceResolutionCode), lhsReportableNonComplianceResolutionCode, rhsReportableNonComplianceResolutionCode)) {
                return false;
            }
        }
        {
            Date lhsReportableNonComplianceResolutionDate;
            lhsReportableNonComplianceResolutionDate = this.getReportableNonComplianceResolutionDate();
            Date rhsReportableNonComplianceResolutionDate;
            rhsReportableNonComplianceResolutionDate = that.getReportableNonComplianceResolutionDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportableNonComplianceResolutionDate", lhsReportableNonComplianceResolutionDate), LocatorUtils.property(thatLocator, "reportableNonComplianceResolutionDate", rhsReportableNonComplianceResolutionDate), lhsReportableNonComplianceResolutionDate, rhsReportableNonComplianceResolutionDate)) {
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
            String theReportableNonComplianceResolutionCode;
            theReportableNonComplianceResolutionCode = this.getReportableNonComplianceResolutionCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportableNonComplianceResolutionCode", theReportableNonComplianceResolutionCode), currentHashCode, theReportableNonComplianceResolutionCode);
        }
        {
            Date theReportableNonComplianceResolutionDate;
            theReportableNonComplianceResolutionDate = this.getReportableNonComplianceResolutionDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportableNonComplianceResolutionDate", theReportableNonComplianceResolutionDate), currentHashCode, theReportableNonComplianceResolutionDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
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
 * <p>Java class for HistoricalPermitScheduleEvents complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="HistoricalPermitScheduleEvents">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}HistoricalPermitScheduleKeyElements">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}ScheduleEventGroup"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "HistoricalPermitScheduleEvents", propOrder = {
    "scheduleReportReceivedDate",
    "scheduleActualDate",
    "scheduleProjectedDate",
    "scheduleUserDefinedDataElement1",
    "scheduleUserDefinedDataElement2",
    "scheduleEventComments"
})
@Embeddable
public class HistoricalPermitScheduleEvents
    extends HistoricalPermitScheduleKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ScheduleReportReceivedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date scheduleReportReceivedDate;
    @XmlElement(name = "ScheduleActualDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date scheduleActualDate;
    @XmlElement(name = "ScheduleProjectedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date scheduleProjectedDate;
    @XmlElement(name = "ScheduleUserDefinedDataElement1")
    protected String scheduleUserDefinedDataElement1;
    @XmlElement(name = "ScheduleUserDefinedDataElement2")
    protected String scheduleUserDefinedDataElement2;
    @XmlElement(name = "ScheduleEventComments")
    protected String scheduleEventComments;

    /**
     * Gets the value of the scheduleReportReceivedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_REP_RCVD_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getScheduleReportReceivedDate() {
        return scheduleReportReceivedDate;
    }

    /**
     * Sets the value of the scheduleReportReceivedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleReportReceivedDate(Date value) {
        this.scheduleReportReceivedDate = value;
    }

    @Transient
    public boolean isSetScheduleReportReceivedDate() {
        return (this.scheduleReportReceivedDate!= null);
    }

    /**
     * Gets the value of the scheduleActualDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_ACTUL_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getScheduleActualDate() {
        return scheduleActualDate;
    }

    /**
     * Sets the value of the scheduleActualDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleActualDate(Date value) {
        this.scheduleActualDate = value;
    }

    @Transient
    public boolean isSetScheduleActualDate() {
        return (this.scheduleActualDate!= null);
    }

    /**
     * Gets the value of the scheduleProjectedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_PROJ_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getScheduleProjectedDate() {
        return scheduleProjectedDate;
    }

    /**
     * Sets the value of the scheduleProjectedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleProjectedDate(Date value) {
        this.scheduleProjectedDate = value;
    }

    @Transient
    public boolean isSetScheduleProjectedDate() {
        return (this.scheduleProjectedDate!= null);
    }

    /**
     * Gets the value of the scheduleUserDefinedDataElement1 property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_USR_DFND_DAT_ELM_1", length = 30)
    public String getScheduleUserDefinedDataElement1() {
        return scheduleUserDefinedDataElement1;
    }

    /**
     * Sets the value of the scheduleUserDefinedDataElement1 property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleUserDefinedDataElement1(String value) {
        this.scheduleUserDefinedDataElement1 = value;
    }

    @Transient
    public boolean isSetScheduleUserDefinedDataElement1() {
        return (this.scheduleUserDefinedDataElement1 != null);
    }

    /**
     * Gets the value of the scheduleUserDefinedDataElement2 property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_USR_DFND_DAT_ELM_2", length = 30)
    public String getScheduleUserDefinedDataElement2() {
        return scheduleUserDefinedDataElement2;
    }

    /**
     * Sets the value of the scheduleUserDefinedDataElement2 property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleUserDefinedDataElement2(String value) {
        this.scheduleUserDefinedDataElement2 = value;
    }

    @Transient
    public boolean isSetScheduleUserDefinedDataElement2() {
        return (this.scheduleUserDefinedDataElement2 != null);
    }

    /**
     * Gets the value of the scheduleEventComments property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_EVT_CMNTS", length = 4000)
    public String getScheduleEventComments() {
        return scheduleEventComments;
    }

    /**
     * Sets the value of the scheduleEventComments property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleEventComments(String value) {
        this.scheduleEventComments = value;
    }

    @Transient
    public boolean isSetScheduleEventComments() {
        return (this.scheduleEventComments!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof HistoricalPermitScheduleEvents)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final HistoricalPermitScheduleEvents that = ((HistoricalPermitScheduleEvents) object);
        {
            Date lhsScheduleReportReceivedDate;
            lhsScheduleReportReceivedDate = this.getScheduleReportReceivedDate();
            Date rhsScheduleReportReceivedDate;
            rhsScheduleReportReceivedDate = that.getScheduleReportReceivedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleReportReceivedDate", lhsScheduleReportReceivedDate), LocatorUtils.property(thatLocator, "scheduleReportReceivedDate", rhsScheduleReportReceivedDate), lhsScheduleReportReceivedDate, rhsScheduleReportReceivedDate)) {
                return false;
            }
        }
        {
            Date lhsScheduleActualDate;
            lhsScheduleActualDate = this.getScheduleActualDate();
            Date rhsScheduleActualDate;
            rhsScheduleActualDate = that.getScheduleActualDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleActualDate", lhsScheduleActualDate), LocatorUtils.property(thatLocator, "scheduleActualDate", rhsScheduleActualDate), lhsScheduleActualDate, rhsScheduleActualDate)) {
                return false;
            }
        }
        {
            Date lhsScheduleProjectedDate;
            lhsScheduleProjectedDate = this.getScheduleProjectedDate();
            Date rhsScheduleProjectedDate;
            rhsScheduleProjectedDate = that.getScheduleProjectedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleProjectedDate", lhsScheduleProjectedDate), LocatorUtils.property(thatLocator, "scheduleProjectedDate", rhsScheduleProjectedDate), lhsScheduleProjectedDate, rhsScheduleProjectedDate)) {
                return false;
            }
        }
        {
            String lhsScheduleUserDefinedDataElement1;
            lhsScheduleUserDefinedDataElement1 = this.getScheduleUserDefinedDataElement1();
            String rhsScheduleUserDefinedDataElement1;
            rhsScheduleUserDefinedDataElement1 = that.getScheduleUserDefinedDataElement1();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleUserDefinedDataElement1", lhsScheduleUserDefinedDataElement1), LocatorUtils.property(thatLocator, "scheduleUserDefinedDataElement1", rhsScheduleUserDefinedDataElement1), lhsScheduleUserDefinedDataElement1, rhsScheduleUserDefinedDataElement1)) {
                return false;
            }
        }
        {
            String lhsScheduleUserDefinedDataElement2;
            lhsScheduleUserDefinedDataElement2 = this.getScheduleUserDefinedDataElement2();
            String rhsScheduleUserDefinedDataElement2;
            rhsScheduleUserDefinedDataElement2 = that.getScheduleUserDefinedDataElement2();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleUserDefinedDataElement2", lhsScheduleUserDefinedDataElement2), LocatorUtils.property(thatLocator, "scheduleUserDefinedDataElement2", rhsScheduleUserDefinedDataElement2), lhsScheduleUserDefinedDataElement2, rhsScheduleUserDefinedDataElement2)) {
                return false;
            }
        }
        {
            String lhsScheduleEventComments;
            lhsScheduleEventComments = this.getScheduleEventComments();
            String rhsScheduleEventComments;
            rhsScheduleEventComments = that.getScheduleEventComments();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleEventComments", lhsScheduleEventComments), LocatorUtils.property(thatLocator, "scheduleEventComments", rhsScheduleEventComments), lhsScheduleEventComments, rhsScheduleEventComments)) {
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
            Date theScheduleReportReceivedDate;
            theScheduleReportReceivedDate = this.getScheduleReportReceivedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleReportReceivedDate", theScheduleReportReceivedDate), currentHashCode, theScheduleReportReceivedDate);
        }
        {
            Date theScheduleActualDate;
            theScheduleActualDate = this.getScheduleActualDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleActualDate", theScheduleActualDate), currentHashCode, theScheduleActualDate);
        }
        {
            Date theScheduleProjectedDate;
            theScheduleProjectedDate = this.getScheduleProjectedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleProjectedDate", theScheduleProjectedDate), currentHashCode, theScheduleProjectedDate);
        }
        {
            String theScheduleUserDefinedDataElement1;
            theScheduleUserDefinedDataElement1 = this.getScheduleUserDefinedDataElement1();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleUserDefinedDataElement1", theScheduleUserDefinedDataElement1), currentHashCode, theScheduleUserDefinedDataElement1);
        }
        {
            String theScheduleUserDefinedDataElement2;
            theScheduleUserDefinedDataElement2 = this.getScheduleUserDefinedDataElement2();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleUserDefinedDataElement2", theScheduleUserDefinedDataElement2), currentHashCode, theScheduleUserDefinedDataElement2);
        }
        {
            String theScheduleEventComments;
            theScheduleEventComments = this.getScheduleEventComments();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleEventComments", theScheduleEventComments), currentHashCode, theScheduleEventComments);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

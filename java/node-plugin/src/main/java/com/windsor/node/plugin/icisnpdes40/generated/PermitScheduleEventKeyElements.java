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
 * <p>Java class for PermitScheduleEventKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermitScheduleEventKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleEventKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermitScheduleEventKeyElements", propOrder = {
    "scheduleEventCode",
    "scheduleDate"
})
@XmlSeeAlso({
    PermitScheduleEvent.class
})
@MappedSuperclass
public class PermitScheduleEventKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ScheduleEventCode", required = true)
    protected String scheduleEventCode;
    @XmlElement(name = "ScheduleDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date scheduleDate;

    /**
     * Gets the value of the scheduleEventCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_EVT_CODE", length = 5)
    public String getScheduleEventCode() {
        return scheduleEventCode;
    }

    /**
     * Sets the value of the scheduleEventCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleEventCode(String value) {
        this.scheduleEventCode = value;
    }

    @Transient
    public boolean isSetScheduleEventCode() {
        return (this.scheduleEventCode!= null);
    }

    /**
     * Gets the value of the scheduleDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SCHD_DATE")
    @Temporal(TemporalType.DATE)
    public Date getScheduleDate() {
        return scheduleDate;
    }

    /**
     * Sets the value of the scheduleDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setScheduleDate(Date value) {
        this.scheduleDate = value;
    }

    @Transient
    public boolean isSetScheduleDate() {
        return (this.scheduleDate!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof PermitScheduleEventKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PermitScheduleEventKeyElements that = ((PermitScheduleEventKeyElements) object);
        {
            String lhsScheduleEventCode;
            lhsScheduleEventCode = this.getScheduleEventCode();
            String rhsScheduleEventCode;
            rhsScheduleEventCode = that.getScheduleEventCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleEventCode", lhsScheduleEventCode), LocatorUtils.property(thatLocator, "scheduleEventCode", rhsScheduleEventCode), lhsScheduleEventCode, rhsScheduleEventCode)) {
                return false;
            }
        }
        {
            Date lhsScheduleDate;
            lhsScheduleDate = this.getScheduleDate();
            Date rhsScheduleDate;
            rhsScheduleDate = that.getScheduleDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleDate", lhsScheduleDate), LocatorUtils.property(thatLocator, "scheduleDate", rhsScheduleDate), lhsScheduleDate, rhsScheduleDate)) {
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
            String theScheduleEventCode;
            theScheduleEventCode = this.getScheduleEventCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleEventCode", theScheduleEventCode), currentHashCode, theScheduleEventCode);
        }
        {
            Date theScheduleDate;
            theScheduleDate = this.getScheduleDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleDate", theScheduleDate), currentHashCode, theScheduleDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

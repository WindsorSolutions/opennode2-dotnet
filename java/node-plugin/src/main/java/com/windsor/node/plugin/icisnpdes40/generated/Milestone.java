//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
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
 * <p>Java class for Milestone complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Milestone">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}EnforcementActionMilestoneKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}MilestonePlannedDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}MilestoneActualDate" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Milestone", propOrder = {
    "milestonePlannedDate",
    "milestoneActualDate"
})
@Embeddable
public class Milestone
    extends EnforcementActionMilestoneKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "MilestonePlannedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date milestonePlannedDate;
    @XmlElement(name = "MilestoneActualDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date milestoneActualDate;

    /**
     * Gets the value of the milestonePlannedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MILESTONE_PLANNED_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getMilestonePlannedDate() {
        return milestonePlannedDate;
    }

    /**
     * Sets the value of the milestonePlannedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMilestonePlannedDate(Date value) {
        this.milestonePlannedDate = value;
    }

    @Transient
    public boolean isSetMilestonePlannedDate() {
        return (this.milestonePlannedDate!= null);
    }

    /**
     * Gets the value of the milestoneActualDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MILESTONE_ACTUL_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getMilestoneActualDate() {
        return milestoneActualDate;
    }

    /**
     * Sets the value of the milestoneActualDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMilestoneActualDate(Date value) {
        this.milestoneActualDate = value;
    }

    @Transient
    public boolean isSetMilestoneActualDate() {
        return (this.milestoneActualDate!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof Milestone)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final Milestone that = ((Milestone) object);
        {
            Date lhsMilestonePlannedDate;
            lhsMilestonePlannedDate = this.getMilestonePlannedDate();
            Date rhsMilestonePlannedDate;
            rhsMilestonePlannedDate = that.getMilestonePlannedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "milestonePlannedDate", lhsMilestonePlannedDate), LocatorUtils.property(thatLocator, "milestonePlannedDate", rhsMilestonePlannedDate), lhsMilestonePlannedDate, rhsMilestonePlannedDate)) {
                return false;
            }
        }
        {
            Date lhsMilestoneActualDate;
            lhsMilestoneActualDate = this.getMilestoneActualDate();
            Date rhsMilestoneActualDate;
            rhsMilestoneActualDate = that.getMilestoneActualDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "milestoneActualDate", lhsMilestoneActualDate), LocatorUtils.property(thatLocator, "milestoneActualDate", rhsMilestoneActualDate), lhsMilestoneActualDate, rhsMilestoneActualDate)) {
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
            Date theMilestonePlannedDate;
            theMilestonePlannedDate = this.getMilestonePlannedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "milestonePlannedDate", theMilestonePlannedDate), currentHashCode, theMilestonePlannedDate);
        }
        {
            Date theMilestoneActualDate;
            theMilestoneActualDate = this.getMilestoneActualDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "milestoneActualDate", theMilestoneActualDate), currentHashCode, theMilestoneActualDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.08.31 at 09:29:38 AM PDT 
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
 * <p>Java class for PermitScheduleKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermitScheduleKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermitScheduleKeyElements", propOrder = {
    "permitIdentifier",
    "narrativeConditionNumber"
})
@XmlSeeAlso({
    NarrativeCondition.class,
    PermitSchedule.class,
    PermitScheduleViolation.class
})
@MappedSuperclass
public class PermitScheduleKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "NarrativeConditionNumber")
    protected int narrativeConditionNumber;

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
     * Gets the value of the narrativeConditionNumber property.
     * 
     */
    @Basic
    @Column(name = "NARR_COND_NUM", precision = 20, scale = 0)
    public int getNarrativeConditionNumber() {
        return narrativeConditionNumber;
    }

    /**
     * Sets the value of the narrativeConditionNumber property.
     * 
     */
    public void setNarrativeConditionNumber(int value) {
        this.narrativeConditionNumber = value;
    }

    @Transient
    public boolean isSetNarrativeConditionNumber() {
        return true;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof PermitScheduleKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PermitScheduleKeyElements that = ((PermitScheduleKeyElements) object);
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
            int lhsNarrativeConditionNumber;
            lhsNarrativeConditionNumber = (this.isSetNarrativeConditionNumber()?this.getNarrativeConditionNumber(): 0);
            int rhsNarrativeConditionNumber;
            rhsNarrativeConditionNumber = (that.isSetNarrativeConditionNumber()?that.getNarrativeConditionNumber(): 0);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "narrativeConditionNumber", lhsNarrativeConditionNumber), LocatorUtils.property(thatLocator, "narrativeConditionNumber", rhsNarrativeConditionNumber), lhsNarrativeConditionNumber, rhsNarrativeConditionNumber)) {
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
            int theNarrativeConditionNumber;
            theNarrativeConditionNumber = (this.isSetNarrativeConditionNumber()?this.getNarrativeConditionNumber(): 0);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "narrativeConditionNumber", theNarrativeConditionNumber), currentHashCode, theNarrativeConditionNumber);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

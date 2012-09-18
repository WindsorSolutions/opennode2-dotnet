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
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SSOSteps complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SSOSteps">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}StepsReducePreventMitigate"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}OtherStepsReducePreventMitigate" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SSOSteps", propOrder = {
    "stepsReducePreventMitigate",
    "otherStepsReducePreventMitigate"
})
@Entity(name = "SSOSteps")
@Table(name = "ICS_SSO_STPS")
@Inheritance(strategy = InheritanceType.JOINED)
public class SSOSteps
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "StepsReducePreventMitigate", required = true)
    protected String stepsReducePreventMitigate;
    @XmlElement(name = "OtherStepsReducePreventMitigate")
    protected String otherStepsReducePreventMitigate;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the stepsReducePreventMitigate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "STPS_RDUCE_PREVNT_MITIGTE", length = 3)
    public String getStepsReducePreventMitigate() {
        return stepsReducePreventMitigate;
    }

    /**
     * Sets the value of the stepsReducePreventMitigate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStepsReducePreventMitigate(String value) {
        this.stepsReducePreventMitigate = value;
    }

    @Transient
    public boolean isSetStepsReducePreventMitigate() {
        return (this.stepsReducePreventMitigate!= null);
    }

    /**
     * Gets the value of the otherStepsReducePreventMitigate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHR_STPS_RDUCE_PREVNT_MITIGTE", length = 50)
    public String getOtherStepsReducePreventMitigate() {
        return otherStepsReducePreventMitigate;
    }

    /**
     * Sets the value of the otherStepsReducePreventMitigate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherStepsReducePreventMitigate(String value) {
        this.otherStepsReducePreventMitigate = value;
    }

    @Transient
    public boolean isSetOtherStepsReducePreventMitigate() {
        return (this.otherStepsReducePreventMitigate!= null);
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
    @Column(name = "ICS_SSO_STPS_ID")
    public String getDbid() {
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
    public void setDbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SSOSteps)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SSOSteps that = ((SSOSteps) object);
        {
            String lhsStepsReducePreventMitigate;
            lhsStepsReducePreventMitigate = this.getStepsReducePreventMitigate();
            String rhsStepsReducePreventMitigate;
            rhsStepsReducePreventMitigate = that.getStepsReducePreventMitigate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stepsReducePreventMitigate", lhsStepsReducePreventMitigate), LocatorUtils.property(thatLocator, "stepsReducePreventMitigate", rhsStepsReducePreventMitigate), lhsStepsReducePreventMitigate, rhsStepsReducePreventMitigate)) {
                return false;
            }
        }
        {
            String lhsOtherStepsReducePreventMitigate;
            lhsOtherStepsReducePreventMitigate = this.getOtherStepsReducePreventMitigate();
            String rhsOtherStepsReducePreventMitigate;
            rhsOtherStepsReducePreventMitigate = that.getOtherStepsReducePreventMitigate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherStepsReducePreventMitigate", lhsOtherStepsReducePreventMitigate), LocatorUtils.property(thatLocator, "otherStepsReducePreventMitigate", rhsOtherStepsReducePreventMitigate), lhsOtherStepsReducePreventMitigate, rhsOtherStepsReducePreventMitigate)) {
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
            String theStepsReducePreventMitigate;
            theStepsReducePreventMitigate = this.getStepsReducePreventMitigate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stepsReducePreventMitigate", theStepsReducePreventMitigate), currentHashCode, theStepsReducePreventMitigate);
        }
        {
            String theOtherStepsReducePreventMitigate;
            theOtherStepsReducePreventMitigate = this.getOtherStepsReducePreventMitigate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherStepsReducePreventMitigate", theOtherStepsReducePreventMitigate), currentHashCode, theOtherStepsReducePreventMitigate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.09.03 at 05:58:07 AM PDT
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
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
 * <p>Java class for StormWaterConstructionNonConstructionInspections complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="StormWaterConstructionNonConstructionInspections">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterUnpermittedConstructionInspection" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterConstructionIndustrialInspection" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "StormWaterConstructionNonConstructionInspections", propOrder = {
    "stormWaterUnpermittedConstructionInspection",
    "stormWaterConstructionIndustrialInspection"
})
@Entity(name = "StormWaterConstructionNonConstructionInspections")
@Table(name = "ICS_SW_CNST_NON_CNST_INSP")
@Inheritance(strategy = InheritanceType.JOINED)
public class StormWaterConstructionNonConstructionInspections
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "StormWaterUnpermittedConstructionInspection")
    protected StormWaterUnpermittedConstructionInspection stormWaterUnpermittedConstructionInspection;
    @XmlElement(name = "StormWaterConstructionIndustrialInspection")
    protected StormWaterConstructionIndustrialInspection stormWaterConstructionIndustrialInspection;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the stormWaterUnpermittedConstructionInspection property.
     *
     * @return
     *     possible object is
     *     {@link StormWaterUnpermittedConstructionInspection }
     *
     */
    // FIXME: changed from @ManyToOne
    @OneToOne(targetEntity = StormWaterUnpermittedConstructionInspection.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_SW_CNST_NON_CNST_INSP_ID")
    public StormWaterUnpermittedConstructionInspection getStormWaterUnpermittedConstructionInspection() {
        return stormWaterUnpermittedConstructionInspection;
    }

    /**
     * Sets the value of the stormWaterUnpermittedConstructionInspection property.
     *
     * @param value
     *     allowed object is
     *     {@link StormWaterUnpermittedConstructionInspection }
     *
     */
    public void setStormWaterUnpermittedConstructionInspection(final StormWaterUnpermittedConstructionInspection value) {
        this.stormWaterUnpermittedConstructionInspection = value;
    }

    @Transient
    public boolean isSetStormWaterUnpermittedConstructionInspection() {
        return (this.stormWaterUnpermittedConstructionInspection!= null);
    }

    /**
     * Gets the value of the stormWaterConstructionIndustrialInspection property.
     *
     * @return
     *     possible object is
     *     {@link StormWaterConstructionIndustrialInspection }
     *
     */
    // FIXME: changed from @ManyToOne
    @OneToOne(targetEntity = StormWaterConstructionIndustrialInspection.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_SW_CNST_NON_CNST_INSP_ID")
    public StormWaterConstructionIndustrialInspection getStormWaterConstructionIndustrialInspection() {
        return stormWaterConstructionIndustrialInspection;
    }

    /**
     * Sets the value of the stormWaterConstructionIndustrialInspection property.
     *
     * @param value
     *     allowed object is
     *     {@link StormWaterConstructionIndustrialInspection }
     *
     */
    public void setStormWaterConstructionIndustrialInspection(final StormWaterConstructionIndustrialInspection value) {
        this.stormWaterConstructionIndustrialInspection = value;
    }

    @Transient
    public boolean isSetStormWaterConstructionIndustrialInspection() {
        return (this.stormWaterConstructionIndustrialInspection!= null);
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
    @Column(name = "ICS_SW_CNST_NON_CNST_INSP_ID")
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
    public void setdbid(final String value) {
        this.dbid = value;
    }

    @Override
	public boolean equals(final ObjectLocator thisLocator, final ObjectLocator thatLocator, final Object object, final EqualsStrategy strategy) {
        if (!(object instanceof StormWaterConstructionNonConstructionInspections)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final StormWaterConstructionNonConstructionInspections that = ((StormWaterConstructionNonConstructionInspections) object);
        {
            StormWaterUnpermittedConstructionInspection lhsStormWaterUnpermittedConstructionInspection;
            lhsStormWaterUnpermittedConstructionInspection = this.getStormWaterUnpermittedConstructionInspection();
            StormWaterUnpermittedConstructionInspection rhsStormWaterUnpermittedConstructionInspection;
            rhsStormWaterUnpermittedConstructionInspection = that.getStormWaterUnpermittedConstructionInspection();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stormWaterUnpermittedConstructionInspection", lhsStormWaterUnpermittedConstructionInspection), LocatorUtils.property(thatLocator, "stormWaterUnpermittedConstructionInspection", rhsStormWaterUnpermittedConstructionInspection), lhsStormWaterUnpermittedConstructionInspection, rhsStormWaterUnpermittedConstructionInspection)) {
                return false;
            }
        }
        {
            StormWaterConstructionIndustrialInspection lhsStormWaterConstructionIndustrialInspection;
            lhsStormWaterConstructionIndustrialInspection = this.getStormWaterConstructionIndustrialInspection();
            StormWaterConstructionIndustrialInspection rhsStormWaterConstructionIndustrialInspection;
            rhsStormWaterConstructionIndustrialInspection = that.getStormWaterConstructionIndustrialInspection();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stormWaterConstructionIndustrialInspection", lhsStormWaterConstructionIndustrialInspection), LocatorUtils.property(thatLocator, "stormWaterConstructionIndustrialInspection", rhsStormWaterConstructionIndustrialInspection), lhsStormWaterConstructionIndustrialInspection, rhsStormWaterConstructionIndustrialInspection)) {
                return false;
            }
        }
        return true;
    }

    @Override
	public boolean equals(final Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    @Override
	public int hashCode(final ObjectLocator locator, final HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            StormWaterUnpermittedConstructionInspection theStormWaterUnpermittedConstructionInspection;
            theStormWaterUnpermittedConstructionInspection = this.getStormWaterUnpermittedConstructionInspection();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stormWaterUnpermittedConstructionInspection", theStormWaterUnpermittedConstructionInspection), currentHashCode, theStormWaterUnpermittedConstructionInspection);
        }
        {
            StormWaterConstructionIndustrialInspection theStormWaterConstructionIndustrialInspection;
            theStormWaterConstructionIndustrialInspection = this.getStormWaterConstructionIndustrialInspection();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stormWaterConstructionIndustrialInspection", theStormWaterConstructionIndustrialInspection), currentHashCode, theStormWaterConstructionIndustrialInspection);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 08:49:32 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for AnimalType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AnimalType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}ReportedAnimalType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}OpenConfinementCount" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}HousedUnderRoofConfinementCount" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AnimalType", propOrder = {
    "openConfinementCount",
    "housedUnderRoofConfinementCount"
})
@Entity(name = "AnimalType")
@Table(name = "ICS_V_ANML_TYPE_HIB")
public class AnimalType
    extends ReportedAnimalType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "OpenConfinementCount", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer openConfinementCount;
    @XmlElement(name = "HousedUnderRoofConfinementCount", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer housedUnderRoofConfinementCount;

    /**
     * Gets the value of the openConfinementCount property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OPEN_CONFINEMNT_CNT", scale = 0)
    public Integer getOpenConfinementCount() {
        return openConfinementCount;
    }

    /**
     * Sets the value of the openConfinementCount property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOpenConfinementCount(Integer value) {
        this.openConfinementCount = value;
    }

    @Transient
    public boolean isSetOpenConfinementCount() {
        return (this.openConfinementCount!= null);
    }

    /**
     * Gets the value of the housedUnderRoofConfinementCount property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "HOUSD_UNDR_ROOF_CONFINEMNT_CNT", scale = 0)
    public Integer getHousedUnderRoofConfinementCount() {
        return housedUnderRoofConfinementCount;
    }

    /**
     * Sets the value of the housedUnderRoofConfinementCount property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setHousedUnderRoofConfinementCount(Integer value) {
        this.housedUnderRoofConfinementCount = value;
    }

    @Transient
    public boolean isSetHousedUnderRoofConfinementCount() {
        return (this.housedUnderRoofConfinementCount!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof AnimalType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final AnimalType that = ((AnimalType) object);
        {
            Integer lhsOpenConfinementCount;
            lhsOpenConfinementCount = this.getOpenConfinementCount();
            Integer rhsOpenConfinementCount;
            rhsOpenConfinementCount = that.getOpenConfinementCount();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "openConfinementCount", lhsOpenConfinementCount), LocatorUtils.property(thatLocator, "openConfinementCount", rhsOpenConfinementCount), lhsOpenConfinementCount, rhsOpenConfinementCount)) {
                return false;
            }
        }
        {
            Integer lhsHousedUnderRoofConfinementCount;
            lhsHousedUnderRoofConfinementCount = this.getHousedUnderRoofConfinementCount();
            Integer rhsHousedUnderRoofConfinementCount;
            rhsHousedUnderRoofConfinementCount = that.getHousedUnderRoofConfinementCount();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "housedUnderRoofConfinementCount", lhsHousedUnderRoofConfinementCount), LocatorUtils.property(thatLocator, "housedUnderRoofConfinementCount", rhsHousedUnderRoofConfinementCount), lhsHousedUnderRoofConfinementCount, rhsHousedUnderRoofConfinementCount)) {
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
            Integer theOpenConfinementCount;
            theOpenConfinementCount = this.getOpenConfinementCount();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "openConfinementCount", theOpenConfinementCount), currentHashCode, theOpenConfinementCount);
        }
        {
            Integer theHousedUnderRoofConfinementCount;
            theHousedUnderRoofConfinementCount = this.getHousedUnderRoofConfinementCount();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "housedUnderRoofConfinementCount", theHousedUnderRoofConfinementCount), currentHashCode, theHousedUnderRoofConfinementCount);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

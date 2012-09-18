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
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for ReportedAnimalType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ReportedAnimalType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}AnimalTypeCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}OtherAnimalTypeName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TotalNumbersEachLivestock" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ReportedAnimalType", propOrder = {
    "animalTypeCode",
    "otherAnimalTypeName",
    "totalNumbersEachLivestock"
})
@XmlSeeAlso({
    AnimalType.class
})
@Entity(name = "ReportedAnimalType")
@Table(name = "ICS_REP_ANML_TYPE")
@Inheritance(strategy = InheritanceType.TABLE_PER_CLASS)
public class ReportedAnimalType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "AnimalTypeCode", required = true)
    protected String animalTypeCode;
    @XmlElement(name = "OtherAnimalTypeName")
    protected String otherAnimalTypeName;
    @XmlElement(name = "TotalNumbersEachLivestock", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer totalNumbersEachLivestock;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the animalTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ANML_TYPE_CODE", length = 3)
    public String getAnimalTypeCode() {
        return animalTypeCode;
    }

    /**
     * Sets the value of the animalTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAnimalTypeCode(String value) {
        this.animalTypeCode = value;
    }

    @Transient
    public boolean isSetAnimalTypeCode() {
        return (this.animalTypeCode!= null);
    }

    /**
     * Gets the value of the otherAnimalTypeName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHR_ANML_TYPE_NAME", length = 50)
    public String getOtherAnimalTypeName() {
        return otherAnimalTypeName;
    }

    /**
     * Sets the value of the otherAnimalTypeName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherAnimalTypeName(String value) {
        this.otherAnimalTypeName = value;
    }

    @Transient
    public boolean isSetOtherAnimalTypeName() {
        return (this.otherAnimalTypeName!= null);
    }

    /**
     * Gets the value of the totalNumbersEachLivestock property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TTL_NUM_EACH_LVSTCK", scale = 0)
    public Integer getTotalNumbersEachLivestock() {
        return totalNumbersEachLivestock;
    }

    /**
     * Sets the value of the totalNumbersEachLivestock property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTotalNumbersEachLivestock(Integer value) {
        this.totalNumbersEachLivestock = value;
    }

    @Transient
    public boolean isSetTotalNumbersEachLivestock() {
        return (this.totalNumbersEachLivestock!= null);
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
    @Column(name = "ICS_REP_ANML_TYPE_ID")
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
        if (!(object instanceof ReportedAnimalType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ReportedAnimalType that = ((ReportedAnimalType) object);
        {
            String lhsAnimalTypeCode;
            lhsAnimalTypeCode = this.getAnimalTypeCode();
            String rhsAnimalTypeCode;
            rhsAnimalTypeCode = that.getAnimalTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "animalTypeCode", lhsAnimalTypeCode), LocatorUtils.property(thatLocator, "animalTypeCode", rhsAnimalTypeCode), lhsAnimalTypeCode, rhsAnimalTypeCode)) {
                return false;
            }
        }
        {
            String lhsOtherAnimalTypeName;
            lhsOtherAnimalTypeName = this.getOtherAnimalTypeName();
            String rhsOtherAnimalTypeName;
            rhsOtherAnimalTypeName = that.getOtherAnimalTypeName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherAnimalTypeName", lhsOtherAnimalTypeName), LocatorUtils.property(thatLocator, "otherAnimalTypeName", rhsOtherAnimalTypeName), lhsOtherAnimalTypeName, rhsOtherAnimalTypeName)) {
                return false;
            }
        }
        {
            Integer lhsTotalNumbersEachLivestock;
            lhsTotalNumbersEachLivestock = this.getTotalNumbersEachLivestock();
            Integer rhsTotalNumbersEachLivestock;
            rhsTotalNumbersEachLivestock = that.getTotalNumbersEachLivestock();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "totalNumbersEachLivestock", lhsTotalNumbersEachLivestock), LocatorUtils.property(thatLocator, "totalNumbersEachLivestock", rhsTotalNumbersEachLivestock), lhsTotalNumbersEachLivestock, rhsTotalNumbersEachLivestock)) {
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
            String theAnimalTypeCode;
            theAnimalTypeCode = this.getAnimalTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "animalTypeCode", theAnimalTypeCode), currentHashCode, theAnimalTypeCode);
        }
        {
            String theOtherAnimalTypeName;
            theOtherAnimalTypeName = this.getOtherAnimalTypeName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherAnimalTypeName", theOtherAnimalTypeName), currentHashCode, theOtherAnimalTypeName);
        }
        {
            Integer theTotalNumbersEachLivestock;
            theTotalNumbersEachLivestock = this.getTotalNumbersEachLivestock();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "totalNumbersEachLivestock", theTotalNumbersEachLivestock), currentHashCode, theTotalNumbersEachLivestock);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

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
 * <p>Java class for ManureLitterProcessedWastewaterStorage complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ManureLitterProcessedWastewaterStorage">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ManureLitterProcessedWastewaterStorageType"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}OtherStorageTypeName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}StorageTotalCapacityMeasure" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DaysOfStorage" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ManureLitterProcessedWastewaterStorage", propOrder = {
    "manureLitterProcessedWastewaterStorageType",
    "otherStorageTypeName",
    "storageTotalCapacityMeasure",
    "daysOfStorage"
})
@Entity(name = "ManureLitterProcessedWastewaterStorage")
@Table(name = "ICS_MNUR_LTTR_PRCSS_WW_STOR")
@Inheritance(strategy = InheritanceType.JOINED)
public class ManureLitterProcessedWastewaterStorage
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ManureLitterProcessedWastewaterStorageType", required = true)
    protected String manureLitterProcessedWastewaterStorageType;
    @XmlElement(name = "OtherStorageTypeName")
    protected String otherStorageTypeName;
    @XmlElement(name = "StorageTotalCapacityMeasure", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer storageTotalCapacityMeasure;
    @XmlElement(name = "DaysOfStorage", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer daysOfStorage;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the manureLitterProcessedWastewaterStorageType property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MNUR_LTTR_PRCSS_WW_STOR_TYPE", length = 3)
    public String getManureLitterProcessedWastewaterStorageType() {
        return manureLitterProcessedWastewaterStorageType;
    }

    /**
     * Sets the value of the manureLitterProcessedWastewaterStorageType property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setManureLitterProcessedWastewaterStorageType(String value) {
        this.manureLitterProcessedWastewaterStorageType = value;
    }

    @Transient
    public boolean isSetManureLitterProcessedWastewaterStorageType() {
        return (this.manureLitterProcessedWastewaterStorageType!= null);
    }

    /**
     * Gets the value of the otherStorageTypeName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHR_STOR_TYPE_NAME", length = 50)
    public String getOtherStorageTypeName() {
        return otherStorageTypeName;
    }

    /**
     * Sets the value of the otherStorageTypeName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherStorageTypeName(String value) {
        this.otherStorageTypeName = value;
    }

    @Transient
    public boolean isSetOtherStorageTypeName() {
        return (this.otherStorageTypeName!= null);
    }

    /**
     * Gets the value of the storageTotalCapacityMeasure property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "STOR_TTL_CPCTY_MEAS", scale = 0)
    public Integer getStorageTotalCapacityMeasure() {
        return storageTotalCapacityMeasure;
    }

    /**
     * Sets the value of the storageTotalCapacityMeasure property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStorageTotalCapacityMeasure(Integer value) {
        this.storageTotalCapacityMeasure = value;
    }

    @Transient
    public boolean isSetStorageTotalCapacityMeasure() {
        return (this.storageTotalCapacityMeasure!= null);
    }

    /**
     * Gets the value of the daysOfStorage property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DAYS_OF_STOR", scale = 0)
    public Integer getDaysOfStorage() {
        return daysOfStorage;
    }

    /**
     * Sets the value of the daysOfStorage property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDaysOfStorage(Integer value) {
        this.daysOfStorage = value;
    }

    @Transient
    public boolean isSetDaysOfStorage() {
        return (this.daysOfStorage!= null);
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
    @Column(name = "ICS_MNUR_LTTR_PRCSS_WW_STOR_ID")
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
        if (!(object instanceof ManureLitterProcessedWastewaterStorage)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ManureLitterProcessedWastewaterStorage that = ((ManureLitterProcessedWastewaterStorage) object);
        {
            String lhsManureLitterProcessedWastewaterStorageType;
            lhsManureLitterProcessedWastewaterStorageType = this.getManureLitterProcessedWastewaterStorageType();
            String rhsManureLitterProcessedWastewaterStorageType;
            rhsManureLitterProcessedWastewaterStorageType = that.getManureLitterProcessedWastewaterStorageType();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "manureLitterProcessedWastewaterStorageType", lhsManureLitterProcessedWastewaterStorageType), LocatorUtils.property(thatLocator, "manureLitterProcessedWastewaterStorageType", rhsManureLitterProcessedWastewaterStorageType), lhsManureLitterProcessedWastewaterStorageType, rhsManureLitterProcessedWastewaterStorageType)) {
                return false;
            }
        }
        {
            String lhsOtherStorageTypeName;
            lhsOtherStorageTypeName = this.getOtherStorageTypeName();
            String rhsOtherStorageTypeName;
            rhsOtherStorageTypeName = that.getOtherStorageTypeName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherStorageTypeName", lhsOtherStorageTypeName), LocatorUtils.property(thatLocator, "otherStorageTypeName", rhsOtherStorageTypeName), lhsOtherStorageTypeName, rhsOtherStorageTypeName)) {
                return false;
            }
        }
        {
            Integer lhsStorageTotalCapacityMeasure;
            lhsStorageTotalCapacityMeasure = this.getStorageTotalCapacityMeasure();
            Integer rhsStorageTotalCapacityMeasure;
            rhsStorageTotalCapacityMeasure = that.getStorageTotalCapacityMeasure();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "storageTotalCapacityMeasure", lhsStorageTotalCapacityMeasure), LocatorUtils.property(thatLocator, "storageTotalCapacityMeasure", rhsStorageTotalCapacityMeasure), lhsStorageTotalCapacityMeasure, rhsStorageTotalCapacityMeasure)) {
                return false;
            }
        }
        {
            Integer lhsDaysOfStorage;
            lhsDaysOfStorage = this.getDaysOfStorage();
            Integer rhsDaysOfStorage;
            rhsDaysOfStorage = that.getDaysOfStorage();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "daysOfStorage", lhsDaysOfStorage), LocatorUtils.property(thatLocator, "daysOfStorage", rhsDaysOfStorage), lhsDaysOfStorage, rhsDaysOfStorage)) {
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
            String theManureLitterProcessedWastewaterStorageType;
            theManureLitterProcessedWastewaterStorageType = this.getManureLitterProcessedWastewaterStorageType();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "manureLitterProcessedWastewaterStorageType", theManureLitterProcessedWastewaterStorageType), currentHashCode, theManureLitterProcessedWastewaterStorageType);
        }
        {
            String theOtherStorageTypeName;
            theOtherStorageTypeName = this.getOtherStorageTypeName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherStorageTypeName", theOtherStorageTypeName), currentHashCode, theOtherStorageTypeName);
        }
        {
            Integer theStorageTotalCapacityMeasure;
            theStorageTotalCapacityMeasure = this.getStorageTotalCapacityMeasure();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "storageTotalCapacityMeasure", theStorageTotalCapacityMeasure), currentHashCode, theStorageTotalCapacityMeasure);
        }
        {
            Integer theDaysOfStorage;
            theDaysOfStorage = this.getDaysOfStorage();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "daysOfStorage", theDaysOfStorage), currentHashCode, theDaysOfStorage);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

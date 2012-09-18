//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
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
 * <p>Java class for SICCodeDetails complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SICCodeDetails">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SICCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SICPrimaryIndicatorCode"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SICCodeDetails", propOrder = {
    "sicCode",
    "sicPrimaryIndicatorCode"
})
@Entity(name = "SICCodeDetails")
@Table(name = "ICS_SIC_CODE")
@Inheritance(strategy = InheritanceType.JOINED)
public class SICCodeDetails
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SICCode", required = true)
    protected String sicCode;
    @XmlElement(name = "SICPrimaryIndicatorCode", required = true)
    protected String sicPrimaryIndicatorCode;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the sicCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SIC_CODE", columnDefinition = "char(4)", length = 4)
    public String getSICCode() {
        return sicCode;
    }

    /**
     * Sets the value of the sicCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSICCode(String value) {
        this.sicCode = value;
    }

    @Transient
    public boolean isSetSICCode() {
        return (this.sicCode!= null);
    }

    /**
     * Gets the value of the sicPrimaryIndicatorCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SIC_PRIMARY_IND_CODE", columnDefinition = "char(1)", length = 1)
    public String getSICPrimaryIndicatorCode() {
        return sicPrimaryIndicatorCode;
    }

    /**
     * Sets the value of the sicPrimaryIndicatorCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSICPrimaryIndicatorCode(String value) {
        this.sicPrimaryIndicatorCode = value;
    }

    @Transient
    public boolean isSetSICPrimaryIndicatorCode() {
        return (this.sicPrimaryIndicatorCode!= null);
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
    @Column(name = "ICS_SIC_CODE_ID")
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
        if (!(object instanceof SICCodeDetails)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SICCodeDetails that = ((SICCodeDetails) object);
        {
            String lhsSICCode;
            lhsSICCode = this.getSICCode();
            String rhsSICCode;
            rhsSICCode = that.getSICCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "sicCode", lhsSICCode), LocatorUtils.property(thatLocator, "sicCode", rhsSICCode), lhsSICCode, rhsSICCode)) {
                return false;
            }
        }
        {
            String lhsSICPrimaryIndicatorCode;
            lhsSICPrimaryIndicatorCode = this.getSICPrimaryIndicatorCode();
            String rhsSICPrimaryIndicatorCode;
            rhsSICPrimaryIndicatorCode = that.getSICPrimaryIndicatorCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "sicPrimaryIndicatorCode", lhsSICPrimaryIndicatorCode), LocatorUtils.property(thatLocator, "sicPrimaryIndicatorCode", rhsSICPrimaryIndicatorCode), lhsSICPrimaryIndicatorCode, rhsSICPrimaryIndicatorCode)) {
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
            String theSICCode;
            theSICCode = this.getSICCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "sicCode", theSICCode), currentHashCode, theSICCode);
        }
        {
            String theSICPrimaryIndicatorCode;
            theSICPrimaryIndicatorCode = this.getSICPrimaryIndicatorCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "sicPrimaryIndicatorCode", theSICPrimaryIndicatorCode), currentHashCode, theSICPrimaryIndicatorCode);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

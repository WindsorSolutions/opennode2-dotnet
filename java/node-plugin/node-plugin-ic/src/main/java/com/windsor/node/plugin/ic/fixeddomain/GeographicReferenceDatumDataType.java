//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2013.08.26 at 02:36:56 PM PDT 
//


package com.windsor.node.plugin.ic.fixeddomain;

import java.io.Serializable;
import javax.persistence.Basic;
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
 * <p>Java class for GeographicReferenceDatumDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="GeographicReferenceDatumDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}GeographicReferenceDatumCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}GeographicReferenceDatumCodeListIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}GeographicReferenceDatumName" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "GeographicReferenceDatumDataType", propOrder = {
    "geographicReferenceDatumCode",
    "geographicReferenceDatumCodeListIdentifier",
    "geographicReferenceDatumName"
})
@Entity(name = "GeographicReferenceDatumDataType")
@Table(name = "IC_GEOGRAPHIC_REFERENCE_DATUM_DATA_TYPE")
@Inheritance(strategy = InheritanceType.JOINED)
public class GeographicReferenceDatumDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "GeographicReferenceDatumCode")
    protected String geographicReferenceDatumCode;
    @XmlElement(name = "GeographicReferenceDatumCodeListIdentifier")
    protected GeographicReferenceDatumCodeListIdentifierDataType geographicReferenceDatumCodeListIdentifier;
    @XmlElement(name = "GeographicReferenceDatumName")
    protected String geographicReferenceDatumName;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the geographicReferenceDatumCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "GEOGRAPHIC_REFERENCE_DATUM_CODE", length = 255)
    public String getGeographicReferenceDatumCode() {
        return geographicReferenceDatumCode;
    }

    /**
     * Sets the value of the geographicReferenceDatumCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGeographicReferenceDatumCode(String value) {
        this.geographicReferenceDatumCode = value;
    }

    @Transient
    public boolean isSetGeographicReferenceDatumCode() {
        return (this.geographicReferenceDatumCode!= null);
    }

    /**
     * Gets the value of the geographicReferenceDatumCodeListIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link GeographicReferenceDatumCodeListIdentifierDataType }
     *     
     */
    @OneToOne(targetEntity = GeographicReferenceDatumCodeListIdentifierDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "GEOGRAPHIC_REFERENCE_DATUM_DATA_TYPE_ID")
    public GeographicReferenceDatumCodeListIdentifierDataType getGeographicReferenceDatumCodeListIdentifier() {
        return geographicReferenceDatumCodeListIdentifier;
    }

    /**
     * Sets the value of the geographicReferenceDatumCodeListIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link GeographicReferenceDatumCodeListIdentifierDataType }
     *     
     */
    public void setGeographicReferenceDatumCodeListIdentifier(GeographicReferenceDatumCodeListIdentifierDataType value) {
        this.geographicReferenceDatumCodeListIdentifier = value;
    }

    @Transient
    public boolean isSetGeographicReferenceDatumCodeListIdentifier() {
        return (this.geographicReferenceDatumCodeListIdentifier!= null);
    }

    /**
     * Gets the value of the geographicReferenceDatumName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "GEOGRAPHIC_REFERENCE_DATUM_NAME", length = 255)
    public String getGeographicReferenceDatumName() {
        return geographicReferenceDatumName;
    }

    /**
     * Sets the value of the geographicReferenceDatumName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGeographicReferenceDatumName(String value) {
        this.geographicReferenceDatumName = value;
    }

    @Transient
    public boolean isSetGeographicReferenceDatumName() {
        return (this.geographicReferenceDatumName!= null);
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
    @Column(name = "GEOGRAPHIC_REFERENCE_DATUM_DATA_TYPE_ID")
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
        if (!(object instanceof GeographicReferenceDatumDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final GeographicReferenceDatumDataType that = ((GeographicReferenceDatumDataType) object);
        {
            String lhsGeographicReferenceDatumCode;
            lhsGeographicReferenceDatumCode = this.getGeographicReferenceDatumCode();
            String rhsGeographicReferenceDatumCode;
            rhsGeographicReferenceDatumCode = that.getGeographicReferenceDatumCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "geographicReferenceDatumCode", lhsGeographicReferenceDatumCode), LocatorUtils.property(thatLocator, "geographicReferenceDatumCode", rhsGeographicReferenceDatumCode), lhsGeographicReferenceDatumCode, rhsGeographicReferenceDatumCode)) {
                return false;
            }
        }
        {
            GeographicReferenceDatumCodeListIdentifierDataType lhsGeographicReferenceDatumCodeListIdentifier;
            lhsGeographicReferenceDatumCodeListIdentifier = this.getGeographicReferenceDatumCodeListIdentifier();
            GeographicReferenceDatumCodeListIdentifierDataType rhsGeographicReferenceDatumCodeListIdentifier;
            rhsGeographicReferenceDatumCodeListIdentifier = that.getGeographicReferenceDatumCodeListIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "geographicReferenceDatumCodeListIdentifier", lhsGeographicReferenceDatumCodeListIdentifier), LocatorUtils.property(thatLocator, "geographicReferenceDatumCodeListIdentifier", rhsGeographicReferenceDatumCodeListIdentifier), lhsGeographicReferenceDatumCodeListIdentifier, rhsGeographicReferenceDatumCodeListIdentifier)) {
                return false;
            }
        }
        {
            String lhsGeographicReferenceDatumName;
            lhsGeographicReferenceDatumName = this.getGeographicReferenceDatumName();
            String rhsGeographicReferenceDatumName;
            rhsGeographicReferenceDatumName = that.getGeographicReferenceDatumName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "geographicReferenceDatumName", lhsGeographicReferenceDatumName), LocatorUtils.property(thatLocator, "geographicReferenceDatumName", rhsGeographicReferenceDatumName), lhsGeographicReferenceDatumName, rhsGeographicReferenceDatumName)) {
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
            String theGeographicReferenceDatumCode;
            theGeographicReferenceDatumCode = this.getGeographicReferenceDatumCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "geographicReferenceDatumCode", theGeographicReferenceDatumCode), currentHashCode, theGeographicReferenceDatumCode);
        }
        {
            GeographicReferenceDatumCodeListIdentifierDataType theGeographicReferenceDatumCodeListIdentifier;
            theGeographicReferenceDatumCodeListIdentifier = this.getGeographicReferenceDatumCodeListIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "geographicReferenceDatumCodeListIdentifier", theGeographicReferenceDatumCodeListIdentifier), currentHashCode, theGeographicReferenceDatumCodeListIdentifier);
        }
        {
            String theGeographicReferenceDatumName;
            theGeographicReferenceDatumName = this.getGeographicReferenceDatumName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "geographicReferenceDatumName", theGeographicReferenceDatumName), currentHashCode, theGeographicReferenceDatumName);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;
import org.jvnet.hyperjaxb3.xml.bind.annotation.adapters.XMLGregorianCalendarAsDate;
import org.jvnet.hyperjaxb3.xml.bind.annotation.adapters.XmlAdapterUtils;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * Used to define the acreage of a handler or area.
 * 
 * <p>Java class for AreaAcreageDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AreaAcreageDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AreaAcreageMeasure"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AreaMeasureSourceDataOwnerCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AreaMeasureSourceCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AreaMeasureSourceText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}AreaMeasureDate"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AreaAcreageDataType", propOrder = {
    "areaAcreageMeasure",
    "areaMeasureSourceDataOwnerCode",
    "areaMeasureSourceCode",
    "areaMeasureSourceText",
    "areaMeasureDate"
})
@Entity(name = "AreaAcreageDataType")
@Table(name = "RCRA_AREAACREAGE")
@Inheritance(strategy = InheritanceType.JOINED)
public class AreaAcreageDataType
    implements Equals, HashCode
{

    @XmlElement(name = "AreaAcreageMeasure", required = true)
    protected BigDecimal areaAcreageMeasure;
    @XmlElement(name = "AreaMeasureSourceDataOwnerCode", required = true)
    protected String areaMeasureSourceDataOwnerCode;
    @XmlElement(name = "AreaMeasureSourceCode", required = true)
    protected String areaMeasureSourceCode;
    @XmlElement(name = "AreaMeasureSourceText")
    protected String areaMeasureSourceText;
    @XmlElement(name = "AreaMeasureDate", required = true)
    protected XMLGregorianCalendar areaMeasureDate;
    @XmlAttribute(name = "Id")
    protected Long id;

    /**
     * Gets the value of the areaAcreageMeasure property.
     * 
     * @return
     *     possible object is
     *     {@link BigDecimal }
     *     
     */
    @Basic
    @Column(name = "AREAACREAGEMSR", precision = 13, scale = 2)
    public BigDecimal getAreaAcreageMeasure() {
        return areaAcreageMeasure;
    }

    /**
     * Sets the value of the areaAcreageMeasure property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigDecimal }
     *     
     */
    public void setAreaAcreageMeasure(BigDecimal value) {
        this.areaAcreageMeasure = value;
    }

    /**
     * Gets the value of the areaMeasureSourceDataOwnerCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AREAMSRSOURCEDATOWNRCODE", length = 2)
    public String getAreaMeasureSourceDataOwnerCode() {
        return areaMeasureSourceDataOwnerCode;
    }

    /**
     * Sets the value of the areaMeasureSourceDataOwnerCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAreaMeasureSourceDataOwnerCode(String value) {
        this.areaMeasureSourceDataOwnerCode = value;
    }

    /**
     * Gets the value of the areaMeasureSourceCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AREAMSRSOURCECODE", length = 4)
    public String getAreaMeasureSourceCode() {
        return areaMeasureSourceCode;
    }

    /**
     * Sets the value of the areaMeasureSourceCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAreaMeasureSourceCode(String value) {
        this.areaMeasureSourceCode = value;
    }

    /**
     * Gets the value of the areaMeasureSourceText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AREAMSRSOURCETXT", length = 255)
    public String getAreaMeasureSourceText() {
        return areaMeasureSourceText;
    }

    /**
     * Sets the value of the areaMeasureSourceText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAreaMeasureSourceText(String value) {
        this.areaMeasureSourceText = value;
    }

    /**
     * Gets the value of the areaMeasureDate property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    @Transient
    public XMLGregorianCalendar getAreaMeasureDate() {
        return areaMeasureDate;
    }

    /**
     * Sets the value of the areaMeasureDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setAreaMeasureDate(XMLGregorianCalendar value) {
        this.areaMeasureDate = value;
    }

    /**
     * Gets the value of the id property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    @Id
    @Column(name = "ID")
    @GeneratedValue(generator = "ColSequence", strategy = GenerationType.AUTO)
    @SequenceGenerator(name = "ColSequence", sequenceName = "COLUMN_ID_SEQUENCE", allocationSize = 1)
    public Long getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setId(Long value) {
        this.id = value;
    }

    @Basic
    @Column(name = "AREAMSRDATEITEM")
    @Temporal(TemporalType.DATE)
    public Date getAreaMeasureDateItem() {
        return XmlAdapterUtils.unmarshall(XMLGregorianCalendarAsDate.class, this.getAreaMeasureDate());
    }

    public void setAreaMeasureDateItem(Date target) {
        setAreaMeasureDate(XmlAdapterUtils.marshall(XMLGregorianCalendarAsDate.class, target));
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof AreaAcreageDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final AreaAcreageDataType that = ((AreaAcreageDataType) object);
        {
            BigDecimal lhsAreaAcreageMeasure;
            lhsAreaAcreageMeasure = this.getAreaAcreageMeasure();
            BigDecimal rhsAreaAcreageMeasure;
            rhsAreaAcreageMeasure = that.getAreaAcreageMeasure();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "areaAcreageMeasure", lhsAreaAcreageMeasure), LocatorUtils.property(thatLocator, "areaAcreageMeasure", rhsAreaAcreageMeasure), lhsAreaAcreageMeasure, rhsAreaAcreageMeasure)) {
                return false;
            }
        }
        {
            String lhsAreaMeasureSourceDataOwnerCode;
            lhsAreaMeasureSourceDataOwnerCode = this.getAreaMeasureSourceDataOwnerCode();
            String rhsAreaMeasureSourceDataOwnerCode;
            rhsAreaMeasureSourceDataOwnerCode = that.getAreaMeasureSourceDataOwnerCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "areaMeasureSourceDataOwnerCode", lhsAreaMeasureSourceDataOwnerCode), LocatorUtils.property(thatLocator, "areaMeasureSourceDataOwnerCode", rhsAreaMeasureSourceDataOwnerCode), lhsAreaMeasureSourceDataOwnerCode, rhsAreaMeasureSourceDataOwnerCode)) {
                return false;
            }
        }
        {
            String lhsAreaMeasureSourceCode;
            lhsAreaMeasureSourceCode = this.getAreaMeasureSourceCode();
            String rhsAreaMeasureSourceCode;
            rhsAreaMeasureSourceCode = that.getAreaMeasureSourceCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "areaMeasureSourceCode", lhsAreaMeasureSourceCode), LocatorUtils.property(thatLocator, "areaMeasureSourceCode", rhsAreaMeasureSourceCode), lhsAreaMeasureSourceCode, rhsAreaMeasureSourceCode)) {
                return false;
            }
        }
        {
            String lhsAreaMeasureSourceText;
            lhsAreaMeasureSourceText = this.getAreaMeasureSourceText();
            String rhsAreaMeasureSourceText;
            rhsAreaMeasureSourceText = that.getAreaMeasureSourceText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "areaMeasureSourceText", lhsAreaMeasureSourceText), LocatorUtils.property(thatLocator, "areaMeasureSourceText", rhsAreaMeasureSourceText), lhsAreaMeasureSourceText, rhsAreaMeasureSourceText)) {
                return false;
            }
        }
        {
            XMLGregorianCalendar lhsAreaMeasureDate;
            lhsAreaMeasureDate = this.getAreaMeasureDate();
            XMLGregorianCalendar rhsAreaMeasureDate;
            rhsAreaMeasureDate = that.getAreaMeasureDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "areaMeasureDate", lhsAreaMeasureDate), LocatorUtils.property(thatLocator, "areaMeasureDate", rhsAreaMeasureDate), lhsAreaMeasureDate, rhsAreaMeasureDate)) {
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
            BigDecimal theAreaAcreageMeasure;
            theAreaAcreageMeasure = this.getAreaAcreageMeasure();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "areaAcreageMeasure", theAreaAcreageMeasure), currentHashCode, theAreaAcreageMeasure);
        }
        {
            String theAreaMeasureSourceDataOwnerCode;
            theAreaMeasureSourceDataOwnerCode = this.getAreaMeasureSourceDataOwnerCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "areaMeasureSourceDataOwnerCode", theAreaMeasureSourceDataOwnerCode), currentHashCode, theAreaMeasureSourceDataOwnerCode);
        }
        {
            String theAreaMeasureSourceCode;
            theAreaMeasureSourceCode = this.getAreaMeasureSourceCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "areaMeasureSourceCode", theAreaMeasureSourceCode), currentHashCode, theAreaMeasureSourceCode);
        }
        {
            String theAreaMeasureSourceText;
            theAreaMeasureSourceText = this.getAreaMeasureSourceText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "areaMeasureSourceText", theAreaMeasureSourceText), currentHashCode, theAreaMeasureSourceText);
        }
        {
            XMLGregorianCalendar theAreaMeasureDate;
            theAreaMeasureDate = this.getAreaMeasureDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "areaMeasureDate", theAreaMeasureDate), currentHashCode, theAreaMeasureDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

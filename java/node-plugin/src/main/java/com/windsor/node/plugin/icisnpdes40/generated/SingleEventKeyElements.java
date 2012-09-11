//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlSeeAlso;
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
 * <p>Java class for SingleEventKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SingleEventKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}SingleEventKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SingleEventKeyElements", propOrder = {
    "permitIdentifier",
    "singleEventViolationCode",
    "singleEventViolationDate"
})
@XmlSeeAlso({
    SingleEventViolation.class,
    SingleEventsViolation.class
})
@MappedSuperclass
public class SingleEventKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "SingleEventViolationCode", required = true)
    protected String singleEventViolationCode;
    @XmlElement(name = "SingleEventViolationDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date singleEventViolationDate;

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
     * Gets the value of the singleEventViolationCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SNGL_EVT_VIOL_CODE", length = 5)
    public String getSingleEventViolationCode() {
        return singleEventViolationCode;
    }

    /**
     * Sets the value of the singleEventViolationCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSingleEventViolationCode(String value) {
        this.singleEventViolationCode = value;
    }

    @Transient
    public boolean isSetSingleEventViolationCode() {
        return (this.singleEventViolationCode!= null);
    }

    /**
     * Gets the value of the singleEventViolationDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SNGL_EVT_VIOL_DATE")
    @Temporal(TemporalType.DATE)
    public Date getSingleEventViolationDate() {
        return singleEventViolationDate;
    }

    /**
     * Sets the value of the singleEventViolationDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSingleEventViolationDate(Date value) {
        this.singleEventViolationDate = value;
    }

    @Transient
    public boolean isSetSingleEventViolationDate() {
        return (this.singleEventViolationDate!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SingleEventKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SingleEventKeyElements that = ((SingleEventKeyElements) object);
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
            String lhsSingleEventViolationCode;
            lhsSingleEventViolationCode = this.getSingleEventViolationCode();
            String rhsSingleEventViolationCode;
            rhsSingleEventViolationCode = that.getSingleEventViolationCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "singleEventViolationCode", lhsSingleEventViolationCode), LocatorUtils.property(thatLocator, "singleEventViolationCode", rhsSingleEventViolationCode), lhsSingleEventViolationCode, rhsSingleEventViolationCode)) {
                return false;
            }
        }
        {
            Date lhsSingleEventViolationDate;
            lhsSingleEventViolationDate = this.getSingleEventViolationDate();
            Date rhsSingleEventViolationDate;
            rhsSingleEventViolationDate = that.getSingleEventViolationDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "singleEventViolationDate", lhsSingleEventViolationDate), LocatorUtils.property(thatLocator, "singleEventViolationDate", rhsSingleEventViolationDate), lhsSingleEventViolationDate, rhsSingleEventViolationDate)) {
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
            String theSingleEventViolationCode;
            theSingleEventViolationCode = this.getSingleEventViolationCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "singleEventViolationCode", theSingleEventViolationCode), currentHashCode, theSingleEventViolationCode);
        }
        {
            Date theSingleEventViolationDate;
            theSingleEventViolationDate = this.getSingleEventViolationDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "singleEventViolationDate", theSingleEventViolationDate), currentHashCode, theSingleEventViolationDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

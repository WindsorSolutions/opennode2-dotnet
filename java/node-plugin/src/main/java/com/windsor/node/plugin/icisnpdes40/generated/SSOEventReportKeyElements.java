//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
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
 * <p>Java class for SSOEventReportKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SSOEventReportKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}SSOEventReportKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SSOEventReportKeyElements", propOrder = {
    "permitIdentifier",
    "ssoEventDate",
    "ssoEventID"
})
@XmlSeeAlso({
    SSOEventReport.class
})
@MappedSuperclass
public class SSOEventReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "SSOEventDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date ssoEventDate;
    @XmlElement(name = "SSOEventID")
    protected int ssoEventID;

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
     * Gets the value of the ssoEventDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SSO_EVT_DATE")
    @Temporal(TemporalType.DATE)
    public Date getSSOEventDate() {
        return ssoEventDate;
    }

    /**
     * Sets the value of the ssoEventDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSSOEventDate(Date value) {
        this.ssoEventDate = value;
    }

    @Transient
    public boolean isSetSSOEventDate() {
        return (this.ssoEventDate!= null);
    }

    /**
     * Gets the value of the ssoEventID property.
     * 
     */
    @Basic
    @Column(name = "SSO_EVT_ID", precision = 20, scale = 0)
    public int getSSOEventID() {
        return ssoEventID;
    }

    /**
     * Sets the value of the ssoEventID property.
     * 
     */
    public void setSSOEventID(int value) {
        this.ssoEventID = value;
    }

    @Transient
    public boolean isSetSSOEventID() {
        return true;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SSOEventReportKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SSOEventReportKeyElements that = ((SSOEventReportKeyElements) object);
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
            Date lhsSSOEventDate;
            lhsSSOEventDate = this.getSSOEventDate();
            Date rhsSSOEventDate;
            rhsSSOEventDate = that.getSSOEventDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoEventDate", lhsSSOEventDate), LocatorUtils.property(thatLocator, "ssoEventDate", rhsSSOEventDate), lhsSSOEventDate, rhsSSOEventDate)) {
                return false;
            }
        }
        {
            int lhsSSOEventID;
            lhsSSOEventID = (this.isSetSSOEventID()?this.getSSOEventID(): 0);
            int rhsSSOEventID;
            rhsSSOEventID = (that.isSetSSOEventID()?that.getSSOEventID(): 0);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoEventID", lhsSSOEventID), LocatorUtils.property(thatLocator, "ssoEventID", rhsSSOEventID), lhsSSOEventID, rhsSSOEventID)) {
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
            Date theSSOEventDate;
            theSSOEventDate = this.getSSOEventDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoEventDate", theSSOEventDate), currentHashCode, theSSOEventDate);
        }
        {
            int theSSOEventID;
            theSSOEventID = (this.isSetSSOEventID()?this.getSSOEventID(): 0);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoEventID", theSSOEventID), currentHashCode, theSSOEventID);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

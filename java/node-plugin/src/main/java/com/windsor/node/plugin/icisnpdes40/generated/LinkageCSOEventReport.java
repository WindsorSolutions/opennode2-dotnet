//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.DateAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for LinkageCSOEventReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LinkageCSOEventReport">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}CSOEventReportKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LinkageCSOEventReport", propOrder = {
    "permitIdentifier",
    "csoEventDate",
    "csoEventID"
})
@Entity(name = "LinkageCSOEventReport")
@Table(name = "ICS_LNK_CSO_EVT_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class LinkageCSOEventReport
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "CSOEventDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date csoEventDate;
    @XmlElement(name = "CSOEventID")
    protected int csoEventID;
    @XmlTransient
    protected String dbid;

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
     * Gets the value of the csoEventDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CSO_EVT_DATE")
    @Temporal(TemporalType.DATE)
    public Date getCSOEventDate() {
        return csoEventDate;
    }

    /**
     * Sets the value of the csoEventDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCSOEventDate(Date value) {
        this.csoEventDate = value;
    }

    @Transient
    public boolean isSetCSOEventDate() {
        return (this.csoEventDate!= null);
    }

    /**
     * Gets the value of the csoEventID property.
     * 
     */
    @Basic
    @Column(name = "CSO_EVT_ID", precision = 20, scale = 0)
    public int getCSOEventID() {
        return csoEventID;
    }

    /**
     * Sets the value of the csoEventID property.
     * 
     */
    public void setCSOEventID(int value) {
        this.csoEventID = value;
    }

    @Transient
    public boolean isSetCSOEventID() {
        return true;
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
    @Column(name = "ICS_CMPL_MON_LNK_ID")
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
        if (!(object instanceof LinkageCSOEventReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final LinkageCSOEventReport that = ((LinkageCSOEventReport) object);
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
            Date lhsCSOEventDate;
            lhsCSOEventDate = this.getCSOEventDate();
            Date rhsCSOEventDate;
            rhsCSOEventDate = that.getCSOEventDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "csoEventDate", lhsCSOEventDate), LocatorUtils.property(thatLocator, "csoEventDate", rhsCSOEventDate), lhsCSOEventDate, rhsCSOEventDate)) {
                return false;
            }
        }
        {
            int lhsCSOEventID;
            lhsCSOEventID = (this.isSetCSOEventID()?this.getCSOEventID(): 0);
            int rhsCSOEventID;
            rhsCSOEventID = (that.isSetCSOEventID()?that.getCSOEventID(): 0);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "csoEventID", lhsCSOEventID), LocatorUtils.property(thatLocator, "csoEventID", rhsCSOEventID), lhsCSOEventID, rhsCSOEventID)) {
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
            Date theCSOEventDate;
            theCSOEventDate = this.getCSOEventDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "csoEventDate", theCSOEventDate), currentHashCode, theCSOEventDate);
        }
        {
            int theCSOEventID;
            theCSOEventID = (this.isSetCSOEventID()?this.getCSOEventID(): 0);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "csoEventID", theCSOEventID), currentHashCode, theCSOEventID);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

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
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for EnforcementAgency complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="EnforcementAgency">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}EnforcementAgencyTypeCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}AgencyLeadIndicator"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "EnforcementAgency", propOrder = {
    "enforcementAgencyTypeCode",
    "agencyLeadIndicator"
})
@Entity(name = "EnforcementAgency")
@Table(name = "ICS_ENFRC_AGNCY")
@Inheritance(strategy = InheritanceType.JOINED)
public class EnforcementAgency
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "EnforcementAgencyTypeCode", required = true)
    protected String enforcementAgencyTypeCode;
    @XmlElement(name = "AgencyLeadIndicator", required = true)
    protected String agencyLeadIndicator;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the enforcementAgencyTypeCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ENFRC_AGNCY_TYPE_CODE", length = 3)
    public String getEnforcementAgencyTypeCode() {
        return enforcementAgencyTypeCode;
    }

    /**
     * Sets the value of the enforcementAgencyTypeCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEnforcementAgencyTypeCode(String value) {
        this.enforcementAgencyTypeCode = value;
    }

    @Transient
    public boolean isSetEnforcementAgencyTypeCode() {
        return (this.enforcementAgencyTypeCode!= null);
    }

    /**
     * Gets the value of the agencyLeadIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AGNCY_LEAD_IND", columnDefinition = "char(1)", length = 1)
    public String getAgencyLeadIndicator() {
        return agencyLeadIndicator;
    }

    /**
     * Sets the value of the agencyLeadIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAgencyLeadIndicator(String value) {
        this.agencyLeadIndicator = value;
    }

    @Transient
    public boolean isSetAgencyLeadIndicator() {
        return (this.agencyLeadIndicator!= null);
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
    @Column(name = "ICS_ENFRC_AGNCY_ID")
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
        if (!(object instanceof EnforcementAgency)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final EnforcementAgency that = ((EnforcementAgency) object);
        {
            String lhsEnforcementAgencyTypeCode;
            lhsEnforcementAgencyTypeCode = this.getEnforcementAgencyTypeCode();
            String rhsEnforcementAgencyTypeCode;
            rhsEnforcementAgencyTypeCode = that.getEnforcementAgencyTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "enforcementAgencyTypeCode", lhsEnforcementAgencyTypeCode), LocatorUtils.property(thatLocator, "enforcementAgencyTypeCode", rhsEnforcementAgencyTypeCode), lhsEnforcementAgencyTypeCode, rhsEnforcementAgencyTypeCode)) {
                return false;
            }
        }
        {
            String lhsAgencyLeadIndicator;
            lhsAgencyLeadIndicator = this.getAgencyLeadIndicator();
            String rhsAgencyLeadIndicator;
            rhsAgencyLeadIndicator = that.getAgencyLeadIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "agencyLeadIndicator", lhsAgencyLeadIndicator), LocatorUtils.property(thatLocator, "agencyLeadIndicator", rhsAgencyLeadIndicator), lhsAgencyLeadIndicator, rhsAgencyLeadIndicator)) {
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
            String theEnforcementAgencyTypeCode;
            theEnforcementAgencyTypeCode = this.getEnforcementAgencyTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "enforcementAgencyTypeCode", theEnforcementAgencyTypeCode), currentHashCode, theEnforcementAgencyTypeCode);
        }
        {
            String theAgencyLeadIndicator;
            theAgencyLeadIndicator = this.getAgencyLeadIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "agencyLeadIndicator", theAgencyLeadIndicator), currentHashCode, theAgencyLeadIndicator);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

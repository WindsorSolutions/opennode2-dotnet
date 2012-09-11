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
 * <p>Java class for LinkageStateComplianceMonitoring complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LinkageStateComplianceMonitoring">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}ComplianceMonitoringKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LinkageStateComplianceMonitoring", propOrder = {
    "permitIdentifier",
    "complianceMonitoringCategoryCode",
    "complianceMonitoringDate"
})
@Entity(name = "LinkageStateComplianceMonitoring")
@Table(name = "ICS_LNK_ST_CMPL_MON")
@Inheritance(strategy = InheritanceType.JOINED)
public class LinkageStateComplianceMonitoring
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "ComplianceMonitoringCategoryCode", required = true)
    protected String complianceMonitoringCategoryCode;
    @XmlElement(name = "ComplianceMonitoringDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date complianceMonitoringDate;
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
     * Gets the value of the complianceMonitoringCategoryCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CMPL_MON_CATG_CODE", length = 3)
    public String getComplianceMonitoringCategoryCode() {
        return complianceMonitoringCategoryCode;
    }

    /**
     * Sets the value of the complianceMonitoringCategoryCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setComplianceMonitoringCategoryCode(String value) {
        this.complianceMonitoringCategoryCode = value;
    }

    @Transient
    public boolean isSetComplianceMonitoringCategoryCode() {
        return (this.complianceMonitoringCategoryCode!= null);
    }

    /**
     * Gets the value of the complianceMonitoringDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CMPL_MON_DATE")
    @Temporal(TemporalType.DATE)
    public Date getComplianceMonitoringDate() {
        return complianceMonitoringDate;
    }

    /**
     * Sets the value of the complianceMonitoringDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setComplianceMonitoringDate(Date value) {
        this.complianceMonitoringDate = value;
    }

    @Transient
    public boolean isSetComplianceMonitoringDate() {
        return (this.complianceMonitoringDate!= null);
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
        if (!(object instanceof LinkageStateComplianceMonitoring)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final LinkageStateComplianceMonitoring that = ((LinkageStateComplianceMonitoring) object);
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
            String lhsComplianceMonitoringCategoryCode;
            lhsComplianceMonitoringCategoryCode = this.getComplianceMonitoringCategoryCode();
            String rhsComplianceMonitoringCategoryCode;
            rhsComplianceMonitoringCategoryCode = that.getComplianceMonitoringCategoryCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "complianceMonitoringCategoryCode", lhsComplianceMonitoringCategoryCode), LocatorUtils.property(thatLocator, "complianceMonitoringCategoryCode", rhsComplianceMonitoringCategoryCode), lhsComplianceMonitoringCategoryCode, rhsComplianceMonitoringCategoryCode)) {
                return false;
            }
        }
        {
            Date lhsComplianceMonitoringDate;
            lhsComplianceMonitoringDate = this.getComplianceMonitoringDate();
            Date rhsComplianceMonitoringDate;
            rhsComplianceMonitoringDate = that.getComplianceMonitoringDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "complianceMonitoringDate", lhsComplianceMonitoringDate), LocatorUtils.property(thatLocator, "complianceMonitoringDate", rhsComplianceMonitoringDate), lhsComplianceMonitoringDate, rhsComplianceMonitoringDate)) {
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
            String theComplianceMonitoringCategoryCode;
            theComplianceMonitoringCategoryCode = this.getComplianceMonitoringCategoryCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "complianceMonitoringCategoryCode", theComplianceMonitoringCategoryCode), currentHashCode, theComplianceMonitoringCategoryCode);
        }
        {
            Date theComplianceMonitoringDate;
            theComplianceMonitoringDate = this.getComplianceMonitoringDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "complianceMonitoringDate", theComplianceMonitoringDate), currentHashCode, theComplianceMonitoringDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

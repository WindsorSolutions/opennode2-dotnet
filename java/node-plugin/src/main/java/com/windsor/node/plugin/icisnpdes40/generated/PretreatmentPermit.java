//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.AssociationOverride;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.Embedded;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
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
 * <p>Java class for PretreatmentPermit complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PretreatmentPermit">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}BasicPermitKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PretreatmentProgramRequiredIndicatorCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ControlAuthorityStateAgencyCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ControlAuthorityRegionalAgencyCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ControlAuthorityNPDESIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PretreatmentProgramApprovedDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PretreatmentContact" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PretreatmentPermit", propOrder = {
    "pretreatmentProgramRequiredIndicatorCode",
    "controlAuthorityStateAgencyCode",
    "controlAuthorityRegionalAgencyCode",
    "controlAuthorityNPDESIdentifier",
    "pretreatmentProgramApprovedDate",
    "pretreatmentContact"
})
@Embeddable
public class PretreatmentPermit
    extends BasicPermitKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PretreatmentProgramRequiredIndicatorCode")
    protected PretreatmentProgramRequiredIndicatorType pretreatmentProgramRequiredIndicatorCode;
    @XmlElement(name = "ControlAuthorityStateAgencyCode")
    protected String controlAuthorityStateAgencyCode;
    @XmlElement(name = "ControlAuthorityRegionalAgencyCode")
    protected String controlAuthorityRegionalAgencyCode;
    @XmlElement(name = "ControlAuthorityNPDESIdentifier")
    protected String controlAuthorityNPDESIdentifier;
    @XmlElement(name = "PretreatmentProgramApprovedDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date pretreatmentProgramApprovedDate;
    @XmlElement(name = "PretreatmentContact")
    protected PretreatmentContact pretreatmentContact;

    /**
     * Gets the value of the pretreatmentProgramRequiredIndicatorCode property.
     * 
     * @return
     *     possible object is
     *     {@link PretreatmentProgramRequiredIndicatorType }
     *     
     */
    @Basic
    @Column(name = "PRETR_PROG_REQD_IND_CODE", columnDefinition = "char(1)", length = 1)
    @Enumerated(EnumType.STRING)
    public PretreatmentProgramRequiredIndicatorType getPretreatmentProgramRequiredIndicatorCode() {
        return pretreatmentProgramRequiredIndicatorCode;
    }

    /**
     * Sets the value of the pretreatmentProgramRequiredIndicatorCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link PretreatmentProgramRequiredIndicatorType }
     *     
     */
    public void setPretreatmentProgramRequiredIndicatorCode(PretreatmentProgramRequiredIndicatorType value) {
        this.pretreatmentProgramRequiredIndicatorCode = value;
    }

    @Transient
    public boolean isSetPretreatmentProgramRequiredIndicatorCode() {
        return (this.pretreatmentProgramRequiredIndicatorCode!= null);
    }

    /**
     * Gets the value of the controlAuthorityStateAgencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CONTROL_AUTH_ST_AGNCY_CODE", columnDefinition = "char(2)", length = 2)
    public String getControlAuthorityStateAgencyCode() {
        return controlAuthorityStateAgencyCode;
    }

    /**
     * Sets the value of the controlAuthorityStateAgencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setControlAuthorityStateAgencyCode(String value) {
        this.controlAuthorityStateAgencyCode = value;
    }

    @Transient
    public boolean isSetControlAuthorityStateAgencyCode() {
        return (this.controlAuthorityStateAgencyCode!= null);
    }

    /**
     * Gets the value of the controlAuthorityRegionalAgencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CONTROL_AUTH_RGNL_AGNCY_CODE", length = 2)
    public String getControlAuthorityRegionalAgencyCode() {
        return controlAuthorityRegionalAgencyCode;
    }

    /**
     * Sets the value of the controlAuthorityRegionalAgencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setControlAuthorityRegionalAgencyCode(String value) {
        this.controlAuthorityRegionalAgencyCode = value;
    }

    @Transient
    public boolean isSetControlAuthorityRegionalAgencyCode() {
        return (this.controlAuthorityRegionalAgencyCode!= null);
    }

    /**
     * Gets the value of the controlAuthorityNPDESIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CONTROL_AUTH_NPDES_IDENT", columnDefinition = "char(9)", length = 9)
    public String getControlAuthorityNPDESIdentifier() {
        return controlAuthorityNPDESIdentifier;
    }

    /**
     * Sets the value of the controlAuthorityNPDESIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setControlAuthorityNPDESIdentifier(String value) {
        this.controlAuthorityNPDESIdentifier = value;
    }

    @Transient
    public boolean isSetControlAuthorityNPDESIdentifier() {
        return (this.controlAuthorityNPDESIdentifier!= null);
    }

    /**
     * Gets the value of the pretreatmentProgramApprovedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRETR_PROG_APRVD_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getPretreatmentProgramApprovedDate() {
        return pretreatmentProgramApprovedDate;
    }

    /**
     * Sets the value of the pretreatmentProgramApprovedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPretreatmentProgramApprovedDate(Date value) {
        this.pretreatmentProgramApprovedDate = value;
    }

    @Transient
    public boolean isSetPretreatmentProgramApprovedDate() {
        return (this.pretreatmentProgramApprovedDate!= null);
    }

    /**
     * Gets the value of the pretreatmentContact property.
     * 
     * @return
     *     possible object is
     *     {@link PretreatmentContact }
     *     
     */
    @Embedded
    @AssociationOverride(name = "contact", joinColumns = {
        @JoinColumn(name = "ICS_PRETR_PRMT_ID")
    })
    public PretreatmentContact getPretreatmentContact() {
        return pretreatmentContact;
    }

    /**
     * Sets the value of the pretreatmentContact property.
     * 
     * @param value
     *     allowed object is
     *     {@link PretreatmentContact }
     *     
     */
    public void setPretreatmentContact(PretreatmentContact value) {
        this.pretreatmentContact = value;
    }

    @Transient
    public boolean isSetPretreatmentContact() {
        return (this.pretreatmentContact!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof PretreatmentPermit)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final PretreatmentPermit that = ((PretreatmentPermit) object);
        {
            PretreatmentProgramRequiredIndicatorType lhsPretreatmentProgramRequiredIndicatorCode;
            lhsPretreatmentProgramRequiredIndicatorCode = this.getPretreatmentProgramRequiredIndicatorCode();
            PretreatmentProgramRequiredIndicatorType rhsPretreatmentProgramRequiredIndicatorCode;
            rhsPretreatmentProgramRequiredIndicatorCode = that.getPretreatmentProgramRequiredIndicatorCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pretreatmentProgramRequiredIndicatorCode", lhsPretreatmentProgramRequiredIndicatorCode), LocatorUtils.property(thatLocator, "pretreatmentProgramRequiredIndicatorCode", rhsPretreatmentProgramRequiredIndicatorCode), lhsPretreatmentProgramRequiredIndicatorCode, rhsPretreatmentProgramRequiredIndicatorCode)) {
                return false;
            }
        }
        {
            String lhsControlAuthorityStateAgencyCode;
            lhsControlAuthorityStateAgencyCode = this.getControlAuthorityStateAgencyCode();
            String rhsControlAuthorityStateAgencyCode;
            rhsControlAuthorityStateAgencyCode = that.getControlAuthorityStateAgencyCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "controlAuthorityStateAgencyCode", lhsControlAuthorityStateAgencyCode), LocatorUtils.property(thatLocator, "controlAuthorityStateAgencyCode", rhsControlAuthorityStateAgencyCode), lhsControlAuthorityStateAgencyCode, rhsControlAuthorityStateAgencyCode)) {
                return false;
            }
        }
        {
            String lhsControlAuthorityRegionalAgencyCode;
            lhsControlAuthorityRegionalAgencyCode = this.getControlAuthorityRegionalAgencyCode();
            String rhsControlAuthorityRegionalAgencyCode;
            rhsControlAuthorityRegionalAgencyCode = that.getControlAuthorityRegionalAgencyCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "controlAuthorityRegionalAgencyCode", lhsControlAuthorityRegionalAgencyCode), LocatorUtils.property(thatLocator, "controlAuthorityRegionalAgencyCode", rhsControlAuthorityRegionalAgencyCode), lhsControlAuthorityRegionalAgencyCode, rhsControlAuthorityRegionalAgencyCode)) {
                return false;
            }
        }
        {
            String lhsControlAuthorityNPDESIdentifier;
            lhsControlAuthorityNPDESIdentifier = this.getControlAuthorityNPDESIdentifier();
            String rhsControlAuthorityNPDESIdentifier;
            rhsControlAuthorityNPDESIdentifier = that.getControlAuthorityNPDESIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "controlAuthorityNPDESIdentifier", lhsControlAuthorityNPDESIdentifier), LocatorUtils.property(thatLocator, "controlAuthorityNPDESIdentifier", rhsControlAuthorityNPDESIdentifier), lhsControlAuthorityNPDESIdentifier, rhsControlAuthorityNPDESIdentifier)) {
                return false;
            }
        }
        {
            Date lhsPretreatmentProgramApprovedDate;
            lhsPretreatmentProgramApprovedDate = this.getPretreatmentProgramApprovedDate();
            Date rhsPretreatmentProgramApprovedDate;
            rhsPretreatmentProgramApprovedDate = that.getPretreatmentProgramApprovedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pretreatmentProgramApprovedDate", lhsPretreatmentProgramApprovedDate), LocatorUtils.property(thatLocator, "pretreatmentProgramApprovedDate", rhsPretreatmentProgramApprovedDate), lhsPretreatmentProgramApprovedDate, rhsPretreatmentProgramApprovedDate)) {
                return false;
            }
        }
        {
            PretreatmentContact lhsPretreatmentContact;
            lhsPretreatmentContact = this.getPretreatmentContact();
            PretreatmentContact rhsPretreatmentContact;
            rhsPretreatmentContact = that.getPretreatmentContact();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pretreatmentContact", lhsPretreatmentContact), LocatorUtils.property(thatLocator, "pretreatmentContact", rhsPretreatmentContact), lhsPretreatmentContact, rhsPretreatmentContact)) {
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
        int currentHashCode = super.hashCode(locator, strategy);
        {
            PretreatmentProgramRequiredIndicatorType thePretreatmentProgramRequiredIndicatorCode;
            thePretreatmentProgramRequiredIndicatorCode = this.getPretreatmentProgramRequiredIndicatorCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pretreatmentProgramRequiredIndicatorCode", thePretreatmentProgramRequiredIndicatorCode), currentHashCode, thePretreatmentProgramRequiredIndicatorCode);
        }
        {
            String theControlAuthorityStateAgencyCode;
            theControlAuthorityStateAgencyCode = this.getControlAuthorityStateAgencyCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "controlAuthorityStateAgencyCode", theControlAuthorityStateAgencyCode), currentHashCode, theControlAuthorityStateAgencyCode);
        }
        {
            String theControlAuthorityRegionalAgencyCode;
            theControlAuthorityRegionalAgencyCode = this.getControlAuthorityRegionalAgencyCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "controlAuthorityRegionalAgencyCode", theControlAuthorityRegionalAgencyCode), currentHashCode, theControlAuthorityRegionalAgencyCode);
        }
        {
            String theControlAuthorityNPDESIdentifier;
            theControlAuthorityNPDESIdentifier = this.getControlAuthorityNPDESIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "controlAuthorityNPDESIdentifier", theControlAuthorityNPDESIdentifier), currentHashCode, theControlAuthorityNPDESIdentifier);
        }
        {
            Date thePretreatmentProgramApprovedDate;
            thePretreatmentProgramApprovedDate = this.getPretreatmentProgramApprovedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pretreatmentProgramApprovedDate", thePretreatmentProgramApprovedDate), currentHashCode, thePretreatmentProgramApprovedDate);
        }
        {
            PretreatmentContact thePretreatmentContact;
            thePretreatmentContact = this.getPretreatmentContact();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pretreatmentContact", thePretreatmentContact), currentHashCode, thePretreatmentContact);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

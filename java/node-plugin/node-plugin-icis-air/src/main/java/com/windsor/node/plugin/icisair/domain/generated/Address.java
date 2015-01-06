//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2014.09.02 at 11:05:46 AM PDT 
//


package com.windsor.node.plugin.icisair.domain.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.DateNoTimeZoneAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for Address complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Address">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}AffiliationTypeText"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}OrganizationFormalName"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}OrganizationDUNSNumber" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MailingAddressText"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SupplementalAddressText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MailingAddressCityName"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MailingAddressStateCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MailingAddressZipCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}CountyName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MailingAddressCountryCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}DivisionName" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}LocationProvince" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}Telephone" maxOccurs="3" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}ElectronicAddressText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}StartDateOfAddressAssociation" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}EndDateOfAddressAssociation" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Address", propOrder = {
    "affiliationTypeText",
    "organizationFormalName",
    "organizationDUNSNumber",
    "mailingAddressText",
    "supplementalAddressText",
    "mailingAddressCityName",
    "mailingAddressStateCode",
    "mailingAddressZipCode",
    "countyName",
    "mailingAddressCountryCode",
    "divisionName",
    "locationProvince",
    "telephone",
    "electronicAddressText",
    "startDateOfAddressAssociation",
    "endDateOfAddressAssociation"
})
@Entity(name = "Address")
@Table(name = "ICA_FAC_ADDR")
@Inheritance(strategy = InheritanceType.JOINED)
public class Address
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "AffiliationTypeText", required = true)
    protected String affiliationTypeText;
    @XmlElement(name = "OrganizationFormalName", required = true)
    protected String organizationFormalName;
    @XmlElement(name = "OrganizationDUNSNumber")
    protected String organizationDUNSNumber;
    @XmlElement(name = "MailingAddressText", required = true)
    protected String mailingAddressText;
    @XmlElement(name = "SupplementalAddressText")
    protected String supplementalAddressText;
    @XmlElement(name = "MailingAddressCityName", required = true)
    protected String mailingAddressCityName;
    @XmlElement(name = "MailingAddressStateCode", required = true)
    protected String mailingAddressStateCode;
    @XmlElement(name = "MailingAddressZipCode", required = true)
    protected String mailingAddressZipCode;
    @XmlElement(name = "CountyName")
    protected String countyName;
    @XmlElement(name = "MailingAddressCountryCode")
    protected String mailingAddressCountryCode;
    @XmlElement(name = "DivisionName")
    protected String divisionName;
    @XmlElement(name = "LocationProvince")
    protected String locationProvince;
    @XmlElement(name = "Telephone")
    protected List<Telephone> telephone;
    @XmlElement(name = "ElectronicAddressText")
    protected String electronicAddressText;
    @XmlElement(name = "StartDateOfAddressAssociation", type = String.class)
    @XmlJavaTypeAdapter(DateNoTimeZoneAdapter.class)
    protected Date startDateOfAddressAssociation;
    @XmlElement(name = "EndDateOfAddressAssociation", type = String.class)
    @XmlJavaTypeAdapter(DateNoTimeZoneAdapter.class)
    protected Date endDateOfAddressAssociation;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the affiliationTypeText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "AFFIL_TYPE_TXT", length = 3)
    public String getAffiliationTypeText() {
        return affiliationTypeText;
    }

    /**
     * Sets the value of the affiliationTypeText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAffiliationTypeText(String value) {
        this.affiliationTypeText = value;
    }

    @Transient
    public boolean isSetAffiliationTypeText() {
        return (this.affiliationTypeText!= null);
    }

    /**
     * Gets the value of the organizationFormalName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ORG_FRML_NAME", length = 80)
    public String getOrganizationFormalName() {
        return organizationFormalName;
    }

    /**
     * Sets the value of the organizationFormalName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizationFormalName(String value) {
        this.organizationFormalName = value;
    }

    @Transient
    public boolean isSetOrganizationFormalName() {
        return (this.organizationFormalName!= null);
    }

    /**
     * Gets the value of the organizationDUNSNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ORG_DUNS_NUM", columnDefinition = "char(9)", length = 9)
    public String getOrganizationDUNSNumber() {
        return organizationDUNSNumber;
    }

    /**
     * Sets the value of the organizationDUNSNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizationDUNSNumber(String value) {
        this.organizationDUNSNumber = value;
    }

    @Transient
    public boolean isSetOrganizationDUNSNumber() {
        return (this.organizationDUNSNumber!= null);
    }

    /**
     * Gets the value of the mailingAddressText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MAILING_ADDR_TXT", length = 50)
    public String getMailingAddressText() {
        return mailingAddressText;
    }

    /**
     * Sets the value of the mailingAddressText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMailingAddressText(String value) {
        this.mailingAddressText = value;
    }

    @Transient
    public boolean isSetMailingAddressText() {
        return (this.mailingAddressText!= null);
    }

    /**
     * Gets the value of the supplementalAddressText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SUPPL_ADDR_TXT", length = 50)
    public String getSupplementalAddressText() {
        return supplementalAddressText;
    }

    /**
     * Sets the value of the supplementalAddressText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSupplementalAddressText(String value) {
        this.supplementalAddressText = value;
    }

    @Transient
    public boolean isSetSupplementalAddressText() {
        return (this.supplementalAddressText!= null);
    }

    /**
     * Gets the value of the mailingAddressCityName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MAILING_ADDR_CITY_NAME", length = 30)
    public String getMailingAddressCityName() {
        return mailingAddressCityName;
    }

    /**
     * Sets the value of the mailingAddressCityName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMailingAddressCityName(String value) {
        this.mailingAddressCityName = value;
    }

    @Transient
    public boolean isSetMailingAddressCityName() {
        return (this.mailingAddressCityName!= null);
    }

    /**
     * Gets the value of the mailingAddressStateCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MAILING_ADDR_ST_CODE", columnDefinition = "char(2)", length = 2)
    public String getMailingAddressStateCode() {
        return mailingAddressStateCode;
    }

    /**
     * Sets the value of the mailingAddressStateCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMailingAddressStateCode(String value) {
        this.mailingAddressStateCode = value;
    }

    @Transient
    public boolean isSetMailingAddressStateCode() {
        return (this.mailingAddressStateCode!= null);
    }

    /**
     * Gets the value of the mailingAddressZipCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MAILING_ADDR_ZIP_CODE", length = 14)
    public String getMailingAddressZipCode() {
        return mailingAddressZipCode;
    }

    /**
     * Sets the value of the mailingAddressZipCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMailingAddressZipCode(String value) {
        this.mailingAddressZipCode = value;
    }

    @Transient
    public boolean isSetMailingAddressZipCode() {
        return (this.mailingAddressZipCode!= null);
    }

    /**
     * Gets the value of the countyName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "COUNTY_NAME", length = 35)
    public String getCountyName() {
        return countyName;
    }

    /**
     * Sets the value of the countyName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCountyName(String value) {
        this.countyName = value;
    }

    @Transient
    public boolean isSetCountyName() {
        return (this.countyName!= null);
    }

    /**
     * Gets the value of the mailingAddressCountryCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MAILING_ADDR_COUNTRY_CODE", length = 3)
    public String getMailingAddressCountryCode() {
        return mailingAddressCountryCode;
    }

    /**
     * Sets the value of the mailingAddressCountryCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMailingAddressCountryCode(String value) {
        this.mailingAddressCountryCode = value;
    }

    @Transient
    public boolean isSetMailingAddressCountryCode() {
        return (this.mailingAddressCountryCode!= null);
    }

    /**
     * Gets the value of the divisionName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DIVISION_NAME", length = 50)
    public String getDivisionName() {
        return divisionName;
    }

    /**
     * Sets the value of the divisionName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDivisionName(String value) {
        this.divisionName = value;
    }

    @Transient
    public boolean isSetDivisionName() {
        return (this.divisionName!= null);
    }

    /**
     * Gets the value of the locationProvince property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LOC_PROVINCE", length = 35)
    public String getLocationProvince() {
        return locationProvince;
    }

    /**
     * Sets the value of the locationProvince property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLocationProvince(String value) {
        this.locationProvince = value;
    }

    @Transient
    public boolean isSetLocationProvince() {
        return (this.locationProvince!= null);
    }

    /**
     * Gets the value of the telephone property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the telephone property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getTelephone().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link Telephone }
     * 
     * 
     */
    @OneToMany(targetEntity = Telephone.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICA_FAC_ADDR_ID")
    public List<Telephone> getTelephone() {
        if (telephone == null) {
            telephone = new ArrayList<Telephone>();
        }
        return this.telephone;
    }

    /**
     * 
     * 
     */
    public void setTelephone(List<Telephone> telephone) {
        this.telephone = telephone;
    }

    @Transient
    public boolean isSetTelephone() {
        return ((this.telephone!= null)&&(!this.telephone.isEmpty()));
    }

    public void unsetTelephone() {
        this.telephone = null;
    }

    /**
     * Gets the value of the electronicAddressText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ELEC_ADDR_TXT", length = 100)
    public String getElectronicAddressText() {
        return electronicAddressText;
    }

    /**
     * Sets the value of the electronicAddressText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setElectronicAddressText(String value) {
        this.electronicAddressText = value;
    }

    @Transient
    public boolean isSetElectronicAddressText() {
        return (this.electronicAddressText!= null);
    }

    /**
     * Gets the value of the startDateOfAddressAssociation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "START_DATE_OF_ADDR_ASSC")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getStartDateOfAddressAssociation() {
        return startDateOfAddressAssociation;
    }

    /**
     * Sets the value of the startDateOfAddressAssociation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStartDateOfAddressAssociation(Date value) {
        this.startDateOfAddressAssociation = value;
    }

    @Transient
    public boolean isSetStartDateOfAddressAssociation() {
        return (this.startDateOfAddressAssociation!= null);
    }

    /**
     * Gets the value of the endDateOfAddressAssociation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "END_DATE_OF_ADDR_ASSC")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getEndDateOfAddressAssociation() {
        return endDateOfAddressAssociation;
    }

    /**
     * Sets the value of the endDateOfAddressAssociation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEndDateOfAddressAssociation(Date value) {
        this.endDateOfAddressAssociation = value;
    }

    @Transient
    public boolean isSetEndDateOfAddressAssociation() {
        return (this.endDateOfAddressAssociation!= null);
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
    @Column(name = "ICA_FAC_ADDR_ID")
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
        if (!(object instanceof Address)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final Address that = ((Address) object);
        {
            String lhsAffiliationTypeText;
            lhsAffiliationTypeText = this.getAffiliationTypeText();
            String rhsAffiliationTypeText;
            rhsAffiliationTypeText = that.getAffiliationTypeText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "affiliationTypeText", lhsAffiliationTypeText), LocatorUtils.property(thatLocator, "affiliationTypeText", rhsAffiliationTypeText), lhsAffiliationTypeText, rhsAffiliationTypeText)) {
                return false;
            }
        }
        {
            String lhsOrganizationFormalName;
            lhsOrganizationFormalName = this.getOrganizationFormalName();
            String rhsOrganizationFormalName;
            rhsOrganizationFormalName = that.getOrganizationFormalName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "organizationFormalName", lhsOrganizationFormalName), LocatorUtils.property(thatLocator, "organizationFormalName", rhsOrganizationFormalName), lhsOrganizationFormalName, rhsOrganizationFormalName)) {
                return false;
            }
        }
        {
            String lhsOrganizationDUNSNumber;
            lhsOrganizationDUNSNumber = this.getOrganizationDUNSNumber();
            String rhsOrganizationDUNSNumber;
            rhsOrganizationDUNSNumber = that.getOrganizationDUNSNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "organizationDUNSNumber", lhsOrganizationDUNSNumber), LocatorUtils.property(thatLocator, "organizationDUNSNumber", rhsOrganizationDUNSNumber), lhsOrganizationDUNSNumber, rhsOrganizationDUNSNumber)) {
                return false;
            }
        }
        {
            String lhsMailingAddressText;
            lhsMailingAddressText = this.getMailingAddressText();
            String rhsMailingAddressText;
            rhsMailingAddressText = that.getMailingAddressText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "mailingAddressText", lhsMailingAddressText), LocatorUtils.property(thatLocator, "mailingAddressText", rhsMailingAddressText), lhsMailingAddressText, rhsMailingAddressText)) {
                return false;
            }
        }
        {
            String lhsSupplementalAddressText;
            lhsSupplementalAddressText = this.getSupplementalAddressText();
            String rhsSupplementalAddressText;
            rhsSupplementalAddressText = that.getSupplementalAddressText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "supplementalAddressText", lhsSupplementalAddressText), LocatorUtils.property(thatLocator, "supplementalAddressText", rhsSupplementalAddressText), lhsSupplementalAddressText, rhsSupplementalAddressText)) {
                return false;
            }
        }
        {
            String lhsMailingAddressCityName;
            lhsMailingAddressCityName = this.getMailingAddressCityName();
            String rhsMailingAddressCityName;
            rhsMailingAddressCityName = that.getMailingAddressCityName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "mailingAddressCityName", lhsMailingAddressCityName), LocatorUtils.property(thatLocator, "mailingAddressCityName", rhsMailingAddressCityName), lhsMailingAddressCityName, rhsMailingAddressCityName)) {
                return false;
            }
        }
        {
            String lhsMailingAddressStateCode;
            lhsMailingAddressStateCode = this.getMailingAddressStateCode();
            String rhsMailingAddressStateCode;
            rhsMailingAddressStateCode = that.getMailingAddressStateCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "mailingAddressStateCode", lhsMailingAddressStateCode), LocatorUtils.property(thatLocator, "mailingAddressStateCode", rhsMailingAddressStateCode), lhsMailingAddressStateCode, rhsMailingAddressStateCode)) {
                return false;
            }
        }
        {
            String lhsMailingAddressZipCode;
            lhsMailingAddressZipCode = this.getMailingAddressZipCode();
            String rhsMailingAddressZipCode;
            rhsMailingAddressZipCode = that.getMailingAddressZipCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "mailingAddressZipCode", lhsMailingAddressZipCode), LocatorUtils.property(thatLocator, "mailingAddressZipCode", rhsMailingAddressZipCode), lhsMailingAddressZipCode, rhsMailingAddressZipCode)) {
                return false;
            }
        }
        {
            String lhsCountyName;
            lhsCountyName = this.getCountyName();
            String rhsCountyName;
            rhsCountyName = that.getCountyName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "countyName", lhsCountyName), LocatorUtils.property(thatLocator, "countyName", rhsCountyName), lhsCountyName, rhsCountyName)) {
                return false;
            }
        }
        {
            String lhsMailingAddressCountryCode;
            lhsMailingAddressCountryCode = this.getMailingAddressCountryCode();
            String rhsMailingAddressCountryCode;
            rhsMailingAddressCountryCode = that.getMailingAddressCountryCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "mailingAddressCountryCode", lhsMailingAddressCountryCode), LocatorUtils.property(thatLocator, "mailingAddressCountryCode", rhsMailingAddressCountryCode), lhsMailingAddressCountryCode, rhsMailingAddressCountryCode)) {
                return false;
            }
        }
        {
            String lhsDivisionName;
            lhsDivisionName = this.getDivisionName();
            String rhsDivisionName;
            rhsDivisionName = that.getDivisionName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "divisionName", lhsDivisionName), LocatorUtils.property(thatLocator, "divisionName", rhsDivisionName), lhsDivisionName, rhsDivisionName)) {
                return false;
            }
        }
        {
            String lhsLocationProvince;
            lhsLocationProvince = this.getLocationProvince();
            String rhsLocationProvince;
            rhsLocationProvince = that.getLocationProvince();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "locationProvince", lhsLocationProvince), LocatorUtils.property(thatLocator, "locationProvince", rhsLocationProvince), lhsLocationProvince, rhsLocationProvince)) {
                return false;
            }
        }
        {
            List<Telephone> lhsTelephone;
            lhsTelephone = (this.isSetTelephone()?this.getTelephone():null);
            List<Telephone> rhsTelephone;
            rhsTelephone = (that.isSetTelephone()?that.getTelephone():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "telephone", lhsTelephone), LocatorUtils.property(thatLocator, "telephone", rhsTelephone), lhsTelephone, rhsTelephone)) {
                return false;
            }
        }
        {
            String lhsElectronicAddressText;
            lhsElectronicAddressText = this.getElectronicAddressText();
            String rhsElectronicAddressText;
            rhsElectronicAddressText = that.getElectronicAddressText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "electronicAddressText", lhsElectronicAddressText), LocatorUtils.property(thatLocator, "electronicAddressText", rhsElectronicAddressText), lhsElectronicAddressText, rhsElectronicAddressText)) {
                return false;
            }
        }
        {
            Date lhsStartDateOfAddressAssociation;
            lhsStartDateOfAddressAssociation = this.getStartDateOfAddressAssociation();
            Date rhsStartDateOfAddressAssociation;
            rhsStartDateOfAddressAssociation = that.getStartDateOfAddressAssociation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "startDateOfAddressAssociation", lhsStartDateOfAddressAssociation), LocatorUtils.property(thatLocator, "startDateOfAddressAssociation", rhsStartDateOfAddressAssociation), lhsStartDateOfAddressAssociation, rhsStartDateOfAddressAssociation)) {
                return false;
            }
        }
        {
            Date lhsEndDateOfAddressAssociation;
            lhsEndDateOfAddressAssociation = this.getEndDateOfAddressAssociation();
            Date rhsEndDateOfAddressAssociation;
            rhsEndDateOfAddressAssociation = that.getEndDateOfAddressAssociation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "endDateOfAddressAssociation", lhsEndDateOfAddressAssociation), LocatorUtils.property(thatLocator, "endDateOfAddressAssociation", rhsEndDateOfAddressAssociation), lhsEndDateOfAddressAssociation, rhsEndDateOfAddressAssociation)) {
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
            String theAffiliationTypeText;
            theAffiliationTypeText = this.getAffiliationTypeText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "affiliationTypeText", theAffiliationTypeText), currentHashCode, theAffiliationTypeText);
        }
        {
            String theOrganizationFormalName;
            theOrganizationFormalName = this.getOrganizationFormalName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "organizationFormalName", theOrganizationFormalName), currentHashCode, theOrganizationFormalName);
        }
        {
            String theOrganizationDUNSNumber;
            theOrganizationDUNSNumber = this.getOrganizationDUNSNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "organizationDUNSNumber", theOrganizationDUNSNumber), currentHashCode, theOrganizationDUNSNumber);
        }
        {
            String theMailingAddressText;
            theMailingAddressText = this.getMailingAddressText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "mailingAddressText", theMailingAddressText), currentHashCode, theMailingAddressText);
        }
        {
            String theSupplementalAddressText;
            theSupplementalAddressText = this.getSupplementalAddressText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "supplementalAddressText", theSupplementalAddressText), currentHashCode, theSupplementalAddressText);
        }
        {
            String theMailingAddressCityName;
            theMailingAddressCityName = this.getMailingAddressCityName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "mailingAddressCityName", theMailingAddressCityName), currentHashCode, theMailingAddressCityName);
        }
        {
            String theMailingAddressStateCode;
            theMailingAddressStateCode = this.getMailingAddressStateCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "mailingAddressStateCode", theMailingAddressStateCode), currentHashCode, theMailingAddressStateCode);
        }
        {
            String theMailingAddressZipCode;
            theMailingAddressZipCode = this.getMailingAddressZipCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "mailingAddressZipCode", theMailingAddressZipCode), currentHashCode, theMailingAddressZipCode);
        }
        {
            String theCountyName;
            theCountyName = this.getCountyName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "countyName", theCountyName), currentHashCode, theCountyName);
        }
        {
            String theMailingAddressCountryCode;
            theMailingAddressCountryCode = this.getMailingAddressCountryCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "mailingAddressCountryCode", theMailingAddressCountryCode), currentHashCode, theMailingAddressCountryCode);
        }
        {
            String theDivisionName;
            theDivisionName = this.getDivisionName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "divisionName", theDivisionName), currentHashCode, theDivisionName);
        }
        {
            String theLocationProvince;
            theLocationProvince = this.getLocationProvince();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "locationProvince", theLocationProvince), currentHashCode, theLocationProvince);
        }
        {
            List<Telephone> theTelephone;
            theTelephone = (this.isSetTelephone()?this.getTelephone():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "telephone", theTelephone), currentHashCode, theTelephone);
        }
        {
            String theElectronicAddressText;
            theElectronicAddressText = this.getElectronicAddressText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "electronicAddressText", theElectronicAddressText), currentHashCode, theElectronicAddressText);
        }
        {
            Date theStartDateOfAddressAssociation;
            theStartDateOfAddressAssociation = this.getStartDateOfAddressAssociation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "startDateOfAddressAssociation", theStartDateOfAddressAssociation), currentHashCode, theStartDateOfAddressAssociation);
        }
        {
            Date theEndDateOfAddressAssociation;
            theEndDateOfAddressAssociation = this.getEndDateOfAddressAssociation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "endDateOfAddressAssociation", theEndDateOfAddressAssociation), currentHashCode, theEndDateOfAddressAssociation);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

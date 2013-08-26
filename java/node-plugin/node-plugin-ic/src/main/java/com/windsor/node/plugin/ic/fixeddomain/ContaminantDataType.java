//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2013.08.26 at 02:36:56 PM PDT 
//


package com.windsor.node.plugin.ic.fixeddomain;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
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
 * <p>Java class for ContaminantDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ContaminantDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}ChemicalCategoryCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}OtherChemicalCategoryText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}CASRegistryNumber" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/IC/1}ChemicalSubstanceDefinitionText"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ContaminantDataType", propOrder = {
    "chemicalCategoryCode",
    "otherChemicalCategoryText",
    "casRegistryNumber",
    "chemicalSubstanceDefinitionText"
})
@Entity(name = "ContaminantDataType")
@Table(name = "IC_CNTMT")
@Inheritance(strategy = InheritanceType.JOINED)
public class ContaminantDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ChemicalCategoryCode", required = true)
    protected ChemicalCategoryCodeDataType chemicalCategoryCode;
    @XmlElement(name = "OtherChemicalCategoryText")
    protected String otherChemicalCategoryText;
    @XmlElement(name = "CASRegistryNumber")
    protected String casRegistryNumber;
    @XmlElement(name = "ChemicalSubstanceDefinitionText", required = true)
    protected String chemicalSubstanceDefinitionText;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the chemicalCategoryCode property.
     * 
     * @return
     *     possible object is
     *     {@link ChemicalCategoryCodeDataType }
     *     
     */
    @Basic
    @Column(name = "CHEM_CATG_CODE", length = 255)
    @Enumerated(EnumType.STRING)
    public ChemicalCategoryCodeDataType getChemicalCategoryCode() {
        return chemicalCategoryCode;
    }

    /**
     * Sets the value of the chemicalCategoryCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link ChemicalCategoryCodeDataType }
     *     
     */
    public void setChemicalCategoryCode(ChemicalCategoryCodeDataType value) {
        this.chemicalCategoryCode = value;
    }

    @Transient
    public boolean isSetChemicalCategoryCode() {
        return (this.chemicalCategoryCode!= null);
    }

    /**
     * Gets the value of the otherChemicalCategoryText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHR_CHEM_CATG_TXT", length = 255)
    public String getOtherChemicalCategoryText() {
        return otherChemicalCategoryText;
    }

    /**
     * Sets the value of the otherChemicalCategoryText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherChemicalCategoryText(String value) {
        this.otherChemicalCategoryText = value;
    }

    @Transient
    public boolean isSetOtherChemicalCategoryText() {
        return (this.otherChemicalCategoryText!= null);
    }

    /**
     * Gets the value of the casRegistryNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CAS_REG_NUM", length = 255)
    public String getCASRegistryNumber() {
        return casRegistryNumber;
    }

    /**
     * Sets the value of the casRegistryNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCASRegistryNumber(String value) {
        this.casRegistryNumber = value;
    }

    @Transient
    public boolean isSetCASRegistryNumber() {
        return (this.casRegistryNumber!= null);
    }

    /**
     * Gets the value of the chemicalSubstanceDefinitionText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CHEM_SUB_DEF_TXT", length = 255)
    public String getChemicalSubstanceDefinitionText() {
        return chemicalSubstanceDefinitionText;
    }

    /**
     * Sets the value of the chemicalSubstanceDefinitionText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setChemicalSubstanceDefinitionText(String value) {
        this.chemicalSubstanceDefinitionText = value;
    }

    @Transient
    public boolean isSetChemicalSubstanceDefinitionText() {
        return (this.chemicalSubstanceDefinitionText!= null);
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
    @Column(name = "IC_CNTMT_ID")
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
        if (!(object instanceof ContaminantDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ContaminantDataType that = ((ContaminantDataType) object);
        {
            ChemicalCategoryCodeDataType lhsChemicalCategoryCode;
            lhsChemicalCategoryCode = this.getChemicalCategoryCode();
            ChemicalCategoryCodeDataType rhsChemicalCategoryCode;
            rhsChemicalCategoryCode = that.getChemicalCategoryCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "chemicalCategoryCode", lhsChemicalCategoryCode), LocatorUtils.property(thatLocator, "chemicalCategoryCode", rhsChemicalCategoryCode), lhsChemicalCategoryCode, rhsChemicalCategoryCode)) {
                return false;
            }
        }
        {
            String lhsOtherChemicalCategoryText;
            lhsOtherChemicalCategoryText = this.getOtherChemicalCategoryText();
            String rhsOtherChemicalCategoryText;
            rhsOtherChemicalCategoryText = that.getOtherChemicalCategoryText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherChemicalCategoryText", lhsOtherChemicalCategoryText), LocatorUtils.property(thatLocator, "otherChemicalCategoryText", rhsOtherChemicalCategoryText), lhsOtherChemicalCategoryText, rhsOtherChemicalCategoryText)) {
                return false;
            }
        }
        {
            String lhsCASRegistryNumber;
            lhsCASRegistryNumber = this.getCASRegistryNumber();
            String rhsCASRegistryNumber;
            rhsCASRegistryNumber = that.getCASRegistryNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "casRegistryNumber", lhsCASRegistryNumber), LocatorUtils.property(thatLocator, "casRegistryNumber", rhsCASRegistryNumber), lhsCASRegistryNumber, rhsCASRegistryNumber)) {
                return false;
            }
        }
        {
            String lhsChemicalSubstanceDefinitionText;
            lhsChemicalSubstanceDefinitionText = this.getChemicalSubstanceDefinitionText();
            String rhsChemicalSubstanceDefinitionText;
            rhsChemicalSubstanceDefinitionText = that.getChemicalSubstanceDefinitionText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "chemicalSubstanceDefinitionText", lhsChemicalSubstanceDefinitionText), LocatorUtils.property(thatLocator, "chemicalSubstanceDefinitionText", rhsChemicalSubstanceDefinitionText), lhsChemicalSubstanceDefinitionText, rhsChemicalSubstanceDefinitionText)) {
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
            ChemicalCategoryCodeDataType theChemicalCategoryCode;
            theChemicalCategoryCode = this.getChemicalCategoryCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "chemicalCategoryCode", theChemicalCategoryCode), currentHashCode, theChemicalCategoryCode);
        }
        {
            String theOtherChemicalCategoryText;
            theOtherChemicalCategoryText = this.getOtherChemicalCategoryText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherChemicalCategoryText", theOtherChemicalCategoryText), currentHashCode, theOtherChemicalCategoryText);
        }
        {
            String theCASRegistryNumber;
            theCASRegistryNumber = this.getCASRegistryNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "casRegistryNumber", theCASRegistryNumber), currentHashCode, theCASRegistryNumber);
        }
        {
            String theChemicalSubstanceDefinitionText;
            theChemicalSubstanceDefinitionText = this.getChemicalSubstanceDefinitionText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "chemicalSubstanceDefinitionText", theChemicalSubstanceDefinitionText), currentHashCode, theChemicalSubstanceDefinitionText);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

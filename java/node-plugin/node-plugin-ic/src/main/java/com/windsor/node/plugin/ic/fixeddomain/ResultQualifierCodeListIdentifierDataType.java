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
import javax.persistence.Embeddable;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for ResultQualifierCodeListIdentifierDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ResultQualifierCodeListIdentifierDataType">
 *   &lt;simpleContent>
 *     &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
 *       &lt;attribute name="CodeListVersionIdentifier" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="CodeListVersionAgencyIdentifier" type="{http://www.w3.org/2001/XMLSchema}string" />
 *     &lt;/extension>
 *   &lt;/simpleContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ResultQualifierCodeListIdentifierDataType", propOrder = {
    "value"
})
@Embeddable
public class ResultQualifierCodeListIdentifierDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlValue
    protected String value;
    @XmlAttribute(name = "CodeListVersionIdentifier")
    protected String codeListVersionIdentifier;
    @XmlAttribute(name = "CodeListVersionAgencyIdentifier")
    protected String codeListVersionAgencyIdentifier;

    /**
     * Gets the value of the value property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "VALUE", length = 255)
    public String getValue() {
        return value;
    }

    /**
     * Sets the value of the value property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setValue(String value) {
        this.value = value;
    }

    @Transient
    public boolean isSetValue() {
        return (this.value!= null);
    }

    /**
     * Gets the value of the codeListVersionIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CODE_LST_IDEN", length = 255)
    public String getCodeListVersionIdentifier() {
        return codeListVersionIdentifier;
    }

    /**
     * Sets the value of the codeListVersionIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCodeListVersionIdentifier(String value) {
        this.codeListVersionIdentifier = value;
    }

    @Transient
    public boolean isSetCodeListVersionIdentifier() {
        return (this.codeListVersionIdentifier!= null);
    }

    /**
     * Gets the value of the codeListVersionAgencyIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CODE_LST_AGENCY_IDEN", length = 255)
    public String getCodeListVersionAgencyIdentifier() {
        return codeListVersionAgencyIdentifier;
    }

    /**
     * Sets the value of the codeListVersionAgencyIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCodeListVersionAgencyIdentifier(String value) {
        this.codeListVersionAgencyIdentifier = value;
    }

    @Transient
    public boolean isSetCodeListVersionAgencyIdentifier() {
        return (this.codeListVersionAgencyIdentifier!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof ResultQualifierCodeListIdentifierDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ResultQualifierCodeListIdentifierDataType that = ((ResultQualifierCodeListIdentifierDataType) object);
        {
            String lhsValue;
            lhsValue = this.getValue();
            String rhsValue;
            rhsValue = that.getValue();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "value", lhsValue), LocatorUtils.property(thatLocator, "value", rhsValue), lhsValue, rhsValue)) {
                return false;
            }
        }
        {
            String lhsCodeListVersionIdentifier;
            lhsCodeListVersionIdentifier = this.getCodeListVersionIdentifier();
            String rhsCodeListVersionIdentifier;
            rhsCodeListVersionIdentifier = that.getCodeListVersionIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "codeListVersionIdentifier", lhsCodeListVersionIdentifier), LocatorUtils.property(thatLocator, "codeListVersionIdentifier", rhsCodeListVersionIdentifier), lhsCodeListVersionIdentifier, rhsCodeListVersionIdentifier)) {
                return false;
            }
        }
        {
            String lhsCodeListVersionAgencyIdentifier;
            lhsCodeListVersionAgencyIdentifier = this.getCodeListVersionAgencyIdentifier();
            String rhsCodeListVersionAgencyIdentifier;
            rhsCodeListVersionAgencyIdentifier = that.getCodeListVersionAgencyIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "codeListVersionAgencyIdentifier", lhsCodeListVersionAgencyIdentifier), LocatorUtils.property(thatLocator, "codeListVersionAgencyIdentifier", rhsCodeListVersionAgencyIdentifier), lhsCodeListVersionAgencyIdentifier, rhsCodeListVersionAgencyIdentifier)) {
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
            String theValue;
            theValue = this.getValue();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "value", theValue), currentHashCode, theValue);
        }
        {
            String theCodeListVersionIdentifier;
            theCodeListVersionIdentifier = this.getCodeListVersionIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "codeListVersionIdentifier", theCodeListVersionIdentifier), currentHashCode, theCodeListVersionIdentifier);
        }
        {
            String theCodeListVersionAgencyIdentifier;
            theCodeListVersionAgencyIdentifier = this.getCodeListVersionAgencyIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "codeListVersionAgencyIdentifier", theCodeListVersionAgencyIdentifier), currentHashCode, theCodeListVersionAgencyIdentifier);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

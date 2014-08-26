//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.5-2 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2013.04.09 at 07:20:00 AM PDT 
//


package com.windsor.node.plugin.attains.fixeddomain;

import java.io.Serializable;
import java.math.BigInteger;
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
 * <p>Java class for StateMethodDetailsDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="StateMethodDetailsDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}AssessmentMethodIdentifierCode"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}AssessmentMethodName"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "StateMethodDetailsDataType", propOrder = {
    "assessmentMethodIdentifierCode",
    "assessmentMethodName"
})
@Entity(name = "StateMethodDetailsDataType")
@Table(name = "OWIR_STATE_METH_DTLS")
@Inheritance(strategy = InheritanceType.JOINED)
public class StateMethodDetailsDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "AssessmentMethodIdentifierCode", required = true)
    protected BigInteger assessmentMethodIdentifierCode;
    @XmlElement(name = "AssessmentMethodName", required = true)
    protected String assessmentMethodName;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the assessmentMethodIdentifierCode property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    @Basic
    @Column(name = "ASMT_METH_IDEN_CODE", precision = 20, scale = 0)
    public BigInteger getAssessmentMethodIdentifierCode() {
        return assessmentMethodIdentifierCode;
    }

    /**
     * Sets the value of the assessmentMethodIdentifierCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setAssessmentMethodIdentifierCode(BigInteger value) {
        this.assessmentMethodIdentifierCode = value;
    }

    @Transient
    public boolean isSetAssessmentMethodIdentifierCode() {
        return (this.assessmentMethodIdentifierCode!= null);
    }

    /**
     * Gets the value of the assessmentMethodName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ASMT_METH_NAME", length = 90)
    public String getAssessmentMethodName() {
        return assessmentMethodName;
    }

    /**
     * Sets the value of the assessmentMethodName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAssessmentMethodName(String value) {
        this.assessmentMethodName = value;
    }

    @Transient
    public boolean isSetAssessmentMethodName() {
        return (this.assessmentMethodName!= null);
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
    @Column(name = "STATE_METH_DTLS_ID")
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
        if (!(object instanceof StateMethodDetailsDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final StateMethodDetailsDataType that = ((StateMethodDetailsDataType) object);
        {
            BigInteger lhsAssessmentMethodIdentifierCode;
            lhsAssessmentMethodIdentifierCode = this.getAssessmentMethodIdentifierCode();
            BigInteger rhsAssessmentMethodIdentifierCode;
            rhsAssessmentMethodIdentifierCode = that.getAssessmentMethodIdentifierCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "assessmentMethodIdentifierCode", lhsAssessmentMethodIdentifierCode), LocatorUtils.property(thatLocator, "assessmentMethodIdentifierCode", rhsAssessmentMethodIdentifierCode), lhsAssessmentMethodIdentifierCode, rhsAssessmentMethodIdentifierCode)) {
                return false;
            }
        }
        {
            String lhsAssessmentMethodName;
            lhsAssessmentMethodName = this.getAssessmentMethodName();
            String rhsAssessmentMethodName;
            rhsAssessmentMethodName = that.getAssessmentMethodName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "assessmentMethodName", lhsAssessmentMethodName), LocatorUtils.property(thatLocator, "assessmentMethodName", rhsAssessmentMethodName), lhsAssessmentMethodName, rhsAssessmentMethodName)) {
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
            BigInteger theAssessmentMethodIdentifierCode;
            theAssessmentMethodIdentifierCode = this.getAssessmentMethodIdentifierCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "assessmentMethodIdentifierCode", theAssessmentMethodIdentifierCode), currentHashCode, theAssessmentMethodIdentifierCode);
        }
        {
            String theAssessmentMethodName;
            theAssessmentMethodName = this.getAssessmentMethodName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "assessmentMethodName", theAssessmentMethodName), currentHashCode, theAssessmentMethodName);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
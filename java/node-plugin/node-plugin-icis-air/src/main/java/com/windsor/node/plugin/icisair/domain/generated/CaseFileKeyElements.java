//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2014.09.02 at 11:05:46 AM PDT 
//


package com.windsor.node.plugin.icisair.domain.generated;

import java.io.Serializable;

import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSeeAlso;
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
 * <p>Java class for CaseFileKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CaseFileKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/5}CaseFileKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CaseFileKeyElements", propOrder = {
    "caseFileIdentifier"
})
@XmlSeeAlso({
    CaseFileLinkage.class,
    AirDACaseFile.class
})
@MappedSuperclass
public class CaseFileKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "CaseFileIdentifier", required = true)
    protected String caseFileIdentifier;

    /**
     * Gets the value of the caseFileIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CASE_FILE_IDENT", length = 25)
    //@Column(name = "LNK_CASE_FILE_IDENT", length = 25)
    public String getCaseFileIdentifier() {
        return caseFileIdentifier;
    }

    /**
     * Sets the value of the caseFileIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCaseFileIdentifier(String value) {
        this.caseFileIdentifier = value;
    }

    @Transient
    public boolean isSetCaseFileIdentifier() {
        return (this.caseFileIdentifier!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof CaseFileKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final CaseFileKeyElements that = ((CaseFileKeyElements) object);
        {
            String lhsCaseFileIdentifier;
            lhsCaseFileIdentifier = this.getCaseFileIdentifier();
            String rhsCaseFileIdentifier;
            rhsCaseFileIdentifier = that.getCaseFileIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "caseFileIdentifier", lhsCaseFileIdentifier), LocatorUtils.property(thatLocator, "caseFileIdentifier", rhsCaseFileIdentifier), lhsCaseFileIdentifier, rhsCaseFileIdentifier)) {
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
            String theCaseFileIdentifier;
            theCaseFileIdentifier = this.getCaseFileIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "caseFileIdentifier", theCaseFileIdentifier), currentHashCode, theCaseFileIdentifier);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vJAXB 2.1.10 in JDK 6 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.01.24 at 11:33:47 AM PST 
//


package com.windsor.node.plugin.facid3.domain;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ResultQualifierDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ResultQualifierDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}ResultQualifierCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}ResultQualifierCodeListIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}ResultQualifierName" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ResultQualifierDataType", propOrder = {
    "resultQualifierCode",
    "resultQualifierCodeListIdentifier",
    "resultQualifierName"
})
public class ResultQualifierDataType {

    @XmlElement(name = "ResultQualifierCode")
    protected String resultQualifierCode;
    @XmlElement(name = "ResultQualifierCodeListIdentifier")
    protected ResultQualifierCodeListIdentifierDataType resultQualifierCodeListIdentifier;
    @XmlElement(name = "ResultQualifierName")
    protected String resultQualifierName;

    /**
     * Gets the value of the resultQualifierCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getResultQualifierCode() {
        return resultQualifierCode;
    }

    /**
     * Sets the value of the resultQualifierCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setResultQualifierCode(String value) {
        this.resultQualifierCode = value;
    }

    /**
     * Gets the value of the resultQualifierCodeListIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link ResultQualifierCodeListIdentifierDataType }
     *     
     */
    public ResultQualifierCodeListIdentifierDataType getResultQualifierCodeListIdentifier() {
        return resultQualifierCodeListIdentifier;
    }

    /**
     * Sets the value of the resultQualifierCodeListIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResultQualifierCodeListIdentifierDataType }
     *     
     */
    public void setResultQualifierCodeListIdentifier(ResultQualifierCodeListIdentifierDataType value) {
        this.resultQualifierCodeListIdentifier = value;
    }

    /**
     * Gets the value of the resultQualifierName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getResultQualifierName() {
        return resultQualifierName;
    }

    /**
     * Sets the value of the resultQualifierName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setResultQualifierName(String value) {
        this.resultQualifierName = value;
    }

}

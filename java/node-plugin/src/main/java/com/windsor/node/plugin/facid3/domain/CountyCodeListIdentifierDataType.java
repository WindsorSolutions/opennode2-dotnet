//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vJAXB 2.1.10 in JDK 6 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.01.24 at 11:33:47 AM PST 
//


package com.windsor.node.plugin.facid3.domain;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;


/**
 * <p>Java class for CountyCodeListIdentifierDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CountyCodeListIdentifierDataType">
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
@XmlType(name = "CountyCodeListIdentifierDataType", propOrder = {
    "value"
})
public class CountyCodeListIdentifierDataType {

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

    /**
     * Gets the value of the codeListVersionIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
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

    /**
     * Gets the value of the codeListVersionAgencyIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
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

}

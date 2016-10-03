
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import javax.xml.namespace.QName;


/**
 * <p>Java class for ParameterType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ParameterType">
 *   &lt;simpleContent>
 *     &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
 *       &lt;attribute name="parameterName" use="required" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="parameterType" type="{http://www.w3.org/2001/XMLSchema}QName" />
 *       &lt;attribute name="parameterEncoding" type="{http://www.exchangenetwork.net/schema/node/2}EncodingType" default="None" />
 *     &lt;/extension>
 *   &lt;/simpleContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ParameterType", propOrder = {
    "value"
})
public class ParameterType {

    @XmlValue
    protected String value;
    @XmlAttribute(name = "parameterName", required = true)
    protected String parameterName;
    @XmlAttribute(name = "parameterType")
    protected QName parameterType;
    @XmlAttribute(name = "parameterEncoding")
    protected EncodingType parameterEncoding;

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
     * Gets the value of the parameterName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getParameterName() {
        return parameterName;
    }

    /**
     * Sets the value of the parameterName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setParameterName(String value) {
        this.parameterName = value;
    }

    /**
     * Gets the value of the parameterType property.
     * 
     * @return
     *     possible object is
     *     {@link QName }
     *     
     */
    public QName getParameterType() {
        return parameterType;
    }

    /**
     * Sets the value of the parameterType property.
     * 
     * @param value
     *     allowed object is
     *     {@link QName }
     *     
     */
    public void setParameterType(QName value) {
        this.parameterType = value;
    }

    /**
     * Gets the value of the parameterEncoding property.
     * 
     * @return
     *     possible object is
     *     {@link EncodingType }
     *     
     */
    public EncodingType getParameterEncoding() {
        if (parameterEncoding == null) {
            return EncodingType.NONE;
        } else {
            return parameterEncoding;
        }
    }

    /**
     * Sets the value of the parameterEncoding property.
     * 
     * @param value
     *     allowed object is
     *     {@link EncodingType }
     *     
     */
    public void setParameterEncoding(EncodingType value) {
        this.parameterEncoding = value;
    }

}

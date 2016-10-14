
package com.agilairecorp;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQSWebServiceArgument;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="args" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}AQSWebServiceArgument" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "args"
})
@XmlRootElement(name = "GetAQSXmlData")
public class GetAQSXmlData {

    @XmlElementRef(name = "args", namespace = "http://www.agilairecorp.com/", type = JAXBElement.class, required = false)
    protected JAXBElement<AQSWebServiceArgument> args;

    /**
     * Gets the value of the args property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link AQSWebServiceArgument }{@code >}
     *     
     */
    public JAXBElement<AQSWebServiceArgument> getArgs() {
        return args;
    }

    /**
     * Sets the value of the args property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link AQSWebServiceArgument }{@code >}
     *     
     */
    public void setArgs(JAXBElement<AQSWebServiceArgument> value) {
        this.args = value;
    }

}

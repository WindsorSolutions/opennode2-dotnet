
package com.agilairecorp;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQS3WebServiceArgument;


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
 *         &lt;element name="args" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}AQS3WebServiceArgument" minOccurs="0"/>
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
@XmlRootElement(name = "GetAQS3XmlData")
public class GetAQS3XmlData {

    @XmlElementRef(name = "args", namespace = "http://www.agilairecorp.com/", type = JAXBElement.class, required = false)
    protected JAXBElement<AQS3WebServiceArgument> args;

    /**
     * Gets the value of the args property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link AQS3WebServiceArgument }{@code >}
     *     
     */
    public JAXBElement<AQS3WebServiceArgument> getArgs() {
        return args;
    }

    /**
     * Sets the value of the args property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link AQS3WebServiceArgument }{@code >}
     *     
     */
    public void setArgs(JAXBElement<AQS3WebServiceArgument> value) {
        this.args = value;
    }

}

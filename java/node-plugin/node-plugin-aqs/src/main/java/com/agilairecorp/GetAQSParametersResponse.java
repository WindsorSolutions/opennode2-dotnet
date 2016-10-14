
package com.agilairecorp;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.ArrayOfAQSParameterInformation;


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
 *         &lt;element name="GetAQSParametersResult" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}ArrayOfAQSParameterInformation" minOccurs="0"/>
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
    "getAQSParametersResult"
})
@XmlRootElement(name = "GetAQSParametersResponse")
public class GetAQSParametersResponse {

    @XmlElementRef(name = "GetAQSParametersResult", namespace = "http://www.agilairecorp.com/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfAQSParameterInformation> getAQSParametersResult;

    /**
     * Gets the value of the getAQSParametersResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfAQSParameterInformation }{@code >}
     *     
     */
    public JAXBElement<ArrayOfAQSParameterInformation> getGetAQSParametersResult() {
        return getAQSParametersResult;
    }

    /**
     * Sets the value of the getAQSParametersResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfAQSParameterInformation }{@code >}
     *     
     */
    public void setGetAQSParametersResult(JAXBElement<ArrayOfAQSParameterInformation> value) {
        this.getAQSParametersResult = value;
    }

}

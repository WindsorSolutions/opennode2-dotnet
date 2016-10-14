
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;
import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfstring;


/**
 * <p>Java class for AQSXmlResultData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AQSXmlResultData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AQSXmlDocumentText" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="DocumentIsZipped" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="GenerationWarnings" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfstring" minOccurs="0"/>
 *         &lt;element name="ZipCompressedAQSXmlDocument" type="{http://www.w3.org/2001/XMLSchema}base64Binary" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AQSXmlResultData", propOrder = {
    "aqsXmlDocumentText",
    "documentIsZipped",
    "generationWarnings",
    "zipCompressedAQSXmlDocument"
})
public class AQSXmlResultData {

    @XmlElementRef(name = "AQSXmlDocumentText", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> aqsXmlDocumentText;
    @XmlElement(name = "DocumentIsZipped")
    protected Boolean documentIsZipped;
    @XmlElementRef(name = "GenerationWarnings", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfstring> generationWarnings;
    @XmlElementRef(name = "ZipCompressedAQSXmlDocument", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<byte[]> zipCompressedAQSXmlDocument;

    /**
     * Gets the value of the aqsXmlDocumentText property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getAQSXmlDocumentText() {
        return aqsXmlDocumentText;
    }

    /**
     * Sets the value of the aqsXmlDocumentText property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setAQSXmlDocumentText(JAXBElement<String> value) {
        this.aqsXmlDocumentText = value;
    }

    /**
     * Gets the value of the documentIsZipped property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isDocumentIsZipped() {
        return documentIsZipped;
    }

    /**
     * Sets the value of the documentIsZipped property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setDocumentIsZipped(Boolean value) {
        this.documentIsZipped = value;
    }

    /**
     * Gets the value of the generationWarnings property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfstring }{@code >}
     *     
     */
    public JAXBElement<ArrayOfstring> getGenerationWarnings() {
        return generationWarnings;
    }

    /**
     * Sets the value of the generationWarnings property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfstring }{@code >}
     *     
     */
    public void setGenerationWarnings(JAXBElement<ArrayOfstring> value) {
        this.generationWarnings = value;
    }

    /**
     * Gets the value of the zipCompressedAQSXmlDocument property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link byte[]}{@code >}
     *     
     */
    public JAXBElement<byte[]> getZipCompressedAQSXmlDocument() {
        return zipCompressedAQSXmlDocument;
    }

    /**
     * Sets the value of the zipCompressedAQSXmlDocument property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link byte[]}{@code >}
     *     
     */
    public void setZipCompressedAQSXmlDocument(JAXBElement<byte[]> value) {
        this.zipCompressedAQSXmlDocument = value;
    }

}

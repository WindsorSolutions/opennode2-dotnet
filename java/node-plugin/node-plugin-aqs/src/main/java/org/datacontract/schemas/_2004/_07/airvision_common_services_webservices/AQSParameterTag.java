
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for AQSParameterTag complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AQSParameterTag">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AgencyCode" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="CountyTribalCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="DurationCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="ParameterCode" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="ParameterOccurrenceCode" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *         &lt;element name="SiteCode" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="StateCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AQSParameterTag", propOrder = {
    "agencyCode",
    "countyTribalCode",
    "durationCode",
    "parameterCode",
    "parameterOccurrenceCode",
    "siteCode",
    "stateCode"
})
public class AQSParameterTag {

    @XmlElement(name = "AgencyCode", required = true, nillable = true)
    protected String agencyCode;
    @XmlElementRef(name = "CountyTribalCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> countyTribalCode;
    @XmlElementRef(name = "DurationCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> durationCode;
    @XmlElement(name = "ParameterCode", required = true, nillable = true)
    protected String parameterCode;
    @XmlElementRef(name = "ParameterOccurrenceCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<Integer> parameterOccurrenceCode;
    @XmlElement(name = "SiteCode", required = true, nillable = true)
    protected String siteCode;
    @XmlElementRef(name = "StateCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> stateCode;

    /**
     * Gets the value of the agencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAgencyCode() {
        return agencyCode;
    }

    /**
     * Sets the value of the agencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAgencyCode(String value) {
        this.agencyCode = value;
    }

    /**
     * Gets the value of the countyTribalCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getCountyTribalCode() {
        return countyTribalCode;
    }

    /**
     * Sets the value of the countyTribalCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setCountyTribalCode(JAXBElement<String> value) {
        this.countyTribalCode = value;
    }

    /**
     * Gets the value of the durationCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getDurationCode() {
        return durationCode;
    }

    /**
     * Sets the value of the durationCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setDurationCode(JAXBElement<String> value) {
        this.durationCode = value;
    }

    /**
     * Gets the value of the parameterCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getParameterCode() {
        return parameterCode;
    }

    /**
     * Sets the value of the parameterCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setParameterCode(String value) {
        this.parameterCode = value;
    }

    /**
     * Gets the value of the parameterOccurrenceCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Integer }{@code >}
     *     
     */
    public JAXBElement<Integer> getParameterOccurrenceCode() {
        return parameterOccurrenceCode;
    }

    /**
     * Sets the value of the parameterOccurrenceCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Integer }{@code >}
     *     
     */
    public void setParameterOccurrenceCode(JAXBElement<Integer> value) {
        this.parameterOccurrenceCode = value;
    }

    /**
     * Gets the value of the siteCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSiteCode() {
        return siteCode;
    }

    /**
     * Sets the value of the siteCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSiteCode(String value) {
        this.siteCode = value;
    }

    /**
     * Gets the value of the stateCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getStateCode() {
        return stateCode;
    }

    /**
     * Sets the value of the stateCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setStateCode(JAXBElement<String> value) {
        this.stateCode = value;
    }

}

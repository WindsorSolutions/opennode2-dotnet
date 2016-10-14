
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for AQSParameterInformation complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AQSParameterInformation">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AgencyCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="CountyTribalCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="CountyTribalDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="ParameterCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="ParameterName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="ParameterOccurrenceCode" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *         &lt;element name="SiteCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="SiteName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="StateAbbreviation" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="StateCode" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="SystemName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AQSParameterInformation", propOrder = {
    "agencyCode",
    "countyTribalCode",
    "countyTribalDescription",
    "parameterCode",
    "parameterName",
    "parameterOccurrenceCode",
    "siteCode",
    "siteName",
    "stateAbbreviation",
    "stateCode",
    "systemName"
})
public class AQSParameterInformation {

    @XmlElementRef(name = "AgencyCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> agencyCode;
    @XmlElementRef(name = "CountyTribalCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> countyTribalCode;
    @XmlElementRef(name = "CountyTribalDescription", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> countyTribalDescription;
    @XmlElementRef(name = "ParameterCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> parameterCode;
    @XmlElementRef(name = "ParameterName", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> parameterName;
    @XmlElementRef(name = "ParameterOccurrenceCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<Integer> parameterOccurrenceCode;
    @XmlElementRef(name = "SiteCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> siteCode;
    @XmlElementRef(name = "SiteName", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> siteName;
    @XmlElementRef(name = "StateAbbreviation", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> stateAbbreviation;
    @XmlElementRef(name = "StateCode", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> stateCode;
    @XmlElementRef(name = "SystemName", namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type = JAXBElement.class, required = false)
    protected JAXBElement<String> systemName;

    /**
     * Gets the value of the agencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getAgencyCode() {
        return agencyCode;
    }

    /**
     * Sets the value of the agencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setAgencyCode(JAXBElement<String> value) {
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
     * Gets the value of the countyTribalDescription property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getCountyTribalDescription() {
        return countyTribalDescription;
    }

    /**
     * Sets the value of the countyTribalDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setCountyTribalDescription(JAXBElement<String> value) {
        this.countyTribalDescription = value;
    }

    /**
     * Gets the value of the parameterCode property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getParameterCode() {
        return parameterCode;
    }

    /**
     * Sets the value of the parameterCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setParameterCode(JAXBElement<String> value) {
        this.parameterCode = value;
    }

    /**
     * Gets the value of the parameterName property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getParameterName() {
        return parameterName;
    }

    /**
     * Sets the value of the parameterName property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setParameterName(JAXBElement<String> value) {
        this.parameterName = value;
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
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getSiteCode() {
        return siteCode;
    }

    /**
     * Sets the value of the siteCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setSiteCode(JAXBElement<String> value) {
        this.siteCode = value;
    }

    /**
     * Gets the value of the siteName property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getSiteName() {
        return siteName;
    }

    /**
     * Sets the value of the siteName property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setSiteName(JAXBElement<String> value) {
        this.siteName = value;
    }

    /**
     * Gets the value of the stateAbbreviation property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getStateAbbreviation() {
        return stateAbbreviation;
    }

    /**
     * Sets the value of the stateAbbreviation property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setStateAbbreviation(JAXBElement<String> value) {
        this.stateAbbreviation = value;
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

    /**
     * Gets the value of the systemName property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getSystemName() {
        return systemName;
    }

    /**
     * Sets the value of the systemName property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setSystemName(JAXBElement<String> value) {
        this.systemName = value;
    }

}

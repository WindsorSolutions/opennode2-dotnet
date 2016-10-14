
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for AQS3WebServiceArgument complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AQS3WebServiceArgument">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AQSXMLSchemaVersion" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="CompressPayload" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="EndTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="SendMonitorAssuranceTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="SendOnlyQAData" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="SendRBTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="SendRDTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="StartTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="Tags" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}ArrayOfAQSParameterTag"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AQS3WebServiceArgument", propOrder = {
    "aqsxmlSchemaVersion",
    "compressPayload",
    "endTime",
    "sendMonitorAssuranceTransactions",
    "sendOnlyQAData",
    "sendRBTransactions",
    "sendRDTransactions",
    "startTime",
    "tags"
})
public class AQS3WebServiceArgument {

    @XmlElement(name = "AQSXMLSchemaVersion", required = true, nillable = true)
    protected String aqsxmlSchemaVersion;
    @XmlElement(name = "CompressPayload")
    protected boolean compressPayload;
    @XmlElement(name = "EndTime", required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar endTime;
    @XmlElement(name = "SendMonitorAssuranceTransactions")
    protected boolean sendMonitorAssuranceTransactions;
    @XmlElement(name = "SendOnlyQAData")
    protected boolean sendOnlyQAData;
    @XmlElement(name = "SendRBTransactions")
    protected boolean sendRBTransactions;
    @XmlElement(name = "SendRDTransactions")
    protected boolean sendRDTransactions;
    @XmlElement(name = "StartTime", required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar startTime;
    @XmlElement(name = "Tags", required = true, nillable = true)
    protected ArrayOfAQSParameterTag tags;

    /**
     * Gets the value of the aqsxmlSchemaVersion property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAQSXMLSchemaVersion() {
        return aqsxmlSchemaVersion;
    }

    /**
     * Sets the value of the aqsxmlSchemaVersion property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAQSXMLSchemaVersion(String value) {
        this.aqsxmlSchemaVersion = value;
    }

    /**
     * Gets the value of the compressPayload property.
     * 
     */
    public boolean isCompressPayload() {
        return compressPayload;
    }

    /**
     * Sets the value of the compressPayload property.
     * 
     */
    public void setCompressPayload(boolean value) {
        this.compressPayload = value;
    }

    /**
     * Gets the value of the endTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getEndTime() {
        return endTime;
    }

    /**
     * Sets the value of the endTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setEndTime(XMLGregorianCalendar value) {
        this.endTime = value;
    }

    /**
     * Gets the value of the sendMonitorAssuranceTransactions property.
     * 
     */
    public boolean isSendMonitorAssuranceTransactions() {
        return sendMonitorAssuranceTransactions;
    }

    /**
     * Sets the value of the sendMonitorAssuranceTransactions property.
     * 
     */
    public void setSendMonitorAssuranceTransactions(boolean value) {
        this.sendMonitorAssuranceTransactions = value;
    }

    /**
     * Gets the value of the sendOnlyQAData property.
     * 
     */
    public boolean isSendOnlyQAData() {
        return sendOnlyQAData;
    }

    /**
     * Sets the value of the sendOnlyQAData property.
     * 
     */
    public void setSendOnlyQAData(boolean value) {
        this.sendOnlyQAData = value;
    }

    /**
     * Gets the value of the sendRBTransactions property.
     * 
     */
    public boolean isSendRBTransactions() {
        return sendRBTransactions;
    }

    /**
     * Sets the value of the sendRBTransactions property.
     * 
     */
    public void setSendRBTransactions(boolean value) {
        this.sendRBTransactions = value;
    }

    /**
     * Gets the value of the sendRDTransactions property.
     * 
     */
    public boolean isSendRDTransactions() {
        return sendRDTransactions;
    }

    /**
     * Sets the value of the sendRDTransactions property.
     * 
     */
    public void setSendRDTransactions(boolean value) {
        this.sendRDTransactions = value;
    }

    /**
     * Gets the value of the startTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getStartTime() {
        return startTime;
    }

    /**
     * Sets the value of the startTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setStartTime(XMLGregorianCalendar value) {
        this.startTime = value;
    }

    /**
     * Gets the value of the tags property.
     * 
     * @return
     *     possible object is
     *     {@link ArrayOfAQSParameterTag }
     *     
     */
    public ArrayOfAQSParameterTag getTags() {
        return tags;
    }

    /**
     * Sets the value of the tags property.
     * 
     * @param value
     *     allowed object is
     *     {@link ArrayOfAQSParameterTag }
     *     
     */
    public void setTags(ArrayOfAQSParameterTag value) {
        this.tags = value;
    }

}

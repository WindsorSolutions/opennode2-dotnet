
package com.agilairecorp;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


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
 *         &lt;element name="startTime" type="{http://www.w3.org/2001/XMLSchema}dateTime" minOccurs="0"/>
 *         &lt;element name="endTime" type="{http://www.w3.org/2001/XMLSchema}dateTime" minOccurs="0"/>
 *         &lt;element name="aqsXmlSchemaVersion" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="sendRdTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="sendRbTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="sendRaTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="sendRpTransactions" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="sendOnlyQaData" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
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
    "startTime",
    "endTime",
    "aqsXmlSchemaVersion",
    "sendRdTransactions",
    "sendRbTransactions",
    "sendRaTransactions",
    "sendRpTransactions",
    "sendOnlyQaData"
})
@XmlRootElement(name = "GetAQSXmlDataWeb")
public class GetAQSXmlDataWeb {

    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar startTime;
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar endTime;
    @XmlElementRef(name = "aqsXmlSchemaVersion", namespace = "http://www.agilairecorp.com/", type = JAXBElement.class, required = false)
    protected JAXBElement<String> aqsXmlSchemaVersion;
    protected Boolean sendRdTransactions;
    protected Boolean sendRbTransactions;
    protected Boolean sendRaTransactions;
    protected Boolean sendRpTransactions;
    protected Boolean sendOnlyQaData;

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
     * Gets the value of the aqsXmlSchemaVersion property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getAqsXmlSchemaVersion() {
        return aqsXmlSchemaVersion;
    }

    /**
     * Sets the value of the aqsXmlSchemaVersion property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setAqsXmlSchemaVersion(JAXBElement<String> value) {
        this.aqsXmlSchemaVersion = value;
    }

    /**
     * Gets the value of the sendRdTransactions property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isSendRdTransactions() {
        return sendRdTransactions;
    }

    /**
     * Sets the value of the sendRdTransactions property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setSendRdTransactions(Boolean value) {
        this.sendRdTransactions = value;
    }

    /**
     * Gets the value of the sendRbTransactions property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isSendRbTransactions() {
        return sendRbTransactions;
    }

    /**
     * Sets the value of the sendRbTransactions property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setSendRbTransactions(Boolean value) {
        this.sendRbTransactions = value;
    }

    /**
     * Gets the value of the sendRaTransactions property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isSendRaTransactions() {
        return sendRaTransactions;
    }

    /**
     * Sets the value of the sendRaTransactions property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setSendRaTransactions(Boolean value) {
        this.sendRaTransactions = value;
    }

    /**
     * Gets the value of the sendRpTransactions property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isSendRpTransactions() {
        return sendRpTransactions;
    }

    /**
     * Sets the value of the sendRpTransactions property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setSendRpTransactions(Boolean value) {
        this.sendRpTransactions = value;
    }

    /**
     * Gets the value of the sendOnlyQaData property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isSendOnlyQaData() {
        return sendOnlyQaData;
    }

    /**
     * Sets the value of the sendOnlyQaData property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setSendOnlyQaData(Boolean value) {
        this.sendOnlyQaData = value;
    }

}

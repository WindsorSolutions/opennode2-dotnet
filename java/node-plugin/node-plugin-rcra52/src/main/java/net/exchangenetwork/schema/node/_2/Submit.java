
package net.exchangenetwork.schema.node._2;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;


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
 *         &lt;element name="securityToken" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="transactionId" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="dataflow" type="{http://www.w3.org/2001/XMLSchema}NCName"/>
 *         &lt;element name="flowOperation" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="recipient" type="{http://www.w3.org/2001/XMLSchema}string" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="notificationURI" type="{http://www.exchangenetwork.net/schema/node/2}NotificationURIType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="documents" type="{http://www.exchangenetwork.net/schema/node/2}NodeDocumentType" maxOccurs="unbounded"/>
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
    "securityToken",
    "transactionId",
    "dataflow",
    "flowOperation",
    "recipient",
    "notificationURI",
    "documents"
})
@XmlRootElement(name = "Submit")
public class Submit {

    @XmlElement(required = true)
    protected String securityToken;
    @XmlElement(required = true)
    protected String transactionId;
    @XmlElement(required = true)
    @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
    @XmlSchemaType(name = "NCName")
    protected String dataflow;
    @XmlElement(required = true)
    protected String flowOperation;
    protected List<String> recipient;
    protected List<NotificationURIType> notificationURI;
    @XmlElement(required = true)
    protected List<NodeDocumentType> documents;

    /**
     * Gets the value of the securityToken property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSecurityToken() {
        return securityToken;
    }

    /**
     * Sets the value of the securityToken property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSecurityToken(String value) {
        this.securityToken = value;
    }

    /**
     * Gets the value of the transactionId property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTransactionId() {
        return transactionId;
    }

    /**
     * Sets the value of the transactionId property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTransactionId(String value) {
        this.transactionId = value;
    }

    /**
     * Gets the value of the dataflow property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDataflow() {
        return dataflow;
    }

    /**
     * Sets the value of the dataflow property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDataflow(String value) {
        this.dataflow = value;
    }

    /**
     * Gets the value of the flowOperation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getFlowOperation() {
        return flowOperation;
    }

    /**
     * Sets the value of the flowOperation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFlowOperation(String value) {
        this.flowOperation = value;
    }

    /**
     * Gets the value of the recipient property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the recipient property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getRecipient().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<String> getRecipient() {
        if (recipient == null) {
            recipient = new ArrayList<String>();
        }
        return this.recipient;
    }

    /**
     * Gets the value of the notificationURI property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the notificationURI property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getNotificationURI().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link NotificationURIType }
     * 
     * 
     */
    public List<NotificationURIType> getNotificationURI() {
        if (notificationURI == null) {
            notificationURI = new ArrayList<NotificationURIType>();
        }
        return this.notificationURI;
    }

    /**
     * Gets the value of the documents property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the documents property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getDocuments().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link NodeDocumentType }
     * 
     * 
     */
    public List<NodeDocumentType> getDocuments() {
        if (documents == null) {
            documents = new ArrayList<NodeDocumentType>();
        }
        return this.documents;
    }

}

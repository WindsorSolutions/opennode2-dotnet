
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlID;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;


/**
 * <p>Java class for NotificationMessageType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="NotificationMessageType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="messageCategory" type="{http://www.exchangenetwork.net/schema/node/2}NotificationMessageCategoryType"/>
 *         &lt;element name="messageName" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="status" type="{http://www.exchangenetwork.net/schema/node/2}TransactionStatusCode"/>
 *         &lt;element name="statusDetail" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *       &lt;/sequence>
 *       &lt;attribute name="objectId" use="required" type="{http://www.w3.org/2001/XMLSchema}ID" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "NotificationMessageType", propOrder = {
    "messageCategory",
    "messageName",
    "status",
    "statusDetail"
})
public class NotificationMessageType {

    @XmlElement(required = true)
    @XmlSchemaType(name = "string")
    protected NotificationMessageCategoryType messageCategory;
    @XmlElement(required = true)
    protected String messageName;
    @XmlElement(required = true)
    @XmlSchemaType(name = "string")
    protected TransactionStatusCode status;
    @XmlElement(required = true)
    protected String statusDetail;
    @XmlAttribute(name = "objectId", required = true)
    @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
    @XmlID
    @XmlSchemaType(name = "ID")
    protected String objectId;

    /**
     * Gets the value of the messageCategory property.
     * 
     * @return
     *     possible object is
     *     {@link NotificationMessageCategoryType }
     *     
     */
    public NotificationMessageCategoryType getMessageCategory() {
        return messageCategory;
    }

    /**
     * Sets the value of the messageCategory property.
     * 
     * @param value
     *     allowed object is
     *     {@link NotificationMessageCategoryType }
     *     
     */
    public void setMessageCategory(NotificationMessageCategoryType value) {
        this.messageCategory = value;
    }

    /**
     * Gets the value of the messageName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMessageName() {
        return messageName;
    }

    /**
     * Sets the value of the messageName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMessageName(String value) {
        this.messageName = value;
    }

    /**
     * Gets the value of the status property.
     * 
     * @return
     *     possible object is
     *     {@link TransactionStatusCode }
     *     
     */
    public TransactionStatusCode getStatus() {
        return status;
    }

    /**
     * Sets the value of the status property.
     * 
     * @param value
     *     allowed object is
     *     {@link TransactionStatusCode }
     *     
     */
    public void setStatus(TransactionStatusCode value) {
        this.status = value;
    }

    /**
     * Gets the value of the statusDetail property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getStatusDetail() {
        return statusDetail;
    }

    /**
     * Sets the value of the statusDetail property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStatusDetail(String value) {
        this.statusDetail = value;
    }

    /**
     * Gets the value of the objectId property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getObjectId() {
        return objectId;
    }

    /**
     * Sets the value of the objectId property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setObjectId(String value) {
        this.objectId = value;
    }

}

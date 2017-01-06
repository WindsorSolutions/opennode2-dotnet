
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
 *         &lt;element name="nodeAddress" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="dataflow" type="{http://www.w3.org/2001/XMLSchema}NCName"/>
 *         &lt;element name="messages" type="{http://www.exchangenetwork.net/schema/node/2}NotificationMessageType" maxOccurs="unbounded"/>
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
    "nodeAddress",
    "dataflow",
    "messages"
})
@XmlRootElement(name = "Notify")
public class Notify {

    @XmlElement(required = true)
    protected String securityToken;
    @XmlElement(required = true)
    protected String nodeAddress;
    @XmlElement(required = true)
    @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
    @XmlSchemaType(name = "NCName")
    protected String dataflow;
    @XmlElement(required = true)
    protected List<NotificationMessageType> messages;

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
     * Gets the value of the nodeAddress property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNodeAddress() {
        return nodeAddress;
    }

    /**
     * Sets the value of the nodeAddress property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNodeAddress(String value) {
        this.nodeAddress = value;
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
     * Gets the value of the messages property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the messages property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getMessages().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link NotificationMessageType }
     * 
     * 
     */
    public List<NotificationMessageType> getMessages() {
        if (messages == null) {
            messages = new ArrayList<NotificationMessageType>();
        }
        return this.messages;
    }

}

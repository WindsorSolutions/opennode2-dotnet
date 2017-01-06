
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


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
 *         &lt;element name="hello" type="{http://www.w3.org/2001/XMLSchema}string"/>
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
    "hello"
})
@XmlRootElement(name = "NodePing")
public class NodePing {

    @XmlElement(required = true)
    protected String hello;

    /**
     * Gets the value of the hello property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getHello() {
        return hello;
    }

    /**
     * Sets the value of the hello property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setHello(String value) {
        this.hello = value;
    }

}


package net.exchangenetwork.schema.node._2;

import java.math.BigInteger;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ResultSetType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ResultSetType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="rowId" type="{http://www.w3.org/2001/XMLSchema}integer"/>
 *         &lt;element name="rowCount" type="{http://www.w3.org/2001/XMLSchema}integer"/>
 *         &lt;element name="lastSet" type="{http://www.w3.org/2001/XMLSchema}boolean"/>
 *         &lt;element name="results" type="{http://www.exchangenetwork.net/schema/node/2}GenericXmlType"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ResultSetType", propOrder = {
    "rowId",
    "rowCount",
    "lastSet",
    "results"
})
public class ResultSetType {

    @XmlElement(required = true)
    protected BigInteger rowId;
    @XmlElement(required = true)
    protected BigInteger rowCount;
    protected boolean lastSet;
    @XmlElement(required = true)
    protected GenericXmlType results;

    /**
     * Gets the value of the rowId property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    public BigInteger getRowId() {
        return rowId;
    }

    /**
     * Sets the value of the rowId property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setRowId(BigInteger value) {
        this.rowId = value;
    }

    /**
     * Gets the value of the rowCount property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    public BigInteger getRowCount() {
        return rowCount;
    }

    /**
     * Sets the value of the rowCount property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setRowCount(BigInteger value) {
        this.rowCount = value;
    }

    /**
     * Gets the value of the lastSet property.
     * 
     */
    public boolean isLastSet() {
        return lastSet;
    }

    /**
     * Sets the value of the lastSet property.
     * 
     */
    public void setLastSet(boolean value) {
        this.lastSet = value;
    }

    /**
     * Gets the value of the results property.
     * 
     * @return
     *     possible object is
     *     {@link GenericXmlType }
     *     
     */
    public GenericXmlType getResults() {
        return results;
    }

    /**
     * Sets the value of the results property.
     * 
     * @param value
     *     allowed object is
     *     {@link GenericXmlType }
     *     
     */
    public void setResults(GenericXmlType value) {
        this.results = value;
    }

}

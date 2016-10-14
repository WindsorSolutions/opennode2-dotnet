
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ArrayOfAQSParameterTag complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfAQSParameterTag">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AQSParameterTag" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}AQSParameterTag" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfAQSParameterTag", propOrder = {
    "aqsParameterTag"
})
public class ArrayOfAQSParameterTag {

    @XmlElement(name = "AQSParameterTag", nillable = true)
    protected List<AQSParameterTag> aqsParameterTag;

    /**
     * Gets the value of the aqsParameterTag property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the aqsParameterTag property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getAQSParameterTag().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link AQSParameterTag }
     * 
     * 
     */
    public List<AQSParameterTag> getAQSParameterTag() {
        if (aqsParameterTag == null) {
            aqsParameterTag = new ArrayList<AQSParameterTag>();
        }
        return this.aqsParameterTag;
    }

}

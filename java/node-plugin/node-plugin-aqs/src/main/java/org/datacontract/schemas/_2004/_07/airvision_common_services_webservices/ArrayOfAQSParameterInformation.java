
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ArrayOfAQSParameterInformation complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfAQSParameterInformation">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="AQSParameterInformation" type="{http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService}AQSParameterInformation" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfAQSParameterInformation", propOrder = {
    "aqsParameterInformation"
})
public class ArrayOfAQSParameterInformation {

    @XmlElement(name = "AQSParameterInformation", nillable = true)
    protected List<AQSParameterInformation> aqsParameterInformation;

    /**
     * Gets the value of the aqsParameterInformation property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the aqsParameterInformation property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getAQSParameterInformation().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link AQSParameterInformation }
     * 
     * 
     */
    public List<AQSParameterInformation> getAQSParameterInformation() {
        if (aqsParameterInformation == null) {
            aqsParameterInformation = new ArrayList<AQSParameterInformation>();
        }
        return this.aqsParameterInformation;
    }

}

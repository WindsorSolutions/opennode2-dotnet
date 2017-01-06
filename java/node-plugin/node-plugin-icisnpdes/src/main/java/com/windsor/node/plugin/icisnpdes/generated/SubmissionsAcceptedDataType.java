//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SubmissionsAcceptedDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SubmissionsAcceptedDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SubmissionAccepted" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SubmissionsAcceptedDataType", propOrder = {
    "submissionAccepted"
})
public class SubmissionsAcceptedDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SubmissionAccepted")
    protected List<SubmissionAcceptedDataType> submissionAccepted;

    /**
     * Gets the value of the submissionAccepted property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the submissionAccepted property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSubmissionAccepted().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SubmissionAcceptedDataType }
     * 
     * 
     */
    public List<SubmissionAcceptedDataType> getSubmissionAccepted() {
        if (submissionAccepted == null) {
            submissionAccepted = new ArrayList<SubmissionAcceptedDataType>();
        }
        return this.submissionAccepted;
    }

    /**
     * 
     * 
     */
    public void setSubmissionAccepted(List<SubmissionAcceptedDataType> submissionAccepted) {
        this.submissionAccepted = submissionAccepted;
    }

    public boolean isSetSubmissionAccepted() {
        return ((this.submissionAccepted!= null)&&(!this.submissionAccepted.isEmpty()));
    }

    public void unsetSubmissionAccepted() {
        this.submissionAccepted = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SubmissionsAcceptedDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SubmissionsAcceptedDataType that = ((SubmissionsAcceptedDataType) object);
        {
            List<SubmissionAcceptedDataType> lhsSubmissionAccepted;
            lhsSubmissionAccepted = (this.isSetSubmissionAccepted()?this.getSubmissionAccepted():null);
            List<SubmissionAcceptedDataType> rhsSubmissionAccepted;
            rhsSubmissionAccepted = (that.isSetSubmissionAccepted()?that.getSubmissionAccepted():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionAccepted", lhsSubmissionAccepted), LocatorUtils.property(thatLocator, "submissionAccepted", rhsSubmissionAccepted), lhsSubmissionAccepted, rhsSubmissionAccepted)) {
                return false;
            }
        }
        return true;
    }

    public boolean equals(Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    public int hashCode(ObjectLocator locator, HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            List<SubmissionAcceptedDataType> theSubmissionAccepted;
            theSubmissionAccepted = (this.isSetSubmissionAccepted()?this.getSubmissionAccepted():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionAccepted", theSubmissionAccepted), currentHashCode, theSubmissionAccepted);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

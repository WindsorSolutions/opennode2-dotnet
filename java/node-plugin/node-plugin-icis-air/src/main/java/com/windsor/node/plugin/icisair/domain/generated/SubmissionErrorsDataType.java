//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2014.09.02 at 11:05:46 AM PDT 
//


package com.windsor.node.plugin.icisair.domain.generated;

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
 * <p>Java class for SubmissionErrorsDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SubmissionErrorsDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SubmissionError" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SubmissionErrorsDataType", propOrder = {
    "submissionError"
})
public class SubmissionErrorsDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SubmissionError")
    protected List<SubmissionErrorDataType> submissionError;

    /**
     * Gets the value of the submissionError property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the submissionError property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSubmissionError().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SubmissionErrorDataType }
     * 
     * 
     */
    public List<SubmissionErrorDataType> getSubmissionError() {
        if (submissionError == null) {
            submissionError = new ArrayList<SubmissionErrorDataType>();
        }
        return this.submissionError;
    }

    /**
     * 
     * 
     */
    public void setSubmissionError(List<SubmissionErrorDataType> submissionError) {
        this.submissionError = submissionError;
    }

    public boolean isSetSubmissionError() {
        return ((this.submissionError!= null)&&(!this.submissionError.isEmpty()));
    }

    public void unsetSubmissionError() {
        this.submissionError = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SubmissionErrorsDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SubmissionErrorsDataType that = ((SubmissionErrorsDataType) object);
        {
            List<SubmissionErrorDataType> lhsSubmissionError;
            lhsSubmissionError = (this.isSetSubmissionError()?this.getSubmissionError():null);
            List<SubmissionErrorDataType> rhsSubmissionError;
            rhsSubmissionError = (that.isSetSubmissionError()?that.getSubmissionError():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionError", lhsSubmissionError), LocatorUtils.property(thatLocator, "submissionError", rhsSubmissionError), lhsSubmissionError, rhsSubmissionError)) {
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
            List<SubmissionErrorDataType> theSubmissionError;
            theSubmissionError = (this.isSetSubmissionError()?this.getSubmissionError():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionError", theSubmissionError), currentHashCode, theSubmissionError);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

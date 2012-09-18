//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

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
 * <p>Java class for SubmissionTypeDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SubmissionTypeDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SubmissionTypeName"/>
 *         &lt;choice>
 *           &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SubmissionsAccepted" maxOccurs="unbounded" minOccurs="0"/>
 *           &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SubmissionErrors" maxOccurs="unbounded" minOccurs="0"/>
 *           &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SubmissionSummary"/>
 *         &lt;/choice>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SubmissionTypeDataType", propOrder = {
    "submissionTypeName",
    "submissionsAccepted",
    "submissionErrors",
    "submissionSummary"
})
public class SubmissionTypeDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SubmissionTypeName", required = true)
    protected String submissionTypeName;
    @XmlElement(name = "SubmissionsAccepted")
    protected List<SubmissionsAcceptedDataType> submissionsAccepted;
    @XmlElement(name = "SubmissionErrors")
    protected List<SubmissionErrorsDataType> submissionErrors;
    @XmlElement(name = "SubmissionSummary")
    protected SubmissionSummaryDataType submissionSummary;

    /**
     * Gets the value of the submissionTypeName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSubmissionTypeName() {
        return submissionTypeName;
    }

    /**
     * Sets the value of the submissionTypeName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSubmissionTypeName(String value) {
        this.submissionTypeName = value;
    }

    public boolean isSetSubmissionTypeName() {
        return (this.submissionTypeName!= null);
    }

    /**
     * Gets the value of the submissionsAccepted property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the submissionsAccepted property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSubmissionsAccepted().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SubmissionsAcceptedDataType }
     * 
     * 
     */
    public List<SubmissionsAcceptedDataType> getSubmissionsAccepted() {
        if (submissionsAccepted == null) {
            submissionsAccepted = new ArrayList<SubmissionsAcceptedDataType>();
        }
        return this.submissionsAccepted;
    }

    /**
     * 
     * 
     */
    public void setSubmissionsAccepted(List<SubmissionsAcceptedDataType> submissionsAccepted) {
        this.submissionsAccepted = submissionsAccepted;
    }

    public boolean isSetSubmissionsAccepted() {
        return ((this.submissionsAccepted!= null)&&(!this.submissionsAccepted.isEmpty()));
    }

    public void unsetSubmissionsAccepted() {
        this.submissionsAccepted = null;
    }

    /**
     * Gets the value of the submissionErrors property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the submissionErrors property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSubmissionErrors().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SubmissionErrorsDataType }
     * 
     * 
     */
    public List<SubmissionErrorsDataType> getSubmissionErrors() {
        if (submissionErrors == null) {
            submissionErrors = new ArrayList<SubmissionErrorsDataType>();
        }
        return this.submissionErrors;
    }

    /**
     * 
     * 
     */
    public void setSubmissionErrors(List<SubmissionErrorsDataType> submissionErrors) {
        this.submissionErrors = submissionErrors;
    }

    public boolean isSetSubmissionErrors() {
        return ((this.submissionErrors!= null)&&(!this.submissionErrors.isEmpty()));
    }

    public void unsetSubmissionErrors() {
        this.submissionErrors = null;
    }

    /**
     * Gets the value of the submissionSummary property.
     * 
     * @return
     *     possible object is
     *     {@link SubmissionSummaryDataType }
     *     
     */
    public SubmissionSummaryDataType getSubmissionSummary() {
        return submissionSummary;
    }

    /**
     * Sets the value of the submissionSummary property.
     * 
     * @param value
     *     allowed object is
     *     {@link SubmissionSummaryDataType }
     *     
     */
    public void setSubmissionSummary(SubmissionSummaryDataType value) {
        this.submissionSummary = value;
    }

    public boolean isSetSubmissionSummary() {
        return (this.submissionSummary!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SubmissionTypeDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SubmissionTypeDataType that = ((SubmissionTypeDataType) object);
        {
            String lhsSubmissionTypeName;
            lhsSubmissionTypeName = this.getSubmissionTypeName();
            String rhsSubmissionTypeName;
            rhsSubmissionTypeName = that.getSubmissionTypeName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionTypeName", lhsSubmissionTypeName), LocatorUtils.property(thatLocator, "submissionTypeName", rhsSubmissionTypeName), lhsSubmissionTypeName, rhsSubmissionTypeName)) {
                return false;
            }
        }
        {
            List<SubmissionsAcceptedDataType> lhsSubmissionsAccepted;
            lhsSubmissionsAccepted = (this.isSetSubmissionsAccepted()?this.getSubmissionsAccepted():null);
            List<SubmissionsAcceptedDataType> rhsSubmissionsAccepted;
            rhsSubmissionsAccepted = (that.isSetSubmissionsAccepted()?that.getSubmissionsAccepted():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionsAccepted", lhsSubmissionsAccepted), LocatorUtils.property(thatLocator, "submissionsAccepted", rhsSubmissionsAccepted), lhsSubmissionsAccepted, rhsSubmissionsAccepted)) {
                return false;
            }
        }
        {
            List<SubmissionErrorsDataType> lhsSubmissionErrors;
            lhsSubmissionErrors = (this.isSetSubmissionErrors()?this.getSubmissionErrors():null);
            List<SubmissionErrorsDataType> rhsSubmissionErrors;
            rhsSubmissionErrors = (that.isSetSubmissionErrors()?that.getSubmissionErrors():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionErrors", lhsSubmissionErrors), LocatorUtils.property(thatLocator, "submissionErrors", rhsSubmissionErrors), lhsSubmissionErrors, rhsSubmissionErrors)) {
                return false;
            }
        }
        {
            SubmissionSummaryDataType lhsSubmissionSummary;
            lhsSubmissionSummary = this.getSubmissionSummary();
            SubmissionSummaryDataType rhsSubmissionSummary;
            rhsSubmissionSummary = that.getSubmissionSummary();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionSummary", lhsSubmissionSummary), LocatorUtils.property(thatLocator, "submissionSummary", rhsSubmissionSummary), lhsSubmissionSummary, rhsSubmissionSummary)) {
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
            String theSubmissionTypeName;
            theSubmissionTypeName = this.getSubmissionTypeName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionTypeName", theSubmissionTypeName), currentHashCode, theSubmissionTypeName);
        }
        {
            List<SubmissionsAcceptedDataType> theSubmissionsAccepted;
            theSubmissionsAccepted = (this.isSetSubmissionsAccepted()?this.getSubmissionsAccepted():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionsAccepted", theSubmissionsAccepted), currentHashCode, theSubmissionsAccepted);
        }
        {
            List<SubmissionErrorsDataType> theSubmissionErrors;
            theSubmissionErrors = (this.isSetSubmissionErrors()?this.getSubmissionErrors():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionErrors", theSubmissionErrors), currentHashCode, theSubmissionErrors);
        }
        {
            SubmissionSummaryDataType theSubmissionSummary;
            theSubmissionSummary = this.getSubmissionSummary();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionSummary", theSubmissionSummary), currentHashCode, theSubmissionSummary);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

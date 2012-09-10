//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
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
 * <p>Java class for SubmissionErrorDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SubmissionErrorDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SubmissionErrorKey" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ErrorReport" maxOccurs="unbounded"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SubmissionErrorDataType", propOrder = {
    "submissionErrorKey",
    "errorReport"
})
public class SubmissionErrorDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "SubmissionErrorKey")
    protected SubmissionErrorKeyDataType submissionErrorKey;
    @XmlElement(name = "ErrorReport", required = true)
    protected List<ErrorReportDataType> errorReport;

    /**
     * Gets the value of the submissionErrorKey property.
     * 
     * @return
     *     possible object is
     *     {@link SubmissionErrorKeyDataType }
     *     
     */
    public SubmissionErrorKeyDataType getSubmissionErrorKey() {
        return submissionErrorKey;
    }

    /**
     * Sets the value of the submissionErrorKey property.
     * 
     * @param value
     *     allowed object is
     *     {@link SubmissionErrorKeyDataType }
     *     
     */
    public void setSubmissionErrorKey(SubmissionErrorKeyDataType value) {
        this.submissionErrorKey = value;
    }

    public boolean isSetSubmissionErrorKey() {
        return (this.submissionErrorKey!= null);
    }

    /**
     * Gets the value of the errorReport property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the errorReport property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getErrorReport().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link ErrorReportDataType }
     * 
     * 
     */
    public List<ErrorReportDataType> getErrorReport() {
        if (errorReport == null) {
            errorReport = new ArrayList<ErrorReportDataType>();
        }
        return this.errorReport;
    }

    /**
     * 
     * 
     */
    public void setErrorReport(List<ErrorReportDataType> errorReport) {
        this.errorReport = errorReport;
    }

    public boolean isSetErrorReport() {
        return ((this.errorReport!= null)&&(!this.errorReport.isEmpty()));
    }

    public void unsetErrorReport() {
        this.errorReport = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SubmissionErrorDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SubmissionErrorDataType that = ((SubmissionErrorDataType) object);
        {
            SubmissionErrorKeyDataType lhsSubmissionErrorKey;
            lhsSubmissionErrorKey = this.getSubmissionErrorKey();
            SubmissionErrorKeyDataType rhsSubmissionErrorKey;
            rhsSubmissionErrorKey = that.getSubmissionErrorKey();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionErrorKey", lhsSubmissionErrorKey), LocatorUtils.property(thatLocator, "submissionErrorKey", rhsSubmissionErrorKey), lhsSubmissionErrorKey, rhsSubmissionErrorKey)) {
                return false;
            }
        }
        {
            List<ErrorReportDataType> lhsErrorReport;
            lhsErrorReport = (this.isSetErrorReport()?this.getErrorReport():null);
            List<ErrorReportDataType> rhsErrorReport;
            rhsErrorReport = (that.isSetErrorReport()?that.getErrorReport():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "errorReport", lhsErrorReport), LocatorUtils.property(thatLocator, "errorReport", rhsErrorReport), lhsErrorReport, rhsErrorReport)) {
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
            SubmissionErrorKeyDataType theSubmissionErrorKey;
            theSubmissionErrorKey = this.getSubmissionErrorKey();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionErrorKey", theSubmissionErrorKey), currentHashCode, theSubmissionErrorKey);
        }
        {
            List<ErrorReportDataType> theErrorReport;
            theErrorReport = (this.isSetErrorReport()?this.getErrorReport():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "errorReport", theErrorReport), currentHashCode, theErrorReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

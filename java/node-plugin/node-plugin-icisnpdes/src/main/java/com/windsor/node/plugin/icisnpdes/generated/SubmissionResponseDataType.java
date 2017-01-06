//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.DateNoTimeZoneAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SubmissionResponseDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SubmissionResponseDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}TransactionIdentifier"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SubmissionDate"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}ProcessedDate"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SubmittingParty" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}FileSubmissionErrors" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SubmissionResponseDataType", propOrder = {
    "transactionIdentifier",
    "submissionDate",
    "processedDate",
    "submittingParty",
    "fileSubmissionErrors"
})
public class SubmissionResponseDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionIdentifier", required = true)
    protected String transactionIdentifier;
    @XmlElement(name = "SubmissionDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateNoTimeZoneAdapter.class)
    protected Date submissionDate;
    @XmlElement(name = "ProcessedDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateNoTimeZoneAdapter.class)
    protected Date processedDate;
    @XmlElement(name = "SubmittingParty")
    protected List<SubmittingPartyDataType> submittingParty;
    @XmlElement(name = "FileSubmissionErrors")
    protected List<FileSubmissionErrorsDataType> fileSubmissionErrors;

    /**
     * Gets the value of the transactionIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTransactionIdentifier() {
        return transactionIdentifier;
    }

    /**
     * Sets the value of the transactionIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTransactionIdentifier(String value) {
        this.transactionIdentifier = value;
    }

    public boolean isSetTransactionIdentifier() {
        return (this.transactionIdentifier!= null);
    }

    /**
     * Gets the value of the submissionDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public Date getSubmissionDate() {
        return submissionDate;
    }

    /**
     * Sets the value of the submissionDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSubmissionDate(Date value) {
        this.submissionDate = value;
    }

    public boolean isSetSubmissionDate() {
        return (this.submissionDate!= null);
    }

    /**
     * Gets the value of the processedDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public Date getProcessedDate() {
        return processedDate;
    }

    /**
     * Sets the value of the processedDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setProcessedDate(Date value) {
        this.processedDate = value;
    }

    public boolean isSetProcessedDate() {
        return (this.processedDate!= null);
    }

    /**
     * Gets the value of the submittingParty property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the submittingParty property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSubmittingParty().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SubmittingPartyDataType }
     * 
     * 
     */
    public List<SubmittingPartyDataType> getSubmittingParty() {
        if (submittingParty == null) {
            submittingParty = new ArrayList<SubmittingPartyDataType>();
        }
        return this.submittingParty;
    }

    /**
     * 
     * 
     */
    public void setSubmittingParty(List<SubmittingPartyDataType> submittingParty) {
        this.submittingParty = submittingParty;
    }

    public boolean isSetSubmittingParty() {
        return ((this.submittingParty!= null)&&(!this.submittingParty.isEmpty()));
    }

    public void unsetSubmittingParty() {
        this.submittingParty = null;
    }

    /**
     * Gets the value of the fileSubmissionErrors property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the fileSubmissionErrors property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getFileSubmissionErrors().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link FileSubmissionErrorsDataType }
     * 
     * 
     */
    public List<FileSubmissionErrorsDataType> getFileSubmissionErrors() {
        if (fileSubmissionErrors == null) {
            fileSubmissionErrors = new ArrayList<FileSubmissionErrorsDataType>();
        }
        return this.fileSubmissionErrors;
    }

    /**
     * 
     * 
     */
    public void setFileSubmissionErrors(List<FileSubmissionErrorsDataType> fileSubmissionErrors) {
        this.fileSubmissionErrors = fileSubmissionErrors;
    }

    public boolean isSetFileSubmissionErrors() {
        return ((this.fileSubmissionErrors!= null)&&(!this.fileSubmissionErrors.isEmpty()));
    }

    public void unsetFileSubmissionErrors() {
        this.fileSubmissionErrors = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SubmissionResponseDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SubmissionResponseDataType that = ((SubmissionResponseDataType) object);
        {
            String lhsTransactionIdentifier;
            lhsTransactionIdentifier = this.getTransactionIdentifier();
            String rhsTransactionIdentifier;
            rhsTransactionIdentifier = that.getTransactionIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "transactionIdentifier", lhsTransactionIdentifier), LocatorUtils.property(thatLocator, "transactionIdentifier", rhsTransactionIdentifier), lhsTransactionIdentifier, rhsTransactionIdentifier)) {
                return false;
            }
        }
        {
            Date lhsSubmissionDate;
            lhsSubmissionDate = this.getSubmissionDate();
            Date rhsSubmissionDate;
            rhsSubmissionDate = that.getSubmissionDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submissionDate", lhsSubmissionDate), LocatorUtils.property(thatLocator, "submissionDate", rhsSubmissionDate), lhsSubmissionDate, rhsSubmissionDate)) {
                return false;
            }
        }
        {
            Date lhsProcessedDate;
            lhsProcessedDate = this.getProcessedDate();
            Date rhsProcessedDate;
            rhsProcessedDate = that.getProcessedDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "processedDate", lhsProcessedDate), LocatorUtils.property(thatLocator, "processedDate", rhsProcessedDate), lhsProcessedDate, rhsProcessedDate)) {
                return false;
            }
        }
        {
            List<SubmittingPartyDataType> lhsSubmittingParty;
            lhsSubmittingParty = (this.isSetSubmittingParty()?this.getSubmittingParty():null);
            List<SubmittingPartyDataType> rhsSubmittingParty;
            rhsSubmittingParty = (that.isSetSubmittingParty()?that.getSubmittingParty():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "submittingParty", lhsSubmittingParty), LocatorUtils.property(thatLocator, "submittingParty", rhsSubmittingParty), lhsSubmittingParty, rhsSubmittingParty)) {
                return false;
            }
        }
        {
            List<FileSubmissionErrorsDataType> lhsFileSubmissionErrors;
            lhsFileSubmissionErrors = (this.isSetFileSubmissionErrors()?this.getFileSubmissionErrors():null);
            List<FileSubmissionErrorsDataType> rhsFileSubmissionErrors;
            rhsFileSubmissionErrors = (that.isSetFileSubmissionErrors()?that.getFileSubmissionErrors():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "fileSubmissionErrors", lhsFileSubmissionErrors), LocatorUtils.property(thatLocator, "fileSubmissionErrors", rhsFileSubmissionErrors), lhsFileSubmissionErrors, rhsFileSubmissionErrors)) {
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
            String theTransactionIdentifier;
            theTransactionIdentifier = this.getTransactionIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "transactionIdentifier", theTransactionIdentifier), currentHashCode, theTransactionIdentifier);
        }
        {
            Date theSubmissionDate;
            theSubmissionDate = this.getSubmissionDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submissionDate", theSubmissionDate), currentHashCode, theSubmissionDate);
        }
        {
            Date theProcessedDate;
            theProcessedDate = this.getProcessedDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "processedDate", theProcessedDate), currentHashCode, theProcessedDate);
        }
        {
            List<SubmittingPartyDataType> theSubmittingParty;
            theSubmittingParty = (this.isSetSubmittingParty()?this.getSubmittingParty():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "submittingParty", theSubmittingParty), currentHashCode, theSubmittingParty);
        }
        {
            List<FileSubmissionErrorsDataType> theFileSubmissionErrors;
            theFileSubmissionErrors = (this.isSetFileSubmissionErrors()?this.getFileSubmissionErrors():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "fileSubmissionErrors", theFileSubmissionErrors), currentHashCode, theFileSubmissionErrors);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.AttributeOverride;
import javax.persistence.AttributeOverrides;
import javax.persistence.Column;
import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
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
 * <p>Java class for SingleEventViolationData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SingleEventViolationData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SingleEventViolation"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SingleEventViolationData", propOrder = {
    "transactionHeader",
    "singleEventViolation"
})
@Entity(name = "SingleEventViolationData")
@Table(name = "ICS_SNGL_EVT_VIOL")
@Inheritance(strategy = InheritanceType.JOINED)
public class SingleEventViolationData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "SingleEventViolation", required = true)
    protected SingleEventViolation singleEventViolation;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the transactionHeader property.
     * 
     * @return
     *     possible object is
     *     {@link TransactionHeader }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "transactionType", column = @Column(name = "TRANSACTION_TYPE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "transactionTimestamp", column = @Column(name = "TRANSACTION_TIMESTAMP"))
    })
    public TransactionHeader getTransactionHeader() {
        return transactionHeader;
    }

    /**
     * Sets the value of the transactionHeader property.
     * 
     * @param value
     *     allowed object is
     *     {@link TransactionHeader }
     *     
     */
    public void setTransactionHeader(TransactionHeader value) {
        this.transactionHeader = value;
    }

    @Transient
    public boolean isSetTransactionHeader() {
        return (this.transactionHeader!= null);
    }

    /**
     * Gets the value of the singleEventViolation property.
     * 
     * @return
     *     possible object is
     *     {@link SingleEventViolation }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "singleEventViolationStartDate", column = @Column(name = "SNGL_EVT_VIOL_START_DATE")),
        @AttributeOverride(name = "singleEventViolationEndDate", column = @Column(name = "SNGL_EVT_VIOL_END_DATE")),
        @AttributeOverride(name = "reportableNonComplianceDetectionCode", column = @Column(name = "REP_NON_CMPL_DETECT_CODE", length = 3)),
        @AttributeOverride(name = "reportableNonComplianceDetectionDate", column = @Column(name = "REP_NON_CMPL_DETECT_DATE")),
        @AttributeOverride(name = "reportableNonComplianceResolutionCode", column = @Column(name = "REP_NON_CMPL_RESL_CODE", length = 3)),
        @AttributeOverride(name = "reportableNonComplianceResolutionDate", column = @Column(name = "REP_NON_CMPL_RESL_DATE")),
        @AttributeOverride(name = "singleEventUserDefinedField1", column = @Column(name = "SNGL_EVT_USR_DFND_FLD_1", length = 30)),
        @AttributeOverride(name = "singleEventUserDefinedField2", column = @Column(name = "SNGL_EVT_USR_DFND_FLD_2", length = 30)),
        @AttributeOverride(name = "singleEventUserDefinedField3", column = @Column(name = "SNGL_EVT_USR_DFND_FLD_3", length = 30)),
        @AttributeOverride(name = "singleEventUserDefinedField4", column = @Column(name = "SNGL_EVT_USR_DFND_FLD_4", length = 30)),
        @AttributeOverride(name = "singleEventUserDefinedField5", column = @Column(name = "SNGL_EVT_USR_DFND_FLD_5", length = 30)),
        @AttributeOverride(name = "singleEventCommentText", column = @Column(name = "SNGL_EVT_CMNT_TXT", length = 4000))
    })
    public SingleEventViolation getSingleEventViolation() {
        return singleEventViolation;
    }

    /**
     * Sets the value of the singleEventViolation property.
     * 
     * @param value
     *     allowed object is
     *     {@link SingleEventViolation }
     *     
     */
    public void setSingleEventViolation(SingleEventViolation value) {
        this.singleEventViolation = value;
    }

    @Transient
    public boolean isSetSingleEventViolation() {
        return (this.singleEventViolation!= null);
    }

    /**
     * 
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Id
    @Column(name = "ICS_SNGL_EVT_VIOL_ID")
    public String getdbid() {
        return dbid;
    }

    /**
     * 
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setdbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SingleEventViolationData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SingleEventViolationData that = ((SingleEventViolationData) object);
        {
            TransactionHeader lhsTransactionHeader;
            lhsTransactionHeader = this.getTransactionHeader();
            TransactionHeader rhsTransactionHeader;
            rhsTransactionHeader = that.getTransactionHeader();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "transactionHeader", lhsTransactionHeader), LocatorUtils.property(thatLocator, "transactionHeader", rhsTransactionHeader), lhsTransactionHeader, rhsTransactionHeader)) {
                return false;
            }
        }
        {
            SingleEventViolation lhsSingleEventViolation;
            lhsSingleEventViolation = this.getSingleEventViolation();
            SingleEventViolation rhsSingleEventViolation;
            rhsSingleEventViolation = that.getSingleEventViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "singleEventViolation", lhsSingleEventViolation), LocatorUtils.property(thatLocator, "singleEventViolation", rhsSingleEventViolation), lhsSingleEventViolation, rhsSingleEventViolation)) {
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
            TransactionHeader theTransactionHeader;
            theTransactionHeader = this.getTransactionHeader();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "transactionHeader", theTransactionHeader), currentHashCode, theTransactionHeader);
        }
        {
            SingleEventViolation theSingleEventViolation;
            theSingleEventViolation = this.getSingleEventViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "singleEventViolation", theSingleEventViolation), currentHashCode, theSingleEventViolation);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

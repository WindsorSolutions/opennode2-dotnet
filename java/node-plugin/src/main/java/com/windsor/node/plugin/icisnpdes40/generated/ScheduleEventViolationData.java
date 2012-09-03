//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.09.03 at 08:41:19 AM PDT
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
 * <p>Java class for ScheduleEventViolationData complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="ScheduleEventViolationData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ScheduleEventViolation"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ScheduleEventViolationData", propOrder = {
    "transactionHeader",
    "scheduleEventViolation"
})
@Entity(name = "ScheduleEventViolationData")
@Table(name = "ICS_SCHD_EVT_VIOL")
@Inheritance(strategy = InheritanceType.JOINED)
public class ScheduleEventViolationData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "ScheduleEventViolation", required = true)
    protected ScheduleEventViolation scheduleEventViolation;
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
    public void setTransactionHeader(final TransactionHeader value) {
        this.transactionHeader = value;
    }

    @Transient
    public boolean isSetTransactionHeader() {
        return (this.transactionHeader!= null);
    }

    /**
     * Gets the value of the scheduleEventViolation property.
     *
     * @return
     *     possible object is
     *     {@link ScheduleEventViolation }
     *
     */
    @Embedded
    // FIXME: commented out
//    @AttributeOverrides({
//        @AttributeOverride(name = "reportableNonComplianceResolutionCode", column = @Column(name = "REP_NON_CMPL_RESL_CODE", length = 3)),
//        @AttributeOverride(name = "reportableNonComplianceResolutionDate", column = @Column(name = "REP_NON_CMPL_RESL_DATE"))
//    })
    public ScheduleEventViolation getScheduleEventViolation() {
        return scheduleEventViolation;
    }

    /**
     * Sets the value of the scheduleEventViolation property.
     *
     * @param value
     *     allowed object is
     *     {@link ScheduleEventViolation }
     *
     */
    public void setScheduleEventViolation(final ScheduleEventViolation value) {
        this.scheduleEventViolation = value;
    }

    @Transient
    public boolean isSetScheduleEventViolation() {
        return (this.scheduleEventViolation!= null);
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
    @Column(name = "ICS_SCHD_EVT_VIOL_ID")
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
    public void setdbid(final String value) {
        this.dbid = value;
    }

    @Override
	public boolean equals(final ObjectLocator thisLocator, final ObjectLocator thatLocator, final Object object, final EqualsStrategy strategy) {
        if (!(object instanceof ScheduleEventViolationData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final ScheduleEventViolationData that = ((ScheduleEventViolationData) object);
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
            ScheduleEventViolation lhsScheduleEventViolation;
            lhsScheduleEventViolation = this.getScheduleEventViolation();
            ScheduleEventViolation rhsScheduleEventViolation;
            rhsScheduleEventViolation = that.getScheduleEventViolation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "scheduleEventViolation", lhsScheduleEventViolation), LocatorUtils.property(thatLocator, "scheduleEventViolation", rhsScheduleEventViolation), lhsScheduleEventViolation, rhsScheduleEventViolation)) {
                return false;
            }
        }
        return true;
    }

    @Override
	public boolean equals(final Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    @Override
	public int hashCode(final ObjectLocator locator, final HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            TransactionHeader theTransactionHeader;
            theTransactionHeader = this.getTransactionHeader();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "transactionHeader", theTransactionHeader), currentHashCode, theTransactionHeader);
        }
        {
            ScheduleEventViolation theScheduleEventViolation;
            theScheduleEventViolation = this.getScheduleEventViolation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "scheduleEventViolation", theScheduleEventViolation), currentHashCode, theScheduleEventViolation);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

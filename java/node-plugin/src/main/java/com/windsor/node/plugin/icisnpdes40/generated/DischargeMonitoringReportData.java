//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.AssociationOverride;
import javax.persistence.AssociationOverrides;
import javax.persistence.AttributeOverride;
import javax.persistence.AttributeOverrides;
import javax.persistence.Column;
import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
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
 * <p>Java class for DischargeMonitoringReportData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="DischargeMonitoringReportData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DischargeMonitoringReport"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "DischargeMonitoringReportData", propOrder = {
    "transactionHeader",
    "dischargeMonitoringReport"
})
@Entity(name = "DischargeMonitoringReportData")
@Table(name = "ICS_DSCH_MON_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class DischargeMonitoringReportData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "DischargeMonitoringReport", required = true)
    protected DischargeMonitoringReport dischargeMonitoringReport;
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
     * Gets the value of the dischargeMonitoringReport property.
     * 
     * @return
     *     possible object is
     *     {@link DischargeMonitoringReport }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "signatureDate", column = @Column(name = "SIGN_DATE")),
        @AttributeOverride(name = "principalExecutiveOfficerFirstName", column = @Column(name = "PRNCPL_EXEC_OFFCR_FIRST_NAME", length = 30)),
        @AttributeOverride(name = "principalExecutiveOfficerLastName", column = @Column(name = "PRNCPL_EXEC_OFFCR_LAST_NAME", length = 30)),
        @AttributeOverride(name = "principalExecutiveOfficerTitle", column = @Column(name = "PRNCPL_EXEC_OFFCR_TITLE", length = 40)),
        @AttributeOverride(name = "principalExecutiveOfficerTelephone", column = @Column(name = "PRNCPL_EXEC_OFFCR_TELEPH", length = 10)),
        @AttributeOverride(name = "signatoryFirstName", column = @Column(name = "SIGN_FIRST_NAME", length = 30)),
        @AttributeOverride(name = "signatoryLastName", column = @Column(name = "SIGN_LAST_NAME", length = 30)),
        @AttributeOverride(name = "signatoryTelephone", column = @Column(name = "SIGN_TELEPH", length = 10)),
        @AttributeOverride(name = "reportCommentText", column = @Column(name = "REP_CMNT_TXT", length = 4000)),
        @AttributeOverride(name = "dmrNoDischargeIndicator", column = @Column(name = "DMR_NO_DSCH_IND", length = 3)),
        @AttributeOverride(name = "dmrNoDischargeReceivedDate", column = @Column(name = "DMR_NO_DSCH_RCVD_DATE"))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "reportParameter", joinColumns = {
            @JoinColumn(name = "ICS_DSCH_MON_REP_ID")
        }),
        @AssociationOverride(name = "landApplicationSite", joinColumns = {
            @JoinColumn(name = "ICS_DSCH_MON_REP_ID")
        }),
        @AssociationOverride(name = "surfaceDisposalSite", joinColumns = {
            @JoinColumn(name = "ICS_DSCH_MON_REP_ID")
        }),
        @AssociationOverride(name = "incinerator", joinColumns = {
            @JoinColumn(name = "ICS_DSCH_MON_REP_ID")
        }),
        @AssociationOverride(name = "coDisposalSite", joinColumns = {
            @JoinColumn(name = "ICS_DSCH_MON_REP_ID")
        })
    })
    public DischargeMonitoringReport getDischargeMonitoringReport() {
        return dischargeMonitoringReport;
    }

    /**
     * Sets the value of the dischargeMonitoringReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link DischargeMonitoringReport }
     *     
     */
    public void setDischargeMonitoringReport(DischargeMonitoringReport value) {
        this.dischargeMonitoringReport = value;
    }

    @Transient
    public boolean isSetDischargeMonitoringReport() {
        return (this.dischargeMonitoringReport!= null);
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
    @Column(name = "ICS_DSCH_MON_REP_ID")
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
        if (!(object instanceof DischargeMonitoringReportData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final DischargeMonitoringReportData that = ((DischargeMonitoringReportData) object);
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
            DischargeMonitoringReport lhsDischargeMonitoringReport;
            lhsDischargeMonitoringReport = this.getDischargeMonitoringReport();
            DischargeMonitoringReport rhsDischargeMonitoringReport;
            rhsDischargeMonitoringReport = that.getDischargeMonitoringReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dischargeMonitoringReport", lhsDischargeMonitoringReport), LocatorUtils.property(thatLocator, "dischargeMonitoringReport", rhsDischargeMonitoringReport), lhsDischargeMonitoringReport, rhsDischargeMonitoringReport)) {
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
            DischargeMonitoringReport theDischargeMonitoringReport;
            theDischargeMonitoringReport = this.getDischargeMonitoringReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dischargeMonitoringReport", theDischargeMonitoringReport), currentHashCode, theDischargeMonitoringReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

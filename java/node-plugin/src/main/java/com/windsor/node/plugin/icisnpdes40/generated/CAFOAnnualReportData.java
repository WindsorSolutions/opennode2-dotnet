//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.09.03 at 11:14:37 AM PDT
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
 * <p>Java class for CAFOAnnualReportData complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="CAFOAnnualReportData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}CAFOAnnualReport"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CAFOAnnualReportData", propOrder = {
    "transactionHeader",
    "cafoAnnualReport"
})
@Entity(name = "CAFOAnnualReportData")
@Table(name = "ICS_CAFO_ANNUL_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class CAFOAnnualReportData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "CAFOAnnualReport", required = true)
    protected CAFOAnnualReport cafoAnnualReport;
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
     * Gets the value of the cafoAnnualReport property.
     *
     * @return
     *     possible object is
     *     {@link CAFOAnnualReport }
     *
     */
    @Embedded
    // FIXME: commented out
//    @AttributeOverrides({
//        @AttributeOverride(name = "dischargesDuringYearProductionAreaIndicator", column = @Column(name = "DSCH_DRNG_YEAR_PROD_AREA_IND", length = 3)),
//        @AttributeOverride(name = "solidManureLitterGeneratedAmount", column = @Column(name = "SOLID_MNUR_LTTR_GNRTD_AMT", scale = 0)),
//        @AttributeOverride(name = "liquidManureWastewaterGeneratedAmount", column = @Column(name = "LIQUID_MNUR_WW_GNRTD_AMT", scale = 0)),
//        @AttributeOverride(name = "solidManureLitterTransferAmount", column = @Column(name = "SOLID_MNUR_LTTR_TRANS_AMT", scale = 0)),
//        @AttributeOverride(name = "liquidManureWastewaterTransferAmount", column = @Column(name = "LIQUID_MNUR_WW_TRANS_AMT", scale = 0)),
//        @AttributeOverride(name = "nmpDevelopedCertifiedPlannerApprovedIndicator", column = @Column(name = "NMP_DVLPD_CERT_PLNR_APRVD_IND", columnDefinition = "char(1)", length = 1)),
//        @AttributeOverride(name = "totalNumberAcresNMPIdentified", column = @Column(name = "TTL_NUM_ACRES_NMP_IDNTFD", scale = 0)),
//        @AttributeOverride(name = "totalNumberAcresUsedLandApplication", column = @Column(name = "TTL_NUM_ACRES_USED_LAND_APPL", scale = 0))
//    })
//    @AssociationOverride(name = "reportedAnimalType")
    public CAFOAnnualReport getCAFOAnnualReport() {
        return cafoAnnualReport;
    }

    /**
     * Sets the value of the cafoAnnualReport property.
     *
     * @param value
     *     allowed object is
     *     {@link CAFOAnnualReport }
     *
     */
    public void setCAFOAnnualReport(final CAFOAnnualReport value) {
        this.cafoAnnualReport = value;
    }

    @Transient
    public boolean isSetCAFOAnnualReport() {
        return (this.cafoAnnualReport!= null);
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
    @Column(name = "ICS_CAFO_ANNUL_REP_ID")
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
        if (!(object instanceof CAFOAnnualReportData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final CAFOAnnualReportData that = ((CAFOAnnualReportData) object);
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
            CAFOAnnualReport lhsCAFOAnnualReport;
            lhsCAFOAnnualReport = this.getCAFOAnnualReport();
            CAFOAnnualReport rhsCAFOAnnualReport;
            rhsCAFOAnnualReport = that.getCAFOAnnualReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "cafoAnnualReport", lhsCAFOAnnualReport), LocatorUtils.property(thatLocator, "cafoAnnualReport", rhsCAFOAnnualReport), lhsCAFOAnnualReport, rhsCAFOAnnualReport)) {
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
            CAFOAnnualReport theCAFOAnnualReport;
            theCAFOAnnualReport = this.getCAFOAnnualReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "cafoAnnualReport", theCAFOAnnualReport), currentHashCode, theCAFOAnnualReport);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
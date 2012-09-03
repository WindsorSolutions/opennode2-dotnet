//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.09.03 at 08:02:26 AM PDT
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
 * <p>Java class for SSOEventReportData complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="SSOEventReportData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}SSOEventReport"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SSOEventReportData", propOrder = {
    "transactionHeader",
    "ssoEventReport"
})
@Entity(name = "SSOEventReportData")
@Table(name = "ICS_SSO_EVT_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class SSOEventReportData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "SSOEventReport", required = true)
    protected SSOEventReport ssoEventReport;
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
     * Gets the value of the ssoEventReport property.
     *
     * @return
     *     possible object is
     *     {@link SSOEventReport }
     *
     */
    @Embedded
    // FIXME: commented out
//    @AttributeOverrides({
//        @AttributeOverride(name = "causeSSOOverflowEvent", column = @Column(name = "CAUSE_SSO_OVRFLW_EVT", length = 1000)),
//        @AttributeOverride(name = "latitudeMeasure", column = @Column(name = "LAT_MEAS", length = 10)),
//        @AttributeOverride(name = "longitudeMeasure", column = @Column(name = "LONG_MEAS", length = 11)),
//        @AttributeOverride(name = "ssoOverflowLocationStreet", column = @Column(name = "SSO_OVRFLW_LOC_STREET", length = 4000)),
//        @AttributeOverride(name = "durationSSOOverflowEvent", column = @Column(name = "DURATION_SSO_OVRFLW_EVT", scale = 2)),
//        @AttributeOverride(name = "ssoVolume", column = @Column(name = "SSO_VOL", scale = 0)),
//        @AttributeOverride(name = "nameReceivingWater", column = @Column(name = "NAME_RCVG_WTR", length = 1000)),
//        @AttributeOverride(name = "descriptionStepsTaken", column = @Column(name = "DESC_STPS_TAKEN", length = 4000))
//    })
//    @AssociationOverrides({
//        @AssociationOverride(name = "ssoSystemComponent"),
//        @AssociationOverride(name = "ssoSteps"),
//        @AssociationOverride(name = "impactSSOEvent", joinTable = @JoinTable(name = "ICS_IMPACT_SSO_EVT", joinColumns = {
//            @JoinColumn(name = "ICS_SSO_EVT_REP_ID")
//        }))
//    })
    public SSOEventReport getSSOEventReport() {
        return ssoEventReport;
    }

    /**
     * Sets the value of the ssoEventReport property.
     *
     * @param value
     *     allowed object is
     *     {@link SSOEventReport }
     *
     */
    public void setSSOEventReport(final SSOEventReport value) {
        this.ssoEventReport = value;
    }

    @Transient
    public boolean isSetSSOEventReport() {
        return (this.ssoEventReport!= null);
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
    @Column(name = "ICS_SSO_EVT_REP_ID")
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
        if (!(object instanceof SSOEventReportData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final SSOEventReportData that = ((SSOEventReportData) object);
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
            SSOEventReport lhsSSOEventReport;
            lhsSSOEventReport = this.getSSOEventReport();
            SSOEventReport rhsSSOEventReport;
            rhsSSOEventReport = that.getSSOEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "ssoEventReport", lhsSSOEventReport), LocatorUtils.property(thatLocator, "ssoEventReport", rhsSSOEventReport), lhsSSOEventReport, rhsSSOEventReport)) {
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
            SSOEventReport theSSOEventReport;
            theSSOEventReport = this.getSSOEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "ssoEventReport", theSSOEventReport), currentHashCode, theSSOEventReport);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

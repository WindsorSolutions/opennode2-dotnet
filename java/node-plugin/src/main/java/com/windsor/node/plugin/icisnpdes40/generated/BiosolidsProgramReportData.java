//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
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
 * <p>Java class for BiosolidsProgramReportData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="BiosolidsProgramReportData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}BiosolidsProgramReport"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "BiosolidsProgramReportData", propOrder = {
    "transactionHeader",
    "biosolidsProgramReport"
})
@Entity(name = "BiosolidsProgramReportData")
@Table(name = "ICS_BS_PROG_REP")
@Inheritance(strategy = InheritanceType.JOINED)
public class BiosolidsProgramReportData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "BiosolidsProgramReport", required = true)
    protected BiosolidsProgramReport biosolidsProgramReport;
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
     * Gets the value of the biosolidsProgramReport property.
     * 
     * @return
     *     possible object is
     *     {@link BiosolidsProgramReport }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "numberOfReportUnits", column = @Column(name = "NUM_OF_REP_UNITS", scale = 0)),
        @AttributeOverride(name = "eqProductDistributedMarketedAmount", column = @Column(name = "EQ_PROD_DIST_MARKETED_AMT", scale = 0)),
        @AttributeOverride(name = "landAppliedAmount", column = @Column(name = "LAND_APPLIED_AMT", scale = 0)),
        @AttributeOverride(name = "incineratedAmount", column = @Column(name = "INCINERATED_AMT", scale = 0)),
        @AttributeOverride(name = "codisposedInMSWLandfillAmount", column = @Column(name = "CODISPOSED_IN_MSW_LANDFILL_AMT", scale = 0)),
        @AttributeOverride(name = "surfaceDisposalAmount", column = @Column(name = "SURF_DSPL_AMT", scale = 0)),
        @AttributeOverride(name = "managedOtherMethodsAmount", column = @Column(name = "MNGED_OTHR_MTHDS_AMT", scale = 0)),
        @AttributeOverride(name = "receivedOffsiteSourcesAmount", column = @Column(name = "RCVD_OFFSITE_SRCS_AMT", scale = 0)),
        @AttributeOverride(name = "transferredAmount", column = @Column(name = "TRANSFERRED_AMT", scale = 0)),
        @AttributeOverride(name = "disposedOutOfStateAmount", column = @Column(name = "DISPOSED_OUT_OF_ST_AMT", scale = 0)),
        @AttributeOverride(name = "beneficiallyUsedOutOfStateAmount", column = @Column(name = "BENEF_USED_OUT_OF_ST_AMT", scale = 0)),
        @AttributeOverride(name = "managedOtherMethodsOutOfStateAmount", column = @Column(name = "MNGED_OTHR_MTHDS_OUT_OF_ST_AMT", scale = 0)),
        @AttributeOverride(name = "totalRemovedAmount", column = @Column(name = "TTL_REMOVED_AMT", scale = 0)),
        @AttributeOverride(name = "annualDrySludgeProductionNumber", column = @Column(name = "ANNUL_DRY_SLDG_PROD_NUM", scale = 0)),
        @AttributeOverride(name = "annualLoadingParameterDate", column = @Column(name = "ANNUL_LOADING_PARAM_DATE")),
        @AttributeOverride(name = "annualLoadingBiosolidGallons", column = @Column(name = "ANNUL_LOADING_BS_GAL", scale = 0)),
        @AttributeOverride(name = "annualLoadingBiosolidDMT", column = @Column(name = "ANNUL_LOADING_BS_DMT", scale = 0)),
        @AttributeOverride(name = "annualLoadingNutrientNitrogen", column = @Column(name = "ANNUL_LOADING_NUTR_NITROGEN", scale = 0)),
        @AttributeOverride(name = "annualLoadingNutrientPhosphorous", column = @Column(name = "ANNUL_LOADING_NUTR_PHOSPH", scale = 0)),
        @AttributeOverride(name = "totalNumberLandApplicationViolations", column = @Column(name = "TTL_NUM_LAND_APPL_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberIncineratorViolations", column = @Column(name = "TTL_NUM_INCIN_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberDistributionMarketingViolations", column = @Column(name = "TTL_NUM_DIST_MARKETING_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberSludgeRelatedManagementPracticeViolations", column = @Column(name = "TTL_NUM_SLDG_RLT_MGMT_PRC_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberSurfaceDisposalViolations", column = @Column(name = "TTL_NUM_SURF_DSPL_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberOtherSludgeViolations", column = @Column(name = "TTL_NUM_OTHR_SLDG_VIOL", scale = 0)),
        @AttributeOverride(name = "totalNumberCodisposalViolations", column = @Column(name = "TTL_NUM_CODISPOSAL_VIOL", scale = 0)),
        @AttributeOverride(name = "biosolidsReportComments", column = @Column(name = "BS_REP_CMNTS", length = 4000))
    })
    public BiosolidsProgramReport getBiosolidsProgramReport() {
        return biosolidsProgramReport;
    }

    /**
     * Sets the value of the biosolidsProgramReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link BiosolidsProgramReport }
     *     
     */
    public void setBiosolidsProgramReport(BiosolidsProgramReport value) {
        this.biosolidsProgramReport = value;
    }

    @Transient
    public boolean isSetBiosolidsProgramReport() {
        return (this.biosolidsProgramReport!= null);
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
    @Column(name = "ICS_BS_PROG_REP_ID")
    public String getDbid() {
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
    public void setDbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof BiosolidsProgramReportData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final BiosolidsProgramReportData that = ((BiosolidsProgramReportData) object);
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
            BiosolidsProgramReport lhsBiosolidsProgramReport;
            lhsBiosolidsProgramReport = this.getBiosolidsProgramReport();
            BiosolidsProgramReport rhsBiosolidsProgramReport;
            rhsBiosolidsProgramReport = that.getBiosolidsProgramReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "biosolidsProgramReport", lhsBiosolidsProgramReport), LocatorUtils.property(thatLocator, "biosolidsProgramReport", rhsBiosolidsProgramReport), lhsBiosolidsProgramReport, rhsBiosolidsProgramReport)) {
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
            BiosolidsProgramReport theBiosolidsProgramReport;
            theBiosolidsProgramReport = this.getBiosolidsProgramReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "biosolidsProgramReport", theBiosolidsProgramReport), currentHashCode, theBiosolidsProgramReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

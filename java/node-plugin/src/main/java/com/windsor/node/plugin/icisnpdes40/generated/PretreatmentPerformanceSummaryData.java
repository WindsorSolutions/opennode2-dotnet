//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
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
 * <p>Java class for PretreatmentPerformanceSummaryData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PretreatmentPerformanceSummaryData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PretreatmentPerformanceSummary"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PretreatmentPerformanceSummaryData", propOrder = {
    "transactionHeader",
    "pretreatmentPerformanceSummary"
})
@Entity(name = "PretreatmentPerformanceSummaryData")
@Table(name = "ICS_PRETR_PERF_SUMM")
@Inheritance(strategy = InheritanceType.JOINED)
public class PretreatmentPerformanceSummaryData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "PretreatmentPerformanceSummary", required = true)
    protected PretreatmentPerformanceSummary pretreatmentPerformanceSummary;
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
     * Gets the value of the pretreatmentPerformanceSummary property.
     * 
     * @return
     *     possible object is
     *     {@link PretreatmentPerformanceSummary }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "pretreatmentPerformanceSummaryStartDate", column = @Column(name = "PRETR_PERF_SUMM_START_DATE")),
        @AttributeOverride(name = "suoReference", column = @Column(name = "SUO_REF", length = 15)),
        @AttributeOverride(name = "suoDate", column = @Column(name = "SUO_DATE")),
        @AttributeOverride(name = "acceptanceHazardousWaste", column = @Column(name = "ACCEPTANCE_HAZ_WASTE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "acceptanceNonHazardousIndustrialWaste", column = @Column(name = "ACCEPTANCE_NON_HAZ_INDST_WASTE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "acceptanceHauledDomesticWastes", column = @Column(name = "ACCEPTANCE_HULED_DOMSTIC_WSTES", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "annualPretreatmentBudgetPPS", column = @Column(name = "ANNUL_PRETR_BUDGET_PP", scale = 0)),
        @AttributeOverride(name = "inadequacySamplingInspectionIndicator", column = @Column(name = "INADEQUACY_SMPL_INSP_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "adequacyPretreatmentResources", column = @Column(name = "ADEQUACY_PRETR_RESOURCES", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "deficienciesIdentifiedDuringIUFileReview", column = @Column(name = "DFCNC_IDNTFD_DRNG_IU_FILE_RVIW", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "controlMechanismDeficiencies", column = @Column(name = "CONTROL_MECH_DFCNC", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "legalAuthorityDeficiencies", column = @Column(name = "LEGAL_AUTH_DFCNC", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "deficienciesInterpretationApplicationPretreatmentStandards", column = @Column(name = "DFCNC_INTRPRT_APPL_PRETR_STNDR", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "deficienciesDataManagementPublicParticipation", column = @Column(name = "DFCNC_DAT_MGMT_PBLC_PRTICIPTON", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "violationIUScheduleRemedialMeasures", column = @Column(name = "VIOL_IU_SCHD_RMD_MSR", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "formalResponseViolationIUScheduleRemedialMeasures", column = @Column(name = "FRML_RSPN_VIOL_IU_SCHD_RMD_MSR", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "annualFrequencyInfluentToxicantSampling", column = @Column(name = "ANNUL_FREQ_INFLUNT_TOXCNT_SMPL", scale = 0)),
        @AttributeOverride(name = "annualFrequencyEffluentToxicantSampling", column = @Column(name = "ANNUL_FREQ_EFFLU_TOXCNT_SMPL", scale = 0)),
        @AttributeOverride(name = "annualFrequencySludgeToxicantSampling", column = @Column(name = "ANNUL_FREQ_SLDG_TOXCNT_SMPL", scale = 0)),
        @AttributeOverride(name = "numberSIUs", column = @Column(name = "NUM_SI_US", scale = 0)),
        @AttributeOverride(name = "siUsWithoutControlMechanism", column = @Column(name = "SI_US_WITHOUT_CONTROL_MECH", scale = 0)),
        @AttributeOverride(name = "siUsNotInspected", column = @Column(name = "SI_US_NOT_INSPECTED", scale = 0)),
        @AttributeOverride(name = "siUsNotSampled", column = @Column(name = "SI_US_NOT_SMPL", scale = 0)),
        @AttributeOverride(name = "siUsOnSchedule", column = @Column(name = "SI_US_ON_SCHD", scale = 0)),
        @AttributeOverride(name = "siUsSNCWithPretreatmentStandards", column = @Column(name = "SI_US_SNC_WITH_PRETR_STNDR", scale = 0)),
        @AttributeOverride(name = "siUsSNCWithReportingRequirements", column = @Column(name = "SI_US_SNC_WITH_REP_REQS", scale = 0)),
        @AttributeOverride(name = "siUsSNCWithPretreatmentSchedule", column = @Column(name = "SI_US_SNC_WITH_PRETR_SCHD", scale = 0)),
        @AttributeOverride(name = "siUsSNCPublishedNewspaper", column = @Column(name = "SI_US_SNC_PUBL_NEWSPAPER", scale = 0)),
        @AttributeOverride(name = "violationNoticesIssuedSIUs", column = @Column(name = "VIOL_NOTICES_ISSUED_SI_US", scale = 0)),
        @AttributeOverride(name = "administrativeOrdersIssuedSIUs", column = @Column(name = "ADMIN_ORDERS_ISSUED_SI_US", scale = 0)),
        @AttributeOverride(name = "civilSuitsFiledAgainstSIUs", column = @Column(name = "CIVIL_SUTS_FILD_AGINST_SI_US", scale = 0)),
        @AttributeOverride(name = "criminalSuitsFiledAgainstSIUs", column = @Column(name = "CRIMINL_SUTS_FILD_AGINST_SI_US", scale = 0)),
        @AttributeOverride(name = "dollarAmountPenaltiesCollectedPPS", column = @Column(name = "DOLLAR_AMT_PNLTY_COLL_PP", scale = 0)),
        @AttributeOverride(name = "iUsWhichPenaltiesHaveBeenCollectedPPS", column = @Column(name = "I_US_WHC_PNLTY_HAV_BEE_COLL_PP", scale = 0)),
        @AttributeOverride(name = "numberCIUs", column = @Column(name = "NUM_CI_US", scale = 0)),
        @AttributeOverride(name = "ciUsInSNC", column = @Column(name = "CI_US_IN_SNC", scale = 0)),
        @AttributeOverride(name = "passThroughInterferenceIndicator", column = @Column(name = "PASS_THROUGH_INTERFERENCE_IND", columnDefinition = "char(1)", length = 1))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "localLimits", joinColumns = {
            @JoinColumn(name = "ICS_PRETR_PERF_SUMM_ID")
        }),
        @AssociationOverride(name = "removalCredits", joinColumns = {
            @JoinColumn(name = "ICS_PRETR_PERF_SUMM_ID")
        })
    })
    public PretreatmentPerformanceSummary getPretreatmentPerformanceSummary() {
        return pretreatmentPerformanceSummary;
    }

    /**
     * Sets the value of the pretreatmentPerformanceSummary property.
     * 
     * @param value
     *     allowed object is
     *     {@link PretreatmentPerformanceSummary }
     *     
     */
    public void setPretreatmentPerformanceSummary(PretreatmentPerformanceSummary value) {
        this.pretreatmentPerformanceSummary = value;
    }

    @Transient
    public boolean isSetPretreatmentPerformanceSummary() {
        return (this.pretreatmentPerformanceSummary!= null);
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
    @Column(name = "ICS_PRETR_PERF_SUMM_ID")
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
        if (!(object instanceof PretreatmentPerformanceSummaryData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PretreatmentPerformanceSummaryData that = ((PretreatmentPerformanceSummaryData) object);
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
            PretreatmentPerformanceSummary lhsPretreatmentPerformanceSummary;
            lhsPretreatmentPerformanceSummary = this.getPretreatmentPerformanceSummary();
            PretreatmentPerformanceSummary rhsPretreatmentPerformanceSummary;
            rhsPretreatmentPerformanceSummary = that.getPretreatmentPerformanceSummary();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pretreatmentPerformanceSummary", lhsPretreatmentPerformanceSummary), LocatorUtils.property(thatLocator, "pretreatmentPerformanceSummary", rhsPretreatmentPerformanceSummary), lhsPretreatmentPerformanceSummary, rhsPretreatmentPerformanceSummary)) {
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
            PretreatmentPerformanceSummary thePretreatmentPerformanceSummary;
            thePretreatmentPerformanceSummary = this.getPretreatmentPerformanceSummary();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pretreatmentPerformanceSummary", thePretreatmentPerformanceSummary), currentHashCode, thePretreatmentPerformanceSummary);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
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
import javax.persistence.JoinTable;
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
 * <p>Java class for LimitsData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LimitsData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}Limits"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LimitsData", propOrder = {
    "transactionHeader",
    "limits"
})
@Entity(name = "LimitsData")
@Table(name = "ICS_LMTS")
@Inheritance(strategy = InheritanceType.JOINED)
public class LimitsData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "Limits", required = true)
    protected Limits limits;
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
     * Gets the value of the limits property.
     * 
     * @return
     *     possible object is
     *     {@link Limits }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "limitTypeCode", column = @Column(name = "LMT_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "sampleTypeText", column = @Column(name = "SMPL_TYPE_TXT", length = 3)),
        @AttributeOverride(name = "frequencyOfAnalysisCode", column = @Column(name = "FREQ_OF_ANALYSIS_CODE", length = 5)),
        @AttributeOverride(name = "eligibleForBurdenReduction", column = @Column(name = "ELIGIBLE_FOR_BURDEN_REDUCTION", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "limitStayTypeCode", column = @Column(name = "LMT_STAY_TYPE_CODE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "stayStartDate", column = @Column(name = "STAY_START_DATE")),
        @AttributeOverride(name = "stayEndDate", column = @Column(name = "STAY_END_DATE")),
        @AttributeOverride(name = "stayReasonText", column = @Column(name = "STAY_REASON_TXT", length = 500)),
        @AttributeOverride(name = "calculateViolationsIndicator", column = @Column(name = "CALCULATE_VIOL_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "enforcementActionIdentifier", column = @Column(name = "ENFRC_ACTN_IDENT", length = 20)),
        @AttributeOverride(name = "finalOrderIdentifier", column = @Column(name = "FINAL_ORDER_IDENT", scale = 0)),
        @AttributeOverride(name = "basisOfLimit", column = @Column(name = "BASIS_OF_LMT", length = 3)),
        @AttributeOverride(name = "limitModificationTypeCode", column = @Column(name = "LMT_MOD_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "limitModificationEffectiveDate", column = @Column(name = "LMT_MOD_EFFECTIVE_DATE")),
        @AttributeOverride(name = "limitsUserDefinedField1", column = @Column(name = "LMTS_USR_DFND_FLD_1", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "limitsUserDefinedField2", column = @Column(name = "LMTS_USR_DFND_FLD_2", length = 30)),
        @AttributeOverride(name = "limitsUserDefinedField3", column = @Column(name = "LMTS_USR_DFND_FLD_3", length = 150)),
        @AttributeOverride(name = "concentrationNumericConditionUnitMeasureCode", column = @Column(name = "CONCEN_NUM_COND_UNIT_MEAS_CODE", length = 2)),
        @AttributeOverride(name = "quantityNumericConditionUnitMeasureCode", column = @Column(name = "QTY_NUM_COND_UNIT_MEAS_CODE", length = 2))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "numericCondition", joinColumns = {
            @JoinColumn(name = "ICS_LMTS_ID")
        }),
        @AssociationOverride(name = "monthLimitApplies", joinTable = @JoinTable(name = "ICS_MN_LMT_APPLIES", joinColumns = {
            @JoinColumn(name = "ICS_LMTS_ID")
        }))
    })
    public Limits getLimits() {
        return limits;
    }

    /**
     * Sets the value of the limits property.
     * 
     * @param value
     *     allowed object is
     *     {@link Limits }
     *     
     */
    public void setLimits(Limits value) {
        this.limits = value;
    }

    @Transient
    public boolean isSetLimits() {
        return (this.limits!= null);
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
    @Column(name = "ICS_LMTS_ID")
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
        if (!(object instanceof LimitsData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final LimitsData that = ((LimitsData) object);
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
            Limits lhsLimits;
            lhsLimits = this.getLimits();
            Limits rhsLimits;
            rhsLimits = that.getLimits();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limits", lhsLimits), LocatorUtils.property(thatLocator, "limits", rhsLimits), lhsLimits, rhsLimits)) {
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
            Limits theLimits;
            theLimits = this.getLimits();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limits", theLimits), currentHashCode, theLimits);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

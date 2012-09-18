//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
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
 * <p>Java class for MasterGeneralPermitData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="MasterGeneralPermitData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}MasterGeneralPermit"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "MasterGeneralPermitData", propOrder = {
    "transactionHeader",
    "masterGeneralPermit"
})
@Entity(name = "MasterGeneralPermitData")
@Table(name = "ICS_MASTER_GNRL_PRMT")
@Inheritance(strategy = InheritanceType.JOINED)
public class MasterGeneralPermitData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "MasterGeneralPermit", required = true)
    protected MasterGeneralPermit masterGeneralPermit;
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
     * Gets the value of the masterGeneralPermit property.
     * 
     * @return
     *     possible object is
     *     {@link MasterGeneralPermit }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "permitTypeCode", column = @Column(name = "PRMT_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "agencyTypeCode", column = @Column(name = "AGNCY_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "permitIssueDate", column = @Column(name = "PRMT_ISSUE_DATE")),
        @AttributeOverride(name = "permitEffectiveDate", column = @Column(name = "PRMT_EFFECTIVE_DATE")),
        @AttributeOverride(name = "permitExpirationDate", column = @Column(name = "PRMT_EXPR_DATE")),
        @AttributeOverride(name = "reissuancePriorityPermitIndicator", column = @Column(name = "REISSU_PRIO_PRMT_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "backlogReasonText", column = @Column(name = "BACKLOG_REASON_TXT", length = 2000)),
        @AttributeOverride(name = "permitIssuingOrganizationTypeName", column = @Column(name = "PRMT_ISSUING_ORG_TYPE_NAME", length = 100)),
        @AttributeOverride(name = "permitAppealedIndicator", column = @Column(name = "PRMT_APPEALED_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "permitUserDefinedDataElement1Text", column = @Column(name = "PRMT_USR_DFND_DAT_ELM_1_TXT", length = 30)),
        @AttributeOverride(name = "permitUserDefinedDataElement2Text", column = @Column(name = "PRMT_USR_DFND_DAT_ELM_2_TXT", length = 30)),
        @AttributeOverride(name = "permitUserDefinedDataElement3Text", column = @Column(name = "PRMT_USR_DFND_DAT_ELM_3_TXT", length = 30)),
        @AttributeOverride(name = "permitUserDefinedDataElement4Text", column = @Column(name = "PRMT_USR_DFND_DAT_ELM_4_TXT", length = 30)),
        @AttributeOverride(name = "permitUserDefinedDataElement5Text", column = @Column(name = "PRMT_USR_DFND_DAT_ELM_5_TXT", length = 30)),
        @AttributeOverride(name = "permitCommentsText", column = @Column(name = "PRMT_CMNTS_TXT", length = 4000)),
        @AttributeOverride(name = "generalPermitIndustrialCategory", column = @Column(name = "GNRL_PRMT_INDST_CATG", length = 3)),
        @AttributeOverride(name = "permitName", column = @Column(name = "PRMT_NAME", length = 120))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "otherPermits", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        }),
        @AssociationOverride(name = "associatedPermit", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        }),
        @AssociationOverride(name = "sicCodeDetails", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        }),
        @AssociationOverride(name = "naicsCodeDetails", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        }),
        @AssociationOverride(name = "permitComponentTypeCode", joinTable = @JoinTable(name = "ICS_PRMT_COMP_TYPE", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        })),
        @AssociationOverride(name = "permitContact.contact", joinColumns = {
            @JoinColumn(name = "ICS_MASTER_GNRL_PRMT_ID")
        })
    })
    public MasterGeneralPermit getMasterGeneralPermit() {
        return masterGeneralPermit;
    }

    /**
     * Sets the value of the masterGeneralPermit property.
     * 
     * @param value
     *     allowed object is
     *     {@link MasterGeneralPermit }
     *     
     */
    public void setMasterGeneralPermit(MasterGeneralPermit value) {
        this.masterGeneralPermit = value;
    }

    @Transient
    public boolean isSetMasterGeneralPermit() {
        return (this.masterGeneralPermit!= null);
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
    @Column(name = "ICS_MASTER_GNRL_PRMT_ID")
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
        if (!(object instanceof MasterGeneralPermitData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final MasterGeneralPermitData that = ((MasterGeneralPermitData) object);
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
            MasterGeneralPermit lhsMasterGeneralPermit;
            lhsMasterGeneralPermit = this.getMasterGeneralPermit();
            MasterGeneralPermit rhsMasterGeneralPermit;
            rhsMasterGeneralPermit = that.getMasterGeneralPermit();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "masterGeneralPermit", lhsMasterGeneralPermit), LocatorUtils.property(thatLocator, "masterGeneralPermit", rhsMasterGeneralPermit), lhsMasterGeneralPermit, rhsMasterGeneralPermit)) {
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
            MasterGeneralPermit theMasterGeneralPermit;
            theMasterGeneralPermit = this.getMasterGeneralPermit();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "masterGeneralPermit", theMasterGeneralPermit), currentHashCode, theMasterGeneralPermit);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

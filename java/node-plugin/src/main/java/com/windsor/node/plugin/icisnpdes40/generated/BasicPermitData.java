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
import javax.persistence.JoinTable;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import com.windsor.node.plugin.icisnpdes40.domain.AbstractBasicPermitData;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for BasicPermitData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="BasicPermitData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}BasicPermit"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "BasicPermitData", propOrder = {
    "transactionHeader",
    "basicPermit"
})
@Entity(name = "BasicPermitData")
@Table(name = "ICS_BASIC_PRMT")
@Inheritance(strategy = InheritanceType.JOINED)
public class BasicPermitData
    extends AbstractBasicPermitData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "BasicPermit", required = true)
    protected BasicPermit basicPermit;
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
     * Gets the value of the basicPermit property.
     * 
     * @return
     *     possible object is
     *     {@link BasicPermit }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "permitTypeCode", column = @Column(name = "PRMT_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "agencyTypeCode", column = @Column(name = "AGNCY_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "permitStatusCode", column = @Column(name = "PRMT_STAT_CODE", length = 255)),
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
        @AttributeOverride(name = "majorMinorRatingCode", column = @Column(name = "MAJOR_MINOR_RATING_CODE", scale = 0)),
        @AttributeOverride(name = "totalApplicationDesignFlowNumber", column = @Column(name = "TTL_APPL_DSGN_FLOW_NUM", scale = 7)),
        @AttributeOverride(name = "totalApplicationAverageFlowNumber", column = @Column(name = "TTL_APPL_AVER_FLOW_NUM", scale = 7)),
        @AttributeOverride(name = "applicationReceivedDate", column = @Column(name = "APPL_RCVD_DATE")),
        @AttributeOverride(name = "permitApplicationCompletionDate", column = @Column(name = "PRMT_APPL_CMPL_DATE")),
        @AttributeOverride(name = "newSourceIndicator", column = @Column(name = "NEW_SRC_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "permitStateWaterBodyCode", column = @Column(name = "PRMT_ST_WTR_BODY_CODE", length = 12)),
        @AttributeOverride(name = "permitStateWaterBodyName", column = @Column(name = "PRMT_ST_WTR_BODY_NAME", length = 50)),
        @AttributeOverride(name = "federalGrantIndicator", column = @Column(name = "FEDR_GRANT_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "dmrCognizantOfficial", column = @Column(name = "DMR_COGNZNT_OFCL", length = 30)),
        @AttributeOverride(name = "dmrCognizantOfficialTelephoneNumber", column = @Column(name = "DMR_COGNZNT_OFCL_TELEPH_NUM", length = 15)),
        @AttributeOverride(name = "significantIUIndicator", column = @Column(name = "SIG_IU_IND", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "receivingPermitIdentifier", column = @Column(name = "RCVG_PRMT_IDENT", columnDefinition = "char(9)", length = 9))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "otherPermits", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "associatedPermit", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "sicCodeDetails", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "naicsCodeDetails", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "facility", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "complianceTrackingStatus", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "effluentGuidelineCode", joinTable = @JoinTable(name = "ICS_EFFLU_GUIDE", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        })),
        @AssociationOverride(name = "permitContact.contact", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        }),
        @AssociationOverride(name = "permitAddress.address", joinColumns = {
            @JoinColumn(name = "ICS_BASIC_PRMT_ID")
        })
    })
    public BasicPermit getBasicPermit() {
        return basicPermit;
    }

    /**
     * Sets the value of the basicPermit property.
     * 
     * @param value
     *     allowed object is
     *     {@link BasicPermit }
     *     
     */
    public void setBasicPermit(BasicPermit value) {
        this.basicPermit = value;
    }

    @Transient
    public boolean isSetBasicPermit() {
        return (this.basicPermit!= null);
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
    @Column(name = "ICS_BASIC_PRMT_ID")
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
        if (!(object instanceof BasicPermitData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final BasicPermitData that = ((BasicPermitData) object);
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
            BasicPermit lhsBasicPermit;
            lhsBasicPermit = this.getBasicPermit();
            BasicPermit rhsBasicPermit;
            rhsBasicPermit = that.getBasicPermit();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "basicPermit", lhsBasicPermit), LocatorUtils.property(thatLocator, "basicPermit", rhsBasicPermit), lhsBasicPermit, rhsBasicPermit)) {
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
            BasicPermit theBasicPermit;
            theBasicPermit = this.getBasicPermit();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "basicPermit", theBasicPermit), currentHashCode, theBasicPermit);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

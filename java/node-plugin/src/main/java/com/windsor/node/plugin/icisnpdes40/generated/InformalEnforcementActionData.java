//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
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
 * <p>Java class for InformalEnforcementActionData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="InformalEnforcementActionData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}InformalEnforcementAction"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "InformalEnforcementActionData", propOrder = {
    "transactionHeader",
    "informalEnforcementAction"
})
@Entity(name = "InformalEnforcementActionData")
@Table(name = "ICS_INFRML_ENFRC_ACTN")
@Inheritance(strategy = InheritanceType.JOINED)
public class InformalEnforcementActionData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "InformalEnforcementAction", required = true)
    protected InformalEnforcementAction informalEnforcementAction;
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
     * Gets the value of the informalEnforcementAction property.
     * 
     * @return
     *     possible object is
     *     {@link InformalEnforcementAction }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "enforcementActionTypeCode", column = @Column(name = "ENFRC_ACTN_TYPE_CODE", length = 7)),
        @AttributeOverride(name = "enforcementActionName", column = @Column(name = "ENFRC_ACTN_NAME", length = 100)),
        @AttributeOverride(name = "achievedDate", column = @Column(name = "ACHIEVED_DATE")),
        @AttributeOverride(name = "reasonDeletingRecord", column = @Column(name = "REASON_DELETING_RECORD", length = 500)),
        @AttributeOverride(name = "informalEACommentText", column = @Column(name = "INFRML_EA_CMNT_TXT", length = 4000)),
        @AttributeOverride(name = "informalEAUserDefinedField1", column = @Column(name = "INFRML_EA_USR_DFND_FLD_1", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "informalEAUserDefinedField2", column = @Column(name = "INFRML_EA_USR_DFND_FLD_2", length = 50)),
        @AttributeOverride(name = "informalEAUserDefinedField3", column = @Column(name = "INFRML_EA_USR_DFND_FLD_3", length = 50)),
        @AttributeOverride(name = "informalEAUserDefinedField4", column = @Column(name = "INFRML_EA_USR_DFND_FLD_4")),
        @AttributeOverride(name = "informalEAUserDefinedField5", column = @Column(name = "INFRML_EA_USR_DFND_FLD_5")),
        @AttributeOverride(name = "informalEAUserDefinedField6", column = @Column(name = "INFRML_EA_USR_DFND_FLD_6", length = 4000)),
        @AttributeOverride(name = "enforcementAgencyName", column = @Column(name = "ENFRC_AGNCY_NAME", length = 100))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "enforcementAgency", joinColumns = {
            @JoinColumn(name = "ICS_INFRML_ENFRC_ACTN_ID")
        }),
        @AssociationOverride(name = "enforcementActionGovernmentContact", joinColumns = {
            @JoinColumn(name = "ICS_INFRML_ENFRC_ACTN_ID")
        }),
        @AssociationOverride(name = "permitIdentifier", joinTable = @JoinTable(name = "ICS_PRMT_IDENT", joinColumns = {
            @JoinColumn(name = "ICS_INFRML_ENFRC_ACTN_ID")
        })),
        @AssociationOverride(name = "programsViolatedCode", joinTable = @JoinTable(name = "ICS_PROGS_VIOL", joinColumns = {
            @JoinColumn(name = "ICS_INFRML_ENFRC_ACTN_ID")
        }))
    })
    public InformalEnforcementAction getInformalEnforcementAction() {
        return informalEnforcementAction;
    }

    /**
     * Sets the value of the informalEnforcementAction property.
     * 
     * @param value
     *     allowed object is
     *     {@link InformalEnforcementAction }
     *     
     */
    public void setInformalEnforcementAction(InformalEnforcementAction value) {
        this.informalEnforcementAction = value;
    }

    @Transient
    public boolean isSetInformalEnforcementAction() {
        return (this.informalEnforcementAction!= null);
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
    @Column(name = "ICS_INFRML_ENFRC_ACTN_ID")
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
        if (!(object instanceof InformalEnforcementActionData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final InformalEnforcementActionData that = ((InformalEnforcementActionData) object);
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
            InformalEnforcementAction lhsInformalEnforcementAction;
            lhsInformalEnforcementAction = this.getInformalEnforcementAction();
            InformalEnforcementAction rhsInformalEnforcementAction;
            rhsInformalEnforcementAction = that.getInformalEnforcementAction();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "informalEnforcementAction", lhsInformalEnforcementAction), LocatorUtils.property(thatLocator, "informalEnforcementAction", rhsInformalEnforcementAction), lhsInformalEnforcementAction, rhsInformalEnforcementAction)) {
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
            InformalEnforcementAction theInformalEnforcementAction;
            theInformalEnforcementAction = this.getInformalEnforcementAction();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "informalEnforcementAction", theInformalEnforcementAction), currentHashCode, theInformalEnforcementAction);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

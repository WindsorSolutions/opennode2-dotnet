//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.08.17 at 12:13:56 PM PDT
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
 * <p>Java class for LimitSetData complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="LimitSetData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LimitSet"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LimitSetData", propOrder = {
    "transactionHeader",
    "limitSet"
})
@Entity(name = "LimitSetData")
@Table(name = "ICS_LMT_SET")
@Inheritance(strategy = InheritanceType.JOINED)
public class LimitSetData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;

    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;

    @XmlElement(name = "LimitSet", required = true)
    protected LimitSet limitSet;
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
     * Gets the value of the limitSet property.
     *
     * @return
     *     possible object is
     *     {@link LimitSet }
     *
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "limitSetType", column = @Column(name = "LMT_SET_TYPE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "limitSetNameText", column = @Column(name = "LMT_SET_NAME_TXT", length = 100)),
        @AttributeOverride(name = "dmrPrePrintCommentsText", column = @Column(name = "DMR_PRE_PRINT_CMNTS_TXT", length = 315)),
        @AttributeOverride(name = "agencyReviewer", column = @Column(name = "AGNCY_REVIEWER", length = 5)),
        @AttributeOverride(name = "limitSetUserDefinedDataElement1Text", column = @Column(name = "LMT_SET_USR_DFND_DAT_ELM_1_TXT", scale = 0)),
        @AttributeOverride(name = "limitSetUserDefinedDataElement2Text", column = @Column(name = "LMT_SET_USR_DFND_DAT_ELM_2_TXT", length = 150))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "limitSetSchedule", joinColumns = {
            @JoinColumn(name = "ICS_LMT_SET_ID")
        }),
        @AssociationOverride(name = "limitSetStatus", joinColumns = {
            @JoinColumn(name = "ICS_LMT_SET_ID")
        }),
        @AssociationOverride(name = "limitSetMonthsApplicable", joinTable = @JoinTable(name = "ICS_LMT_SET_MONTHS_APPL", joinColumns = {
            @JoinColumn(name = "ICS_LMT_SET_ID")
        }))
    })
    public LimitSet getLimitSet() {
        return limitSet;
    }

    /**
     * Sets the value of the limitSet property.
     *
     * @param value
     *     allowed object is
     *     {@link LimitSet }
     *
     */
    public void setLimitSet(final LimitSet value) {
        this.limitSet = value;
    }

    @Transient
    public boolean isSetLimitSet() {
        return (this.limitSet!= null);
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
    @Column(name = "ICS_LMT_SET_ID")
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
        if (!(object instanceof LimitSetData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final LimitSetData that = ((LimitSetData) object);
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
            LimitSet lhsLimitSet;
            lhsLimitSet = this.getLimitSet();
            LimitSet rhsLimitSet;
            rhsLimitSet = that.getLimitSet();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSet", lhsLimitSet), LocatorUtils.property(thatLocator, "limitSet", rhsLimitSet), lhsLimitSet, rhsLimitSet)) {
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
            LimitSet theLimitSet;
            theLimitSet = this.getLimitSet();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSet", theLimitSet), currentHashCode, theLimitSet);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

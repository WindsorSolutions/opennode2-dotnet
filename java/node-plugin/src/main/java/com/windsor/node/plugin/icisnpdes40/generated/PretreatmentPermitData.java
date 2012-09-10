//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.AssociationOverride;
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
 * <p>Java class for PretreatmentPermitData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PretreatmentPermitData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PretreatmentPermit"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PretreatmentPermitData", propOrder = {
    "transactionHeader",
    "pretreatmentPermit"
})
@Entity(name = "PretreatmentPermitData")
@Table(name = "ICS_PRETR_PRMT")
@Inheritance(strategy = InheritanceType.JOINED)
public class PretreatmentPermitData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "PretreatmentPermit", required = true)
    protected PretreatmentPermit pretreatmentPermit;
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
     * Gets the value of the pretreatmentPermit property.
     * 
     * @return
     *     possible object is
     *     {@link PretreatmentPermit }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "pretreatmentProgramRequiredIndicatorCode", column = @Column(name = "PRETR_PROG_REQD_IND_CODE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "controlAuthorityStateAgencyCode", column = @Column(name = "CONTROL_AUTH_ST_AGNCY_CODE", columnDefinition = "char(2)", length = 2)),
        @AttributeOverride(name = "controlAuthorityRegionalAgencyCode", column = @Column(name = "CONTROL_AUTH_RGNL_AGNCY_CODE", length = 2)),
        @AttributeOverride(name = "controlAuthorityNPDESIdentifier", column = @Column(name = "CONTROL_AUTH_NPDES_IDENT", columnDefinition = "char(9)", length = 9)),
        @AttributeOverride(name = "pretreatmentProgramApprovedDate", column = @Column(name = "PRETR_PROG_APRVD_DATE"))
    })
    @AssociationOverride(name = "pretreatmentContact.contact", joinColumns = {
        @JoinColumn(name = "ICS_PRETR_PRMT_ID")
    })
    public PretreatmentPermit getPretreatmentPermit() {
        return pretreatmentPermit;
    }

    /**
     * Sets the value of the pretreatmentPermit property.
     * 
     * @param value
     *     allowed object is
     *     {@link PretreatmentPermit }
     *     
     */
    public void setPretreatmentPermit(PretreatmentPermit value) {
        this.pretreatmentPermit = value;
    }

    @Transient
    public boolean isSetPretreatmentPermit() {
        return (this.pretreatmentPermit!= null);
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
    @Column(name = "ICS_PRETR_PRMT_ID")
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
        if (!(object instanceof PretreatmentPermitData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PretreatmentPermitData that = ((PretreatmentPermitData) object);
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
            PretreatmentPermit lhsPretreatmentPermit;
            lhsPretreatmentPermit = this.getPretreatmentPermit();
            PretreatmentPermit rhsPretreatmentPermit;
            rhsPretreatmentPermit = that.getPretreatmentPermit();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pretreatmentPermit", lhsPretreatmentPermit), LocatorUtils.property(thatLocator, "pretreatmentPermit", rhsPretreatmentPermit), lhsPretreatmentPermit, rhsPretreatmentPermit)) {
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
            PretreatmentPermit thePretreatmentPermit;
            thePretreatmentPermit = this.getPretreatmentPermit();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pretreatmentPermit", thePretreatmentPermit), currentHashCode, thePretreatmentPermit);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
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
 * <p>Java class for NarrativeConditionScheduleData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="NarrativeConditionScheduleData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NarrativeCondition"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "NarrativeConditionScheduleData", propOrder = {
    "transactionHeader",
    "narrativeCondition"
})
@Entity(name = "NarrativeConditionScheduleData")
@Table(name = "ICS_NARR_COND_SCHD")
@Inheritance(strategy = InheritanceType.JOINED)
public class NarrativeConditionScheduleData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "NarrativeCondition", required = true)
    protected NarrativeCondition narrativeCondition;
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
     * Gets the value of the narrativeCondition property.
     * 
     * @return
     *     possible object is
     *     {@link NarrativeCondition }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "narrativeConditionCode", column = @Column(name = "NARR_COND_CODE", columnDefinition = "char(3)", length = 3)),
        @AttributeOverride(name = "comments", column = @Column(name = "CMNTS", length = 4000))
    })
    @AssociationOverride(name = "permitScheduleEvent", joinColumns = {
        @JoinColumn(name = "ICS_NARR_COND_SCHD_ID")
    })
    public NarrativeCondition getNarrativeCondition() {
        return narrativeCondition;
    }

    /**
     * Sets the value of the narrativeCondition property.
     * 
     * @param value
     *     allowed object is
     *     {@link NarrativeCondition }
     *     
     */
    public void setNarrativeCondition(NarrativeCondition value) {
        this.narrativeCondition = value;
    }

    @Transient
    public boolean isSetNarrativeCondition() {
        return (this.narrativeCondition!= null);
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
    @Column(name = "ICS_NARR_COND_SCHD_ID")
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
        if (!(object instanceof NarrativeConditionScheduleData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final NarrativeConditionScheduleData that = ((NarrativeConditionScheduleData) object);
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
            NarrativeCondition lhsNarrativeCondition;
            lhsNarrativeCondition = this.getNarrativeCondition();
            NarrativeCondition rhsNarrativeCondition;
            rhsNarrativeCondition = that.getNarrativeCondition();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "narrativeCondition", lhsNarrativeCondition), LocatorUtils.property(thatLocator, "narrativeCondition", rhsNarrativeCondition), lhsNarrativeCondition, rhsNarrativeCondition)) {
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
            NarrativeCondition theNarrativeCondition;
            theNarrativeCondition = this.getNarrativeCondition();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "narrativeCondition", theNarrativeCondition), currentHashCode, theNarrativeCondition);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

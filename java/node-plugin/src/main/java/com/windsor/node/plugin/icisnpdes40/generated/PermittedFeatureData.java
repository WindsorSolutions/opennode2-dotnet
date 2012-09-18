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
import com.windsor.node.plugin.icisnpdes40.domain.AbstractPermittedFeatureData;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for PermittedFeatureData complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermittedFeatureData">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}TransactionHeader"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PermittedFeature"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermittedFeatureData", propOrder = {
    "transactionHeader",
    "permittedFeature"
})
@Entity(name = "PermittedFeatureData")
@Table(name = "ICS_PRMT_FEATR")
@Inheritance(strategy = InheritanceType.JOINED)
public class PermittedFeatureData
    extends AbstractPermittedFeatureData
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "TransactionHeader", required = true)
    protected TransactionHeader transactionHeader;
    @XmlElement(name = "PermittedFeature", required = true)
    protected PermittedFeature permittedFeature;
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
     * Gets the value of the permittedFeature property.
     * 
     * @return
     *     possible object is
     *     {@link PermittedFeature }
     *     
     */
    @Embedded
    @AttributeOverrides({
        @AttributeOverride(name = "permittedFeatureTypeCode", column = @Column(name = "PRMT_FEATR_TYPE_CODE", length = 3)),
        @AttributeOverride(name = "permittedFeatureDescription", column = @Column(name = "PRMT_FEATR_DESC", length = 100)),
        @AttributeOverride(name = "permittedFeatureDesignFlowNumber", column = @Column(name = "PRMT_FEATR_DSGN_FLOW_NUM", scale = 7)),
        @AttributeOverride(name = "permittedFeatureActualAverageFlowNumber", column = @Column(name = "PRMT_FEATR_ACTUL_AVER_FLOW_NUM", scale = 7)),
        @AttributeOverride(name = "permittedFeatureStateWaterBodyCode", column = @Column(name = "PRMT_FEATR_ST_WTR_BODY_CODE", length = 12)),
        @AttributeOverride(name = "permittedFeatureStateWaterBodyName", column = @Column(name = "PRMT_FEATR_ST_WTR_BODY_NAME", length = 50)),
        @AttributeOverride(name = "permittedFeatureUserDefinedDataElement1", column = @Column(name = "PRMT_FEATR_USR_DFND_DAT_ELM_1", length = 30)),
        @AttributeOverride(name = "permittedFeatureUserDefinedDataElement2", column = @Column(name = "PRMT_FEATR_USR_DFND_DAT_ELM_2", length = 30)),
        @AttributeOverride(name = "fieldSize", column = @Column(name = "FLD_SIZE", scale = 0)),
        @AttributeOverride(name = "isSiteOwnByFacility", column = @Column(name = "IS_SITE_OWN_BY_FAC", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "isSystemLinedWithLeachate", column = @Column(name = "IS_SYSTM_LINED_WITH_LEACHATE", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "doesUnitHaveDailyCover", column = @Column(name = "DOES_UNIT_HAV_DAILY_COVER", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "propertyBoundaryDistance", column = @Column(name = "PROP_BOUNDARY_DISTANCE", scale = 0)),
        @AttributeOverride(name = "isRequiredNitrateGroundWater", column = @Column(name = "IS_REQD_NITRATE_GROUND_WTR", columnDefinition = "char(1)", length = 1)),
        @AttributeOverride(name = "wellNumber", column = @Column(name = "WELL_NUM", scale = 0)),
        @AttributeOverride(name = "sourcePermittedFeatureDetailText", column = @Column(name = "SRC_PRMT_FEATR_DETAIL_TXT", length = 200))
    })
    @AssociationOverrides({
        @AssociationOverride(name = "geographicCoordinates", joinColumns = {
            @JoinColumn(name = "ICS_PRMT_FEATR_ID")
        }),
        @AssociationOverride(name = "permittedFeatureCharacteristics", joinTable = @JoinTable(name = "ICS_PRMT_FEATR_CHAR", joinColumns = {
            @JoinColumn(name = "ICS_PRMT_FEATR_ID")
        })),
        @AssociationOverride(name = "permittedFeatureTreatmentTypeCode", joinTable = @JoinTable(name = "ICS_PRMT_FEATR_TRTMNT_TYPE", joinColumns = {
            @JoinColumn(name = "ICS_PRMT_FEATR_ID")
        })),
        @AssociationOverride(name = "siteOwnerContact.contact", joinColumns = {
            @JoinColumn(name = "ICS_PRMT_FEATR_ID")
        }),
        @AssociationOverride(name = "siteOwnerAddress.address", joinColumns = {
            @JoinColumn(name = "ICS_PRMT_FEATR_ID")
        })
    })
    public PermittedFeature getPermittedFeature() {
        return permittedFeature;
    }

    /**
     * Sets the value of the permittedFeature property.
     * 
     * @param value
     *     allowed object is
     *     {@link PermittedFeature }
     *     
     */
    public void setPermittedFeature(PermittedFeature value) {
        this.permittedFeature = value;
    }

    @Transient
    public boolean isSetPermittedFeature() {
        return (this.permittedFeature!= null);
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
    @Column(name = "ICS_PRMT_FEATR_ID")
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
        if (!(object instanceof PermittedFeatureData)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final PermittedFeatureData that = ((PermittedFeatureData) object);
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
            PermittedFeature lhsPermittedFeature;
            lhsPermittedFeature = this.getPermittedFeature();
            PermittedFeature rhsPermittedFeature;
            rhsPermittedFeature = that.getPermittedFeature();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permittedFeature", lhsPermittedFeature), LocatorUtils.property(thatLocator, "permittedFeature", rhsPermittedFeature), lhsPermittedFeature, rhsPermittedFeature)) {
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
            PermittedFeature thePermittedFeature;
            thePermittedFeature = this.getPermittedFeature();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permittedFeature", thePermittedFeature), currentHashCode, thePermittedFeature);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

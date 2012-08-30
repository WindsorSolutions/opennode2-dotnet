//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.08.30 at 09:36:55 AM PDT
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.AssociationOverride;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.Embedded;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;

import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;

import com.windsor.node.plugin.icisnpdes40.adapter.DateAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;


/**
 * <p>Java class for SWConstructionPermit complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="SWConstructionPermit">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}BasicPermitKeyElements">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterBodyGroup" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}GPCFNoticeOfIntent" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}GPCFNoticeOfTermination" minOccurs="0"/>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterConstructionPermitComponentGroup" minOccurs="0"/>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterContactGroup" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SWConstructionPermit", propOrder = {
    "stateWaterBodyName",
    "receivingMS4Name",
    "impairedWaterIndicator",
    "historicPropertyIndicator",
    "historicPropertyCriterionMetCode",
    "speciesCriticalHabitatIndicator",
    "speciesCriterionMetCode",
    "gpcfNoticeOfIntent",
    "gpcfNoticeOfTermination",
    "projectTypeCode",
    "estimatedStartDate",
    "estimatedCompleteDate",
    "estimatedAreaDisturbedAcresNumber",
    "projectPlanSizeCode",
    "stormWaterContact",
    "stormWaterAddress"
})
@Embeddable
public class SWConstructionPermit
    extends BasicPermitKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "StateWaterBodyName")
    protected String stateWaterBodyName;
    @XmlElement(name = "ReceivingMS4Name")
    protected String receivingMS4Name;
    @XmlElement(name = "ImpairedWaterIndicator")
    protected String impairedWaterIndicator;
    @XmlElement(name = "HistoricPropertyIndicator")
    protected String historicPropertyIndicator;
    @XmlElement(name = "HistoricPropertyCriterionMetCode")
    protected String historicPropertyCriterionMetCode;
    @XmlElement(name = "SpeciesCriticalHabitatIndicator")
    protected String speciesCriticalHabitatIndicator;
    @XmlElement(name = "SpeciesCriterionMetCode")
    protected String speciesCriterionMetCode;
    @XmlElement(name = "GPCFNoticeOfIntent")
    protected GPCFNoticeOfIntent gpcfNoticeOfIntent;
    @XmlElement(name = "GPCFNoticeOfTermination")
    protected GPCFNoticeOfTermination gpcfNoticeOfTermination;
    @XmlElement(name = "ProjectTypeCode")
    protected String projectTypeCode;
    @XmlElement(name = "EstimatedStartDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date estimatedStartDate;
    @XmlElement(name = "EstimatedCompleteDate", type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    protected Date estimatedCompleteDate;
    @XmlElement(name = "EstimatedAreaDisturbedAcresNumber", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer estimatedAreaDisturbedAcresNumber;
    @XmlElement(name = "ProjectPlanSizeCode")
    protected String projectPlanSizeCode;
    @XmlElement(name = "StormWaterContact")
    protected StormWaterContact stormWaterContact;
    @XmlElement(name = "StormWaterAddress")
    protected StormWaterAddress stormWaterAddress;

    /**
     * Gets the value of the stateWaterBodyName property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "ST_WTR_BODY_NAME", length = 50)
    public String getStateWaterBodyName() {
        return stateWaterBodyName;
    }

    /**
     * Sets the value of the stateWaterBodyName property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setStateWaterBodyName(final String value) {
        this.stateWaterBodyName = value;
    }

    @Transient
    public boolean isSetStateWaterBodyName() {
        return (this.stateWaterBodyName!= null);
    }

    /**
     * Gets the value of the receivingMS4Name property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "RCVG_MS_4_NAME", length = 50)
    public String getReceivingMS4Name() {
        return receivingMS4Name;
    }

    /**
     * Sets the value of the receivingMS4Name property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setReceivingMS4Name(final String value) {
        this.receivingMS4Name = value;
    }

    @Transient
    public boolean isSetReceivingMS4Name() {
        return (this.receivingMS4Name!= null);
    }

    /**
     * Gets the value of the impairedWaterIndicator property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "IMPAIRED_WTR_IND", columnDefinition = "char(1)", length = 1)
    public String getImpairedWaterIndicator() {
        return impairedWaterIndicator;
    }

    /**
     * Sets the value of the impairedWaterIndicator property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setImpairedWaterIndicator(final String value) {
        this.impairedWaterIndicator = value;
    }

    @Transient
    public boolean isSetImpairedWaterIndicator() {
        return (this.impairedWaterIndicator!= null);
    }

    /**
     * Gets the value of the historicPropertyIndicator property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "HIST_PROP_IND", columnDefinition = "char(1)", length = 1)
    public String getHistoricPropertyIndicator() {
        return historicPropertyIndicator;
    }

    /**
     * Sets the value of the historicPropertyIndicator property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setHistoricPropertyIndicator(final String value) {
        this.historicPropertyIndicator = value;
    }

    @Transient
    public boolean isSetHistoricPropertyIndicator() {
        return (this.historicPropertyIndicator!= null);
    }

    /**
     * Gets the value of the historicPropertyCriterionMetCode property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "HIST_PROP_CRIT_MET_CODE", length = 3)
    public String getHistoricPropertyCriterionMetCode() {
        return historicPropertyCriterionMetCode;
    }

    /**
     * Sets the value of the historicPropertyCriterionMetCode property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setHistoricPropertyCriterionMetCode(final String value) {
        this.historicPropertyCriterionMetCode = value;
    }

    @Transient
    public boolean isSetHistoricPropertyCriterionMetCode() {
        return (this.historicPropertyCriterionMetCode!= null);
    }

    /**
     * Gets the value of the speciesCriticalHabitatIndicator property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "SPECIES_CRIT_HABITAT_IND", columnDefinition = "char(1)", length = 1)
    public String getSpeciesCriticalHabitatIndicator() {
        return speciesCriticalHabitatIndicator;
    }

    /**
     * Sets the value of the speciesCriticalHabitatIndicator property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setSpeciesCriticalHabitatIndicator(final String value) {
        this.speciesCriticalHabitatIndicator = value;
    }

    @Transient
    public boolean isSetSpeciesCriticalHabitatIndicator() {
        return (this.speciesCriticalHabitatIndicator!= null);
    }

    /**
     * Gets the value of the speciesCriterionMetCode property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "SPECIES_CRIT_MET_CODE", length = 3)
    public String getSpeciesCriterionMetCode() {
        return speciesCriterionMetCode;
    }

    /**
     * Sets the value of the speciesCriterionMetCode property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setSpeciesCriterionMetCode(final String value) {
        this.speciesCriterionMetCode = value;
    }

    @Transient
    public boolean isSetSpeciesCriterionMetCode() {
        return (this.speciesCriterionMetCode!= null);
    }

    /**
     * Gets the value of the gpcfNoticeOfIntent property.
     *
     * @return
     *     possible object is
     *     {@link GPCFNoticeOfIntent }
     *
     */
    @ManyToOne(targetEntity = GPCFNoticeOfIntent.class, cascade = {
        CascadeType.ALL
    })
    // FIXME: fixed join column name
    @JoinColumn(name = "ICS_SW_CNST_PRMT_ID", insertable = false, updatable = false)
    public GPCFNoticeOfIntent getGPCFNoticeOfIntent() {
        return gpcfNoticeOfIntent;
    }

    /**
     * Sets the value of the gpcfNoticeOfIntent property.
     *
     * @param value
     *     allowed object is
     *     {@link GPCFNoticeOfIntent }
     *
     */
    public void setGPCFNoticeOfIntent(final GPCFNoticeOfIntent value) {
        this.gpcfNoticeOfIntent = value;
    }

    @Transient
    public boolean isSetGPCFNoticeOfIntent() {
        return (this.gpcfNoticeOfIntent!= null);
    }

    /**
     * Gets the value of the gpcfNoticeOfTermination property.
     *
     * @return
     *     possible object is
     *     {@link GPCFNoticeOfTermination }
     *
     */
    @ManyToOne(targetEntity = GPCFNoticeOfTermination.class, cascade = {
        CascadeType.ALL
    })
    // FIXME: fixed join column name
    @JoinColumn(name = "ICS_SW_CNST_PRMT_ID", insertable = false, updatable = false)
    public GPCFNoticeOfTermination getGPCFNoticeOfTermination() {
        return gpcfNoticeOfTermination;
    }

    /**
     * Sets the value of the gpcfNoticeOfTermination property.
     *
     * @param value
     *     allowed object is
     *     {@link GPCFNoticeOfTermination }
     *
     */
    public void setGPCFNoticeOfTermination(final GPCFNoticeOfTermination value) {
        this.gpcfNoticeOfTermination = value;
    }

    @Transient
    public boolean isSetGPCFNoticeOfTermination() {
        return (this.gpcfNoticeOfTermination!= null);
    }

    /**
     * Gets the value of the projectTypeCode property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "PROJ_TYPE_CODE", length = 3)
    public String getProjectTypeCode() {
        return projectTypeCode;
    }

    /**
     * Sets the value of the projectTypeCode property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setProjectTypeCode(final String value) {
        this.projectTypeCode = value;
    }

    @Transient
    public boolean isSetProjectTypeCode() {
        return (this.projectTypeCode!= null);
    }

    /**
     * Gets the value of the estimatedStartDate property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "EST_START_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getEstimatedStartDate() {
        return estimatedStartDate;
    }

    /**
     * Sets the value of the estimatedStartDate property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setEstimatedStartDate(final Date value) {
        this.estimatedStartDate = value;
    }

    @Transient
    public boolean isSetEstimatedStartDate() {
        return (this.estimatedStartDate!= null);
    }

    /**
     * Gets the value of the estimatedCompleteDate property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "EST_COMPLETE_DATE")
    @Temporal(TemporalType.TIMESTAMP)
    public Date getEstimatedCompleteDate() {
        return estimatedCompleteDate;
    }

    /**
     * Sets the value of the estimatedCompleteDate property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setEstimatedCompleteDate(final Date value) {
        this.estimatedCompleteDate = value;
    }

    @Transient
    public boolean isSetEstimatedCompleteDate() {
        return (this.estimatedCompleteDate!= null);
    }

    /**
     * Gets the value of the estimatedAreaDisturbedAcresNumber property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "EST_AREA_DISTURBED_ACRES_NUM", scale = 0)
    public Integer getEstimatedAreaDisturbedAcresNumber() {
        return estimatedAreaDisturbedAcresNumber;
    }

    /**
     * Sets the value of the estimatedAreaDisturbedAcresNumber property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setEstimatedAreaDisturbedAcresNumber(final Integer value) {
        this.estimatedAreaDisturbedAcresNumber = value;
    }

    @Transient
    public boolean isSetEstimatedAreaDisturbedAcresNumber() {
        return (this.estimatedAreaDisturbedAcresNumber!= null);
    }

    /**
     * Gets the value of the projectPlanSizeCode property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "PROJ_PLAN_SIZE_CODE", length = 3)
    public String getProjectPlanSizeCode() {
        return projectPlanSizeCode;
    }

    /**
     * Sets the value of the projectPlanSizeCode property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setProjectPlanSizeCode(final String value) {
        this.projectPlanSizeCode = value;
    }

    @Transient
    public boolean isSetProjectPlanSizeCode() {
        return (this.projectPlanSizeCode!= null);
    }

    /**
     * Gets the value of the stormWaterContact property.
     *
     * @return
     *     possible object is
     *     {@link StormWaterContact }
     *
     */
    @Embedded
    // FIXME: add join column info
    @AssociationOverride(name = "contact", joinColumns = @JoinColumn(name = "ICS_SW_CNST_PRMT_ID"))
    public StormWaterContact getStormWaterContact() {
        return stormWaterContact;
    }

    /**
     * Sets the value of the stormWaterContact property.
     *
     * @param value
     *     allowed object is
     *     {@link StormWaterContact }
     *
     */
    public void setStormWaterContact(final StormWaterContact value) {
        this.stormWaterContact = value;
    }

    @Transient
    public boolean isSetStormWaterContact() {
        return (this.stormWaterContact!= null);
    }

    /**
     * Gets the value of the stormWaterAddress property.
     *
     * @return
     *     possible object is
     *     {@link StormWaterAddress }
     *
     */
    @Embedded
    // FIXME: add join column info
    @AssociationOverride(name = "address", joinColumns = @JoinColumn(name = "ICS_SW_CNST_PRMT_ID"))
    public StormWaterAddress getStormWaterAddress() {
        return stormWaterAddress;
    }

    /**
     * Sets the value of the stormWaterAddress property.
     *
     * @param value
     *     allowed object is
     *     {@link StormWaterAddress }
     *
     */
    public void setStormWaterAddress(final StormWaterAddress value) {
        this.stormWaterAddress = value;
    }

    @Transient
    public boolean isSetStormWaterAddress() {
        return (this.stormWaterAddress!= null);
    }

    @Override
	public boolean equals(final ObjectLocator thisLocator, final ObjectLocator thatLocator, final Object object, final EqualsStrategy strategy) {
        if (!(object instanceof SWConstructionPermit)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final SWConstructionPermit that = ((SWConstructionPermit) object);
        {
            String lhsStateWaterBodyName;
            lhsStateWaterBodyName = this.getStateWaterBodyName();
            String rhsStateWaterBodyName;
            rhsStateWaterBodyName = that.getStateWaterBodyName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stateWaterBodyName", lhsStateWaterBodyName), LocatorUtils.property(thatLocator, "stateWaterBodyName", rhsStateWaterBodyName), lhsStateWaterBodyName, rhsStateWaterBodyName)) {
                return false;
            }
        }
        {
            String lhsReceivingMS4Name;
            lhsReceivingMS4Name = this.getReceivingMS4Name();
            String rhsReceivingMS4Name;
            rhsReceivingMS4Name = that.getReceivingMS4Name();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "receivingMS4Name", lhsReceivingMS4Name), LocatorUtils.property(thatLocator, "receivingMS4Name", rhsReceivingMS4Name), lhsReceivingMS4Name, rhsReceivingMS4Name)) {
                return false;
            }
        }
        {
            String lhsImpairedWaterIndicator;
            lhsImpairedWaterIndicator = this.getImpairedWaterIndicator();
            String rhsImpairedWaterIndicator;
            rhsImpairedWaterIndicator = that.getImpairedWaterIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "impairedWaterIndicator", lhsImpairedWaterIndicator), LocatorUtils.property(thatLocator, "impairedWaterIndicator", rhsImpairedWaterIndicator), lhsImpairedWaterIndicator, rhsImpairedWaterIndicator)) {
                return false;
            }
        }
        {
            String lhsHistoricPropertyIndicator;
            lhsHistoricPropertyIndicator = this.getHistoricPropertyIndicator();
            String rhsHistoricPropertyIndicator;
            rhsHistoricPropertyIndicator = that.getHistoricPropertyIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "historicPropertyIndicator", lhsHistoricPropertyIndicator), LocatorUtils.property(thatLocator, "historicPropertyIndicator", rhsHistoricPropertyIndicator), lhsHistoricPropertyIndicator, rhsHistoricPropertyIndicator)) {
                return false;
            }
        }
        {
            String lhsHistoricPropertyCriterionMetCode;
            lhsHistoricPropertyCriterionMetCode = this.getHistoricPropertyCriterionMetCode();
            String rhsHistoricPropertyCriterionMetCode;
            rhsHistoricPropertyCriterionMetCode = that.getHistoricPropertyCriterionMetCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "historicPropertyCriterionMetCode", lhsHistoricPropertyCriterionMetCode), LocatorUtils.property(thatLocator, "historicPropertyCriterionMetCode", rhsHistoricPropertyCriterionMetCode), lhsHistoricPropertyCriterionMetCode, rhsHistoricPropertyCriterionMetCode)) {
                return false;
            }
        }
        {
            String lhsSpeciesCriticalHabitatIndicator;
            lhsSpeciesCriticalHabitatIndicator = this.getSpeciesCriticalHabitatIndicator();
            String rhsSpeciesCriticalHabitatIndicator;
            rhsSpeciesCriticalHabitatIndicator = that.getSpeciesCriticalHabitatIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "speciesCriticalHabitatIndicator", lhsSpeciesCriticalHabitatIndicator), LocatorUtils.property(thatLocator, "speciesCriticalHabitatIndicator", rhsSpeciesCriticalHabitatIndicator), lhsSpeciesCriticalHabitatIndicator, rhsSpeciesCriticalHabitatIndicator)) {
                return false;
            }
        }
        {
            String lhsSpeciesCriterionMetCode;
            lhsSpeciesCriterionMetCode = this.getSpeciesCriterionMetCode();
            String rhsSpeciesCriterionMetCode;
            rhsSpeciesCriterionMetCode = that.getSpeciesCriterionMetCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "speciesCriterionMetCode", lhsSpeciesCriterionMetCode), LocatorUtils.property(thatLocator, "speciesCriterionMetCode", rhsSpeciesCriterionMetCode), lhsSpeciesCriterionMetCode, rhsSpeciesCriterionMetCode)) {
                return false;
            }
        }
        {
            GPCFNoticeOfIntent lhsGPCFNoticeOfIntent;
            lhsGPCFNoticeOfIntent = this.getGPCFNoticeOfIntent();
            GPCFNoticeOfIntent rhsGPCFNoticeOfIntent;
            rhsGPCFNoticeOfIntent = that.getGPCFNoticeOfIntent();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "gpcfNoticeOfIntent", lhsGPCFNoticeOfIntent), LocatorUtils.property(thatLocator, "gpcfNoticeOfIntent", rhsGPCFNoticeOfIntent), lhsGPCFNoticeOfIntent, rhsGPCFNoticeOfIntent)) {
                return false;
            }
        }
        {
            GPCFNoticeOfTermination lhsGPCFNoticeOfTermination;
            lhsGPCFNoticeOfTermination = this.getGPCFNoticeOfTermination();
            GPCFNoticeOfTermination rhsGPCFNoticeOfTermination;
            rhsGPCFNoticeOfTermination = that.getGPCFNoticeOfTermination();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "gpcfNoticeOfTermination", lhsGPCFNoticeOfTermination), LocatorUtils.property(thatLocator, "gpcfNoticeOfTermination", rhsGPCFNoticeOfTermination), lhsGPCFNoticeOfTermination, rhsGPCFNoticeOfTermination)) {
                return false;
            }
        }
        {
            String lhsProjectTypeCode;
            lhsProjectTypeCode = this.getProjectTypeCode();
            String rhsProjectTypeCode;
            rhsProjectTypeCode = that.getProjectTypeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "projectTypeCode", lhsProjectTypeCode), LocatorUtils.property(thatLocator, "projectTypeCode", rhsProjectTypeCode), lhsProjectTypeCode, rhsProjectTypeCode)) {
                return false;
            }
        }
        {
            Date lhsEstimatedStartDate;
            lhsEstimatedStartDate = this.getEstimatedStartDate();
            Date rhsEstimatedStartDate;
            rhsEstimatedStartDate = that.getEstimatedStartDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "estimatedStartDate", lhsEstimatedStartDate), LocatorUtils.property(thatLocator, "estimatedStartDate", rhsEstimatedStartDate), lhsEstimatedStartDate, rhsEstimatedStartDate)) {
                return false;
            }
        }
        {
            Date lhsEstimatedCompleteDate;
            lhsEstimatedCompleteDate = this.getEstimatedCompleteDate();
            Date rhsEstimatedCompleteDate;
            rhsEstimatedCompleteDate = that.getEstimatedCompleteDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "estimatedCompleteDate", lhsEstimatedCompleteDate), LocatorUtils.property(thatLocator, "estimatedCompleteDate", rhsEstimatedCompleteDate), lhsEstimatedCompleteDate, rhsEstimatedCompleteDate)) {
                return false;
            }
        }
        {
            Integer lhsEstimatedAreaDisturbedAcresNumber;
            lhsEstimatedAreaDisturbedAcresNumber = this.getEstimatedAreaDisturbedAcresNumber();
            Integer rhsEstimatedAreaDisturbedAcresNumber;
            rhsEstimatedAreaDisturbedAcresNumber = that.getEstimatedAreaDisturbedAcresNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "estimatedAreaDisturbedAcresNumber", lhsEstimatedAreaDisturbedAcresNumber), LocatorUtils.property(thatLocator, "estimatedAreaDisturbedAcresNumber", rhsEstimatedAreaDisturbedAcresNumber), lhsEstimatedAreaDisturbedAcresNumber, rhsEstimatedAreaDisturbedAcresNumber)) {
                return false;
            }
        }
        {
            String lhsProjectPlanSizeCode;
            lhsProjectPlanSizeCode = this.getProjectPlanSizeCode();
            String rhsProjectPlanSizeCode;
            rhsProjectPlanSizeCode = that.getProjectPlanSizeCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "projectPlanSizeCode", lhsProjectPlanSizeCode), LocatorUtils.property(thatLocator, "projectPlanSizeCode", rhsProjectPlanSizeCode), lhsProjectPlanSizeCode, rhsProjectPlanSizeCode)) {
                return false;
            }
        }
        {
            StormWaterContact lhsStormWaterContact;
            lhsStormWaterContact = this.getStormWaterContact();
            StormWaterContact rhsStormWaterContact;
            rhsStormWaterContact = that.getStormWaterContact();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stormWaterContact", lhsStormWaterContact), LocatorUtils.property(thatLocator, "stormWaterContact", rhsStormWaterContact), lhsStormWaterContact, rhsStormWaterContact)) {
                return false;
            }
        }
        {
            StormWaterAddress lhsStormWaterAddress;
            lhsStormWaterAddress = this.getStormWaterAddress();
            StormWaterAddress rhsStormWaterAddress;
            rhsStormWaterAddress = that.getStormWaterAddress();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "stormWaterAddress", lhsStormWaterAddress), LocatorUtils.property(thatLocator, "stormWaterAddress", rhsStormWaterAddress), lhsStormWaterAddress, rhsStormWaterAddress)) {
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
        int currentHashCode = super.hashCode(locator, strategy);
        {
            String theStateWaterBodyName;
            theStateWaterBodyName = this.getStateWaterBodyName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stateWaterBodyName", theStateWaterBodyName), currentHashCode, theStateWaterBodyName);
        }
        {
            String theReceivingMS4Name;
            theReceivingMS4Name = this.getReceivingMS4Name();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "receivingMS4Name", theReceivingMS4Name), currentHashCode, theReceivingMS4Name);
        }
        {
            String theImpairedWaterIndicator;
            theImpairedWaterIndicator = this.getImpairedWaterIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "impairedWaterIndicator", theImpairedWaterIndicator), currentHashCode, theImpairedWaterIndicator);
        }
        {
            String theHistoricPropertyIndicator;
            theHistoricPropertyIndicator = this.getHistoricPropertyIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "historicPropertyIndicator", theHistoricPropertyIndicator), currentHashCode, theHistoricPropertyIndicator);
        }
        {
            String theHistoricPropertyCriterionMetCode;
            theHistoricPropertyCriterionMetCode = this.getHistoricPropertyCriterionMetCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "historicPropertyCriterionMetCode", theHistoricPropertyCriterionMetCode), currentHashCode, theHistoricPropertyCriterionMetCode);
        }
        {
            String theSpeciesCriticalHabitatIndicator;
            theSpeciesCriticalHabitatIndicator = this.getSpeciesCriticalHabitatIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "speciesCriticalHabitatIndicator", theSpeciesCriticalHabitatIndicator), currentHashCode, theSpeciesCriticalHabitatIndicator);
        }
        {
            String theSpeciesCriterionMetCode;
            theSpeciesCriterionMetCode = this.getSpeciesCriterionMetCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "speciesCriterionMetCode", theSpeciesCriterionMetCode), currentHashCode, theSpeciesCriterionMetCode);
        }
        {
            GPCFNoticeOfIntent theGPCFNoticeOfIntent;
            theGPCFNoticeOfIntent = this.getGPCFNoticeOfIntent();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "gpcfNoticeOfIntent", theGPCFNoticeOfIntent), currentHashCode, theGPCFNoticeOfIntent);
        }
        {
            GPCFNoticeOfTermination theGPCFNoticeOfTermination;
            theGPCFNoticeOfTermination = this.getGPCFNoticeOfTermination();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "gpcfNoticeOfTermination", theGPCFNoticeOfTermination), currentHashCode, theGPCFNoticeOfTermination);
        }
        {
            String theProjectTypeCode;
            theProjectTypeCode = this.getProjectTypeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "projectTypeCode", theProjectTypeCode), currentHashCode, theProjectTypeCode);
        }
        {
            Date theEstimatedStartDate;
            theEstimatedStartDate = this.getEstimatedStartDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "estimatedStartDate", theEstimatedStartDate), currentHashCode, theEstimatedStartDate);
        }
        {
            Date theEstimatedCompleteDate;
            theEstimatedCompleteDate = this.getEstimatedCompleteDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "estimatedCompleteDate", theEstimatedCompleteDate), currentHashCode, theEstimatedCompleteDate);
        }
        {
            Integer theEstimatedAreaDisturbedAcresNumber;
            theEstimatedAreaDisturbedAcresNumber = this.getEstimatedAreaDisturbedAcresNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "estimatedAreaDisturbedAcresNumber", theEstimatedAreaDisturbedAcresNumber), currentHashCode, theEstimatedAreaDisturbedAcresNumber);
        }
        {
            String theProjectPlanSizeCode;
            theProjectPlanSizeCode = this.getProjectPlanSizeCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "projectPlanSizeCode", theProjectPlanSizeCode), currentHashCode, theProjectPlanSizeCode);
        }
        {
            StormWaterContact theStormWaterContact;
            theStormWaterContact = this.getStormWaterContact();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stormWaterContact", theStormWaterContact), currentHashCode, theStormWaterContact);
        }
        {
            StormWaterAddress theStormWaterAddress;
            theStormWaterAddress = this.getStormWaterAddress();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "stormWaterAddress", theStormWaterAddress), currentHashCode, theStormWaterAddress);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

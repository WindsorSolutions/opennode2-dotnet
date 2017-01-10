//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.AssociationOverride;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.Embedded;
import javax.persistence.JoinColumn;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.IntegerAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.OneDigitPrecisionAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for SWEventReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SWEventReport">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/5}SWEventReportKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}PermittedFeatureIdentifier" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}RainfallStormEventSampledNumber" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}DurationStormEventSampled" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}VolumeDischargeSample" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}DurationSinceLastStormEvent" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SamplingBasisIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}PrecipitationForm" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}SampleTakenWithinTimeframeIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}TimeExceedanceRationaleCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}EssentiallyIdenticalOutfallNotification" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}MonitoringExemptionRationaleIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}PollutantMonitoringBasisCode" minOccurs="0"/>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/5}StormWaterContactGroup" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SWEventReport", propOrder = {
    "permittedFeatureIdentifier",
    "rainfallStormEventSampledNumber",
    "durationStormEventSampled",
    "volumeDischargeSample",
    "durationSinceLastStormEvent",
    "samplingBasisIndicator",
    "precipitationForm",
    "sampleTakenWithinTimeframeIndicator",
    "timeExceedanceRationaleCode",
    "essentiallyIdenticalOutfallNotification",
    "monitoringExemptionRationaleIndicator",
    "pollutantMonitoringBasisCode",
    "stormWaterContact",
    "stormWaterAddress"
})
@Embeddable
public class SWEventReport
    extends SWEventReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermittedFeatureIdentifier")
    protected String permittedFeatureIdentifier;
    @XmlElement(name = "RainfallStormEventSampledNumber", type = String.class)
    @XmlJavaTypeAdapter(OneDigitPrecisionAdapter.class)
    protected BigDecimal rainfallStormEventSampledNumber;
    @XmlElement(name = "DurationStormEventSampled")
    protected String durationStormEventSampled;
    @XmlElement(name = "VolumeDischargeSample", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer volumeDischargeSample;
    @XmlElement(name = "DurationSinceLastStormEvent", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer durationSinceLastStormEvent;
    @XmlElement(name = "SamplingBasisIndicator")
    protected String samplingBasisIndicator;
    @XmlElement(name = "PrecipitationForm")
    protected String precipitationForm;
    @XmlElement(name = "SampleTakenWithinTimeframeIndicator")
    protected String sampleTakenWithinTimeframeIndicator;
    @XmlElement(name = "TimeExceedanceRationaleCode")
    protected String timeExceedanceRationaleCode;
    @XmlElement(name = "EssentiallyIdenticalOutfallNotification")
    protected String essentiallyIdenticalOutfallNotification;
    @XmlElement(name = "MonitoringExemptionRationaleIndicator")
    protected String monitoringExemptionRationaleIndicator;
    @XmlElement(name = "PollutantMonitoringBasisCode")
    protected String pollutantMonitoringBasisCode;
    @XmlElement(name = "StormWaterContact")
    protected StormWaterContact stormWaterContact;
    @XmlElement(name = "StormWaterAddress")
    protected StormWaterAddress stormWaterAddress;

    /**
     * Gets the value of the permittedFeatureIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRMT_FEATR_IDENT", length = 4)
    public String getPermittedFeatureIdentifier() {
        return permittedFeatureIdentifier;
    }

    /**
     * Sets the value of the permittedFeatureIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermittedFeatureIdentifier(String value) {
        this.permittedFeatureIdentifier = value;
    }

    @Transient
    public boolean isSetPermittedFeatureIdentifier() {
        return (this.permittedFeatureIdentifier!= null);
    }

    /**
     * Gets the value of the rainfallStormEventSampledNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "RAINFALL_STRM_EVT_SMPL_NUM", scale = 1)
    public BigDecimal getRainfallStormEventSampledNumber() {
        return rainfallStormEventSampledNumber;
    }

    /**
     * Sets the value of the rainfallStormEventSampledNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setRainfallStormEventSampledNumber(BigDecimal value) {
        this.rainfallStormEventSampledNumber = value;
    }

    @Transient
    public boolean isSetRainfallStormEventSampledNumber() {
        return (this.rainfallStormEventSampledNumber!= null);
    }

    /**
     * Gets the value of the durationStormEventSampled property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DURATION_STRM_EVT_SMPL", length = 5)
    public String getDurationStormEventSampled() {
        return durationStormEventSampled;
    }

    /**
     * Sets the value of the durationStormEventSampled property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDurationStormEventSampled(String value) {
        this.durationStormEventSampled = value;
    }

    @Transient
    public boolean isSetDurationStormEventSampled() {
        return (this.durationStormEventSampled!= null);
    }

    /**
     * Gets the value of the volumeDischargeSample property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "VOL_DSCH_SMPL", scale = 0)
    public Integer getVolumeDischargeSample() {
        return volumeDischargeSample;
    }

    /**
     * Sets the value of the volumeDischargeSample property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVolumeDischargeSample(Integer value) {
        this.volumeDischargeSample = value;
    }

    @Transient
    public boolean isSetVolumeDischargeSample() {
        return (this.volumeDischargeSample!= null);
    }

    /**
     * Gets the value of the durationSinceLastStormEvent property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DURATION_SINCE_LAST_STRM_EVT", scale = 0)
    public Integer getDurationSinceLastStormEvent() {
        return durationSinceLastStormEvent;
    }

    /**
     * Sets the value of the durationSinceLastStormEvent property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDurationSinceLastStormEvent(Integer value) {
        this.durationSinceLastStormEvent = value;
    }

    @Transient
    public boolean isSetDurationSinceLastStormEvent() {
        return (this.durationSinceLastStormEvent!= null);
    }

    /**
     * Gets the value of the samplingBasisIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SMPL_BASIS_IND", columnDefinition = "char(1)", length = 1)
    public String getSamplingBasisIndicator() {
        return samplingBasisIndicator;
    }

    /**
     * Sets the value of the samplingBasisIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSamplingBasisIndicator(String value) {
        this.samplingBasisIndicator = value;
    }

    @Transient
    public boolean isSetSamplingBasisIndicator() {
        return (this.samplingBasisIndicator!= null);
    }

    /**
     * Gets the value of the precipitationForm property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRECIP_FORM", columnDefinition = "char(1)", length = 1)
    public String getPrecipitationForm() {
        return precipitationForm;
    }

    /**
     * Sets the value of the precipitationForm property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPrecipitationForm(String value) {
        this.precipitationForm = value;
    }

    @Transient
    public boolean isSetPrecipitationForm() {
        return (this.precipitationForm!= null);
    }

    /**
     * Gets the value of the sampleTakenWithinTimeframeIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "SMPL_TAKEN_WITHIN_TIMEFRME_IND", columnDefinition = "char(1)", length = 1)
    public String getSampleTakenWithinTimeframeIndicator() {
        return sampleTakenWithinTimeframeIndicator;
    }

    /**
     * Sets the value of the sampleTakenWithinTimeframeIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSampleTakenWithinTimeframeIndicator(String value) {
        this.sampleTakenWithinTimeframeIndicator = value;
    }

    @Transient
    public boolean isSetSampleTakenWithinTimeframeIndicator() {
        return (this.sampleTakenWithinTimeframeIndicator!= null);
    }

    /**
     * Gets the value of the timeExceedanceRationaleCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TIME_EXCEEDANCE_RATIONALE_CODE", length = 3)
    public String getTimeExceedanceRationaleCode() {
        return timeExceedanceRationaleCode;
    }

    /**
     * Sets the value of the timeExceedanceRationaleCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTimeExceedanceRationaleCode(String value) {
        this.timeExceedanceRationaleCode = value;
    }

    @Transient
    public boolean isSetTimeExceedanceRationaleCode() {
        return (this.timeExceedanceRationaleCode!= null);
    }

    /**
     * Gets the value of the essentiallyIdenticalOutfallNotification property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "ESSEN_IDENTICAL_OUTFALL_NOTIF", length = 50)
    public String getEssentiallyIdenticalOutfallNotification() {
        return essentiallyIdenticalOutfallNotification;
    }

    /**
     * Sets the value of the essentiallyIdenticalOutfallNotification property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEssentiallyIdenticalOutfallNotification(String value) {
        this.essentiallyIdenticalOutfallNotification = value;
    }

    @Transient
    public boolean isSetEssentiallyIdenticalOutfallNotification() {
        return (this.essentiallyIdenticalOutfallNotification!= null);
    }

    /**
     * Gets the value of the monitoringExemptionRationaleIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "MON_EXEMPTION_RATIONALE_IND", length = 3)
    public String getMonitoringExemptionRationaleIndicator() {
        return monitoringExemptionRationaleIndicator;
    }

    /**
     * Sets the value of the monitoringExemptionRationaleIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMonitoringExemptionRationaleIndicator(String value) {
        this.monitoringExemptionRationaleIndicator = value;
    }

    @Transient
    public boolean isSetMonitoringExemptionRationaleIndicator() {
        return (this.monitoringExemptionRationaleIndicator!= null);
    }

    /**
     * Gets the value of the pollutantMonitoringBasisCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "POLUT_MON_BASIS_CODE", length = 3)
    public String getPollutantMonitoringBasisCode() {
        return pollutantMonitoringBasisCode;
    }

    /**
     * Sets the value of the pollutantMonitoringBasisCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPollutantMonitoringBasisCode(String value) {
        this.pollutantMonitoringBasisCode = value;
    }

    @Transient
    public boolean isSetPollutantMonitoringBasisCode() {
        return (this.pollutantMonitoringBasisCode!= null);
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
    @AssociationOverride(name = "contact", joinColumns = {
        @JoinColumn(name = "ICS_SW_EVT_REP_ID")
    })
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
    public void setStormWaterContact(StormWaterContact value) {
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
    @AssociationOverride(name = "address", joinColumns = {
        @JoinColumn(name = "ICS_SW_EVT_REP_ID")
    })
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
    public void setStormWaterAddress(StormWaterAddress value) {
        this.stormWaterAddress = value;
    }

    @Transient
    public boolean isSetStormWaterAddress() {
        return (this.stormWaterAddress!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof SWEventReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final SWEventReport that = ((SWEventReport) object);
        {
            String lhsPermittedFeatureIdentifier;
            lhsPermittedFeatureIdentifier = this.getPermittedFeatureIdentifier();
            String rhsPermittedFeatureIdentifier;
            rhsPermittedFeatureIdentifier = that.getPermittedFeatureIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permittedFeatureIdentifier", lhsPermittedFeatureIdentifier), LocatorUtils.property(thatLocator, "permittedFeatureIdentifier", rhsPermittedFeatureIdentifier), lhsPermittedFeatureIdentifier, rhsPermittedFeatureIdentifier)) {
                return false;
            }
        }
        {
            BigDecimal lhsRainfallStormEventSampledNumber;
            lhsRainfallStormEventSampledNumber = this.getRainfallStormEventSampledNumber();
            BigDecimal rhsRainfallStormEventSampledNumber;
            rhsRainfallStormEventSampledNumber = that.getRainfallStormEventSampledNumber();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "rainfallStormEventSampledNumber", lhsRainfallStormEventSampledNumber), LocatorUtils.property(thatLocator, "rainfallStormEventSampledNumber", rhsRainfallStormEventSampledNumber), lhsRainfallStormEventSampledNumber, rhsRainfallStormEventSampledNumber)) {
                return false;
            }
        }
        {
            String lhsDurationStormEventSampled;
            lhsDurationStormEventSampled = this.getDurationStormEventSampled();
            String rhsDurationStormEventSampled;
            rhsDurationStormEventSampled = that.getDurationStormEventSampled();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "durationStormEventSampled", lhsDurationStormEventSampled), LocatorUtils.property(thatLocator, "durationStormEventSampled", rhsDurationStormEventSampled), lhsDurationStormEventSampled, rhsDurationStormEventSampled)) {
                return false;
            }
        }
        {
            Integer lhsVolumeDischargeSample;
            lhsVolumeDischargeSample = this.getVolumeDischargeSample();
            Integer rhsVolumeDischargeSample;
            rhsVolumeDischargeSample = that.getVolumeDischargeSample();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "volumeDischargeSample", lhsVolumeDischargeSample), LocatorUtils.property(thatLocator, "volumeDischargeSample", rhsVolumeDischargeSample), lhsVolumeDischargeSample, rhsVolumeDischargeSample)) {
                return false;
            }
        }
        {
            Integer lhsDurationSinceLastStormEvent;
            lhsDurationSinceLastStormEvent = this.getDurationSinceLastStormEvent();
            Integer rhsDurationSinceLastStormEvent;
            rhsDurationSinceLastStormEvent = that.getDurationSinceLastStormEvent();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "durationSinceLastStormEvent", lhsDurationSinceLastStormEvent), LocatorUtils.property(thatLocator, "durationSinceLastStormEvent", rhsDurationSinceLastStormEvent), lhsDurationSinceLastStormEvent, rhsDurationSinceLastStormEvent)) {
                return false;
            }
        }
        {
            String lhsSamplingBasisIndicator;
            lhsSamplingBasisIndicator = this.getSamplingBasisIndicator();
            String rhsSamplingBasisIndicator;
            rhsSamplingBasisIndicator = that.getSamplingBasisIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "samplingBasisIndicator", lhsSamplingBasisIndicator), LocatorUtils.property(thatLocator, "samplingBasisIndicator", rhsSamplingBasisIndicator), lhsSamplingBasisIndicator, rhsSamplingBasisIndicator)) {
                return false;
            }
        }
        {
            String lhsPrecipitationForm;
            lhsPrecipitationForm = this.getPrecipitationForm();
            String rhsPrecipitationForm;
            rhsPrecipitationForm = that.getPrecipitationForm();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "precipitationForm", lhsPrecipitationForm), LocatorUtils.property(thatLocator, "precipitationForm", rhsPrecipitationForm), lhsPrecipitationForm, rhsPrecipitationForm)) {
                return false;
            }
        }
        {
            String lhsSampleTakenWithinTimeframeIndicator;
            lhsSampleTakenWithinTimeframeIndicator = this.getSampleTakenWithinTimeframeIndicator();
            String rhsSampleTakenWithinTimeframeIndicator;
            rhsSampleTakenWithinTimeframeIndicator = that.getSampleTakenWithinTimeframeIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "sampleTakenWithinTimeframeIndicator", lhsSampleTakenWithinTimeframeIndicator), LocatorUtils.property(thatLocator, "sampleTakenWithinTimeframeIndicator", rhsSampleTakenWithinTimeframeIndicator), lhsSampleTakenWithinTimeframeIndicator, rhsSampleTakenWithinTimeframeIndicator)) {
                return false;
            }
        }
        {
            String lhsTimeExceedanceRationaleCode;
            lhsTimeExceedanceRationaleCode = this.getTimeExceedanceRationaleCode();
            String rhsTimeExceedanceRationaleCode;
            rhsTimeExceedanceRationaleCode = that.getTimeExceedanceRationaleCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "timeExceedanceRationaleCode", lhsTimeExceedanceRationaleCode), LocatorUtils.property(thatLocator, "timeExceedanceRationaleCode", rhsTimeExceedanceRationaleCode), lhsTimeExceedanceRationaleCode, rhsTimeExceedanceRationaleCode)) {
                return false;
            }
        }
        {
            String lhsEssentiallyIdenticalOutfallNotification;
            lhsEssentiallyIdenticalOutfallNotification = this.getEssentiallyIdenticalOutfallNotification();
            String rhsEssentiallyIdenticalOutfallNotification;
            rhsEssentiallyIdenticalOutfallNotification = that.getEssentiallyIdenticalOutfallNotification();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "essentiallyIdenticalOutfallNotification", lhsEssentiallyIdenticalOutfallNotification), LocatorUtils.property(thatLocator, "essentiallyIdenticalOutfallNotification", rhsEssentiallyIdenticalOutfallNotification), lhsEssentiallyIdenticalOutfallNotification, rhsEssentiallyIdenticalOutfallNotification)) {
                return false;
            }
        }
        {
            String lhsMonitoringExemptionRationaleIndicator;
            lhsMonitoringExemptionRationaleIndicator = this.getMonitoringExemptionRationaleIndicator();
            String rhsMonitoringExemptionRationaleIndicator;
            rhsMonitoringExemptionRationaleIndicator = that.getMonitoringExemptionRationaleIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "monitoringExemptionRationaleIndicator", lhsMonitoringExemptionRationaleIndicator), LocatorUtils.property(thatLocator, "monitoringExemptionRationaleIndicator", rhsMonitoringExemptionRationaleIndicator), lhsMonitoringExemptionRationaleIndicator, rhsMonitoringExemptionRationaleIndicator)) {
                return false;
            }
        }
        {
            String lhsPollutantMonitoringBasisCode;
            lhsPollutantMonitoringBasisCode = this.getPollutantMonitoringBasisCode();
            String rhsPollutantMonitoringBasisCode;
            rhsPollutantMonitoringBasisCode = that.getPollutantMonitoringBasisCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pollutantMonitoringBasisCode", lhsPollutantMonitoringBasisCode), LocatorUtils.property(thatLocator, "pollutantMonitoringBasisCode", rhsPollutantMonitoringBasisCode), lhsPollutantMonitoringBasisCode, rhsPollutantMonitoringBasisCode)) {
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

    public boolean equals(Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    public int hashCode(ObjectLocator locator, HashCodeStrategy strategy) {
        int currentHashCode = super.hashCode(locator, strategy);
        {
            String thePermittedFeatureIdentifier;
            thePermittedFeatureIdentifier = this.getPermittedFeatureIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permittedFeatureIdentifier", thePermittedFeatureIdentifier), currentHashCode, thePermittedFeatureIdentifier);
        }
        {
            BigDecimal theRainfallStormEventSampledNumber;
            theRainfallStormEventSampledNumber = this.getRainfallStormEventSampledNumber();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "rainfallStormEventSampledNumber", theRainfallStormEventSampledNumber), currentHashCode, theRainfallStormEventSampledNumber);
        }
        {
            String theDurationStormEventSampled;
            theDurationStormEventSampled = this.getDurationStormEventSampled();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "durationStormEventSampled", theDurationStormEventSampled), currentHashCode, theDurationStormEventSampled);
        }
        {
            Integer theVolumeDischargeSample;
            theVolumeDischargeSample = this.getVolumeDischargeSample();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "volumeDischargeSample", theVolumeDischargeSample), currentHashCode, theVolumeDischargeSample);
        }
        {
            Integer theDurationSinceLastStormEvent;
            theDurationSinceLastStormEvent = this.getDurationSinceLastStormEvent();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "durationSinceLastStormEvent", theDurationSinceLastStormEvent), currentHashCode, theDurationSinceLastStormEvent);
        }
        {
            String theSamplingBasisIndicator;
            theSamplingBasisIndicator = this.getSamplingBasisIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "samplingBasisIndicator", theSamplingBasisIndicator), currentHashCode, theSamplingBasisIndicator);
        }
        {
            String thePrecipitationForm;
            thePrecipitationForm = this.getPrecipitationForm();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "precipitationForm", thePrecipitationForm), currentHashCode, thePrecipitationForm);
        }
        {
            String theSampleTakenWithinTimeframeIndicator;
            theSampleTakenWithinTimeframeIndicator = this.getSampleTakenWithinTimeframeIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "sampleTakenWithinTimeframeIndicator", theSampleTakenWithinTimeframeIndicator), currentHashCode, theSampleTakenWithinTimeframeIndicator);
        }
        {
            String theTimeExceedanceRationaleCode;
            theTimeExceedanceRationaleCode = this.getTimeExceedanceRationaleCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "timeExceedanceRationaleCode", theTimeExceedanceRationaleCode), currentHashCode, theTimeExceedanceRationaleCode);
        }
        {
            String theEssentiallyIdenticalOutfallNotification;
            theEssentiallyIdenticalOutfallNotification = this.getEssentiallyIdenticalOutfallNotification();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "essentiallyIdenticalOutfallNotification", theEssentiallyIdenticalOutfallNotification), currentHashCode, theEssentiallyIdenticalOutfallNotification);
        }
        {
            String theMonitoringExemptionRationaleIndicator;
            theMonitoringExemptionRationaleIndicator = this.getMonitoringExemptionRationaleIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "monitoringExemptionRationaleIndicator", theMonitoringExemptionRationaleIndicator), currentHashCode, theMonitoringExemptionRationaleIndicator);
        }
        {
            String thePollutantMonitoringBasisCode;
            thePollutantMonitoringBasisCode = this.getPollutantMonitoringBasisCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pollutantMonitoringBasisCode", thePollutantMonitoringBasisCode), currentHashCode, thePollutantMonitoringBasisCode);
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

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
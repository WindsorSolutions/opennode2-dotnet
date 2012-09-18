//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 08:27:53 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.Decimal10FloatingTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.Decimal11FloatingTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.TwoDigitPrecisionAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for CSOEventReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CSOEventReport">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}CSOEventReportKeyElements">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}CSOOverflowEventGroup" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CSOEventReport", propOrder = {
    "dryOrWetWeatherIndicator",
    "permittedFeatureIdentifier",
    "latitudeMeasure",
    "longitudeMeasure",
    "csoOverflowLocationStreet",
    "durationCSOOverflowEvent",
    "dischargeVolumeTreated",
    "dischargeVolumeUntreated",
    "correctiveActionTakenDescriptionText",
    "inchesPrecipitation"
})
@Embeddable
public class CSOEventReport
    extends CSOEventReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "DryOrWetWeatherIndicator")
    protected String dryOrWetWeatherIndicator;
    @XmlElement(name = "PermittedFeatureIdentifier")
    protected String permittedFeatureIdentifier;
    @XmlElement(name = "LatitudeMeasure", type = String.class)
    @XmlJavaTypeAdapter(Decimal10FloatingTypeAdapter.class)
    protected BigDecimal latitudeMeasure;
    @XmlElement(name = "LongitudeMeasure", type = String.class)
    @XmlJavaTypeAdapter(Decimal11FloatingTypeAdapter.class)
    protected BigDecimal longitudeMeasure;
    @XmlElement(name = "CSOOverflowLocationStreet")
    protected String csoOverflowLocationStreet;
    @XmlElement(name = "DurationCSOOverflowEvent", type = String.class)
    @XmlJavaTypeAdapter(TwoDigitPrecisionAdapter.class)
    protected BigDecimal durationCSOOverflowEvent;
    @XmlElement(name = "DischargeVolumeTreated", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer dischargeVolumeTreated;
    @XmlElement(name = "DischargeVolumeUntreated", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer dischargeVolumeUntreated;
    @XmlElement(name = "CorrectiveActionTakenDescriptionText")
    protected String correctiveActionTakenDescriptionText;
    @XmlElement(name = "InchesPrecipitation", type = String.class)
    @XmlJavaTypeAdapter(TwoDigitPrecisionAdapter.class)
    protected BigDecimal inchesPrecipitation;

    /**
     * Gets the value of the dryOrWetWeatherIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DRY_OR_WET_WEATHER_IND", columnDefinition = "char(1)", length = 1)
    public String getDryOrWetWeatherIndicator() {
        return dryOrWetWeatherIndicator;
    }

    /**
     * Sets the value of the dryOrWetWeatherIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDryOrWetWeatherIndicator(String value) {
        this.dryOrWetWeatherIndicator = value;
    }

    @Transient
    public boolean isSetDryOrWetWeatherIndicator() {
        return (this.dryOrWetWeatherIndicator!= null);
    }

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
     * Gets the value of the latitudeMeasure property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LAT_MEAS", length = 10)
    public BigDecimal getLatitudeMeasure() {
        return latitudeMeasure;
    }

    /**
     * Sets the value of the latitudeMeasure property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLatitudeMeasure(BigDecimal value) {
        this.latitudeMeasure = value;
    }

    @Transient
    public boolean isSetLatitudeMeasure() {
        return (this.latitudeMeasure!= null);
    }

    /**
     * Gets the value of the longitudeMeasure property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "LONG_MEAS", length = 11)
    public BigDecimal getLongitudeMeasure() {
        return longitudeMeasure;
    }

    /**
     * Sets the value of the longitudeMeasure property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLongitudeMeasure(BigDecimal value) {
        this.longitudeMeasure = value;
    }

    @Transient
    public boolean isSetLongitudeMeasure() {
        return (this.longitudeMeasure!= null);
    }

    /**
     * Gets the value of the csoOverflowLocationStreet property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CSO_OVRFLW_LOC_STREET", length = 4000)
    public String getCSOOverflowLocationStreet() {
        return csoOverflowLocationStreet;
    }

    /**
     * Sets the value of the csoOverflowLocationStreet property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCSOOverflowLocationStreet(String value) {
        this.csoOverflowLocationStreet = value;
    }

    @Transient
    public boolean isSetCSOOverflowLocationStreet() {
        return (this.csoOverflowLocationStreet!= null);
    }

    /**
     * Gets the value of the durationCSOOverflowEvent property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DURATION_CSO_OVRFLW_EVT", scale = 2)
    public BigDecimal getDurationCSOOverflowEvent() {
        return durationCSOOverflowEvent;
    }

    /**
     * Sets the value of the durationCSOOverflowEvent property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDurationCSOOverflowEvent(BigDecimal value) {
        this.durationCSOOverflowEvent = value;
    }

    @Transient
    public boolean isSetDurationCSOOverflowEvent() {
        return (this.durationCSOOverflowEvent!= null);
    }

    /**
     * Gets the value of the dischargeVolumeTreated property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DSCH_VOL_TREATED", scale = 0)
    public Integer getDischargeVolumeTreated() {
        return dischargeVolumeTreated;
    }

    /**
     * Sets the value of the dischargeVolumeTreated property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDischargeVolumeTreated(Integer value) {
        this.dischargeVolumeTreated = value;
    }

    @Transient
    public boolean isSetDischargeVolumeTreated() {
        return (this.dischargeVolumeTreated!= null);
    }

    /**
     * Gets the value of the dischargeVolumeUntreated property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "DSCH_VOL_UNTREATED", scale = 0)
    public Integer getDischargeVolumeUntreated() {
        return dischargeVolumeUntreated;
    }

    /**
     * Sets the value of the dischargeVolumeUntreated property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDischargeVolumeUntreated(Integer value) {
        this.dischargeVolumeUntreated = value;
    }

    @Transient
    public boolean isSetDischargeVolumeUntreated() {
        return (this.dischargeVolumeUntreated!= null);
    }

    /**
     * Gets the value of the correctiveActionTakenDescriptionText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CORR_ACTN_TAKEN_DESC_TXT", length = 4000)
    public String getCorrectiveActionTakenDescriptionText() {
        return correctiveActionTakenDescriptionText;
    }

    /**
     * Sets the value of the correctiveActionTakenDescriptionText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCorrectiveActionTakenDescriptionText(String value) {
        this.correctiveActionTakenDescriptionText = value;
    }

    @Transient
    public boolean isSetCorrectiveActionTakenDescriptionText() {
        return (this.correctiveActionTakenDescriptionText!= null);
    }

    /**
     * Gets the value of the inchesPrecipitation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "INCHES_PRECIP", scale = 2)
    public BigDecimal getInchesPrecipitation() {
        return inchesPrecipitation;
    }

    /**
     * Sets the value of the inchesPrecipitation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setInchesPrecipitation(BigDecimal value) {
        this.inchesPrecipitation = value;
    }

    @Transient
    public boolean isSetInchesPrecipitation() {
        return (this.inchesPrecipitation!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof CSOEventReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final CSOEventReport that = ((CSOEventReport) object);
        {
            String lhsDryOrWetWeatherIndicator;
            lhsDryOrWetWeatherIndicator = this.getDryOrWetWeatherIndicator();
            String rhsDryOrWetWeatherIndicator;
            rhsDryOrWetWeatherIndicator = that.getDryOrWetWeatherIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dryOrWetWeatherIndicator", lhsDryOrWetWeatherIndicator), LocatorUtils.property(thatLocator, "dryOrWetWeatherIndicator", rhsDryOrWetWeatherIndicator), lhsDryOrWetWeatherIndicator, rhsDryOrWetWeatherIndicator)) {
                return false;
            }
        }
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
            BigDecimal lhsLatitudeMeasure;
            lhsLatitudeMeasure = this.getLatitudeMeasure();
            BigDecimal rhsLatitudeMeasure;
            rhsLatitudeMeasure = that.getLatitudeMeasure();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "latitudeMeasure", lhsLatitudeMeasure), LocatorUtils.property(thatLocator, "latitudeMeasure", rhsLatitudeMeasure), lhsLatitudeMeasure, rhsLatitudeMeasure)) {
                return false;
            }
        }
        {
            BigDecimal lhsLongitudeMeasure;
            lhsLongitudeMeasure = this.getLongitudeMeasure();
            BigDecimal rhsLongitudeMeasure;
            rhsLongitudeMeasure = that.getLongitudeMeasure();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "longitudeMeasure", lhsLongitudeMeasure), LocatorUtils.property(thatLocator, "longitudeMeasure", rhsLongitudeMeasure), lhsLongitudeMeasure, rhsLongitudeMeasure)) {
                return false;
            }
        }
        {
            String lhsCSOOverflowLocationStreet;
            lhsCSOOverflowLocationStreet = this.getCSOOverflowLocationStreet();
            String rhsCSOOverflowLocationStreet;
            rhsCSOOverflowLocationStreet = that.getCSOOverflowLocationStreet();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "csoOverflowLocationStreet", lhsCSOOverflowLocationStreet), LocatorUtils.property(thatLocator, "csoOverflowLocationStreet", rhsCSOOverflowLocationStreet), lhsCSOOverflowLocationStreet, rhsCSOOverflowLocationStreet)) {
                return false;
            }
        }
        {
            BigDecimal lhsDurationCSOOverflowEvent;
            lhsDurationCSOOverflowEvent = this.getDurationCSOOverflowEvent();
            BigDecimal rhsDurationCSOOverflowEvent;
            rhsDurationCSOOverflowEvent = that.getDurationCSOOverflowEvent();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "durationCSOOverflowEvent", lhsDurationCSOOverflowEvent), LocatorUtils.property(thatLocator, "durationCSOOverflowEvent", rhsDurationCSOOverflowEvent), lhsDurationCSOOverflowEvent, rhsDurationCSOOverflowEvent)) {
                return false;
            }
        }
        {
            Integer lhsDischargeVolumeTreated;
            lhsDischargeVolumeTreated = this.getDischargeVolumeTreated();
            Integer rhsDischargeVolumeTreated;
            rhsDischargeVolumeTreated = that.getDischargeVolumeTreated();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dischargeVolumeTreated", lhsDischargeVolumeTreated), LocatorUtils.property(thatLocator, "dischargeVolumeTreated", rhsDischargeVolumeTreated), lhsDischargeVolumeTreated, rhsDischargeVolumeTreated)) {
                return false;
            }
        }
        {
            Integer lhsDischargeVolumeUntreated;
            lhsDischargeVolumeUntreated = this.getDischargeVolumeUntreated();
            Integer rhsDischargeVolumeUntreated;
            rhsDischargeVolumeUntreated = that.getDischargeVolumeUntreated();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dischargeVolumeUntreated", lhsDischargeVolumeUntreated), LocatorUtils.property(thatLocator, "dischargeVolumeUntreated", rhsDischargeVolumeUntreated), lhsDischargeVolumeUntreated, rhsDischargeVolumeUntreated)) {
                return false;
            }
        }
        {
            String lhsCorrectiveActionTakenDescriptionText;
            lhsCorrectiveActionTakenDescriptionText = this.getCorrectiveActionTakenDescriptionText();
            String rhsCorrectiveActionTakenDescriptionText;
            rhsCorrectiveActionTakenDescriptionText = that.getCorrectiveActionTakenDescriptionText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "correctiveActionTakenDescriptionText", lhsCorrectiveActionTakenDescriptionText), LocatorUtils.property(thatLocator, "correctiveActionTakenDescriptionText", rhsCorrectiveActionTakenDescriptionText), lhsCorrectiveActionTakenDescriptionText, rhsCorrectiveActionTakenDescriptionText)) {
                return false;
            }
        }
        {
            BigDecimal lhsInchesPrecipitation;
            lhsInchesPrecipitation = this.getInchesPrecipitation();
            BigDecimal rhsInchesPrecipitation;
            rhsInchesPrecipitation = that.getInchesPrecipitation();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "inchesPrecipitation", lhsInchesPrecipitation), LocatorUtils.property(thatLocator, "inchesPrecipitation", rhsInchesPrecipitation), lhsInchesPrecipitation, rhsInchesPrecipitation)) {
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
            String theDryOrWetWeatherIndicator;
            theDryOrWetWeatherIndicator = this.getDryOrWetWeatherIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dryOrWetWeatherIndicator", theDryOrWetWeatherIndicator), currentHashCode, theDryOrWetWeatherIndicator);
        }
        {
            String thePermittedFeatureIdentifier;
            thePermittedFeatureIdentifier = this.getPermittedFeatureIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permittedFeatureIdentifier", thePermittedFeatureIdentifier), currentHashCode, thePermittedFeatureIdentifier);
        }
        {
            BigDecimal theLatitudeMeasure;
            theLatitudeMeasure = this.getLatitudeMeasure();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "latitudeMeasure", theLatitudeMeasure), currentHashCode, theLatitudeMeasure);
        }
        {
            BigDecimal theLongitudeMeasure;
            theLongitudeMeasure = this.getLongitudeMeasure();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "longitudeMeasure", theLongitudeMeasure), currentHashCode, theLongitudeMeasure);
        }
        {
            String theCSOOverflowLocationStreet;
            theCSOOverflowLocationStreet = this.getCSOOverflowLocationStreet();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "csoOverflowLocationStreet", theCSOOverflowLocationStreet), currentHashCode, theCSOOverflowLocationStreet);
        }
        {
            BigDecimal theDurationCSOOverflowEvent;
            theDurationCSOOverflowEvent = this.getDurationCSOOverflowEvent();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "durationCSOOverflowEvent", theDurationCSOOverflowEvent), currentHashCode, theDurationCSOOverflowEvent);
        }
        {
            Integer theDischargeVolumeTreated;
            theDischargeVolumeTreated = this.getDischargeVolumeTreated();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dischargeVolumeTreated", theDischargeVolumeTreated), currentHashCode, theDischargeVolumeTreated);
        }
        {
            Integer theDischargeVolumeUntreated;
            theDischargeVolumeUntreated = this.getDischargeVolumeUntreated();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dischargeVolumeUntreated", theDischargeVolumeUntreated), currentHashCode, theDischargeVolumeUntreated);
        }
        {
            String theCorrectiveActionTakenDescriptionText;
            theCorrectiveActionTakenDescriptionText = this.getCorrectiveActionTakenDescriptionText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "correctiveActionTakenDescriptionText", theCorrectiveActionTakenDescriptionText), currentHashCode, theCorrectiveActionTakenDescriptionText);
        }
        {
            BigDecimal theInchesPrecipitation;
            theInchesPrecipitation = this.getInchesPrecipitation();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "inchesPrecipitation", theInchesPrecipitation), currentHashCode, theInchesPrecipitation);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

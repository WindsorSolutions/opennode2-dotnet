//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.18 at 11:48:16 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for InspectionConclusionDataSheet complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="InspectionConclusionDataSheet">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DeficienciesObservedIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DeficiencyObservedCode" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}DeficiencyCommunicatedFacilityIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FacilityActionObservedIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}CorrectiveActionCode" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}AirPollutantCode" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}WaterPollutantCode" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NationalPolicyGeneralAssistanceIndicator" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NationalPolicySiteSpecificAssistanceIndicator" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "InspectionConclusionDataSheet", propOrder = {
    "deficienciesObservedIndicator",
    "deficiencyObservedCode",
    "deficiencyCommunicatedFacilityIndicator",
    "facilityActionObservedIndicator",
    "correctiveActionCode",
    "airPollutantCode",
    "waterPollutantCode",
    "nationalPolicyGeneralAssistanceIndicator",
    "nationalPolicySiteSpecificAssistanceIndicator"
})
public class InspectionConclusionDataSheet
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "DeficienciesObservedIndicator")
    protected String deficienciesObservedIndicator;
    @XmlElement(name = "DeficiencyObservedCode")
    protected List<String> deficiencyObservedCode;
    @XmlElement(name = "DeficiencyCommunicatedFacilityIndicator")
    protected String deficiencyCommunicatedFacilityIndicator;
    @XmlElement(name = "FacilityActionObservedIndicator")
    protected String facilityActionObservedIndicator;
    @XmlElement(name = "CorrectiveActionCode", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected List<Integer> correctiveActionCode;
    @XmlElement(name = "AirPollutantCode", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected List<Integer> airPollutantCode;
    @XmlElement(name = "WaterPollutantCode", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected List<Integer> waterPollutantCode;
    @XmlElement(name = "NationalPolicyGeneralAssistanceIndicator")
    protected String nationalPolicyGeneralAssistanceIndicator;
    @XmlElement(name = "NationalPolicySiteSpecificAssistanceIndicator")
    protected String nationalPolicySiteSpecificAssistanceIndicator;

    /**
     * Gets the value of the deficienciesObservedIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDeficienciesObservedIndicator() {
        return deficienciesObservedIndicator;
    }

    /**
     * Sets the value of the deficienciesObservedIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDeficienciesObservedIndicator(String value) {
        this.deficienciesObservedIndicator = value;
    }

    public boolean isSetDeficienciesObservedIndicator() {
        return (this.deficienciesObservedIndicator!= null);
    }

    /**
     * Gets the value of the deficiencyObservedCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the deficiencyObservedCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getDeficiencyObservedCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<String> getDeficiencyObservedCode() {
        if (deficiencyObservedCode == null) {
            deficiencyObservedCode = new ArrayList<String>();
        }
        return this.deficiencyObservedCode;
    }

    /**
     * 
     * 
     */
    public void setDeficiencyObservedCode(List<String> deficiencyObservedCode) {
        this.deficiencyObservedCode = deficiencyObservedCode;
    }

    public boolean isSetDeficiencyObservedCode() {
        return ((this.deficiencyObservedCode!= null)&&(!this.deficiencyObservedCode.isEmpty()));
    }

    public void unsetDeficiencyObservedCode() {
        this.deficiencyObservedCode = null;
    }

    /**
     * Gets the value of the deficiencyCommunicatedFacilityIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDeficiencyCommunicatedFacilityIndicator() {
        return deficiencyCommunicatedFacilityIndicator;
    }

    /**
     * Sets the value of the deficiencyCommunicatedFacilityIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDeficiencyCommunicatedFacilityIndicator(String value) {
        this.deficiencyCommunicatedFacilityIndicator = value;
    }

    public boolean isSetDeficiencyCommunicatedFacilityIndicator() {
        return (this.deficiencyCommunicatedFacilityIndicator!= null);
    }

    /**
     * Gets the value of the facilityActionObservedIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getFacilityActionObservedIndicator() {
        return facilityActionObservedIndicator;
    }

    /**
     * Sets the value of the facilityActionObservedIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFacilityActionObservedIndicator(String value) {
        this.facilityActionObservedIndicator = value;
    }

    public boolean isSetFacilityActionObservedIndicator() {
        return (this.facilityActionObservedIndicator!= null);
    }

    /**
     * Gets the value of the correctiveActionCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the correctiveActionCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getCorrectiveActionCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<Integer> getCorrectiveActionCode() {
        if (correctiveActionCode == null) {
            correctiveActionCode = new ArrayList<Integer>();
        }
        return this.correctiveActionCode;
    }

    /**
     * 
     * 
     */
    public void setCorrectiveActionCode(List<Integer> correctiveActionCode) {
        this.correctiveActionCode = correctiveActionCode;
    }

    public boolean isSetCorrectiveActionCode() {
        return ((this.correctiveActionCode!= null)&&(!this.correctiveActionCode.isEmpty()));
    }

    public void unsetCorrectiveActionCode() {
        this.correctiveActionCode = null;
    }

    /**
     * Gets the value of the airPollutantCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the airPollutantCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getAirPollutantCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<Integer> getAirPollutantCode() {
        if (airPollutantCode == null) {
            airPollutantCode = new ArrayList<Integer>();
        }
        return this.airPollutantCode;
    }

    /**
     * 
     * 
     */
    public void setAirPollutantCode(List<Integer> airPollutantCode) {
        this.airPollutantCode = airPollutantCode;
    }

    public boolean isSetAirPollutantCode() {
        return ((this.airPollutantCode!= null)&&(!this.airPollutantCode.isEmpty()));
    }

    public void unsetAirPollutantCode() {
        this.airPollutantCode = null;
    }

    /**
     * Gets the value of the waterPollutantCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the waterPollutantCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getWaterPollutantCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<Integer> getWaterPollutantCode() {
        if (waterPollutantCode == null) {
            waterPollutantCode = new ArrayList<Integer>();
        }
        return this.waterPollutantCode;
    }

    /**
     * 
     * 
     */
    public void setWaterPollutantCode(List<Integer> waterPollutantCode) {
        this.waterPollutantCode = waterPollutantCode;
    }

    public boolean isSetWaterPollutantCode() {
        return ((this.waterPollutantCode!= null)&&(!this.waterPollutantCode.isEmpty()));
    }

    public void unsetWaterPollutantCode() {
        this.waterPollutantCode = null;
    }

    /**
     * Gets the value of the nationalPolicyGeneralAssistanceIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNationalPolicyGeneralAssistanceIndicator() {
        return nationalPolicyGeneralAssistanceIndicator;
    }

    /**
     * Sets the value of the nationalPolicyGeneralAssistanceIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNationalPolicyGeneralAssistanceIndicator(String value) {
        this.nationalPolicyGeneralAssistanceIndicator = value;
    }

    public boolean isSetNationalPolicyGeneralAssistanceIndicator() {
        return (this.nationalPolicyGeneralAssistanceIndicator!= null);
    }

    /**
     * Gets the value of the nationalPolicySiteSpecificAssistanceIndicator property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNationalPolicySiteSpecificAssistanceIndicator() {
        return nationalPolicySiteSpecificAssistanceIndicator;
    }

    /**
     * Sets the value of the nationalPolicySiteSpecificAssistanceIndicator property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNationalPolicySiteSpecificAssistanceIndicator(String value) {
        this.nationalPolicySiteSpecificAssistanceIndicator = value;
    }

    public boolean isSetNationalPolicySiteSpecificAssistanceIndicator() {
        return (this.nationalPolicySiteSpecificAssistanceIndicator!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof InspectionConclusionDataSheet)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final InspectionConclusionDataSheet that = ((InspectionConclusionDataSheet) object);
        {
            String lhsDeficienciesObservedIndicator;
            lhsDeficienciesObservedIndicator = this.getDeficienciesObservedIndicator();
            String rhsDeficienciesObservedIndicator;
            rhsDeficienciesObservedIndicator = that.getDeficienciesObservedIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "deficienciesObservedIndicator", lhsDeficienciesObservedIndicator), LocatorUtils.property(thatLocator, "deficienciesObservedIndicator", rhsDeficienciesObservedIndicator), lhsDeficienciesObservedIndicator, rhsDeficienciesObservedIndicator)) {
                return false;
            }
        }
        {
            List<String> lhsDeficiencyObservedCode;
            lhsDeficiencyObservedCode = (this.isSetDeficiencyObservedCode()?this.getDeficiencyObservedCode():null);
            List<String> rhsDeficiencyObservedCode;
            rhsDeficiencyObservedCode = (that.isSetDeficiencyObservedCode()?that.getDeficiencyObservedCode():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "deficiencyObservedCode", lhsDeficiencyObservedCode), LocatorUtils.property(thatLocator, "deficiencyObservedCode", rhsDeficiencyObservedCode), lhsDeficiencyObservedCode, rhsDeficiencyObservedCode)) {
                return false;
            }
        }
        {
            String lhsDeficiencyCommunicatedFacilityIndicator;
            lhsDeficiencyCommunicatedFacilityIndicator = this.getDeficiencyCommunicatedFacilityIndicator();
            String rhsDeficiencyCommunicatedFacilityIndicator;
            rhsDeficiencyCommunicatedFacilityIndicator = that.getDeficiencyCommunicatedFacilityIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "deficiencyCommunicatedFacilityIndicator", lhsDeficiencyCommunicatedFacilityIndicator), LocatorUtils.property(thatLocator, "deficiencyCommunicatedFacilityIndicator", rhsDeficiencyCommunicatedFacilityIndicator), lhsDeficiencyCommunicatedFacilityIndicator, rhsDeficiencyCommunicatedFacilityIndicator)) {
                return false;
            }
        }
        {
            String lhsFacilityActionObservedIndicator;
            lhsFacilityActionObservedIndicator = this.getFacilityActionObservedIndicator();
            String rhsFacilityActionObservedIndicator;
            rhsFacilityActionObservedIndicator = that.getFacilityActionObservedIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "facilityActionObservedIndicator", lhsFacilityActionObservedIndicator), LocatorUtils.property(thatLocator, "facilityActionObservedIndicator", rhsFacilityActionObservedIndicator), lhsFacilityActionObservedIndicator, rhsFacilityActionObservedIndicator)) {
                return false;
            }
        }
        {
            List<Integer> lhsCorrectiveActionCode;
            lhsCorrectiveActionCode = (this.isSetCorrectiveActionCode()?this.getCorrectiveActionCode():null);
            List<Integer> rhsCorrectiveActionCode;
            rhsCorrectiveActionCode = (that.isSetCorrectiveActionCode()?that.getCorrectiveActionCode():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "correctiveActionCode", lhsCorrectiveActionCode), LocatorUtils.property(thatLocator, "correctiveActionCode", rhsCorrectiveActionCode), lhsCorrectiveActionCode, rhsCorrectiveActionCode)) {
                return false;
            }
        }
        {
            List<Integer> lhsAirPollutantCode;
            lhsAirPollutantCode = (this.isSetAirPollutantCode()?this.getAirPollutantCode():null);
            List<Integer> rhsAirPollutantCode;
            rhsAirPollutantCode = (that.isSetAirPollutantCode()?that.getAirPollutantCode():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "airPollutantCode", lhsAirPollutantCode), LocatorUtils.property(thatLocator, "airPollutantCode", rhsAirPollutantCode), lhsAirPollutantCode, rhsAirPollutantCode)) {
                return false;
            }
        }
        {
            List<Integer> lhsWaterPollutantCode;
            lhsWaterPollutantCode = (this.isSetWaterPollutantCode()?this.getWaterPollutantCode():null);
            List<Integer> rhsWaterPollutantCode;
            rhsWaterPollutantCode = (that.isSetWaterPollutantCode()?that.getWaterPollutantCode():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "waterPollutantCode", lhsWaterPollutantCode), LocatorUtils.property(thatLocator, "waterPollutantCode", rhsWaterPollutantCode), lhsWaterPollutantCode, rhsWaterPollutantCode)) {
                return false;
            }
        }
        {
            String lhsNationalPolicyGeneralAssistanceIndicator;
            lhsNationalPolicyGeneralAssistanceIndicator = this.getNationalPolicyGeneralAssistanceIndicator();
            String rhsNationalPolicyGeneralAssistanceIndicator;
            rhsNationalPolicyGeneralAssistanceIndicator = that.getNationalPolicyGeneralAssistanceIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "nationalPolicyGeneralAssistanceIndicator", lhsNationalPolicyGeneralAssistanceIndicator), LocatorUtils.property(thatLocator, "nationalPolicyGeneralAssistanceIndicator", rhsNationalPolicyGeneralAssistanceIndicator), lhsNationalPolicyGeneralAssistanceIndicator, rhsNationalPolicyGeneralAssistanceIndicator)) {
                return false;
            }
        }
        {
            String lhsNationalPolicySiteSpecificAssistanceIndicator;
            lhsNationalPolicySiteSpecificAssistanceIndicator = this.getNationalPolicySiteSpecificAssistanceIndicator();
            String rhsNationalPolicySiteSpecificAssistanceIndicator;
            rhsNationalPolicySiteSpecificAssistanceIndicator = that.getNationalPolicySiteSpecificAssistanceIndicator();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "nationalPolicySiteSpecificAssistanceIndicator", lhsNationalPolicySiteSpecificAssistanceIndicator), LocatorUtils.property(thatLocator, "nationalPolicySiteSpecificAssistanceIndicator", rhsNationalPolicySiteSpecificAssistanceIndicator), lhsNationalPolicySiteSpecificAssistanceIndicator, rhsNationalPolicySiteSpecificAssistanceIndicator)) {
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
            String theDeficienciesObservedIndicator;
            theDeficienciesObservedIndicator = this.getDeficienciesObservedIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "deficienciesObservedIndicator", theDeficienciesObservedIndicator), currentHashCode, theDeficienciesObservedIndicator);
        }
        {
            List<String> theDeficiencyObservedCode;
            theDeficiencyObservedCode = (this.isSetDeficiencyObservedCode()?this.getDeficiencyObservedCode():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "deficiencyObservedCode", theDeficiencyObservedCode), currentHashCode, theDeficiencyObservedCode);
        }
        {
            String theDeficiencyCommunicatedFacilityIndicator;
            theDeficiencyCommunicatedFacilityIndicator = this.getDeficiencyCommunicatedFacilityIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "deficiencyCommunicatedFacilityIndicator", theDeficiencyCommunicatedFacilityIndicator), currentHashCode, theDeficiencyCommunicatedFacilityIndicator);
        }
        {
            String theFacilityActionObservedIndicator;
            theFacilityActionObservedIndicator = this.getFacilityActionObservedIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "facilityActionObservedIndicator", theFacilityActionObservedIndicator), currentHashCode, theFacilityActionObservedIndicator);
        }
        {
            List<Integer> theCorrectiveActionCode;
            theCorrectiveActionCode = (this.isSetCorrectiveActionCode()?this.getCorrectiveActionCode():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "correctiveActionCode", theCorrectiveActionCode), currentHashCode, theCorrectiveActionCode);
        }
        {
            List<Integer> theAirPollutantCode;
            theAirPollutantCode = (this.isSetAirPollutantCode()?this.getAirPollutantCode():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "airPollutantCode", theAirPollutantCode), currentHashCode, theAirPollutantCode);
        }
        {
            List<Integer> theWaterPollutantCode;
            theWaterPollutantCode = (this.isSetWaterPollutantCode()?this.getWaterPollutantCode():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "waterPollutantCode", theWaterPollutantCode), currentHashCode, theWaterPollutantCode);
        }
        {
            String theNationalPolicyGeneralAssistanceIndicator;
            theNationalPolicyGeneralAssistanceIndicator = this.getNationalPolicyGeneralAssistanceIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "nationalPolicyGeneralAssistanceIndicator", theNationalPolicyGeneralAssistanceIndicator), currentHashCode, theNationalPolicyGeneralAssistanceIndicator);
        }
        {
            String theNationalPolicySiteSpecificAssistanceIndicator;
            theNationalPolicySiteSpecificAssistanceIndicator = this.getNationalPolicySiteSpecificAssistanceIndicator();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "nationalPolicySiteSpecificAssistanceIndicator", theNationalPolicySiteSpecificAssistanceIndicator), currentHashCode, theNationalPolicySiteSpecificAssistanceIndicator);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

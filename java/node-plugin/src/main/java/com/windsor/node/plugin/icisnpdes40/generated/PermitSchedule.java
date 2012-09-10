//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
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
 * <p>Java class for PermitSchedule complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="PermitSchedule">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NarrativeConditionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleComments" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}PermitScheduleEvent" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "PermitSchedule", propOrder = {
    "narrativeConditionCode",
    "permitScheduleComments",
    "permitScheduleEvent"
})
public class PermitSchedule
    extends PermitScheduleKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "NarrativeConditionCode")
    protected String narrativeConditionCode;
    @XmlElement(name = "PermitScheduleComments")
    protected String permitScheduleComments;
    @XmlElement(name = "PermitScheduleEvent")
    protected List<PermitScheduleEvent> permitScheduleEvent;

    /**
     * Gets the value of the narrativeConditionCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNarrativeConditionCode() {
        return narrativeConditionCode;
    }

    /**
     * Sets the value of the narrativeConditionCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNarrativeConditionCode(String value) {
        this.narrativeConditionCode = value;
    }

    public boolean isSetNarrativeConditionCode() {
        return (this.narrativeConditionCode!= null);
    }

    /**
     * Gets the value of the permitScheduleComments property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPermitScheduleComments() {
        return permitScheduleComments;
    }

    /**
     * Sets the value of the permitScheduleComments property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitScheduleComments(String value) {
        this.permitScheduleComments = value;
    }

    public boolean isSetPermitScheduleComments() {
        return (this.permitScheduleComments!= null);
    }

    /**
     * Gets the value of the permitScheduleEvent property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the permitScheduleEvent property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getPermitScheduleEvent().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link PermitScheduleEvent }
     * 
     * 
     */
    public List<PermitScheduleEvent> getPermitScheduleEvent() {
        if (permitScheduleEvent == null) {
            permitScheduleEvent = new ArrayList<PermitScheduleEvent>();
        }
        return this.permitScheduleEvent;
    }

    /**
     * 
     * 
     */
    public void setPermitScheduleEvent(List<PermitScheduleEvent> permitScheduleEvent) {
        this.permitScheduleEvent = permitScheduleEvent;
    }

    public boolean isSetPermitScheduleEvent() {
        return ((this.permitScheduleEvent!= null)&&(!this.permitScheduleEvent.isEmpty()));
    }

    public void unsetPermitScheduleEvent() {
        this.permitScheduleEvent = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof PermitSchedule)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final PermitSchedule that = ((PermitSchedule) object);
        {
            String lhsNarrativeConditionCode;
            lhsNarrativeConditionCode = this.getNarrativeConditionCode();
            String rhsNarrativeConditionCode;
            rhsNarrativeConditionCode = that.getNarrativeConditionCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "narrativeConditionCode", lhsNarrativeConditionCode), LocatorUtils.property(thatLocator, "narrativeConditionCode", rhsNarrativeConditionCode), lhsNarrativeConditionCode, rhsNarrativeConditionCode)) {
                return false;
            }
        }
        {
            String lhsPermitScheduleComments;
            lhsPermitScheduleComments = this.getPermitScheduleComments();
            String rhsPermitScheduleComments;
            rhsPermitScheduleComments = that.getPermitScheduleComments();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitScheduleComments", lhsPermitScheduleComments), LocatorUtils.property(thatLocator, "permitScheduleComments", rhsPermitScheduleComments), lhsPermitScheduleComments, rhsPermitScheduleComments)) {
                return false;
            }
        }
        {
            List<PermitScheduleEvent> lhsPermitScheduleEvent;
            lhsPermitScheduleEvent = (this.isSetPermitScheduleEvent()?this.getPermitScheduleEvent():null);
            List<PermitScheduleEvent> rhsPermitScheduleEvent;
            rhsPermitScheduleEvent = (that.isSetPermitScheduleEvent()?that.getPermitScheduleEvent():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitScheduleEvent", lhsPermitScheduleEvent), LocatorUtils.property(thatLocator, "permitScheduleEvent", rhsPermitScheduleEvent), lhsPermitScheduleEvent, rhsPermitScheduleEvent)) {
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
            String theNarrativeConditionCode;
            theNarrativeConditionCode = this.getNarrativeConditionCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "narrativeConditionCode", theNarrativeConditionCode), currentHashCode, theNarrativeConditionCode);
        }
        {
            String thePermitScheduleComments;
            thePermitScheduleComments = this.getPermitScheduleComments();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitScheduleComments", thePermitScheduleComments), currentHashCode, thePermitScheduleComments);
        }
        {
            List<PermitScheduleEvent> thePermitScheduleEvent;
            thePermitScheduleEvent = (this.isSetPermitScheduleEvent()?this.getPermitScheduleEvent():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitScheduleEvent", thePermitScheduleEvent), currentHashCode, thePermitScheduleEvent);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

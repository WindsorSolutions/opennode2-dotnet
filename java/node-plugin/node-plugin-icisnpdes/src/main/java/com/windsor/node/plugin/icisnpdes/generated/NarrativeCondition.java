//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.12.07 at 11:39:25 AM EST 
//


package com.windsor.node.plugin.icisnpdes.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.Transient;
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
 * <p>Java class for NarrativeCondition complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="NarrativeCondition">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/5}PermitScheduleKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}NarrativeConditionCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}Comments" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}PermitScheduleEvent" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "NarrativeCondition", propOrder = {
    "narrativeConditionCode",
    "comments",
    "permitScheduleEvent"
})
@Embeddable
public class NarrativeCondition
    extends PermitScheduleKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "NarrativeConditionCode")
    protected String narrativeConditionCode;
    @XmlElement(name = "Comments")
    protected String comments;
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
    @Basic
    @Column(name = "NARR_COND_CODE", columnDefinition = "char(3)", length = 3)
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

    @Transient
    public boolean isSetNarrativeConditionCode() {
        return (this.narrativeConditionCode!= null);
    }

    /**
     * Gets the value of the comments property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CMNTS", columnDefinition = "varchar(4000)", length = 4000)
    public String getComments() {
        return comments;
    }

    /**
     * Sets the value of the comments property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setComments(String value) {
        this.comments = value;
    }

    @Transient
    public boolean isSetComments() {
        return (this.comments!= null);
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
    @OneToMany(targetEntity = PermitScheduleEvent.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_NARR_COND_ID")
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

    @Transient
    public boolean isSetPermitScheduleEvent() {
        return ((this.permitScheduleEvent!= null)&&(!this.permitScheduleEvent.isEmpty()));
    }

    public void unsetPermitScheduleEvent() {
        this.permitScheduleEvent = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof NarrativeCondition)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final NarrativeCondition that = ((NarrativeCondition) object);
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
            String lhsComments;
            lhsComments = this.getComments();
            String rhsComments;
            rhsComments = that.getComments();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "comments", lhsComments), LocatorUtils.property(thatLocator, "comments", rhsComments), lhsComments, rhsComments)) {
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
            String theComments;
            theComments = this.getComments();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "comments", theComments), currentHashCode, theComments);
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
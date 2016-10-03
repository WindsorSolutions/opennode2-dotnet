//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

import java.util.ArrayList;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
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
 * Facility corrective action submission.
 * 
 * <p>Java class for CorrectiveActionFacilitySubmissionDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="CorrectiveActionFacilitySubmissionDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}HandlerID"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CorrectiveActionArea" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CorrectiveActionAuthority" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}CorrectiveActionEvent" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "CorrectiveActionFacilitySubmissionDataType", propOrder = {
    "handlerID",
    "correctiveActionArea",
    "correctiveActionAuthority",
    "correctiveActionEvent"
})
@Entity(name = "CorrectiveActionFacilitySubmissionDataType")
@Table(name = "RCRA_CORRACTFACSUB")
@Inheritance(strategy = InheritanceType.JOINED)
public class CorrectiveActionFacilitySubmissionDataType
    implements Equals, HashCode
{

    @XmlElement(name = "HandlerID", required = true)
    protected String handlerID;
    @XmlElement(name = "CorrectiveActionArea")
    protected List<CorrectiveActionAreaDataType> correctiveActionArea;
    @XmlElement(name = "CorrectiveActionAuthority")
    protected List<CorrectiveActionAuthorityDataType> correctiveActionAuthority;
    @XmlElement(name = "CorrectiveActionEvent")
    protected List<CorrectiveActionEventDataType> correctiveActionEvent;
    @XmlAttribute(name = "Id")
    protected Long id;

    /**
     * Gets the value of the handlerID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "HANDLERID", length = 12)
    public String getHandlerID() {
        return handlerID;
    }

    /**
     * Sets the value of the handlerID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setHandlerID(String value) {
        this.handlerID = value;
    }

    /**
     * Gets the value of the correctiveActionArea property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the correctiveActionArea property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getCorrectiveActionArea().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link CorrectiveActionAreaDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = CorrectiveActionAreaDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "CORRACTFACSUBID")
    public List<CorrectiveActionAreaDataType> getCorrectiveActionArea() {
        if (correctiveActionArea == null) {
            correctiveActionArea = new ArrayList<CorrectiveActionAreaDataType>();
        }
        return this.correctiveActionArea;
    }

    /**
     * 
     * 
     */
    public void setCorrectiveActionArea(List<CorrectiveActionAreaDataType> correctiveActionArea) {
        this.correctiveActionArea = correctiveActionArea;
    }

    /**
     * Gets the value of the correctiveActionAuthority property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the correctiveActionAuthority property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getCorrectiveActionAuthority().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link CorrectiveActionAuthorityDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = CorrectiveActionAuthorityDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "CORRACTFACSUBID")
    public List<CorrectiveActionAuthorityDataType> getCorrectiveActionAuthority() {
        if (correctiveActionAuthority == null) {
            correctiveActionAuthority = new ArrayList<CorrectiveActionAuthorityDataType>();
        }
        return this.correctiveActionAuthority;
    }

    /**
     * 
     * 
     */
    public void setCorrectiveActionAuthority(List<CorrectiveActionAuthorityDataType> correctiveActionAuthority) {
        this.correctiveActionAuthority = correctiveActionAuthority;
    }

    /**
     * Gets the value of the correctiveActionEvent property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the correctiveActionEvent property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getCorrectiveActionEvent().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link CorrectiveActionEventDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = CorrectiveActionEventDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "CORRACTFACSUBID")
    public List<CorrectiveActionEventDataType> getCorrectiveActionEvent() {
        if (correctiveActionEvent == null) {
            correctiveActionEvent = new ArrayList<CorrectiveActionEventDataType>();
        }
        return this.correctiveActionEvent;
    }

    /**
     * 
     * 
     */
    public void setCorrectiveActionEvent(List<CorrectiveActionEventDataType> correctiveActionEvent) {
        this.correctiveActionEvent = correctiveActionEvent;
    }

    /**
     * Gets the value of the id property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    @Id
    @Column(name = "ID")
    @GeneratedValue(generator = "ColSequence", strategy = GenerationType.AUTO)
    @SequenceGenerator(name = "ColSequence", sequenceName = "COLUMN_ID_SEQUENCE", allocationSize = 1)
    public Long getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setId(Long value) {
        this.id = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof CorrectiveActionFacilitySubmissionDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final CorrectiveActionFacilitySubmissionDataType that = ((CorrectiveActionFacilitySubmissionDataType) object);
        {
            String lhsHandlerID;
            lhsHandlerID = this.getHandlerID();
            String rhsHandlerID;
            rhsHandlerID = that.getHandlerID();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "handlerID", lhsHandlerID), LocatorUtils.property(thatLocator, "handlerID", rhsHandlerID), lhsHandlerID, rhsHandlerID)) {
                return false;
            }
        }
        {
            List<CorrectiveActionAreaDataType> lhsCorrectiveActionArea;
            lhsCorrectiveActionArea = (((this.correctiveActionArea!= null)&&(!this.correctiveActionArea.isEmpty()))?this.getCorrectiveActionArea():null);
            List<CorrectiveActionAreaDataType> rhsCorrectiveActionArea;
            rhsCorrectiveActionArea = (((that.correctiveActionArea!= null)&&(!that.correctiveActionArea.isEmpty()))?that.getCorrectiveActionArea():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "correctiveActionArea", lhsCorrectiveActionArea), LocatorUtils.property(thatLocator, "correctiveActionArea", rhsCorrectiveActionArea), lhsCorrectiveActionArea, rhsCorrectiveActionArea)) {
                return false;
            }
        }
        {
            List<CorrectiveActionAuthorityDataType> lhsCorrectiveActionAuthority;
            lhsCorrectiveActionAuthority = (((this.correctiveActionAuthority!= null)&&(!this.correctiveActionAuthority.isEmpty()))?this.getCorrectiveActionAuthority():null);
            List<CorrectiveActionAuthorityDataType> rhsCorrectiveActionAuthority;
            rhsCorrectiveActionAuthority = (((that.correctiveActionAuthority!= null)&&(!that.correctiveActionAuthority.isEmpty()))?that.getCorrectiveActionAuthority():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "correctiveActionAuthority", lhsCorrectiveActionAuthority), LocatorUtils.property(thatLocator, "correctiveActionAuthority", rhsCorrectiveActionAuthority), lhsCorrectiveActionAuthority, rhsCorrectiveActionAuthority)) {
                return false;
            }
        }
        {
            List<CorrectiveActionEventDataType> lhsCorrectiveActionEvent;
            lhsCorrectiveActionEvent = (((this.correctiveActionEvent!= null)&&(!this.correctiveActionEvent.isEmpty()))?this.getCorrectiveActionEvent():null);
            List<CorrectiveActionEventDataType> rhsCorrectiveActionEvent;
            rhsCorrectiveActionEvent = (((that.correctiveActionEvent!= null)&&(!that.correctiveActionEvent.isEmpty()))?that.getCorrectiveActionEvent():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "correctiveActionEvent", lhsCorrectiveActionEvent), LocatorUtils.property(thatLocator, "correctiveActionEvent", rhsCorrectiveActionEvent), lhsCorrectiveActionEvent, rhsCorrectiveActionEvent)) {
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
            String theHandlerID;
            theHandlerID = this.getHandlerID();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "handlerID", theHandlerID), currentHashCode, theHandlerID);
        }
        {
            List<CorrectiveActionAreaDataType> theCorrectiveActionArea;
            theCorrectiveActionArea = (((this.correctiveActionArea!= null)&&(!this.correctiveActionArea.isEmpty()))?this.getCorrectiveActionArea():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "correctiveActionArea", theCorrectiveActionArea), currentHashCode, theCorrectiveActionArea);
        }
        {
            List<CorrectiveActionAuthorityDataType> theCorrectiveActionAuthority;
            theCorrectiveActionAuthority = (((this.correctiveActionAuthority!= null)&&(!this.correctiveActionAuthority.isEmpty()))?this.getCorrectiveActionAuthority():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "correctiveActionAuthority", theCorrectiveActionAuthority), currentHashCode, theCorrectiveActionAuthority);
        }
        {
            List<CorrectiveActionEventDataType> theCorrectiveActionEvent;
            theCorrectiveActionEvent = (((this.correctiveActionEvent!= null)&&(!this.correctiveActionEvent.isEmpty()))?this.getCorrectiveActionEvent():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "correctiveActionEvent", theCorrectiveActionEvent), currentHashCode, theCorrectiveActionEvent);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

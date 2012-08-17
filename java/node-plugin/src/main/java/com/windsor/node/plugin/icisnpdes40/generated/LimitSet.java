//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a>
// Any modifications to this file will be lost upon recompilation of the source schema.
// Generated on: 2012.08.17 at 12:13:56 PM PDT
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.CollectionTable;
import javax.persistence.Column;
import javax.persistence.ElementCollection;
import javax.persistence.Embeddable;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.OrderColumn;
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

import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;


/**
 * <p>Java class for LimitSet complex type.
 *
 * <p>The following schema fragment specifies the expected content contained within this class.
 *
 * <pre>
 * &lt;complexType name="LimitSet">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}LimitSetKeyElements">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}LimitSetGroup" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LimitSetSchedule" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 *
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LimitSet", propOrder = {
    "limitSetType",
    "limitSetNameText",
    "dmrPrePrintCommentsText",
    "agencyReviewer",
    "limitSetUserDefinedDataElement1Text",
    "limitSetUserDefinedDataElement2Text",
    "limitSetMonthsApplicable",
    "limitSetStatus",
    "limitSetSchedule"
})
@Embeddable
public class LimitSet
    extends LimitSetKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "LimitSetType")
    protected LimitSetType limitSetType;
    @XmlElement(name = "LimitSetNameText")
    protected String limitSetNameText;
    @XmlElement(name = "DMRPrePrintCommentsText")
    protected String dmrPrePrintCommentsText;
    @XmlElement(name = "AgencyReviewer")
    protected String agencyReviewer;
    @XmlElement(name = "LimitSetUserDefinedDataElement1Text", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer limitSetUserDefinedDataElement1Text;
    @XmlElement(name = "LimitSetUserDefinedDataElement2Text")
    protected String limitSetUserDefinedDataElement2Text;
    @XmlElement(name = "LimitSetMonthsApplicable")
    protected List<MonthTextType> limitSetMonthsApplicable;
    @XmlElement(name = "LimitSetStatus")
    protected LimitSetStatus limitSetStatus;
    @XmlElement(name = "LimitSetSchedule")
    protected List<LimitSetSchedule> limitSetSchedule;

    /**
     * Gets the value of the limitSetType property.
     *
     * @return
     *     possible object is
     *     {@link LimitSetType }
     *
     */
    @Basic
    @Column(name = "LMT_SET_TYPE", columnDefinition = "char(1)", length = 1)
    @Enumerated(EnumType.STRING)
    public LimitSetType getLimitSetType() {
        return limitSetType;
    }

    /**
     * Sets the value of the limitSetType property.
     *
     * @param value
     *     allowed object is
     *     {@link LimitSetType }
     *
     */
    public void setLimitSetType(final LimitSetType value) {
        this.limitSetType = value;
    }

    @Transient
    public boolean isSetLimitSetType() {
        return (this.limitSetType!= null);
    }

    /**
     * Gets the value of the limitSetNameText property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "LMT_SET_NAME_TXT", length = 100)
    public String getLimitSetNameText() {
        return limitSetNameText;
    }

    /**
     * Sets the value of the limitSetNameText property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setLimitSetNameText(final String value) {
        this.limitSetNameText = value;
    }

    @Transient
    public boolean isSetLimitSetNameText() {
        return (this.limitSetNameText!= null);
    }

    /**
     * Gets the value of the dmrPrePrintCommentsText property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "DMR_PRE_PRINT_CMNTS_TXT", length = 315)
    public String getDMRPrePrintCommentsText() {
        return dmrPrePrintCommentsText;
    }

    /**
     * Sets the value of the dmrPrePrintCommentsText property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setDMRPrePrintCommentsText(final String value) {
        this.dmrPrePrintCommentsText = value;
    }

    @Transient
    public boolean isSetDMRPrePrintCommentsText() {
        return (this.dmrPrePrintCommentsText!= null);
    }

    /**
     * Gets the value of the agencyReviewer property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "AGNCY_REVIEWER", length = 5)
    public String getAgencyReviewer() {
        return agencyReviewer;
    }

    /**
     * Sets the value of the agencyReviewer property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setAgencyReviewer(final String value) {
        this.agencyReviewer = value;
    }

    @Transient
    public boolean isSetAgencyReviewer() {
        return (this.agencyReviewer!= null);
    }

    /**
     * Gets the value of the limitSetUserDefinedDataElement1Text property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "LMT_SET_USR_DFND_DAT_ELM_1_TXT", scale = 0)
    public Integer getLimitSetUserDefinedDataElement1Text() {
        return limitSetUserDefinedDataElement1Text;
    }

    /**
     * Sets the value of the limitSetUserDefinedDataElement1Text property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setLimitSetUserDefinedDataElement1Text(final Integer value) {
        this.limitSetUserDefinedDataElement1Text = value;
    }

    @Transient
    public boolean isSetLimitSetUserDefinedDataElement1Text() {
        return (this.limitSetUserDefinedDataElement1Text!= null);
    }

    /**
     * Gets the value of the limitSetUserDefinedDataElement2Text property.
     *
     * @return
     *     possible object is
     *     {@link String }
     *
     */
    @Basic
    @Column(name = "LMT_SET_USR_DFND_DAT_ELM_2_TXT", length = 150)
    public String getLimitSetUserDefinedDataElement2Text() {
        return limitSetUserDefinedDataElement2Text;
    }

    /**
     * Sets the value of the limitSetUserDefinedDataElement2Text property.
     *
     * @param value
     *     allowed object is
     *     {@link String }
     *
     */
    public void setLimitSetUserDefinedDataElement2Text(final String value) {
        this.limitSetUserDefinedDataElement2Text = value;
    }

    @Transient
    public boolean isSetLimitSetUserDefinedDataElement2Text() {
        return (this.limitSetUserDefinedDataElement2Text!= null);
    }

    /**
     * Gets the value of the limitSetMonthsApplicable property.
     *
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the limitSetMonthsApplicable property.
     *
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getLimitSetMonthsApplicable().add(newItem);
     * </pre>
     *
     *
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link MonthTextType }
     *
     *
     */
    @ElementCollection
    @OrderColumn(name = "DATA_HASH")
    @Column(name = "LMT_SET_MONTHS_APPL", length = 255)
    @Enumerated(EnumType.STRING)
    @CollectionTable(name = "ICS_LMT_SET_MONTHS_APPL", joinColumns = @JoinColumn(name = "ICS_LMT_SET_ID"))
    // FIXME: add joinColumns = @JoinColumn(name = "ICS_LMT_SET_ID") to the
 	// @CollectionTable annotation
    public List<MonthTextType> getLimitSetMonthsApplicable() {
        if (limitSetMonthsApplicable == null) {
            limitSetMonthsApplicable = new ArrayList<MonthTextType>();
        }
        return this.limitSetMonthsApplicable;
    }

    /**
     *
     *
     */
    public void setLimitSetMonthsApplicable(final List<MonthTextType> limitSetMonthsApplicable) {
        this.limitSetMonthsApplicable = limitSetMonthsApplicable;
    }

    @Transient
    public boolean isSetLimitSetMonthsApplicable() {
        return ((this.limitSetMonthsApplicable!= null)&&(!this.limitSetMonthsApplicable.isEmpty()));
    }

    public void unsetLimitSetMonthsApplicable() {
        this.limitSetMonthsApplicable = null;
    }

    /**
     * Gets the value of the limitSetStatus property.
     *
     * @return
     *     possible object is
     *     {@link LimitSetStatus }
     *
     */
    @JoinColumn(name = "dummy")
    @OneToOne(targetEntity = LimitSetStatus.class, cascade = {
        CascadeType.ALL
    })
    public LimitSetStatus getLimitSetStatus() {
        return limitSetStatus;
    }

    /**
     * Sets the value of the limitSetStatus property.
     *
     * @param value
     *     allowed object is
     *     {@link LimitSetStatus }
     *
     */
    public void setLimitSetStatus(final LimitSetStatus value) {
        this.limitSetStatus = value;
    }

    @Transient
    public boolean isSetLimitSetStatus() {
        return (this.limitSetStatus!= null);
    }

    /**
     * Gets the value of the limitSetSchedule property.
     *
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the limitSetSchedule property.
     *
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getLimitSetSchedule().add(newItem);
     * </pre>
     *
     *
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link LimitSetSchedule }
     *
     *
     */
    @JoinColumn(name = "dummy")
    @OneToMany(targetEntity = LimitSetSchedule.class, cascade = {
        CascadeType.ALL
    })
    public List<LimitSetSchedule> getLimitSetSchedule() {
        if (limitSetSchedule == null) {
            limitSetSchedule = new ArrayList<LimitSetSchedule>();
        }
        return this.limitSetSchedule;
    }

    /**
     *
     *
     */
    public void setLimitSetSchedule(final List<LimitSetSchedule> limitSetSchedule) {
        this.limitSetSchedule = limitSetSchedule;
    }

    @Transient
    public boolean isSetLimitSetSchedule() {
        return ((this.limitSetSchedule!= null)&&(!this.limitSetSchedule.isEmpty()));
    }

    public void unsetLimitSetSchedule() {
        this.limitSetSchedule = null;
    }

    @Override
	public boolean equals(final ObjectLocator thisLocator, final ObjectLocator thatLocator, final Object object, final EqualsStrategy strategy) {
        if (!(object instanceof LimitSet)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final LimitSet that = ((LimitSet) object);
        {
            LimitSetType lhsLimitSetType;
            lhsLimitSetType = this.getLimitSetType();
            LimitSetType rhsLimitSetType;
            rhsLimitSetType = that.getLimitSetType();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetType", lhsLimitSetType), LocatorUtils.property(thatLocator, "limitSetType", rhsLimitSetType), lhsLimitSetType, rhsLimitSetType)) {
                return false;
            }
        }
        {
            String lhsLimitSetNameText;
            lhsLimitSetNameText = this.getLimitSetNameText();
            String rhsLimitSetNameText;
            rhsLimitSetNameText = that.getLimitSetNameText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetNameText", lhsLimitSetNameText), LocatorUtils.property(thatLocator, "limitSetNameText", rhsLimitSetNameText), lhsLimitSetNameText, rhsLimitSetNameText)) {
                return false;
            }
        }
        {
            String lhsDMRPrePrintCommentsText;
            lhsDMRPrePrintCommentsText = this.getDMRPrePrintCommentsText();
            String rhsDMRPrePrintCommentsText;
            rhsDMRPrePrintCommentsText = that.getDMRPrePrintCommentsText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "dmrPrePrintCommentsText", lhsDMRPrePrintCommentsText), LocatorUtils.property(thatLocator, "dmrPrePrintCommentsText", rhsDMRPrePrintCommentsText), lhsDMRPrePrintCommentsText, rhsDMRPrePrintCommentsText)) {
                return false;
            }
        }
        {
            String lhsAgencyReviewer;
            lhsAgencyReviewer = this.getAgencyReviewer();
            String rhsAgencyReviewer;
            rhsAgencyReviewer = that.getAgencyReviewer();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "agencyReviewer", lhsAgencyReviewer), LocatorUtils.property(thatLocator, "agencyReviewer", rhsAgencyReviewer), lhsAgencyReviewer, rhsAgencyReviewer)) {
                return false;
            }
        }
        {
            Integer lhsLimitSetUserDefinedDataElement1Text;
            lhsLimitSetUserDefinedDataElement1Text = this.getLimitSetUserDefinedDataElement1Text();
            Integer rhsLimitSetUserDefinedDataElement1Text;
            rhsLimitSetUserDefinedDataElement1Text = that.getLimitSetUserDefinedDataElement1Text();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetUserDefinedDataElement1Text", lhsLimitSetUserDefinedDataElement1Text), LocatorUtils.property(thatLocator, "limitSetUserDefinedDataElement1Text", rhsLimitSetUserDefinedDataElement1Text), lhsLimitSetUserDefinedDataElement1Text, rhsLimitSetUserDefinedDataElement1Text)) {
                return false;
            }
        }
        {
            String lhsLimitSetUserDefinedDataElement2Text;
            lhsLimitSetUserDefinedDataElement2Text = this.getLimitSetUserDefinedDataElement2Text();
            String rhsLimitSetUserDefinedDataElement2Text;
            rhsLimitSetUserDefinedDataElement2Text = that.getLimitSetUserDefinedDataElement2Text();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetUserDefinedDataElement2Text", lhsLimitSetUserDefinedDataElement2Text), LocatorUtils.property(thatLocator, "limitSetUserDefinedDataElement2Text", rhsLimitSetUserDefinedDataElement2Text), lhsLimitSetUserDefinedDataElement2Text, rhsLimitSetUserDefinedDataElement2Text)) {
                return false;
            }
        }
        {
            List<MonthTextType> lhsLimitSetMonthsApplicable;
            lhsLimitSetMonthsApplicable = (this.isSetLimitSetMonthsApplicable()?this.getLimitSetMonthsApplicable():null);
            List<MonthTextType> rhsLimitSetMonthsApplicable;
            rhsLimitSetMonthsApplicable = (that.isSetLimitSetMonthsApplicable()?that.getLimitSetMonthsApplicable():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetMonthsApplicable", lhsLimitSetMonthsApplicable), LocatorUtils.property(thatLocator, "limitSetMonthsApplicable", rhsLimitSetMonthsApplicable), lhsLimitSetMonthsApplicable, rhsLimitSetMonthsApplicable)) {
                return false;
            }
        }
        {
            LimitSetStatus lhsLimitSetStatus;
            lhsLimitSetStatus = this.getLimitSetStatus();
            LimitSetStatus rhsLimitSetStatus;
            rhsLimitSetStatus = that.getLimitSetStatus();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetStatus", lhsLimitSetStatus), LocatorUtils.property(thatLocator, "limitSetStatus", rhsLimitSetStatus), lhsLimitSetStatus, rhsLimitSetStatus)) {
                return false;
            }
        }
        {
            List<LimitSetSchedule> lhsLimitSetSchedule;
            lhsLimitSetSchedule = (this.isSetLimitSetSchedule()?this.getLimitSetSchedule():null);
            List<LimitSetSchedule> rhsLimitSetSchedule;
            rhsLimitSetSchedule = (that.isSetLimitSetSchedule()?that.getLimitSetSchedule():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "limitSetSchedule", lhsLimitSetSchedule), LocatorUtils.property(thatLocator, "limitSetSchedule", rhsLimitSetSchedule), lhsLimitSetSchedule, rhsLimitSetSchedule)) {
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
            LimitSetType theLimitSetType;
            theLimitSetType = this.getLimitSetType();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetType", theLimitSetType), currentHashCode, theLimitSetType);
        }
        {
            String theLimitSetNameText;
            theLimitSetNameText = this.getLimitSetNameText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetNameText", theLimitSetNameText), currentHashCode, theLimitSetNameText);
        }
        {
            String theDMRPrePrintCommentsText;
            theDMRPrePrintCommentsText = this.getDMRPrePrintCommentsText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "dmrPrePrintCommentsText", theDMRPrePrintCommentsText), currentHashCode, theDMRPrePrintCommentsText);
        }
        {
            String theAgencyReviewer;
            theAgencyReviewer = this.getAgencyReviewer();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "agencyReviewer", theAgencyReviewer), currentHashCode, theAgencyReviewer);
        }
        {
            Integer theLimitSetUserDefinedDataElement1Text;
            theLimitSetUserDefinedDataElement1Text = this.getLimitSetUserDefinedDataElement1Text();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetUserDefinedDataElement1Text", theLimitSetUserDefinedDataElement1Text), currentHashCode, theLimitSetUserDefinedDataElement1Text);
        }
        {
            String theLimitSetUserDefinedDataElement2Text;
            theLimitSetUserDefinedDataElement2Text = this.getLimitSetUserDefinedDataElement2Text();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetUserDefinedDataElement2Text", theLimitSetUserDefinedDataElement2Text), currentHashCode, theLimitSetUserDefinedDataElement2Text);
        }
        {
            List<MonthTextType> theLimitSetMonthsApplicable;
            theLimitSetMonthsApplicable = (this.isSetLimitSetMonthsApplicable()?this.getLimitSetMonthsApplicable():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetMonthsApplicable", theLimitSetMonthsApplicable), currentHashCode, theLimitSetMonthsApplicable);
        }
        {
            LimitSetStatus theLimitSetStatus;
            theLimitSetStatus = this.getLimitSetStatus();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetStatus", theLimitSetStatus), currentHashCode, theLimitSetStatus);
        }
        {
            List<LimitSetSchedule> theLimitSetSchedule;
            theLimitSetSchedule = (this.isSetLimitSetSchedule()?this.getLimitSetSchedule():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "limitSetSchedule", theLimitSetSchedule), currentHashCode, theLimitSetSchedule);
        }
        return currentHashCode;
    }

    @Override
	public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

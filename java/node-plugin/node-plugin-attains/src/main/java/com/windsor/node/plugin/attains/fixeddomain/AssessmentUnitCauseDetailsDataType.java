//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.5-2 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2013.04.10 at 11:16:50 AM PDT 
//


package com.windsor.node.plugin.attains.fixeddomain;

import java.io.Serializable;
import java.util.Date;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import javax.xml.datatype.XMLGregorianCalendar;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.GYearToIntegerAdapter;
import com.windsor.node.plugin.common.xml.bind.annotation.adapters.StringAdapter;
import org.jvnet.hyperjaxb3.xml.bind.annotation.adapters.XMLGregorianCalendarAsDate;
import org.jvnet.hyperjaxb3.xml.bind.annotation.adapters.XmlAdapterUtils;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for AssessmentUnitCauseDetailsDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="AssessmentUnitCauseDetailsDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}CauseName"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}CycleFirstListed" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}ExpectedToAttainDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLSchedule" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLPriority" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLCompletionDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLProjectStatus" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLProjectComment" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}ImplementationActions" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}ConsentDecreeCycle" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}PollutionSourceType" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}JustificationURL" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}OtherPointSourceID" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}TMDLs" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/OWIR/ATT/2}NPDES" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "AssessmentUnitCauseDetailsDataType", propOrder = {
    "causeName",
    "cycleFirstListed",
    "expectedToAttainDate",
    "tmdlSchedule",
    "tmdlPriority",
    "tmdlCompletionDate",
    "tmdlProjectStatus",
    "tmdlProjectComment",
    "implementationActions",
    "consentDecreeCycle",
    "pollutionSourceType",
    "justificationURL",
    "otherPointSourceID",
    "tmdLs",
    "npdes"
})
@Entity(name = "AssessmentUnitCauseDetailsDataType")
@Table(name = "OWIR_ASMT_UNIT_CAUSE_DTLS")
@Inheritance(strategy = InheritanceType.JOINED)
public class AssessmentUnitCauseDetailsDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "CauseName", required = true)
    protected String causeName;
    @XmlElement(name = "CycleFirstListed", type = String.class)
    @XmlJavaTypeAdapter(GYearToIntegerAdapter.class)
    @XmlSchemaType(name = "gYear")
    protected Integer cycleFirstListed;
    @XmlElement(name = "ExpectedToAttainDate")
    @XmlSchemaType(name = "date")
    protected XMLGregorianCalendar expectedToAttainDate;
    @XmlElement(name = "TMDLSchedule", type = String.class)
    @XmlJavaTypeAdapter(GYearToIntegerAdapter.class)
    @XmlSchemaType(name = "gYear")
    protected Integer tmdlSchedule;
    @XmlElement(name = "TMDLPriority")
    @XmlJavaTypeAdapter(StringAdapter.class)
    protected String tmdlPriority;
    @XmlElement(name = "TMDLCompletionDate")
    @XmlSchemaType(name = "date")
    protected XMLGregorianCalendar tmdlCompletionDate;
    @XmlElement(name = "TMDLProjectStatus")
    protected String tmdlProjectStatus;
    @XmlElement(name = "TMDLProjectComment")
    protected String tmdlProjectComment;
    @XmlElement(name = "ImplementationActions")
    protected ImplementationActionsDataType implementationActions;
    @XmlElement(name = "ConsentDecreeCycle", type = String.class)
    @XmlJavaTypeAdapter(GYearToIntegerAdapter.class)
    @XmlSchemaType(name = "gYear")
    protected Integer consentDecreeCycle;
    @XmlElement(name = "PollutionSourceType")
    protected PollutionSourceTypeDataType pollutionSourceType;
    @XmlElement(name = "JustificationURL")
    protected String justificationURL;
    @XmlElement(name = "OtherPointSourceID")
    protected String otherPointSourceID;
    @XmlElement(name = "TMDLs")
    protected TMDLsDataType tmdLs;
    @XmlElement(name = "NPDES")
    protected NPDESDataType npdes;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the causeName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CAUSE_NAME", length = 240)
    public String getCauseName() {
        return causeName;
    }

    /**
     * Sets the value of the causeName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCauseName(String value) {
        this.causeName = value;
    }

    @Transient
    public boolean isSetCauseName() {
        return (this.causeName!= null);
    }

    /**
     * Gets the value of the cycleFirstListed property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CYCLE_FIRST_LISTED")
    public Integer getCycleFirstListed() {
        return cycleFirstListed;
    }

    /**
     * Sets the value of the cycleFirstListed property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCycleFirstListed(Integer value) {
        this.cycleFirstListed = value;
    }

    @Transient
    public boolean isSetCycleFirstListed() {
        return (this.cycleFirstListed!= null);
    }

    /**
     * Gets the value of the expectedToAttainDate property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    @Transient
    public XMLGregorianCalendar getExpectedToAttainDate() {
        return expectedToAttainDate;
    }

    /**
     * Sets the value of the expectedToAttainDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setExpectedToAttainDate(XMLGregorianCalendar value) {
        this.expectedToAttainDate = value;
    }

    @Transient
    public boolean isSetExpectedToAttainDate() {
        return (this.expectedToAttainDate!= null);
    }

    /**
     * Gets the value of the tmdlSchedule property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TMDL_SCHEDULE")
    public Integer getTMDLSchedule() {
        return tmdlSchedule;
    }

    /**
     * Sets the value of the tmdlSchedule property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTMDLSchedule(Integer value) {
        this.tmdlSchedule = value;
    }

    @Transient
    public boolean isSetTMDLSchedule() {
        return (this.tmdlSchedule!= null);
    }

    /**
     * Gets the value of the tmdlPriority property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TMDL_PRI", columnDefinition = "6", length = 6)
    public String getTMDLPriority() {
        return tmdlPriority;
    }

    /**
     * Sets the value of the tmdlPriority property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTMDLPriority(String value) {
        this.tmdlPriority = value;
    }

    @Transient
    public boolean isSetTMDLPriority() {
        return (this.tmdlPriority!= null);
    }

    /**
     * Gets the value of the tmdlCompletionDate property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    @Transient
    public XMLGregorianCalendar getTMDLCompletionDate() {
        return tmdlCompletionDate;
    }

    /**
     * Sets the value of the tmdlCompletionDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setTMDLCompletionDate(XMLGregorianCalendar value) {
        this.tmdlCompletionDate = value;
    }

    @Transient
    public boolean isSetTMDLCompletionDate() {
        return (this.tmdlCompletionDate!= null);
    }

    /**
     * Gets the value of the tmdlProjectStatus property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TMDL_PRJT_STAT", length = 255)
    public String getTMDLProjectStatus() {
        return tmdlProjectStatus;
    }

    /**
     * Sets the value of the tmdlProjectStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTMDLProjectStatus(String value) {
        this.tmdlProjectStatus = value;
    }

    @Transient
    public boolean isSetTMDLProjectStatus() {
        return (this.tmdlProjectStatus!= null);
    }

    /**
     * Gets the value of the tmdlProjectComment property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "TMDL_PRJT_COMMENT", length = 4000)
    public String getTMDLProjectComment() {
        return tmdlProjectComment;
    }

    /**
     * Sets the value of the tmdlProjectComment property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTMDLProjectComment(String value) {
        this.tmdlProjectComment = value;
    }

    @Transient
    public boolean isSetTMDLProjectComment() {
        return (this.tmdlProjectComment!= null);
    }

    @OneToMany(targetEntity = ImplementationActionDetailsDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ASMT_UNIT_CAUSE_DTLS_ID", insertable = false, updatable = false)
    public List<ImplementationActionDetailsDataType> getImplementationActionDetails() {
        return (implementationActions != null ? implementationActions.getImplementationActionDetails() : null);
    }

    public void setImplementationActionDetails(List<ImplementationActionDetailsDataType> list)
    {
        if(implementationActions == null)
        {
            ObjectFactory fact = new ObjectFactory();
            setImplementationActions(fact.createImplementationActionsDataType());
        }
        getImplementationActions().setImplementationActionDetails(list);
    }

    /**
     * Gets the value of the implementationActions property.
     * 
     * @return
     *     possible object is
     *     {@link ImplementationActionsDataType }
     *     
     */
    @Transient
    public ImplementationActionsDataType getImplementationActions() {
        return implementationActions;
    }

    /**
     * Sets the value of the implementationActions property.
     * 
     * @param value
     *     allowed object is
     *     {@link ImplementationActionsDataType }
     *     
     */
    public void setImplementationActions(ImplementationActionsDataType value) {
        this.implementationActions = value;
    }

    @Transient
    public boolean isSetImplementationActions() {
        return (this.implementationActions!= null);
    }

    /**
     * Gets the value of the consentDecreeCycle property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CNST_DECREE_CYCLE")
    public Integer getConsentDecreeCycle() {
        return consentDecreeCycle;
    }

    /**
     * Sets the value of the consentDecreeCycle property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setConsentDecreeCycle(Integer value) {
        this.consentDecreeCycle = value;
    }

    @Transient
    public boolean isSetConsentDecreeCycle() {
        return (this.consentDecreeCycle!= null);
    }

    /**
     * Gets the value of the pollutionSourceType property.
     * 
     * @return
     *     possible object is
     *     {@link PollutionSourceTypeDataType }
     *     
     */
    @Basic
    @Column(name = "POLLUTION_SRC_TYPE", length = 255)
    @Enumerated(EnumType.STRING)
    public PollutionSourceTypeDataType getPollutionSourceType() {
        return pollutionSourceType;
    }

    /**
     * Sets the value of the pollutionSourceType property.
     * 
     * @param value
     *     allowed object is
     *     {@link PollutionSourceTypeDataType }
     *     
     */
    public void setPollutionSourceType(PollutionSourceTypeDataType value) {
        this.pollutionSourceType = value;
    }

    @Transient
    public boolean isSetPollutionSourceType() {
        return (this.pollutionSourceType!= null);
    }

    /**
     * Gets the value of the justificationURL property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "JUSTIFICATION_URL", length = 250)
    public String getJustificationURL() {
        return justificationURL;
    }

    /**
     * Sets the value of the justificationURL property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setJustificationURL(String value) {
        this.justificationURL = value;
    }

    @Transient
    public boolean isSetJustificationURL() {
        return (this.justificationURL!= null);
    }

    /**
     * Gets the value of the otherPointSourceID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "OTHER_PT_SRC_ID", length = 4000)
    public String getOtherPointSourceID() {
        return otherPointSourceID;
    }

    /**
     * Sets the value of the otherPointSourceID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOtherPointSourceID(String value) {
        this.otherPointSourceID = value;
    }

    @Transient
    public boolean isSetOtherPointSourceID() {
        return (this.otherPointSourceID!= null);
    }

    @OneToMany(targetEntity = TMDLsDetailsDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ASMT_UNIT_CAUSE_DTLS_ID", insertable = false, updatable = false)
    public List<TMDLsDetailsDataType> getTMDLsDetails() {
        return (tmdLs != null ? tmdLs.getTMDLsDetails() : null);
    }

    public void setTMDLsDetails(List<TMDLsDetailsDataType> list)
    {
        if(tmdLs == null)
        {
            ObjectFactory fact = new ObjectFactory();
            setTMDLs(fact.createTMDLsDataType());
        }
        getTMDLs().setTMDLsDetails(list);
    }

    /**
     * Gets the value of the tmdLs property.
     * 
     * @return
     *     possible object is
     *     {@link TMDLsDataType }
     *     
     */
    @Transient
    public TMDLsDataType getTMDLs() {
        return tmdLs;
    }

    /**
     * Sets the value of the tmdLs property.
     * 
     * @param value
     *     allowed object is
     *     {@link TMDLsDataType }
     *     
     */
    public void setTMDLs(TMDLsDataType value) {
        this.tmdLs = value;
    }

    @Transient
    public boolean isSetTMDLs() {
        return (this.tmdLs!= null);
    }

    @OneToMany(targetEntity = NPDESDetailsDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ASMT_UNIT_CAUSE_DTLS_ID", insertable = false, updatable = false)
    public List<NPDESDetailsDataType> getNPDESDetails() {
        return (npdes != null ? npdes.getNPDESDetails() : null);
    }

    public void setNPDESDetails(List<NPDESDetailsDataType> list)
    {
        if(npdes == null)
        {
            ObjectFactory fact = new ObjectFactory();
            setNPDES(fact.createNPDESDataType());
        }
        getNPDES().setNPDESDetails(list);
    }

    /**
     * Gets the value of the npdes property.
     * 
     * @return
     *     possible object is
     *     {@link NPDESDataType }
     *     
     */
    @Transient
    public NPDESDataType getNPDES() {
        return npdes;
    }

    /**
     * Sets the value of the npdes property.
     * 
     * @param value
     *     allowed object is
     *     {@link NPDESDataType }
     *     
     */
    public void setNPDES(NPDESDataType value) {
        this.npdes = value;
    }

    @Transient
    public boolean isSetNPDES() {
        return (this.npdes!= null);
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
    @Column(name = "ASMT_UNIT_CAUSE_DTLS_ID")
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

    @Basic
    @Column(name = "EXPECTED_TO_ATTAIN_DATE")
    @Temporal(TemporalType.DATE)
    public Date getExpectedToAttainDateItem() {
        return XmlAdapterUtils.unmarshall(XMLGregorianCalendarAsDate.class, this.getExpectedToAttainDate());
    }

    public void setExpectedToAttainDateItem(Date target) {
        setExpectedToAttainDate(XmlAdapterUtils.marshall(XMLGregorianCalendarAsDate.class, target));
    }

    @Basic
    @Column(name = "TMDL_COMP_DATE")
    @Temporal(TemporalType.DATE)
    public Date getTMDLCompletionDateItem() {
        return XmlAdapterUtils.unmarshall(XMLGregorianCalendarAsDate.class, this.getTMDLCompletionDate());
    }

    public void setTMDLCompletionDateItem(Date target) {
        setTMDLCompletionDate(XmlAdapterUtils.marshall(XMLGregorianCalendarAsDate.class, target));
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof AssessmentUnitCauseDetailsDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final AssessmentUnitCauseDetailsDataType that = ((AssessmentUnitCauseDetailsDataType) object);
        {
            String lhsCauseName;
            lhsCauseName = this.getCauseName();
            String rhsCauseName;
            rhsCauseName = that.getCauseName();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "causeName", lhsCauseName), LocatorUtils.property(thatLocator, "causeName", rhsCauseName), lhsCauseName, rhsCauseName)) {
                return false;
            }
        }
        {
            Integer lhsCycleFirstListed;
            lhsCycleFirstListed = this.getCycleFirstListed();
            Integer rhsCycleFirstListed;
            rhsCycleFirstListed = that.getCycleFirstListed();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "cycleFirstListed", lhsCycleFirstListed), LocatorUtils.property(thatLocator, "cycleFirstListed", rhsCycleFirstListed), lhsCycleFirstListed, rhsCycleFirstListed)) {
                return false;
            }
        }
        {
            XMLGregorianCalendar lhsExpectedToAttainDate;
            lhsExpectedToAttainDate = this.getExpectedToAttainDate();
            XMLGregorianCalendar rhsExpectedToAttainDate;
            rhsExpectedToAttainDate = that.getExpectedToAttainDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "expectedToAttainDate", lhsExpectedToAttainDate), LocatorUtils.property(thatLocator, "expectedToAttainDate", rhsExpectedToAttainDate), lhsExpectedToAttainDate, rhsExpectedToAttainDate)) {
                return false;
            }
        }
        {
            Integer lhsTMDLSchedule;
            lhsTMDLSchedule = this.getTMDLSchedule();
            Integer rhsTMDLSchedule;
            rhsTMDLSchedule = that.getTMDLSchedule();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdlSchedule", lhsTMDLSchedule), LocatorUtils.property(thatLocator, "tmdlSchedule", rhsTMDLSchedule), lhsTMDLSchedule, rhsTMDLSchedule)) {
                return false;
            }
        }
        {
            String lhsTMDLPriority;
            lhsTMDLPriority = this.getTMDLPriority();
            String rhsTMDLPriority;
            rhsTMDLPriority = that.getTMDLPriority();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdlPriority", lhsTMDLPriority), LocatorUtils.property(thatLocator, "tmdlPriority", rhsTMDLPriority), lhsTMDLPriority, rhsTMDLPriority)) {
                return false;
            }
        }
        {
            XMLGregorianCalendar lhsTMDLCompletionDate;
            lhsTMDLCompletionDate = this.getTMDLCompletionDate();
            XMLGregorianCalendar rhsTMDLCompletionDate;
            rhsTMDLCompletionDate = that.getTMDLCompletionDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdlCompletionDate", lhsTMDLCompletionDate), LocatorUtils.property(thatLocator, "tmdlCompletionDate", rhsTMDLCompletionDate), lhsTMDLCompletionDate, rhsTMDLCompletionDate)) {
                return false;
            }
        }
        {
            String lhsTMDLProjectStatus;
            lhsTMDLProjectStatus = this.getTMDLProjectStatus();
            String rhsTMDLProjectStatus;
            rhsTMDLProjectStatus = that.getTMDLProjectStatus();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdlProjectStatus", lhsTMDLProjectStatus), LocatorUtils.property(thatLocator, "tmdlProjectStatus", rhsTMDLProjectStatus), lhsTMDLProjectStatus, rhsTMDLProjectStatus)) {
                return false;
            }
        }
        {
            String lhsTMDLProjectComment;
            lhsTMDLProjectComment = this.getTMDLProjectComment();
            String rhsTMDLProjectComment;
            rhsTMDLProjectComment = that.getTMDLProjectComment();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdlProjectComment", lhsTMDLProjectComment), LocatorUtils.property(thatLocator, "tmdlProjectComment", rhsTMDLProjectComment), lhsTMDLProjectComment, rhsTMDLProjectComment)) {
                return false;
            }
        }
        {
            ImplementationActionsDataType lhsImplementationActions;
            lhsImplementationActions = this.getImplementationActions();
            ImplementationActionsDataType rhsImplementationActions;
            rhsImplementationActions = that.getImplementationActions();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "implementationActions", lhsImplementationActions), LocatorUtils.property(thatLocator, "implementationActions", rhsImplementationActions), lhsImplementationActions, rhsImplementationActions)) {
                return false;
            }
        }
        {
            Integer lhsConsentDecreeCycle;
            lhsConsentDecreeCycle = this.getConsentDecreeCycle();
            Integer rhsConsentDecreeCycle;
            rhsConsentDecreeCycle = that.getConsentDecreeCycle();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "consentDecreeCycle", lhsConsentDecreeCycle), LocatorUtils.property(thatLocator, "consentDecreeCycle", rhsConsentDecreeCycle), lhsConsentDecreeCycle, rhsConsentDecreeCycle)) {
                return false;
            }
        }
        {
            PollutionSourceTypeDataType lhsPollutionSourceType;
            lhsPollutionSourceType = this.getPollutionSourceType();
            PollutionSourceTypeDataType rhsPollutionSourceType;
            rhsPollutionSourceType = that.getPollutionSourceType();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "pollutionSourceType", lhsPollutionSourceType), LocatorUtils.property(thatLocator, "pollutionSourceType", rhsPollutionSourceType), lhsPollutionSourceType, rhsPollutionSourceType)) {
                return false;
            }
        }
        {
            String lhsJustificationURL;
            lhsJustificationURL = this.getJustificationURL();
            String rhsJustificationURL;
            rhsJustificationURL = that.getJustificationURL();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "justificationURL", lhsJustificationURL), LocatorUtils.property(thatLocator, "justificationURL", rhsJustificationURL), lhsJustificationURL, rhsJustificationURL)) {
                return false;
            }
        }
        {
            String lhsOtherPointSourceID;
            lhsOtherPointSourceID = this.getOtherPointSourceID();
            String rhsOtherPointSourceID;
            rhsOtherPointSourceID = that.getOtherPointSourceID();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "otherPointSourceID", lhsOtherPointSourceID), LocatorUtils.property(thatLocator, "otherPointSourceID", rhsOtherPointSourceID), lhsOtherPointSourceID, rhsOtherPointSourceID)) {
                return false;
            }
        }
        {
            TMDLsDataType lhsTMDLs;
            lhsTMDLs = this.getTMDLs();
            TMDLsDataType rhsTMDLs;
            rhsTMDLs = that.getTMDLs();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "tmdLs", lhsTMDLs), LocatorUtils.property(thatLocator, "tmdLs", rhsTMDLs), lhsTMDLs, rhsTMDLs)) {
                return false;
            }
        }
        {
            NPDESDataType lhsNPDES;
            lhsNPDES = this.getNPDES();
            NPDESDataType rhsNPDES;
            rhsNPDES = that.getNPDES();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "npdes", lhsNPDES), LocatorUtils.property(thatLocator, "npdes", rhsNPDES), lhsNPDES, rhsNPDES)) {
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
            String theCauseName;
            theCauseName = this.getCauseName();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "causeName", theCauseName), currentHashCode, theCauseName);
        }
        {
            Integer theCycleFirstListed;
            theCycleFirstListed = this.getCycleFirstListed();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "cycleFirstListed", theCycleFirstListed), currentHashCode, theCycleFirstListed);
        }
        {
            XMLGregorianCalendar theExpectedToAttainDate;
            theExpectedToAttainDate = this.getExpectedToAttainDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "expectedToAttainDate", theExpectedToAttainDate), currentHashCode, theExpectedToAttainDate);
        }
        {
            Integer theTMDLSchedule;
            theTMDLSchedule = this.getTMDLSchedule();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdlSchedule", theTMDLSchedule), currentHashCode, theTMDLSchedule);
        }
        {
            String theTMDLPriority;
            theTMDLPriority = this.getTMDLPriority();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdlPriority", theTMDLPriority), currentHashCode, theTMDLPriority);
        }
        {
            XMLGregorianCalendar theTMDLCompletionDate;
            theTMDLCompletionDate = this.getTMDLCompletionDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdlCompletionDate", theTMDLCompletionDate), currentHashCode, theTMDLCompletionDate);
        }
        {
            String theTMDLProjectStatus;
            theTMDLProjectStatus = this.getTMDLProjectStatus();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdlProjectStatus", theTMDLProjectStatus), currentHashCode, theTMDLProjectStatus);
        }
        {
            String theTMDLProjectComment;
            theTMDLProjectComment = this.getTMDLProjectComment();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdlProjectComment", theTMDLProjectComment), currentHashCode, theTMDLProjectComment);
        }
        {
            ImplementationActionsDataType theImplementationActions;
            theImplementationActions = this.getImplementationActions();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "implementationActions", theImplementationActions), currentHashCode, theImplementationActions);
        }
        {
            Integer theConsentDecreeCycle;
            theConsentDecreeCycle = this.getConsentDecreeCycle();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "consentDecreeCycle", theConsentDecreeCycle), currentHashCode, theConsentDecreeCycle);
        }
        {
            PollutionSourceTypeDataType thePollutionSourceType;
            thePollutionSourceType = this.getPollutionSourceType();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "pollutionSourceType", thePollutionSourceType), currentHashCode, thePollutionSourceType);
        }
        {
            String theJustificationURL;
            theJustificationURL = this.getJustificationURL();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "justificationURL", theJustificationURL), currentHashCode, theJustificationURL);
        }
        {
            String theOtherPointSourceID;
            theOtherPointSourceID = this.getOtherPointSourceID();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "otherPointSourceID", theOtherPointSourceID), currentHashCode, theOtherPointSourceID);
        }
        {
            TMDLsDataType theTMDLs;
            theTMDLs = this.getTMDLs();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "tmdLs", theTMDLs), currentHashCode, theTMDLs);
        }
        {
            NPDESDataType theNPDES;
            theNPDES = this.getNPDES();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "npdes", theNPDES), currentHashCode, theNPDES);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.03 at 05:58:07 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.DateAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for StormWaterUnpermittedConstructionInspection complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="StormWaterUnpermittedConstructionInspection">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}StormWaterConstructionInspectionGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "StormWaterUnpermittedConstructionInspection", propOrder = {
    "projectType",
    "estimatedStartDate",
    "estimatedCompleteDate",
    "estimatedAreaDisturbedAcresNumber",
    "projectPlanSizeCode"
})
@Entity(name = "StormWaterUnpermittedConstructionInspection")
@Table(name = "ICS_SW_UNPRMT_CNST_INSP")
@Inheritance(strategy = InheritanceType.JOINED)
public class StormWaterUnpermittedConstructionInspection
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ProjectType")
    protected ProjectType projectType;
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
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the projectType property.
     * 
     * @return
     *     possible object is
     *     {@link ProjectType }
     *     
     */
    @ManyToOne(targetEntity = ProjectType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_SW_UNPRMT_CNST_INSP_ID", insertable = false, updatable = false)
    public ProjectType getProjectType() {
        return projectType;
    }

    /**
     * Sets the value of the projectType property.
     * 
     * @param value
     *     allowed object is
     *     {@link ProjectType }
     *     
     */
    public void setProjectType(ProjectType value) {
        this.projectType = value;
    }

    @Transient
    public boolean isSetProjectType() {
        return (this.projectType!= null);
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
    public void setEstimatedStartDate(Date value) {
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
    public void setEstimatedCompleteDate(Date value) {
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
    public void setEstimatedAreaDisturbedAcresNumber(Integer value) {
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
    public void setProjectPlanSizeCode(String value) {
        this.projectPlanSizeCode = value;
    }

    @Transient
    public boolean isSetProjectPlanSizeCode() {
        return (this.projectPlanSizeCode!= null);
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
    @Column(name = "ICS_SW_UNPRMT_CNST_INSP_ID")
    public String getdbid() {
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
    public void setdbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof StormWaterUnpermittedConstructionInspection)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final StormWaterUnpermittedConstructionInspection that = ((StormWaterUnpermittedConstructionInspection) object);
        {
            ProjectType lhsProjectType;
            lhsProjectType = this.getProjectType();
            ProjectType rhsProjectType;
            rhsProjectType = that.getProjectType();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "projectType", lhsProjectType), LocatorUtils.property(thatLocator, "projectType", rhsProjectType), lhsProjectType, rhsProjectType)) {
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
        return true;
    }

    public boolean equals(Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    public int hashCode(ObjectLocator locator, HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            ProjectType theProjectType;
            theProjectType = this.getProjectType();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "projectType", theProjectType), currentHashCode, theProjectType);
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
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}

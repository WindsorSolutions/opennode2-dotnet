//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra54.domain.generated;

import java.util.ArrayList;
import java.util.List;
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
 * Hazardous waste permit.
 * 
 * <p>Java class for HazardousWastePermitDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="HazardousWastePermitDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}PermitFacilitySubmission" maxOccurs="unbounded"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "HazardousWastePermitDataType", propOrder = {
    "permitFacilitySubmission"
})
@Entity(name = "HazardousWastePermitDataType")
@Table(name = "RCRA_HZRDWASTEPERMIT")
@Inheritance(strategy = InheritanceType.JOINED)
public class HazardousWastePermitDataType
    implements Equals, HashCode
{

    @XmlElement(name = "PermitFacilitySubmission", required = true)
    protected List<PermitFacilitySubmissionDataType> permitFacilitySubmission;
    @XmlAttribute(name = "Id")
    protected Long id;

    /**
     * Gets the value of the permitFacilitySubmission property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the permitFacilitySubmission property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getPermitFacilitySubmission().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link PermitFacilitySubmissionDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = PermitFacilitySubmissionDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "HZRDWASTEPERMITID")
    public List<PermitFacilitySubmissionDataType> getPermitFacilitySubmission() {
        if (permitFacilitySubmission == null) {
            permitFacilitySubmission = new ArrayList<PermitFacilitySubmissionDataType>();
        }
        return this.permitFacilitySubmission;
    }

    /**
     * 
     * 
     */
    public void setPermitFacilitySubmission(List<PermitFacilitySubmissionDataType> permitFacilitySubmission) {
        this.permitFacilitySubmission = permitFacilitySubmission;
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
        if (!(object instanceof HazardousWastePermitDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final HazardousWastePermitDataType that = ((HazardousWastePermitDataType) object);
        {
            List<PermitFacilitySubmissionDataType> lhsPermitFacilitySubmission;
            lhsPermitFacilitySubmission = (((this.permitFacilitySubmission!= null)&&(!this.permitFacilitySubmission.isEmpty()))?this.getPermitFacilitySubmission():null);
            List<PermitFacilitySubmissionDataType> rhsPermitFacilitySubmission;
            rhsPermitFacilitySubmission = (((that.permitFacilitySubmission!= null)&&(!that.permitFacilitySubmission.isEmpty()))?that.getPermitFacilitySubmission():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitFacilitySubmission", lhsPermitFacilitySubmission), LocatorUtils.property(thatLocator, "permitFacilitySubmission", rhsPermitFacilitySubmission), lhsPermitFacilitySubmission, rhsPermitFacilitySubmission)) {
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
            List<PermitFacilitySubmissionDataType> thePermitFacilitySubmission;
            thePermitFacilitySubmission = (((this.permitFacilitySubmission!= null)&&(!this.permitFacilitySubmission.isEmpty()))?this.getPermitFacilitySubmission():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitFacilitySubmission", thePermitFacilitySubmission), currentHashCode, thePermitFacilitySubmission);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}